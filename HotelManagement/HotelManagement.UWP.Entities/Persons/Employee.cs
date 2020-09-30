using System;
using System.ComponentModel;
using HotelManagement.UWP.Entities.Entity;

namespace HotelManagement.UWP.Entities.Persons
{
    public class Employee: Person, IEntity, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public int Id { get; set; }

        protected Employee()
        {
            
        }

        public string JobDescription { get; set; }
        protected Employee(string firstName, string lastName, string phoneNumber, DateTime dateofBirth, string username, string passwordHash) : base(firstName, lastName, phoneNumber, dateofBirth,username, passwordHash)
        {
        }
    }
}
