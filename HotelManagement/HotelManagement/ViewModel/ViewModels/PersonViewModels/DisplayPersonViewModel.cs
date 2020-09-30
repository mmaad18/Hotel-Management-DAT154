using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using HotelManagement.DAL.Repositorys.Guests;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Entities.Reciepts;

namespace HotelManagement.Reception.ViewModel.ViewModels.PersonViewModels
{
    public class DisplayPersonViewModel: ViewModelBase
    {
        private Guest _guest;
        public IGuestRepository GuestRepository { get; set; }

        public Guest Guest
        {
            get { return _guest; }
            set
            {
                _guest = value;
                RaisePropertyChanged();
            }
        }

        public DisplayPersonViewModel(IGuestRepository guestRepository)
        {
            GuestRepository = guestRepository;

        }
    }
}
