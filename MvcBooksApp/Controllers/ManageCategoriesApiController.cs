using MvcBooksApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcBooksApp.Controllers
{
    public class ManageCategoriesApiController : Controller
    {
        private BooksEntities db = new BooksEntities();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateJson([Bind(Include = "Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Set<Category>().Add(category);
                await db.SaveChangesAsync();
                return Json(new { status = true });
            }

            return Json(new { status = false });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}