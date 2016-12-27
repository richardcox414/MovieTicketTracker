using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sp16_p3_g__1_.Models;
using System.Security.AccessControl;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Sp16_p3_g__1_.DAL
{
    public class MovieContext : DbContext
    {

        public MovieContext() : base("name=MovieContext")
        {
            Database.SetInitializer<MovieContext>(null);

        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Auditorium> Auditoriums { get; set; }
        public virtual DbSet<Theater> Theaters { get; set; }
        public virtual DbSet<ShowTime> ShowTimes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
 

        // Fluent API to help with database relationships
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Theater>()
                .HasMany(a => a.Auditoriums)
                .WithOptional(t => t.Theater)
                .WillCascadeOnDelete();

            //modelBuilder.Entity<Auditorium>()
            //.HasRequired(a => a.Theater)
            //.WithMany(s => s.Auditoriums);

                //modelBuilder.Entity<Movie>()
                //  .HasMany(r => r.Reviews)
                //  .WithRequired(m => m.Movie)
                //  .WillCascadeOnDelete();


            modelBuilder.Entity<ShowTime>()
                        .HasOptional(a => a.Auditorium)
                        .WithMany(s => s.ShowTimes);

            base.OnModelCreating(modelBuilder);
        }
    }
}