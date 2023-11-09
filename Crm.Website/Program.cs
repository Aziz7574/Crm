using DAL.Data_Storage.Classes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Crm.Website
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Startup startup = new Startup();

           // startup.Run(args);

            CrmDbContext db = new CrmDbContext(new DbContextOptions<CrmDbContext>());
            //var crmRepository = new CrmRepository<Student>(new CrmDbContext()
            //{

            //});
            /*  Startup startup = new Startup();
              startup.Run(args);*/
        }
    }
}