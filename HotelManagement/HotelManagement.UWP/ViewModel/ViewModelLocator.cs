using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using HotelManagement.UWP.ViewModel.ViewModels;
using HotelManagement.UWP.Views;

namespace HotelManagement.UWP.ViewModel
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
        public const string RoomServicesKey = "RoomServices";
        public const string LoginViewKey = "LoginView";


        /// <summary>
        /// This property can be used to force the application to run with design time data.
        /// </summary>
        public static bool UseDesignTimeData
        {
            get
            {
                return false;
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var nav = new NavigationService();
            nav.Configure(LoginViewKey, typeof(LoginPage));
            nav.Configure(RoomServicesKey, typeof(RoomServicesPage));
            SimpleIoc.Default.Register<INavigationService>(() => nav);

            SimpleIoc.Default.Register<IDialogService, DialogService>();



            //if (ViewModelBase.IsInDesignModeStatic
            //        || UseDesignTimeData)
            //{
            //    SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            //}
            //else
            //{
            //    SimpleIoc.Default.Register<IDataService, DataService>();
            //}

            SimpleIoc.Default.Register<MainViewModel>(true);
            SimpleIoc.Default.Register<RoomServicesViewModel>(false);
            SimpleIoc.Default.Register<LoginViewModel>(false);
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public RoomServicesViewModel RoomServices => ServiceLocator.Current.GetInstance<RoomServicesViewModel>();
        public LoginViewModel Login => ServiceLocator.Current.GetInstance<LoginViewModel>();

    }
}
