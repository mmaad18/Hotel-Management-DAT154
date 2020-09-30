/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:HotelManagement.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using HotelManagement.DAL.Repositorys.Bills;
using HotelManagement.DAL.Repositorys.Employees;
using HotelManagement.DAL.Repositorys.General;
using HotelManagement.DAL.Repositorys.Guests;
using HotelManagement.DAL.Repositorys.Reciepts;
using HotelManagement.DAL.Repositorys.Rooms;
using HotelManagement.DAL.Repositorys.RoomServices;
using HotelManagement.Reception.Model;
using HotelManagement.Reception.Services.DataService;
using HotelManagement.Reception.Services.Login;
using HotelManagement.Reception.Services.Navigation;
using HotelManagement.Reception.Services.Navigation.Interfaces;
using HotelManagement.Reception.Services.Notification;
using HotelManagement.Reception.ViewModel.ViewModels;
using HotelManagement.Reception.ViewModel.ViewModels.PersonViewModels;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.ServiceLocation;

namespace HotelManagement.Reception.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }
            SimpleIoc.Default.Register<IDialogCoordinator, DialogCoordinator>(true);
            SimpleIoc.Default.Register<INotificationService, NotificationService>(true);
            SimpleIoc.Default.Register<INavigationService, NavigationService>(true);
            //SimpleIoc.Default.Register<IGuestRepository, GuestRepository>(true);
            //SimpleIoc.Default.Register<IEmployeeRepository, EmployeeRepository>(true);
            //SimpleIoc.Default.Register<IRecieptReposetory, ReciptReposetory>(true);
            //SimpleIoc.Default.Register<IRoomRepository, RoomRepository>(true);
            //SimpleIoc.Default.Register<IRoomServiceRepository, RoomServiceRepository>(true);

            //SimpleIoc.Default.Register<IBillRepository, BillRepository>(true);
            SimpleIoc.Default.Register<IHotelRepository,HotelRepository>(true);


            SimpleIoc.Default.Register<MainViewModel>();
            
            SimpleIoc.Default.Register<GuestViewModel>();
            SimpleIoc.Default.Register<RoomViewModel>();
            SimpleIoc.Default.Register<RecieptViewModel>();



        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public GuestViewModel Guest
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GuestViewModel>();
            }
        }
        public RoomViewModel Room
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RoomViewModel>();
            }
        }
        public RecieptViewModel Reciept
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RecieptViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}