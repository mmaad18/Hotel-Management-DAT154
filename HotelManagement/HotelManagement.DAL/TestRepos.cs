using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAL.Repositorys.Guests;
using HotelManagement.Entities.Bills;
using HotelManagement.Entities.Bills.BillTypes;
using HotelManagement.Entities.Persons;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Entities.Reciepts;
using HotelManagement.Entities.Rooms;
using HotelManagement.Entities.RoomServices;

namespace HotelManagement.DAL
{
    public class TestRepos
    {
        public TestRepos()
        {


            //HotelManagementContext ss = new HotelManagementContext();
            GuestRepository gg = new GuestRepository();
            var test =  gg.GetAll().ToList();
            var test1 = test[0];
            test1.PhoneNumber = "91199965";
            gg.Update(test1);
            gg.Save();
           
            //using (HotelManagementContext ss = new HotelManagementContext())
            //{
            //    Persons = ss.Guests.ToList();
            //    Rooms = ss.Rooms.ToList();
            //    Reciepts = ss.Reciepts.ToList();
            //    Bills = ss.Bills.ToList();
            //    var person1 = Persons[2] as Guest;
            //    var room1 = person1.BookedRooms[0];
            //    var person = ss.Guests.Single(x => x.Id == person1.Id);
            //    var room = ss.Rooms.Single(x => x.Id == room1.Id);
            //    ss.Entry(person).State= EntityState.Modified;
            //    ss.Entry(room).State = EntityState.Modified;
            //    room.MoveOut();
            //    //ss.Persons.Add(person);
            //    //ss.Rooms.Add(room);
            //    ss.SaveChanges();




            //    //ss.Bills.Add(new FoodBill(){Reciept = Reciepts.First(), Amount = 9999});
            //    //ss.SaveChanges();
            //    //Bills = ss.Bills.ToList();
            //}

        }

        public List<Reciept> Reciepts { get; set; }
        public List<Guest> Persons { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Bill> Bills { get; set; }
    }
}
