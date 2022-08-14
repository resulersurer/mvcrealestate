using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCRealEstate.Data;

namespace MVCRealEstate
{
    public static class ApplicationBuilderExtentions
    {
        public static IApplicationBuilder UseMVCRealEstate(this IApplicationBuilder builder)
        {
            var scope = builder.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            var userManeger = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            var user = new User
            {
                Name = config.GetValue<string>("DefaultUser:Name"),
                UserName = config.GetValue<string>("DefaultUser:UserName"),
                Email = config.GetValue<string>("DefaultUser:Email"),
                EmailConfirmed = true
            };

            userManeger.CreateAsync(user, config.GetValue<string>("DefaultUser:Password")).Wait();

            context.Database.Migrate();

            return builder;
        }
    }
}
