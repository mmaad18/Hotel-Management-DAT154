using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAL.Repositorys.Shared.Password;
using HotelManagement.Entities.Persons.Guests;

namespace HotelManagement.DAL.Repositorys.Validation
{
    public class GuestValidationRepository : IValidationRepository<Guest>
    {
       
        public Guest Validate(string username, string password)
        {
            using (var context = new HotelManagementContext())
            {
                return context.Guests.First(x => x.Username.ToLower() == username &&  SecurePasswordHasher.Verify(password,x.PasswordHash));
            }
        }
    }
}
