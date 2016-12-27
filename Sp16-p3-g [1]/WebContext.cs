using System.Security.AccessControl;
using Sp16_p3_g__1_.Models;

namespace Sp16_p3_g__1_
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class WebContext : DbContext
    {
        // Your context has been configured to use a 'WebContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'JohnCandy.WebApi.WebContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'WebContext' 
        // connection string in the application configuration file.
        public WebContext()
            : base("name=WebContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Auditorium> Auditorium { get; set; }
        public virtual DbSet<Theater> Theaters { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }        
        public virtual DbSet<Review> Reviews { get; set; }
        

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}