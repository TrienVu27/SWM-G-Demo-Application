
namespace BasicMotionSample
{
    partial class FormMelsofGEMINIControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMelsofGEMINIControl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonSrvON = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxYTarget = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxXTarget = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxYActual = new System.Windows.Forms.TextBox();
            this.textBoxXActual = new System.Windows.Forms.TextBox();
            this.radioButtonControl = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonMonitor = new System.Windows.Forms.RadioButton();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelOPCConnected = new System.Windows.Forms.Label();
            this.labelGEMINICConnected = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonMonitor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.buttonHome);
            this.groupBox1.Controls.Add(this.buttonSrvON);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxYTarget);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxXTarget);
            this.groupBox1.Location = new System.Drawing.Point(4, 75);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(465, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(303, 92);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(112, 35);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(166, 92);
            this.buttonHome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(112, 35);
            this.buttonHome.TabIndex = 5;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonSrvON
            // 
            this.buttonSrvON.Location = new System.Drawing.Point(32, 92);
            this.buttonSrvON.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSrvON.Name = "buttonSrvON";
            this.buttonSrvON.Size = new System.Drawing.Size(112, 35);
            this.buttonSrvON.TabIndex = 4;
            this.buttonSrvON.Text = "ServoON";
            this.buttonSrvON.UseVisualStyleBackColor = true;
            this.buttonSrvON.Click += new System.EventHandler(this.buttonSrvON_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y Axis Target";
            // 
            // textBoxYTarget
            // 
            this.textBoxYTarget.Location = new System.Drawing.Point(345, 40);
            this.textBoxYTarget.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxYTarget.Name = "textBoxYTarget";
            this.textBoxYTarget.Size = new System.Drawing.Size(50, 26);
            this.textBoxYTarget.TabIndex = 2;
            this.textBoxYTarget.Text = "000";
            this.textBoxYTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "X Axis Target";
            // 
            // textBoxXTarget
            // 
            this.textBoxXTarget.Location = new System.Drawing.Point(114, 38);
            this.textBoxXTarget.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxXTarget.Name = "textBoxXTarget";
            this.textBoxXTarget.Size = new System.Drawing.Size(56, 26);
            this.textBoxXTarget.TabIndex = 0;
            this.textBoxXTarget.Text = "000";
            this.textBoxXTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxXTarget.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonMonitor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxYActual);
            this.groupBox2.Controls.Add(this.textBoxXActual);
            this.groupBox2.Location = new System.Drawing.Point(4, 232);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(465, 126);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Monitor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(240, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Y Axis Actual";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "X Axis Actual";
            // 
            // textBoxYActual
            // 
            this.textBoxYActual.Location = new System.Drawing.Point(345, 25);
            this.textBoxYActual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxYActual.Name = "textBoxYActual";
            this.textBoxYActual.ReadOnly = true;
            this.textBoxYActual.Size = new System.Drawing.Size(50, 26);
            this.textBoxYActual.TabIndex = 9;
            this.textBoxYActual.Text = "000";
            this.textBoxYActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxXActual
            // 
            this.textBoxXActual.Location = new System.Drawing.Point(114, 23);
            this.textBoxXActual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxXActual.Name = "textBoxXActual";
            this.textBoxXActual.ReadOnly = true;
            this.textBoxXActual.Size = new System.Drawing.Size(56, 26);
            this.textBoxXActual.TabIndex = 7;
            this.textBoxXActual.Text = "000";
            this.textBoxXActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButtonControl
            // 
            this.radioButtonControl.AutoSize = true;
            this.radioButtonControl.Location = new System.Drawing.Point(14, 29);
            this.radioButtonControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonControl.Name = "radioButtonControl";
            this.radioButtonControl.Size = new System.Drawing.Size(129, 24);
            this.radioButtonControl.TabIndex = 2;
            this.radioButtonControl.TabStop = true;
            this.radioButtonControl.Text = "Control Mode";
            this.radioButtonControl.UseVisualStyleBackColor = true;
            this.radioButtonControl.CheckedChanged += new System.EventHandler(this.radioButtonControl_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonMonitor);
            this.groupBox3.Controls.Add(this.radioButtonControl);
            this.groupBox3.Location = new System.Drawing.Point(4, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(294, 65);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Control Mode";
            // 
            // radioButtonMonitor
            // 
            this.radioButtonMonitor.AutoSize = true;
            this.radioButtonMonitor.Location = new System.Drawing.Point(150, 29);
            this.radioButtonMonitor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonMonitor.Name = "radioButtonMonitor";
            this.radioButtonMonitor.Size = new System.Drawing.Size(131, 24);
            this.radioButtonMonitor.TabIndex = 3;
            this.radioButtonMonitor.TabStop = true;
            this.radioButtonMonitor.Text = "Monitor Mode";
            this.radioButtonMonitor.UseVisualStyleBackColor = true;
            this.radioButtonMonitor.CheckedChanged += new System.EventHandler(this.radioButtonMonitor_CheckedChanged);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(351, 368);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(112, 35);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelOPCConnected
            // 
            this.labelOPCConnected.AutoSize = true;
            this.labelOPCConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOPCConnected.ForeColor = System.Drawing.Color.Green;
            this.labelOPCConnected.Location = new System.Drawing.Point(308, 14);
            this.labelOPCConnected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOPCConnected.Name = "labelOPCConnected";
            this.labelOPCConnected.Size = new System.Drawing.Size(184, 20);
            this.labelOPCConnected.TabIndex = 7;
            this.labelOPCConnected.Text = "OPC Server Connected";
            // 
            // labelGEMINICConnected
            // 
            this.labelGEMINICConnected.AutoSize = true;
            this.labelGEMINICConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGEMINICConnected.ForeColor = System.Drawing.Color.Green;
            this.labelGEMINICConnected.Location = new System.Drawing.Point(334, 37);
            this.labelGEMINICConnected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGEMINICConnected.Name = "labelGEMINICConnected";
            this.labelGEMINICConnected.Size = new System.Drawing.Size(152, 20);
            this.labelGEMINICConnected.TabIndex = 8;
            this.labelGEMINICConnected.Text = "GEMINI Connected";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonMonitor
            // 
            this.buttonMonitor.Location = new System.Drawing.Point(334, 75);
            this.buttonMonitor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonMonitor.Name = "buttonMonitor";
            this.buttonMonitor.Size = new System.Drawing.Size(112, 35);
            this.buttonMonitor.TabIndex = 7;
            this.buttonMonitor.Text = "Monitor";
            this.buttonMonitor.UseVisualStyleBackColor = true;
            this.buttonMonitor.Click += new System.EventHandler(this.buttonMonitor_Click);
            // 
            // FormMelsofGEMINIControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 419);
            this.Controls.Add(this.labelGEMINICConnected);
            this.Controls.Add(this.labelOPCConnected);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMelsofGEMINIControl";
            this.Text = "Melsof GEMINI Control";
            this.Load += new System.EventHandler(this.FormMelsofGEMINIControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSrvON;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxYTarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxXTarget;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonControl;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonMonitor;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxYActual;
        private System.Windows.Forms.TextBox textBoxXActual;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelOPCConnected;
        private System.Windows.Forms.Label labelGEMINICConnected;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonMonitor;
    }
}