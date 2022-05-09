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
    public partial class form_ViewTeachers : Form
    {
        public form_ViewTeachers()
        {
            InitializeComponent();
            show();
        }
        private void show()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Teacher's Name");
            dt.Columns.Add("ID");
            dt.Columns.Add("E-Mail");
            dt.Columns.Add("Borrowed Books");


            for (int i = 0; i < Global.c3; i++)
            {

                dt.Rows.Add(Global.teacher[i].name, Global.teacher[i].id, Global.teacher[i].e_mail, Global.teacher[i].c_borrow);
                dataGridView1.DataSource = dt;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string target = textBox1.Text;
            MessageBox.Show(Global.teacher[0].search(target, Global.student,Global.teacher, Global.c3));
        }
    }
}
