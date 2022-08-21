using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MVCRealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AppDbContext context;

        public HomeController(
            AppDbContext context
            )
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Properties = await context.Properties.CountAsync();
            ViewBag.Categories = await context.Categories.CountAsync();
            return View();
        }
    }
}
