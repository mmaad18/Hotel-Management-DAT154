using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HotelManagement.DAL.Repositorys.General;
using HotelManagement.Entities.Bills;
using HotelManagement.Entities.Bills.BillTypes;
using HotelManagement.Entities.Reciepts;
using HotelManagement.Entities.Reciepts.States;
using HotelManagement.Entities.Rooms;
using HotelManagement.Entities.Rooms.States;
using HotelManagement.Entities.RoomServices;
using HotelManagement.Entities.RoomServices.Food;
using HotelManagement.Entities.RoomServices.Housekeeping;
using HotelManagement.Reception.Messages.General;
using HotelManagement.Reception.Messages.Update;
using HotelManagement.Reception.Services.Notification;
using HotelManagement.Reception.ViewModel.ViewModels.RoomViewModels;

namespace HotelManagement.Reception.ViewModel.Bills
{
    public class CreateBillViewModel : ViewModelBase
    {
        private Bill _bill;
        private string _selectedBillType;

        public CreateBillViewModel(Reciept reciept, IHotelRepository hotelRepository,
            INotificationService notificationService)
        {
            HotelRepository = hotelRepository;
            RoomSearchViewModel = new RoomSearchViewModel(typeof(AvailableState), HotelRepository.Rooms);
            NotificationService = notificationService;
            Reciept = reciept;
            Bill = new RoomBill();
            BillTypes = new List<string> {"Cleaning Bill", "Food Bill", "Misc Bill", "Room Bill"};
            CreateBillCommand = new RelayCommand(ExecuteCreateBill);
            CancelCommand = new RelayCommand(ExecuteCancel);
        }

        public IHotelRepository HotelRepository { get; set; }
        public RoomSearchViewModel RoomSearchViewModel { get; set; }

        public INotificationService NotificationService { get; set; }

        public RelayCommand CreateBillCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        public List<string> BillTypes { get; set; }

        public string SelectedBillType
        {
            get => _selectedBillType;
            set
            {
                _selectedBillType = value;
                SetBillType(_selectedBillType);
                RaisePropertyChanged();
            }
        }

        public Reciept Reciept { get; set; }

        public Bill Bill
        {
            get => _bill;
            set
            {
                _bill = value;
                RaisePropertyChanged();
            }
        }

        private void SetBillType(string selectedBillType)
        {
            switch (selectedBillType)
            {
                case "Cleaning Bill":
                    Bill = new CleaningBill();
                    break;
                case "Food Bill":
                    Bill = new FoodBill();
                    break;
                case "Misc Bill":
                    Bill = new MiscBill();
                    break;
                case "Room Bill":
                    Bill = new RoomBill();
                    break;
                default:
                    Bill = new FoodBill();
                    break;
            }
        }

        private void ExecuteCancel()
        {
            Messenger.Default.Send(new CloseDialogMessage());
        }

        private void ExecuteCreateBill()
        {
            if (Bill.Amount >= 0)
            {
                if (Bill is RoomBill)
                {
                    var room = RoomSearchViewModel.SelectedRoom;
                    if (room == null)
                    {
                        NotificationService.Warning("Select Room", "Need to select Room before Creating");
                        return;
                    }
                    Reciept.RoomId = room.Id;
                    room.GuestId = Reciept.GuestId;
                    room.State = new OccupiedState();
                    HotelRepository.Rooms.Update(room);
                    HotelRepository.Rooms.Save();
                }

                Bill.OrderedDate = DateTime.Now;
                Bill.RecieptId = Reciept.Id;
                HotelRepository.Bills.Add(Bill);
                HotelRepository.Bills.Save();
                var reciept = HotelRepository.Reciepts.Get(Reciept.Id);
                reciept.State = new UnsettledReciept();
                HotelRepository.Reciepts.Update(reciept);
                HotelRepository.Reciepts.Save();

                AddServiceForBill(Bill, Reciept);

                Messenger.Default.Send(new UpdateBillMessage());
                Messenger.Default.Send(new UpdateReciptMessage());

                NotificationService.Success("Bill Created",
                    "Succsessfully added " + SelectedBillType + " with an amount of " + Bill.Amount);
                Messenger.Default.Send(new CloseDialogMessage());
            }
            else
            {
                NotificationService.Warning("Amount error", "Amount needs to be above zero");
            }
        }

        private void AddServiceForBill(Bill bill, Reciept reciept)
        {
            var room = HotelRepository.Rooms.Get(reciept.RoomId);
            RoomService roomservice = null;
            if (bill.GetType() == typeof(FoodBill))
                roomservice = new FoodService {Ordered = DateTime.Now, RoomId = room.Id};
            if (bill.GetType() == typeof(CleaningBill))
                roomservice = new HousekeepingService {Ordered = DateTime.Now, RoomId = room.Id};

            if (roomservice != null)
            {
                HotelRepository.RoomServices.Add(roomservice);
                HotelRepository.RoomServices.Save();
            }
        }
    }
}