namespace Crm.Website
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var startup = new Startup();

            startup.Run(args);
        }
    }
}