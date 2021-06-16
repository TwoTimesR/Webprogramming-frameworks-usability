using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Model
{
    [Table("Owner")]
    public class Owner
    {
        public Owner()
        {
        }

        [Column("Owner_Id")]
        public int OwnerId { get; set; }

        [StringLength(40)]
        public string FirstName { get; set; }

        [StringLength(40)]
        public string LastName { get; set; }

        public int Age { get; set; }


        //FK
        public int OrganisationId { get; set; }

        public Organisation Organisation { get; set; }
    }
}
