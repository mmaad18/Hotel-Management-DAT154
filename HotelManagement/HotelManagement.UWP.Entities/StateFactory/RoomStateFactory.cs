using HotelManagement.UWP.Entities.Rooms.States;

namespace HotelManagement.UWP.Entities.StateFactory
{
    public static class RoomStateFactory
    {
        public static RoomState GetRoomState(string stateTypeName)
        {

            switch (stateTypeName)
            {
                case "AvailableState":
                    return new AvailableState();

                case "MaintenanceState":
                    return new MaintenanceState();

                case "NotCleanedState":
                    return new NotCleanedState();

                case "OccupiedState":
                    return new OccupiedState();

            }

            return new AvailableState();

        }

    }
}
