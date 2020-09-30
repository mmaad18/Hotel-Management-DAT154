using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.UWP.Entities.Rooms;

namespace HotelManagement.UWP.DAL.Api.Repository.RoomRepository
{
    public interface IRoomRepository
    {
        Task<Room> GetRoom(int id);
        Task<bool> UpdateRoom(Room roomService);
    }
}
