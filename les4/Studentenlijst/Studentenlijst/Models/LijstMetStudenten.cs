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
            lijst.Add(new Student(0, "Bob", "Bobsen", "BobBosen@outlook.com"));
            lijst.Add(new Student(1, "Jan", "Jansen", "JanJansen@outlook.com"));
            lijst.Add(new Student(2, "Peter", "Petersen", "Peter_Petersen@outlook.com"));
            lijst.Add(new Student(3, "Bernard", "Bernardsen", "BernardBernardsen@outlook.com"));
            lijst.Add(new Student(4, "Bob", "Bobsen", "BobBobsen@outlook.com"));
            lijst.Add(new Student(5, "Geert", "Geertsen", "GeertGeertsen@outlook.com"));
            lijst.Add(new Student(6, "Gerard", "Gerardsen", "GerardGerardsen@outlook.com"));
            lijst.Add(new Student(7, "Jeroen", "Jeroensen", "JeroenJeroensen@outlook.com"));
            lijst.Add(new Student(8, "Kees", "Keessen", "KeesKeessen@outlook.com"));

        }

        public void VoegStudent(Student student) {
            lijst.Add(student);
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
