using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using HotelManagement.Entities.Entity;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Entities.Rooms.States;
using HotelManagement.Entities.StateFactory;

[assembly: InternalsVisibleTo("HotelManagement.DAL")]

namespace HotelManagement.Entities.Rooms
{
    public abstract class Room : IEntity, INotifyPropertyChanged
    {
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