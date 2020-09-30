using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models.Reciepts;
using HotelManagement.Models.Reciepts.States;
using HotelManagement.Models.Reciepts.Bills;
using HotelManagement.Models.Reciepts.Bills.BillTypes;
using HotelManagement.Models.Reciepts.Bills.States;
using NUnit.Framework;
using HotelManagement.Models.Persons.Guests;
using HotelManagement.Models.Rooms.RoomTypes;

namespace HotelManagement.Models.Tests.RecieptsTest
{
    [TestFixture]
    class RecieptStateTests
    {
        public Guest guest { get; set; }
        public Reciept reciept { get; set; }
        public Rooms.Room Room { get; set; } = new DoubleRoom("D14");
        public RoomBill unsettledRoomBill { get { return new RoomBill(Room, 2000); } } 

        public FoodBill settledFoodBill
        {
            get
            {
                var bill =  new FoodBill("Breakfast",70);
                bill.SettleBill();
                return bill;
            }
        }

        [SetUp]
        public void SetUp()
        {
            guest = new Guest("Yahya","Maad", "55565758", "ya", "Blob");
            guest.Id = 1337;

            reciept = new Reciept(guest,DateTime.Now.AddDays(-2),DateTime.Now.AddDays(2), unsettledRoomBill);

         
        }

        [Test]
        public void Initial_check_Guest()
        {
            Assert.AreEqual(guest, reciept.Guest);
        }

        [Test]
        public void Add_Single_Unsettled_Bill_State_Should_be_Unsettled()
        {
            reciept.AddBill(unsettledRoomBill);
            Assert.AreEqual(typeof(UnsettledReciept), reciept.State.GetType());
        }

        [Test]
        public void Add_Single_Settled_Bill_State_Should_be_Settled()
        {
            reciept.SettleReciept();
            reciept.AddBill(settledFoodBill);
            Assert.AreEqual(typeof(SettledReciept), reciept.State.GetType());
        }

        [Test]
        public void Add_Settled_Bill_State_Should_be_Unsettled()
        {
            reciept.AddBill(unsettledRoomBill);
            reciept.AddBill(settledFoodBill);
            Assert.AreEqual(typeof(UnsettledReciept), reciept.State.GetType());
        }

        [Test]
        public void Add_Settled_Bill_State_Should_be_Settled()
        {
            reciept.SettleReciept();
            reciept.AddBill(settledFoodBill);
            reciept.AddBill(settledFoodBill);
            Assert.AreEqual(typeof(SettledReciept), reciept.State.GetType());
        }

        [Test]
        public void Add_Unsettled_Bill_State_Should_be_Unsettled()
        {
            reciept.AddBill(settledFoodBill);
            reciept.AddBill(unsettledRoomBill);
            Assert.AreEqual(typeof(UnsettledReciept), reciept.State.GetType());
        }

        [Test]
        public void Add_Unsettled_Reciepts_then_Settle_Reciept_State_Should_be_Settled()
        {
            reciept.AddBill(unsettledRoomBill);
            reciept.AddBill(unsettledRoomBill);
            reciept.AddBill(unsettledRoomBill);
            reciept.SettleReciept();
            Assert.AreEqual(typeof(SettledReciept), reciept.State.GetType());
        }
        [Test]
        public void AddBills_Should_Increase_TotalAmount()
        {
            reciept.AddBill(unsettledRoomBill);
            reciept.AddBill(unsettledRoomBill);
            reciept.AddBill(unsettledRoomBill);
            
            Assert.AreEqual(typeof(UnsettledReciept), reciept.State.GetType());
            Assert.AreEqual(8000,reciept.TotalAmmount);
            Assert.AreEqual(8000, reciept.RemainingAmount);
            reciept.SettleReciept();
            Assert.AreEqual(8000, reciept.TotalAmmount);
            Assert.AreEqual(0, reciept.RemainingAmount);
            reciept.AddBill(unsettledRoomBill);
            Assert.AreEqual(10000, reciept.TotalAmmount);
            Assert.AreEqual(2000, reciept.RemainingAmount);
        }
    }
}
