using System;

namespace HotelManagement.UWP.Entities.Persons.Employees.Receptionists
{
    public class Receptionist: Employee
    {
        public Receptionist()
        {
            
        }
        public Receptionist(string firstName, string lastName, string phoneNumber, DateTime dateofBirth, string username, string passwordHash) : base(firstName, lastName, phoneNumber,dateofBirth, username, passwordHash)
        {
        }
    }
}
