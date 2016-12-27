using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sp16_p3_g__1_.DAL;
using Sp16_p3_g__1_.Models;

namespace Sp16_p3_g__1_.Controllers
{
    public class AuditoriumsRazorController : Controller
    {
        private MovieContext db = new MovieContext();

        // GET: AuditoriumsRazor
        public async Task<ActionResult> Index()
        {
            return View(await db.Auditoriums.ToListAsync());
        }

        // GET: AuditoriumsRazor/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditorium auditorium = await db.Auditoriums.FindAsync(id);
            if (auditorium == null)
            {
                return HttpNotFound();
            }
            return View(auditorium);
        }

        // GET: AuditoriumsRazor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuditoriumsRazor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,AuditoriumName")] Auditorium auditorium)
        {
            if (ModelState.IsValid)
            {
                db.Auditoriums.Add(auditorium);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(auditorium);
        }

        // GET: AuditoriumsRazor/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditorium auditorium = await db.Auditoriums.FindAsync(id);
            if (auditorium == null)
            {
                return HttpNotFound();
            }
            return View(auditorium);
        }

        // POST: AuditoriumsRazor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,AuditoriumName")] Auditorium auditorium)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditorium).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(auditorium);
        }

        // GET: AuditoriumsRazor/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditorium auditorium = await db.Auditoriums.FindAsync(id);
            if (auditorium == null)
            {
                return HttpNotFound();
            }
            return View(auditorium);
        }

        // POST: AuditoriumsRazor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Auditorium auditorium = await db.Auditoriums.FindAsync(id);
            db.Auditoriums.Remove(auditorium);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
