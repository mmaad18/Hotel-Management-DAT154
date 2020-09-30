using System;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using HotelManagement.DAL.Repositorys.General;
using HotelManagement.Entities.Bills.States;
using HotelManagement.Entities.Reciepts.States;
using HotelManagement.Reception.Messages.Update;
using HotelManagement.Reception.Services.Navigation.Interfaces;
using HotelManagement.Reception.Services.Notification;
using HotelManagement.Reception.ViewModel.Bills;
using HotelManagement.Reception.ViewModel.ViewModels.RecieptViewModels;
using HotelManagement.Reception.Views.Bills;
using MaterialDesignThemes.Wpf;

namespace HotelManagement.Reception.ViewModel.ViewModels
{
    public class RecieptViewModel : ViewModelBase, IDisplayable, IMenuView
    {
        public RecieptViewModel()
        {
            SettleRecieptCommand = new RelayCommand(ExeCuteSettleReciept);
            AddBillCommand = new RelayCommand(ExecuteAddBill);
        }

        [PreferredConstructor]
        public RecieptViewModel(IHotelRepository hotelRepository,
            INotificationService notificationService) : this()
        {
            HotelRepository = hotelRepository;

            NotificationService = notificationService;
            RecieptSearchViewModel = new RecieptSearchViewModel(HotelRepository);
        }

        public IHotelRepository HotelRepository { get; set; }
        public CreateBillViewModel CreateBillViewModelContext { get; set; }
        public INotificationService NotificationService { get; set; }

        public RecieptSearchViewModel RecieptSearchViewModel { get; set; }

        public RelayCommand SettleRecieptCommand { get; set; }
        public RelayCommand AddBillCommand { get; set; }
        public string DisplayTitle { get; set; } = "Reciept View";
        public object Parameter { get; set; }

        private async void ExecuteAddBill()
        {
            var reciept = RecieptSearchViewModel.SelectedReciept;
            if (reciept == null)
            {
                NotificationService.Warning("No reciept selected!", "You need to select a reciept to edit");
                return;
            }
            CreateBillViewModelContext = new CreateBillViewModel(reciept, HotelRepository,
                NotificationService);
            var queryView = new CreateBillView
            {
                DataContext = CreateBillViewModelContext
            };
            await DialogHost.Show(queryView);
        }

        private void ExeCuteSettleReciept()
        {
            var recieptTemp = RecieptSearchViewModel.SelectedReciept;
            if (recieptTemp == null)
            {
                NotificationService.Warning("No Selected Reciept", "Select a reciept to settle");
                return;
            }
            var reciept = HotelRepository.Reciepts.Get(recieptTemp.Id);
            var bills = HotelRepository.Bills.GetBillsByReciept(reciept).ToList();

            foreach (var bill in bills.Where(x => x.State.GetType() == typeof(UnsettledBill)))
            {
                bill.State = new SettledBill();
                bill.PayedDate = DateTime.Now;
                HotelRepository.Bills.Update(bill);
            }
            HotelRepository.Bills.Save();

            reciept.State = new SettledReciept();
            reciept.SettledDate = DateTime.Now;
            HotelRepository.Reciepts.Update(reciept);
            HotelRepository.Reciepts.Save();

            RecieptSearchViewModel.UpdateRecieptsView();
            Messenger.Default.Send(new UpdateReciptMessage());
            Messenger.Default.Send(new UpdateBillMessage());
        }
    }
}