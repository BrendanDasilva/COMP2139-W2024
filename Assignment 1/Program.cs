using Assignment1.Data;
using Assignment1.Models;
using Assignment1.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender, EmailSender>();

// Configure Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
  loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();

try
{
  var context = services.GetRequiredService<ApplicationDbContext>();
  var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
  var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

  // Seed roles and superadmin
  await ContextSeed.SeedRolesAsync(userManager, roleManager);
  await ContextSeed.SuperSeedRoleAsync(userManager, roleManager);
}
catch (Exception e)
{
  var logger = loggerFactory.CreateLogger<Program>();
  logger.LogError(e, "An error occurred when attempting to seed the roles for the system.");
}

if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{action=AdminIndex}/{id?}",
    defaults: new { controller = "Admin", action = "AdminIndex" });

app.Run();
