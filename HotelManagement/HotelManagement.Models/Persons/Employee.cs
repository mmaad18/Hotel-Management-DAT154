using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models.Persons
{
    public abstract class Employee: Person
    {
        protected Employee(string firstName,string lastName, string phoneNumber, string username, string passwordHash) : base(firstName, lastName, phoneNumber, username, passwordHash)
        {
           
        }
       

        
       

       
    }
}
