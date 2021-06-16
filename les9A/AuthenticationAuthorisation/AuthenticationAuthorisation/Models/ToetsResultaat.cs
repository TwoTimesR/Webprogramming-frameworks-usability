using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAuthorisation.Models
{
    public class ToetsResultaat
    {
        public ToetsResultaat() { }

        [Key]
        public int Id { get; set; }

        public string StudentNaam { get; set; }

        public int Cijfer { get; set; }
    }
}
