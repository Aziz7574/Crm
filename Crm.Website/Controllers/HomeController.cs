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


         [HttpGet]
        public async Task<ActionResult> Index()
        {
            //  throw new NullReferenceException();
            var all = await db.GetAllStudents();
                
            return View(all.OrderBy(p => p.Name).ThenBy(p => p.LastName).ThenBy(p => p.Email));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {


            if (ModelState.IsValid)
            {
                var result = await db.AddAsync(student);
                return RedirectToAction("Index");
            }
            else
                return View();
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

            if (ModelState.IsValid)
            {
                await db.Update(std);
                return RedirectToAction("Index");
            }
            
            return View();
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


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            Student student = await db.GetAsync(p => p.Id == id);
            return View(student);
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


        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    filterContext.ExceptionHandled = true;

        //    //Log the error!!

        //    //Redirect to action
        //    filterContext.Result = RedirectToAction("Error", "InternalError");

        //    // OR return specific view
        //    filterContext.Result = new ViewResult
        //    {
        //        ViewName = "~/Views/Error/InternalError.cshtml"
        //    };
        //    return;
        //}



        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    filterContext.ExceptionHandled = true;

        //    //Log the error!!      

        //    //Redirect to action
        //    filterContext.Result = RedirectToAction("Error", "InternalError");

        //    // OR return specific view
        //    filterContext.Result = new ViewResult
        //    {
        //        ViewName = "~/Views/Error/InternalError.cshtml"
        //    };


        //}
    }
}