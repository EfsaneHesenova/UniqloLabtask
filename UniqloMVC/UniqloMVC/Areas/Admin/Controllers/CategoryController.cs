using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniqloMVC.DAL;
using UniqloMVC.Models;

namespace UniqloMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
          Category category = _context.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
            
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }
            Category updatedcategory = _context.Categories.AsNoTracking().FirstOrDefault();
            if(updatedcategory==null)
            {
                return NotFound();
            }
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Category deletedcategory = _context.Categories.Find(id);
            if(deletedcategory==null)
            {
                return NotFound();
            }
            _context.Categories.Remove(deletedcategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
