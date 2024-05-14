using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AttendanceFaceQR
{
    public partial class Form6 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server='localhost';Database='facialrecog';User='root';Pwd='';SslMode=none");
        public static string usr;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public Form6()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string pass = txtPassword.Text.Trim();
            //MessageBox.Show(usr +" "+pass );
            cmd = new MySqlCommand("SELECT * FROM `admin` WHERE `username`='" + usr + "' AND `password`='" + txtPassword.Text + "'", conn);
            conn.Open();
            //cmd.Connection = conn;
            //cmd.CommandText = "SELECT * FROM `admin` WHERE `username`='"+usr+"' AND `password`='"+txtPassword.Text+"'";
            dr = cmd.ExecuteReader();
            MessageBox.Show("Am alive");

            if (dr.Read())
            {
                //conn.Close(); dr.Dispose(); cmd.Dispose();
                Admin ad = new Admin();
                this.Hide();
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
