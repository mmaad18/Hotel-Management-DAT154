using HotelManagement.Models.Persons;
using HotelManagement.Models.Persons.Employees.Housekeeping;

namespace HotelManagement.Models.RoomServices.Housekeeping
{
    public class RoomCleaning: RoomService
    {
       
        
        public override bool Perform(Employee person)
        {
            if (!(person is Housekeeper)) return false;

            PerformedBy = person;
            return true;
        }
    }
}
