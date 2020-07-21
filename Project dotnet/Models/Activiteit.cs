using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_dotnet.Models
{
    public class Activiteit
    {
        [Key]
        public int Id { get; set; }

        public string Naam { get; set; }
        public DateTime Date { get; set; }
        public string Eenheid { get; set; }
        public ICollection<Wedstrijd> Wedstrijden { get; set; }
        public ICollection<Training> Trainingen { get; set; }

        public void updateActiviteit(Activiteit activiteit)
        {
            Naam = activiteit.Naam;
            Date = activiteit.Date;
            Eenheid = activiteit.Eenheid;
        }
    }
}
