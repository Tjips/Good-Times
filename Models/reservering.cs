using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodTimes.Models
{
    public class reservering
    {
        public int Id { get; set; }
        [Required]
        public string voornaam { get; set; }
        [Required]
        public string achternaam { get; set; }
        [Required]
        public int aantal { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string telefoon { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime datum { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan begintijd { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan eindtijd { get; set; }
        public DateTime aangemaakt { get; set; }
        [DataType(DataType.MultilineText)]
        public string opmerking { get; set; }


        public string medewerkerId { get; set; }
        public IdentityUser medewerker { get; set; }
    }
}
