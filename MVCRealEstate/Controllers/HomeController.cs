using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCRealEstate.Data;
using MVCRealEstate.Models;

namespace MVCRealEstate.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext context;

    public HomeController(
        ILogger<HomeController> logger, 
        AppDbContext context
        )
    {
        _logger = logger;
        this.context = context;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Showcase = await context.Properties.OrderByDescending(p => p.Date).Take(6).ToListAsync();
        return View();
    }

    public async  Task<IActionResult> Detail(Guid id)
    {
        var model = await context.Properties.FindAsync(id);
        return View(model);
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
