using HotelManagement.Models.Persons.Guests;

namespace HotelManagement.Models.Rooms.States
{
    public class NotCleanedState: RoomState
    {
        public NotCleanedState(RoomState state)
        {
            this.Name = "Not cleaned";
            this.Room = state.Room;

            this.needMaintenanced = state.needMaintenanced;
            cleaned = false;
            
        }

        protected internal override void Clean()
        {
            cleaned = true;
            StateChangeCheck();
        }

        protected internal override bool MoveIn(Guest guest)
        {
            return false;
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
                room.State = new MaintenanceState(this);
            }
            if (cleaned)
            {
                Room.State = new AvailableState(this);
            }
           
        }
    }
}
