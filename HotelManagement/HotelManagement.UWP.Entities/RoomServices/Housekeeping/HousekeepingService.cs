using System;
using HotelManagement.UWP.Entities.Persons;
using HotelManagement.UWP.Entities.Persons.Employees.Housekeeping;

namespace HotelManagement.UWP.Entities.RoomServices.Housekeeping
{
    public class HousekeepingService: RoomService
    {
        public HousekeepingService()
        {
            Type = "HousekeepingService";
        }

        public override bool Perform(Employee person)
        {
            if (!(person is Housekeeper)) return false;

            Employee = person;
            EmployeeId = person.Id;
            DatePerformed = DateTime.Now;
            return true;
        }
    }
}
