using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AttendanceFaceQR
{
    public partial class ViewAttend : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnString);
        public ViewAttend()
        {
            InitializeComponent();
        }

      
        private void btnGo_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            string date = dtp.Value.ToString("yyyy-MM-dd");
            string department = cmbDepartment.Text;
            try
            {
                string query = string.Format("Select matrics,names from facialrecog.attendance where date='{0}' and department='{1}'", date, department);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                listView1.Columns.Add("Matric No.", 100, HorizontalAlignment.Center);
                listView1.Columns.Add("Names Of Students Present", 200, HorizontalAlignment.Center);
                listView1.View = View.Details;

                string[] s = new string[] { };
                string[] nam = new string[] { };
                while (dr.Read())
                {
                    s = dr["matrics"].ToString().Split(',');
                    nam = dr["names"].ToString().Split(',');
                }
                int length = s.Length;
                for (int i = 0; i < length; i++)
                {
                    string[] subitem = new string[] { s[i] };
                    ListViewItem item = new ListViewItem(subitem);
                    listView1.Items.Add(item);
                }

                lblDept.Text = department; lblDate.Text = date;

                conn.Close(); cmd.Dispose(); dr.Dispose(); 
            }
            catch (Exception em) { MessageBox.Show(em.Message + em.ToString()); conn.Close(); }
        }

    }
}
