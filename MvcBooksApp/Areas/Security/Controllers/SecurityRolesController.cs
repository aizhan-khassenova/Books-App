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
using MvcBooksApp.Areas.Security.ViewModels;

namespace MvcBooksApp.Areas.Security.Controllers
{
    public class SecurityRolesController : Controller
    {
        private BooksEntities db = new BooksEntities();

        // GET: Security/SecurityRoles
        public async Task<ActionResult> Index()
        {
            //return View(await db.Roles.ToListAsync());
            return View(await db.Roles.Select(x => new DisplayRoleViewModel
            {
                Name = x.Name,
                Id = x.Id,
            }).ToListAsync());
        }

        // GET: Security/SecurityRoles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = await (db.Roles as DbSet<Role>).FindAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            //return View(role);
            return View(new DisplayRoleViewModel
            {
                Id = role.Id,
                Name = role.Name
            });
        }

        // GET: Security/SecurityRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Security/SecurityRoles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Role role)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name")] CreateRoleViewModel role)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    //db.Roles.Add(role);
                    db.Roles.Add(new Role
                    {
                        Name = role.Name,
                        Id = 0
                    });
                    await db.SaveChangesAsync();
                    return Json(new { status = true });
                }
                catch (Exception)
                {

                    return Json(new { status = false });
                }
            }

            return Json(new { status = false });
        }

        // GET: Security/SecurityRoles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = await (db.Roles as DbSet<Role>).FindAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            //return View(role);
            return View(new EditRoleViewModel
            {
                Id = role.Id,
                Name = role.Name
            });
        }

        // POST: Security/SecurityRoles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Role role)
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] EditRoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //db.Entry(role).State = EntityState.Modified;
                    var entry = await db.Roles.Where(x => x.Id == role.Id).FirstOrDefaultAsync();
                    entry.Name = role.Name;
                    db.Entry(entry).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return Json(new { status = true });
                }
                catch (Exception)
                {
                    return Json(new { status = false });
                }
            }
            return Json(new { status = false });
        }

        // POST: ManageAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Role roles = await db.Set<Role>().FindAsync(id);

            if (roles == null)
            {
                return HttpNotFound();
            }

            db.Set<Role>().Remove(roles);
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
