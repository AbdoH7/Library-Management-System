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
    public partial class Sign_in : Form
    {
        public Sign_in()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int i = 0;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DCC28QQ\SQLEXPRESS;Initial Catalog=Library_Mangment_System;Integrated Security=True");
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Admin", con))
                {
                    con.Open();
                    using (SqlDataReader MyReader = cmd.ExecuteReader())
                    {

                        while (MyReader.Read())
                        {
                            IDataRecord record = (IDataRecord)MyReader;
                            if (textBox1.Text == record[1].ToString() && textBox2.Text == record[2].ToString())
                            { i = 1; }

                        }
                    }

                    if (i == 0)
                    {
                        MessageBox.Show("Uername or password is not correct");
                    }

                    else
                    {
                        this.Hide();
                        MainForm m = new MainForm();
                        m.Show();
                    }
                    con.Close();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
