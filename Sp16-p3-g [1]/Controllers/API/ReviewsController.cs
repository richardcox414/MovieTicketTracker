using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Sp16_p3_g__1_.DAL;
using Sp16_p3_g__1_.Models;
using Sp16_p3_g__1_.ViewModels;

namespace Sp16_p3_g__1_.Controllers.API
{
    public class ReviewsController : ApiController
    {
        private MovieContext db = new MovieContext();

        [HttpGet]
        public async Task<ICollection<ReviewVM>> GetReviews()
        {
            var revs = await db.Reviews.ToListAsync();
            var revVms = new List<ReviewVM>();
            foreach( var review in revs)
            {
                revVms.Add(new ReviewVM(review));
            }
            return revVms;
        }

        [HttpGet]
        [Route("api/Reviews/{id:int}")]
        public async Task<IHttpActionResult> GetReview(int id)
        {
            var searchRev = await db.Reviews.FindAsync(id);
            if (searchRev == null)
            {
                return NotFound();
            }

            return Ok(new ReviewVM(searchRev));
        }

        [ResponseType(typeof(ICollection<ReviewVM>))]
        [Route("api/Reviews/Movie/{movieId:int}")]
        public async Task<IHttpActionResult> GetReviewByMovie(int? movieId)
        {
            

            if (movieId == null)
            {
                return BadRequest("Movie Id Required.");
            }

            var revList = new List<ReviewVM>();
            foreach (var review in await db.Reviews.Where(r => r.Movie.Id == movieId).ToListAsync())
            {
                revList.Add(new ReviewVM(review));
            }
            return Ok(revList);
        }

        [Route("api/Reviews/{id:int}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReview(int id, Review review)
        {

            Review orginalReview = await db.Reviews.FindAsync(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != review.Id)
            {
                return BadRequest();
            }

            review.Movie = await db.Movies.FindAsync(review.Movie.Id);
            if(review.Movie == null)
            {
                return BadRequest("Movie Id");
            }


            orginalReview = UpdateReview(orginalReview, review);

            // db.Entry(review).State = EntityState.Modified;
            db.Entry(orginalReview).CurrentValues.SetValues(review);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/Reviews
        [ResponseType(typeof(ReviewVM))]
        public async Task<IHttpActionResult> PostReview(Review review)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            review.Movie = await db.Movies.FindAsync(review.Movie.Id);
            if(review.Movie == null)
            {
                return BadRequest("Need llink to movie");
            }

            db.Reviews.Add(review);
            await db.SaveChangesAsync();

            return  CreatedAtRoute("DefaultApi", new { id = review.Id }, new ReviewVM(review));
        }

        // DELETE: api/Reviews/5
        [Route("api/Reviews/{id:int}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DeleteReview(int id)
        {
            Review review = await db.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            db.Reviews.Remove(review);
            await db.SaveChangesAsync();

            return Ok(review);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReviewExists(int id)
        {
            return db.Reviews.Count(e => e.Id == id) > 0;
        }

        private Review UpdateReview(Review originalReview, Review editedReview)
        {
            originalReview.Id = editedReview.Id;
            originalReview.ReviewUser = editedReview.ReviewUser;
            originalReview.ReviewComment = editedReview.ReviewComment;
          //  originalReview.Movie.Id = editedReview.Movie.Id;

            return originalReview;
        }
    }
}