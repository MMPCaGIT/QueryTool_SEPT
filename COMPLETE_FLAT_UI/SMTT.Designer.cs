namespace COMPLETE_FLAT_UI
{
    partial class SMTT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMTT));
            this.browseXLSX = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SmttCombo = new System.Windows.Forms.ComboBox();
            this.browseFile = new System.Windows.Forms.Button();
            this.combineBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.GenData = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_import_file_path = new System.Windows.Forms.Label();
            this.lbl_import_file = new System.Windows.Forms.Label();
            this.opt_MLM_ID = new System.Windows.Forms.CheckBox();
            this.btn_import = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.statusSMTT = new System.Windows.Forms.Label();
            this.browTxt = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SMTTpBar = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseXLSX
            // 
            this.browseXLSX.FileName = ".xlsx";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(383, 80);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 22);
            this.dateTimePicker1.TabIndex = 57;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(564, 80);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(125, 22);
            this.dateTimePicker2.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(323, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 59;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(525, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "To";
            // 
            // SmttCombo
            // 
            this.SmttCombo.FormattingEnabled = true;
            this.SmttCombo.Items.AddRange(new object[] {
            "By CRD",
            "By PODD",
            "Ship Date",
            "By Order"});
            this.SmttCombo.Location = new System.Drawing.Point(158, 80);
            this.SmttCombo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SmttCombo.Name = "SmttCombo";
            this.SmttCombo.Size = new System.Drawing.Size(157, 23);
            this.SmttCombo.TabIndex = 61;
            this.SmttCombo.SelectedIndexChanged += new System.EventHandler(this.SmttCombo_SelectedIndexChanged);
            // 
            // browseFile
            // 
            this.browseFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.browseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseFile.ForeColor = System.Drawing.Color.Transparent;
            this.browseFile.Location = new System.Drawing.Point(723, 208);
            this.browseFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.browseFile.Name = "browseFile";
            this.browseFile.Size = new System.Drawing.Size(94, 42);
            this.browseFile.TabIndex = 64;
            this.browseFile.Text = "Import";
            this.browseFile.UseVisualStyleBackColor = false;
            this.browseFile.Click += new System.EventHandler(this.browseFile_Click);
            // 
            // combineBtn
            // 
            this.combineBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.combineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combineBtn.ForeColor = System.Drawing.Color.Transparent;
            this.combineBtn.Location = new System.Drawing.Point(326, 398);
            this.combineBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.combineBtn.Name = "combineBtn";
            this.combineBtn.Size = new System.Drawing.Size(95, 39);
            this.combineBtn.TabIndex = 65;
            this.combineBtn.Text = "Combine";
            this.combineBtn.UseVisualStyleBackColor = false;
            this.combineBtn.Click += new System.EventHandler(this.combineBtn_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(594, 142);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 42);
            this.button1.TabIndex = 66;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(457, 398);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 39);
            this.button3.TabIndex = 67;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_2);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 70;
            this.label3.Text = "Step 1: Export Data";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.panel3.Location = new System.Drawing.Point(-18, 383);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1037, 3);
            this.panel3.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 173);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 16);
            this.label4.TabIndex = 72;
            this.label4.Text = "Step 2: Import Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 364);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 16);
            this.label5.TabIndex = 73;
            this.label5.Text = "Step 3: Combine Data";
            // 
            // richTextBox1
            // 
            this.richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.Location = new System.Drawing.Point(150, 250);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(553, 110);
            this.richTextBox1.TabIndex = 74;
            this.richTextBox1.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(69, 84);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 75;
            this.label6.Text = "Date Type";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.panel2.Location = new System.Drawing.Point(-23, 192);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1037, 2);
            this.panel2.TabIndex = 62;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.panel4.Location = new System.Drawing.Point(-23, 61);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1037, 1);
            this.panel4.TabIndex = 76;
            // 
            // GenData
            // 
            this.GenData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.GenData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenData.ForeColor = System.Drawing.Color.Transparent;
            this.GenData.Location = new System.Drawing.Point(492, 142);
            this.GenData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GenData.Name = "GenData";
            this.GenData.Size = new System.Drawing.Size(94, 42);
            this.GenData.TabIndex = 77;
            this.GenData.Text = "Generate";
            this.GenData.UseVisualStyleBackColor = false;
            this.GenData.Click += new System.EventHandler(this.GenData_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lbl_import_file_path);
            this.panel1.Controls.Add(this.lbl_import_file);
            this.panel1.Controls.Add(this.opt_MLM_ID);
            this.panel1.Controls.Add(this.btn_import);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.statusSMTT);
            this.panel1.Controls.Add(this.GenData);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.browTxt);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.combineBtn);
            this.panel1.Controls.Add(this.browseFile);
            this.panel1.Controls.Add(this.SmttCombo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Location = new System.Drawing.Point(-2, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 453);
            this.panel1.TabIndex = 1;
            // 
            // lbl_import_file_path
            // 
            this.lbl_import_file_path.AutoSize = true;
            this.lbl_import_file_path.Location = new System.Drawing.Point(342, 116);
            this.lbl_import_file_path.Name = "lbl_import_file_path";
            this.lbl_import_file_path.Size = new System.Drawing.Size(0, 15);
            this.lbl_import_file_path.TabIndex = 87;
            // 
            // lbl_import_file
            // 
            this.lbl_import_file.AutoSize = true;
            this.lbl_import_file.Location = new System.Drawing.Point(194, 117);
            this.lbl_import_file.Name = "lbl_import_file";
            this.lbl_import_file.Size = new System.Drawing.Size(143, 15);
            this.lbl_import_file.TabIndex = 86;
            this.lbl_import_file.Text = "Import File Path:";
            // 
            // opt_MLM_ID
            // 
            this.opt_MLM_ID.AutoSize = true;
            this.opt_MLM_ID.Checked = true;
            this.opt_MLM_ID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.opt_MLM_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_MLM_ID.ForeColor = System.Drawing.Color.Black;
            this.opt_MLM_ID.Location = new System.Drawing.Point(72, 114);
            this.opt_MLM_ID.Name = "opt_MLM_ID";
            this.opt_MLM_ID.Size = new System.Drawing.Size(116, 20);
            this.opt_MLM_ID.TabIndex = 85;
            this.opt_MLM_ID.Text = "With MLM_ID";
            this.opt_MLM_ID.UseVisualStyleBackColor = true;
            // 
            // btn_import
            // 
            this.btn_import.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_import.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_import.ForeColor = System.Drawing.Color.Transparent;
            this.btn_import.Location = new System.Drawing.Point(390, 142);
            this.btn_import.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(94, 42);
            this.btn_import.TabIndex = 84;
            this.btn_import.Text = "Import";
            this.btn_import.UseVisualStyleBackColor = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(72, 251);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 83;
            this.label8.Text = "Message";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(74, 211);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 82;
            this.label7.Text = "File Path";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(-1, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 36);
            this.button2.TabIndex = 81;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Liberation Mono", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(376, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 42);
            this.label9.TabIndex = 80;
            this.label9.Text = "SMTT";
            // 
            // statusSMTT
            // 
            this.statusSMTT.AutoSize = true;
            this.statusSMTT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusSMTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusSMTT.ForeColor = System.Drawing.Color.Black;
            this.statusSMTT.Location = new System.Drawing.Point(41, 17);
            this.statusSMTT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusSMTT.Name = "statusSMTT";
            this.statusSMTT.Size = new System.Drawing.Size(13, 16);
            this.statusSMTT.TabIndex = 80;
            this.statusSMTT.Text = "-";
            // 
            // browTxt
            // 
            this.browTxt.Location = new System.Drawing.Point(150, 212);
            this.browTxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.browTxt.Name = "browTxt";
            this.browTxt.ReadOnly = true;
            this.browTxt.Size = new System.Drawing.Size(554, 22);
            this.browTxt.TabIndex = 69;
            this.browTxt.TextChanged += new System.EventHandler(this.browTxt_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(150, 211);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(552, 22);
            this.progressBar1.TabIndex = 78;
            // 
            // SMTTpBar
            // 
            this.SMTTpBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.SMTTpBar.Location = new System.Drawing.Point(0, 0);
            this.SMTTpBar.Name = "SMTTpBar";
            this.SMTTpBar.Size = new System.Drawing.Size(1000, 10);
            this.SMTTpBar.TabIndex = 79;
            // 
            // SMTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 449);
            this.Controls.Add(this.SMTTpBar);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Liberation Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "SMTT";
            this.Text = "SMTT";
            this.Load += new System.EventHandler(this.SMTT_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog browseXLSX;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SmttCombo;
        private System.Windows.Forms.Button browseFile;
        private System.Windows.Forms.Button combineBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button GenData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox browTxt;
        private System.Windows.Forms.Label statusSMTT;
        private System.Windows.Forms.ProgressBar SMTTpBar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.CheckBox opt_MLM_ID;
        private System.Windows.Forms.Label lbl_import_file;
        private System.Windows.Forms.Label lbl_import_file_path;
    }
}