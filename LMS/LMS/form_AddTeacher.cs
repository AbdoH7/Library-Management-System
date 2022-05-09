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
    public partial class form_AddTeacher : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DCC28QQ\SQLEXPRESS;Initial Catalog=Library_Mangment_System;Integrated Security=True");
        SqlCommand cmd;
        string Query;
        public form_AddTeacher()
        {
            InitializeComponent();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Teacher a = new Teacher();
            a.name = textBox1.Text;
            a.id = Convert.ToInt32(textBox2.Text);
            a.dep = textBox3.Text;
            a.e_mail = textBox4.Text;
            Global.teacher.Add(a);


            con.Open();
            Query = @"insert into Teacher_Informations values('" + Global.c3 + "','" + a.name + "' ,'" + a.id + "','" + a.dep + "','" + a.e_mail + "','" + a.c_bought + "','" + a.c_borrow + "')";
            cmd = new SqlCommand(Query, con);
            cmd.ExecuteReader();
            con.Close();

            Global.c3++;



            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
