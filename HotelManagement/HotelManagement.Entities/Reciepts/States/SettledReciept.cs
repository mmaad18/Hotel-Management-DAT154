using System;
using HotelManagement.Entities.Bills;
using HotelManagement.Entities.Bills.States;

namespace HotelManagement.Entities.Reciepts.States
{
    public class SettledReciept : RecieptState
    {
       

        public override string ToString()
        {
            return "Settled";
        }
    }
}
