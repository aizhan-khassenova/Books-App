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
using MvcBooksApp.ViewModels;

namespace MvcBooksApp.Controllers
{
    public class ManageBooksController : Controller
    {
        private BooksEntities db = new BooksEntities();

        // GET: ManageBooks
        public async Task<ActionResult> Index()
        {
            var books = from b in db.Set<Book>()

                        join a in db.Set<Author>() on b.AuthorId equals a.Id
                        join c in db.Set<Category>() on b.CategoryId equals c.Id

                        select new DisplayBookViewModel
                        {
                            AuthorId = b.AuthorId,
                            AuthorName = a.LastName + " " + a.FirstName,
                            CategoryId = b.CategoryId,
                            CategoryName = c.Name,
                            Cost = b.Cost,
                            Id = b.Id,
                            Pages = b.Pages,
                            Title = b.Title
                        };
            return View(await books.ToListAsync());
        }

        // GET: ManageBooks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.Set<Book>().FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [Authorize]
        // GET: ManageBooks/Create
        public ActionResult Create()
        {
            var authors = from a in db.Set<Author>()
                          select new
                          {
                              a.Id,
                              FullName = a.LastName + " " + a.FirstName
                          };
            ViewBag.AuthorId = new SelectList(authors, "Id", "FullName");
            ViewBag.CategoryId = new SelectList(db.Set<Category>(), "Id", "Name");
            return View();
        }

        // POST: ManageBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,AuthorId,CategoryId,Pages,Cost")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Set<Book>().Add(book);
                await db.SaveChangesAsync();
                return Json(new { status = true });
            }

            var authors = from a in db.Set<Author>()
                          select new
                          {
                              a.Id,
                              FullName = a.LastName + " " + a.FirstName
                          };

            ViewBag.AuthorId = new SelectList(authors, "Id", "FullName", book.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Set<Category>(), "Id", "Name", book.CategoryId);
            return Json(new { status = false });
        }

        [Authorize]
        // GET: ManageBooks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.Set<Book>().FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            var authors = from a in db.Set<Author>()
                          select new
                          {
                              a.Id,
                              FullName = a.LastName + " " + a.FirstName
                          };

            ViewBag.AuthorId = new SelectList(authors, "Id", "FullName", book.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Set<Category>(), "Id", "Name", book.CategoryId);
            return View(book);
        }

        // POST: ManageBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,AuthorId,CategoryId,Pages,Cost")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Json(new { status = true });
            }

            var authors = from a in db.Set<Author>()
                          select new
                          {
                              a.Id,
                              FullName = a.LastName + " " + a.FirstName
                          };

            ViewBag.AuthorId = new SelectList(authors, "Id", "FullName", book.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Set<Category>(), "Id", "Name", book.CategoryId);
            return Json(new { status = false });
        }

        [Authorize]
        // POST: ManageBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Book book = await db.Set<Book>().FindAsync(id);
            db.Set<Book>().Remove(book);
            await db.SaveChangesAsync();
            //return RedirectToAction("Index");
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