

namespace HotelManagement.Models.Reciept.Bill.States
{
    public class SettledBill : BillState
    {

        public SettledBill(BillState state)
        {
            this.Bill = state.Bill;
        }
        
    }
}
