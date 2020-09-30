using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using HotelManagement.UWP.Converter;
using HotelManagement.UWP.DAL.Api.Repository;
using HotelManagement.UWP.Entities.Display;
using HotelManagement.UWP.Entities.Messeges;
using HotelManagement.UWP.Entities.Persons;
using HotelManagement.UWP.Entities.Rooms;
using HotelManagement.UWP.Entities.Rooms.States;
using HotelManagement.UWP.Entities.RoomServices;

namespace HotelManagement.UWP.ViewModel.ViewModels
{
    public class RoomServicesViewModel : ViewModelBase, IDisposable
    {
        private Employee _loggedInnEmployee;
        private ObservableCollection<RoomServiceDisplay> _roomService;
        private RoomService _selectedRoomService;

        public RoomServicesViewModel(INavigationService navigationService,IDialogService dialogService)
        {
            NavigationService = navigationService;
            DialogService = dialogService;
            RoomServiceConverter = new RoomServiceConverter();
            LoadedCommand = new RelayCommand(PageLoadedEvent);
            LogOut = new RelayCommand(Logout);
            Messenger.Default.Register<LoginMessage>(this, SetLogedInnEmployee);
            HttpClient = new HttpClient();
            PerformService = new RelayCommand<RoomServiceDisplay>(ExecutePerformService);
        }

        private void Logout()
        {
            DispatcherTimer.Stop();
            NavigationService.NavigateTo(ViewModelLocator.LoginViewKey);

        }

        public HttpClient HttpClient { get; set; }
        public RelayCommand LoadedCommand { get; set; }
        public DispatcherTimer DispatcherTimer { get; set; }
        public RoomServiceConverter RoomServiceConverter { get; set; }
        public INavigationService NavigationService { get; set; }
        public RelayCommand<RoomServiceDisplay> PerformService { get; set; }
        public RelayCommand LogOut { get; set; }

        public HotelManagementRepository HotelManagementRepository { get; set; }
        public IDialogService DialogService { get; set; }


        public RoomService SelectedRoomService
        {
            get => _selectedRoomService;
            set
            {
                _selectedRoomService = value;
                RaisePropertyChanged();
            }
        }


        public ObservableCollection<RoomServiceDisplay> RoomServices
        {
            get => _roomService;
            set
            {
                _roomService = value;
                RaisePropertyChanged();
            }
        }


        public Employee LoggedInnEmployee
        {
            get => _loggedInnEmployee;
            set
            {
                _loggedInnEmployee = value;
                RaisePropertyChanged();
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void ExecutePerformService(RoomServiceDisplay roomServiceDisplay)
        {
            if (roomServiceDisplay == null)
                return;

            roomServiceDisplay.Employee = LoggedInnEmployee;
            roomServiceDisplay.DatePerformed = DateTime.Now.Date.ToUniversalTime();
            roomServiceDisplay.Ordered = roomServiceDisplay.Ordered.Date;
            var roomService = RoomServiceConverter.ToRoomService(roomServiceDisplay);


            UpdateRoomService(roomService);
            UpdateRoom(roomService);
            RoomServices.Remove(roomServiceDisplay);
            
        }

        private async void UpdateRoom(RoomService roomservice)
        {
            if (!roomservice.RoomId.HasValue)
            {
                await DialogService.ShowMessage("Food Delivey Completed ", "Food Delivery");
                return;
            }
            var room = await HotelManagementRepository.RoomRepository.GetRoom(roomservice.RoomId.Value);

            room.State = GetNewRoomState(room, roomservice);
            await HotelManagementRepository.RoomRepository.UpdateRoom(room);
            await DialogService.ShowMessage("Service performed on room " + room.RoomNumber, "Service performed");
        }

        private RoomState GetNewRoomState(Room room, RoomService roomService)
        {
            switch (roomService.Type)
            {
                case "JanitorService":
                    if (room.State.GetType() == typeof(MaintenanceState))
                        return new NotCleanedState();
                    break;
                case "HousekeepingService":
                    if (room.State.GetType() == typeof(NotCleanedState))
                        return new AvailableState();
                    break;
            }
            return room.State;
        }


        private void UpdateRoomService(RoomService roomService)
        {
            HotelManagementRepository.RoomServiceRepository.UpdateRoomService(roomService);
        }

        private void SetLogedInnEmployee(LoginMessage obj)
        {
            LoggedInnEmployee = obj.Employee;
        }

        private void PageLoadedEvent()
        {
            HotelManagementRepository = new HotelManagementRepository(LoggedInnEmployee);
            GetRoomServices(null, null);
            DispatcherTimer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 20)};
            DispatcherTimer.Tick += GetRoomServices;
            DispatcherTimer.Start();
        }

        private async void GetRoomServices(object o, object o1)
        {
            var roomServiceList = await HotelManagementRepository.RoomServiceRepository.GetAllRoomsServices();

            RoomServices = new ObservableCollection<RoomServiceDisplay>();
            foreach (var roomService in roomServiceList)
                RoomServices.Add(await RoomServiceConverter.ToRoomServiceDisplay(roomService));


            //RoomServices = new ObservableCollection<RoomService>(roomServiceList);
        }


        ~RoomServicesViewModel()
        {
            Dispose();
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                HttpClient?.Dispose();
                DispatcherTimer.Tick -= GetRoomServices;
                DispatcherTimer.Stop();
            }
        }
    }
}