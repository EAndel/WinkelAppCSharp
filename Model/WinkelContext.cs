using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinkelApp.Model
{
    public class WinkelContext : DbContext
    {
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=WinkelDb;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Auteur>().HasData(
                new Auteur
                {
                    id = 1,
                    Firstname = "Henk",
                    Lastname = "Bersen",
                    Phonenumber = 0612459246,
                    Email = "HBersen@Winkel.nl"
                },
                new Auteur
                {
                    id = 2,
                    Firstname = "Lisa",
                    Lastname = "Jansen",
                    Phonenumber = 0651234943,
                    Email = "LJansen@Winkel.nl"
                }
            );

            builder.Entity<Item>().HasData(
                new Item
                {
                    id = 1,
                    Name = "Honden knuffel",
                    Price = 10.00,
                    Description = "Een knuffel die er uitziet als een hond",
                    Auteurid = 1
                },
                new Item
                {
                    id = 2,
                    Name = "Katten knuffel",
                    Price = 10.00,
                    Description = "Een knuffel die er uitziet als een kat",
                    Auteurid = 1
                },
                new Item
                {
                    id = 3,
                    Name = "Houten boot",
                    Price = 15.00,
                    Description = "Een kleine boot gemaakt van hout",
                    Auteurid = 2
                }
                ); ;
        }
    }
}
