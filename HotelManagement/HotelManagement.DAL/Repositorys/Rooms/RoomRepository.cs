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
    public class RoomRepository : EFRepository<HotelManagementContext, Room>, IRoomRepository
    {
        public IEnumerable<Room> GetRoomsOfType(Type type)
        {
            return GetAll().ToList().Where(x => x.State.GetType() == type);
        }

        public IEnumerable<Room> GetRoomsByState(Type type)
        {
            return FindBy(x => x.State.GetType() == type);
        }

        public IEnumerable<Room> GetRoomsByGuest(Guest guest)
        {
            return FindBy(x => x.Guest == guest);
        }
    }
}
