using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.UWP.Entities.Persons;

namespace HotelManagement.UWP.DAL.Api.Repository.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<Employee> ValidateEmployee(string username, string password);
        Task<Employee> GetEmployee(int id);

    }
}
