using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LMS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            hidePanels();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DCC28QQ\SQLEXPRESS;Initial Catalog=Library_Mangment_System;Integrated Security=True");
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Book_Informations", con))
                {
                    con.Open();
                    using (SqlDataReader MyReader = cmd.ExecuteReader())
                    {

                        while (MyReader.Read())
                        {
                            IDataRecord record = (IDataRecord)MyReader;

                            Book a = new Book();
                            a.Name = record[1].ToString();
                            a.Author_name = record[2].ToString();
                            a.Publication_date = record[3].ToString();
                            a.Price = Convert.ToDouble(record[4]);
                            a.Quantity = Convert.ToInt32(record[5]);
                            a.Publisher = record[6].ToString();
                            a.rent_price = Convert.ToDouble(record[7]);
                            a.purchase_price = Convert.ToDouble(record[8]);
                            a.state = Convert.ToInt32(record[9]);
                            a.access = Convert.ToInt32(record[10]);
                            a.borrow = Convert.ToInt32(record[11]);
                            a.bought = Convert.ToInt32(record[12]);

                            Global.book.Add(a);
                            Global.c1++;

                        }
                    }
                    con.Close();
                }




                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Students_Informations", con))
                {
                    con.Open();
                    using (SqlDataReader MyReader = cmd.ExecuteReader())
                    {

                        while (MyReader.Read())
                        {

                            IDataRecord record = (IDataRecord)MyReader;

                            Student a = new Student();
                            a.name = record[1].ToString();
                            a.id = Convert.ToInt32(record[2]);
                            a.dep = record[3].ToString();
                            a.e_mail = record[4].ToString();
                            a.c_bought = Convert.ToInt32(record[5]);
                            a.c_borrow = Convert.ToInt32(record[6]);


                            Global.student.Add(a);
                            Global.c2++;
                        }

                    }
                    con.Close();
                }


                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Student_Borrow", con))
                {
                    con.Open();
                    using (SqlDataReader MyReader = cmd.ExecuteReader())
                    {
                        for (int i = 0; i < Global.c2; i++)
                        {



                            while (MyReader.Read())
                            {


                                IDataRecord record = (IDataRecord)MyReader;


                                Book a = new Book();
                                int k = Convert.ToInt32(record[0]);
                                a.Name = record[1].ToString();
                                a.Author_name = record[2].ToString();
                                a.Publication_date = record[3].ToString();
                                a.Publisher = record[4].ToString();
                                a.rent_price = Convert.ToDouble(record[5]);
                                a.state = Convert.ToInt32(record[6]);
                                a.access = Convert.ToInt32(record[7]);


                                if (k == i) Global.student[i].borrow.Add(a);



                            }
                        }
                    }

                    con.Close();
                }



                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Student_Bought", con))
                {
                    con.Open();
                    using (SqlDataReader MyReader = cmd.ExecuteReader())
                    {
                        for (int i = 0; i < Global.c2; i++)
                        {



                            while (MyReader.Read())
                            {


                                IDataRecord record = (IDataRecord)MyReader;


                                Book a = new Book();
                                int k = Convert.ToInt32(record[0]);
                                a.Name = record[1].ToString();
                                a.Author_name = record[2].ToString();
                                a.Publication_date = record[3].ToString();
                                a.Publisher = record[4].ToString();
                                a.purchase_price = Convert.ToDouble(record[5]);
                                a.state = Convert.ToInt32(record[6]);
                                a.access = Convert.ToInt32(record[7]);


                                if (k == i) Global.student[i].bought.Add(a);



                            }
                        }
                    }

                    con.Close();
                }




                using (SqlCommand cmd = new SqlCommand("SELECT * From Teacher_Informations", con))
                {
                    con.Open();
                    using (SqlDataReader MyReader = cmd.ExecuteReader())
                    {

                        while (MyReader.Read())
                        {
                            IDataRecord record = (IDataRecord)MyReader;

                            Teacher a = new Teacher();
                            a.name = record[1].ToString();
                            a.id = Convert.ToInt32(record[2]);
                            a.dep = record[3].ToString();
                            a.e_mail = record[4].ToString();
                            a.c_bought = Convert.ToInt32(record[5]);
                            a.c_borrow = Convert.ToInt32(record[6]);

                            Global.teacher.Add(a);
                            Global.c3++;

                        }
                    }
                    con.Close();
                }
            }

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Teacher_Borrow", con))
            {
                con.Open();
                using (SqlDataReader MyReader = cmd.ExecuteReader())
                {
                    for (int i = 0; i < Global.c2; i++)
                    {



                        while (MyReader.Read())
                        {


                            IDataRecord record = (IDataRecord)MyReader;


                            Book a = new Book();
                            int k = Convert.ToInt32(record[0]);
                            a.Name = record[1].ToString();
                            a.Author_name = record[2].ToString();
                            a.Publication_date = record[3].ToString();
                            a.Publisher = record[4].ToString();
                            a.rent_price = Convert.ToDouble(record[5]);
                            a.state = Convert.ToInt32(record[6]);
                            a.access = Convert.ToInt32(record[7]);



                            if (k == i) Global.teacher[i].borrow.Add(a);



                        }
                    }
                }

                con.Close();
            }




            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Teacher_Bought", con))
            {
                con.Open();
                using (SqlDataReader MyReader = cmd.ExecuteReader())
                {
                    for (int i = 0; i < Global.c2; i++)
                    {



                        while (MyReader.Read())
                        {


                            IDataRecord record = (IDataRecord)MyReader;


                            Book a = new Book();
                            int k = Convert.ToInt32(record[0]);
                            a.Name = record[1].ToString();
                            a.Author_name = record[2].ToString();
                            a.Publication_date = record[3].ToString();
                            a.Publisher = record[4].ToString();
                            a.purchase_price = Convert.ToDouble(record[5]);
                            a.state = Convert.ToInt32(record[6]);
                            a.access = Convert.ToInt32(record[7]);



                            if (k == i) Global.teacher[i].bought.Add(a);



                        }
                    }
                }

                con.Close();
            }

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Library_finance", con))
            {
                con.Open();
                using (SqlDataReader MyReader = cmd.ExecuteReader())
                {




                    while(MyReader.Read())
                    {


                        IDataRecord record = (IDataRecord)MyReader;

                        Global.wallet = Convert.ToDouble(record[0]);



                    }

                    
                        
                }

                con.Close();
            }

        }

        public const int WM_NCHITTEST = 0x84;
        public const int HT_CLIENT = 0x1;
        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private void hidePanels()
        {
            panelBook.Visible = false;
            panelStudents.Visible = false;
            panelTeachers.Visible = false;
            panelPurchase.Visible = false;
            panelBorrow.Visible = false;

        }
        private void showPanel(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hidePanels();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }


        private void Book_Click(object sender, EventArgs e)
        {
            showPanel(panelBook);
            miniSidePanel.Top = Book.Top;
            miniSidePanel.Height = Book.Height;

        }

        private void Students_Click(object sender, EventArgs e)
        {
            showPanel(panelStudents);
            miniSidePanel.Top = Students.Top;
            miniSidePanel.Height = Students.Height;
        }

        private void Teachers_Click(object sender, EventArgs e)
        {
            showPanel(panelTeachers);
            miniSidePanel.Top = Teachers.Top;
            miniSidePanel.Height = Teachers.Height;
        }

        private void Purchase_Click(object sender, EventArgs e)
        {
            showPanel(panelPurchase);
            miniSidePanel.Top = Purchase.Top;
            miniSidePanel.Height = Purchase.Height;
        }

        private void Borrow_Click(object sender, EventArgs e)
        {
            showPanel(panelBorrow);
            miniSidePanel.Top = Borrow.Top;
            miniSidePanel.Height = Borrow.Height;
        }

        private void AddNewBook_Click(object sender, EventArgs e)
        {
            openChildForm(new form_AddBook());
            hidePanels();
        }

        private void ViewBooks_Click(object sender, EventArgs e)
        {
            openChildForm(new form_ViewBooks());
            hidePanels();
        }


        private void AddNewStudent_Click(object sender, EventArgs e)
        {
            openChildForm(new form_AddStudent());
            hidePanels();
        }

        private void ViewStudents_Click(object sender, EventArgs e)
        {
            openChildForm(new form_ViewStudents());
            hidePanels();
        }




        private void AddNewTeacher_Click(object sender, EventArgs e)
        {
            openChildForm(new form_AddTeacher());
            hidePanels();
        }

        private void ViewTeachers_Click(object sender, EventArgs e)
        {
            openChildForm(new form_ViewTeachers());
            hidePanels();
        }



        private void Purchase_s_Click(object sender, EventArgs e)
        {
            hidePanels();
            openChildForm(new form_PurchasingS());
        }

        private void Purchase_t_Click(object sender, EventArgs e)
        {
            hidePanels();
            openChildForm(new form_PurchasingT());
        }

        private void Borrow_s_Click_1(object sender, EventArgs e)
        {
            openChildForm(new form_BorrowS());
            hidePanels();
        }

        private void Borrow_t_Click(object sender, EventArgs e)
        {
            openChildForm(new form_BorrowT());
            hidePanels();
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Wallet_Click(object sender, EventArgs e)
        {
            hidePanels();
            openChildForm(new form_Wallet());
            miniSidePanel.Top = Wallet.Top;
            miniSidePanel.Height = Wallet.Height;
        }

        private void info_Click(object sender, EventArgs e)
        {
            hidePanels();
            miniSidePanel.Top = info.Top;
            miniSidePanel.Height = info.Height;
            openChildForm(new form_Info());

        }

        private void Retuen_Click(object sender, EventArgs e)
        {
            hidePanels();

            openChildForm(new form_Return());
        }
    }
}
