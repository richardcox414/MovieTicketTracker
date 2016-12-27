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
    public class ReviewVM
    {

        public ReviewVM(Review toVM)
        {
            this.Id = toVM.Id;
            this.ReviewUser = toVM.ReviewUser;
            this.ReviewComment = toVM.ReviewComment;
        }

        public int Id { get; set; }

        public string ReviewUser { get; set; }

        public string ReviewComment { get; set; }



        public Movie Movie { get; set; }
    }
}