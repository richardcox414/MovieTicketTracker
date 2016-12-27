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
    public class SaleVM
    {
        public SaleVM(Sale toVM)
        {
            this.Id = toVM.Id;
            this.Date = toVM.Date;
            this.EmailAddress = toVM.EmailAddress;
            this.TotalAmount = toVM.TotalAmount;
            this.ConfirmCode = toVM.ConfirmCode;

            //might need to un do all this.. we shall see
            //foreach (var showtime in toVM.ShowTimes)
            //{

                //        while (showtime.ShowTime.Auditorium.ShowTimes != null)
                //        {
                //            showtime.ShowTime.Auditorium.ShowTimes = null;
                //        }
                //while (showtime.ShowTime.Movie.ShowTimes != null)
                //{
                //    showtime.ShowTime.Movie.ShowTimes = null;
                //}
                //        while (showtime.ShowTime.Auditorium.Theater.Auditoriums != null)
                //        {
                //            showtime.ShowTime.Auditorium.Theater.Auditoriums = null;
                //        }
                //        while (showtime.ShowTime.Movie.Genre.Movies != null)
                //        {
                //            showtime.ShowTime.Movie.Genre.Movies = null;
                //        }
                //        while (showtime.ShowTime.Movie.Reviews != null)
                //        {
                //            showtime.ShowTime.Movie.Reviews = null;
                //        }
                //        while (showtime.ShowTime.Sales != null)
                //        {
                //            showtime.ShowTime.Sales = null;
                //        }
            //    this.ShowTimes.Add(showtime);
            //}
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalAmount { get; set; }

        public string EmailAddress { get; set; }

        public int ConfirmCode { get; set; }


        public ICollection<ShowTimeSaleDetails> ShowTimes { get; set; } = new List<ShowTimeSaleDetails>();
    }
}