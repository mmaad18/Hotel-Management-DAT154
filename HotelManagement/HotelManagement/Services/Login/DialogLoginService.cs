using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HotelManagement.DAL.Repositorys.General;
using MahApps.Metro.Controls.Dialogs;

namespace HotelManagement.Reception.Services.Login
{
    public class DialogLoginService: ILoginService
    {
        public IDialogCoordinator DialogCoordinator { get; set; }
        public IHotelRepository HotelRepository { get; set; }
        public DialogLoginService()
        {
            
        }
        public DialogLoginService(IDialogCoordinator dialogCoordinator)
        {
            DialogCoordinator = dialogCoordinator;
            HotelRepository = new HotelRepository();
        }

        
        //private ActiveDirectoryUtil ActiveDirectory { get; } = new ActiveDirectoryUtil();

        public async Task Login()
        {
            //if (ValidateCachedCredentials())
            //{
            //    //Setup ApplicationUser with the cached credentials. 
            //    InitializeApplicationUser();
            //    return;
            //}

            LoginDialogData loginDialogResult = null;
            var isUserValid = false;


            while (!isUserValid)
            {
                //Display login modul
                loginDialogResult = await DisplayLoginDialog();

                //Check if user clicked Cancel
                if (loginDialogResult == null)
                    Application.Current.Shutdown();


                isUserValid = ValidateCredentials(loginDialogResult.Username, loginDialogResult.Password);
            }          
        }

        

        private async Task<LoginDialogData> DisplayLoginDialog()
        {
            var dictionary = new ResourceDictionary
            {
                Source = new Uri(
                    "pack://application:,,,/MaterialDesignThemes.MahApps;component/Themes/MaterialDesignTheme.MahApps.Dialogs.xaml")
            };

            var result =
                await
                    DialogCoordinator.ShowLoginAsync(
                        this,
                        "Login",
                        string.Empty,
                        new LoginDialogSettings
                        {
                            //InitialUsername = UserSettings.Default.Username,
                            EnablePasswordPreview = true,
                            UsernameWatermark = "username",
                            PasswordWatermark = "Password",
                            RememberCheckBoxVisibility = Visibility.Hidden,
                            
                            AnimateHide = false,
                            SuppressDefaultResources = false,
                            CustomResourceDictionary = dictionary,
                            AnimateShow = true,

                        });

            return result;
        }

       

        private bool ValidateCredentials(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || password == null)
                return false;
            return HotelRepository.ReceptionistValidation.Validate(username, password) ;
            
        }
    }
}

