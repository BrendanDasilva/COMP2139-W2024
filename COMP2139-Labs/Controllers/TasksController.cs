using Microsoft.AspNetCore.Mvc;
using COMP2139_Labs.Data;
using COMP2139_Labs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

namespace COMP2139_Labs.Controllers
{
  public class TasksController : Controller
  {
    private readonly ApplicationDbContext _db;

    public TasksController(ApplicationDbContext context)
    {
      _db = context;
    }

    [HttpGet]
    public IActionResult Index(int projectId)
    {
      var tasks = _db.ProjectTasks.Where(t => t.ProjectId == projectId).ToList();
      ViewBag.ProjectId = projectId;
      return View(tasks);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
      var task = _db.ProjectTasks.Include(t => t.Project).FirstOrDefault(t => t.ProjectTaskId == id);
      if (task == null)
      {
        return NotFound();
      }
      return View(task);
    }

    public IActionResult Create(int projectId)
    {
      var project = _db.Projects.Find(projectId);
      if (project == null)
      {
        return NotFound();
      }

      var task = new ProjectTask
      {
        ProjectId = projectId
      };

      return View(task);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Title", "Description", "ProjectId")] ProjectTask task)
    {
      if (ModelState.IsValid)
      {
        _db.ProjectTasks.Add(task);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index), new { projectId = task.ProjectId });
      }

      ViewBag.Projects = new SelectList(_db.Projects, "ProjectsId", "Name", task.ProjectId);
      return View(task);
    }

    public IActionResult Edit(int id) 
    {
      var task = _db.ProjectTasks.Include(t => t.Project).FirstOrDefault(t => t.ProjectTaskId == id);
      if (task == null)
      {
        return NotFound();
      }

      ViewBag.Projects = new SelectList(_db.Projects, "ProjectId", "Name", task.ProjectId);
      return View(task);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("ProjectTaskId,Title,Description,ProjectId")] ProjectTask task)
    {
      if (id != task.ProjectTaskId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _db.Update(task);
          _db.SaveChanges();
          return RedirectToAction(nameof(Index), new { projectId = task.ProjectId });
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!_db.ProjectTasks.Any(e => e.ProjectTaskId == task.ProjectTaskId))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
      }
      ViewBag.Projects = new SelectList(_db.Projects, "ProjectId", "Name", task.ProjectId);
      return View(task);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
      var task = _db.ProjectTasks.Include(t => t.Project).FirstOrDefault(t => t.ProjectTaskId == id);
      if (task == null)
      {
        return NotFound();
      }
      return View(task);
    }

    [HttpPost, ActionName("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int ProjectTaskId)
    {
      var task = _db.ProjectTasks.Find(ProjectTaskId);
      if (task != null)
      {
        _db.ProjectTasks.Remove(task);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index), new { projectId = task.ProjectId });
      }
      return NotFound();
    }
  }
}
