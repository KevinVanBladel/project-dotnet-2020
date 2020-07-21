using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Project_dotnet.Models
{
    public class Training
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Naam { get; set; }
        [AllowNull]
        public string Locatie { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? Hoeveelheid { get; set; }
        [AllowNull]
        public string GebruikerId { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public int? ActiviteitId { get; set; }
        public Activiteit Activiteit { get; set; }

        public void updateTraining(Training training)
        {
            Naam = training.Naam;
            Locatie = training.Locatie;
            Hoeveelheid = training.Hoeveelheid;
            GebruikerId = training.GebruikerId;
            ActiviteitId = training.ActiviteitId;
        }
    }
}
