using System;
using System.Collections.Generic;
using HotelManagement.Models.Persons.Guests;
using HotelManagement.Models.Reciepts;
using HotelManagement.Models.Reciepts.Bills;
using HotelManagement.Models.Reciepts.Bills.BillTypes;
using HotelManagement.Models.Reciepts.Bills.States;
using HotelManagement.Models.Rooms.RoomTypes;
using NUnit.Framework;

namespace HotelManagement.Models.Tests.RecieptsTest.BillsTests
{
    [TestFixture]
    public class BillStateTests
    {
        public List<Bill> Bills { get; set; }
       

        [SetUp]
        public void SetUp()
        {
            
           

            var room = new DoubleRoom("s2");
            Bills = new List<Bill>
            {
                new CleaningBill(200),
                new FoodBill("Dinner",135.5),
                new MiscBill("Flowers",98),
                new RoomBill(room,1400)
            };


        }

        [Test]
        public void Initial_State_is_Unsettled_And_Has_Ammount()
        {
            foreach (var bill in Bills)
            {
                Assert.AreEqual(typeof(UnsettledBill), bill.State.GetType());
                Assert.AreEqual(DateTime.Now.Date,bill.OrderedDate.Date);
                Assert.Greater(bill.Amount,0);
            }
        }

        [Test]
        public void SettleBill_Should_Change_State_And_PayedDate()
        {
            foreach (var bill in Bills)
            {
                bill.SettleBill();
                Assert.AreEqual(typeof(SettledBill), bill.State.GetType());
                
                Assert.AreEqual(DateTime.Now.Date, bill.PayedDate.Date);
            }
        }
        [Test]
        public void SettleBill_Should_Not_Change_State_On_Settle()
        {
            foreach (var bill in Bills)
            {
                bill.SettleBill();
                Assert.AreEqual(typeof(SettledBill), bill.State.GetType());
                bill.SettleBill();
                Assert.AreEqual(typeof(SettledBill), bill.State.GetType());
            }
        }
    }
}
