using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using COMP2139_Labs.Models;
using Humanizer;

namespace COMP2139_Labs.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    return View();
  }

  public IActionResult About()
  {
    return View();
  }

  //Lab 5 - Project or ProjectTask Search
  // General search action
  [HttpGet]
  public IActionResult GeneralSearch(string searchType, string searchString)
  {
    if (searchType == "Projects")
    {
      // Redirect to Projects search
      return RedirectToAction("Search", "Projects", new { area = "ProjectManagement", searchString });
    }
    else if (searchType == "Tasks")
    {
      // Redirect to Tasks search - Assuming default projectId
      int defaultProjectId = 1;
      return RedirectToAction("Search", "Tasks", new { area = "ProjectManagement", projectId = defaultProjectId, searchString });
    }

    return RedirectToAction("Index", "Home");
  }

  //Lab 5 - NotFound() Action added
  public IActionResult NotFound(int statusCode)
  {
    if (statusCode == 404)
    {
      return View("NotFound");
    }
    return View("Error");
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
