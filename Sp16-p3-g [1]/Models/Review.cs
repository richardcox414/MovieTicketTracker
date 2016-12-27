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
    [Table("Reviews")]
    public class Review 
    {

      //  [Column("Review_Id")]
        [Key]
        public int Id { get; set; }

        [DisplayName("User")]
        [Column(TypeName = "varchar")]
        [StringLength(512, ErrorMessage = "Name can be no more than 512 characters")]
        public string ReviewUser { get; set; }

        [DisplayName("Comment")]
        [Column(TypeName = "varchar")]
        [StringLength(512, ErrorMessage = "Name can be no more than 512 characters")]
        public string ReviewComment { get; set; }

        
        public virtual Movie Movie { get; set; }
        
    }
}