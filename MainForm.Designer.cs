namespace MultiFaceRec
{
    partial class FrmPrincipal
    {
        
        private System.ComponentModel.IContainer components = null;

        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.grpAutomation = new System.Windows.Forms.GroupBox();
            this.grpDoor = new System.Windows.Forms.GroupBox();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAllOff = new System.Windows.Forms.Button();
            this.btnFanOff = new System.Windows.Forms.Button();
            this.btnFanOn = new System.Windows.Forms.Button();
            this.btnBulbOff = new System.Windows.Forms.Button();
            this.btnBulbOn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.grpAutomation.SuspendLayout();
            this.grpDoor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(18, 247);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(214, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "2. Add face";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 209);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 22);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "ALVCD";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.imageBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(456, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(245, 298);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Training: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 213);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name: ";
            // 
            // imageBox1
            // 
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.Location = new System.Drawing.Point(15, 22);
            this.imageBox1.Margin = new System.Windows.Forms.Padding(4);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(217, 164);
            this.imageBox1.TabIndex = 5;
            this.imageBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(709, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(279, 298);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "Persons present in the scene:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(12, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 16;
            this.label4.Text = "Nobody";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(217, 153);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Number of faces detected: ";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(8, 220);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 65);
            this.button1.TabIndex = 2;
            this.button1.Text = "1. Detect and recognize";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(16, 15);
            this.imageBoxFrameGrabber.Margin = new System.Windows.Forms.Padding(4);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(426, 295);
            this.imageBoxFrameGrabber.TabIndex = 4;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // grpAutomation
            // 
            this.grpAutomation.Controls.Add(this.grpDoor);
            this.grpAutomation.Controls.Add(this.linkLabel1);
            this.grpAutomation.Controls.Add(this.chart1);
            this.grpAutomation.Controls.Add(this.groupBox5);
            this.grpAutomation.Controls.Add(this.groupBox4);
            this.grpAutomation.Enabled = false;
            this.grpAutomation.Location = new System.Drawing.Point(19, 325);
            this.grpAutomation.Name = "grpAutomation";
            this.grpAutomation.Size = new System.Drawing.Size(1239, 406);
            this.grpAutomation.TabIndex = 10;
            this.grpAutomation.TabStop = false;
            this.grpAutomation.Text = "TESTING";
            // 
            // grpDoor
            /* 
            this.grpDoor.Controls.Add(this.btnUnlock);
            this.grpDoor.Controls.Add(this.btnLock);
            this.grpDoor.Location = new System.Drawing.Point(233, 200);
            this.grpDoor.Name = "grpDoor";
            this.grpDoor.Size = new System.Drawing.Size(137, 133);
            this.grpDoor.TabIndex = 12;
            this.grpDoor.TabStop = false;
            this.grpDoor.Text = "";
             
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(6, 73);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(125, 37);
            this.btnUnlock.TabIndex = 1;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(6, 25);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(124, 37);
            this.btnLock.TabIndex = 0;
            this.btnLock.Text = "Lock";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(648, 18);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(263, 17);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://thingspeak.com/channels/114419";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(376, 45);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(841, 336);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Room Temperature in \'C";
            this.chart1.Titles.Add(title1);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAllOff);
            this.groupBox5.Controls.Add(this.btnFanOff);
            this.groupBox5.Controls.Add(this.btnFanOn);
            this.groupBox5.Controls.Add(this.btnBulbOff);
            this.groupBox5.Controls.Add(this.btnBulbOn);
            this.groupBox5.Location = new System.Drawing.Point(16, 189);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(212, 144);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Home Control";
            // 
            // btnAllOff
            // 
            this.btnAllOff.Location = new System.Drawing.Point(6, 98);
            this.btnAllOff.Name = "btnAllOff";
            this.btnAllOff.Size = new System.Drawing.Size(194, 23);
            this.btnAllOff.TabIndex = 4;
            this.btnAllOff.Text = "All Off(0)";
            this.btnAllOff.UseVisualStyleBackColor = true;
            this.btnAllOff.Click += new System.EventHandler(this.btnAllOff_Click);
            // 
            // btnFanOff
            // 
            this.btnFanOff.Location = new System.Drawing.Point(114, 65);
            this.btnFanOff.Name = "btnFanOff";
            this.btnFanOff.Size = new System.Drawing.Size(86, 27);
            this.btnFanOff.TabIndex = 3;
            this.btnFanOff.Text = "Fan Off(4)";
            this.btnFanOff.UseVisualStyleBackColor = true;
            this.btnFanOff.Click += new System.EventHandler(this.btnFanOff_Click);
            // 
            // btnFanOn
            // 
            this.btnFanOn.Location = new System.Drawing.Point(6, 65);
            this.btnFanOn.Name = "btnFanOn";
            this.btnFanOn.Size = new System.Drawing.Size(102, 27);
            this.btnFanOn.TabIndex = 2;
            this.btnFanOn.Text = "Fan On(3)";
            this.btnFanOn.UseVisualStyleBackColor = true;
            this.btnFanOn.Click += new System.EventHandler(this.btnFanOn_Click);
            // 
            // btnBulbOff
            // 
            this.btnBulbOff.Location = new System.Drawing.Point(112, 30);
            this.btnBulbOff.Name = "btnBulbOff";
            this.btnBulbOff.Size = new System.Drawing.Size(86, 29);
            this.btnBulbOff.TabIndex = 1;
            this.btnBulbOff.Text = "Bulb Off(2)";
            this.btnBulbOff.UseVisualStyleBackColor = true;
            this.btnBulbOff.Click += new System.EventHandler(this.btnBulbOff_Click);
            // 
            // btnBulbOn
            // 
            this.btnBulbOn.Location = new System.Drawing.Point(6, 30);
            this.btnBulbOn.Name = "btnBulbOn";
            this.btnBulbOn.Size = new System.Drawing.Size(100, 29);
            this.btnBulbOn.TabIndex = 0;
            this.btnBulbOn.Text = "Bulb On(1)";
            this.btnBulbOn.UseVisualStyleBackColor = true;
            this.btnBulbOn.Click += new System.EventHandler(this.btnBulbOn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnConnect);
            this.groupBox4.Controls.Add(this.cmbPort);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(16, 30);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(354, 153);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Connect to Arduino";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(27, 95);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(253, 33);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(90, 50);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(190, 24);
            this.cmbPort.TabIndex = 1;
            */ 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ports";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 759);
            this.Controls.Add(this.grpAutomation);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageBoxFrameGrabber);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPrincipal";
            this.Text = "ENHANCED SECURITY VERIFICATION AND AUTHENTICATION IN TOLLGATE";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.grpAutomation.ResumeLayout(false);
            this.grpAutomation.PerformLayout();
            this.grpDoor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpAutomation;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAllOff;
        private System.Windows.Forms.Button btnFanOff;
        private System.Windows.Forms.Button btnFanOn;
        private System.Windows.Forms.Button btnBulbOff;
        private System.Windows.Forms.Button btnBulbOn;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox grpDoor;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnLock;
    }
}

