using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAL;
using HotelManagement.Entities.Persons;
using HotelManagement.Entities.Persons.Employees.Housekeeping;
using HotelManagement.Entities.Persons.Employees.Receptionists;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Reception.Services.DataService.Persons;

namespace HotelManagement.Reception.Design.Persons
{
    public class DesignPersonDataService: IPersonDataService
    {

        public List<Person> persons = new List<Person>();


        public DesignPersonDataService()
        {
            //TestRepos ss = new TestRepos();
            //var list = ss;
            //persons.Add(new Guest("Sondre"," Fingann", "98848184",DateTime.Now,"Sf","blolb"));
            //persons.Add(new Guest("Jens"," Stensrup", "43992834", DateTime.Now, "Sf", "blolb"));
            //persons.Add(new Guest("Lars"," Øvreset", "83374561", DateTime.Now, "Sf", "blolb"));
            //persons.Add(new Receptionist("Jone"," Bergman", "48837745", DateTime.Now, "test1", "blobl"));
            //persons.Add(new Housekeeper("Jens"," Stensrup", "43992834", DateTime.Now, "test2", "blobl"));
            //persons.Add(new Receptionist("Lars"," Øvreset", "83374561", DateTime.Now, "test3","blobl"));



        }

        public void GetPersons(Action<List<Person>, Exception> callback)
        {
            callback(persons, null);
        }

        public void GetPersonsOfType(Action<List<Person>, Exception> callback, Type type)
        {
            callback(persons.Where(x => x.GetType() == type).ToList(), null);
        }
    }
}
