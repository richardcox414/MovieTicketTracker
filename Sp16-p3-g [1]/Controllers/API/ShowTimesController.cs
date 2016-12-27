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
    public class ShowTimesController : ApiController
    {
        private MovieContext db = new MovieContext();

        [HttpGet]
        public async Task<ICollection<ShowTimeVM>> GetShowTimes()
        {
            var shows = await db.ShowTimes.ToListAsync();
            var showVms = new List<ShowTimeVM>();
            foreach (var showtime in shows)
            {
                showVms.Add(new ShowTimeVM(showtime));
            }
            return showVms;
        }

        [HttpGet]
        [Route("api/ShowTimes/{id:int}")]  
        public async Task<IHttpActionResult> GetShowTime(int id)
        {
            var searchShow = await db.ShowTimes.FindAsync(id);
            if (searchShow == null) return NotFound();
            return Ok(new ShowTimeVM(searchShow));
        }

        [ResponseType(typeof(ICollection<ShowTimeVM>))]
        [Route("api/ShowTimes/Movie/{movieId:int}")]
        public async Task<IHttpActionResult> GetShowTimesByMovie(int? movieId)
        {
            if(movieId == null)
            {
                return BadRequest("movie id required.");
            }
            var resultSet = new List<ShowTimeVM>();
            foreach(var showtime in await db.ShowTimes.Where(s => s.Movie.Id == movieId).ToListAsync())
            {
                resultSet.Add(new ShowTimeVM(showtime));
            }
            return Ok(resultSet);
        }


        [Route("api/ShowTimes/{id:int}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShowTime(int id, ShowTime showTime)
        {
            ShowTime orgShow = await db.ShowTimes.FindAsync(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != showTime.Id)
            {
                return BadRequest();
            }

            showTime.Auditorium = await db.Auditoriums.FindAsync(showTime.Auditorium.Id);
            if(showTime.Auditorium == null)
            {
                return BadRequest("Auditorium Id needed");
            }

            showTime.Movie = await db.Movies.FindAsync(showTime.Movie.Id);

            orgShow = UpdateShow(orgShow, showTime);

          //  db.Entry(orgShow).CurrentValues.SetValues(showTime);
            db.Entry(orgShow).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowTimeExists(id))
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

        [ResponseType(typeof(ShowTime))]
        public async Task<IHttpActionResult> PostShowTime(ShowTime showTime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            showTime.Auditorium = await db.Auditoriums.FindAsync(showTime.Auditorium.Id);
            if (showTime.Auditorium == null)
            {
                return BadRequest("Auditorium Id needed");
            }

            showTime.Movie = await db.Movies.FindAsync(showTime.Movie.Id);

            db.ShowTimes.Add(showTime);
            await db.SaveChangesAsync();

            return Ok();//CreatedAtRoute("DefaultApi", new { id = showTime.Id }, new ShowTimeVM(showTime));
        }

        // DELETE: api/ShowTimes/5
        [Route("api/ShowTimes/{id:int}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DeleteShowTime(int id)
        {
            ShowTime showTime = await db.ShowTimes.FindAsync(id);
            if (showTime == null)
            {
                return NotFound();
            }

            db.ShowTimes.Remove(showTime);

            await db.SaveChangesAsync();

            return Ok();//(showTime);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShowTimeExists(int id)
        {
            return db.ShowTimes.Count(e => e.Id == id) > 0;
        }

        private ShowTime UpdateShow(ShowTime orgShow, ShowTime editShow)
        {
            orgShow.Id = editShow.Id;
            orgShow.Price = editShow.Price;
            orgShow.StartTime = editShow.StartTime;
            orgShow.ShowDate = editShow.ShowDate;
            orgShow.TotalSeats = editShow.TotalSeats;
            orgShow.Auditorium = editShow.Auditorium;
            orgShow.Movie = editShow.Movie;
            orgShow.TicketsSold = editShow.TicketsSold;

            return orgShow;
        }
    }
}