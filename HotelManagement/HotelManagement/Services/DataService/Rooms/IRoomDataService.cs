using System;
using System.Collections.Generic;
using HotelManagement.Entities.Rooms;
using HotelManagement.Entities.Rooms.States;

namespace HotelManagement.Reception.Services.DataService.Rooms
{
    public interface IRoomDataService
    {
        void GetRooms(Action<List<Room>, Exception> callback);
        void GetRoomsWithState(Action<List<Room>, Exception> callback, RoomState state);
    }
}
