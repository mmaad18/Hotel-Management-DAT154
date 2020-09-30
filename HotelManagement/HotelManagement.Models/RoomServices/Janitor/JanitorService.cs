using System;
using HotelManagement.Models.Persons;

namespace HotelManagement.Models.RoomServices.Janitor
{
    using Persons.Employees.Janitors;
    public class JanitorService: RoomService
    {
        
        public override bool Perform(Employee person)
        {
            if (!(person is Janitor)) return false;

            PerformedBy = person;
            return true;
        }
    }
}
