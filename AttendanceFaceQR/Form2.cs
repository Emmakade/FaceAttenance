using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AttendanceFaceQR
{
    public partial class Form2 : Form
    {
        public static string matric,department,date;
        string allmatrics, nam, allnames,dept;
        bool dateAttend = false;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnString);
        public Form2()
        {
            InitializeComponent();
        }

        private void btnMark_Click(object sender, EventArgs e)
        {
            conn.Close();
            department = dept; date = dtpAttend.Value.ToString("yyyy-MM-dd");
            if (dateAttend)
            {
                try
                {
                    allmatrics += "," + matric;
                    allnames += "," + nam;
                    conn.Open();
                    string qw = string.Format("UPDATE facialrecog.attendance SET matrics = @allmatrics, names = @allnames where date='{0}' and department='{1}'", date, department);
                    SqlCommand cmd = new SqlCommand(qw, conn);
                    cmd.Parameters.AddWithValue("@matrics", allmatrics);
                    cmd.Parameters.AddWithValue("@matrics", allnames);

                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Attendance Captured Successfully", "Success!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information); conn.Close(); cmd.Dispose();
                        this.Close();
                    }
                    conn.Close();
                    lblCapStatus.Text = "Attendance Marked Successfully";
                }
                catch (Exception ed) { MessageBox.Show(ed.Message + ed.ToString()); }
                finally { conn.Close(); }
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into facialrecog.attendance(matrics,names,department,date) values(@matrics,@names,@department,@date)", conn);
                    cmd.Parameters.AddWithValue("@matrics", matric);
                    cmd.Parameters.AddWithValue("@names", nam);
                    cmd.Parameters.AddWithValue("@department", department);
                    cmd.Parameters.AddWithValue("@date", date);

                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Attendance Captured Successfully", "Success!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information); conn.Close(); cmd.Dispose();
                    }
                    conn.Close();

                    lblCapStatus.Text = "Attendance Captured";
                }
                catch (Exception ed) { MessageBox.Show(ed.Message + ed.ToString()); }
                finally { conn.Close(); }
            }   
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            matric = StdPanel.matric;
            nam = StdPanel.name;
            dept = StdPanel.department;

            lblMatric.Text = matric;
            lblName.Text = nam;
            txtDept.Text = dept;
            panel3.BackColor = Color.FromArgb(200, 50, 50, 100);
            dtpAttend.MinDate = DateTime.Now;
            //dtpAttend.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpAttend.MaxDate = DateTime.Now.AddDays(0);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            department = dept; date = dtpAttend.Value.ToString("yyyy-MM-dd");

            if (!string.IsNullOrEmpty(department))
            {
                try
                {
                    string query = string.Format("Select matrics,names from facialrecog.attendance where date='{0}'", date);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    string[] matricArray = new string[] { };
                    while (dr.Read())
                    {
                        if (dr.HasRows)
                        {
                            dateAttend = true;
                        }
                        allmatrics = dr["matrics"].ToString();
                        allnames = dr["names"].ToString();
                        matricArray = allmatrics.Split(',');
                    }

                    if (matricArray.Contains(matric))
                    {
                        MessageBox.Show("You already Mark Attendance \r\n for " + department + " on this today " + date, "Stop!",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Close(); conn.Close();
                    }
                    else
                    {
                        btnMark.Enabled = true; //btnFaceMark.Enabled = true;
                    }
                    conn.Close();
                }
                catch (Exception ef) { MessageBox.Show(ef.Message); conn.Close(); }
                finally { conn.Close(); }
            }
        }

        private void btnFaceMark_Click(object sender, EventArgs e)
        {
            using (MarkFace mf = new MarkFace())
            {
                date = dtpAttend.Value.ToString("yyyy-MM-dd");
                //mf.ShowDialog();
                if (mf.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}
