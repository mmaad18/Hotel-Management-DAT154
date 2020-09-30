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
    public class ReciptReposetory:EFRepository<HotelManagementContext, Reciept>, IRecieptReposetory
    {
        public IEnumerable<Reciept> GetAllRecieptsofType(Type type)
        {
            return FindBy(x => x.State.GetType() == type);
        }

        public IEnumerable<Reciept> GetRecipetsByGuest(Guest guest)
        {
            return FindBy(x => x.Guest == guest);
        }
    }
}
