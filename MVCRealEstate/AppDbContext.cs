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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(entity =>
            {
                entity.HasData(
                    new Category { Id = Guid.Parse("{80057419-E9F1-42D1-AB26-1C632176E480}"), Name = "Konut" },
                    new Category { Id = Guid.Parse("{21531705-FA38-40DE-9BBA-7039A9549ED7}"), Name = "Dükkan" },
                    new Category { Id = Guid.Parse("{0250E03A-3839-4FA5-A9BC-9FE3966F6F46}"), Name = "Arsa" },
                    new Category { Id = Guid.Parse("{BD773033-227E-460A-B492-D218AC693F00}"), Name = "Yazlık" }
                    );
            });
            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}
