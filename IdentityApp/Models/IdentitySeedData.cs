using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models

{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Admin_123";

        public static async void IdentityTestUser(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate(); // bekleyen migrations varssa migrate yap
            }

            var UserManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

           var user= await UserManager.FindByNameAsync(adminUser);

            if (user == null)
            {

                user = new AppUser{
                    FullName ="Muhammet Ali",
                    UserName=adminUser,
                    Email="admin@alikayanc",
                    PhoneNumber = "123456"
                    
                };

                await UserManager.CreateAsync(user, adminPassword);
            }
        }
    }
}