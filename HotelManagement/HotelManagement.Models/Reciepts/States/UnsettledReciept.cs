using System.Linq;
using HotelManagement.Models.Reciepts.Bills;
using HotelManagement.Models.Reciepts.Bills.BillTypes;
using HotelManagement.Models.Reciepts.Bills.States;
using HotelManagement.Models.Rooms;

namespace HotelManagement.Models.Reciepts.States
{
    public class UnsettledReciept : RecieptState
    {
        public UnsettledReciept(RecieptState state): this(state.Reciept)
        {
        }
        public UnsettledReciept(Reciept reciept)
        {
            base.Reciept = reciept;
            this.Name = "Unsettled";
        }
        protected internal override bool SettleReciept()
        {
            foreach(var bill in Reciept.Bills)
            {
                bill.SettleBill();
            }

            StateChangeCheck();
            return true;
        }

        protected internal override void AddBill(Bill bill)
        {
            Reciept.Bills.Add(bill);
            if (bill is RoomBill)
            {
                Reciept.Guest.BookedRooms.Add((bill as RoomBill).Room);
            }

            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (Reciept.Bills.All(x => x.State.GetType() != typeof(UnsettledBill)))
            {
                Reciept.State = new SettledReciept(this);
                
            }
        }
    }
}
