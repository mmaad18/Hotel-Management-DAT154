using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models.Entity;

namespace HotelManagement.Models.Persons
{
    public abstract class Person: IEntity
    {
        
        protected Person(string firstName,string lastName, string phoneNumber,string username, string passwordHash)
        {
            this.FirstName = firstName;
            this.Lastname = lastName;
            this.PhoneNumber = phoneNumber;
            Username = username;
            PasswordHash = passwordHash;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string FullName => $"{FirstName} {Lastname}";
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }


    }
}
