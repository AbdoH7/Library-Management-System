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
    public partial class form_Wallet : Form
    {
        public form_Wallet()
        {
            InitializeComponent();
            textBox1.AppendText(Global.wallet.ToString()+" $");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
