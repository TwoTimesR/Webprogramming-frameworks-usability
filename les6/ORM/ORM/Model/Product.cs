using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ORM.Model
{
	[Table("Product")]
	public class Product
	{
		public Product()
		{
		}

		public int SequenceNumber { get; set; }

		public string Name { get; set; }

		public double Price { get; set; }

		public bool InStock { get; set; }

		public List<Review> Reviews { get; set; }


		//FK
		public int OrganisationId { get; set; }

		public Company Company { get; set; }
	}
}
