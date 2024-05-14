using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AttendanceFaceQR
{
    public partial class StdPanel : Form
    {
        public static string name,matric,department;
        private static string  level, mypix;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnString);
        public StdPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 sp = new Form1();
            this.Hide();
            sp.Show();
        }

        private void StdPanel_Load(object sender, EventArgs e)
        {
            matric = Form4.matric;

            try
            {
                using (conn)
                {
                    string query = string.Format("SELECT * FROM facialrecog.students WHERE students.matric = '{0}'", matric);
                    using (SqlCommand cmd = new SqlCommand(query,conn))
                    {
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            name = dr.GetString(1);
                            matric = dr.GetString(2);
                            department = dr.GetString(5);
                            level = dr.GetString(6);
                            mypix = dr.GetString(4);
                        }
                        conn.Close();cmd.Parameters.Clear();

                        lblName.Text = name;
                        lblMatric.Text = matric;
                        lblLevel.Text = level;
                        lblDept.Text = department;

                        pixBox.Image = Image.FromFile(Application.StartupPath + "/pix/" + mypix + ".jpg");
                    }

                }
                
            }
            catch (Exception et) { MessageBox.Show(et.Message); }            


        }

        private void markAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form2 vs = new Form2())
            {
                vs.ShowDialog();
            }
        }

        private void viewAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ViewAttend va = new ViewAttend()) { va.ShowDialog(); }
        }
    }
}
