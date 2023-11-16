using DAL.Data_Storage.Classes;
using Microsoft.EntityFrameworkCore;

namespace Crm.Website
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Startup startup = new Startup();

            startup.Run(args);
        }
    }
}