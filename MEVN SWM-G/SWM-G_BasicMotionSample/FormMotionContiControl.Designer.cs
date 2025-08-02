namespace BasicMotionSample
{
    partial class FormMotionContiControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMotionContiControl));
            this.label1 = new System.Windows.Forms.Label();
            this.textAxis = new System.Windows.Forms.TextBox();
            this.groupStanbyType = new System.Windows.Forms.GroupBox();
            this.radioStanbyType2 = new System.Windows.Forms.RadioButton();
            this.radioStanbyType1 = new System.Windows.Forms.RadioButton();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonServoON = new System.Windows.Forms.Button();
            this.timerMonitor = new System.Windows.Forms.Timer(this.components);
            this.groupStanbyType.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Axis";
            // 
            // textAxis
            // 
            this.textAxis.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textAxis.Location = new System.Drawing.Point(62, 18);
            this.textAxis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textAxis.Name = "textAxis";
            this.textAxis.Size = new System.Drawing.Size(48, 22);
            this.textAxis.TabIndex = 0;
            this.textAxis.Text = "0";
            this.textAxis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textAxis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAxis_KeyPress);
            // 
            // groupStanbyType
            // 
            this.groupStanbyType.Controls.Add(this.radioStanbyType2);
            this.groupStanbyType.Controls.Add(this.radioStanbyType1);
            this.groupStanbyType.Location = new System.Drawing.Point(20, 54);
            this.groupStanbyType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupStanbyType.Name = "groupStanbyType";
            this.groupStanbyType.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupStanbyType.Size = new System.Drawing.Size(644, 66);
            this.groupStanbyType.TabIndex = 2;
            this.groupStanbyType.TabStop = false;
            this.groupStanbyType.Text = "Continuous standby type";
            // 
            // radioStanbyType2
            // 
            this.radioStanbyType2.AutoSize = true;
            this.radioStanbyType2.Location = new System.Drawing.Point(258, 24);
            this.radioStanbyType2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioStanbyType2.Name = "radioStanbyType2";
            this.radioStanbyType2.Size = new System.Drawing.Size(322, 21);
            this.radioStanbyType2.TabIndex = 1;
            this.radioStanbyType2.Text = "Waiting in trigger motion (Remaining Distance)";
            this.radioStanbyType2.UseVisualStyleBackColor = true;
            // 
            // radioStanbyType1
            // 
            this.radioStanbyType1.AutoSize = true;
            this.radioStanbyType1.Checked = true;
            this.radioStanbyType1.Location = new System.Drawing.Point(24, 26);
            this.radioStanbyType1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioStanbyType1.Name = "radioStanbyType1";
            this.radioStanbyType1.Size = new System.Drawing.Size(204, 21);
            this.radioStanbyType1.TabIndex = 0;
            this.radioStanbyType1.TabStop = true;
            this.radioStanbyType1.Text = "Waiting on Idle in axial state";
            this.radioStanbyType1.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(32, 30);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(100, 30);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(140, 30);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(100, 30);
            this.buttonPause.TabIndex = 1;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dataGridView);
            this.groupBox2.Controls.Add(this.labelStatus);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.buttonStart);
            this.groupBox2.Controls.Add(this.buttonPause);
            this.groupBox2.Location = new System.Drawing.Point(20, 128);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(644, 430);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Continuous operation";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Positioning point";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeight = 34;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.dataGridView.Location = new System.Drawing.Point(24, 92);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 21;
            this.dataGridView.Size = new System.Drawing.Size(549, 314);
            this.dataGridView.TabIndex = 9;
            this.dataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_EditingControlShowing);
            // 
            // labelStatus
            // 
            this.labelStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelStatus.Location = new System.Drawing.Point(428, 30);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(168, 30);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "Not executed";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(296, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Execution state";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(477, 568);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(187, 28);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonServoON
            // 
            this.buttonServoON.Location = new System.Drawing.Point(120, 16);
            this.buttonServoON.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonServoON.Name = "buttonServoON";
            this.buttonServoON.Size = new System.Drawing.Size(147, 30);
            this.buttonServoON.TabIndex = 1;
            this.buttonServoON.Text = "Servo ON";
            this.buttonServoON.UseVisualStyleBackColor = true;
            this.buttonServoON.Click += new System.EventHandler(this.buttonServoON_Click);
            // 
            // timerMonitor
            // 
            this.timerMonitor.Interval = 1;
            this.timerMonitor.Tick += new System.EventHandler(this.timerMonitor_Tick);
            // 
            // FormMotionContiControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 610);
            this.Controls.Add(this.buttonServoON);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupStanbyType);
            this.Controls.Add(this.textAxis);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMotionContiControl";
            this.ShowInTaskbar = false;
            this.Text = "Single axis Positioning  (Continuous)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMotionContiControl_FormClosed);
            this.Load += new System.EventHandler(this.FormMotionContiControl_Load);
            this.groupStanbyType.ResumeLayout(false);
            this.groupStanbyType.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textAxis;
        private System.Windows.Forms.GroupBox groupStanbyType;
        private System.Windows.Forms.RadioButton radioStanbyType2;
        private System.Windows.Forms.RadioButton radioStanbyType1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonServoON;
        private System.Windows.Forms.Timer timerMonitor;
    }
}