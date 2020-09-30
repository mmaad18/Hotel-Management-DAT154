using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models.Persons.Guests;

namespace HotelManagement.Models.Reciepts.Bills.BillTypes
{
    public class MiscBill: Bill
    {
        public MiscBill(string itemName, double amount) : base(amount)
        {
            ItemName = itemName;
        }

        public string ItemName { get; set; }
    }
}
