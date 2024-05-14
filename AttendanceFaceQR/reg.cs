using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace AttendanceFaceQR
{
    public partial class reg : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnString);
        
        public reg()
        {
            InitializeComponent();
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagepath = openFileDialog1.FileName;
                pixbox.Image = Image.FromFile(openFileDialog1.FileName);
                pixbox.ImageLocation = imagepath;
            }
        }

        private void reg_Load(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select A Profile Picture";
            openFileDialog1.Filter = "Jpg Files|*.jpg|Gif Files|*.gif|Png Files|*.png";

            cmbDept.SelectedIndex = 0;
            cmbLevel.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string matric = txtMatric.Text.Trim();
            string name = txtName.Text.Trim();
            try
            {
                if (!(name =="") && !(matric ==""))
                {
                    Regex regMatric = new Regex("[0-9]{6,8}");
                    if (regMatric.IsMatch(matric))
                    {
                        if (!(cmbDept.Text.Equals("Select a Dept.")) && !(cmbLevel.Text.Equals("Select A Level")))
                        {
                            using (conn)
                            {
                                String query = "INSERT INTO facialrecog.students (name,matric,department,level,password,dp) " +
                                    "VALUES (@name,@matric,@department,@level,@password,@dp)";

                                using (SqlCommand cmd = new SqlCommand(query, conn))
                                {
                                    DateTime date = DateTime.Now;
                                    int uniq = date.GetHashCode();
                                    string un = uniq.ToString();
                                    string mydp = un.Substring(1); //start at the 2nd character

                                    conn.Open();
                                    cmd.Parameters.AddWithValue("name", txtName.Text.ToUpper());
                                    cmd.Parameters.AddWithValue("matric", matric);
                                    cmd.Parameters.AddWithValue("department", cmbDept.Text);
                                    cmd.Parameters.AddWithValue("level", cmbLevel.Text);
                                    cmd.Parameters.AddWithValue("password", "12345");
                                    cmd.Parameters.AddWithValue("dp", mydp);

                                    
                                    int a = cmd.ExecuteNonQuery();

                                    //pixbox.Image.Save(Application.StartupPath + "/pix/" + mydp + ".jpg");
                                    // Check Error
                                    if (a == 1)
                                    {
                                        MessageBox.Show("Registration Successful", "SUCCESS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else if (a < 0) { MessageBox.Show("Error inserting data into Database!");}
                                        
                                    
                                }
                            }
                            
                            reset();
                        }
                        else
                        {
                            MessageBox.Show("Please Select a department and/or level.");
                        }
                   }
                    else
                    {
                        MessageBox.Show("Please Enter a valid matric No");
                    }
                }
                else
                {
                    MessageBox.Show("FullName and/or Matric cannot be empty.");
                }
            }
            catch (Exception ed)
            {
                MessageBox.Show("Encounter Error, Please check and try again \r\n" + ed.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
            finally { conn.Close(); }
        }

        private void reset()
        {
            txtName.Clear(); txtMatric.Clear(); cmbLevel.SelectedIndex = 0; cmbDept.SelectedIndex = 0; pixbox.Image = null; conn.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void txtMatric_Enter(object sender, EventArgs e)
        {
            cmbDept.Enabled = true; 
        }
    }
}
