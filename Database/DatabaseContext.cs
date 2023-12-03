using Microsoft.EntityFrameworkCore;
using UniversityOfNottinghamAPI.Models.ServerModels;

namespace UniversityOfNottinghamAPI.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<AccessLogsModel> AccessLogs { get; set; }
        public DbSet<DevicesModel> Devices { get; set; }
        public DbSet<DocumentsModel> Documents { get; set; }
        public DbSet<NotificationsModel> Notifications { get; set; }
        public DbSet<StoragesModel> Storages { get; set; }
        public DbSet<UserAccountsModel> UserAccounts { get; set; }
        public DbSet<UserAuthenticationModel> UserAuthentication { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessLogsModel>().HasKey(x => x.userId);
            modelBuilder.Entity<DevicesModel>().HasKey(x => x.deviceId);            
            modelBuilder.Entity<DocumentsModel>().HasKey(x => x.documentId);
            modelBuilder.Entity<NotificationsModel>().HasKey(x => x.notificationId);
            modelBuilder.Entity<StoragesModel>().HasKey(x => x.storageId);
            modelBuilder.Entity<UserAuthenticationModel>().HasKey(x => x.userId);
            modelBuilder.Entity<UserAccountsModel>().HasKey(x => x.userId);
            base.OnModelCreating(modelBuilder);
        }
    }
}