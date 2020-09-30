

namespace HotelManagement.Models.Reciepts.Bills.States
{
    public class SettledBill : BillState
    {

        public SettledBill(BillState state)
        {
            this.Bill = state.Bill;
        }
        
    }
}
