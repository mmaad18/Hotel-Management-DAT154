using System;
using HotelManagement.Entities.Persons;
using HotelManagement.Entities.Persons.Employees.Housekeeping;

namespace HotelManagement.Entities.RoomServices.Housekeeping
{
    public class HousekeepingService: RoomService
    {
        public HousekeepingService()
        {
            Type = "HousekeepingService";
        }

    }
}
