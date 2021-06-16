using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentenlijst.Models
{
    public class Student
    {
        private int id;
        private string voornaam;
        private string achternaam;
        private string email;

        public Student() { }

        public Student(int id, string voornaam, string achternaam, string email)
        {
            this.id = id;
            this.voornaam = voornaam;
            this.achternaam = achternaam;
            this.email = email;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Voornaam
        {
            get { return voornaam; }
            set { voornaam = value; }
        }

        public string Achternaam
        {
            get { return achternaam; }
            set { achternaam = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
