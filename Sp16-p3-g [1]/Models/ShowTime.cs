using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Sp16_p3_g__1_.Models
{
    [Table("ShowTimes")]
    public class ShowTime 
    {
   
        [Key]
        public int Id { get; set; }

        // [Required]
        [DisplayName("Start Time")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Range(0.0, 9999999999999999.99)]
        public decimal Price { get; set; }

        [DisplayName("Tickets Sold")]
        [Range(0, Int32.MaxValue)]
        public int TicketsSold { get; set; }

        [DisplayName("Aud Seats")]
        [Range(0, Int32.MaxValue)]
        public int TotalSeats { get; set; }

        [DisplayName("Show Date")]
        [Column(TypeName = "date")]
        [DataType(DataType.DateTime)]
        public DateTime ShowDate { get; set; }

        [DisplayName("Available")]
        public bool IsAvailable { get; set; }


        public virtual Auditorium Auditorium { get; set; }
        

        public virtual Movie Movie { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();



    }
}