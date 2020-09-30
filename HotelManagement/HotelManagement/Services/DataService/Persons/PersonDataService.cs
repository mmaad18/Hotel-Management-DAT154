using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Entities.Persons;

namespace HotelManagement.Reception.Services.DataService.Persons
{
    
    public class PersonDataService: IPersonDataService
    {
       
        public void GetPersons(Action<List<Person>, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void GetPersonsOfType(Action<List<Person>, Exception> callback, Type type)
        {
            throw new NotImplementedException();
        }
    }
}
