using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodTimes.Models
{
    public class categorie
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        public menukaart menukaart { get; set; }
        public int MenukaartId { get; set; }
        public int volgeorde { get; set; }
        public List<product> products { get; set; }
    }
}
