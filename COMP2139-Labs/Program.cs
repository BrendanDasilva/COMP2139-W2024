using COMP2139_Labs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using COMP2139_Labs.Services;
using COMP2139_Labs.Areas.ProjectManagement.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
  .AddEntityFrameworkStores<ApplicationDbContext>()
  .AddDefaultUI()
  .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IEmailSender, IEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) // remove ! to see user environment
{
  app.UseExceptionHandler("/Home/Error");
  app.UseStatusCodePagesWithRedirects("/Home/NotFound?statusCode={0}");
  app.UseHsts();
} 
else
{
  app.UseDeveloperExceptionPage();
}

using var scope = app.Services.CreateScope();
var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();

try
{
  ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
  var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
  var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
  await ContextSeed.SeedRolesAsync(userManager, roleManager);
  await ContextSeed.SeedSuperAdminAsync(userManager, roleManager);
}
catch (Exception ex)
{
  var logger = loggerFactory.CreateLogger<Program>();
  logger.LogError(ex, "An error occurred seeding the Roles in the Database");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Projects}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();