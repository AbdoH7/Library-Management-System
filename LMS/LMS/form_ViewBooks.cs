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
    public partial class form_ViewBooks : Form
    {
        public form_ViewBooks()
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
            dt.Columns.Add("Book's Name");
            dt.Columns.Add("Author's Name");
            dt.Columns.Add("Purchasing Price");
            dt.Columns.Add("Rent Price");


            for (int i = 0; i < Global.c1; i++)
            {

                dt.Rows.Add(Global.book[i].Name, Global.book[i].Author_name ,Global.book[i].Price, Global.book[i].rent_price);
                dataGridView1.DataSource = dt;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string target = textBox1.Text;
            MessageBox.Show(Book.Search(target, Global.book, Global.c1));
        }
    }
}
