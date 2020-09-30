using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAL.Repositorys.Shared;
using HotelManagement.Entities.Persons;

namespace HotelManagement.DAL.Repositorys.Employees
{
    public class EmployeeRepository : EFRepository<HotelManagementContext, Employee>, IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployeesofType(Type type)
        {

            return GetAll().ToList().Where(x => x.GetType() == type); ;
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
        {
            return FindBy(x => x.FullName.Contains(name));
        }
    }
}
