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
    public class MovieVM
    {

        public MovieVM(Movie toVM)
        {
            this.Id = toVM.Id;
            this.MovieName = toVM.MovieName;
            this.MovieRating = toVM.MovieRating;
            this.MovieImageUrl = toVM.MovieImageUrl;
            this.MovieLength = toVM.MovieLength;
            this.AdultPrice = toVM.AdultPrice;
            this.ChildPrice = toVM.ChildPrice;
            this.SeniorPrice = toVM.SeniorPrice;
            this.MovieSynopsis = toVM.MovieSynopsis;
            this.Reviews = toVM.Reviews;
         //   this.ShowTimes = toVM.ShowTimes;
            this.Genre = toVM.Genre;
            foreach (var showtime in toVM.ShowTimes)
            {
                while (showtime.Sales != null)
                {
                    showtime.Sales = null;
                }
                while (showtime.Auditorium.ShowTimes != null)
                {
                    showtime.Auditorium.ShowTimes = null;
                }
                while (showtime.Movie.ShowTimes != null)
                {
                    showtime.Movie.ShowTimes = null;
                }
                while(showtime.Auditorium.Theater.Auditoriums != null)
                {
                    showtime.Auditorium.Theater.Auditoriums = null;
                }
                while(showtime.Movie.Genre.Movies != null)
                {
                    showtime.Movie.Genre.Movies = null;
                }
                while(showtime.Movie.Reviews != null)
                {
                    showtime.Movie.Reviews = null;
                }
                this.ShowTimes.Add(showtime);
            }

        } 

        public int Id { get; set; }

        public string MovieName { get; set; }

        public TimeSpan MovieLength { get; set; }

        public string MovieRating { get; set; }

        public string MovieImageUrl { get; set; }

        public string MovieSynopsis { get; set; }

        public decimal AdultPrice { get; set; }

        public decimal ChildPrice { get; set; }

        public decimal SeniorPrice { get; set; }



        public Genre Genre { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<ShowTime> ShowTimes { get; set; } = new List<ShowTime>();
    }
}