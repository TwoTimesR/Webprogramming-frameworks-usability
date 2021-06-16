using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Models
{
    public class Docent : IdentityUser
    {
        public Docent() { }

        public int DocentId { get; set; }

        public string DocentNaam { get; set; }

        public List<ToetsResultaat> ToetsResultaten { get; set; }
    }
}
