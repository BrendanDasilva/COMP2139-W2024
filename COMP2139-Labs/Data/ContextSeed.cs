using COMP2139_Labs.Areas.ProjectManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace COMP2139_Labs.Data
{
  public class ContextSeed
  {
    public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
      await roleManager.CreateAsync(new IdentityRole(Enum.Roles.SuperAdmin.ToString()));
      await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Admin.ToString()));
      await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Moderator.ToString()));
      await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Basic.ToString()));
    }

    public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
      //Seed Default User
      var defaultUser = new ApplicationUser
      {
        UserName = "superadmin",
        Email = "superadmin@gmail.com",
        FirstName = "Peter",
        LastName = "Parker",
        EmailConfirmed = true,
        PhoneNumberConfirmed = true
      };
      if (userManager.Users.All(u => u.Id != defaultUser.Id))
      {
        var user = await userManager.FindByEmailAsync(defaultUser.Email);
        if (user == null)
        {
          await userManager.CreateAsync(defaultUser, "[Password]");
          await userManager.AddToRoleAsync(defaultUser, Enum.Roles.Basic.ToString());
          await userManager.AddToRoleAsync(defaultUser, Enum.Roles.Moderator.ToString());
          await userManager.AddToRoleAsync(defaultUser, Enum.Roles.Admin.ToString());
          await userManager.AddToRoleAsync(defaultUser, Enum.Roles.SuperAdmin.ToString());
        }
      }
    }
  }
}
