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
    public partial class form_BorrowT : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DCC28QQ\SQLEXPRESS;Initial Catalog=Library_Mangment_System;Integrated Security=True");
        SqlCommand cmd;
        string Query;
        public form_BorrowT()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string t_name, b_name;
            int check1 = 0, check2 = 0, i = 0, j = 0;
            t_name = textBox1.Text;
            b_name = textBox2.Text;
            for (i = 0; i < Global.c1; i++)
            {
                if (b_name == Global.book[i].Name)
                {
                    check2 = 1;
                    break;
                }
            }
            for (j = 0; j < Global.c3; j++)
            {
                if (t_name == Global.teacher[j].name)
                {
                    check1 = 1;
                    break;
                }
            }
            if (check1 == 0 && check2 == 0)
                MessageBox.Show("Invalid student's name, and book's name");
            else if (check1 == 0)
                MessageBox.Show("Invalid student's name");
            else if (check2 == 0)
                MessageBox.Show("Invalid book's name");
            else
            {
                int flag = 0;
                for (int z = 0; z < Global.teacher[j].c_borrow; z++)
                {
                    if (b_name == Global.teacher[j].borrow[z].Name)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    if (Global.book[i].state == 2)
                    {
                        MessageBox.Show("Sorry, this book is for purchasing only");
                    }
                    else
                    {
                        Global.teacher[j].borrow.Add(Global.book[i]);
                        Global.teacher[j].c_borrow++;
                        Global.book[i].borrow++;
                        Global.wallet += Global.book[i].rent_price;


                        con.Open();
                        Query = @"insert into Teacher_Borrow values('" + j + "','" + Global.book[i].Name + "','" + Global.book[i].Author_name + "','" + Global.book[i].Publication_date + "','" + Global.book[i].Publisher + "','" + Global.book[i].rent_price + "','" + Global.book[i].state + "','" + Global.book[i].access + "')";
                        cmd = new SqlCommand(Query, con);
                        cmd.ExecuteReader();
                        con.Close();

                        con.Open();
                        Query = "update Teacher_Informations set no_Borrow='" + Global.teacher[j].c_borrow + "' where Id= '"+j+"';";
                        cmd = new SqlCommand(Query, con);
                        cmd.ExecuteReader();
                        con.Close();

                        con.Open();
                        Query = "update Book_Informations set no_of_Books_Borrowed='" + Global.book[i].borrow + "', Rent_price='" + Global.book[i].rent_price + "' where Id= '"+i+"';";
                        cmd = new SqlCommand(Query, con);
                        cmd.ExecuteReader();
                        con.Close();

                        con.Open();
                        Query = "update Library_finance set Wallet='" + Global.wallet + "';";
                        cmd = new SqlCommand(Query, con);
                        cmd.ExecuteReader();
                        con.Close();

                        MessageBox.Show("Book borrowed successfully");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
                else MessageBox.Show("Sorry, You can't borrow the same book more than once");

            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
