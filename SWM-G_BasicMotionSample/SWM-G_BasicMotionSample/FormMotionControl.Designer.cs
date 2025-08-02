namespace BasicMotionSample
{
    partial class FormMotionControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMotionControl));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textTarget = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonJogP = new System.Windows.Forms.Button();
            this.buttonJogM = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonAbs = new System.Windows.Forms.Button();
            this.buttonRel = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textAxis = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonServoON = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.textVelocity = new System.Windows.Forms.TextBox();
            this.textAccDec = new System.Windows.Forms.TextBox();
            this.timerMonitor = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 186);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Velocity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 218);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Accel,Decel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 152);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Target Pos/Distance";
            // 
            // textTarget
            // 
            this.textTarget.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textTarget.Location = new System.Drawing.Point(201, 152);
            this.textTarget.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textTarget.Name = "textTarget";
            this.textTarget.Size = new System.Drawing.Size(132, 22);
            this.textTarget.TabIndex = 5;
            this.textTarget.Text = "10000.000";
            this.textTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTarget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textValue_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonJogP);
            this.groupBox1.Controls.Add(this.buttonJogM);
            this.groupBox1.Location = new System.Drawing.Point(8, 258);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(334, 72);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "JOG operation ";
            // 
            // buttonJogP
            // 
            this.buttonJogP.Location = new System.Drawing.Point(180, 26);
            this.buttonJogP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonJogP.Name = "buttonJogP";
            this.buttonJogP.Size = new System.Drawing.Size(147, 30);
            this.buttonJogP.TabIndex = 1;
            this.buttonJogP.Text = "JOG(+)";
            this.buttonJogP.UseVisualStyleBackColor = true;
            this.buttonJogP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonJogP_MouseDown);
            this.buttonJogP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonJog_MouseUp);
            // 
            // buttonJogM
            // 
            this.buttonJogM.Location = new System.Drawing.Point(9, 26);
            this.buttonJogM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonJogM.Name = "buttonJogM";
            this.buttonJogM.Size = new System.Drawing.Size(147, 30);
            this.buttonJogM.TabIndex = 0;
            this.buttonJogM.Text = "JOG(-)";
            this.buttonJogM.UseVisualStyleBackColor = true;
            this.buttonJogM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonJogM_MouseDown);
            this.buttonJogM.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonJog_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonPause);
            this.groupBox2.Controls.Add(this.buttonAbs);
            this.groupBox2.Controls.Add(this.buttonRel);
            this.groupBox2.Location = new System.Drawing.Point(8, 338);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(334, 72);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Positioning Control";
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(243, 24);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(84, 30);
            this.buttonPause.TabIndex = 2;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonAbs
            // 
            this.buttonAbs.Location = new System.Drawing.Point(120, 24);
            this.buttonAbs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAbs.Name = "buttonAbs";
            this.buttonAbs.Size = new System.Drawing.Size(103, 30);
            this.buttonAbs.TabIndex = 1;
            this.buttonAbs.Text = "AbsMove";
            this.buttonAbs.UseVisualStyleBackColor = true;
            this.buttonAbs.Click += new System.EventHandler(this.buttonAbs_Click);
            // 
            // buttonRel
            // 
            this.buttonRel.Location = new System.Drawing.Point(9, 24);
            this.buttonRel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRel.Name = "buttonRel";
            this.buttonRel.Size = new System.Drawing.Size(103, 30);
            this.buttonRel.TabIndex = 0;
            this.buttonRel.Text = "RelMove";
            this.buttonRel.UseVisualStyleBackColor = true;
            this.buttonRel.Click += new System.EventHandler(this.buttonRel_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(16, 90);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(147, 30);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(158, 418);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(187, 30);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textAxis
            // 
            this.textAxis.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textAxis.Location = new System.Drawing.Point(76, 18);
            this.textAxis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textAxis.Name = "textAxis";
            this.textAxis.Size = new System.Drawing.Size(48, 22);
            this.textAxis.TabIndex = 1;
            this.textAxis.Text = "0";
            this.textAxis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textAxis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAxis_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Axis";
            // 
            // buttonServoON
            // 
            this.buttonServoON.Location = new System.Drawing.Point(16, 52);
            this.buttonServoON.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonServoON.Name = "buttonServoON";
            this.buttonServoON.Size = new System.Drawing.Size(147, 30);
            this.buttonServoON.TabIndex = 2;
            this.buttonServoON.Text = "Servo ON";
            this.buttonServoON.UseVisualStyleBackColor = true;
            this.buttonServoON.Click += new System.EventHandler(this.buttonServoON_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(201, 52);
            this.buttonHome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(144, 30);
            this.buttonHome.TabIndex = 3;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // textVelocity
            // 
            this.textVelocity.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textVelocity.Location = new System.Drawing.Point(201, 186);
            this.textVelocity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textVelocity.Name = "textVelocity";
            this.textVelocity.Size = new System.Drawing.Size(132, 22);
            this.textVelocity.TabIndex = 6;
            this.textVelocity.Text = "10000.000";
            this.textVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textVelocity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textValue_KeyPress);
            // 
            // textAccDec
            // 
            this.textAccDec.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textAccDec.Location = new System.Drawing.Point(201, 218);
            this.textAccDec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textAccDec.Name = "textAccDec";
            this.textAccDec.Size = new System.Drawing.Size(132, 22);
            this.textAccDec.TabIndex = 7;
            this.textAccDec.Text = "10000.000";
            this.textAccDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textAccDec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textValue_KeyPress);
            // 
            // timerMonitor
            // 
            this.timerMonitor.Interval = 1;
            this.timerMonitor.Tick += new System.EventHandler(this.timerMonitor_Tick);
            // 
            // FormMotionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 462);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.textAccDec);
            this.Controls.Add(this.textVelocity);
            this.Controls.Add(this.textAxis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonServoON);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMotionControl";
            this.ShowInTaskbar = false;
            this.Text = "Single axis Positioning/JOG Operation ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMotionControl_FormClosed);
            this.Load += new System.EventHandler(this.FormMotionControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textTarget;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonJogP;
        private System.Windows.Forms.Button buttonJogM;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonRel;
        private System.Windows.Forms.Button buttonAbs;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textAxis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonServoON;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.TextBox textVelocity;
        private System.Windows.Forms.TextBox textAccDec;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Timer timerMonitor;
    }
}