using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models.Persons.Guests;

namespace HotelManagement.Models.Reciepts.Bills.BillTypes
{
    public class FoodBill: Bill
    {
        public FoodBill(string dishName, double amount) : base( amount)
        {
            DishDishName = dishName;
        }

        public string DishDishName { get; set; }
    }
}
