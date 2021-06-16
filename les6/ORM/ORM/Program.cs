using System;
using ORM.Model;
using System.Linq;
using static ORM.Model.Database;

namespace ORM
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var db = new OrganisationContext())
			{
				//insert data - Company and Nonprofit

				/*db.Add(new Company { Name = "Deloitte BV", NetWorth = 600000, StockPrice = 12.99, Solvability = 30.25 });
				db.Add(new Company { Name = "Shell NV", NetWorth = 900000, StockPrice = 14.63, Solvability = 65.51 });
				db.Add(new Company { Name = "HHS", NetWorth = 0, StockPrice = -2.01, Solvability = 99.99 });
				db.Add(new NonProfit { Name = "Unichef", NetWorth = 200000, Goal = "End world hunger", Category = "Human rights" });
				db.Add(new NonProfit { Name = "Rode Kruis", NetWorth = 150000, Goal = "helping people", Category = "World peace" });
				db.SaveChanges();
				Console.WriteLine("Successfull insert");*/




				//insert data - Owner

				/*db.Add(new Owner { FirstName = "Kees", LastName = "van Helden ", Age = 18, OrganisationId = 7 });
				db.Add(new Owner { FirstName = "Henk", LastName = "Overbos ", Age = 21, OrganisationId = 8 });
				db.Add(new Owner { FirstName = "Jan", LastName = "de Fries ", Age = 86, OrganisationId = 9 });
				db.Add(new Owner { FirstName = "Klaas", LastName = "de Vries ", Age = 52, OrganisationId = 10 });
				db.Add(new Owner { FirstName = "Bob", LastName = "Naaktgeboren ", Age = 6, OrganisationId = 11 });
				db.SaveChanges();
				Console.WriteLine("Successfull insert");*/




				//insert data - Product

				/*db.Add(new Product { SequenceNumber = 51, Name = "financial advice", Price = 87.99, InStock = true, OrganisationId = 7 });
				db.Add(new Product { SequenceNumber = 73, Name = "gasoline", Price = 91.32, InStock = false, OrganisationId = 8 });
				db.Add(new Product { SequenceNumber = 81, Name = "oil", Price = 66.77, InStock = true, OrganisationId = 8 });
				db.Add(new Product { SequenceNumber = 105, Name = "electricity", Price = 12.45, InStock = true, OrganisationId = 8 });
				db.Add(new Product { SequenceNumber = 121, Name = "headache", Price = 0, InStock = true, OrganisationId = 9 });
				db.SaveChanges();
				Console.WriteLine("Successfull insert");*/




				//insert data - Review

				/*db.Add(new Review { Description = "Made me rich", Rating = 9.9, OrganisationId = 7, SequenceNumber = 51 });
				db.Add(new Review { Description = "I dont think this is legal", Rating = 7.7, OrganisationId = 7, SequenceNumber = 51 });
				db.Add(new Review { Description = "Lost my house and wife", Rating = 1.2, OrganisationId = 7, SequenceNumber = 51 });
				db.SaveChanges();
				Console.WriteLine("Successfull insert");*/




				//insert data - Customers

				/*db.Add(new Customer { AvgSpending = 47.99, PurchaseMade = 2});
				db.Add(new Customer { AvgSpending = 200.15, PurchaseMade = 7 });
				db.Add(new Customer { AvgSpending = 15.45, PurchaseMade = 1 });
				db.Add(new Customer { AvgSpending = 102.77, PurchaseMade = 5 });
				db.Add(new Customer { AvgSpending = 81.55, PurchaseMade = 3 });
				db.SaveChanges();
				Console.WriteLine("Successfull insert");*/




				//insert data - CompanyCustomer

				/*db.Add(new CompanyCustomer { OrganisationId = 7, CustomerId = 1 });
				db.Add(new CompanyCustomer { OrganisationId = 9, CustomerId = 1 });
				db.Add(new CompanyCustomer { OrganisationId = 7, CustomerId = 2 });
				db.Add(new CompanyCustomer { OrganisationId = 8, CustomerId = 2 });
				db.Add(new CompanyCustomer { OrganisationId = 9, CustomerId = 3 });
				db.Add(new CompanyCustomer { OrganisationId = 7, CustomerId = 4 });
				db.Add(new CompanyCustomer { OrganisationId = 8, CustomerId = 4 });
				db.Add(new CompanyCustomer { OrganisationId = 9, CustomerId = 4 });
				db.Add(new CompanyCustomer { OrganisationId = 8, CustomerId = 5 });
				db.SaveChanges();
				Console.WriteLine("Successfull insert");*/
			}
		}
	}
}
