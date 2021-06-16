using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Model
{
    [Table("CompanyCustomer")]
    public class CompanyCustomer
    {
        public CompanyCustomer()
        {
        }

        [Column("Organisation_Id")]
        public int OrganisationId { get; set; }

        public Company Company { get; set; }

        [Column("Customer_Id")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
