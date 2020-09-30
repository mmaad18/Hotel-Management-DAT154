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
    public interface IHotelRepository
    {
        

        IGuestRepository Guests { get; set; }
        IRoomRepository Rooms { get; set; }
         IBillRepository Bills { get; set; }
         IRoomServiceRepository RoomServices { get; set; }
         IRecieptReposetory Reciepts { get; set; }
         IEmployeeRepository Employees { get; set; }
        IValidationRepository<bool> ReceptionistValidation { get; set; }
        void RefreshAll();

    }
}
