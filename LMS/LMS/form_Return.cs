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
    public partial class form_Return : Form
    {
        string Query;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DCC28QQ\SQLEXPRESS;Initial Catalog=Library_Mangment_System;Integrated Security=True");
        SqlCommand cmd = new SqlCommand(); 
        public form_Return()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                int flag = 0;
                for (int i = 0; i < Global.c3; i++)
                {
                    if (Global.teacher[i].name == textBox1.Text)
                    {
                        for (int j = 0; j < Global.teacher[i].c_borrow; j++)
                        {
                            if (Global.teacher[i].borrow[j].Name == textBox2.Text)
                            {
                                Global.teacher[i].c_borrow--;
                                Global.teacher[i].borrow.RemoveAt(j);

                                con.Open();
                                Query = "update Teacher_Informations set no_Borrow='" + Global.teacher[i].c_borrow + "' where Id='" + i + "';";
                                cmd = new SqlCommand(Query, con);
                                cmd.ExecuteReader();
                                con.Close();

                                for (int z = 0; z < Global.c1; z++)
                                {
                                    if (textBox2.Text == Global.book[z].Name)
                                    {
                                        Global.book[z].borrow--;

                                        con.Open();
                                        Query = "update Book_Informations set no_of_Books_Borrowed='" + Global.book[z].borrow + "' where Id='" + z + "';";
                                        cmd = new SqlCommand(Query, con);
                                        cmd.ExecuteReader();
                                        con.Close();



                                        con.Open();
                                        Query = "delete from Teacher_Borrow where id='" + i + "' and Book_Name='" + Global.book[z].Name + "'";
                                        cmd = new SqlCommand(Query, con);
                                        cmd.ExecuteReader();
                                        con.Close();
                                        

                                        break;
                                    }

                                }
                                flag = 1;

                            }
                        }
                    }
                }
                if (flag == 1) MessageBox.Show("Book returned to the library successfully");
                else MessageBox.Show("operation failed");
                textBox1.Clear();
                textBox2.Clear();
            }
            else if (radioButton2.Checked == true)
            {
                int flag = 0;
                for (int i = 0; i < Global.c2; i++)
                {
                    if (Global.student[i].name == textBox1.Text)
                    {
                        for (int j = 0; j < Global.student[i].c_borrow; j++)
                        {
                            if (Global.student[i].borrow[j].Name == textBox2.Text)
                            {
                                Global.student[i].c_borrow--;
                                Global.student[i].borrow.RemoveAt(j);

                                con.Open();
                                Query = "update Students_Informations set no_Borrow='" + Global.student[i].c_borrow + "' where Id='" + i + "';";
                                cmd = new SqlCommand(Query, con);
                                cmd.ExecuteReader();
                                con.Close();

                                for (int z = 0; z < Global.c1; z++)
                                {
                                    if (textBox2.Text == Global.book[z].Name)
                                    {
                                        Global.book[z].borrow--;

                                        con.Open();
                                        Query = "update Book_Informations set no_of_Books_Borrowed='" + Global.book[z].borrow + "' where Id='" + z + "';";
                                        cmd = new SqlCommand(Query, con);
                                        cmd.ExecuteReader();
                                        con.Close();


                                        con.Open();
                                        Query = "delete from Student_Borrow where id='" + i + "' and Book_Name='" + Global.book[z].Name + "'; ";
                                        cmd = new SqlCommand(Query, con);
                                        cmd.ExecuteReader();
                                        con.Close();


                                        break;
                                    }

                                }
                                flag = 1;

                            }
                        }
                    }
                }
                if (flag == 1) MessageBox.Show("Book returned to the library successfully");
                else MessageBox.Show("operation failed");
                textBox1.Clear();
                textBox2.Clear();
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}