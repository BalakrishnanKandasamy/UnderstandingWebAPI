using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UnderstandingWebAPI.Controllers
{
    [RoutePrefix("api")]
    public class PersonController : ApiController
    {
        static List<Person> persons = new List<Person> 
        {
            new Person {
                Name="Williams",
                Location="Bangalore",
                Age=27,
                Children=new List<Person>{
                    new Person{
                    Name="Serena",
                    Location="America",
                    Age=10
                    }
                }
            },
            new Person {
                Name="Roger",
                Location="Swiss",
                Age=26,
                Children=new List<Person>{
                    new Person{
                        Name="Federer",
                        Location="Swiss",
                        Age=5
                    }
                }
            }
        };
        // GET api/values
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

        [Route("{controller}/{name:alpha}/Children")]
        public List<Person> GetChildrenByPerson(string name)
        {
            return persons.First(person => person.Name == name).Children;
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
    public class Person
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
        public List<Person> Children { get; set; }
    }
}
