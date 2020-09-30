using System;

namespace HotelManagement.Entities.Bills.States
{
    public class UnsettledBill : BillState
    {
        public override string ToString()
        {
            return "Unsettled";
        }
    }
}