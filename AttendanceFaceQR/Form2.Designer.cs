namespace AttendanceFaceQR
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param nam="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMatric = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnFaceMark = new System.Windows.Forms.Button();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnMark = new System.Windows.Forms.Button();
            this.dtpAttend = new System.Windows.Forms.DateTimePicker();
            this.lblCapStatus = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.lblMatric);
            this.panel3.Controls.Add(this.lblName);
            this.panel3.Controls.Add(this.btnFaceMark);
            this.panel3.Controls.Add(this.txtDept);
            this.panel3.Controls.Add(this.btnCheck);
            this.panel3.Controls.Add(this.btnMark);
            this.panel3.Controls.Add(this.dtpAttend);
            this.panel3.Location = new System.Drawing.Point(59, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(362, 265);
            this.panel3.TabIndex = 16;
            // 
            // lblMatric
            // 
            this.lblMatric.AutoSize = true;
            this.lblMatric.Font = new System.Drawing.Font("Antiqua 101-Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatric.ForeColor = System.Drawing.Color.White;
            this.lblMatric.Location = new System.Drawing.Point(62, 44);
            this.lblMatric.Name = "lblMatric";
            this.lblMatric.Size = new System.Drawing.Size(61, 22);
            this.lblMatric.TabIndex = 21;
            this.lblMatric.Text = "(Matric)";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Antiqua 101-Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(62, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 22);
            this.lblName.TabIndex = 21;
            this.lblName.Text = "Name";
            // 
            // btnFaceMark
            // 
            this.btnFaceMark.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFaceMark.BackgroundImage")));
            this.btnFaceMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFaceMark.Enabled = false;
            this.btnFaceMark.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnFaceMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFaceMark.Location = new System.Drawing.Point(245, 184);
            this.btnFaceMark.Name = "btnFaceMark";
            this.btnFaceMark.Size = new System.Drawing.Size(44, 42);
            this.btnFaceMark.TabIndex = 20;
            this.btnFaceMark.UseVisualStyleBackColor = true;
            this.btnFaceMark.Click += new System.EventHandler(this.btnFaceMark_Click);
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(66, 144);
            this.txtDept.Name = "txtDept";
            this.txtDept.ReadOnly = true;
            this.txtDept.Size = new System.Drawing.Size(132, 20);
            this.txtDept.TabIndex = 19;
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.ForeColor = System.Drawing.Color.White;
            this.btnCheck.Location = new System.Drawing.Point(214, 142);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 18;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnMark
            // 
            this.btnMark.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnMark.Enabled = false;
            this.btnMark.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMark.ForeColor = System.Drawing.Color.White;
            this.btnMark.Location = new System.Drawing.Point(66, 184);
            this.btnMark.Name = "btnMark";
            this.btnMark.Size = new System.Drawing.Size(162, 42);
            this.btnMark.TabIndex = 15;
            this.btnMark.Text = "Mark";
            this.btnMark.UseVisualStyleBackColor = false;
            this.btnMark.Click += new System.EventHandler(this.btnMark_Click);
            // 
            // dtpAttend
            // 
            this.dtpAttend.CalendarMonthBackground = System.Drawing.Color.LightSkyBlue;
            this.dtpAttend.Location = new System.Drawing.Point(66, 107);
            this.dtpAttend.Name = "dtpAttend";
            this.dtpAttend.Size = new System.Drawing.Size(223, 20);
            this.dtpAttend.TabIndex = 12;
            // 
            // lblCapStatus
            // 
            this.lblCapStatus.AutoSize = true;
            this.lblCapStatus.BackColor = System.Drawing.Color.White;
            this.lblCapStatus.Location = new System.Drawing.Point(223, 21);
            this.lblCapStatus.Name = "lblCapStatus";
            this.lblCapStatus.Padding = new System.Windows.Forms.Padding(9, 6, 9, 6);
            this.lblCapStatus.Size = new System.Drawing.Size(34, 25);
            this.lblCapStatus.TabIndex = 16;
            this.lblCapStatus.Text = "...";
            this.lblCapStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AttendanceFaceQR.Properties.Resources.bg1;
            this.ClientSize = new System.Drawing.Size(480, 371);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblCapStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BioFacial Mark";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCapStatus;
        private System.Windows.Forms.Button btnMark;
        private System.Windows.Forms.DateTimePicker dtpAttend;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Button btnFaceMark;
        private System.Windows.Forms.Label lblMatric;
        private System.Windows.Forms.Label lblName;
    }
}