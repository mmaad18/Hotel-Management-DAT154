using HotelManagement.UWP.Entities.Persons;

namespace HotelManagement.UWP.Entities.Messeges
{
    public class LoginMessage
    {
        public Employee Employee { get; set; }

        public LoginMessage(Employee employee)
        {
            Employee = employee;
        }

    }
}
