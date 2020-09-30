using System.Runtime.CompilerServices;
using HotelManagement.Models.Entity;
using HotelManagement.Models.Persons.Guests;
using HotelManagement.Models.Rooms.States;
using Microsoft.Build.Framework;
[assembly: InternalsVisibleTo("Name_of_Assembly")]
namespace HotelManagement.Models.Rooms
{
    public abstract class Room: IEntity
    {
        
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        
        public Guest Guest { get; set; }
        public RoomState State { get; set; }

        public void CleanRoom()
        {
            State.Clean();
        }

        public bool MoveIn(Guest guest)
        {
            return State.MoveIn(guest);
        }

        public Guest MoveOut()
        {
            return State.MoveOut();
        }

        public void NeedMaintenance(bool working)
        {
            State.NeedMaintenance(working);
        }

    }
}
