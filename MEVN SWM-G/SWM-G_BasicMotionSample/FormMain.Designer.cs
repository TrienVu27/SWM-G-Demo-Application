namespace BasicMotionSample
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonStartEng = new System.Windows.Forms.Button();
            this.buttonStartComm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelEngCommstat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonIOMonitor = new System.Windows.Forms.Button();
            this.buttonAlarmMonitor = new System.Windows.Forms.Button();
            this.buttonAxesMonitor = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonMultiMotionCtrl = new System.Windows.Forms.Button();
            this.buttonSyncMotionCtrl = new System.Windows.Forms.Button();
            this.buttonMotionContiCtrl = new System.Windows.Forms.Button();
            this.buttonMotionCtrl = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonSdoBatch = new System.Windows.Forms.Button();
            this.buttonSdoRW = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartEng
            // 
            this.buttonStartEng.Location = new System.Drawing.Point(6, 20);
            this.buttonStartEng.Name = "buttonStartEng";
            this.buttonStartEng.Size = new System.Drawing.Size(136, 24);
            this.buttonStartEng.TabIndex = 3;
            this.buttonStartEng.Text = "Engine Start";
            this.buttonStartEng.UseVisualStyleBackColor = true;
            this.buttonStartEng.Click += new System.EventHandler(this.buttonStartEng_Click);
            // 
            // buttonStartComm
            // 
            this.buttonStartComm.Location = new System.Drawing.Point(148, 20);
            this.buttonStartComm.Name = "buttonStartComm";
            this.buttonStartComm.Size = new System.Drawing.Size(130, 24);
            this.buttonStartComm.TabIndex = 4;
            this.buttonStartComm.Text = "Communication Start";
            this.buttonStartComm.UseVisualStyleBackColor = true;
            this.buttonStartComm.Click += new System.EventHandler(this.buttonStartComm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelEngCommstat);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonStartEng);
            this.groupBox1.Controls.Add(this.buttonStartComm);
            this.groupBox1.Location = new System.Drawing.Point(15, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 93);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Engine Information";
            // 
            // labelEngCommstat
            // 
            this.labelEngCommstat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelEngCommstat.Location = new System.Drawing.Point(148, 55);
            this.labelEngCommstat.Name = "labelEngCommstat";
            this.labelEngCommstat.Size = new System.Drawing.Size(130, 24);
            this.labelEngCommstat.TabIndex = 6;
            this.labelEngCommstat.Text = "Stoppped";
            this.labelEngCommstat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Engine state";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonIOMonitor);
            this.groupBox2.Controls.Add(this.buttonAlarmMonitor);
            this.groupBox2.Controls.Add(this.buttonAxesMonitor);
            this.groupBox2.Location = new System.Drawing.Point(15, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 86);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Monitor";
            // 
            // buttonIOMonitor
            // 
            this.buttonIOMonitor.Location = new System.Drawing.Point(173, 21);
            this.buttonIOMonitor.Name = "buttonIOMonitor";
            this.buttonIOMonitor.Size = new System.Drawing.Size(160, 24);
            this.buttonIOMonitor.TabIndex = 1;
            this.buttonIOMonitor.Text = "IO Monitor";
            this.buttonIOMonitor.UseVisualStyleBackColor = true;
            this.buttonIOMonitor.Click += new System.EventHandler(this.buttonIOMonitor_Click);
            // 
            // buttonAlarmMonitor
            // 
            this.buttonAlarmMonitor.Location = new System.Drawing.Point(173, 52);
            this.buttonAlarmMonitor.Name = "buttonAlarmMonitor";
            this.buttonAlarmMonitor.Size = new System.Drawing.Size(160, 24);
            this.buttonAlarmMonitor.TabIndex = 0;
            this.buttonAlarmMonitor.Text = "Alarm Monitor";
            this.buttonAlarmMonitor.UseVisualStyleBackColor = true;
            this.buttonAlarmMonitor.Click += new System.EventHandler(this.buttonAlarmMonitor_Click);
            // 
            // buttonAxesMonitor
            // 
            this.buttonAxesMonitor.Location = new System.Drawing.Point(7, 21);
            this.buttonAxesMonitor.Name = "buttonAxesMonitor";
            this.buttonAxesMonitor.Size = new System.Drawing.Size(160, 24);
            this.buttonAxesMonitor.TabIndex = 0;
            this.buttonAxesMonitor.Text = "Axes Monitor";
            this.buttonAxesMonitor.UseVisualStyleBackColor = true;
            this.buttonAxesMonitor.Click += new System.EventHandler(this.buttonAxesMonitor_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.buttonMultiMotionCtrl);
            this.groupBox3.Controls.Add(this.buttonSyncMotionCtrl);
            this.groupBox3.Controls.Add(this.buttonMotionContiCtrl);
            this.groupBox3.Controls.Add(this.buttonMotionCtrl);
            this.groupBox3.Location = new System.Drawing.Point(15, 301);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 123);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Positioning Control/JOG Operation ";
            // 
            // buttonMultiMotionCtrl
            // 
            this.buttonMultiMotionCtrl.Location = new System.Drawing.Point(7, 57);
            this.buttonMultiMotionCtrl.Name = "buttonMultiMotionCtrl";
            this.buttonMultiMotionCtrl.Size = new System.Drawing.Size(160, 24);
            this.buttonMultiMotionCtrl.TabIndex = 3;
            this.buttonMultiMotionCtrl.Text = "Multi Axis Pos./JOG";
            this.buttonMultiMotionCtrl.UseVisualStyleBackColor = true;
            this.buttonMultiMotionCtrl.Click += new System.EventHandler(this.buttonMultiMotionCtrl_Click);
            // 
            // buttonSyncMotionCtrl
            // 
            this.buttonSyncMotionCtrl.Location = new System.Drawing.Point(173, 57);
            this.buttonSyncMotionCtrl.Name = "buttonSyncMotionCtrl";
            this.buttonSyncMotionCtrl.Size = new System.Drawing.Size(161, 24);
            this.buttonSyncMotionCtrl.TabIndex = 2;
            this.buttonSyncMotionCtrl.Text = "Sync Control";
            this.buttonSyncMotionCtrl.UseVisualStyleBackColor = true;
            this.buttonSyncMotionCtrl.Click += new System.EventHandler(this.buttonSyncMotionCtrl_Click);
            // 
            // buttonMotionContiCtrl
            // 
            this.buttonMotionContiCtrl.Location = new System.Drawing.Point(173, 21);
            this.buttonMotionContiCtrl.Name = "buttonMotionContiCtrl";
            this.buttonMotionContiCtrl.Size = new System.Drawing.Size(161, 24);
            this.buttonMotionContiCtrl.TabIndex = 1;
            this.buttonMotionContiCtrl.Text = "Single Axis Pos (Conti.)";
            this.buttonMotionContiCtrl.UseVisualStyleBackColor = true;
            this.buttonMotionContiCtrl.Click += new System.EventHandler(this.buttonMotionContiCtrl_Click);
            // 
            // buttonMotionCtrl
            // 
            this.buttonMotionCtrl.Location = new System.Drawing.Point(7, 21);
            this.buttonMotionCtrl.Name = "buttonMotionCtrl";
            this.buttonMotionCtrl.Size = new System.Drawing.Size(160, 24);
            this.buttonMotionCtrl.TabIndex = 0;
            this.buttonMotionCtrl.Text = "Single Axis Pos./JOG";
            this.buttonMotionCtrl.UseVisualStyleBackColor = true;
            this.buttonMotionCtrl.Click += new System.EventHandler(this.buttonMotionCtrl_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonSdoBatch);
            this.groupBox4.Controls.Add(this.buttonSdoRW);
            this.groupBox4.Location = new System.Drawing.Point(15, 424);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(341, 57);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SDO Control";
            // 
            // buttonSdoBatch
            // 
            this.buttonSdoBatch.Location = new System.Drawing.Point(173, 21);
            this.buttonSdoBatch.Name = "buttonSdoBatch";
            this.buttonSdoBatch.Size = new System.Drawing.Size(160, 24);
            this.buttonSdoBatch.TabIndex = 1;
            this.buttonSdoBatch.Text = "SDO Read/Write(Batch)";
            this.buttonSdoBatch.UseVisualStyleBackColor = true;
            this.buttonSdoBatch.Click += new System.EventHandler(this.buttonSdoBatch_Click);
            // 
            // buttonSdoRW
            // 
            this.buttonSdoRW.Location = new System.Drawing.Point(7, 21);
            this.buttonSdoRW.Name = "buttonSdoRW";
            this.buttonSdoRW.Size = new System.Drawing.Size(160, 24);
            this.buttonSdoRW.TabIndex = 0;
            this.buttonSdoRW.Text = "SDO Read/Write";
            this.buttonSdoRW.UseVisualStyleBackColor = true;
            this.buttonSdoRW.Click += new System.EventHandler(this.buttonSdoRW_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(216, 488);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(140, 24);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BasicMotionSample.Properties.Resources.ME_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "GEMINI Control";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 522);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "MEVN - Motion Software SWM-G Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonStartEng;
        private System.Windows.Forms.Button buttonStartComm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelEngCommstat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonAxesMonitor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonMotionContiCtrl;
        private System.Windows.Forms.Button buttonMotionCtrl;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonSdoBatch;
        private System.Windows.Forms.Button buttonSdoRW;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonSyncMotionCtrl;
        private System.Windows.Forms.Button buttonIOMonitor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonMultiMotionCtrl;
        private System.Windows.Forms.Button buttonAlarmMonitor;
        private System.Windows.Forms.Button button1;
    }
}

