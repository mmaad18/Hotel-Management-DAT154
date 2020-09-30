using System.Linq;
using HotelManagement.Entities.Bills;
using HotelManagement.Entities.Bills.BillTypes;
using HotelManagement.Entities.Bills.States;

namespace HotelManagement.Entities.Reciepts.States
{
    public class UnsettledReciept : RecieptState
    {
        

        public override string ToString()
        {
            return "Unsettled";
        }
    }
}
