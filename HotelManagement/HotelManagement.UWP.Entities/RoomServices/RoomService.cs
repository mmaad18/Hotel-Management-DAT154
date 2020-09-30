using System;
using System.ComponentModel;
using HotelManagement.UWP.Entities.Entity;
using HotelManagement.UWP.Entities.Persons;
using HotelManagement.UWP.Entities.Rooms;

namespace HotelManagement.UWP.Entities.RoomServices
{
    public class RoomService: IEntity, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Id { get; set; }
        public DateTime DatePerformed { get; set; }
        public DateTime Ordered { get; set; }
        public string Type { get; set; }

        public virtual bool Perform(Employee person)
        {
            return false;
        }

        public int? RoomId { get; set; }
        public Room Room { get; set; }
        public int? EmployeeId { get;  set; }
        public Employee Employee { get; set; }
    }
}
