using Microsoft.AspNetCore.Identity;
using Assignment1.Models;


namespace Assignment1.Data
 
{
    public class ContextSeed
    {

        public static async Task SeedRolesAsync(UserManager<ApplicationUser> usermanager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Enum.Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Basic.ToString()));
        }

        public static async Task SuperSeedRoleAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var superUser = new ApplicationUser
            {
                UserName = "superAdmin",
                Email = "Test@test.com",
                FirstName = "John",
                LastName = "Doe",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(superUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(superUser, "SecurePass123!");
                await userManager.AddToRoleAsync(superUser, Enum.Roles.SuperAdmin.ToString());
                await userManager.AddToRoleAsync(superUser, Enum.Roles.Admin.ToString());
                await userManager.AddToRoleAsync(superUser, Enum.Roles.Moderator.ToString());
                await userManager.AddToRoleAsync(superUser, Enum.Roles.Basic.ToString());
            }
        }


    }
}
