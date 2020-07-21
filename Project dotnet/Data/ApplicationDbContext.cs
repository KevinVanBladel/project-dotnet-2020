using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_dotnet.Models;

namespace Project_dotnet.Data
{
    public class ApplicationDbContext : IdentityDbContext<Gebruiker>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Activiteit> Activiteiten { get; set; }
        public DbSet<Wedstrijd> Wedstrijden { get; set; }
        public DbSet<Training> Trainingen { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Gebruiker>().ToTable("Gebruiker");
            builder.Entity<Activiteit>().ToTable("Activiteit");
            builder.Entity<Wedstrijd>().ToTable("Wedstrijd");
            builder.Entity<Training>().ToTable("Training");
            builder.Entity<GebruikerWedstrijd>().ToTable("GebruikerWedstrijd");
        }
    }
}
