using Microsoft.EntityFrameworkCore;

namespace SakilaWebServer.Models {
    class SakilaDbContext : DbContext {
        public SakilaDbContext(DbContextOptions<SakilaDbContext> options)
        : base(options) { }

        public DbSet<Actor> Actor { get; set; }
        // DbSet<T> type properties for other domain models
    }

    class SakilaDbContextFactory {
        public static SakilaDbContext Create(string connectionString) {
            var optionsBuilder = new DbContextOptionsBuilder<SakilaDbContext>();
            optionsBuilder.UseMySql(connectionString);
            var dbContext = new SakilaDbContext(optionsBuilder.Options);
            return dbContext;
        }
    }
}