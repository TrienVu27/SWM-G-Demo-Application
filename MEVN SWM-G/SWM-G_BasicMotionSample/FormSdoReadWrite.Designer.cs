namespace BasicMotionSample
{
    partial class FormSdoReadWrite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSdoReadWrite));
            this.buttonClose = new System.Windows.Forms.Button();
            this.comboLength = new System.Windows.Forms.ComboBox();
            this.labelDropNo1 = new System.Windows.Forms.Label();
            this.labelSlaveId1 = new System.Windows.Forms.Label();
            this.labellabelReadLength1 = new System.Windows.Forms.Label();
            this.labelSubIndex1 = new System.Windows.Forms.Label();
            this.labelIndex1 = new System.Windows.Forms.Label();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textDropNo = new System.Windows.Forms.TextBox();
            this.textSlaveID = new System.Windows.Forms.TextBox();
            this.textSubIndex = new System.Windows.Forms.TextBox();
            this.textIndex = new System.Windows.Forms.TextBox();
            this.textData = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(335, 144);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(187, 31);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // comboLength
            // 
            this.comboLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLength.FormattingEnabled = true;
            this.comboLength.Items.AddRange(new object[] {
            "1",
            "2",
            "4"});
            this.comboLength.Location = new System.Drawing.Point(428, 41);
            this.comboLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboLength.Name = "comboLength";
            this.comboLength.Size = new System.Drawing.Size(55, 24);
            this.comboLength.TabIndex = 4;
            // 
            // labelDropNo1
            // 
            this.labelDropNo1.AutoSize = true;
            this.labelDropNo1.Location = new System.Drawing.Point(191, 12);
            this.labelDropNo1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDropNo1.Name = "labelDropNo1";
            this.labelDropNo1.Size = new System.Drawing.Size(61, 17);
            this.labelDropNo1.TabIndex = 7;
            this.labelDropNo1.Text = "Drop No";
            // 
            // labelSlaveId1
            // 
            this.labelSlaveId1.AutoSize = true;
            this.labelSlaveId1.Location = new System.Drawing.Point(16, 12);
            this.labelSlaveId1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSlaveId1.Name = "labelSlaveId1";
            this.labelSlaveId1.Size = new System.Drawing.Size(56, 17);
            this.labelSlaveId1.TabIndex = 5;
            this.labelSlaveId1.Text = "SlaveID";
            // 
            // labellabelReadLength1
            // 
            this.labellabelReadLength1.AutoSize = true;
            this.labellabelReadLength1.Location = new System.Drawing.Point(368, 47);
            this.labellabelReadLength1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labellabelReadLength1.Name = "labellabelReadLength1";
            this.labellabelReadLength1.Size = new System.Drawing.Size(52, 17);
            this.labellabelReadLength1.TabIndex = 10;
            this.labellabelReadLength1.Text = "Length";
            // 
            // labelSubIndex1
            // 
            this.labelSubIndex1.AutoSize = true;
            this.labelSubIndex1.Location = new System.Drawing.Point(191, 47);
            this.labelSubIndex1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSubIndex1.Name = "labelSubIndex1";
            this.labelSubIndex1.Size = new System.Drawing.Size(104, 17);
            this.labelSubIndex1.TabIndex = 8;
            this.labelSubIndex1.Text = "SubIndex(HEX)";
            // 
            // labelIndex1
            // 
            this.labelIndex1.AutoSize = true;
            this.labelIndex1.Location = new System.Drawing.Point(16, 47);
            this.labelIndex1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIndex1.Name = "labelIndex1";
            this.labelIndex1.Size = new System.Drawing.Size(79, 17);
            this.labelIndex1.TabIndex = 6;
            this.labelIndex1.Text = "Index(HEX)";
            // 
            // buttonWrite
            // 
            this.buttonWrite.Location = new System.Drawing.Point(335, 109);
            this.buttonWrite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(187, 27);
            this.buttonWrite.TabIndex = 7;
            this.buttonWrite.Text = "Write";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(140, 109);
            this.buttonRead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(187, 27);
            this.buttonRead.TabIndex = 6;
            this.buttonRead.Text = "Read";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "Data(HEX)";
            // 
            // textDropNo
            // 
            this.textDropNo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.textDropNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textDropNo.Location = new System.Drawing.Point(301, 8);
            this.textDropNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textDropNo.MaxLength = 1;
            this.textDropNo.Name = "textDropNo";
            this.textDropNo.Size = new System.Drawing.Size(52, 22);
            this.textDropNo.TabIndex = 1;
            this.textDropNo.Text = "0";
            this.textDropNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textDropNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textHex_KeyPress);
            // 
            // textSlaveID
            // 
            this.textSlaveID.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.textSlaveID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textSlaveID.Location = new System.Drawing.Point(113, 8);
            this.textSlaveID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textSlaveID.MaxLength = 3;
            this.textSlaveID.Name = "textSlaveID";
            this.textSlaveID.Size = new System.Drawing.Size(52, 22);
            this.textSlaveID.TabIndex = 0;
            this.textSlaveID.Text = "0";
            this.textSlaveID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textSlaveID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textHex_KeyPress);
            // 
            // textSubIndex
            // 
            this.textSubIndex.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.textSubIndex.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textSubIndex.Location = new System.Drawing.Point(301, 43);
            this.textSubIndex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textSubIndex.MaxLength = 2;
            this.textSubIndex.Name = "textSubIndex";
            this.textSubIndex.Size = new System.Drawing.Size(52, 22);
            this.textSubIndex.TabIndex = 3;
            this.textSubIndex.Text = "0";
            this.textSubIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textSubIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textHex_KeyPress);
            // 
            // textIndex
            // 
            this.textIndex.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.textIndex.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textIndex.Location = new System.Drawing.Point(113, 43);
            this.textIndex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textIndex.MaxLength = 4;
            this.textIndex.Name = "textIndex";
            this.textIndex.Size = new System.Drawing.Size(52, 22);
            this.textIndex.TabIndex = 2;
            this.textIndex.Text = "6060";
            this.textIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textHex_KeyPress);
            // 
            // textData
            // 
            this.textData.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.textData.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textData.Location = new System.Drawing.Point(113, 76);
            this.textData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textData.MaxLength = 16;
            this.textData.Name = "textData";
            this.textData.Size = new System.Drawing.Size(139, 22);
            this.textData.TabIndex = 5;
            this.textData.Text = "00";
            this.textData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textHex_KeyPress);
            // 
            // FormSdoReadWrite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 192);
            this.Controls.Add(this.textData);
            this.Controls.Add(this.textDropNo);
            this.Controls.Add(this.textSlaveID);
            this.Controls.Add(this.textSubIndex);
            this.Controls.Add(this.textIndex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonWrite);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.comboLength);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelDropNo1);
            this.Controls.Add(this.labelSlaveId1);
            this.Controls.Add(this.labelIndex1);
            this.Controls.Add(this.labelSubIndex1);
            this.Controls.Add(this.labellabelReadLength1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSdoReadWrite";
            this.ShowInTaskbar = false;
            this.Text = "SDO Read/Write";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSdoReadWrite_FormClosed);
            this.Load += new System.EventHandler(this.FormSdoReadWrite_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox comboLength;
        private System.Windows.Forms.Label labelDropNo1;
        private System.Windows.Forms.Label labelSlaveId1;
        private System.Windows.Forms.Label labellabelReadLength1;
        private System.Windows.Forms.Label labelSubIndex1;
        private System.Windows.Forms.Label labelIndex1;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDropNo;
        private System.Windows.Forms.TextBox textSlaveID;
        private System.Windows.Forms.TextBox textSubIndex;
        private System.Windows.Forms.TextBox textIndex;
        private System.Windows.Forms.TextBox textData;
    }
}