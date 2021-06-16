using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Validation.Models
{
	[Table("StudentVriend")]
	public class StudentVriend
	{
		public StudentVriend()
		{
		}

		[Column("Student_ID")]
		public int StudentID { get; set; }

		[Column("Vriend_ID")]
		public int VriendID { get; set; }

		public Student Student { get; set; }
	}
}
