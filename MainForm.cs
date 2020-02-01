
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using uPLibrary.Networking.M2Mqtt;
using System.IO.Ports;
using System.Text;
using System.Web;
using System.Net;

namespace MultiFaceRec
{
    delegate void del(string data);
    public partial class FrmPrincipal : Form
    {
        del MyDlg;
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels= new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;
        string UpdateThingSpeakData(string[] fields, string APIKey)
        {
            string url = "http://api.cognitiveface.com/";
            StringBuilder sb = new StringBuilder();
            if (fields.Length > 8)
            {
                throw (new Exception("Can't Handle More than 8 Parameters"));
            }
            sb.Append(url + "update?key=" + APIKey);

            for (int i = 0; i < fields.Length; i++)
            {
                sb.Append("&field" + (i + 1) + "=" + HttpUtility.UrlEncode(fields[i]));

            }
            string QueryString = sb.ToString();
            StringBuilder sbResponse = new StringBuilder();
            byte[] buf = new byte[8192];

            // Hit the URL with the querystring and put the response in webResponse
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(QueryString);
            HttpWebResponse webResponse = (HttpWebResponse)myRequest.GetResponse();
            try
            {
                Stream myResponse = webResponse.GetResponseStream();

                int count = 0;

                // Read the response buffer and return
                do
                {
                    count = myResponse.Read(buf, 0, buf.Length);
                    if (count != 0)
                    {
                        sbResponse.Append(Encoding.ASCII.GetString(buf, 0, count));
                    }
                }
                while (count > 0);
                return sbResponse.ToString();
            }
            catch (WebException ex)
            {
                return "0";
            }

        }
        void Display(string s)
        {
           
           
            
            try
            {
                double en = double.Parse(s);
                chart1.Series[0].Points.AddY(en);
                if (en > 40)
                {
                    EmailSend.SendMail("police@gmail.com", "Culprit detected","Invalid License "+DateTime.Now ,"");
                }
                
            }
            catch
            {
            }
        }
        public FrmPrincipal()
        {
            InitializeComponent();
            MyDlg = new del(Display);
            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels+1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }
            
            }
            catch(Exception e)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        Stopwatch stFire = new Stopwatch();
        Stopwatch stUnknown = new Stopwatch();
        private void button1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            if (admin.ShowDialog().Equals(DialogResult.OK))
            {
                //Initialize the capture device
                grabber = new Capture();
                grabber.QueryFrame();
                //Initialize the FrameGraber event
                Application.Idle += new EventHandler(FrameGrabber);
                button1.Enabled = false;
                grpAutomation.Enabled = true;
                grpDoor.Enabled = false;
            }
            else
            {
                MessageBox.Show("Authentication Failed!!");
            }
        }


        private void button2_Click(object sender, System.EventArgs e)
        {
            Admin admin = new Admin();
            if (!admin.ShowDialog().Equals(DialogResult.OK))
            {
                MessageBox.Show("Authentication failed!!!");
                return;
            }
            try
            {
                //Trained face counter
                ContTrain = ContTrain + 1;

                //Get a gray frame from capture device
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

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
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                //resize face detected image for force to compare the same size with the 
                //test image with cubic interpolation type method
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(textBox1.Text);

                //Show face added in gray scale
                imageBox1.Image = TrainedFace;

                //Write the number of triained faces in a file text for further load
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                //Write the labels of triained faces in a file text for further load
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }

                MessageBox.Show(textBox1.Text + "´s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        void FrameGrabber(object sender, EventArgs e)
        {
            label3.Text = "0";
            //label4.Text = "";
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
                        if (name.Equals("Unknown"))
                        {
                            //grpDoor.Enabled = false;

                        }
                        else
                        {
                            grpDoor.Enabled = true;
                        }

                            //Draw the label for each face detected and recognized
                        currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                        }

                            NamePersons[t-1] = name;
                            NamePersons.Add("");


                        //Set the number of faces detected on the scene
                        label3.Text = facesDetected[0].Length.ToString();
                       
                        /*
                        //Set the region of interest on the faces
                        
                        gray.ROI = f.rect;
                        MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                           eye,
                           1.1,
                           10,
                           Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                           new Size(20, 20));
                        gray.ROI = Rectangle.Empty;

                        foreach (MCvAvgComp ey in eyesDetected[0])
                        {
                            Rectangle eyeRect = ey.rect;
                            eyeRect.Offset(f.rect.X, f.rect.Y);
                            currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                        }
                         */

                    }
                        t = 0;

                        //Names concatenation of persons recognized
                    for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
                    {
                        names = names + NamePersons[nnn] + ", ";
                    }
                    //Show the faces procesed and recognized
                    imageBoxFrameGrabber.Image = currentFrame;
                    label4.Text = names;
                    names = "";
                    //Clear the list(vector) of names
                    NamePersons.Clear();

                }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("Donate.html");
        }
        MqttClient mc = null;
        Color ac = Color.Blue;
        string topic = "rupam/MyHome";
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
        void mc_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            //throw new NotImplementedException();
            //MessageBox.Show(GetString(e.Message));
            string s = "";
            try
            {
                byte b = e.Message[0];
                //e.Retain = false;
                s = (b - 48).ToString();
            }
            catch
            {
                return;
            }
            this.Invoke((MethodInvoker)delegate
            {

                if (s.Equals("1"))
                {
                    btnBulbOn_Click(btnBulbOn, new EventArgs());
                }
                if (s.Equals("2"))
                {
                    btnBulbOff_Click(btnConnect, new EventArgs());
                }
                if (s.Equals("3"))
                {
                    btnFanOn_Click(btnFanOn, new EventArgs());
                }
                if (s.Equals("4"))
                {
                    btnFanOff_Click(btnFanOff, new EventArgs());
                }
                if (s.Equals("0"))
                {
                    btnAllOff_Click(btnAllOff, new EventArgs());
                }
                if (s.Equals("5"))
                {
                    if (grpDoor.Enabled)
                    {
                        btnLock_Click(btnAllOff, new EventArgs());
                    }
                    else
                    {
                        (new System.Speech.Synthesis.SpeechSynthesizer()).SpeakAsync("Unauthorized Attempt!!!");

                    }
                }
                if (s.Equals("6"))
                {
                    if (grpDoor.Enabled)
                    {
                        btnUnlock_Click(btnAllOff, new EventArgs());
                    }
                    else
                    {
                        (new System.Speech.Synthesis.SpeechSynthesizer()).SpeakAsync("Unauthorized Attempt!!!");

                        String fileName = ".\\Unknown\\Image_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".jpg";//Save the filename first on 
                
                        
                        imageBoxFrameGrabber.Image.Save(fileName);
                        EmailSend.SendMail("home_owner_mail_id_where_this_alermail_should_go@gmail.com", "Unknown Person", "Unknown person attempting unlock " + DateTime.Now, fileName);

                    }
                }

            });
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                cmbPort.Items.Add(ports[i]);
            }
            try
            {
                mc = new MqttClient("test.mosquitto.org");
                mc.Connect("RUPAM");
                mc.Subscribe(new string[] { topic }, new byte[] { (byte)0 });
                mc.MqttMsgPublishReceived += mc_MqttMsgPublishReceived;
                label5.Text = "Connected to iot.eclipse.org in channel rupam/energy";
                label5.BackColor = Color.Green;
            }
            catch
            {
                label5.Text = "No Connection with Server-Check Internet Connection";
                label5.BackColor = Color.Red;
            }
            ac = btnConnect.BackColor;
        }

        private void btnBulbOn_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("1");
            btnBulbOn.BackColor = Color.Green;
            btnBulbOff.BackColor = ac;
        }

        private void btnBulbOff_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("2");
            btnBulbOn.BackColor = ac;
            btnBulbOff.BackColor = Color.Green;
        }

        private void btnFanOn_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("3");
            btnFanOn.BackColor = Color.Green;
            btnFanOff.BackColor = ac;
        }

        private void btnFanOff_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("4");
            btnFanOn.BackColor = ac;
            btnFanOff.BackColor = Color.Green;
        }

        private void btnAllOff_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("0");
            btnFanOff.BackColor = ac;
            btnFanOn.BackColor = ac;
            btnBulbOn.BackColor = ac;
            btnBulbOff.BackColor = ac;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text.Equals("Connect"))
            {
                try
                {
                    serialPort1.PortName = cmbPort.SelectedItem.ToString();
                    serialPort1.BaudRate = 19200;
                    serialPort1.Open();
                    btnConnect.Text = "Disconnect";
                    MessageBox.Show("Connected");

                }
                catch
                {
                    MessageBox.Show("Could Not Connect");

                }
            }
            else
            {
                serialPort1.Close();
                btnConnect.Text = "Connect";
                MessageBox.Show("Disconnected");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string s = serialPort1.ReadLine();
            this.BeginInvoke(MyDlg, s);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (!label4.Text.Contains("Unknown"))
            {
                serialPort1.WriteLine("5");
                btnUnlock.BackColor = ac;
                btnLock.BackColor = Color.Green;
                grpDoor.Enabled = false;
                
            }
            else
            {
                //// Send a Mail
                (new System.Speech.Synthesis.SpeechSynthesizer()).SpeakAsync("Unauthorized Attempt!!!");

                String fileName = ".\\Unknown\\Image_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".jpg";//Save the filename first on 


                imageBoxFrameGrabber.Image.Save(fileName);
                EmailSend.SendMail("maneeshanmc27@gmail.com", "Unknown Person", "Unknown person attempting unlock " + DateTime.Now, fileName);
                ///////
            }
            
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (!label4.Text.Contains("Unknown"))
            {
                serialPort1.WriteLine("6");
                btnLock.BackColor = ac;
                btnUnlock.BackColor = Color.Green;
            }
            else
            {
                //// Send a Mail
                (new System.Speech.Synthesis.SpeechSynthesizer()).SpeakAsync("Unauthorized Attempt!!!");

                String fileName = ".\\Unknown\\Image_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".jpg";//Save the filename first on 


                imageBoxFrameGrabber.Image.Save(fileName);
                EmailSend.SendMail("maneeshanmc27@gmail.com", "Unknown Person", "Unknown person attempting unlock " + DateTime.Now, fileName);
                ///////
            }
        }

       

       

    }
}