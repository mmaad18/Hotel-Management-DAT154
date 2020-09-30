using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using HotelManagement.DAL.Repositorys.General;
using HotelManagement.Reception.Messages.General;
using HotelManagement.Reception.Messages.Update;
using HotelManagement.Reception.Services.DataService;
using HotelManagement.Reception.Services.Login;
using HotelManagement.Reception.Services.Navigation.Interfaces;
using HotelManagement.Reception.Services.Notification;
using MahApps.Metro.Controls.Dialogs;

namespace HotelManagement.Reception.ViewModel
{
    /// <summary>
    ///     This class contains properties that the main View can data bind to.
    ///     <para>
    ///         See http://www.mvvmlight.net
    ///     </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private bool _dialogHostIsOpen;

        /// <summary>
        ///     Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService,
            IDialogCoordinator dialogCoordinator, IHotelRepository hotelRepository,
            INavigationService navigationService)
        {
            HotelRepository = hotelRepository;

            NavigationService = navigationService;
            DialogCoordinator = dialogCoordinator;
            LoginService = new DialogLoginService(DialogCoordinator);
            //OnLoadedCommand = new RelayCommand(OnLoaded);
            Messenger.Default.Register<CloseDialogMessage>(this, x => DialogHostIsOpen = false);

            DispatcherTimer = new DispatcherTimer();
            DispatcherTimer.Interval = new TimeSpan(0, 0, 15);
            DispatcherTimer.Tick += DispatcherTimerOnTick;
            DispatcherTimer.Start();
            
        }

        public INavigationService NavigationService { get; set; }
        public INotificationService NotificationService { get; set; }
        private IDialogCoordinator DialogCoordinator { get; }
        public ILoginService LoginService { get; }
        public DispatcherTimer DispatcherTimer { get; set; }

        public RelayCommand OnLoadedCommand { get; private set; }
        public RelayCommand LogoutCommand { get; private set; }

        public IHotelRepository HotelRepository { get; set; }

        public bool DialogHostIsOpen
        {
            get => _dialogHostIsOpen;
            set
            {
                _dialogHostIsOpen = value;
                RaisePropertyChanged();
            }
        }

        private void DispatcherTimerOnTick(object sender, EventArgs eventArgs)
        {
            HotelRepository.RefreshAll();
            Messenger.Default.Send(new UpdateBillMessage());
            Messenger.Default.Send(new UpdateGuestMessage());
            Messenger.Default.Send(new UpdateReciptMessage());
            Messenger.Default.Send(new UpdateRoomMessage());
        }

        private async void OnLoaded()
        {
            //Awaits the loginService before doing anything else
            await RunLoginService();
        }

        private async Task RunLoginService()
        {
            await LoginService.Login();
        }

        ~MainViewModel()
        {
            DispatcherTimer.Stop();
        }
        ////}

        ////    base.Cleanup();
        ////    // Clean up if needed
        ////{


        ////public override void Cleanup()
    }
}