using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZoekFilterPagineer.Models
{
    public class Cursus
    {
        public Cursus(){}

        [Key]
        public int CursusId { get; set; }

        public string CursusNaam { get; set; }

        public IList<StudentCursus> StudentCursus { get; set; }
    }
}
