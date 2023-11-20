using Crm.Website.Models;
using DAL.Data_Storage.Classes;
using DAL.Data_Storage.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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


        public async Task<ActionResult> Index()
        {
            var all = await db.GetAllStudents();    
            return View(all.OrderBy(p => p.Name).ThenBy(p => p.LastName).ThenBy(p => p.Email));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            var result = await db.AddAsync(student);

            if(result.Id != null)
               return RedirectToAction("Index");
            else
                return View(new ErrorViewModel());
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
            return RedirectToAction("Index");
            //   return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            Student student = await db.GetAsync(p => p.Id == id);
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            CrmDbContext crmDbContext = new CrmDbContext();
            if (crmDbContext.Students.ToList().IsNullOrEmpty())
            {
                return RedirectToAction("Index");
            }

            var student = await db.GetAsync(p => p.Id == id);
            if (student != null)
            {
                db.Delete(student);
            }
            return RedirectToAction(nameof(Index));
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