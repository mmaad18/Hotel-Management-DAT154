using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HotelManagement.DAL.Repositorys.Guests;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Reception.Messages.General;
using HotelManagement.Reception.Messages.Update;
using HotelManagement.Reception.Services.Notification;
using MaterialDesignThemes.Wpf.Converters;

namespace HotelManagement.Reception.ViewModel.ViewModels.PersonViewModels.Search
{
    public class CreateUserViewModel : ViewModelBase
    {
        private string _userName;
        private string _passwordHash;
        private string _firstName;
        private string _lastname;
        private string _phone;
        private DateTime _dateOfBirth = DateTime.Now;

        public string AcceptButton { get; set; }
        public IGuestRepository GuestRepository { get; set; }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged();
            }
        }

        public string PasswordHash
        {
            get { return _passwordHash; }
            set
            {
                _passwordHash = value;
                RaisePropertyChanged();
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged();
            }
        }

        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                RaisePropertyChanged();
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                RaisePropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                RaisePropertyChanged();
            }
        }

        public CreateUserViewModel()
        {
            ClearCommand = new RelayCommand(ExecuteClear);
            CreateUserCommand = new RelayCommand(ExecuteCreateUser);
            BackCommand = new RelayCommand(GoBackCommand);
        }
        public CreateUserViewModel(bool edit,  INotificationService notificationService, IGuestRepository guestRepository = null,int guestId = 0 ) :this()
        {
            GuestRepository = guestRepository;
            NotificationService = notificationService;
            if (!edit)
            {
                DisplayTitle = "Create new User";
                AcceptButton = "Create";
                IsEdit = false;
                Guest = new Guest();
            }
            else
            {
                DisplayTitle = "Edit User";
                AcceptButton = "Edit";
                IsEdit = true;
                Guest = GuestRepository.Get(guestId); 
                _firstName = Guest.FirstName;
                _lastname = Guest.Lastname;
                _phone = Guest.PhoneNumber;
                _userName = Guest.Username;
                _passwordHash = Guest.PasswordHash;
                _dateOfBirth = Guest.DateOfBirth;
            }


            
            
        }

        

        public string DisplayTitle { get; set; }
        public object Parameter { get; set; }

       
        public INotificationService NotificationService { get; set; }

        public RelayCommand CreateUserCommand { get; set; }
        public RelayCommand BackCommand { get; set; }

        public RelayCommand ClearCommand { get; set; }

        public Guest Guest { get; set; }

        public bool IsEdit { get; set; }
        public bool Success { get; set; }

        private void GoBackCommand()
        {
            Success = false;
            Messenger.Default.Send(new CloseDialogMessage());
        }

        private void ExecuteCreateUser()
        {
            if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(Lastname) &&
                !string.IsNullOrWhiteSpace(Phone) && DateOfBirth != default(DateTime))
            {
                if (IsEdit)
                {   
                    Guest.FirstName = FirstName;
                    Guest.Lastname = Lastname;
                    Guest.PhoneNumber = Phone;
                    Guest.Username = UserName;
                    Guest.PasswordHash = PasswordHash;
                    Guest.DateOfBirth = DateOfBirth;
                    GuestRepository.Update(Guest);
                }
                else
                {
                    Guest = new Guest
                    {
                        FirstName = FirstName,
                        Lastname = Lastname,
                        PhoneNumber = Phone,
                        Username = UserName,
                        PasswordHash = PasswordHash,
                        DateOfBirth = DateOfBirth
                    };
                    GuestRepository.Add(Guest);
                }
                GuestRepository.Save();

                
                Messenger.Default.Send(new UpdateGuestMessage());
                Messenger.Default.Send(new CloseDialogMessage());
            }
            else
            {
                NotificationService.Warning("Validation error!",
                    "You need to fill out all forms, except username and password");
            }
        }

        private void ExecuteClear()
        {
           FirstName = Lastname = PasswordHash = Phone = UserName = "";
           DateOfBirth = default(DateTime);
        }
    }
}