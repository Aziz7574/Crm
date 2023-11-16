using Crm.Website.Models;
using DAL.Data_Storage.Classes;
using DAL.Data_Storage.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Crm.Website.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;

        private CrmRepository<Student> db = new CrmRepository<Student>(new CrmDbContext());

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            var all = db.GetAllStudents();
            return View(all);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
        
            var student = await db.GetAsync(p => p.Id == id);

            return View(student);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Student std)
        {
            await db.Update(std);
            return View(std);
         //   return RedirectToAction("Index");
        }

        [HttpDelete]

        public Task<IActionResult> Delete(Guid id)
        {
            return null;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}