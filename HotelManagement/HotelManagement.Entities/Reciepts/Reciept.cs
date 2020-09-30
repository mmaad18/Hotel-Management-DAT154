using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagement.Entities.Entity;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Entities.Reciepts.States;
using HotelManagement.Entities.StateFactory;

namespace HotelManagement.Entities.Reciepts
{
    public class Reciept : IEntity, INotifyPropertyChanged
    {
        public string GuestName { get; set; }
        public int RoomId { get; set; }

        public DateTime StayedFromDate { get; set; }
        public DateTime StayedToDate { get; set; }
        public DateTime SettledDate { get; set; }
        public string RoomQuality { get; set; }
        public string RoomType { get; set; }


        public string StateString { get; private set; } = "UnsettledBill";

        [NotMapped]
        public RecieptState State
        {
            get => RoomStateFactory.GetRecieptState(StateString);
            set => StateString = value.GetType().Name;
        }

        public int GuestId { get; set; }
        public virtual Guest Guest { get; set; }

        public int Id { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}