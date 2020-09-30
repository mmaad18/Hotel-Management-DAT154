using System.Collections.Generic;
using System.Threading.Tasks;
using HotelManagement.UWP.Entities.Rooms;
using HotelManagement.UWP.Entities.RoomServices;

namespace HotelManagement.UWP.DAL.Api.Repository.RoomServiceRepository
{
    public interface IRoomServiceRepository
    {
        Task<List<RoomService>> GetAllRoomsServices();
        Task<RoomService> GetRoomService(int id);
        Task<bool> UpdateRoomService(RoomService roomService);
    }
}
