using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Sp16_p3_g__1_.Models
{
    public class Auditorium 
    {
       
        [Key]
        public int Id { get; set; }

        //    [Index(IsUnique = true)]
        [DisplayName("Name")]
        [Column(TypeName = "varchar")]
        [StringLength(512, ErrorMessage = "Name can be no more than 512 characters")]
        public string AuditoriumName { get; set; }

        public virtual Theater Theater { get; set; }

        public virtual ICollection<ShowTime> ShowTimes { get; set; } = new List<ShowTime>();

    }
}