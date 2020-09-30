using System;
using HotelManagement.Models.Entity;
using HotelManagement.Models.Persons;
using HotelManagement.Models.Rooms;

namespace HotelManagement.Models.RoomServices
{
    public abstract class RoomService: IEntity
    {
        public int Id { get; set; }
        public DateTime DatePerformed { get; set; }
        public DateTime Ordered { get; set; }
        public Room Room { get; set; }
        public Employee PerformedBy { get; protected set; }  
        public abstract bool Perform(Employee person);
    }
}
