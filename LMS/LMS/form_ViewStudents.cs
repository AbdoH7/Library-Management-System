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
    public partial class form_ViewStudents : Form
    {
        public form_ViewStudents()
        {
            InitializeComponent();
            show();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void show()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Student's Name");
            dt.Columns.Add("ID");
            dt.Columns.Add("E-Mail");
            dt.Columns.Add("Borrowed Books");


            for (int i = 0; i < Global.c2; i++)
            {

                dt.Rows.Add(Global.student[i].name, Global.student[i].id, Global.student[i].e_mail, Global.student[i].c_borrow);
                dataGridView1.DataSource = dt;
            }
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string target = textBox1.Text;
            MessageBox.Show(Global.student[0].search(target, Global.student, Global.teacher, Global.c2));
        }
    }
}
