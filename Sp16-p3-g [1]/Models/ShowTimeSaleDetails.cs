﻿using System;
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
    public class ShowTimeSaleDetails 
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }

        public ShowTime ShowTime { get; set; }
        //here
       // public Movie Movie { get; set; }
    }
}