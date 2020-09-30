using System.Collections.Generic;
using HotelManagement.Models.Persons.Guests;
using HotelManagement.Models.Rooms.RoomTypes;
using HotelManagement.Models.Rooms.States;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;


namespace HotelManagement.Models.Tests.Room
{
    [TestFixture]
    public class RoomStateTests
    {
        public List<Rooms.Room> Rooms { get; set; }
        public Guest Guest { get; set; }
        [SetUp]
        public void SetUp()
        {
            Rooms = new List<Rooms.Room>
            {
                new DoubleRoom("1"),
                new SingleRoom("2")
            };


            Guest = new Guest("Sondre","Fingann","98848184","sf","Blob");
    
        }

        [Test]
        public void Initial_State_is_Cleaned()
        {
            foreach (var room in Rooms)
            {
                Assert.AreEqual(typeof(AvailableState),room.State.GetType() );
            }
        }

        [Test]
        public void MoveInn_Should_Change_State_To_occupied()
        {
            foreach (var room in Rooms)
            {
                room.MoveIn(Guest);
                Assert.AreEqual(typeof(OccupiedState), room.State.GetType());
            }
        }

        [Test]
        public void MoveOut_Should_Change_State_To_NotCleaned()
        {
            foreach (var room in Rooms)
            {
                var success = room.MoveIn(Guest);
                var guest = room.MoveOut();
                Assert.IsTrue(success);
                Assert.AreEqual(Guest, guest);
                Assert.AreEqual(typeof(NotCleanedState), room.State.GetType());
            }
        }
        [Test]
        public void MoveOut_in_Awailable_is_Null()
        {
            foreach (var room in Rooms)
            {
                room.MoveIn(Guest);
                room.MoveOut();
                Assert.AreEqual(typeof(NotCleanedState), room.State.GetType());
                room.CleanRoom();
                Assert.AreEqual(typeof(AvailableState), room.State.GetType());
                var guest = room.MoveOut();
                Assert.IsNull(guest);
            }
        }
        [Test]
        public void MoveInn_in_Occupied_is_False()
        {
            foreach (var room in Rooms)
            {
                room.MoveIn(Guest);
                Assert.AreEqual(typeof(OccupiedState), room.State.GetType());

                var success = room.MoveIn(Guest);
                Assert.IsFalse(success);
            }
        }

        [Test]
        public void Maitnance_Should_Change_State_To_Maitnance()
        {
            foreach (var room in Rooms)
            {   
                Assert.AreEqual(typeof(AvailableState), room.State.GetType());
                room.NeedMaintenance(true);
                Assert.AreEqual(typeof(MaintenanceState), room.State.GetType());
                room.NeedMaintenance(false);
                Assert.AreEqual(typeof(NotCleanedState), room.State.GetType());
                room.NeedMaintenance(true);
                Assert.AreEqual(typeof(MaintenanceState), room.State.GetType());
                
                room.NeedMaintenance(false);
                Assert.AreEqual(typeof(NotCleanedState), room.State.GetType());
                room.CleanRoom();
                Assert.AreEqual(typeof(AvailableState), room.State.GetType());
                room.MoveIn(Guest);
                Assert.AreEqual(typeof(OccupiedState), room.State.GetType());
                room.NeedMaintenance(true);
                Assert.AreEqual(typeof(OccupiedState), room.State.GetType());
                room.MoveOut();
                Assert.AreEqual(typeof(MaintenanceState), room.State.GetType());

                var success = room.MoveIn(Guest);
                Assert.IsFalse(success);
            }
        }

    }
}
