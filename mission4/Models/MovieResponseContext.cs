using System;
using Microsoft.EntityFrameworkCore;

namespace mission4.Models
{
    public class MovieResponseContext : DbContext
    {
        public MovieResponseContext(DbContextOptions<MovieResponseContext> options) : base(options)
        {
            // leave blank for now
        }

        public DbSet<MovieResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
            new Category { CategoryID = 1, CategoryName = "Action/Adventure" },
            new Category { CategoryID = 2, CategoryName = "Comedy" },
            new Category { CategoryID = 3, CategoryName = "Horror/Suspense" },
            new Category { CategoryID = 4, CategoryName = "Drama" },
            new Category { CategoryID = 5, CategoryName = "Family" },
            new Category { CategoryID = 6, CategoryName = "TV" },
            new Category { CategoryID = 7, CategoryName = "VHS" },
            new Category { CategoryID = 8, CategoryName = "Misc" }

            );
            mb.Entity<MovieResponse>().HasData(

                new MovieResponse
                {
                    MovieID = 1,
                    CategoryID = 1,
                    Title = "Back to the Future",
                    Year = 1985,
                    Director = "Robert Zemeckis",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },

                new MovieResponse
                {
                    MovieID = 2,
                    CategoryID = 2,
                    Title = "Hot Rod",
                    Year = 2007,
                    Director = "Akiva Schaffer",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },

                new MovieResponse
                {
                    MovieID = 3,
                    CategoryID = 2,
                    Title = "Hoodwinked!",
                    Year = 2005,
                    Director = "Cory Edwards",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },

                new MovieResponse
                {
                    MovieID = 4,
                    CategoryID = 2,
                    Title = "Hunt for the Wilderpeople",
                    Year = 2016,
                    Director = "Taika Waititi",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }


                );
            ;
        }

    }
}



