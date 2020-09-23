using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodTimes.Models
{
    public class bestelling
    {
        public int Id { get; set; }
        [Required]
        public string Gerecht { get; set; }
        public int Aantal { get; set; }
        [Required]
        public int Tafel { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan Tijd { get; set; }
        [DataType(DataType.MultilineText)]
        public string Opmerking { get; set; }
        public bool Acties { get; set; }
        public List<product> Products { get; set; }
    }
}
