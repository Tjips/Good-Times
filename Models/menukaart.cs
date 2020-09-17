using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodTimes.Models
{
    public class menukaart
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        public List<categorie> categories { get; set; }
    }
}
