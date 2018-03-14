using Microsoft.AspNetCore.Mvc;
using WebServer.Models;
using System.Linq;

namespace WebServer.Controllers
{
    [Route("api/people")]
    public class PeopleController : Controller
    {
        // Get all persons
        [HttpGet]
        public Person[] Get()
        {
            return Repository.People.ToArray();
        }

        // Get person by id
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return Repository.GetPersonByID(id);
        }

        [HttpPost]
        // Add a person
        public void Post([FromBody]Person person)
        {
            Repository.AddPerson(person);
        }

        [HttpPut("{id}")]
        // Replace person
        public void Put(int id, [FromBody]Person person)
        {
            Repository.ReplacePersonByID(id, person);
        }

        [HttpDelete("{id}")]
        // Delete person
        public void Delete(int id)
        {
            Repository.RemovePersonByID(id);
        }
    }
}