namespace HotelManagement.Models.Persons.Employees.Janitors
{
    public class Janitor: Employee
    {
        private Janitor() : base(null, null, null, null, null)
        {
            //Used by Entity FrameWork
        }
        public Janitor(string firstName, string lastName, string phoneNumber, string username, string passwordHash) : base(firstName,lastName, phoneNumber, username, passwordHash)
        {
        }
    }
}
