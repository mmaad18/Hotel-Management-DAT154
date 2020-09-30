namespace HotelManagement.Models.Persons.Employees.Receptionists
{
    public class Receptionist: Employee
    {
        private Receptionist() : base(null, null, null, null, null)
        {
            //Used by Entity FrameWork
        }
        public Receptionist(string firstName, string lastName, string phoneNumber, string username, string passwordHash) : base(firstName, lastName, phoneNumber, username, passwordHash)
        {
        }
    }
}
