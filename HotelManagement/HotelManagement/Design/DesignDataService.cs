using System;
using HotelManagement.Reception.Design.Persons;
using HotelManagement.Reception.Model;
using HotelManagement.Reception.Services.DataService;
using HotelManagement.Reception.Services.DataService.Persons;
using HotelManagement.Reception.Services.DataService.Rooms;

namespace HotelManagement.Reception.Design
{
    public class DesignDataService : IDataService
    {
        public DesignDataService()
        {
            PersonData = new DesignPersonDataService();
            RoomData = new RoomDataService();
        }
        public IPersonDataService PersonData { get; set; }
        public IRoomDataService RoomData { get; set; }
    }
}