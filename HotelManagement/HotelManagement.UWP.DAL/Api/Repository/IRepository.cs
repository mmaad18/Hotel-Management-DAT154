using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.UWP.DAL.Api.Repository.RoomServiceRepository;

namespace HotelManagement.UWP.DAL.Api.Repository
{
    public interface IRepository
    {
        IRoomServiceRepository RoomServiceRepository { get; set; }
    }
}
