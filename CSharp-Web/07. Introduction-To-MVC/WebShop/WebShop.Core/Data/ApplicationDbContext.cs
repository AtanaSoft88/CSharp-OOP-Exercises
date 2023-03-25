using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //We can use these methods to Delete and Create DB , for Test purposes, but anyways Migrations using is recommended!
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
            
        }
    }
}