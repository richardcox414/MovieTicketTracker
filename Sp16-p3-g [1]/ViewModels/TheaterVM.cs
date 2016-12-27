using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sp16_p3_g__1_.Models;

namespace Sp16_p3_g__1_.ViewModels
{
    public class TheaterVM
    {
   

        public TheaterVM(Theater toVM)
        {
            this.Id = toVM.Id;
            this.TheaterName = toVM.TheaterName;
          // this.Auditoriums = toVM.Auditoriums;

           //foreach( var auditorium in toVM.Auditoriums)
           // {
           //     while(auditorium.Theater.Auditoriums != null)
           //     {
           //         auditorium.Theater.Auditoriums = null;
           //     }
           //     this.Auditoriums.Add(auditorium);
           // }
            


        }

        public int Id { get; set; }

        public string TheaterName { get; set; }


        public ICollection<Auditorium> Auditoriums { get; set; } = new List<Auditorium>();
    }
}