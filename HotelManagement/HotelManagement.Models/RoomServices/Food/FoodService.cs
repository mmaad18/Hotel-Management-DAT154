using HotelManagement.Models.Persons;
using HotelManagement.Models.Persons.Employees.Servants;
using HotelManagement.Models.Rooms.RoomTypes;

namespace HotelManagement.Models.RoomServices.Food
{
    public class FoodService: RoomService
    {
        public override bool Perform(Employee person)
        {
            if (!(person is FoodServent)) return false;

            PerformedBy = person;
            return true;
        }
    }
}
