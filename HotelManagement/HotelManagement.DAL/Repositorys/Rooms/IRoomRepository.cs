using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAL.Repositorys.Shared;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Entities.Rooms;

namespace HotelManagement.DAL.Repositorys.Rooms
{
    public interface IRoomRepository : IRepository<Room>
    {
        IEnumerable<Room> GetRoomsOfType(Type type);
        IEnumerable<Room> GetRoomsByState(Type type);
        IEnumerable<Room> GetRoomsByGuest(Guest guest);

    }
}
