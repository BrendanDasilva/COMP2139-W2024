using COMP2139_Labs.Areas.ProjectManagement.Models;
using COMP2139_Labs.Data;
using COMP2139_Labs.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2139_Labs.Areas.ProjectManagement.Controllers
{
  [Area("ProjectManagement")]
  [Route("[area]/[controller]/[action]")]

  public class ProjectCommentController : Controller
  {

    private readonly ApplicationDbContext _db;
    public ProjectCommentController(ApplicationDbContext context)
    {
      _db = context;
    }

    // GET: ProjectManagement/ProjectComment/GetComments/{projectId}
    [HttpGet]
    public async Task<IActionResult> GetComments(int projectId)
    {
      var comments = await _db.ProjectComments
                                   .Where(c => c.ProjectId == projectId)
                                   .OrderByDescending(c => c.CreatedDate)
                                   .ToListAsync();
      return Json(comments);
    }

    [HttpPost]
    public async Task<IActionResult> AddComment([FromBody] ProjectComment comment)
    {
      if (ModelState.IsValid)
      {
        comment.CreatedDate = DateTime.Now; // Set the current time as the posting time
        _db.ProjectComments.Add(comment);
        await _db.SaveChangesAsync();
        return Json(new { success = true, message = "Comment added successfully." });
      }

      // Log ModelState errors
      var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
      return Json(new { success = false, message = "Invalid comment data.", errors = errors });
    }
  }
}
