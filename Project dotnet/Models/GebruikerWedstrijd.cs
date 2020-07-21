using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_dotnet.Models
{
    public class GebruikerWedstrijd
    {
        [Key]
        public int Id { get; set; }
        public string GebruikerId { get; set; }
        public int WedstrijdId { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public Wedstrijd Wedstrijd { get; set; }
    }
}
