using Studentenlijst.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace Studentenlijst.Models
{
	public class LijstMetStudenten
	{
		private static LijstMetStudenten instance = null;

		public List<Student> lijst = null;

		private LijstMetStudenten() {

			//niet verwijderen, nodig voor ZoekStudentLetter en ZoekStudentName als resultaat

			lijst = new List<Student>();
			lijst.Add(new Student(87, "Bob", "Bobsen", "BobBosen@outlook.com"));
			lijst.Add(new Student(88, "Jan", "Jansen", "JanJansen@outlook.com"));
			lijst.Add(new Student(89, "Peter", "Petersen", "Peter_Petersen@outlook.com"));
			lijst.Add(new Student(90, "Bernard", "Bernardsen", "BernardBernardsen@outlook.com"));
			lijst.Add(new Student(91, "Bob", "Bobsen", "BobBobsen@outlook.com"));
			lijst.Add(new Student(92, "Geert", "Geertsen", "GeertGeertsen@outlook.com"));
			lijst.Add(new Student(93, "Gerard", "Gerardsen", "GerardGerardsen@outlook.com"));
			lijst.Add(new Student(94, "Jeroen", "Jeroensen", "JeroenJeroensen@outlook.com"));
			lijst.Add(new Student(95, "Kees", "Keessen", "KeesKeessen@outlook.com"));
		}

		public void VoegStudent(Student student) {
			lijst.Add(student);
		}

		public void WijzigStudent(Student student)
		{
			Student editStudent = lijst.Where(student => student.Id == student.Id).First();
			editStudent = student;
		}

		public static LijstMetStudenten GetInstance() {
			if (instance == null)
			{
				instance = new LijstMetStudenten();
			}
			return instance;
		}
	}
}
