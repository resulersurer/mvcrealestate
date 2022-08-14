using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MVCRealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PropertiesController : Controller
    {
        private readonly AppDbContext context;

        public PropertiesController(
            AppDbContext context
            )
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var result = await context
                .Properties
                .OrderByDescending(p => p.Date)
                .ToListAsync();

            return View(result);
        }
    }
}
