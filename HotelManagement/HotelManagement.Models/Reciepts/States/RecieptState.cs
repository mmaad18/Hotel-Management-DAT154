using HotelManagement.Models.Entity;
using HotelManagement.Models.Reciepts.Bills;

namespace HotelManagement.Models.Reciepts.States
{
    public abstract class RecieptState: IEntity
    {
        public string Name { get; set; }

        public Reciept Reciept { get; set; }

        protected internal virtual bool SettleReciept()
        {
            return false;
        }

        protected internal abstract void AddBill(Bill bill);
        public int Id { get; set; }
    }
}
