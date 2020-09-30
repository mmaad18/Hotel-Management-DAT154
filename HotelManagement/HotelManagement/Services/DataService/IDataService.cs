using HotelManagement.Reception.Services.DataService.Persons;
using HotelManagement.Reception.Services.DataService.Rooms;

namespace HotelManagement.Reception.Services.DataService
{
    public interface IDataService
    {
       IPersonDataService PersonData { get; set; }
       IRoomDataService RoomData { get; set; }

    }
}
