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
    public class CategoriesController : Controller
    {
        private readonly AppDbContext context;

        public CategoriesController(
            AppDbContext context
            )
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            //Eager
            var result = await context
                .Categories
                .OrderBy(p => p.Name)
                .ToListAsync();

            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            context.Categories.Add(model);

            try
            {
                await context.SaveChangesAsync();
                TempData["success"] = "Kategori ekleme işlemi başarıyla tamamlanmıştır!";
                return RedirectToAction("Index");
            }
            catch (DbException)
            {
                ViewBag.Categories = new SelectList(context.Categories, "Id", "Name");
                return View(model);
            }

        }

        [HttpGet()]
        public async Task<IActionResult> Remove(Guid id)
        {
            var model = await context.Categories.FindAsync(id);
            context.Categories.Remove(model);
            try
            {
                await context.SaveChangesAsync();
                TempData["success"] = "Kategori silme işlemi başarıyla tamamlanmıştır!";

            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index");

        }


        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await context.Categories.FindAsync(id);
            ViewBag.Categories = new SelectList(context.Categories, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category model)
        {
            context.Categories.Update(model);
            try
            {
                await context.SaveChangesAsync();
                TempData["success"] = "Kategori güncelleme işlemi başarıyla tamamlanmıştır!";
                return RedirectToAction("Index");
            }
            catch (DbException)
            {
                ViewBag.Categories = new SelectList(context.Categories, "Id", "Name");
                return View(model);
            }

        }


    }
}
