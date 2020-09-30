using System;
using System.ComponentModel;

namespace HotelManagement.UWP.Entities.Persons
{
    public abstract class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected Person()
        {

        }

    protected Person(string firstName, string lastName, string phoneNumber, DateTime dateofBirth) : this()
        {
            this.FirstName = firstName;
            this.Lastname = lastName;
            this.PhoneNumber = phoneNumber;
            DateOfBirth = dateofBirth;
        }

        protected Person(string firstName, string lastName, string phoneNumber, DateTime dateofBirth, string username, string passwordHash): this(firstName,lastName,phoneNumber, dateofBirth)
        {
           
            Username = username;
            PasswordHash = passwordHash;
        }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }


        
    }
}
