using Crm.Website.Models;
using Microsoft.EntityFrameworkCore;v
namespace DAL.Data_Storage.Classes

{
    public class CrmDbContext : DbContext
    {
        public CrmDbContext(DbContextOptions<CrmDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<StudentGroup> StudentGroups { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=DESKTOP-4HKLI08\\zzrxm;database=Example;trusted_connection=true;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
