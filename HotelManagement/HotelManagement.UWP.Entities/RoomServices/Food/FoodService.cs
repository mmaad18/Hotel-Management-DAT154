using System;
using HotelManagement.UWP.Entities.Persons;
using HotelManagement.UWP.Entities.Persons.Employees.Servants;

namespace HotelManagement.UWP.Entities.RoomServices.Food
{
    public class FoodService: RoomService
    {
        public FoodService()
        {
            Type = "FoodService";
        }
        public override bool Perform(Employee person)
        {
            if (!(person is FoodServent)) return false;

            Employee = person;
            EmployeeId = person.Id;
            DatePerformed = DateTime.Now;
            return true;
        }
    }
}
