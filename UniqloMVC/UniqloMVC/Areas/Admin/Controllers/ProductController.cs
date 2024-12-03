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
            ProductVM model = new ProductVM()
            {
                Categories = _context.Categories.Where(d =>  !d.IsDeleted).Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Title
                })
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                ProductVM model = new ProductVM()
                {
                    Categories = _context.Categories.Where(d => !d.IsDeleted).Select(d => new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.Title
                    }),
                    Product = product
                };
                return View(model);
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
                Categories = _context.Categories.Where(d => !d.IsDeleted).Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Title
                }),
                Product = updatedproduct
            };

            return View(model);
        }



       

        [HttpPost]
        public IActionResult Update(int id, Product product)
        {
            Product? updatedproduct = _context.Products.Find(id);
            if (updatedproduct == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ProductVM model = new ProductVM()
                {
                    Categories = _context.Categories.Where(d => !d.IsDeleted).Select(d => new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.Title
                    }),
                    Product = product
                };
                return View(model);
            }

            updatedproduct.UpdateDate = DateTime.Now;
            updatedproduct.CategoryId = product.CategoryId;
            updatedproduct.Title = product.Title;
            updatedproduct.Price = product.Price;
            updatedproduct.ImgUrl = product.ImgUrl;

            _context.Products.Update(updatedproduct);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


    }
}
