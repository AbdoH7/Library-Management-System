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
    public partial class form_PurchasingT : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DCC28QQ\SQLEXPRESS;Initial Catalog=Library_Mangment_System;Integrated Security=True");
        SqlCommand cmd;
        string Query;
        public form_PurchasingT()
        {
            InitializeComponent();
        }

        private void form_PurchasingT_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string s_name, b_name;
            int check1 = 0, check2 = 0, i = 0, j = 0;
            s_name = textBox1.Text;
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
                if (s_name == Global.teacher[j].name)
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
                if (Global.book[i].state == 1)
                {
                    MessageBox.Show("Sorry, this book is for borrowing only");
                }
                else
                {
                    Global.teacher[j].bought.Add(Global.book[i]);
                    Global.teacher[j].c_bought++;
                    Global.book[i].bought++;
                    Global.book[i].Quantity--;
                    Global.wallet += Global.book[i].Price;


                    con.Open();
                    Query = @"insert into Teacher_Bought values('" + j + "','" + Global.book[i].Name + "','" + Global.book[i].Author_name + "','" + Global.book[i].Publication_date + "','" + Global.book[i].Publisher + "','" + Global.book[i].purchase_price + "','" + Global.book[i].state + "','" + Global.book[i].access + "')";
                    cmd = new SqlCommand(Query, con);
                    cmd.ExecuteReader();
                    con.Close();

                    con.Open();
                    Query = "update Library_finance set Wallet='" + Global.wallet + "';";
                    cmd = new SqlCommand(Query, con);
                    cmd.ExecuteReader();
                    con.Close();

                    con.Open();
                    Query = "update Book_Informations set Book_Quantity='" + Global.book[i].Quantity + "', no_of_Books_Boughted='" + Global.book[i].bought + "' where Id='"+i+"';";
                    cmd = new SqlCommand(Query, con);
                    cmd.ExecuteReader();
                    con.Close();

                    con.Open();
                    Query = "update Teacher_Informations set no_Bought='" + Global.teacher[j].c_bought + "' where Id='"+j+"';";
                    cmd = new SqlCommand(Query, con);
                    cmd.ExecuteReader();
                    con.Close();


                    MessageBox.Show("Book bought successfully");
                    textBox1.Clear();
                    textBox2.Clear();

                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
