using System;
using HotelManagement.Models.Persons.Guests;

namespace HotelManagement.Models.Reciepts.Bills.States
{
    public class UnsettledBill : BillState
    {
        public UnsettledBill(Bill bill)
        {
            Bill = bill;
        }

        protected internal override void SettleBill()
        {
           
            Bill.PayedDate = DateTime.Now;

            StateChange();
        }

        private void StateChange()
        {
            Bill.State = new SettledBill(this);
        }
    }
}