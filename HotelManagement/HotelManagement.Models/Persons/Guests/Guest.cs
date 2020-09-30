using System;
using System.Collections.ObjectModel;
using HotelManagement.Models.Reciepts;
using HotelManagement.Models.Rooms;

namespace HotelManagement.Models.Persons.Guests
{
    public class Guest: Person
    {
        private Guest() : base(null, null, null, null, null)
        {
            //Used by Entity FrameWork
        }

        public Guest(string firstName,string lastName, string phoneNumber, string username, string passwordHash) : base(firstName,lastName, phoneNumber, username, passwordHash)
        {
          BookedRooms = new ObservableCollection<Room>();
          Reciepts = new ObservableCollection<Reciept>();
        }

        public ObservableCollection<Room> BookedRooms { get; set; }
        public ObservableCollection<Reciept> Reciepts { get; set; }     
       
 
    }
}
