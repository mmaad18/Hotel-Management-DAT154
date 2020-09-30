using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAL.Repositorys.Shared;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Entities.Reciepts;

namespace HotelManagement.DAL.Repositorys.Reciepts
{
    public interface IRecieptReposetory : IRepository<Reciept>
    {
        IEnumerable<Reciept> GetAllRecieptsofType(Type type);
        IEnumerable<Reciept> GetRecipetsByGuest(Guest guest);

    }
}
