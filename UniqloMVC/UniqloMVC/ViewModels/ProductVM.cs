using Microsoft.AspNetCore.Mvc.Rendering;
using UniqloMVC.Models;

namespace UniqloMVC.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
