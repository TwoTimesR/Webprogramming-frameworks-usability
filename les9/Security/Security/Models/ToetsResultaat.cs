using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Models
{
    public class ToetsResultaat
    {
        public ToetsResultaat() { }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public DateTime Datum { get; set; } = new DateTime().Date;

        public int Cijfer { get; set; }

        public int DocentId { get; set; }

        public Docent Docent { get; set; }
    }
}
