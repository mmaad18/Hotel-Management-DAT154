using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models.Persons.Guests;

namespace HotelManagement.Models.Rooms.States
{
    public class MaintenanceState: RoomState
    {
        public MaintenanceState(RoomState state)
        {
            needMaintenanced = true;
            Room = state.Room;
            Name = "Maintenance";
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

        protected internal override void Clean()
        {
            cleaned = true;
        }

        protected internal override bool MoveIn(Guest guest)
        {
            return false;
        }

        private void StateChangeCheck()
        {
            if (!needMaintenanced)
            {
                Room.State = new NotCleanedState(this);
            }
        }
    }
}
