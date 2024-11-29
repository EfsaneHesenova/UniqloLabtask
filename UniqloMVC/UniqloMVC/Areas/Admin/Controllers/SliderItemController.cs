using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniqloMVC.DAL;
using UniqloMVC.Models;

namespace UniqloMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderItemController : Controller
    {
        private readonly AppDbContext _context;

        public SliderItemController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<SliderItem> sliderItems = await _context.SliderItems.ToListAsync();
            return View(sliderItems);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SliderItem sliderItem)
        {
            if (!ModelState.IsValid)
            {
                return View(sliderItem);
            }
            _context.SliderItems.Add(sliderItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int? id)
        {
            SliderItem sliderItem = _context.SliderItems.Find(id);
            if (sliderItem == null)
            {
                return BadRequest();
            }

            return View(sliderItem);
        }
        [HttpPost]
        public IActionResult Update(SliderItem sliderItem)
        {
            if (!ModelState.IsValid)
            {
                return View(sliderItem);
            }
            SliderItem? uptadedsliderItem = _context.SliderItems.AsNoTracking().FirstOrDefault(s=>s.Id == sliderItem.Id);
            if (uptadedsliderItem == null)
            {
                return NotFound();
            }
            _context.SliderItems.Update(sliderItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public IActionResult Delete(int? id)
        {
            SliderItem? deletedsliderItem = _context.SliderItems.Find(id);
            if(deletedsliderItem==null)
            {
                return NotFound();
            }
            _context.SliderItems.Remove(deletedsliderItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
