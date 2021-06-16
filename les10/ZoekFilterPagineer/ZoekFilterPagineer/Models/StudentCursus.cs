using System;
namespace ZoekFilterPagineer.Models
{
    public class StudentCursus
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CursusId { get; set; }
        public Cursus Cursus { get; set; }
    }
}
