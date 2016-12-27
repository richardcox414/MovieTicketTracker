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
    public class Genre 
    {

        [Key]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Column(TypeName = "varchar")]
        [StringLength(512, ErrorMessage = "Name can be no more than 512 characters")]
        public string GenreName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}