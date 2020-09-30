using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAL.Repositorys.Shared;
using HotelManagement.Entities.Persons;

namespace HotelManagement.DAL.Repositorys.Employees
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeesofType(Type type);
        IEnumerable<Employee> GetEmployeeByName(String name);



    }
}
