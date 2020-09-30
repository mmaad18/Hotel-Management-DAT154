using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.UWP.DAL.Api.HttpClient;
using HotelManagement.UWP.Entities.Persons;

namespace HotelManagement.UWP.DAL.Api.Repository.EmployeeRepository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        public RestClient<Employee> RestClient { get; set; }
        public string BaseEndpoint { get; set; }

        public EmployeeRepository()
        {
            
            RestClient = new RestClient<Employee>();
            BaseEndpoint = "Employees/";
        }
        public async Task<Employee> ValidateEmployee(string username, string password)
        {
            return await RestClient.Get(BaseEndpoint + "Validation/" +username+"/"+password);
        }
        public async Task<Employee> GetEmployee(int id)
        {
            return await RestClient.Get(BaseEndpoint + id);
        }
    }
}
