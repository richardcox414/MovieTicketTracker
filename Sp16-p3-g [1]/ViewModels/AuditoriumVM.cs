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
    public class AuditoriumVM
    {
        public AuditoriumVM(Auditorium toVM)
        {
            this.Id = toVM.Id;
            this.AuditoriumName = toVM.AuditoriumName;
          // this.ShowTimes = toVM.ShowTimes;
            foreach(var showtime in toVM.ShowTimes)
            {
                while (showtime.Auditorium.ShowTimes != null)
                {
                    showtime.Auditorium.ShowTimes = null;
                }
                while(showtime.Movie.ShowTimes != null)
                {
                    showtime.Movie.ShowTimes = null;
                }
                while (showtime.Sales != null)
                {
                    showtime.Sales = null;
                }
                this.ShowTimes.Add(showtime);
            }

           this.Theater = toVM.Theater;

           
        }

        public int Id { get; set; }

        public string AuditoriumName { get; set; }


        public Theater Theater { get; set; }

        public ICollection<ShowTime> ShowTimes { get; set; } = new List<ShowTime>();
    }
}