using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Validation.Models
{
	[Table("Student")]
	public class Student
	{
		public Student()
		{
		}

		[Column("Student_ID")]
		public int StudentID { get; set; }

		[Column("Voornaam")]
		[Required]
		[StringLength(80)]
		public string Voornaam { get; set; }

		[Column("Achternaam")]
		[StringLength(80)]
		[Required]
		public string Achternaam { get; set; }

		[Column("Woonplaats")]
		[Required]
		public string Woonplaats { get; set; }

		[Column("Email")]
		[EmailAddress]
		[StringLength(90)]
		[Required]
		public string Email { get; set; }

		[Column("Opleiding")]
		[StringLength(40)]
		[Required]
		public string Opleiding { get; set; }

		[Column("Studiepunten")]
		[Required]
		[Range(0, 240)]
		public int Studiepunten { get; set; }

		public ICollection<StudentVriend> StudentVrienden { get; set; }
	}
}
