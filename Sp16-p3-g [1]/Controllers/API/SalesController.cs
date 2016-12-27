using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Sp16_p3_g__1_.DAL;
using Sp16_p3_g__1_.Models;
using Sp16_p3_g__1_.ViewModels;

namespace Sp16_p3_g__1_.Controllers.API
{
    public class SalesController : ApiController
    {
        private MovieContext db = new MovieContext();

        // GET: api/Sales
        [HttpGet]
        [Route("api/Sales")]
        public async Task<ICollection<SaleVM>> GetSales()
        {
            var salz = await db.Sales.ToListAsync();
            var retList = new List<SaleVM>();
            foreach(var sale in salz)
            {
                    retList.Add(new SaleVM(sale));

            }
            return retList;
        }

        // GET: api/Sales/5
        [HttpGet]
        [Route("api/Sales/{id:int}")]
        [ResponseType(typeof(SaleVM))]
        public async Task<IHttpActionResult> GetSale(int id)
        {
            Sale sale = await db.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            return Ok(new SaleVM(sale));
        }

        // PUT: api/Sales/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSale(int id, Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sale.Id)
            {
                return BadRequest();
            }

            db.Entry(sale).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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

        // POST: api/Sales
        [HttpPost]
        [Route("api/Sales", Name = "PostSale")]
        [ResponseType(typeof(SaleVM))]
        public async Task<IHttpActionResult> PostSale(Sale sale)
        {
            if (sale?.ShowTimes == null || sale.EmailAddress == null)
            {
                return BadRequest(ModelState);
            }

            Random random = new Random();
            int maxValue = 11100;
            int r = random.Next(maxValue);
            sale.ConfirmCode = r;

            sale.Date = DateTime.UtcNow;
            var buyShow = new List<ShowTimeSaleDetails>();

            foreach(var saleDetail in sale.ShowTimes)
            {
                var dbShowTime = await db.ShowTimes.FindAsync(saleDetail.ShowTime.Id);

                if (dbShowTime.TotalSeats < saleDetail.Quantity)
                    return
                        BadRequest("Can not purchase " + saleDetail.Quantity + " for " + dbShowTime.StartTime + " . " +
                        dbShowTime.Movie.MovieName + " has an available seat count of " + dbShowTime.TotalSeats);
                dbShowTime.Movie = dbShowTime.Movie;
                dbShowTime.TotalSeats -= saleDetail.Quantity;
                dbShowTime.Auditorium = dbShowTime.Auditorium;
                db.Entry(dbShowTime).State = EntityState.Modified;
                buyShow.Add(new ShowTimeSaleDetails() { ShowTime = dbShowTime, Quantity = saleDetail.Quantity });
            }
            sale.ShowTimes = buyShow;
            sale.TotalAmount = CalculateSale(sale);
            db.Sales.Add(sale);

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

         //   SendEmail(sale);

            return CreatedAtRoute("PostSale", new { id = sale.Id }, new SaleVM(sale));
        }

        private void SendEmail(Sale purchasedCart)
        {
            using(var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.Credentials = new NetworkCredential("test.bookmovies383@gmail.com", "cmps383phase3");
                client.EnableSsl = true;
                var message = new MailMessage("test.bookmovies383@gmail.com", purchasedCart.EmailAddress,
                    "Movie Ticket Details",
                   "Your purchase:\n\tTotal: " + purchasedCart.TotalAmount.ToString("C") +
                   "\n\tMovie:\n\t\t" +
                   String.Join("\n\t\t", purchasedCart.ShowTimes.Select(s => s.ShowTime.StartTime + " (x" + s.Quantity + ") - " + s.ShowTime.Movie.AdultPrice.ToString("C"))));
                client.Send(message);
            }
        }

        [HttpPut]
        [Route("api/Sale/Calculate/")]
        public async Task<IHttpActionResult> CalculateTotal(Sale sale)
        {
            if (sale == null) return BadRequest();
            var calculate = new List<ShowTimeSaleDetails>();
            foreach (var saleShowTimeDetail in sale.ShowTimes)
            {
                saleShowTimeDetail.ShowTime = await db.ShowTimes.FindAsync(saleShowTimeDetail.ShowTime.Id);
                if (saleShowTimeDetail.ShowTime == null) return NotFound();
                calculate.Add(saleShowTimeDetail);
            }
            return Ok(CalculateShowTimes(calculate));
        }

        public decimal CalculateSale(Sale sale)
        {
            return CalculateShowTimes(sale.ShowTimes);
        }

        public decimal CalculateShowTimes(IEnumerable<ShowTimeSaleDetails> showtimes)
        {
            var total = 0M;
            Parallel.ForEach(showtimes, pr => total += (pr.ShowTime.Price * pr.Quantity));
            return total;
        }
        // DELETE: api/Sales/5
        [ResponseType(typeof(SaleVM))]
        public async Task<IHttpActionResult> DeleteSale(int id)
        {
            Sale sale = await db.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            db.Sales.Remove(sale);
            await db.SaveChangesAsync();

            return Ok(new SaleVM(sale));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SaleExists(int id)
        {
            return db.Sales.Count(e => e.Id == id) > 0;
        }
    }
}