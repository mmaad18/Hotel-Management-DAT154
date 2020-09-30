using HotelManagement.Models.Rooms.States;

namespace HotelManagement.Models.Rooms.RoomTypes
{
    public class DoubleRoom: Room
    {
        private DoubleRoom()
        {
            //For Entity Framework

        }
        public DoubleRoom(string roomNumber)
        {
            RoomNumber = roomNumber;
            State = new AvailableState(this);
        }
    }
}
