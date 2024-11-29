using Microsoft.EntityFrameworkCore;
using UniqloMVC.Models;

namespace UniqloMVC.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
       public DbSet<SliderItem> SliderItems { get; set; }
    }
}
