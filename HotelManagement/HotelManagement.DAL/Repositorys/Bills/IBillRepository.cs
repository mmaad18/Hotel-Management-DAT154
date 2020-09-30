using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAL.Repositorys.Shared;
using HotelManagement.Entities.Bills;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Entities.Reciepts;

namespace HotelManagement.DAL.Repositorys.Bills
{
    public interface IBillRepository : IRepository<Bill>
    {
        IEnumerable<Bill> GetBillsOfType(Type type);
        IEnumerable<Bill> GetBillsByGuest(Guest guest);
        IEnumerable<Bill> GetBillsByReciept(Reciept reciept);

    }
}
