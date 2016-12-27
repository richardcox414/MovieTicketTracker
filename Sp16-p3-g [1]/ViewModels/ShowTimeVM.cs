using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Sp16_p3_g__1_.Models;

namespace Sp16_p3_g__1_.ViewModels
{
    public class ShowTimeVM
    {
        public ShowTimeVM(ShowTime toVM)
        {
            this.Id = toVM.Id;
            this.ShowDate = toVM.ShowDate;
            this.StartTime = toVM.StartTime;
            this.TotalSeats = toVM.TotalSeats;
            this.Price = toVM.Price;
            this.TicketsSold = toVM.TicketsSold;
            this.Movie = toVM.Movie;
            this.Auditorium = toVM.Auditorium;

            //   this.Sales = toVM.Sales;

            while (this.Movie.ShowTimes != null)
            {
                this.Movie.ShowTimes = null;
            }
            while (this.Auditorium.ShowTimes != null)
            {
                this.Auditorium.ShowTimes = null;
            }
            while (this.Auditorium.Theater.Auditoriums != null)
            {
                this.Auditorium.Theater.Auditoriums = null;
            }
            while (this.Movie.Genre.Movies != null)
            {
                this.Movie.Genre.Movies = null;
            }
            while (this.Movie.Reviews != null)
            {
                this.Movie.Reviews = null;
            }
            while (this.Sales != null)
            {
                this.Sales = null;
            }
        }


        public int Id { get; set; }

        public TimeSpan StartTime { get; set; }

        public decimal Price { get; set; }

        public int TicketsSold { get; set; }

        public int TotalSeats { get; set; }

        public DateTime ShowDate { get; set; }



        public Auditorium Auditorium { get; set; }


        public Movie Movie { get; set; }

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}