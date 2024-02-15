using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP2139_Labs.Models;
using COMP2139_Labs.Data;

namespace COMP2139_Labs.Controllers
{
  [Route("Projects")]
  public class ProjectsController : Controller
  {
    private readonly ApplicationDbContext _db;

    public ProjectsController(ApplicationDbContext db)
    {
      _db = db;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
      return View(_db.Projects.ToList());
    }


    [HttpGet("Details/{id:int}")]
    public IActionResult Details(int id)
    {
      var project = _db.Projects.FirstOrDefault(p => p.ProjectId == id);
      if (project == null)
      {
        return NotFound();
      }
      return View(project);
    }

    [HttpGet("Create/{projectId:int}")]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost("Create/{projectId:int}")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Project project)
    {
      if (ModelState.IsValid)
      {
        _db.Projects.Add(project);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(project);
    }

    [HttpGet("Edit/{id:int}")]
    public IActionResult Edit(int id)
    {
      var project = _db.Projects.Find(id);
      if (project == null)
      {
        return NotFound();
      }
      return View(project);
    }

    [HttpPost("Edit/{id:int}")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("ProjectId, Name, Description, StartDate, EndDate, Status")] Project project)
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
          _db.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ProjectExists(project.ProjectId))
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

    private bool ProjectExists(int projectId)
    {
      return _db.Projects.Any(e => e.ProjectId == projectId);
    }

    [HttpGet("Delete/{id:int}")]
    public IActionResult Delete(int id)
    {
      var project = _db.Projects.FirstOrDefault(p => p.ProjectId == id);
      if (project == null)
      {
        return NotFound();
      }
      return View(project);
    }

    [HttpPost("DeleteConfirmed/{id:int}")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int ProjectId)
    {
      var project = _db.Projects.Find(ProjectId);
      if (project != null)
      {
        _db.Projects.Remove(project);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
      }
      return NotFound();
    }

    [HttpGet("Search/{searchString?}")]
    public async Task<IActionResult> Search(string searchString)
    {
      var projectsQuery = from p in _db.Projects
                          select p;
      bool searchPerformed = !String.IsNullOrEmpty(searchString);
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

