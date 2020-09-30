using HotelManagement.Models.Persons.Guests;

namespace HotelManagement.Models.Rooms.States
{
    public class AvailableState : RoomState
    {
        public AvailableState(RoomState state) :this(state.Room)
        {
            needMaintenanced = state.needMaintenanced;
            
        }
        public AvailableState(Room room)
        {
            cleaned = true;
            this.Room = room;
            Name = "Available";
        }

        protected internal override void Clean()
        {
           
        }

        protected internal override bool MoveIn(Guest guest)
        {
            guest.BookedRooms.Add(Room);
            Room.Guest = guest;

            StateChangeCheck();
            return true;
        }

        protected internal override Guest MoveOut()
        {
            return null;
        }

        protected internal override void NeedMaintenance(bool working)
        {
            needMaintenanced = working;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (needMaintenanced)
            {
                Room.State = new MaintenanceState(this);
            }

            if (Room.Guest != null)
                Room.State = new OccupiedState(this);
        }
    }
}