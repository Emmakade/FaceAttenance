﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using System.Threading;
using MySql.Data.MySqlClient;

namespace AttendanceFaceQR
{
    public partial class MarkFace : Form
    {
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;

        Capture grabber;
        HaarCascade face;
        //HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name = null;

        public static string matric,dept;
        string dat, allmatrics, nam, allnames;
        bool dateAttend = false;
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=facialrecog;Uid=root;Pwd=;");

        public MarkFace()
        {
            InitializeComponent();

            try
            {
                //Load haarcascades for face detection
                face = new HaarCascade("haarcascade_frontalface_default.xml");
                //eye = new HaarCascade("haarcascade_eye.xml");
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }

            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button). \r\n", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
            grabber.Dispose();
            this.Close();
        }

        private void btnMark_Click(object sender, EventArgs e)
        {
            try
            {
                //Initialize the capture device
                grabber = new Capture();
                grabber.QueryFrame();
                //Initialize the FrameGraber event
                Application.Idle += new EventHandler(FrameGrabber);
                btnMark.Enabled = false;
            }
            catch (Exception xd) { MessageBox.Show(xd.Message); }
        }

        private void FrameGrabber(object sender, EventArgs e)
        {
            NamePersons.Add("");


            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
          face,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with blue color
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


                if (trainingImages.ToArray().Length != 0)
                {
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                    //Eigen face recognizer
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                       labels.ToArray(),
                       3000,
                       ref termCrit);

                    name = recognizer.Recognize(result);

                    //Draw the label for each face detected and recognized
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));


                    if (!string.IsNullOrEmpty(name))
                    {
                        
                        if (matric == name)
                        {
                            if (Application.OpenForms["Form2"] == null)
                            {
                                this.Dispose();

                                try
                                {
                                    allmatrics += "," + matric;
                                    allnames += "," + nam;
                                    conn.Open();
                                    string qw = string.Format("UPDATE attendance SET matrics = @allmatrics, names = @allnames where date='{0}' and department='{1}'", dat, dept);
                                    MySqlCommand cmd = new MySqlCommand(qw, conn);
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
                                    //lblCapStatus.Text = "Attendance Marked Successfully";
                                }
                                catch (Exception ed) { MessageBox.Show(ed.Message + ed.ToString()); }
                            }
                            else
                            {
                                try
                                {
                                    conn.Open();
                                    MySqlCommand cmd = new MySqlCommand("insert into attendance(matrics,names,department,date) values(@matrics,@names,@department,@date)", conn);
                                    cmd.Parameters.AddWithValue("@matrics", matric);
                                    cmd.Parameters.AddWithValue("@names", nam);
                                    cmd.Parameters.AddWithValue("@department", dept);
                                    cmd.Parameters.AddWithValue("@date", dat);

                                    int a = cmd.ExecuteNonQuery();
                                    if (a > 0)
                                    {
                                        MessageBox.Show("Attendance Captured Successfully", "Success!",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information); conn.Close(); cmd.Dispose();
                                    }
                                    conn.Close();

                                    //lblCapStatus.Text = "Attendance Captured";
                                }
                                catch (Exception ed) { MessageBox.Show(ed.Message + ed.ToString()); }
                            }
                            //if (dateAttend)
                            //{

                            //}  
                        }
                        else
                        {
                            MessageBox.Show("Matric not found, \r\n Have you capture your face with admin?", "Stop",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Face has not being regstered", "Not Captured yet.");
                    }

                }

            }
            t = 0;
            pixFrame.Image = currentFrame.Bitmap;
            NamePersons.Clear();
        }

        private void MarkFace_Load(object sender, EventArgs e)
        {
            matric = Form2.matric; dept = Form2.department;
            dat = Form2.date;
        }

    }
}
