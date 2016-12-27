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

//23:59:59.99

namespace Sp16_p3_g__1_.Controllers.API
{
    [RoutePrefix("api")]
    public class MoviesController : ApiController
    {
        private MovieContext db = new MovieContext();

        [HttpGet]
        [Route("Movies")]
        public async Task<ICollection<MovieVM>> GetMovies()
        {
            var movis = await db.Movies.ToListAsync();
            var movisVM = new List<MovieVM>();
            foreach(var movie in movis)
            {
                movisVM.Add(new MovieVM(movie));
            }
            return movisVM;
        }

        [HttpGet]
        [Route("Movies/{id:int}")]
        public async Task<IHttpActionResult> GetMovie(int id)
        {
            var movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(new MovieVM(movie));
        }

        [Route("Movies/{id:int}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMovie(int id, Movie movie)
        {
            Movie orgMovie = await db.Movies.FindAsync(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.Id)
            {
                return BadRequest("Can not find Movie Id");
            }

            movie.Genre = await db.Genres.FindAsync(movie.Genre.Id);
            if (movie.Genre == null)
            {
                return BadRequest("Movie needs genre");
            }

            orgMovie = UpdateMovie(orgMovie, movie);


            db.Entry(orgMovie).State = EntityState.Detached;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movies
        [ResponseType(typeof(void))]
        [Route("Movies")]
        [HttpPost]
        public async Task<IHttpActionResult> PostMovie(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            movie.Genre = await db.Genres.FindAsync(movie.Genre.Id);
            if(movie.Genre == null)
            {
                return BadRequest("Genre Id not found");
            }

            movie.Reviews = null;
       //     movie.ShowTimes = null;


            db.Movies.Add(movie);

            try
            {
                await db.SaveChangesAsync();
            }

            catch (System.Data.Entity.Core.UpdateException e)
            {

            }

            catch (System.Data.Entity.Infrastructure.DbUpdateException ex) //DbContext
            {
                System.Diagnostics.Debug.Write(ex.InnerException);
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.InnerException);
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = movie.Id }, new MovieVM (movie));
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DeleteMovie(int id)
        {
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            await db.SaveChangesAsync();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return db.Movies.Count(e => e.Id == id) > 0;
        }

        private Movie UpdateMovie(Movie orgMovie, Movie editMovie)
        {
            orgMovie.Id = editMovie.Id;
            orgMovie.MovieName = editMovie.MovieName;
            orgMovie.MovieLength = editMovie.MovieLength;
            orgMovie.MovieRating = editMovie.MovieRating;
            orgMovie.MovieImageUrl = editMovie.MovieImageUrl;
            orgMovie.Genre = editMovie.Genre;

            return orgMovie;
        }
    }
}