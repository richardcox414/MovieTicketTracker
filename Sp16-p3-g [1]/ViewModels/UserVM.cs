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
    public class UserVM
    {
        //
        //
        /// just added the models, no MVC controller or views or auth set up
        /// 
        /// //
        /// </summary>
        
        public int Id { get; set; }

        //public string ApiKey { get; set; }
    }
}