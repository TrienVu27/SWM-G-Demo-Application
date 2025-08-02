
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMultiMotionCtrl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAxesGroup = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Axis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ready = new System.Windows.Forms.DataGridViewButtonColumn();
            this.SrvON = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Home = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Reset = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TargetPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Velocity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ABSRELcheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ABSREL = new System.Windows.Forms.DataGridViewButtonColumn();
            this.JOGSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JOGdown = new System.Windows.Forms.DataGridViewButtonColumn();
            this.JOGup = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBoxAxesGroup);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initialize Parameters";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(1, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(655, 286);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Multi Control";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Axes Group :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.comboBoxAxesGroup.Location = new System.Drawing.Point(133, 23);
            this.comboBoxAxesGroup.Name = "comboBoxAxesGroup";
            this.comboBoxAxesGroup.Size = new System.Drawing.Size(82, 21);
            this.comboBoxAxesGroup.TabIndex = 0;
            this.comboBoxAxesGroup.Text = "000 ~ 009";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(217, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(247, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 21);
            this.button2.TabIndex = 1;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(389, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 21);
            this.button3.TabIndex = 2;
            this.button3.Text = "READ";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(455, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 21);
            this.button4.TabIndex = 3;
            this.button4.Text = "WRITE";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(565, 23);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(77, 21);
            this.button5.TabIndex = 4;
            this.button5.Text = "Parameters";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
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
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(8, 19);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(640, 260);
            this.dataGridView1.TabIndex = 2;
            // 
            // Axis
            // 
            this.Axis.HeaderText = "Axis";
            this.Axis.Name = "Axis";
            this.Axis.Width = 50;
            // 
            // Ready
            // 
            this.Ready.HeaderText = "Ready";
            this.Ready.Name = "Ready";
            this.Ready.Width = 40;
            // 
            // SrvON
            // 
            this.SrvON.HeaderText = "SrvON";
            this.SrvON.Name = "SrvON";
            this.SrvON.Width = 45;
            // 
            // Home
            // 
            this.Home.HeaderText = "Home";
            this.Home.Name = "Home";
            this.Home.Width = 40;
            // 
            // Reset
            // 
            this.Reset.HeaderText = "Reset";
            this.Reset.Name = "Reset";
            this.Reset.Width = 40;
            // 
            // TargetPos
            // 
            this.TargetPos.HeaderText = "Target Pos";
            this.TargetPos.Name = "TargetPos";
            this.TargetPos.Width = 90;
            // 
            // Velocity
            // 
            this.Velocity.HeaderText = "Velocity";
            this.Velocity.Name = "Velocity";
            this.Velocity.Width = 90;
            // 
            // ABSRELcheck
            // 
            this.ABSRELcheck.HeaderText = "";
            this.ABSRELcheck.Name = "ABSRELcheck";
            this.ABSRELcheck.Width = 20;
            // 
            // ABSREL
            // 
            this.ABSREL.HeaderText = "ABS/REL";
            this.ABSREL.Name = "ABSREL";
            this.ABSREL.Width = 70;
            // 
            // JOGSpeed
            // 
            this.JOGSpeed.HeaderText = "JOG Speed";
            this.JOGSpeed.Name = "JOGSpeed";
            this.JOGSpeed.Width = 90;
            // 
            // JOGdown
            // 
            this.JOGdown.HeaderText = "JOG -";
            this.JOGdown.Name = "JOGdown";
            this.JOGdown.Width = 30;
            // 
            // JOGup
            // 
            this.JOGup.HeaderText = "JOG +";
            this.JOGup.Name = "JOGup";
            this.JOGup.Width = 30;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.button10);
            this.groupBox3.Location = new System.Drawing.Point(1, 358);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(655, 56);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Checked Axis Control";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(565, 23);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(77, 21);
            this.button6.TabIndex = 4;
            this.button6.Text = "Parameters";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(455, 23);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(66, 21);
            this.button7.TabIndex = 3;
            this.button7.Text = "WRITE";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(389, 23);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(66, 21);
            this.button8.TabIndex = 2;
            this.button8.Text = "READ";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(217, 23);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(29, 21);
            this.button10.TabIndex = 0;
            this.button10.Text = "<";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(105, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "All Check";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(8, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "All Check";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FormMultiMotionCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 465);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormMultiMotionCtrl";
            this.Text = "Multi axis Positioning/JOG Operation ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxAxesGroup;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Axis;
        private System.Windows.Forms.DataGridViewButtonColumn Ready;
        private System.Windows.Forms.DataGridViewButtonColumn SrvON;
        private System.Windows.Forms.DataGridViewButtonColumn Home;
        private System.Windows.Forms.DataGridViewButtonColumn Reset;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Velocity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ABSRELcheck;
        private System.Windows.Forms.DataGridViewButtonColumn ABSREL;
        private System.Windows.Forms.DataGridViewTextBoxColumn JOGSpeed;
        private System.Windows.Forms.DataGridViewButtonColumn JOGdown;
        private System.Windows.Forms.DataGridViewButtonColumn JOGup;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}