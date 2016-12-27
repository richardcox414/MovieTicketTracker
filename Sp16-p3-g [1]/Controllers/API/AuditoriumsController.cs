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
    [RoutePrefix("api")]
    public class AuditoriumsController : ApiController
    {
        private MovieContext db = new MovieContext();

        [HttpGet]
        [Route("Auditoriums")]
        public async Task<ICollection<AuditoriumVM>> GetAuditoriums()
        {
            var auds = await db.Auditoriums.ToListAsync();
            var audVms = new List<AuditoriumVM>();
            foreach(var auditorium in auds)
            {
                audVms.Add(new AuditoriumVM(auditorium));
            }
            return audVms;
        }

        [HttpGet]
        [Route("Auditoriums/{id:int}")]
        public async Task<IHttpActionResult> GetAuditorium(int id)
        {
            var searchAud = await db.Auditoriums.FirstOrDefaultAsync(t => t.Id == id);
            if (searchAud == null)
            {
                return NotFound();
            }

            return Ok(new AuditoriumVM(searchAud));
        }

        [ResponseType(typeof(ICollection<AuditoriumVM>))]
        [HttpGet]
        [Route("Auditoriums/Theater/{theaterId:int}")]
        public async Task<IHttpActionResult> GetAuditoriumsByTheater(int? theaterId, int id)
        {
            
            var check = await db.Theaters.FirstOrDefaultAsync(t => t.Id ==  id);
            if(theaterId != id)
            {
                return BadRequest("THeater does not exist");
            }

            if (theaterId == null)
            {
                return BadRequest("theater Id required");
            }
            var resultSet = new List<AuditoriumVM>();
            foreach(var auditorium in await db.Auditoriums.Where(a => a.Theater.Id == theaterId).ToListAsync())
            {
                resultSet.Add(new AuditoriumVM(auditorium));
            }
            return Ok(resultSet);
        }

        // PUT: api/Auditoriums/5
        [HttpPut]
        [Route("Auditoriums/{id:int}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAuditorium(int id, Auditorium auditorium)
        {
            Auditorium originalAuditorium = await db.Auditoriums.FindAsync(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != auditorium.Id)
            {
                return BadRequest("Auditorium Id required.");
            }

            auditorium.Theater = await db.Theaters.FindAsync(auditorium.Theater.Id);

            if (auditorium.Theater == null)
            {
                return BadRequest("Theater Id required");
            }

            originalAuditorium = UpdateAuditorium(originalAuditorium, auditorium);

            db.Entry(originalAuditorium).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditoriumExists(id))
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

        // POST: api/Auditoriums
        [HttpPost]
        [Route("Auditoriums/")]
        [ResponseType(typeof(AuditoriumVM))]
        public async Task<IHttpActionResult> PostAuditorium(Auditorium auditorium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var uniq = await db.Auditoriums.FirstOrDefaultAsync(a => a.AuditoriumName.ToLower() == auditorium.AuditoriumName.ToLower());
            if(uniq != null)
            {
                return BadRequest("Auditorium not unquie");
            }

            auditorium.Theater = await db.Theaters.FindAsync(auditorium.Theater.Id);
            if (auditorium.Theater == null)
            {
                return BadRequest("Auditorium needs a theater.");
            }


            db.Auditoriums.Add(auditorium);

            await db.SaveChangesAsync();

            return Ok();// CreatedAtRoute("DefaultApi", new { id = auditorium.Id }, new AuditoriumVM(auditorium));
        }

        // DELETE: api/Auditoriums/5
        
        [Route("Auditoriums/{id:int}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DeleteAuditorium(int id)
        {
            Auditorium auditorium = await db.Auditoriums.FindAsync(id);
            if (auditorium == null)
            {
                return NotFound();
            }

            db.Auditoriums.Remove(auditorium);

            await db.SaveChangesAsync();

            return Ok();// (auditorium);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuditoriumExists(int id)
        {
            return db.Auditoriums.Count(e => e.Id == id) > 0;
        }

        private Auditorium UpdateAuditorium(Auditorium originalAuditorium, Auditorium editedAuditorium)
        {
            originalAuditorium.Id = editedAuditorium.Id;
            originalAuditorium.AuditoriumName = editedAuditorium.AuditoriumName;
           // originalAuditorium.Theater = editedAuditorium.Theater;

            return originalAuditorium;
        }
    }
}