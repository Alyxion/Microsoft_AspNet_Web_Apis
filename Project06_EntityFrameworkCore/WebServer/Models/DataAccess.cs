using Microsoft.EntityFrameworkCore;

namespace WebServer.Models
{
    public class SakilaDbContext : DbContext
    {
        public SakilaDbContext(DbContextOptions<SakilaDbContext> optons) :
        base(optons)
        {

        }

        public DbSet<Film> Film {get; set; }
    }

    public class SakilaDbContextFactory
    {
        public static SakilaDbContext Create(string connectionString)
        {
            var optonsBuilder = new DbContextOptionsBuilder<SakilaDbContext>();
            optonsBuilder.UseMySql(connectionString);
            var sakilaDbContext = new SakilaDbContext(optonsBuilder.Options);
            return sakilaDbContext;
        }
    }    
}