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
    public class ShowTimesRazorController : Controller
    {
        private MovieContext db = new MovieContext();

        // GET: ShowTimesRazor
        public async Task<ActionResult> Index()
        {
            return View(await db.ShowTimes.ToListAsync());
        }

        // GET: ShowTimesRazor/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTime showTime = await db.ShowTimes.FindAsync(id);
            if (showTime == null)
            {
                return HttpNotFound();
            }
            return View(showTime);
        }

        // GET: ShowTimesRazor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShowTimesRazor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StartTime,Price,TicketsSold,TotalSeats,ShowDate,IsAvailable")] ShowTime showTime)
        {
            if (ModelState.IsValid)
            {
                db.ShowTimes.Add(showTime);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(showTime);
        }

        // GET: ShowTimesRazor/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTime showTime = await db.ShowTimes.FindAsync(id);
            if (showTime == null)
            {
                return HttpNotFound();
            }
            return View(showTime);
        }

        // POST: ShowTimesRazor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StartTime,Price,TicketsSold,TotalSeats,ShowDate,IsAvailable")] ShowTime showTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showTime).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(showTime);
        }

        // GET: ShowTimesRazor/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTime showTime = await db.ShowTimes.FindAsync(id);
            if (showTime == null)
            {
                return HttpNotFound();
            }
            return View(showTime);
        }

        // POST: ShowTimesRazor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ShowTime showTime = await db.ShowTimes.FindAsync(id);
            db.ShowTimes.Remove(showTime);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult CreateShow()
        {
            return View();
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
