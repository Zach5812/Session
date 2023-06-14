using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session.Models;

namespace Session.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("addUser")]
    public IActionResult Create(string Name, int Score)
    {
        HttpContext.Session.SetString("Name", Name);
        HttpContext.Session.SetInt32("Score", 22);

        string? sessionName = HttpContext.Session.GetString("Name");
        int? sessionScore = HttpContext.Session.GetInt32("Score");

        return View("Dashboard");
    }

    [HttpPost("Logic")]
    public IActionResult Math(string operation)
    {
        if (operation == "1")
        {
            int? sessionScore = HttpContext.Session.GetInt32("Score");
            sessionScore = sessionScore + 1;
            HttpContext.Session.SetInt32("Score", (int)sessionScore);
        }
        if (operation == "2")
        {
            int? sessionScore = HttpContext.Session.GetInt32("Score");
            sessionScore = sessionScore - 1;
            HttpContext.Session.SetInt32("Score", (int)sessionScore);
        }
        if (operation == "3")
        {
            int? sessionScore = HttpContext.Session.GetInt32("Score");
            sessionScore = sessionScore * 2;
            HttpContext.Session.SetInt32("Score", (int)sessionScore);
        }
        if (operation == "4")
        {
            Random rand = new Random();
            int? sessionScore = HttpContext.Session.GetInt32("Score");
            sessionScore = sessionScore +rand.Next(1,10);
            HttpContext.Session.SetInt32("Score", (int)sessionScore);
        }
        return View("Dashboard");
    }

    [HttpPost("clearSession")]
    public IActionResult ClearSession()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
