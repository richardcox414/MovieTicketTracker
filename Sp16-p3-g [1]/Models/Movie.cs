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
    [Table("Movies")]
    public class Movie 
    {
    

        [Key]
        public int Id { get; set; }

        [Column(TypeName ="varchar")]
        [DisplayName("Title")]
        [StringLength(512, ErrorMessage ="Name can be no more than 512 characters")]
        public string MovieName { get; set; }

        [Column(TypeName = "time")]
        [DisplayName("Length")]
        [DataType(DataType.Time)]
        public TimeSpan MovieLength { get; set; }

        //public int ReviewId { get; set; }

        [DisplayName("Adult Price")]
        [Range(0.0, 9999999999999999.99)]
        public decimal AdultPrice { get; set; }

        [DisplayName("Senior Price")]
        [Range(0.0, 9999999999999999.99)]
        public decimal SeniorPrice { get; set; }

        [DisplayName("Child Price")]
        [Range(0.0, 9999999999999999.99)]
        public decimal ChildPrice { get; set; }

        [Column(TypeName = "varchar")]
        [DisplayName("Rating")]
        [StringLength(512, ErrorMessage = "Name can be no more than 512 characters")]
        public string MovieRating { get; set; }

        [DisplayName("Poster URL")]
        [Column(TypeName = "varchar")]
        [StringLength(512, ErrorMessage = "Image Url can be no more than 512 characters")]
        public string MovieImageUrl { get; set; }

        [DisplayName("Description")]
        [Column(TypeName = "varchar")]
      //  [StringLength(512, ErrorMessage = "Image Url can be no more than 512 characters")]
        public string MovieSynopsis { get; set; }

        public virtual Genre Genre { get; set; }


        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public virtual ICollection<ShowTime> ShowTimes { get; set; } = new List<ShowTime>();


    }
}