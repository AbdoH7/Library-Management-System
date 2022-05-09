using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class form_Info : Form
    {
        public form_Info()
        {
            InitializeComponent();
            show();
        }
        private void show()
        {
            richTextBox1.AppendText("This program was designed and developed by Abdulrahman Hussein and Fady Samy as a part of the requirements for the CC319 Advanced Programing course\n\nThis program is submitted to Dr.Karma Fathallah and Eng.Noha Sobhi.\n\nThe program runs several complex library operations and maintains them such as new purchases to the inventory, selling books, borrowing books, adding new students and teachers, handling the finance of the library and many other operations.\n\nThe data entered by the librarian is saved in a data base and recalled upon further runs of the program.");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
