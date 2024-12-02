using UniqloMVC.Models.Base;

namespace UniqloMVC.Models
{
    public class Product: BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Price { get; set; }
        public string ImgUrl { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
