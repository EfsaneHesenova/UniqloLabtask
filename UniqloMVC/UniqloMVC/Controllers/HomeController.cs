using Microsoft.AspNetCore.Mvc;
using UniqloMVC.DAL;
using UniqloMVC.Models;

namespace UniqloMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<SliderItem> sliderItems = _context.SliderItems.OrderByDescending(i => i.Id).Take(2).ToList();
            return View(sliderItems);
        }
    }
}
