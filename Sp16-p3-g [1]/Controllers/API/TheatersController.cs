using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Sp16_p3_g__1_.DAL;
using Sp16_p3_g__1_.Models;
using Sp16_p3_g__1_.ViewModels;


namespace Sp16_p3_g__1_.Controllers.API
{
    public class TheatersController : ApiController
    {
        private MovieContext db = new MovieContext();

        public async Task<ICollection<TheaterVM>> GetTheaters()
        {
            var thets = await db.Theaters.ToListAsync();
            var thetsVms = new List<TheaterVM>();
            foreach(var theater in thets)
            {
                thetsVms.Add(new TheaterVM(theater));
            }
            return thetsVms;
        }

        [ResponseType(typeof(TheaterVM))]
        public async Task<IHttpActionResult> GetTheater(int id)
        {
            var searchThet = await db.Theaters.FirstOrDefaultAsync(t => t.Id == id);

            if (searchThet == null)
            {
                return NotFound();
            }
            var theater = new TheaterVM(searchThet);
            return Ok(theater);
        }

        // PUT: api/Theaters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTheater(int id, Theater theater)
        {
           Theater oldTheater = await db.Theaters.FindAsync(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != theater.Id)
            {
                return BadRequest("Theater Id error");
            }
            oldTheater = EditTheater(oldTheater, theater);

            db.Entry(oldTheater).CurrentValues.SetValues(theater);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheaterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Theaters
        [ResponseType(typeof(TheaterVM))]
        public async Task<IHttpActionResult> PostTheater(Theater theater)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            theater.Auditoriums = null;

            var special = await db.Theaters.FirstOrDefaultAsync(t => t.TheaterName.ToLower() == theater.TheaterName.ToLower());
            if (special != null)
            {
                return BadRequest("Theater Name exists already.");
            }

            db.Theaters.Add(theater);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = theater.Id }, new TheaterVM(theater));
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DeleteTheater(int id)
        {
            Theater theater = await db.Theaters.FindAsync(id);
            if (theater == null)
            {
                return NotFound();
            }

            db.Theaters.Remove(theater);

            await db.SaveChangesAsync();

            return Ok(new TheaterVM(theater));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TheaterExists(int id)
        {
            return db.Theaters.Count(e => e.Id == id) > 0;
        }

        private Theater EditTheater(Theater oldTHeater, Theater editedTheater)
        {
            oldTHeater.Id = editedTheater.Id;
            oldTHeater.TheaterName = editedTheater.TheaterName;
          //  originalTheater.Auditoriums = editedTheater.Auditoriums;

            return oldTHeater;
        }
    }
}