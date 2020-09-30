using HotelManagement.Entities.Persons.Guests;

namespace HotelManagement.Entities.Rooms.States
{
    public class NotCleanedState: RoomState
    {
        
        public override string ToString()
        {
            return "Need cleaning";
        }
    }
}
