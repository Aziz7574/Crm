using Crm.Website.Models;
using Microsoft.EntityFrameworkCore;
namespace DAL.Data_Storage.Classes
{
    public class CrmDbContext : DbContext
    {
        public CrmDbContext()
        {

        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<StudentGroup> StudentGroups { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=DESKTOP-4HKLI08\\MSSQLSERVER01;Database=Example;Trusted_Connection=true;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .Property(g => g.Price)
                .HasColumnType("decimal(18, 2)"); // Adjust precision and scale according to your needs

            // Other configurations...
        }

    }
}
