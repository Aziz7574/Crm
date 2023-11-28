using Microsoft.AspNetCore.Mvc;

namespace Crm.Website.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
