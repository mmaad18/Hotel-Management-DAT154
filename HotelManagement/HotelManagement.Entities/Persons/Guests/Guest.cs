using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using HotelManagement.Entities.Annotations;
using HotelManagement.Entities.Entity;
using HotelManagement.Entities.Reciepts;
using HotelManagement.Entities.Rooms;

namespace HotelManagement.Entities.Persons.Guests
{
    public class Guest: Person, IEntity, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


       

        public int Id { get; set; }

        public Guest()
        {
          
        }
        public Guest(string firstName, string lastName, string phoneNumber, DateTime dateofBirth) : base(firstName,lastName,phoneNumber,dateofBirth)
        {
        }
        public Guest(string firstName, string lastName, string phoneNumber, DateTime dateofBirth, string username, string passwordHash) : base(firstName, lastName, phoneNumber, dateofBirth, username, passwordHash)
        {
            
        }

        
       
    }
}
