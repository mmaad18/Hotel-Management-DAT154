using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Entities.Rooms.RoomTypes;
using HotelManagement.Entities.Rooms.States;

using HotelManagement.Reception.Services.DataService.Rooms;

namespace HotelManagement.Reception.Design.Room
{
    using Entities.Rooms;
    public class DesignRoomDataService: IRoomDataService
    {
        public List<Room> Rooms { get; set; }

        public DesignRoomDataService()
        {
            //Guest guest = new Guest("Sondre","Fingann","98848184", DateTime.Now, "Sf", "blobl");
            //Room inhabited = new DoubleRoom("7");
            //inhabited.MoveIn(guest);

            //Room uninhabited = new SingleRoom("4");
            //uninhabited.MoveIn(guest);
            //uninhabited.MoveOut();
            Rooms = new List<Room>
            {
            //    new DoubleRoom("1"),
            //    new SingleRoom("2"),
            //    new DoubleRoom("3"),
            //    uninhabited,
            //    new DoubleRoom("5"),
            //    new SingleRoom("6"),
            //    inhabited,
            //    new SingleRoom("8"),
            //    new SingleRoom("9"),
            //    new SingleRoom("10"),
            //    new SingleRoom("11"),
            //    new SingleRoom("12")
            };
        }
        public void GetRooms(Action<List<Room>, Exception> callback)
        {
            callback(Rooms,null);
            
        }

        public void GetRoomsWithState(Action<List<Room>, Exception> callback, RoomState state)
        {
            callback(Rooms.Where(x => x.State == state).ToList(), null);
        }
    }
}
