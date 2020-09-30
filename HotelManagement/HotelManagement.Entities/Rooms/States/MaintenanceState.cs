using HotelManagement.Entities.Persons.Guests;

namespace HotelManagement.Entities.Rooms.States
{
    public class MaintenanceState: RoomState
    {
        public override string ToString()
        {
            return "Need maintenance";
        }
    }
}
