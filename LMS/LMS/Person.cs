using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    abstract class Person
    {
        protected string Name;
        protected int ID;
        protected string E_mail;
        protected string DEP;

        
        public string name
        {
            set { Name = value; }
            get { return Name; }
        }

        public int id
        {
            set { ID = value; }
            get { return ID; }
        }

        public string e_mail
        {
            set { E_mail = value; }
            get { return E_mail; }
        }

        public string dep
        {
            set { DEP = value; }
            get { return DEP; }
        }




        public abstract string search(string target, List<Student> Student, List<Teacher> Teacher, int size);
        public override string ToString()
        {
            return "Name: " + Name + "\n" + "ID: " + ID + "\n" + "E-Mail: " + E_mail + "\n" + "Department: " + DEP;
        }
    }
}
