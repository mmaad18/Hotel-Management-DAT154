using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelManagement.UWP.DAL.Api.HttpClient;
using HotelManagement.UWP.Entities.Persons;
using HotelManagement.UWP.Entities.Rooms;
using HotelManagement.UWP.Entities.RoomServices;

namespace HotelManagement.UWP.DAL.Api.Repository.RoomServiceRepository
{
    public class RoomServiceRepository: IRoomServiceRepository
    {
        public RestClient<RoomService> RestClient { get; set; }
        public string BaseEndpoint { get; set; }
        public Employee Employee { get; set; }

        public RoomServiceRepository(Employee employee)
        {
            Employee = employee;
            RestClient= new RestClient<RoomService>();
            BaseEndpoint = "RoomServices/";
        }
        public async Task<List<RoomService>> GetAllRoomsServices()
        {
            
                switch (Employee.JobDescription)
                {
                    case "Housekeeper":
                        return await RestClient.GetAll(BaseEndpoint + "HousekeepingServices");
                    case "FoodServer":
                        return await RestClient.GetAll(BaseEndpoint+"FoodServices");
                    case "Janitor":
                        return await RestClient.GetAll(BaseEndpoint+"JanitorServices");

                }
           

            return await RestClient.GetAll(BaseEndpoint);
        }

        public async Task<RoomService> GetRoomService(int id)
        {
            return await RestClient.Get(BaseEndpoint + id);
        }

        public async Task<bool> UpdateRoomService(RoomService roomService)
        {

            switch (Employee.JobDescription)
            {
                case "Housekeeper":
                    return await RestClient.Update(BaseEndpoint + "HousekeepingServices/" + roomService.Id, roomService);
                case "FoodServer":
                    return await RestClient.Update(BaseEndpoint + "FoodServices/" + roomService.Id, roomService);
                case "Janitor":
                    return await RestClient.Update(BaseEndpoint + "JanitorServices/"+ roomService.Id, roomService);

            }
            return false;
        }
    }
}
