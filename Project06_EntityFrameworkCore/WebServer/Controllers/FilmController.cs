using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    public class FilmsController : Controller
    {
        private SakilaDbContext dbContext;

        public FilmsController()
        {
            string connectionString = "server=localhost;port=3306;database=sakila;userid=root;pwd=!Vanen1909;sslmode=none";
            dbContext = SakilaDbContextFactory.Create(connectionString);
        }

        // Get all films
        [HttpGet]
        public Film [] Get()
        {
            return dbContext.Film.ToArray();
        }

        // Get film by id
        [HttpGet("{id}")]
        public Film Get(int id)
        {
            var target = dbContext.Film.SingleOrDefault(f=>f.Film_ID==id);
            return target;
        }
    }
}
