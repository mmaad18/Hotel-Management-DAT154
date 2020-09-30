using System;
using HotelManagement.Models.Rooms.States;

namespace HotelManagement.Models.Rooms.RoomTypes
{
    public class SingleRoom : Room
    {
        private SingleRoom()
        {
            //For Entity Framework
        }
        public SingleRoom(String roomNumber)
        {
            this.RoomNumber = roomNumber;
            this.State = new AvailableState(this);
        }

       
    }
}
