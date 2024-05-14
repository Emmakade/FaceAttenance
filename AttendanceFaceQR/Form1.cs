using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AttendanceFaceQR
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnString);
        public static string usr;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!(txtMatric.Text == string.Empty) && !(txtPassword.Text == string.Empty))
            {
                if (!(cmbRole.Text == "none"))
                {
                    usr = txtMatric.Text.Trim();
                    string adm = "Admin";
                    if (cmbRole.Text == adm)
                    {
                        try
                        {
                            using (conn)
                            { string str = "SELECT COUNT(*) FROM facialrecog.admin WHERE username='" + usr + "' AND password='" + txtPassword.Text + "'";
                                using (SqlDataAdapter sda = new SqlDataAdapter(str, conn))
                                {
                                    DataTable dt = new DataTable(); //this is creating a virtual table  
                                    sda.Fill(dt);
                                    if (dt.Rows[0][0].ToString() == "1")
                                    {
                                        this.Hide();
                                        conn.Close(); sda.Dispose();
                                        Admin ad = new Admin();
                                        ad.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Username and password combination incorrect, \r\n Kindly correct and retry", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        conn.Close();
                                    }

                                }
                            }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message);
                        }
                        finally { conn.Close(); }
                    }
                    else
                    {
                       try
                        {
                            using (conn)
                            {
                                string str = "SELECT COUNT(*) FROM facialrecog.students WHERE matric='" + usr + "' AND password='" + txtPassword.Text + "'";
                                using (SqlDataAdapter sdat = new SqlDataAdapter(str, conn))
                                {
                                    DataTable dtb = new DataTable(); 
                                    sdat.Fill(dtb);
                                    if (dtb.Rows[0][0].ToString() == "1")
                                    {
                                        sdat.Dispose(); dtb.Dispose();
                                        Form4 adt = new Form4();
                                        this.Hide();
                                        adt.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Matric and password combination incorrect, \r\n Kindly correct and retry", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        conn.Close();
                                    }

                                }
                            }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); } finally { conn.Close(); }
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Your Role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Enter Your Username or Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.FromArgb(200, 102, 124, 155); cmbRole.SelectedIndex = 1;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (!(txtMatric.Text == string.Empty))
            { 
                Form4 qc = new Form4();
                this.Hide();
                qc.Show();
            }
            else
            {
                MessageBox.Show("Please Enter Your Username to use this option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn.Close();
            }
            
        }
    }
}
