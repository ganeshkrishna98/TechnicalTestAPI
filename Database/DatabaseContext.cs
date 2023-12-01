using Microsoft.EntityFrameworkCore;
using UniversityOfNottinghamAPI.Models.ServerModels;

namespace UniversityOfNottinghamAPI.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<DocumentsModel> Documents { get; set; }
        public DbSet<UserAccountsModel> UserAccounts { get; set; }
        public DbSet<UserAuthenticationModel> UserAuthentication { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAuthenticationModel>().HasKey(x => x.userId);
            modelBuilder.Entity<DocumentsModel>().HasKey(x => x.documentId);
            modelBuilder.Entity<UserAccountsModel>().HasKey(x => x.userId);
            base.OnModelCreating(modelBuilder);
        }
    }
}