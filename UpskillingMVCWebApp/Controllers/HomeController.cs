using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UpskillingMVCWebApp.Data.Data;
using UpskillingMVCWebApp.Models;

namespace UpskillingMVCWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ScrumDbContext _context;

    public HomeController(ILogger<HomeController> logger, ScrumDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        ViewData["Projects"] = _context.Projects.ToList();

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}