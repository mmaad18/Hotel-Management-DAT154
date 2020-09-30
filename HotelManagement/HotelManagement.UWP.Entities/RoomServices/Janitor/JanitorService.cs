using System;
using HotelManagement.UWP.Entities.Persons;

namespace HotelManagement.UWP.Entities.RoomServices.Janitor
{
    public class JanitorService: RoomService
    {
        public JanitorService()
        {
            Type = "JanitorService";
        }
        
        public override bool Perform(Employee person)
        {
            if (!(person is Persons.Employees.Janitors.Janitor)) return false;

            Employee = person;
            EmployeeId = person.Id;
            DatePerformed = DateTime.Now;
            return true;
        }
    }
}
