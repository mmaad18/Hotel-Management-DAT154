using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using HotelManagement.DAL.Repositorys.Guests;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Reception.Messages.Update;

namespace HotelManagement.Reception.ViewModel.ViewModels.PersonViewModels.Search
{
    public class GuestSearchViewModel: PersonSearchViewModel<Guest>
    {
        public GuestSearchViewModel(IGuestRepository guestRepository) : base(guestRepository)
        {
            Messenger.Default.Register<UpdateGuestMessage>(this,(x) => UpdateCollection(GuestRepository.GetAll().ToList()));
            UpdateCollection(GuestRepository.GetAll().ToList());
        }
    }
}
