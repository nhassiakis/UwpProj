using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjUWP.Models
{
    public class Joke
    {

        public Joke()
        {
            type = string.Empty;
            joke = string.Empty;
            setup = string.Empty;
            delivery = string.Empty;
        }
        public string type { get; set; }
        public string joke { get; set; }
        public string setup { get; set; }
        public string delivery { get; set; }
        public int id { get; set; }
        public Flags flags { get; set; }
    }
}
