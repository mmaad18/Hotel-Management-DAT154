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
    public class BillRepository : EFRepository<HotelManagementContext, Bill>, IBillRepository
    {
        public IEnumerable<Bill> GetBillsOfType(Type type)
        {
            return FindBy(x => x.GetType() == type);
        }

        public IEnumerable<Bill> GetBillsByGuest(Guest guest)
        {
            return FindBy(x => x.Reciept.Guest == guest);
        }

        public IEnumerable<Bill> GetBillsByReciept(Reciept reciept)
        {
            return FindBy(x => x.RecieptId == reciept.Id);
        }
    }
}
