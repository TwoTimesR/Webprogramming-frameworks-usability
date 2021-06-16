using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Model
{
    [Table("Company")]
    public class Company : Organisation
    {
        public Company() : base()
        {
        }

        public double StockPrice { get; set; }

        public double Solvability { get; set; }

        [NotMapped]
        public int AmountOfStocks
        {
            get
            {
                return (int)(NetWorth / StockPrice);
            }
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public ICollection<CompanyCustomer> CompanyCustomers { get; set; }
    }
}
