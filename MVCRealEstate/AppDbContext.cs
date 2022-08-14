using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCRealEstate.Data;

namespace MVCRealEstate
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}
