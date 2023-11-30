using Microsoft.EntityFrameworkCore;
using UniversityOfNottinghamAPI.Models.OutputModels;

namespace UniversityOfNottinghamAPI.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<UsersOutput> Users { get; set; }
        public DbSet<DocumentOutput> DocumentOutputs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersOutput>().HasNoKey();
            modelBuilder.Entity<DocumentOutput>()
                .HasKey(d => d.Document_ID);

            base.OnModelCreating(modelBuilder);
        }
    }
}