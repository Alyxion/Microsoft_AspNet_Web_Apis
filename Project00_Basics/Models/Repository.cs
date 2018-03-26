using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebServer.Models
{
    public class Repository
    {
        private static int counter;

        public static IList<Person> People{get;} = new List<Person>();

        // Returns a person by id
        public static Person GetPersonByID(int id)
        {
            var target = People.SingleOrDefault(p=>p.ID==id);            
            return target;
        }

        // Removes a person by id
        public static void RemovePersonByID(int id)
        {
            var target = People.SingleOrDefault(p=>p.ID==id);            
            if (target!=null)
            {
                People.Remove(target);
            }
        }

        // Replace a person by id
        public static void ReplacePersonByID(int id, Person person)
        {
            var target = People.SingleOrDefault(p=>p.ID==id);            
            if (target!=null)
            {
                People.Remove(target);
                People.Add(person);
            }                        
        }

        // Adds a person
        public static void AddPerson(Person person)
        {
            person.ID = counter++;
            People.Add(person);
        }
    }
}