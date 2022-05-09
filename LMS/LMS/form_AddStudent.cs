using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LMS
{
    public partial class form_AddStudent : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DCC28QQ\SQLEXPRESS;Initial Catalog=Library_Mangment_System;Integrated Security=True");
        SqlCommand cmd;
        string Query;
        public form_AddStudent()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Student a = new Student();
            a.name = textBox1.Text;
            a.id = Convert.ToInt32(textBox2.Text);
            a.dep = textBox3.Text;
            a.e_mail = textBox4.Text;
            Global.student.Add(a);

            con.Open();
            Query = @"insert into Students_Informations values('" + Global.c2 + "','" + a.name + "' ,'" + a.id + "','" + a.dep + "','" + a.e_mail + "','" + a.c_bought + "','" + a.c_borrow + "')";
            cmd = new SqlCommand(Query, con);
            cmd.ExecuteReader();
            con.Close();

            Global.c2++;


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

       
    }
}
