using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Models
{
    public class Student : IdentityUser
    {
        public Student() { }

        public int StudentId { get; set; }

        public string StudentNaam { get; set; }

        public List<ToetsResultaat> ToetsResultaten { get; set; }
    }
}
