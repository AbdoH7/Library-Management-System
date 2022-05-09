using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    class Teacher : Person
    {
        protected List<Book> Bought = new List<Book>();
        protected List<Book> Borrow = new List<Book>();
        protected int C_bought = 0;
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



            public override string search(string target, List<Student> Student, List<Teacher> teacher, int size)
            {
                for (int i = 0; i < size; i++)
                {
                    if (target == teacher[i].name)
                    {
                        return (teacher[i].ToString()+"\nNumber of Borrowed Books: " + teacher[i].c_borrow + "\nNumber of Boughted Books: " + teacher[i].c_bought);
                    }
                }
                return "Teacher not found";
            }
        
    }
}
