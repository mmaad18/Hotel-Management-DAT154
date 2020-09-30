using System;

namespace HotelManagement.UWP.Entities.Persons.Employees.Housekeeping
{
    public class Housekeeper: Employee
    {
        public Housekeeper()
        {
            
        }
        public Housekeeper(string firstName, string lastName, string phoneNumber, DateTime dateofBirth, string username, string passwordHash) : base(firstName, lastName, phoneNumber,dateofBirth, username, passwordHash)
        {
        }

        
    }
}
