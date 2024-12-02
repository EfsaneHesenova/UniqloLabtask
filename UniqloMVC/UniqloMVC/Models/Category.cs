using UniqloMVC.Models.Base;

namespace UniqloMVC.Models
{
    public class Category : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Product>? Products { get; set; }

    }
}
