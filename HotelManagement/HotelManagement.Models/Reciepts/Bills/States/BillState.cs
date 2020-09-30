using HotelManagement.Models.Entity;
using HotelManagement.Models.Persons.Guests;

namespace HotelManagement.Models.Reciepts.Bills.States
{
    public abstract class BillState: IEntity
    {

        protected internal Bill Bill { get; set; }

        protected internal virtual void SettleBill()
        {

        }

        public int Id { get; set; }
    }
}
