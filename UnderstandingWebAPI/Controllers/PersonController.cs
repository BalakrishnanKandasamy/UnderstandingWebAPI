using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UnderstandingWebAPI.Controllers
{
    public class PersonController : ApiController
    {
        static List<Person> persons = new List<Person> 
        {
            new Person{Name="Balakrishnan",Location="Bangalore",Age=27},
            new Person{Name="Sridevi",Location="Salem",Age=26}
        };
        // GET api/values
        [Route]
        public List<Person> GetPersons()
        {
            return persons;
        }

        // GET api/values/5
        [HttpGet]
        public Person FindPersonsByName(string name)
        {
            return persons.First(person => person.Name == name);
        }

        // POST api/values
        public void Post([FromUri]Person person)
        {
            persons.Add(person);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Person person)
        {
            persons[id] = person;
        }

        // DELETE api/values/5
        public void Delete(string name)
        {
            persons.Remove(persons.First(person => person.Name == name));
        }
    }
    [TypeConverter]
    public class Person
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
    }
}
