using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Project = COMP2139_Labs.Areas.ProjectManagement.Models.Project;
using COMP2139_Labs.Areas.ProjectManagement.Models;

namespace COMP2139_Labs.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        
        public DbSet<ProjectTask> ProjectTasks { get; set; }
    }

}

