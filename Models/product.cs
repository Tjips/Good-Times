using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GoodTimes.Models
{
    public class product
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Omschrijving { get; set; }
        [Required]
        public float Prijs { get; set; }
        public int Volgorde { get; set; }
        public categorie categorie { get; set; }
        public int categorieId { get; set; }
        public bestelling bestelling { get; set; }
    }
}
