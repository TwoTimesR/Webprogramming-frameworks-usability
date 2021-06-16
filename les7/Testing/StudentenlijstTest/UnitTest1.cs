using System;
using Xunit;
using Studentenlijst.Controllers;
using Studentenlijst.Data;
using Microsoft.EntityFrameworkCore;
using Studentenlijst.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace StudentenlijstTest
{
	public class UnitTest1
	{
		[Fact]
		public void Test1() {
			var options = new DbContextOptionsBuilder<MijnContext>()
			.UseInMemoryDatabase("studenttest")
			.Options;
			var testDb = new MijnContext(options);

			testDb.Studenten.Add(new Student { Id = 127, Voornaam = "Bart", Achternaam = "Simpson ", Email = "BartSimpson@outlook.com" });
			testDb.Studenten.Add(new Student { Id = 128, Voornaam = "Margaret", Achternaam = "Simpson ", Email = "MargaretSimpson@outlook.com" });
			testDb.Studenten.Add(new Student { Id = 129, Voornaam = "Lisa", Achternaam = "Simpson ", Email = "LisaSimpson@outlook.com" });
			testDb.Studenten.Add(new Student { Id = 130, Voornaam = "Homer", Achternaam = "Simpson ", Email = "HomerSimpson@outlook.com" });
			testDb.Studenten.Add(new Student { Id = 131, Voornaam = "Maggie", Achternaam = "Simpson ", Email = "MaggieSimpson@outlook.com" });
			testDb.SaveChanges();
			Console.WriteLine("Simpsons added");

			var totalAmount = testDb.Studenten.Count();
			Assert.Equal(5, totalAmount);

			var s131 = testDb.Studenten.Where(s => s.Id == 131).Single();
			testDb.Studenten.Remove(s131);
			testDb.SaveChanges();
			Console.WriteLine($"{s131.Voornaam} {s131.Achternaam} removed");

			totalAmount = testDb.Studenten.Count();
			Assert.Equal(4, totalAmount);
		}

        [Fact]
        public void Test2() {
			var options = new DbContextOptionsBuilder<MijnContext>()
			.UseInMemoryDatabase("studenttest")
			.Options;
			var testDb = new MijnContext(options);
			StudentController sc = new StudentController(testDb);

			var student = LijstMetStudenten.GetInstance().lijst[0].Id;
			sc.ZoekStudent(student);
			Assert.Equal(87, student);
		}

		[Fact]
		public void Test3() {
			var options = new DbContextOptionsBuilder<MijnContext>()
			.UseInMemoryDatabase("studenttest")
			.Options;
			var testDb = new MijnContext(options);
			StudentController sc = new StudentController(testDb);

			Assert.IsType<ViewResult>(sc.WijzigStudent(87));

			char letter = char.Parse("B");
			Assert.IsType<ViewResult>(sc.ZoekStudentLetter(letter));
		}

		[Fact]
		public void Test4() {

			Student student = new Student(96, "Hans", "Heet", "HansHeet@Hotmail.com");
			LijstMetStudenten.GetInstance().VoegStudent(student);

			Assert.Equal(student, LijstMetStudenten.GetInstance().lijst.Last());
		}

		[Fact]
		public void Test5() {

			Student student = new Student(96, "Hans", "Heet", "HansHeet@Hotmail.com");
			LijstMetStudenten.GetInstance().VoegStudent(student);

			Assert.Equal(student, LijstMetStudenten.GetInstance().lijst.Last());

			Console.WriteLine($"{student.Id} {student.Voornaam} Not Changed");

			student.Voornaam = "Piet";
			LijstMetStudenten.GetInstance().WijzigStudent(student);
			Console.WriteLine($"{student.Id} {student.Voornaam} Changed");
		}
	}
}
