using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Sp16_p3_g__1_.Models
{
    public class Theater 
    {


        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [DisplayName("Name")]
        [Column(TypeName = "varchar")]
        [StringLength(512, ErrorMessage = "Name can be no more than 512 characters")]
        public string TheaterName { get; set; }


        public virtual ICollection<Auditorium> Auditoriums { get; set; } = new List<Auditorium>();
    }
}