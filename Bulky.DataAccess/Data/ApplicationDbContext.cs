using Bulky.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Produit> Produits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Produit>().HasData(
                new Produit
                {
                    Id = 1,
                    Titre = "Fortune of Time",
                    Auteur = "Billy Spark",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    ListePrix = 99,
                    Prix = 90,
                    Prix50 = 85,
                    Prix100 = 80,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Produit
                {
                    Id = 2,
                    Titre = "Dark Skies",
                    Auteur = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    ListePrix = 40,
                    Prix = 30,
                    Prix50 = 25,
                    Prix100 = 20,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Produit
                {
                    Id = 3,
                    Titre = "Vanish in the Sunset",
                    Auteur = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    ListePrix = 55,
                    Prix = 50,
                    Prix50 = 40,
                    Prix100 = 35,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Produit
                {
                    Id = 4,
                    Titre = "Cotton Candy",
                    Auteur = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    ListePrix = 70,
                    Prix = 65,
                    Prix50 = 60,
                    Prix100 = 55,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Produit
                {
                    Id = 5,
                    Titre = "Rock in the Ocean",
                    Auteur = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    ListePrix = 30,
                    Prix = 27,
                    Prix50 = 25,
                    Prix100 = 20,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Produit
                {
                    Id = 6,
                    Titre = "Leaves and Wonders",
                    Auteur = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    ListePrix = 25,
                    Prix = 23,
                    Prix50 = 22,
                    Prix100 = 20,
                    CategoryId = 3,
                    ImageUrl = ""
                }

                );
        }
    }
}