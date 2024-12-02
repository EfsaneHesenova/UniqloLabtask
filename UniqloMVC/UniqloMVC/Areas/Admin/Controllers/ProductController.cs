using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniqloMVC.DAL;
using UniqloMVC.Models;
using UniqloMVC.ViewModels;

namespace UniqloMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
         IEnumerable<Product> products =  await _context.Products.ToListAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Product deletedproduct = _context.Products.Find(id);
            if (deletedproduct == null)
            {
                return NotFound();
            }
            _context.Products.Remove(deletedproduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }









        public IActionResult Update(int id)
        {
            Product? updatedproduct = _context.Products.Find(id);
            if (updatedproduct == null)
            {
                return NotFound();
            }

            ProductVM model = new ProductVM()
            {
                Product = updatedproduct,
                Categories = _context.Categories.Where(d => !d.IsDeleted)
                                          .Select(d => new SelectListItem
                                          {
                                              Value = d.Id.ToString(),
                                              Text = d.Title
                                          }).ToList(),
            };

            return View(model);
        }



    }
}
