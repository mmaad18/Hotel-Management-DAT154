using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAL.Repositorys.Bills;
using HotelManagement.DAL.Repositorys.Employees;
using HotelManagement.DAL.Repositorys.Guests;
using HotelManagement.DAL.Repositorys.Reciepts;
using HotelManagement.DAL.Repositorys.Rooms;
using HotelManagement.DAL.Repositorys.RoomServices;
using HotelManagement.DAL.Repositorys.Validation;
using HotelManagement.Entities.Persons;

namespace HotelManagement.DAL.Repositorys.General
{
    public class HotelRepository: IHotelRepository
    {

        public HotelRepository()
        {
            Guests = new GuestRepository();
            Rooms = new RoomRepository();
            Bills = new BillRepository();
            RoomServices = new RoomServiceRepository();
            Reciepts = new ReciptReposetory();
            Employees = new EmployeeRepository();
            ReceptionistValidation = new EmployeeValidationRepository();
        }

        public IGuestRepository Guests { get; set; }
        public IRoomRepository Rooms { get; set; }
        public IBillRepository Bills { get; set; }
        public IRoomServiceRepository RoomServices { get; set; }
        public IRecieptReposetory Reciepts { get; set; }
        public IEmployeeRepository Employees { get; set; }
        public IValidationRepository<bool> ReceptionistValidation { get; set; }

        public void RefreshAll()
        {
            Guests.RefreshAll();
            Rooms.RefreshAll();
            Bills.RefreshAll();
            RoomServices.RefreshAll();
            Reciepts.RefreshAll();
            Employees.RefreshAll();
        }
    }
}
