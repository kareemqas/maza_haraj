using Mazad_Haraj.Models;
using Microsoft.AspNetCore.Identity;

namespace Mazad_Haraj.Data
{
    public class SeedData
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            IdentityResult roleResult;
            //Add Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            roleCheck = await RoleManager.RoleExistsAsync("Bidder");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Bidder"));
            }

            AppUser user = await UserManager.FindByEmailAsync("admin@mazadharaj.ksa");
            if (user == null)
            {
                var User = new AppUser();
                User.Email = "admin@mazadharaj.ksa";
                User.UserName = "admin@mazadharaj.ksa";
                string password = "Admin@123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, password);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = await UserManager.AddToRoleAsync(User, "Admin");
                }
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            //using (var context = new DataContext(
            //    serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            //{
            CreateUserRoles(serviceProvider).Wait();
            //}
        }
    }
}
