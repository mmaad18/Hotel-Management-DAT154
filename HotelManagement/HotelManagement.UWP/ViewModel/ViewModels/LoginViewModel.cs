using System;
using System.Net.Http;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using HotelManagement.UWP.Entities.Messeges;
using HotelManagement.UWP.Entities.Persons;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;

namespace HotelManagement.UWP.ViewModel.ViewModels
{
    public class LoginViewModel : ViewModelBase, IDisposable
    {
        private string _password;
        private string _username;

        public LoginViewModel(INavigationService navigationService)
        {
            HttpClient = new HttpClient();
            NavigationService = navigationService;
            LoginCommand = new RelayCommand(async () => await Test());
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        public HttpClient HttpClient { get; set; }

        public RelayCommand LoginCommand { get; set; }
        public INavigationService NavigationService { get; set; }

        public void Dispose()
        {
            HttpClient?.Dispose();
        }

        private async Task Test()
        {
            var uri = new Uri($"http://localhost:55908/api/Employees/validation/{Username}/{Password}");
            var response = string.Empty;
            try
            {
                response = await HttpClient.GetStringAsync(uri);
            }
            catch (HttpRequestException e)
            {
                var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                await dialog.ShowMessage("Wrong Username or password", "Authentication Failed");
                return;
            }
            catch (Exception e)
            {
                var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                await dialog.ShowMessage("Webserver not found", "Start Webserver");
                return;
            }


            Employee account = null;
            try
            {
                account = JsonConvert.DeserializeObject<Employee>(response);
            }
            catch (JsonSerializationException e)
            {
                var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                await dialog.ShowMessage("Wrong Username or Password", "Authentication Failed");
                return;
            }

            if (account != null)
            {
                NavigationService.NavigateTo(ViewModelLocator.RoomServicesKey);
                Messenger.Default.Send(new LoginMessage(account));

                var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                await dialog.ShowMessage("Welcome " + account.FullName, "Login Success");
            }
        }
    }
}