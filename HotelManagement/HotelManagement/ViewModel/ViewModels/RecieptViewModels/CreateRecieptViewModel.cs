using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HotelManagement.DAL.Repositorys.General;
using HotelManagement.Entities.Bills;
using HotelManagement.Entities.Bills.BillTypes;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Entities.Reciepts;
using HotelManagement.Entities.Rooms;
using HotelManagement.Entities.Rooms.RoomTypes;
using HotelManagement.Entities.Rooms.States;
using HotelManagement.Reception.Messages.General;
using HotelManagement.Reception.Messages.Update;
using HotelManagement.Reception.Services.Notification;
using HotelManagement.Reception.ViewModel.ViewModels.RoomViewModels;

namespace HotelManagement.Reception.ViewModel.ViewModels.RecieptViewModels
{
    public class CreateRecieptViewModel : ViewModelBase
    {
        private RoomSearchViewModel _roomSearchViewModel;
        private DateTime _settledDate;
        private DateTime _stayedFromDate = DateTime.Now;
        private DateTime _stayedToDate = DateTime.Now.AddDays(2);
        private double _amount;


        public CreateRecieptViewModel(int guestId, IHotelRepository hotelRepository,
            INotificationService notificationService)
        {
            HotelRepository = hotelRepository;

            NotificationService = notificationService;

            Guest = HotelRepository.Guests.Get(guestId);

            DisplayTitle = "Check Inn " + Guest.FullName;
            AcceptTitle = "Check Inn";
            Reciept = new Reciept();

            CreateRecieptCommand = new RelayCommand(ExecuteCreateReciept);
            GoBackCommand = new RelayCommand(ExecuteGoBack);

            RoomSearchViewModel = new RoomSearchViewModel(typeof(AvailableState), HotelRepository.Rooms);
        }


        public IHotelRepository HotelRepository { get; set; }
        public string DisplayTitle { get; set; }
        public string AcceptTitle { get; set; }
        public Guest Guest { get; set; }
        public Reciept Reciept { get; set; }
        public Room Room { get; set; }
        public bool Success { get; set; }
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

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public DateTime StayedFromDate
        {
            get => _stayedFromDate;
            set
            {
                _stayedFromDate = value;
                RaisePropertyChanged();
            }
        }

        public DateTime StayedToDate
        {
            get => _stayedToDate;
            set
            {
                _stayedToDate = value;
                RaisePropertyChanged();
            }
        }

        public DateTime SettledDate
        {
            get => _settledDate;
            set
            {
                _settledDate = value;
                RaisePropertyChanged();
            }
        }


        public RelayCommand CreateRecieptCommand { get; set; }
        public RelayCommand GoBackCommand { get; set; }

        private void ExecuteGoBack()
        {
            Messenger.Default.Send(new CloseDialogMessage());
        }

        private void ExecuteCreateReciept()
        {
            if (StayedToDate != default(DateTime) && StayedFromDate != default(DateTime) && Guest != null &&
                RoomSearchViewModel.SelectedRoom != null && Amount>0)
            {
                Room = HotelRepository.Rooms.Get(RoomSearchViewModel.SelectedRoom.Id);
                Reciept.StayedFromDate = StayedFromDate;
                Reciept.StayedToDate = StayedToDate;
                //Reciept.Guest = Guest;
                //fix kommer doble guest et sted
                Reciept.RoomId = Room.Id;
                Reciept.GuestName = Guest.FullName;
                Reciept.GuestId = Guest.Id;
                Reciept.RoomQuality = Room.Quality;
                Reciept.RoomType = Room.Type;
                HotelRepository.Reciepts.Add(Reciept);
                HotelRepository.Reciepts.Save();

                //var recipt = RecieptReposetory.FindBy(x => x.GuestId == Reciept.GuestId && StayedFromDate == Reciept.StayedFromDate)
                //    .First();

                Bill bill;
                if (Room is DoubleRoom)
                    bill = new RoomBill {Amount = Amount, OrderedDate = DateTime.Now, RecieptId = Reciept.Id};
                else
                    bill = new RoomBill {Amount = Amount, OrderedDate = DateTime.Now, RecieptId = Reciept.Id};
                HotelRepository.Bills.Add(bill);
                HotelRepository.Bills.Save();
                Room.GuestId = Guest.Id;
                Room.State = new OccupiedState();

                HotelRepository.Rooms.Update(Room);
                HotelRepository.Rooms.Save();
                NotificationService.Success("Booking Complete", Guest.FullName + " booked to room " + Room.RoomNumber);
                Messenger.Default.Send(new UpdateBillMessage());
                Messenger.Default.Send(new UpdateRoomMessage());
                Messenger.Default.Send(new UpdateReciptMessage());

                Messenger.Default.Send(new CloseDialogMessage());
            }
            else
            {
                NotificationService.Warning("Validation error!",
                    "You need to fill out all forms, and value not minus");
            }
        }
    }
}