using System;
using System.ComponentModel;
using HotelManagement.Entities.Entity;
using HotelManagement.Entities.Persons;
using HotelManagement.Entities.Rooms;

namespace HotelManagement.Entities.RoomServices
{
    public abstract class RoomService: IEntity, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Id { get; set; }
        public DateTime DatePerformed { get; set; }
        public DateTime Ordered { get; set; }
        public string Type { get; set; }
        public int? RoomId { get; set; }
        public Room Room { get; set; }
        public int? EmployeeId { get;  set; }
        public Employee Employee { get; set; }
    }
}
