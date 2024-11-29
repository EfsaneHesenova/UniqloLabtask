using UniqloMVC.Models.Base;

namespace UniqloMVC.Models
{
    public class SliderItem: BaseAuditableEntity
    {
        public string Title { get; set; }
        public string ButtonUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}
