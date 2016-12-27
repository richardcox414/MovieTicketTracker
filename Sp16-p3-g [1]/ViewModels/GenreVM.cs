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
    public class GenreVM
    {
        public GenreVM(Genre toVM)
        {
            this.Id = toVM.Id;
            this.GenreName = toVM.GenreName;
            
            // foreach(var movie in toVM.Movies)
            //{
            //    while(movie.Genre.Movies != null)
            //    {
            //        movie.Genre.Movies = null;
            //    }
            //    this.Movies.Add(movie);
            //}
            
        }

        public int Id { get; set; }

        public string GenreName { get; set; }


        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}