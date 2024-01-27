using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP2139_Labs.Models;
using COMP2139_Labs.Data;

namespace COMP2139_Labs.Controllers
{
  public class ProjectsController : Controller
  {
    private readonly ApplicationDbContext _db;

    public ProjectsController(ApplicationDbContext db)
    {
      _db = db;
    }

    public IActionResult Index()
    {
      return View(_db.Projects.ToList());
    }

    public IActionResult Details(int id)
    {
      var project = _db.Projects.FirstOrDefault(p => p.ProjectId == id);
      if (project == null) 
      {
        return NotFound();
      }
      return View(project);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
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

    public IActionResult Edit(int id)
    {
      var project = _db.Projects.Find(id);
      if (project == null)
      {
        return NotFound();
      }
      return View(project);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("ProjectId, Name, Description")] Project project)
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

    public IActionResult Delete(int id)
    {
      var project = _db.Projects.FirstOrDefault(p => p.ProjectId == id);
      if (project == null) 
      {
        return NotFound();
      }
      return View(project);
    }

    [HttpPost, ActionName("DeleteConfirmed")]
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
  }
}

