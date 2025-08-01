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
            this.buttonStartEng = new System.Windows.Forms.Button();
            this.buttonStartComm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelEngCommstat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonIOMonitor = new System.Windows.Forms.Button();
            this.buttonAxesMonitor = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonMultiMotionContiCtrl = new System.Windows.Forms.Button();
            this.buttonMotionContiCtrl = new System.Windows.Forms.Button();
            this.buttonMotionCtrl = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonSdoBatch = new System.Windows.Forms.Button();
            this.buttonSdoRW = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartEng
            // 
            this.buttonStartEng.Location = new System.Drawing.Point(9, 30);
            this.buttonStartEng.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStartEng.Name = "buttonStartEng";
            this.buttonStartEng.Size = new System.Drawing.Size(204, 38);
            this.buttonStartEng.TabIndex = 3;
            this.buttonStartEng.Text = "Engine Start";
            this.buttonStartEng.UseVisualStyleBackColor = true;
            this.buttonStartEng.Click += new System.EventHandler(this.buttonStartEng_Click);
            // 
            // buttonStartComm
            // 
            this.buttonStartComm.Location = new System.Drawing.Point(222, 30);
            this.buttonStartComm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStartComm.Name = "buttonStartComm";
            this.buttonStartComm.Size = new System.Drawing.Size(195, 38);
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
            this.groupBox1.Location = new System.Drawing.Point(23, 171);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(512, 142);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Engine Information";
            // 
            // labelEngCommstat
            // 
            this.labelEngCommstat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelEngCommstat.Location = new System.Drawing.Point(222, 85);
            this.labelEngCommstat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEngCommstat.Name = "labelEngCommstat";
            this.labelEngCommstat.Size = new System.Drawing.Size(195, 37);
            this.labelEngCommstat.TabIndex = 6;
            this.labelEngCommstat.Text = "Stoppped";
            this.labelEngCommstat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Engine state";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonIOMonitor);
            this.groupBox2.Controls.Add(this.buttonAxesMonitor);
            this.groupBox2.Location = new System.Drawing.Point(23, 323);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(512, 87);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Monitor";
            // 
            // buttonIOMonitor
            // 
            this.buttonIOMonitor.Location = new System.Drawing.Point(260, 32);
            this.buttonIOMonitor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonIOMonitor.Name = "buttonIOMonitor";
            this.buttonIOMonitor.Size = new System.Drawing.Size(240, 38);
            this.buttonIOMonitor.TabIndex = 1;
            this.buttonIOMonitor.Text = "IO Monitor";
            this.buttonIOMonitor.UseVisualStyleBackColor = true;
            this.buttonIOMonitor.Click += new System.EventHandler(this.buttonIOMonitor_Click);
            // 
            // buttonAxesMonitor
            // 
            this.buttonAxesMonitor.Location = new System.Drawing.Point(10, 32);
            this.buttonAxesMonitor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAxesMonitor.Name = "buttonAxesMonitor";
            this.buttonAxesMonitor.Size = new System.Drawing.Size(240, 38);
            this.buttonAxesMonitor.TabIndex = 0;
            this.buttonAxesMonitor.Text = "Axes Monitor";
            this.buttonAxesMonitor.UseVisualStyleBackColor = true;
            this.buttonAxesMonitor.Click += new System.EventHandler(this.buttonAxesMonitor_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonMultiMotionContiCtrl);
            this.groupBox3.Controls.Add(this.buttonMotionContiCtrl);
            this.groupBox3.Controls.Add(this.buttonMotionCtrl);
            this.groupBox3.Location = new System.Drawing.Point(23, 421);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(512, 147);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Positioning Control/JOG Operation ";
            // 
            // buttonMultiMotionContiCtrl
            // 
            this.buttonMultiMotionContiCtrl.Location = new System.Drawing.Point(260, 88);
            this.buttonMultiMotionContiCtrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonMultiMotionContiCtrl.Name = "buttonMultiMotionContiCtrl";
            this.buttonMultiMotionContiCtrl.Size = new System.Drawing.Size(242, 38);
            this.buttonMultiMotionContiCtrl.TabIndex = 2;
            this.buttonMultiMotionContiCtrl.Text = "Sync Control";
            this.buttonMultiMotionContiCtrl.UseVisualStyleBackColor = true;
            this.buttonMultiMotionContiCtrl.Click += new System.EventHandler(this.buttonMultiMotionContiCtrl_Click);
            // 
            // buttonMotionContiCtrl
            // 
            this.buttonMotionContiCtrl.Location = new System.Drawing.Point(260, 32);
            this.buttonMotionContiCtrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonMotionContiCtrl.Name = "buttonMotionContiCtrl";
            this.buttonMotionContiCtrl.Size = new System.Drawing.Size(242, 38);
            this.buttonMotionContiCtrl.TabIndex = 1;
            this.buttonMotionContiCtrl.Text = "Single Axis Pos (Conti.)";
            this.buttonMotionContiCtrl.UseVisualStyleBackColor = true;
            this.buttonMotionContiCtrl.Click += new System.EventHandler(this.buttonMotionContiCtrl_Click);
            // 
            // buttonMotionCtrl
            // 
            this.buttonMotionCtrl.Location = new System.Drawing.Point(10, 32);
            this.buttonMotionCtrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonMotionCtrl.Name = "buttonMotionCtrl";
            this.buttonMotionCtrl.Size = new System.Drawing.Size(240, 38);
            this.buttonMotionCtrl.TabIndex = 0;
            this.buttonMotionCtrl.Text = "Single Axis Pos./JOG";
            this.buttonMotionCtrl.UseVisualStyleBackColor = true;
            this.buttonMotionCtrl.Click += new System.EventHandler(this.buttonMotionCtrl_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonSdoBatch);
            this.groupBox4.Controls.Add(this.buttonSdoRW);
            this.groupBox4.Location = new System.Drawing.Point(23, 578);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(512, 87);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SDO Control";
            // 
            // buttonSdoBatch
            // 
            this.buttonSdoBatch.Location = new System.Drawing.Point(260, 32);
            this.buttonSdoBatch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSdoBatch.Name = "buttonSdoBatch";
            this.buttonSdoBatch.Size = new System.Drawing.Size(240, 38);
            this.buttonSdoBatch.TabIndex = 1;
            this.buttonSdoBatch.Text = "SDO Read/Write(Batch)";
            this.buttonSdoBatch.UseVisualStyleBackColor = true;
            this.buttonSdoBatch.Click += new System.EventHandler(this.buttonSdoBatch_Click);
            // 
            // buttonSdoRW
            // 
            this.buttonSdoRW.Location = new System.Drawing.Point(10, 32);
            this.buttonSdoRW.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSdoRW.Name = "buttonSdoRW";
            this.buttonSdoRW.Size = new System.Drawing.Size(240, 38);
            this.buttonSdoRW.TabIndex = 0;
            this.buttonSdoRW.Text = "SDO Read/Write";
            this.buttonSdoRW.UseVisualStyleBackColor = true;
            this.buttonSdoRW.Click += new System.EventHandler(this.buttonSdoRW_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(325, 678);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(210, 38);
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
            this.pictureBox1.Image = global::BasicMotionSample.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(76, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(406, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 734);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
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
        private System.Windows.Forms.Button buttonMultiMotionContiCtrl;
        private System.Windows.Forms.Button buttonIOMonitor;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

