using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Project_dotnet.Models
{
    public class Gebruiker : IdentityUser
    {
        [Required]
        [PersonalData]
        public string Voornaam { get; set; }
        [Required]
        [PersonalData]
        public string Achternaam { get; set; }
        [PersonalData]
        public string Stad { get; set; }
        [PersonalData]
        public string Postcode { get; set; }
        [PersonalData]
        public string Straat { get; set; }
        [PersonalData]
        public string Huisnummer { get; set; }
        [PersonalData]
        public string Bus { get; set; }
        [PersonalData]
        [AllowNull]
        public string TelefoonNummer { get; set; }
        public bool IsCoach { get; set; }
        [NotMapped]
        public string Token { get; set; }
        public ICollection<Training> Trainingen { get; set; }
        public ICollection<GebruikerWedstrijd> Wedstrijden { get; set; }
    }
}
