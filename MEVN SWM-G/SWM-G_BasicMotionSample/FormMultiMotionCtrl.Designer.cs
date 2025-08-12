
namespace BasicMotionSample
{
    partial class FormMultiMotionCtrl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMultiMotionCtrl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonParameters = new System.Windows.Forms.Button();
            this.buttonWRITE = new System.Windows.Forms.Button();
            this.buttonREAD = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.comboBoxAxesGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Axis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ready = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SrvON = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Home = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Reset = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TargetPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Velocity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ABSRELcheck = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ABSREL = new System.Windows.Forms.DataGridViewButtonColumn();
            this.JOGSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JOGdown = new System.Windows.Forms.DataGridViewButtonColumn();
            this.JOGup = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonParameters);
            this.groupBox1.Controls.Add(this.buttonWRITE);
            this.groupBox1.Controls.Add(this.buttonREAD);
            this.groupBox1.Controls.Add(this.buttonNext);
            this.groupBox1.Controls.Add(this.buttonPrev);
            this.groupBox1.Controls.Add(this.comboBoxAxesGroup);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(873, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initialize Parameters";
            // 
            // buttonParameters
            // 
            this.buttonParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonParameters.Location = new System.Drawing.Point(747, 28);
            this.buttonParameters.Margin = new System.Windows.Forms.Padding(4);
            this.buttonParameters.Name = "buttonParameters";
            this.buttonParameters.Size = new System.Drawing.Size(109, 26);
            this.buttonParameters.TabIndex = 4;
            this.buttonParameters.Text = "Parameters";
            this.buttonParameters.UseVisualStyleBackColor = true;
            // 
            // buttonWRITE
            // 
            this.buttonWRITE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWRITE.Location = new System.Drawing.Point(607, 28);
            this.buttonWRITE.Margin = new System.Windows.Forms.Padding(4);
            this.buttonWRITE.Name = "buttonWRITE";
            this.buttonWRITE.Size = new System.Drawing.Size(88, 26);
            this.buttonWRITE.TabIndex = 3;
            this.buttonWRITE.Text = "WRITE";
            this.buttonWRITE.UseVisualStyleBackColor = true;
            // 
            // buttonREAD
            // 
            this.buttonREAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonREAD.Location = new System.Drawing.Point(519, 28);
            this.buttonREAD.Margin = new System.Windows.Forms.Padding(4);
            this.buttonREAD.Name = "buttonREAD";
            this.buttonREAD.Size = new System.Drawing.Size(88, 26);
            this.buttonREAD.TabIndex = 2;
            this.buttonREAD.Text = "READ";
            this.buttonREAD.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.Location = new System.Drawing.Point(329, 28);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(39, 26);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrev.Location = new System.Drawing.Point(289, 28);
            this.buttonPrev.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(39, 26);
            this.buttonPrev.TabIndex = 0;
            this.buttonPrev.Text = "<";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // comboBoxAxesGroup
            // 
            this.comboBoxAxesGroup.FormattingEnabled = true;
            this.comboBoxAxesGroup.Items.AddRange(new object[] {
            "000 ~ 009",
            "010 ~ 019",
            "020 ~ 029",
            "030 ~ 039",
            "040 ~ 049",
            "050 ~ 059",
            "060 ~ 069",
            "070 ~ 079",
            "080 ~ 089",
            "090 ~ 099",
            "100 ~ 109",
            "110 ~ 119",
            "120 ~ 127"});
            this.comboBoxAxesGroup.Location = new System.Drawing.Point(177, 28);
            this.comboBoxAxesGroup.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAxesGroup.Name = "comboBoxAxesGroup";
            this.comboBoxAxesGroup.Size = new System.Drawing.Size(108, 24);
            this.comboBoxAxesGroup.TabIndex = 0;
            this.comboBoxAxesGroup.Text = "000 ~ 009";
            this.comboBoxAxesGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxAxesGroup_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Axes Group :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(1, 81);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(873, 352);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Multi Control";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Axis,
            this.Ready,
            this.SrvON,
            this.Home,
            this.Reset,
            this.TargetPos,
            this.Velocity,
            this.ABSRELcheck,
            this.ABSREL,
            this.JOGSpeed,
            this.JOGdown,
            this.JOGup});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(11, 23);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(853, 320);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Axis
            // 
            this.Axis.HeaderText = "Axis";
            this.Axis.MinimumWidth = 6;
            this.Axis.Name = "Axis";
            this.Axis.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Axis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Axis.Width = 50;
            // 
            // Ready
            // 
            this.Ready.HeaderText = "Ready";
            this.Ready.MinimumWidth = 6;
            this.Ready.Name = "Ready";
            this.Ready.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Ready.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Ready.Width = 40;
            // 
            // SrvON
            // 
            this.SrvON.HeaderText = "SrvON";
            this.SrvON.MinimumWidth = 6;
            this.SrvON.Name = "SrvON";
            this.SrvON.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SrvON.Width = 45;
            // 
            // Home
            // 
            this.Home.HeaderText = "Home";
            this.Home.MinimumWidth = 6;
            this.Home.Name = "Home";
            this.Home.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Home.Width = 40;
            // 
            // Reset
            // 
            this.Reset.HeaderText = "Reset";
            this.Reset.MinimumWidth = 6;
            this.Reset.Name = "Reset";
            this.Reset.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Reset.Width = 40;
            // 
            // TargetPos
            // 
            this.TargetPos.HeaderText = "Target Pos";
            this.TargetPos.MinimumWidth = 6;
            this.TargetPos.Name = "TargetPos";
            this.TargetPos.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TargetPos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TargetPos.Width = 90;
            // 
            // Velocity
            // 
            this.Velocity.HeaderText = "Velocity";
            this.Velocity.MinimumWidth = 6;
            this.Velocity.Name = "Velocity";
            this.Velocity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Velocity.Width = 90;
            // 
            // ABSRELcheck
            // 
            this.ABSRELcheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ABSRELcheck.HeaderText = "";
            this.ABSRELcheck.MinimumWidth = 6;
            this.ABSRELcheck.Name = "ABSRELcheck";
            this.ABSRELcheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ABSRELcheck.Width = 20;
            // 
            // ABSREL
            // 
            this.ABSREL.HeaderText = "ABS/REL";
            this.ABSREL.MinimumWidth = 6;
            this.ABSREL.Name = "ABSREL";
            this.ABSREL.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ABSREL.Width = 70;
            // 
            // JOGSpeed
            // 
            this.JOGSpeed.HeaderText = "JOG Speed";
            this.JOGSpeed.MinimumWidth = 6;
            this.JOGSpeed.Name = "JOGSpeed";
            this.JOGSpeed.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.JOGSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.JOGSpeed.Width = 90;
            // 
            // JOGdown
            // 
            this.JOGdown.HeaderText = "JOG -";
            this.JOGdown.MinimumWidth = 6;
            this.JOGdown.Name = "JOGdown";
            this.JOGdown.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.JOGdown.Width = 30;
            // 
            // JOGup
            // 
            this.JOGup.HeaderText = "JOG +";
            this.JOGup.MinimumWidth = 6;
            this.JOGup.Name = "JOGup";
            this.JOGup.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.JOGup.Width = 30;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(678, 441);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(187, 30);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // FormMultiMotionCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 479);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMultiMotionCtrl";
            this.Text = "Multi axis Positioning/JOG Operation ";
            this.Load += new System.EventHandler(this.FormMultiMotionCtrl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.ComboBox comboBoxAxesGroup;
        private System.Windows.Forms.Button buttonParameters;
        private System.Windows.Forms.Button buttonWRITE;
        private System.Windows.Forms.Button buttonREAD;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Axis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ready;
        private System.Windows.Forms.DataGridViewButtonColumn SrvON;
        private System.Windows.Forms.DataGridViewButtonColumn Home;
        private System.Windows.Forms.DataGridViewButtonColumn Reset;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Velocity;
        private System.Windows.Forms.DataGridViewButtonColumn ABSRELcheck;
        private System.Windows.Forms.DataGridViewButtonColumn ABSREL;
        private System.Windows.Forms.DataGridViewTextBoxColumn JOGSpeed;
        private System.Windows.Forms.DataGridViewButtonColumn JOGdown;
        private System.Windows.Forms.DataGridViewButtonColumn JOGup;
        private System.Windows.Forms.Button buttonClose;
    }
}