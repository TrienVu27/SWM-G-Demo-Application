
namespace BasicMotionSample
{
    partial class FormMultiMotionControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMultiMotionControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SyncAxes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAllAxisSyncOFF = new System.Windows.Forms.Button();
            this.buttonAllAxisSyncON = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timerMonitor = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonAlarmReset = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonAllServoOFF = new System.Windows.Forms.Button();
            this.buttonAllServoON = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.labelStatus = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.buttonAllAxisSyncOFF);
            this.groupBox2.Controls.Add(this.buttonAllAxisSyncON);
            this.groupBox2.Controls.Add(this.dataGridView);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SyncAxes});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.Height = 18;
            // 
            // SyncAxes
            // 
            resources.ApplyResources(this.SyncAxes, "SyncAxes");
            this.SyncAxes.Name = "SyncAxes";
            this.SyncAxes.ReadOnly = true;
            // 
            // buttonAllAxisSyncOFF
            // 
            resources.ApplyResources(this.buttonAllAxisSyncOFF, "buttonAllAxisSyncOFF");
            this.buttonAllAxisSyncOFF.Name = "buttonAllAxisSyncOFF";
            this.buttonAllAxisSyncOFF.UseVisualStyleBackColor = true;
            this.buttonAllAxisSyncOFF.Click += new System.EventHandler(this.buttonAllAxisSyncOFF_Click);
            // 
            // buttonAllAxisSyncON
            // 
            resources.ApplyResources(this.buttonAllAxisSyncON, "buttonAllAxisSyncON");
            this.buttonAllAxisSyncON.Name = "buttonAllAxisSyncON";
            this.buttonAllAxisSyncON.UseVisualStyleBackColor = true;
            this.buttonAllAxisSyncON.Click += new System.EventHandler(this.buttonAllAxisSyncON_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            resources.ApplyResources(this.dataGridView, "dataGridView");
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.Text = "Enable";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1"),
            resources.GetString("comboBox1.Items2"),
            resources.GetString("comboBox1.Items3"),
            resources.GetString("comboBox1.Items4"),
            resources.GetString("comboBox1.Items5"),
            resources.GetString("comboBox1.Items6"),
            resources.GetString("comboBox1.Items7"),
            resources.GetString("comboBox1.Items8"),
            resources.GetString("comboBox1.Items9"),
            resources.GetString("comboBox1.Items10"),
            resources.GetString("comboBox1.Items11"),
            resources.GetString("comboBox1.Items12"),
            resources.GetString("comboBox1.Items13"),
            resources.GetString("comboBox1.Items14"),
            resources.GetString("comboBox1.Items15"),
            resources.GetString("comboBox1.Items16"),
            resources.GetString("comboBox1.Items17"),
            resources.GetString("comboBox1.Items18"),
            resources.GetString("comboBox1.Items19"),
            resources.GetString("comboBox1.Items20"),
            resources.GetString("comboBox1.Items21"),
            resources.GetString("comboBox1.Items22"),
            resources.GetString("comboBox1.Items23"),
            resources.GetString("comboBox1.Items24"),
            resources.GetString("comboBox1.Items25"),
            resources.GetString("comboBox1.Items26"),
            resources.GetString("comboBox1.Items27"),
            resources.GetString("comboBox1.Items28"),
            resources.GetString("comboBox1.Items29"),
            resources.GetString("comboBox1.Items30"),
            resources.GetString("comboBox1.Items31"),
            resources.GetString("comboBox1.Items32"),
            resources.GetString("comboBox1.Items33"),
            resources.GetString("comboBox1.Items34"),
            resources.GetString("comboBox1.Items35"),
            resources.GetString("comboBox1.Items36"),
            resources.GetString("comboBox1.Items37"),
            resources.GetString("comboBox1.Items38"),
            resources.GetString("comboBox1.Items39"),
            resources.GetString("comboBox1.Items40"),
            resources.GetString("comboBox1.Items41"),
            resources.GetString("comboBox1.Items42"),
            resources.GetString("comboBox1.Items43"),
            resources.GetString("comboBox1.Items44"),
            resources.GetString("comboBox1.Items45"),
            resources.GetString("comboBox1.Items46"),
            resources.GetString("comboBox1.Items47"),
            resources.GetString("comboBox1.Items48"),
            resources.GetString("comboBox1.Items49"),
            resources.GetString("comboBox1.Items50"),
            resources.GetString("comboBox1.Items51"),
            resources.GetString("comboBox1.Items52"),
            resources.GetString("comboBox1.Items53"),
            resources.GetString("comboBox1.Items54"),
            resources.GetString("comboBox1.Items55"),
            resources.GetString("comboBox1.Items56"),
            resources.GetString("comboBox1.Items57"),
            resources.GetString("comboBox1.Items58"),
            resources.GetString("comboBox1.Items59"),
            resources.GetString("comboBox1.Items60"),
            resources.GetString("comboBox1.Items61"),
            resources.GetString("comboBox1.Items62"),
            resources.GetString("comboBox1.Items63"),
            resources.GetString("comboBox1.Items64"),
            resources.GetString("comboBox1.Items65"),
            resources.GetString("comboBox1.Items66"),
            resources.GetString("comboBox1.Items67"),
            resources.GetString("comboBox1.Items68"),
            resources.GetString("comboBox1.Items69"),
            resources.GetString("comboBox1.Items70"),
            resources.GetString("comboBox1.Items71"),
            resources.GetString("comboBox1.Items72"),
            resources.GetString("comboBox1.Items73"),
            resources.GetString("comboBox1.Items74"),
            resources.GetString("comboBox1.Items75"),
            resources.GetString("comboBox1.Items76"),
            resources.GetString("comboBox1.Items77"),
            resources.GetString("comboBox1.Items78"),
            resources.GetString("comboBox1.Items79"),
            resources.GetString("comboBox1.Items80"),
            resources.GetString("comboBox1.Items81"),
            resources.GetString("comboBox1.Items82"),
            resources.GetString("comboBox1.Items83"),
            resources.GetString("comboBox1.Items84"),
            resources.GetString("comboBox1.Items85"),
            resources.GetString("comboBox1.Items86"),
            resources.GetString("comboBox1.Items87"),
            resources.GetString("comboBox1.Items88"),
            resources.GetString("comboBox1.Items89"),
            resources.GetString("comboBox1.Items90"),
            resources.GetString("comboBox1.Items91"),
            resources.GetString("comboBox1.Items92"),
            resources.GetString("comboBox1.Items93"),
            resources.GetString("comboBox1.Items94"),
            resources.GetString("comboBox1.Items95"),
            resources.GetString("comboBox1.Items96"),
            resources.GetString("comboBox1.Items97"),
            resources.GetString("comboBox1.Items98"),
            resources.GetString("comboBox1.Items99"),
            resources.GetString("comboBox1.Items100"),
            resources.GetString("comboBox1.Items101"),
            resources.GetString("comboBox1.Items102"),
            resources.GetString("comboBox1.Items103"),
            resources.GetString("comboBox1.Items104"),
            resources.GetString("comboBox1.Items105"),
            resources.GetString("comboBox1.Items106"),
            resources.GetString("comboBox1.Items107"),
            resources.GetString("comboBox1.Items108"),
            resources.GetString("comboBox1.Items109"),
            resources.GetString("comboBox1.Items110"),
            resources.GetString("comboBox1.Items111"),
            resources.GetString("comboBox1.Items112"),
            resources.GetString("comboBox1.Items113"),
            resources.GetString("comboBox1.Items114"),
            resources.GetString("comboBox1.Items115"),
            resources.GetString("comboBox1.Items116"),
            resources.GetString("comboBox1.Items117"),
            resources.GetString("comboBox1.Items118"),
            resources.GetString("comboBox1.Items119"),
            resources.GetString("comboBox1.Items120"),
            resources.GetString("comboBox1.Items121"),
            resources.GetString("comboBox1.Items122"),
            resources.GetString("comboBox1.Items123"),
            resources.GetString("comboBox1.Items124"),
            resources.GetString("comboBox1.Items125"),
            resources.GetString("comboBox1.Items126"),
            resources.GetString("comboBox1.Items127")});
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // timerMonitor
            // 
            this.timerMonitor.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonAlarmReset);
            this.groupBox4.Controls.Add(this.buttonPause);
            this.groupBox4.Controls.Add(this.buttonStart);
            this.groupBox4.Controls.Add(this.buttonStop);
            this.groupBox4.Controls.Add(this.buttonHome);
            this.groupBox4.Controls.Add(this.buttonAllServoOFF);
            this.groupBox4.Controls.Add(this.buttonAllServoON);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // buttonAlarmReset
            // 
            resources.ApplyResources(this.buttonAlarmReset, "buttonAlarmReset");
            this.buttonAlarmReset.Name = "buttonAlarmReset";
            this.buttonAlarmReset.UseVisualStyleBackColor = true;
            this.buttonAlarmReset.Click += new System.EventHandler(this.buttonAlarmReset_Click);
            // 
            // buttonPause
            // 
            resources.ApplyResources(this.buttonPause, "buttonPause");
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStart
            // 
            resources.ApplyResources(this.buttonStart, "buttonStart");
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            resources.ApplyResources(this.buttonStop, "buttonStop");
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonHome
            // 
            resources.ApplyResources(this.buttonHome, "buttonHome");
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonAllServoOFF
            // 
            resources.ApplyResources(this.buttonAllServoOFF, "buttonAllServoOFF");
            this.buttonAllServoOFF.Name = "buttonAllServoOFF";
            this.buttonAllServoOFF.UseVisualStyleBackColor = true;
            this.buttonAllServoOFF.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAllServoON
            // 
            resources.ApplyResources(this.buttonAllServoON, "buttonAllServoON");
            this.buttonAllServoON.Name = "buttonAllServoON";
            this.buttonAllServoON.UseVisualStyleBackColor = true;
            this.buttonAllServoON.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Controls.Add(this.labelStatus);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            resources.GetString("comboBox2.Items"),
            resources.GetString("comboBox2.Items1"),
            resources.GetString("comboBox2.Items2"),
            resources.GetString("comboBox2.Items3"),
            resources.GetString("comboBox2.Items4"),
            resources.GetString("comboBox2.Items5"),
            resources.GetString("comboBox2.Items6"),
            resources.GetString("comboBox2.Items7"),
            resources.GetString("comboBox2.Items8"),
            resources.GetString("comboBox2.Items9"),
            resources.GetString("comboBox2.Items10"),
            resources.GetString("comboBox2.Items11"),
            resources.GetString("comboBox2.Items12"),
            resources.GetString("comboBox2.Items13"),
            resources.GetString("comboBox2.Items14"),
            resources.GetString("comboBox2.Items15"),
            resources.GetString("comboBox2.Items16"),
            resources.GetString("comboBox2.Items17"),
            resources.GetString("comboBox2.Items18"),
            resources.GetString("comboBox2.Items19"),
            resources.GetString("comboBox2.Items20"),
            resources.GetString("comboBox2.Items21"),
            resources.GetString("comboBox2.Items22"),
            resources.GetString("comboBox2.Items23"),
            resources.GetString("comboBox2.Items24")});
            resources.ApplyResources(this.comboBox2, "comboBox2");
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dataGridView2, "dataGridView2");
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 21;
            // 
            // labelStatus
            // 
            this.labelStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.labelStatus, "labelStatus");
            this.labelStatus.Name = "labelStatus";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeColumns = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dataGridView3, "dataGridView3");
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowTemplate.Height = 21;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridView3);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // FormMultiMotionControl
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormMultiMotionControl";
            this.Load += new System.EventHandler(this.FormMultiMotionControl_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonAllAxisSyncOFF;
        private System.Windows.Forms.Button buttonAllAxisSyncON;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerMonitor;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonAllServoOFF;
        private System.Windows.Forms.Button buttonAllServoON;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAlarmReset;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncAxes;
    }
}