using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodTimes.Models
{
    public class reservering
    {
        public int reserveringsID { get; set; }
        public string voornaam { get; set; }
        public string achternaam { get; set; }
        public string email { get; set; }
        public string telefoon { get; set; }
        public string opmerking { get; set; }
        public DateTime datum { get; set; }
        public string begintijd { get; set; }
        public string eindtijd { get; set; }
    }
}
