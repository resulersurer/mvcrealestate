using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCRealEstate.Data;
using System.Data.Common;

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
            //Eager
            var result = await context
                .Properties
                .Include(p => p.Category)
                .OrderByDescending(p => p.Date)
                .ToListAsync();

            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            await CreateDropdownsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Property model)
        {
            model.Date =
            model.DateModified = DateTime.Now;

            context.Properties.Add(model);

            try
            {

                await context.SaveChangesAsync();
                TempData["success"] = "İlan ekleme işlemi başarıyla tamamlanmıştır!";
                return RedirectToAction("Index");
            }
            catch (DbException)
            {
                await CreateDropdownsAsync();
                return View(model);
            }

        }

        [HttpGet()]
        public async Task<IActionResult> Remove(Guid id)
        {
            var model = await context.Properties.FindAsync(id);
            context.Properties.Remove(model);
            try
            {
                await context.SaveChangesAsync();
                TempData["success"] = "İlan silme işlemi başarıyla tamamlanmıştır!";

            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await context.Properties.FindAsync(id);
            await CreateDropdownsAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Property model)
        {
            model.DateModified = DateTime.Now;

            context.Properties.Update(model);
            try
            {
                await context.SaveChangesAsync();
                TempData["success"] = "İlan güncelleme işlemi başarıyla tamamlanmıştır!";
                return RedirectToAction("Index");
            }
            catch (DbException)
            {
                await CreateDropdownsAsync();
                return View(model);
            }

        }

        private async Task CreateDropdownsAsync()
        {
            ViewBag.Categories = new SelectList(await context.Categories.OrderBy(p => p.Name).ToListAsync(), "Id", "Name");
        }
    }
}
