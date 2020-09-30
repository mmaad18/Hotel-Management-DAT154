using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using HotelManagement.UWP.Entities.Entity;
using HotelManagement.UWP.Entities.Persons.Guests;
using HotelManagement.UWP.Entities.Rooms.States;
using HotelManagement.UWP.Entities.StateFactory;

[assembly: InternalsVisibleTo("HotelManagement.DAL")]

namespace HotelManagement.UWP.Entities.Rooms
{
    public class Room : IEntity, INotifyPropertyChanged
    {
        protected Room()
        {
        }

        protected Room(string roomNumber)
        {
            RoomNumber = roomNumber;
        }

        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public string StateString { get; set; } = "AvailableState";
        public string Quality { get; set; }

        [NotMapped]
        public RoomState State
        {
            get => RoomStateFactory.GetRoomState(StateString);
            set => StateString = value.GetType().Name;
        }


        public int? GuestId { get; set; }
        public virtual Guest Guest { get; set; }

        public int Id { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}