using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.UWP.DAL.Api.Repository.EmployeeRepository;
using HotelManagement.UWP.DAL.Api.Repository.RoomRepository;
using HotelManagement.UWP.DAL.Api.Repository.RoomServiceRepository;
using HotelManagement.UWP.Entities.Persons;

namespace HotelManagement.UWP.DAL.Api.Repository
{
    public class HotelManagementRepository: IRepository
    {
        public HotelManagementRepository(Employee employee)
        {
            RoomServiceRepository = new RoomServiceRepository.RoomServiceRepository(employee);
            RoomRepository = new RoomRepository.RoomRepository();
            EmployeeRepository = new EmployeeRepository.EmployeeRepository();
        }
        public IRoomServiceRepository RoomServiceRepository { get; set; }

        public IRoomRepository RoomRepository { get; set; }

        public IEmployeeRepository EmployeeRepository { get; set; }
    }
}
