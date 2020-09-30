using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace HotelManagement.UWP.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        ////private RelayCommand _incrementCommand;
        //private RelayCommand _sendMessageCommand;
        //private RelayCommand _showDialogCommand;
        private RelayCommand<string> _navigateCommand;
       
       

      

        

        public RelayCommand NavigateCommand { get; set; }

       

        //public RelayCommand ShowDialogCommand
        //{
        //    get
        //    {
        //        return _showDialogCommand
        //               ?? (_showDialogCommand = new RelayCommand(
        //                   async () =>
        //                   {
        //                       var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
        //                       await dialog.ShowMessage("Hello Universal Application", "it works...");
        //                   }));
        //    }
        //}

      

        public MainViewModel(
            INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new RelayCommand(InitiateLogin);
           
        }


        public void InitiateLogin()
        {
            _navigationService.NavigateTo(ViewModelLocator.LoginViewKey);
        }
      
    }
}