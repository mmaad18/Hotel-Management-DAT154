using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using HotelManagement.DAL.Repositorys.General;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Reception.Messages.Update;
using HotelManagement.Reception.Services.Navigation.Interfaces;
using HotelManagement.Reception.Services.Notification;
using HotelManagement.Reception.ViewModel.Dialogs;
using HotelManagement.Reception.ViewModel.ViewModels.PersonViewModels.Search;
using HotelManagement.Reception.ViewModel.ViewModels.RecieptViewModels;
using HotelManagement.Reception.Views.Dialogs;
using HotelManagement.Reception.Views.PersonViews;
using HotelManagement.Reception.Views.RecieptViews;
using MaterialDesignThemes.Wpf;

namespace HotelManagement.Reception.ViewModel.ViewModels
{
    public class GuestViewModel : ViewModelBase, IDisplayable, IMenuView
    {
        public GuestViewModel()
        {
            EditGuestCommand = new RelayCommand(ExecuteEditGuest);
            NewGuestCommand = new RelayCommand(ExecuteNewGuest);
            DeleteGuestCommand = new RelayCommand(ExecuteDeleteGuest);
            CheckInnCommand = new RelayCommand(ExecuteCheckInn);
        }

        [PreferredConstructor]
        public GuestViewModel(IHotelRepository hotelRepository,
            INotificationService notificationService) : this()
        {
            HotelRepository = hotelRepository;
            NotificationService = notificationService;
            GuestSearchViewModel = new GuestSearchViewModel(HotelRepository.Guests);
        }

        public IHotelRepository HotelRepository { get; set; }
        public INotificationService NotificationService { get; set; }

        public GuestSearchViewModel GuestSearchViewModel { get; set; }
        public ObservableCollection<Guest> GuestCollection { get; set; }

        public RelayCommand EditGuestCommand { get; set; }
        public RelayCommand NewGuestCommand { get; set; }
        public RelayCommand DeleteGuestCommand { get; set; }
        public RelayCommand CheckInnCommand { get; set; }
        public RelayCommand CheckOutCommand { get; set; }
        public string DisplayTitle { get; set; } = "Guest View";
        public object Parameter { get; set; }

        private async void ExecuteCheckInn()
        {
            var guest = GuestSearchViewModel.SelectedPerson;
            if (guest == null)
            {
                NotificationService.Warning("No guest selected!", "You need to select a guest to edit");
                return;
            }
            var datacontext = new CreateRecieptViewModel(guest.Id, HotelRepository,
                NotificationService);
            var queryView = new CreateRecieptView
            {
                DataContext = datacontext
            };
            await DialogHost.Show(queryView);

            if (datacontext.Success)
            {
                HotelRepository.Guests.Update(datacontext.Guest);
                HotelRepository.Reciepts.Add(datacontext.Reciept);
                HotelRepository.Reciepts.Save();
            }

            Messenger.Default.Send(new UpdateGuestMessage());
            Messenger.Default.Send(new UpdateReciptMessage());
        }

        private async void ExecuteDeleteGuest()
        {
            var guest = GuestSearchViewModel.SelectedPerson;
            if (guest == null)
            {
                NotificationService.Warning("No guest selected!", "You need to select a guest to edit");
                return;
            }
            var queryView = new QueryDialogView
            {
                DataContext = new QueryDialogViewModel
                {
                    AcceptButtonText = "Delete",
                    CancelButtonText = "Cancel",
                    Info = "To delete" + GuestSearchViewModel.SelectedPerson.FullName + " type \"delete\""
                }
            };
            var result = await DialogHost.Show(queryView);
            var s = result as string;

            if (s == null || s.ToLower() != "delete") return;

            DeleteGuest(HotelRepository.Guests.Get(guest.Id));
        }

        private void DeleteGuest(Guest guest)
        {
            //if (guest.BookedRooms.Any())
            //{
            //    NotificationService.Warning("Delete failed",
            //        "Cannot delete person witch is staying at the hotel. Vacate guest first");
            //    return;
            //}

            HotelRepository.Guests.Delete(guest);
            HotelRepository.Guests.Save();

            Messenger.Default.Send(new UpdateGuestMessage());
        }


        private async void ExecuteEditGuest()
        {
            var guest = GuestSearchViewModel.SelectedPerson;
            if (guest == null)
            {
                NotificationService.Warning("No guest selected!", "You need to select a guest to edit");
                return;
            }
            var datacontext = new CreateUserViewModel(true, NotificationService, HotelRepository.Guests, guest.Id);
            await LaunchCreateEditDialog(datacontext);
        }


        private async void ExecuteNewGuest()
        {
            var datacontext = new CreateUserViewModel(false, NotificationService, HotelRepository.Guests);
            await LaunchCreateEditDialog(datacontext);
        }


        private async Task LaunchCreateEditDialog(CreateUserViewModel datacontext)
        {
            var queryView = new CreateUserView
            {
                DataContext = datacontext
            };
            await DialogHost.Show(queryView);
        }
    }
}