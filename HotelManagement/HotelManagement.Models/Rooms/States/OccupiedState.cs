using HotelManagement.Models.Persons.Guests;

namespace HotelManagement.Models.Rooms.States
{
    public class OccupiedState: RoomState
    {
        public OccupiedState(RoomState state)
        {
            this.Name = "Occupied";           
            this.room = state.Room;
            this.cleaned = false;
            this.needMaintenanced = state.needMaintenanced;
            StateChangeCheck();
        }

        protected internal override void Clean()
        {
            cleaned = true;
        }

        protected internal override bool MoveIn(Guest guest)
        {
            return false;
        }

        protected internal override Guest MoveOut()
        {
            Room.Guest.BookedRooms.Remove(Room);
            Guest occupent = Room.Guest;
            Room.Guest = null;            
            StateChangeCheck();
            return occupent;
        }

        protected internal override void NeedMaintenance(bool working)
        {
            needMaintenanced = working;  
        }

        private void StateChangeCheck()
        {
            

            if (Room.Guest == null)
            {
                if (needMaintenanced)
                {
                    Room.State= new MaintenanceState(this);
                }
                else
                {
                    Room.State = new NotCleanedState(this);
                }
            }

            
        }
    }
}
