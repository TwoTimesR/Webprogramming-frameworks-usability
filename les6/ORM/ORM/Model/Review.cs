using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ORM.Model
{
    [Table("Review")]
    public class Review
    {
        public Review()
        {
        }

        [Column("Review_Id")]
        public int ReviewId { get; set; }

        public string Description { get; set; }

        public double Rating { get; set; }


        //FK
        public int OrganisationId { get; set; }

        public int SequenceNumber { get; set; }

        public Product Product { get; set; }
    }
}
