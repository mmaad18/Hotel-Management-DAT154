using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.UWP.DAL.Api.Repository.EmployeeRepository;
using HotelManagement.UWP.DAL.Api.Repository.RoomRepository;
using HotelManagement.UWP.DAL.Api.Repository.RoomServiceRepository;
using HotelManagement.UWP.Entities.Display;
using HotelManagement.UWP.Entities.Persons;
using HotelManagement.UWP.Entities.Rooms;
using HotelManagement.UWP.Entities.RoomServices;

namespace HotelManagement.UWP.Converter
{
    public class RoomServiceConverter
    {
        public IRoomRepository RoomRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public RoomServiceConverter()
        {
            RoomRepository = new RoomRepository();
            EmployeeRepository = new EmployeeRepository();
        }
        public async Task<RoomServiceDisplay> ToRoomServiceDisplay(RoomService roomService)
        {
            Room roomTask = null;
            Employee employeeTask = null;
            if (roomService.RoomId != null)
                roomTask = await RoomRepository.GetRoom(roomService.RoomId.Value);

            if (roomService.EmployeeId != null)
                employeeTask = await EmployeeRepository.GetEmployee(roomService.EmployeeId.Value);

           
            var roomServiceDisplay = new RoomServiceDisplay()
            {
                Id = roomService.Id,Ordered = roomService.Ordered,Type = roomService.Type
            };
          

            if (employeeTask != null) roomServiceDisplay.Employee = employeeTask;

            if (roomTask != null) roomServiceDisplay.Room = roomTask;
            return roomServiceDisplay;
        }

        public RoomService ToRoomService(RoomServiceDisplay roomServiceDisplay)
        {
            var roomservice = new RoomService
            {
                DatePerformed = roomServiceDisplay.DatePerformed,
                Ordered = roomServiceDisplay.Ordered,
                Id = roomServiceDisplay.Id,
                Type = roomServiceDisplay.Type,
                EmployeeId = roomServiceDisplay.Employee.Id,
                RoomId = roomServiceDisplay.Room?.Id
            };
            return roomservice;
        }
    }
}
