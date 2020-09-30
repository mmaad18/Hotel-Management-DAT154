using System;
using System.ComponentModel;
using HotelManagement.UWP.Entities.Entity;

namespace HotelManagement.UWP.Entities.Persons.Guests
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
