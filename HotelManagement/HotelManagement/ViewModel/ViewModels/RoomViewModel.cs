using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using HotelManagement.DAL.Repositorys.General;
using HotelManagement.Entities.Rooms;
using HotelManagement.Entities.Rooms.States;
using HotelManagement.Entities.RoomServices.Housekeeping;
using HotelManagement.Entities.RoomServices.Janitor;
using HotelManagement.Reception.Messages.Update;
using HotelManagement.Reception.Services.Navigation.Interfaces;
using HotelManagement.Reception.Services.Notification;
using HotelManagement.Reception.ViewModel.ViewModels.RoomViewModels;

namespace HotelManagement.Reception.ViewModel.ViewModels
{
    public class RoomViewModel : ViewModelBase, IDisplayable, IMenuView
    {
        private RoomSearchViewModel _roomSearchViewModel;

        public RoomViewModel()
        {
            NeedCleaningCommand = new RelayCommand(ExecuteNeedCleaning);
            CheckOutCommand = new RelayCommand(ExecuteCheckOut);
            NeedMaintnanceCommand = new RelayCommand(ExecuteNeedMaitnance);
        }

        [PreferredConstructor]
        public RoomViewModel(IHotelRepository hotelRepository, INotificationService notificationService) : this()
        {
            HotelRepository = hotelRepository;
            NotificationService = notificationService;
            Messenger.Default.Register<UpdateRoomMessage>(this,
                x => RoomSearchViewModel = new RoomSearchViewModel(typeof(Room), hotelRepository.Rooms));
            RoomSearchViewModel = new RoomSearchViewModel(typeof(Room), hotelRepository.Rooms);
        }

        public INotificationService NotificationService { get; set; }

        public RoomSearchViewModel RoomSearchViewModel
        {
            get => _roomSearchViewModel;
            set
            {
                _roomSearchViewModel = value;
                RaisePropertyChanged();
            }
        }

        public IHotelRepository HotelRepository { get; set; }

        public RelayCommand NeedMaintnanceCommand { get; set; }
        public RelayCommand CheckOutCommand { get; set; }
        public RelayCommand NeedCleaningCommand { get; set; }
        public string DisplayTitle { get; set; } = "Room View";
        public object Parameter { get; set; }

        private void ExecuteNeedMaitnance()
        {
            if (RoomSearchViewModel.SelectedRoom == null)
            {
                NotificationService.Warning("No room selected", "You need to select a room first");
                return;
            }
            var room = HotelRepository.Rooms.Get(RoomSearchViewModel.SelectedRoom.Id);
            room.GuestId = null;
            room.State = new MaintenanceState();

            HotelRepository.Rooms.Update(room);
            HotelRepository.Rooms.Save();
            var janitorService = new JanitorService {Ordered = DateTime.Now, RoomId = room.Id};

            HotelRepository.RoomServices.Add(janitorService);
            HotelRepository.RoomServices.Save();
            NotificationService.Success("Room issued for maitnance",
                "Room has has been issued for maitnance, room " + room.RoomNumber);

            Messenger.Default.Send(new UpdateRoomMessage());
        }

        private void ExecuteCheckOut()
        {
            if (RoomSearchViewModel.SelectedRoom == null)
            {
                NotificationService.Warning("No room selected", "You need to select a room first");
                return;
            }
            if (RoomSearchViewModel.SelectedRoom.State.GetType() != typeof(OccupiedState))
            {
                NotificationService.Warning("Room is empty", "You need to select a occupied room");
                return;
            }

            var room = HotelRepository.Rooms.Get(RoomSearchViewModel.SelectedRoom.Id);
            var guestname = room.Guest.FullName;
            room.GuestId = null;
            room.State = new NotCleanedState();

            HotelRepository.Rooms.Update(room);
            HotelRepository.Rooms.Save();
            var roomservice = new HousekeepingService {Ordered = DateTime.Now, RoomId = room.Id};
            HotelRepository.RoomServices.Add(roomservice);
            HotelRepository.RoomServices.Save();
            NotificationService.Success("Guest Checked out",
                "Guest " + guestname + " has checked out of room " + room.RoomNumber);
            Messenger.Default.Send(new UpdateRoomMessage());
        }

        private void ExecuteNeedCleaning()
        {
            var roomTemp = RoomSearchViewModel.SelectedRoom;
            if (roomTemp == null)
            {
                NotificationService.Warning("No room selected", "You need to select a room first");
                return;
            }
            if (roomTemp.State.GetType() == typeof(AvailableState) ||
                roomTemp.State.GetType() == typeof(MaintenanceState))
            {
                NotificationService.Warning("Room unavailable for cleening", "Room is clean or need maintanence");
                return;
            }

            var room = HotelRepository.Rooms.Get(RoomSearchViewModel.SelectedRoom.Id);

            var housekeepingService = new HousekeepingService {Ordered = DateTime.Now, RoomId = room.Id};

            HotelRepository.RoomServices.Add(housekeepingService);
            HotelRepository.RoomServices.Save();
            NotificationService.Success("Issued Cleaning Service",
                "Room " + room.RoomNumber + " is issued for cleaning");
        }
    }
}