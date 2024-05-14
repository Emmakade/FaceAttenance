using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceFaceQR
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (reg rg = new reg()) { rg.ShowDialog(); }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form1 sp = new Form1();
            this.Close();
            sp.Show();
        }

        private void registerFaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form3 fc = new Form3()) { fc.ShowDialog(); }
        }

        private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ViewAttend va = new ViewAttend()) { va.ShowDialog(); }
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
