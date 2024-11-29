using EmployeeMVC.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
