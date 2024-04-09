using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using COMP2139_Labs.Models;
using Humanizer;
using COMP2139_Labs.Services;

namespace COMP2139_Labs.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private readonly ISessionService _sessionService;

  public HomeController(ILogger<HomeController> logger, ISessionService sessionService)
  {
    _logger = logger;
    _sessionService = sessionService;
  }

  public IActionResult Index()
  {
    // Lab 12
    const string sessionKey = "VisitCount";
    int visitCount = _sessionService.GetSessionData<int>(sessionKey);
    visitCount++;
    _sessionService.SetSessionData(sessionKey, visitCount);

    ViewData["VisitCount"] = visitCount;

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
      //int defaultProjectId = 1;
      //return RedirectToAction("Search", "Tasks", new { area = "ProjectManagement", projectId = defaultProjectId, searchString });
      var url = Url.Action("Search", "Task", new { area = "ProjectManagement", searchString }) + $"?searchString={searchString}";
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
