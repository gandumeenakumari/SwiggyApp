using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SwiggyApp.Models
{
    public class UserContext:DbContext
    {
        
        public UserContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
