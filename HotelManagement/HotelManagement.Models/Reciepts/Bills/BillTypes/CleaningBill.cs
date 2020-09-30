using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models.Persons.Guests;
using HotelManagement.Models.Rooms;

namespace HotelManagement.Models.Reciepts.Bills.BillTypes
{
    public class CleaningBill: Bill
    {
        public CleaningBill(double amount) : base(amount)
        {
            
        }

        public Room Room { get; set; }
    }
}
