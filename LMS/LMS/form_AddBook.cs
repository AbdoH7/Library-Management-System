using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LMS
{
    public partial class form_AddBook : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DCC28QQ\SQLEXPRESS;Initial Catalog=Library_Mangment_System;Integrated Security=True");
        SqlCommand cmd;
        string Query;
        public form_AddBook()
        {
            InitializeComponent();
        }
        

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
           
            Book a = new Book();
            string x = textBox1.Text;
            int flag = 0;
            if(Global.c1!=0)
            {
                for (int i = 0; i < Global.c1; i++)
                {
                    if (x == Global.book[i].Name)
                    {
                        MessageBox.Show("This book is already in your inventory, "+ textBox6.Text + " copies of it was added succesfully ");
                        Global.book[i].Quantity += Convert.ToInt32(textBox6.Text);
                        Global.wallet -= (Global.book[i].purchase_price*Global.book[i].Quantity);
                        flag = 1;


                        con.Open();
                        Query = "update Book_Informations set Book_Quantity='"+Global.book[i].Quantity+"' where Id='" +i+"';";
                        cmd = new SqlCommand(Query, con);
                        cmd.ExecuteReader();
                        con.Close();



                        con.Open();
                        Query = "update Library_finance set Wallet='" + Global.wallet + "';";
                        cmd = new SqlCommand(Query, con);
                        cmd.ExecuteReader();
                        con.Close();


                    }
                }
            }
            
            if(flag==0)
            {
                a.Name = textBox1.Text;
                a.Author_name = textBox2.Text;
                a.Publication_date = textBox3.Text;
                a.purchase_price =Convert.ToDouble (textBox4.Text);
                a.Price = Convert.ToDouble(textBox5.Text);
                a.Quantity = Convert.ToInt32(textBox6.Text);
                a.Publisher = textBox7.Text;
                a.rent_price =Convert.ToDouble( textBox8.Text);
                if (radioButton1.Checked == true) a.state = 1;
                else if (radioButton2.Checked == true) a.state = 2;
                else if (radioButton3.Checked == true) a.state = 3;
                if (radioButton4.Checked == true) a.access = 1;
                else if (radioButton5.Checked == true) a.access = 2;
                Global.book.Add(a);
                Global.wallet -= (a.purchase_price * a.Quantity);

                con.Open();
                Query = @"insert into Book_Informations values('" + Global.c1 + "','" + a.Name + "','" + a.Author_name + "','" + a.Publication_date + "','" + a.Price + "','" + a.Quantity + "','" + a.Publisher + "','" + a.rent_price + "','" + a.purchase_price + "','" + a.state + "','" + a.access + "','" + a.borrow + "','" + a.bought + "')";
                cmd = new SqlCommand(Query, con);
                cmd.ExecuteReader();
                con.Close();

                con.Open();
                Query = "update Library_finance set Wallet='" + Global.wallet + "';";
                cmd = new SqlCommand(Query, con);
                cmd.ExecuteReader();
                con.Close();

                Global.c1++;
           

            }

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void form_AddBook_Load(object sender, EventArgs e)
        {

        }

       
    }
}
