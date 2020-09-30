using System;

namespace HotelManagement.UWP.Entities.Persons.Employees.Janitors
{
    public class Janitor: Employee
    {
        public Janitor()
        {
            
        }
        public Janitor(string firstName, string lastName, string phoneNumber, DateTime dateofBirth, string username, string passwordHash) : base(firstName, lastName, phoneNumber,dateofBirth, username, passwordHash)
        {
        }
    }
}
