using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Studentenlijst.Models;
using Studentenlijst.Data;
using Microsoft.EntityFrameworkCore;

namespace Studentenlijst.Controllers
{
    public class StudentController : Controller
    {
        private MijnContext context = new MijnContext(new DbContextOptionsBuilder<MijnContext>()
            .UseSqlite("Data Source=student.db")
            .Options);

        public StudentController(MijnContext context)
        {
            this.context = context;
        }

        private static int studentId;

        public ViewResult ZoekStudent(int id)
        {
            Student student = GetStudent(id);
            return View(student);
        }

        private Student GetStudent(int id)
        {
            Student result = null;
            foreach (Student student in LijstMetStudenten.GetInstance().lijst)
            {
                if (student.Id == id)
                {
                    result = student;
                    break;
                }
            }
            return result;
        }

        public ViewResult ZoekStudentName(string id) //id = voornaam
        {
            int namecount = GetNumberOfStudentsByName(id);
            ViewBag.Id = id;
            ViewBag.Namecount = namecount;
            return View();
        }

        private int GetNumberOfStudentsByName(string voornaam)
        {
            int aantal = LijstMetStudenten.GetInstance().lijst.FindAll(student => student.Voornaam == voornaam).Count();
            return aantal;
        }

        public ViewResult ZoekStudentLetter(char id) //id = letter
        {
            char letterUC = char.ToUpper(id);
            List<string> namen = GetStudentsByLetter(letterUC);
            ViewBag.Namen = namen;
            ViewBag.LetterUC = letterUC;
            return View();
        }

        private List<string> GetStudentsByLetter(char letterUC)
        {
            int letterPlace = 0;
            List<string> gevondenNamen = new List<string>();

            foreach (Student student in LijstMetStudenten.GetInstance().lijst)
            {
                char studentLetterUC = char.ToUpper(student.Voornaam[letterPlace]);
                if (studentLetterUC == letterUC)
                {
                    gevondenNamen.Add(student.Voornaam);
                }
            }
            return gevondenNamen;
        }

        public ViewResult NieuweStudent()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult NieuweStudent(string voornaam, string achternaam, string email)
        {
            int nieuwStudentId = LijstMetStudenten.GetInstance().lijst.Count();
            studentId = nieuwStudentId;
            Student student = new Student(nieuwStudentId, voornaam, achternaam, email);
            LijstMetStudenten.GetInstance().VoegStudent(student);
            return RedirectToAction("BevestigStudentgegevens", student);
        }

        public ViewResult WijzigStudent(int id) {
            studentId = id;
            Student student = GetStudent(studentId);
            return View(student); 
        }

        [HttpPost]
        public IActionResult WijzigStudent(string voornaam, string achternaam, string email)
        {
            Student student = GetStudent(studentId);
            if (voornaam != student.Voornaam)
            {
                student.Voornaam = voornaam;
            }
            if (achternaam != student.Achternaam)
            {
                student.Achternaam = achternaam;
            }
            if (email != student.Email)
            {
                student.Email = email;
            }
            return RedirectToAction("BevestigStudentgegevens", student);
        }
 
        public IActionResult BevestigStudentgegevens(Student student) {
            Student getStudent = GetStudent(student.Id);
            return View(getStudent);
        }
    }
}
