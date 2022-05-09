using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    class Student : Person
    {
        protected List<Book> Bought = new List<Book>();
        protected int C_bought = 0;
        protected List<Book> Borrow = new List<Book>();
        protected int C_borrow;


        public List<Book> bought
        {
            set { Bought = value; }
            get { return Bought; }
        }

        public int c_bought
        {
            set { C_bought = value; }
            get { return C_bought; }
        }

        public List<Book> borrow
        {
            set { Borrow = value; }
            get { return Borrow; }
        }

        public int c_borrow
        {
            set { C_borrow = value; }
            get { return C_borrow; }
        }
        public override string search(string target, List<Student> Student, List<Teacher> Teacher, int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (target == Student[i].name)
                {
                    return (Student[i].ToString() + "\nNumber of Borrowed Books: " + Student[i].c_borrow + "\nNumber of Boughted Books: " + Student[i].c_bought);
                }
            }
            return "Student not found";
        }
    }
}
