using System;
using System.Collections.Generic;
using HotelManagement.Entities.Rooms;
using HotelManagement.Entities.Rooms.States;

namespace HotelManagement.Reception.Services.DataService.Rooms
{
    public class RoomDataService: IRoomDataService
    {
        

        void IRoomDataService.GetRooms(Action<List<Room>, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void GetRoomsWithState(Action<List<Room>, Exception> callback, RoomState state)
        {
            throw new NotImplementedException();
        }
    }
}
