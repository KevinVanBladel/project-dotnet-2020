using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Project_dotnet.Models
{
    public class Wedstrijd
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? Hoeveelheid { get; set; }
        public int? ActiviteitId { get; set; }
        public Activiteit Activiteit { get; set; }
        public ICollection<GebruikerWedstrijd> Gebruikers { get; set; }

        public void updateWedstrijd(Wedstrijd wedstrijd)
        {
            Naam = wedstrijd.Naam;
            Date = wedstrijd.Date;
            Hoeveelheid = wedstrijd.Hoeveelheid;
            ActiviteitId = wedstrijd.ActiviteitId;
        }
    }
}
