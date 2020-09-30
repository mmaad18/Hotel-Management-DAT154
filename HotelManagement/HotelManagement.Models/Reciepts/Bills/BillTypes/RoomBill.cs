using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models.Persons.Guests;
using HotelManagement.Models.Rooms;

namespace HotelManagement.Models.Reciepts.Bills.BillTypes
{
    public class RoomBill: Bill
    {
        public RoomBill(Room room, double amount) : base( amount)
        {
            Room = room;
        }

        public Room Room { get; set; }
    }
}
