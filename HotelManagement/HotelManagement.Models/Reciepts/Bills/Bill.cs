using System;
using HotelManagement.Models.Entity;
using HotelManagement.Models.Persons.Guests;
using HotelManagement.Models.Reciepts.Bills.States;

namespace HotelManagement.Models.Reciepts.Bills
{
    public abstract class Bill : IEntity
    {
        protected Bill( double amount)
        {
            Amount = amount;
            State = new UnsettledBill(this);
            OrderedDate = DateTime.Now;
        }

        public DateTime OrderedDate { get; set; }
        public DateTime PayedDate { get; set; }
        public double Amount { get; set; }
        public Guest Guest { get; set; }
        public BillState State { get; set; }

        public int Id { get; set; }

        public void SettleBill()
        {
            State.SettleBill();
        }
    }
}