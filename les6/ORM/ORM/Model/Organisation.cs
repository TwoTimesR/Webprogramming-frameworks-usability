using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Model
{
    [Table("Organisation")]
    public abstract class Organisation
    {
        public Organisation()
        {
        }

        [Column("Organisation_Id")]
        public int OrganisationId { get; set; }

        public string Name { get; set; }

        public int NetWorth { get; set; }

        public Owner Owner { get; set; }
    }
}
