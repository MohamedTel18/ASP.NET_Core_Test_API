using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MagicVilla_VillaAPI.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContest>
    {
        public ApplicationDbContest CreateDbContext(string[] args)
        {
            // Configure DbContextOptions here
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContest>();

            // Use your actual database provider (SQL Server, SQLite, etc.)
            var connectionString = "Server=localhost;Database=YourDatabase;Trusted_Connection=True;Encrypt=False;";

            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContest(optionsBuilder.Options);
        }

        
    }
}