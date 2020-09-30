using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAL.Repositorys.Shared;
using HotelManagement.Entities.RoomServices;

namespace HotelManagement.DAL.Repositorys.RoomServices
{
    public interface IRoomServiceRepository: IRepository<RoomService>
    {
    }
}
