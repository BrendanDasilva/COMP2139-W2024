using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP2139_Labs.Data;
using COMP2139_Labs.Areas.ProjectManagement.Models;
using COMP2139_Labs.Services;

namespace COMP2139_Labs.Areas.ProjectManagement.Controllers
{
    [Area("ProjectManagement")]
    [Route("[area]/[controller]/[action]")]
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<ProjectsController> _logger;
        private readonly ISessionService _sessionService;

        public ProjectsController(ApplicationDbContext db, ILogger<ProjectsController> logger,
          ISessionService sessionService)
        {
            _db = db;
            _logger = logger;
            _sessionService = sessionService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Calling project index action");
            var projects = await _db.Projects.ToListAsync();

            // Session Mgmt
            var value = _sessionService.GetSessionData<int?>("Visited") ?? 0;
            _sessionService.SetSessionData("Visited", value + 1);

            ViewBag.mysession = value + 1;

            return View(projects);
        }


        [HttpGet("Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            _logger.LogInformation("Calling project detail action");

            var project = await _db.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            if (ModelState.IsValid)
            {
                await _db.Projects.AddAsync(project);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        [HttpGet("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var project = await _db.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId, Name, Description, StartDate, EndDate, Status")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(project);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProjectExists(project.ProjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        private async Task<bool> ProjectExists(int projectId)
        {
            return await _db.Projects.AnyAsync(e => e.ProjectId == projectId);
        }

        [HttpGet("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _db.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost("DeleteConfirmed/{id:int}")]
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = _db.Projects.Find(id);
            if (project != null)
            {
                _db.Projects.Remove(project);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        [HttpGet("Search/{searchString?}")]
        public async Task<IActionResult> Search(string searchString)
        {
            var projectsQuery = from p in _db.Projects
                                select p;
            bool searchPerformed = !string.IsNullOrEmpty(searchString);
            if (searchPerformed)
            {
                projectsQuery = projectsQuery.Where(p => p.Name.Contains(searchString)
                                               || p.Description.Contains(searchString));
            }
            var projects = await projectsQuery.ToListAsync();
            ViewData["SearchPerformed"] = searchPerformed;
            ViewData["SearchString"] = searchString;
            return View("Index", projects); // Reuse the Index view to display results
        }

    }

}

