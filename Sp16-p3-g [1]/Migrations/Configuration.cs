using System.Web.Helpers;
using Sp16_p3_g__1_.Models;

namespace Sp16_p3_g__1_.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sp16_p3_g__1_.DAL.MovieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        /*
        If you have to update the database after it is already seeding, you need to drop all the tables in object explorer
        then update. If not dropped a sequence error will occur. This is not ideal but whatev'z
        */
        protected override void Seed(Sp16_p3_g__1_.DAL.MovieContext context)
        {
            var today = DateTime.UtcNow;
            var tomorrow = today.AddDays(1);
            var tomNext = tomorrow.AddDays(1);

            context.Users.AddOrUpdate(u => u.Email,
          new User()
          {
              Email = "sa@383.com",
              Password = Crypto.HashPassword("password"),
              FName = "Admin",
              LName = "383"
          });
            context.Users.AddOrUpdate(u => u.Email,
          new User()
          {
              Email = "sa@383.net",
              Password = Crypto.HashPassword("password"),
              FName = "Manager",
              LName = "383"
          });


            var Fake1 = new Genre() { GenreName = "Suspense", Id = 1 };
            var Fake2 = new Genre() { GenreName = "Thriller", Id = 2 };
            var Fake3 = new Genre() { GenreName = "Drama", Id = 3 };
            var Fake4 = new Genre() { GenreName = "Comedy", Id = 4 };
            var Fake5 = new Genre() { GenreName = "Action", Id = 5 };
            context.Genres.AddOrUpdate(u => u.Id, Fake1, Fake2, Fake3, Fake4, Fake5);

            var thet1 = new Theater() { TheaterName = "Regal Loft 4" };
            var thet2 = new Theater() { TheaterName = "AMC High 8" };
            context.Theaters.AddOrUpdate(u => u.Id, thet1, thet2);


            var aud1 = new Auditorium() { AuditoriumName = "Screen 1", Theater = thet1 };
            var aud2 = new Auditorium() { AuditoriumName = "Screen 5 ", Theater = thet1 };
            var aud3 = new Auditorium() { AuditoriumName = "Screen 4", Theater = thet1 };
            var aud4 = new Auditorium() { AuditoriumName = "Screen 3", Theater = thet1 };
            var aud5 = new Auditorium() { AuditoriumName = "Screen 2", Theater = thet1 };
            var aud6 = new Auditorium() { AuditoriumName = "Screen 7", Theater = thet1 };
            var aud7 = new Auditorium() { AuditoriumName = "Screen 10", Theater = thet1 };
            var aud8 = new Auditorium() { AuditoriumName = "Screen 8", Theater = thet1 };
            var aud9 = new Auditorium() { AuditoriumName = "Screen 9", Theater = thet1 };
            var aud10 = new Auditorium() { AuditoriumName = "Screen 9", Theater = thet2 };

            context.Auditoriums.AddOrUpdate(u => u.Id, aud1, aud2, aud3, aud4, aud5, aud6, aud7, aud8, aud9, aud10);


            var mov1 = new Movie()
            {
                MovieLength = new TimeSpan(2, 1, 1),
                MovieName = "Avatar",
                MovieRating = "M",
                AdultPrice = 9.99M,
                ChildPrice = 5.99M,
                SeniorPrice = 7.99M,
                MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b0/Avatar-Teaser-Poster.jpg",
                MovieSynopsis = "Jake Sully is a former Marine confined to a wheelchair. But despite his broken body, Jake is still a warrior at heart. He is recruited to travel light years to the human outpost on Pandora, where a corporate consortium is mining a rare mineral that is the key to solving Earth's energy crisis. Because Pandora's atmosphere is toxic, they have created the Avatar Program, in which human drivers have their consciousness linked to an avatar, a remotely-controlled biological body that can survive in the lethal air. These avatars are genetically engineered hybrids of human DNA mixed with DNA from the natives of Pandora... the Na'vi. Reborn in his avatar form, Jake can walk again. He is given a mission to infiltrate the Na'vi, who have become a major obstacle to mining the precious ore. But a beautiful Na'vi female, Neytiri, saves Jake's life, and this changes everything. Jake is taken in by her clan, and learns to become one of them, which involves many tests and adventures. As Jake's relationship with his reluctant teacher Neytiri deepens, he learns to respect the Na'vi way and finally takes his place among them. Soon he will face the ultimate test as he leads them in an epic battle that will decide the fate of an entire world.",
                Genre = Fake1,
            };
            var mov2 = new Movie()
            {
                MovieLength = new TimeSpan(1, 15, 1),
                MovieName = "Godzilla",
                MovieRating = "R",
                AdultPrice = 9.99M,
                ChildPrice = 5.99M,
                SeniorPrice = 7.99M,
                MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/2e/Godzilla_%281998_Movie_Poster%29.jpg",
                MovieSynopsis = "Giant Lizard attacks the last City in the world. Only an unknown hero can make amends.Godzilla does Manhattan in this variation on the Japanese A-bomb monster movie classic.",
                Genre = Fake2,
            };
            var mov3 = new Movie()
            {
                MovieLength = new TimeSpan(1, 25, 1),
                MovieName = "Hulk",
                MovieRating = "PG",
                AdultPrice = 9.99M,
                ChildPrice = 5.99M,
                SeniorPrice = 7.99M,
                MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/88/The_Incredible_Hulk_poster.jpg",
                MovieSynopsis = "The Incredible Hulk kicks off an all-new, explosive and action-packed epic of one of the most popular Super Heroes of all time. In the film, scientist Bruce Banner desperately hunts for a cure to the gamma radiation that poisoned his cells and unleashes the unbridled force of rage within him: The Hulk. Living in the shadows—cut off form a life he knew and the woman he loves, Betty Ross—Banner struggles to avoid the obsessive pursuit of his nemesis, General Thunderbolt Ross and the military machinery that seeks to capture him and brutally exploit his power. As all three grapple with the secrets that led to The Hulk’s creation, they are confronted with a monstrous new adversary known as the Abomination, whose destructive strength exceeds even The Hulk’s own.",
                Genre = Fake3,
            };
            var mov4 = new Movie()
            {
                MovieLength = new TimeSpan(2, 0, 1),
                MovieName = "Robocop",
                MovieRating = "NC-17",
                AdultPrice = 9.99M,
                ChildPrice = 5.99M,
                SeniorPrice = 7.99M,
                MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b1/Robocop_poster.jpg",
                MovieSynopsis = "The year is 2028 and multinational conglomerate OmniCorp is at the center of robot technology. Overseas, their drones have been used by the military for years, but have been forbidden for law enforcement in America. Now OmniCorp wants to bring their controversial technology to the home front, and they see a golden opportunity to do it. When Alex Murphy (Joel Kinnaman) – a loving husband, father and good cop doing his best to stem the tide of crime and corruption in Detroit – is critically injured.",
                Genre = Fake5,
            };
            var mov5 = new Movie()
            {
                MovieLength = new TimeSpan(1, 55, 1),
                MovieName = "Transformers",
                MovieRating = "PG-13",
                AdultPrice = 9.99M,
                ChildPrice = 5.99M,
                SeniorPrice = 7.99M,
                MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/66/Transformers07.jpg",
                MovieSynopsis = "Transformers: Dark of the Moon features Sam Witwicky taking his first tenuous steps into adulthood while remaining a reluctant human ally of Optimus Prime. The film centers around the space race between the U.S.S.R. and the USA, suggesting there was a hidden Transformers role in it all that remains one of the planet's most dangerous secrets. The villain of the third film will be Shockwave. (DreamWorks Pictures)",
                Genre = Fake4,
            };
            var mov6 = new Movie()
            {
                MovieLength = new TimeSpan(1, 55, 1),
                MovieName = "X-Men",
                MovieRating = "PG-13",
                AdultPrice = 9.99M,
                ChildPrice = 5.99M,
                SeniorPrice = 7.99M,
                MovieImageUrl = "http://upload.wikimedia.org/wikipedia/en/8/8c/XMen1poster.jpg",
                MovieSynopsis = "Dr. Charles Xavier gathers children from all over the planet who were born with an added twist to their genetic code. Known as the X - factor these children can perform extraordinary feats. Dr. Xavier calls them his X-Men.",
                Genre = Fake4,
            };
            var mov7 = new Movie()
            {
                MovieLength = new TimeSpan(2, 55, 1),
                MovieName = "Jurassic Park",
                MovieRating = "PG-13",
                AdultPrice = 9.99M,
                ChildPrice = 5.99M,
                SeniorPrice = 7.99M,
                MovieImageUrl = "http://upload.wikimedia.org/wikipedia/en/e/e7/Jurassic_Park_poster.jpg",
                MovieSynopsis = "Featuring incredible special effects and action - packed drama, Jurassic Park takes you to a remote island where an amazing theme park with living dinosaurs is about to turn deadly, as five people must battle to survive among the prehistoric predators.(Universal Pictures)",
                Genre = Fake4,
            };
            var mov8 = new Movie()
            {
                MovieLength = new TimeSpan(1, 35, 1),
                MovieName = "Hollow Man",
                MovieRating = "PG-13",
                AdultPrice = 9.99M,
                ChildPrice = 5.99M,
                SeniorPrice = 7.99M,
                MovieImageUrl = "http://upload.wikimedia.org/wikipedia/en/e/e1/Poster_Hollow_Man.jpg",
                MovieSynopsis = "A government scientist (Bacon) discovers how to make people invisible. After a freak accident that makes him slowly disappear, he begins to go insane and seeks revenge on the other scientists on the project.",
                Genre = Fake4,
            };
            try
            {
                context.Movies.AddOrUpdate(u => u.Id, mov1, mov2, mov3, mov4, mov5, mov6, mov7, mov8);
            }
            catch (System.Data.Entity.Core.UpdateException e)
            {

            }

            catch (System.Data.Entity.Infrastructure.DbUpdateException ex) //DbContext
            {
                System.Diagnostics.Debug.Write(ex.InnerException);
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.InnerException);
                throw;
            }

            context.ShowTimes.AddOrUpdate(u => u.StartTime,
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(11, 5, 1), IsAvailable = true, Auditorium = aud6, Movie = mov8 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(3, 5, 1), IsAvailable = true, Auditorium = aud8, Movie = mov7 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(5, 35, 1), IsAvailable = true, Auditorium = aud7, Movie = mov6 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(7, 5, 1), IsAvailable = true, Auditorium = aud6, Movie = mov1 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(9, 5, 1), IsAvailable = true, Auditorium = aud7, Movie = mov2 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(11, 5, 1), IsAvailable = true, Auditorium = aud1, Movie = mov1 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(3, 5, 1), IsAvailable = true, Auditorium = aud1, Movie = mov2 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(5, 35, 1), IsAvailable = true, Auditorium = aud1, Movie = mov3 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(7, 5, 1), IsAvailable = true, Auditorium = aud1, Movie = mov4 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(9, 5, 1), IsAvailable = true, Auditorium = aud1, Movie = mov5 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(11, 5, 1), IsAvailable = true, Auditorium = aud2, Movie = mov2 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(3, 5, 1), IsAvailable = true, Auditorium = aud2, Movie = mov3 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(5, 35, 1), IsAvailable = true, Auditorium = aud2, Movie = mov4 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(7, 5, 1), IsAvailable = true, Auditorium = aud2, Movie = mov5 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(9, 5, 1), IsAvailable = true, Auditorium = aud2, Movie = mov1 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(11, 5, 1), IsAvailable = true, Auditorium = aud3, Movie = mov3 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(3, 5, 1), IsAvailable = true, Auditorium = aud3, Movie = mov4 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(5, 35, 1), IsAvailable = true, Auditorium = aud3, Movie = mov5 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(7, 5, 1), IsAvailable = true, Auditorium = aud3, Movie = mov1 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(9, 5, 1), IsAvailable = true, Auditorium = aud3, Movie = mov2 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(11, 5, 1), IsAvailable = true, Auditorium = aud4, Movie = mov4 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(3, 5, 1), IsAvailable = true, Auditorium = aud4, Movie = mov5 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(5, 35, 1), IsAvailable = true, Auditorium = aud4, Movie = mov1 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(7, 5, 1), IsAvailable = true, Auditorium = aud4, Movie = mov4 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(9, 5, 1), IsAvailable = true, Auditorium = aud4, Movie = mov3 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(11, 5, 1), IsAvailable = true, Auditorium = aud1, Movie = mov1 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(3, 5, 1), IsAvailable = true, Auditorium = aud1, Movie = mov5 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(5, 35, 1), IsAvailable = true, Auditorium = aud1, Movie = mov4 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(7, 5, 1), IsAvailable = true, Auditorium = aud1, Movie = mov3 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(9, 5, 1), IsAvailable = true, Auditorium = aud1, Movie = mov2 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(11, 5, 1), IsAvailable = true, Auditorium = aud2, Movie = mov1 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(3, 5, 1), IsAvailable = true, Auditorium = aud2, Movie = mov4 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(5, 35, 1), IsAvailable = true, Auditorium = aud2, Movie = mov5 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(7, 5, 1), IsAvailable = true, Auditorium = aud2, Movie = mov1 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(9, 5, 1), IsAvailable = true, Auditorium = aud2, Movie = mov2 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(11, 5, 1), IsAvailable = true, Auditorium = aud3, Movie = mov3 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(3, 5, 1), IsAvailable = true, Auditorium = aud3, Movie = mov3 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(5, 35, 1), IsAvailable = true, Auditorium = aud3, Movie = mov4 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(7, 5, 1), IsAvailable = true, Auditorium = aud3, Movie = mov5 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(9, 5, 1), IsAvailable = true, Auditorium = aud3, Movie = mov1 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(11, 5, 1), IsAvailable = true, Auditorium = aud4, Movie = mov2 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(3, 5, 1), IsAvailable = true, Auditorium = aud4, Movie = mov5 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(5, 35, 1), IsAvailable = true, Auditorium = aud4, Movie = mov1 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(7, 5, 1), IsAvailable = true, Auditorium = aud4, Movie = mov4 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(9, 5, 1), IsAvailable = true, Auditorium = aud4, Movie = mov3 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(13, 55, 1), IsAvailable = true, Auditorium = aud7 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(15, 25, 1), IsAvailable = true, Auditorium = aud8 },
            new ShowTime() { ShowDate = today, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(17, 15, 1), IsAvailable = true, Auditorium = aud9 },
            new ShowTime() { ShowDate = tomNext, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(1, 5, 1), IsAvailable = true, Auditorium = aud1 },
            new ShowTime() { ShowDate = tomNext, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(3, 35, 1), IsAvailable = true, Auditorium = aud2 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(7, 35, 1), IsAvailable = true, Auditorium = aud3 },
            new ShowTime() { ShowDate = tomorrow, Price = 9.99M, TicketsSold = 1, TotalSeats = 50, StartTime = new TimeSpan(11, 35, 1), IsAvailable = true, Auditorium = aud4 });


            context.Reviews.AddOrUpdate(u => u.ReviewUser,
            new Review() { ReviewUser = "Roger", ReviewComment = "Movie was bad. Do not go! I would rather eat eggs.", Movie = mov1 },
            new Review() { ReviewUser = "Mike", ReviewComment = "Went to see it 100 times! I am in there now!... Wait, make that 101!", Movie = mov2 },
            new Review() { ReviewUser = "Bert", ReviewComment = "More like the popcorn was bad. Do not go to this stinking place!", Movie = mov3 },
            new Review() { ReviewUser = "Larry", ReviewComment = "Went to see it 100 times! I am in there now!", Movie = mov4 },
            new Review() { ReviewUser = "Marty", ReviewComment = "Movie was bad. Do not go! I am troll, that lives in your house.", Movie = mov5 });

            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                        DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format(
                            "- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                //Write to file
                System.IO.File.AppendAllLines(@"c:\temp\errors.txt", outputLines);
                throw;

                // Showing it on screen
                throw new Exception(string.Join(",", outputLines.ToArray()));

            }


        }

    }
}