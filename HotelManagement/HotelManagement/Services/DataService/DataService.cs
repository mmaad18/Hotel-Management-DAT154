using HotelManagement.Reception.Design.Persons;
using HotelManagement.Reception.Design.Room;
using HotelManagement.Reception.Services.DataService.Persons;
using HotelManagement.Reception.Services.DataService.Rooms;

namespace HotelManagement.Reception.Services.DataService
{
    public class DataService : IDataService
    {
        public DataService()
        {
            RoomData = new DesignRoomDataService();
            PersonData = new DesignPersonDataService();
        }
        public IPersonDataService PersonData { get; set; }
        public IRoomDataService RoomData { get; set; }
    }
}