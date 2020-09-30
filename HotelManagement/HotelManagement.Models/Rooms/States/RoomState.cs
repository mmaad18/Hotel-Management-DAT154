using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagement.Models.Entity;
using HotelManagement.Models.Persons.Guests;
using Microsoft.Build.Framework;

namespace HotelManagement.Models.Rooms.States
{
    public abstract class RoomState: IEntity
    {
       
        protected Room room;

        protected bool cleaned;

        internal bool needMaintenanced;
        
        public Room Room
        {
            get => room;
            set => room = value;
        }

        public string Name { get; set; }

        protected internal abstract void Clean();


        protected internal abstract bool MoveIn(Guest guest);


        protected internal abstract Guest MoveOut();


        protected internal abstract void NeedMaintenance(bool working);

        public int Id { get; set; }
    }
}
