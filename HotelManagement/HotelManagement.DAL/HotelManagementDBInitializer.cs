using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Entities.Bills;
using HotelManagement.Entities.Bills.BillTypes;
using HotelManagement.Entities.Persons;
using HotelManagement.Entities.Persons.Employees.Housekeeping;
using HotelManagement.Entities.Persons.Employees.Janitors;
using HotelManagement.Entities.Persons.Employees.Receptionists;
using HotelManagement.Entities.Persons.Employees.Servants;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Entities.Reciepts;
using HotelManagement.Entities.Rooms;
using HotelManagement.Entities.Rooms.RoomTypes;
using HotelManagement.Entities.Rooms.States;
using HotelManagement.Entities.RoomServices;
using HotelManagement.Entities.RoomServices.Food;
using HotelManagement.Entities.RoomServices.Housekeeping;
using HotelManagement.Entities.RoomServices.Janitor;

namespace HotelManagement.DAL
{
    internal class HotelManagementDBInitializer : DropCreateDatabaseIfModelChanges<HotelManagementContext>
    {
        public List<Reciept> Reciepts { get; set; } = new List<Reciept>();
        public List<Person> Persons { get; set; } = new List<Person>();
        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<RoomService> RoomService { get; set; } = new List<RoomService>();
       
        protected override void Seed(HotelManagementContext context)
        {
            //InstanciateLists(context);
            InstatnciateSimple(context);

            //foreach (Standard std in defaultStandards)
            //    context.Standards.Add(std);

            base.Seed(context);
        }

        private void AddLists(HotelManagementContext context)
        {
            //foreach (var reciept in Reciepts)
            //    context.Reciepts.Add(reciept);

            //foreach (var person in Persons)
            //    context.Persons.Add(person);

            //foreach (var room in Rooms)
            //    context.Rooms.Add(room);

            //foreach (var roomService in RoomService)
            //    context.RoomServices.Add(roomService);

        }

        public void InstatnciateSimple(HotelManagementContext context)
        {
            var guest1 = new Guest() { FirstName = "Sondre", Lastname = " Fingann", PhoneNumber = "98848184", Username = "sondre", PasswordHash = "Sondre123" };
            var guest2 = new Guest() { FirstName = "Tore", Lastname = " Stensrup", PhoneNumber = "43992834", Username = "tore", PasswordHash = "tore124" };
            var guest3 = new Guest() { FirstName = "Jonas", Lastname = " Øvreset", PhoneNumber = "83374561", Username = "jonas", PasswordHash = "jonas123" };
            var guest4 = new Guest() { FirstName = "Nils", Lastname = "Kondens", PhoneNumber = "45734821", Username = "nils", PasswordHash = "nils123" };

            var receptionist1 = new Receptionist() { FirstName = "Fred", Lastname = "Singer", PhoneNumber = "48837745", Username = "Receptionist1", PasswordHash = "Receptionist1", JobDescription = "Receptionist" };
            var receptionist2 = new Receptionist() { FirstName = "Roy", Lastname = "Averson", PhoneNumber = "48837745", Username = "Receptionist2", PasswordHash = "Receptionist2", JobDescription = "Receptionist" };

            var housekeeper1 = new Housekeeper() { FirstName = "Stian", Lastname = "Stensrup", PhoneNumber = "43992834", Username = "Housekeeper1", PasswordHash = "Housekeeper1", JobDescription = "Housekeeper" };
            var foodServent = new FoodServent() { FirstName = "Gordon", Lastname = "Øvreset", PhoneNumber = "83374561", Username = "Foodservent1", PasswordHash = "Foodservent1", JobDescription = "FoodServer" };
            var janitor = new Janitor() { FirstName = "Terje", Lastname = "Lillebø", PhoneNumber = "83374561", Username = "Janitor1", PasswordHash = "Janitor1", JobDescription = "Janitor" };
            context.Guests.Add(guest1);
            context.Guests.Add(guest2);
            context.Guests.Add(guest3);
            context.Guests.Add(guest4);
            context.SaveChanges();

            context.Employees.Add(receptionist1);
            context.Employees.Add(receptionist2);
            context.Employees.Add(housekeeper1);
            context.Employees.Add(foodServent);
            context.Employees.Add(janitor);
            context.SaveChanges();

            for (int i = 0; i < 25; i++)
            {
                Rooms.Add(new SingleRoom() { RoomNumber = "A" + i, Quality = "Vip" });
                Rooms.Add(new DoubleRoom() { RoomNumber = "B" + i, Quality = "Standard" });
                Rooms.Add(new SingleRoom() { RoomNumber = "A" + (i+25), Quality = "Standard"});
                Rooms.Add(new DoubleRoom() { RoomNumber = "B" + (i+25), Quality = "Vip"});

            }
            //Rooms[7].State = new NotCleanedState();
            //Rooms[8].State = new NotCleanedState();
            //Rooms[9].State = new MaintenanceState();
            

            context.Rooms.AddRange(Rooms);
            context.SaveChanges();

            //var cleaningService = new HousekeepingService() { Ordered = DateTime.Now, RoomId = Rooms[7].Id };
            //var cleaningService2 = new HousekeepingService() { Ordered = DateTime.Now, RoomId = Rooms[8].Id };
            //var maintnanceService = new JanitorService(){Ordered = DateTime.Now,RoomId = Rooms[9].Id};
            //var foodService = new FoodService(){Ordered = DateTime.Now, RoomId = Rooms[9].Id};

            //context.RoomServices.AddRange(
            //    new List<RoomService>() {cleaningService, cleaningService2, maintnanceService});



        }

        //public void InstanciateLists(HotelManagementContext context)
        //{
           
        //    //Persons
        //    var guest1 = new Guest(){ FirstName = "Sondre", Lastname = " Fingann", PhoneNumber = "98848184", Username = "sondre",PasswordHash = "Sondre123" };
        //    var guest2 = new Guest(){ FirstName = "Tore", Lastname = " Stensrup", PhoneNumber = "43992834", Username = "tore",PasswordHash = "tore124" };
        //    var guest3 = new Guest(){ FirstName = "Jonas", Lastname = " Øvreset", PhoneNumber = "83374561", Username = "jonas", PasswordHash = "jonas123" };
        //    var guest4 = new Guest(){ FirstName = "Nils", Lastname = "Kondens", PhoneNumber = "45734821",Username = "nils",PasswordHash = "nils123" };

        //    var receptionist1 = new Receptionist(){FirstName = "Jone",Lastname = " Bergman", PhoneNumber = "48837745", Username = "jone", PasswordHash = "jone123" };
        //    var receptionist2 = new Receptionist(){ FirstName = "Sigrid", Lastname = " Bergman",PhoneNumber = "48837745", Username = "sigrid", PasswordHash = "sigrid123" };

        //    var housekeeper1 = new Housekeeper(){ FirstName = "Jens",Lastname = " Stensrup",PhoneNumber = "43992834", Username = "jens", PasswordHash = "jens123" };
        //    var foodServent = new FoodServent(){FirstName = "Lars", Lastname = " Øvreset",PhoneNumber = "83374561",Username = "lars",PasswordHash = "lars123"};
        //    var janitor = new Janitor(){ FirstName = "Terje", Lastname = " Stangeland",PhoneNumber = "83374561",Username = "terje", PasswordHash = "terje123" };
        //    context.Guests.Add(guest1);
        //    context.Guests.Add(guest2);
        //    context.Guests.Add(guest3);
        //    context.Guests.Add(guest4);
        //    context.Employees.Add(receptionist1);
        //    context.Employees.Add(receptionist2);
        //    context.Employees.Add(housekeeper1);
        //    context.Employees.Add(foodServent);
        //    context.Employees.Add(janitor);
        //    context.SaveChanges();


        //    //Rooms
        //    //adds 100 rooms
        //    for (int i = 0; i < 50; i++)
        //    {
        //        Rooms.Add(new SingleRoom(){RoomNumber = "A" + i });
        //        Rooms.Add(new DoubleRoom(){ RoomNumber = "B" + i } );

        //    }
        //    Rooms[0].MoveIn(guest3) ;
        //    Rooms[1].MoveIn(guest3);
        //    context.Rooms.AddRange(Rooms);
        //    context.SaveChanges();

        //    //Reciepts
        //    var reciept1 = new Reciept() { Guest = guest1, StayedFromDate = DateTime.Now.AddDays(-16), StayedToDate = DateTime.Now.AddDays(-13) };
        //    var reciept2 = new Reciept() { Guest = guest2, StayedFromDate = DateTime.Now.AddDays(-8), StayedToDate = DateTime.Now.AddDays(-2), };
        //    var reciept3 = new Reciept() { Guest = guest3, StayedFromDate = DateTime.Now.AddDays(-2), StayedToDate = DateTime.Now.AddDays(4) };
        //    context.Reciepts.Add(reciept1);
        //    context.Reciepts.Add(reciept2);
        //    context.Reciepts.Add(reciept3);
        //    context.SaveChanges();



        //    //Bills
        //    var foodbill1 = new FoodBill(){ Amount = 135 ,Reciept = reciept1};          
        //    var foodbill2 = new FoodBill() { Amount = 76, Reciept = reciept2 };           
        //    var foodbill3 =  new FoodBill() { Amount = 178.5, Reciept = reciept2 };

        //    var roombill1 = new RoomBill(){ Amount = 135, Reciept = reciept1};
        //    var roombill2 = new RoomBill(){Amount = 135, Reciept = reciept2 };           
        //    var roombill3 = new RoomBill(){Amount = 135, Reciept = reciept3 };

        //    var cleaningBill3 = new CleaningBill(){Amount = 40, Reciept = reciept3 };

        //    //reciept1.Bills.Add(foodbill1);
        //    //reciept1.Bills.Add(roombill1);

        //    //reciept2.Bills.Add(foodbill2);
        //    //reciept2.Bills.Add(roombill2);

        //    //reciept1.Bills.Add(foodbill3);
        //    //reciept1.Bills.Add(roombill3);
        //    //reciept1.Bills.Add(cleaningBill3);



        //    context.Bills.Add(foodbill1);
        //    context.Bills.Add(foodbill2);
        //    context.Bills.Add(foodbill3);
        //    context.Bills.Add(roombill1);
        //    context.Bills.Add(roombill2);
        //    context.Bills.Add(roombill3);
        //    context.Bills.Add(cleaningBill3);
        //    context.SaveChanges();
        //}
    }
}
