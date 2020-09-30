using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.UWP.DAL.Api.HttpClient;
using HotelManagement.UWP.Entities.Rooms;

namespace HotelManagement.UWP.DAL.Api.Repository.RoomRepository
{
    public class RoomRepository: IRoomRepository
    {
        public RestClient<Room> RestClient { get; set; }
        public string BaseEndpoint { get; set; }

        public RoomRepository()
        {

            RestClient = new RestClient<Room>();
            BaseEndpoint = "Rooms/";
        }
        public async Task<Room> GetRoom(int id)
        {
            return await RestClient.Get(BaseEndpoint + id);
        }

        public async Task<bool> UpdateRoom(Room room)
        {
            switch (room.Type)
            {
                case "SingleRoom":
                    return await RestClient.Update(BaseEndpoint + "SingleRoom/" + room.Id, room);
                case "DoubleRoom":
                    return await RestClient.Update(BaseEndpoint + "DoubleRoom/" + room.Id, room);
               

            }
            return false;
        }
    }
}
