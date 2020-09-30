using System;
using HotelManagement.Models.Reciepts.Bills;
using HotelManagement.Models.Reciepts.Bills.BillTypes;
using HotelManagement.Models.Reciepts.Bills.States;

namespace HotelManagement.Models.Reciepts.States
{
    public class SettledReciept : RecieptState
    {
        public SettledReciept(RecieptState state)
        {
            Reciept = state.Reciept;
            Reciept.SettledDate = DateTime.Now;
            this.Name = "Settled";
        }

        protected internal override void AddBill(Bill bill)
        {
            Reciept.Bills.Add(bill);
            if (bill is RoomBill)
            {
                Reciept.Guest.BookedRooms.Add(((RoomBill) bill).Room);
            }

            StateChangeCheck(bill);
        }

        private void StateChangeCheck(Bill bill)
        {
            if(bill.State.GetType() == typeof(UnsettledBill))
            {
                Reciept.State = new UnsettledReciept(this);
            }
            else
            {
                Reciept.SettledDate = DateTime.Now;
            }
        }
    }
}
