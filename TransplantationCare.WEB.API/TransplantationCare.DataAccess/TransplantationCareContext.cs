using Microsoft.EntityFrameworkCore;
using TransplantationCare.Core.Models.DataBase;
using TransplantationCare.DataAccess.Helpers;

namespace TransplantationCare.DataAccess
{
    public class TransplantationCareContext : DbContext
    {
        public DbSet<Chat> Chats { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<ContractStatus> ContractStatuses { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Process> Processes { get; set; }

        public DbSet<ProcessStatus> ProcessStatuses { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserContract> UserContracts { get; set; }

        public TransplantationCareContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(DatabaseInitializationHelper.GetBaseRoles());
            modelBuilder.Entity<ContractStatus>().HasData(DatabaseInitializationHelper.GetBaseContractStatuses());
            modelBuilder.Entity<ProcessStatus>().HasData(DatabaseInitializationHelper.GetBaseProcessStatuses());
            modelBuilder.Entity<User>().HasData(DatabaseInitializationHelper.GetBaseAdmin());
        }
    }
}
