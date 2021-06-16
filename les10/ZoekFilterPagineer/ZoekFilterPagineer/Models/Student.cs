using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZoekFilterPagineer.Models
{
    public class Student
    {
        public Student(){}

        [Key]
        public int StudentId { get; set; }

        public string StudentNaam { get; set; }

        public int Lengte { get; set; }


        public IList<StudentCursus> StudentCursus { get; set; }
    }
}