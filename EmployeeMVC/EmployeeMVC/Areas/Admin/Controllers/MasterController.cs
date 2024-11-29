using EmployeeMVC.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Areas.Admin.Controllers
{
    public class MasterController : Controller
    {
        private readonly AppDbContext _context;

        public MasterController(AppDbContext context)
        {
           _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
