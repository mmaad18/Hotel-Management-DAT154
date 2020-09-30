using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAL.Repositorys.Employees;
using HotelManagement.DAL.Repositorys.Shared.Password;
using HotelManagement.Entities.Persons;
using HotelManagement.Entities.Persons.Employees.Receptionists;

namespace HotelManagement.DAL.Repositorys.Validation
{
    class EmployeeValidationRepository: IValidationRepository<bool>
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public EmployeeValidationRepository()
        {
            EmployeeRepository = new EmployeeRepository();
        }
        public bool Validate(string username, string password)
        {
            return EmployeeRepository.GetEmployeesofType(typeof(Receptionist))
                .Any(x => String.Equals(x.PasswordHash, password, StringComparison.CurrentCultureIgnoreCase) && String.Equals(x.Username, username, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
