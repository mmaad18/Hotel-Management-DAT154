using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models.Persons.Employees.Servants
{
    public class FoodServent: Employee
    {
        private FoodServent() : base(null, null, null, null, null)
        {
            //Used by Entity FrameWork
        }

        public FoodServent(string firstName, string lastName, string phoneNumber, string username, string passwordHash) : base(firstName, lastName, phoneNumber, username, passwordHash)
        {
        }
    }
}
