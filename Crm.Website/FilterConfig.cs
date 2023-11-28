using System.Web.Mvc;

namespace Crm.Website
{
    public class FilterConfig
    {
        public FilterConfig() { }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
