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
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }


        [DisplayName("Total Amount")]
        [Range(0.0, 9999999999999999.99)]
        public decimal TotalAmount { get; set; }

        [DisplayName("Confirm Code")]
        [Range(0, Int32.MaxValue)]
        public int ConfirmCode { get; set; }

        [Required]
        [DisplayName("Email Address")]
        [Column(TypeName = "varchar")]
        [DataType(DataType.EmailAddress)]
        [StringLength(512, ErrorMessage = "Email Address can be no more than 512 characters")]
        public string EmailAddress { get; set; }



        public virtual ICollection<ShowTimeSaleDetails> ShowTimes { get; set; } = new List<ShowTimeSaleDetails>();

    }
}