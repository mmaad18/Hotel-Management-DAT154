namespace HotelManagement.Models.Persons.Employees.Housekeeping
{
    public class Housekeeper: Employee
    {
       
        private Housekeeper() : base(null,null,null,null,null)
        {
            //Used by Entity FrameWork
        }
        public Housekeeper(string firstName, string lastName, string phoneNumber, string username, string passwordHash) : base(firstName,lastName, phoneNumber, username, passwordHash)
        {
        }
    }
}
