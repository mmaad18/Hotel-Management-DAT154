using System;

namespace HotelManagement.Entities.Persons.Employees.Servants
{
    public class FoodServent: Employee
    {
        public FoodServent()
        {
            
        }
        public FoodServent(string firstName, string lastName, string phoneNumber, DateTime dateofBirth, string username, string passwordHash) : base(firstName, lastName, phoneNumber,dateofBirth, username, passwordHash)
        {
        }
    }
}
