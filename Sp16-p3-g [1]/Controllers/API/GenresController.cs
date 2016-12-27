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
    public class GenresController : ApiController
    {
        private MovieContext db = new MovieContext();

        // GET: api/Genres
        public ICollection<GenreVM> GetGenres()
        {
            var genreList = new List<GenreVM>();
            foreach(var genre in db.Genres)
            {
                genreList.Add(new GenreVM(genre));
            }
            return genreList;
        }

        // GET: api/Genres/5
        [ResponseType(typeof(GenreVM))]
        public async Task<IHttpActionResult> GetGenre(int id)
        {
            Genre genre = await db.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            return Ok(new GenreVM(genre));
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGenre(int id, Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genre.Id)
            {
                return BadRequest();
            }

            db.Entry(genre).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
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

        // POST: api/Genres
        [ResponseType(typeof(GenreVM))]
        public async Task<IHttpActionResult> PostGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Genres.Add(genre);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = genre.Id }, new GenreVM(genre));
        }

        // DELETE: api/Genres/5
        [ResponseType(typeof(GenreVM))]
        public async Task<IHttpActionResult> DeleteGenre(int id)
        {
            Genre genre = await db.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            db.Genres.Remove(genre);
            await db.SaveChangesAsync();

            return Ok(new GenreVM(genre));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GenreExists(int id)
        {
            return db.Genres.Count(e => e.Id == id) > 0;
        }
    }
}