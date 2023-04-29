using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcBooksApp.Models;

namespace MvcBooksApp.Controllers
{
    public class ManageAuthorsController : Controller
    {
        private readonly BooksEntities db = new BooksEntities();

        private DbSet<T> Set<T>() where T : class
            => db.Set<T>();

        // GET: ManageAuthors
        public async Task<ActionResult> Index()
        {
            return View(await Set<Author>().ToListAsync());
        }

        // GET: ManageAuthors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = await Set<Author>().FindAsync(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        [Authorize]
        // GET: ManageAuthors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LastName,FirstName")] Author author)
        {
            if (ModelState.IsValid)
            {
                Set<Author>().Add(author);
                await db.SaveChangesAsync();
                return Json(new { status = true });
            }

            return Json(new { status = false });
        }

        [Authorize]
        // GET: ManageAuthors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = await Set<Author>().FindAsync(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: ManageAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,LastName,FirstName")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Json(new { status = true });
            }
            return Json(new { status = false });
        }

        [Authorize]
        // POST: ManageAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Author author = await Set<Author>().FindAsync(id);
            Set<Author>().Remove(author);
            await db.SaveChangesAsync();
            return Json(new { status = true });
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