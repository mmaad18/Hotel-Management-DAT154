using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelManagement.Models.Persons.Guests;
using HotelManagement.Models.Reciept.Bill;
using HotelManagement.Models.Reciept.Bill.States;

namespace HotelManagement.Models.Reciept.States
{
    class UnsettledState : RecieptState
    {
        public UnsettledState(Reciept reciept)
        {
            base.Reciept = reciept;
            this.StateInfo = "Unsettled";
        }

        public UnsettledState(RecieptState state)
        {
            this.StateInfo = "Unsettled";
        }

        public override bool SettleReciept()
        {
            StateChangeCheck();
            return true;
        }

        public override void AddBill(Bill.Bill bill)
        {
            Reciept.BillList.Add(bill);

            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (Reciept.BillList.Any(x => x.State.GetType() == typeof(UnsettledBill)))
            {
                Reciept.State = new SettledState(this);
            }
        }
    }
}
