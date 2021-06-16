using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Model
{
	[Table("Customer")]
	public class Customer
	{
		public Customer()
		{
		}

		[Column("Customer_Id")]
		public int CustomerId { get; set; }

		public double AvgSpending { get; set; }

		public int PurchaseMade { get; set; }

		public ICollection<CompanyCustomer> CompanyCustomers { get; set; }
	}
}
