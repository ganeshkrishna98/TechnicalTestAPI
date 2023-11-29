using Microsoft.EntityFrameworkCore;
using UniversityOfNottinghamAPI.Models.ServerModels;

namespace UniversityOfNottinghamAPI.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Documents> Documents { get; set; }
    }
}
