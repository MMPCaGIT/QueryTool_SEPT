namespace QUERY_TOOL
{
    partial class POstatus_inquiry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POstatus_inquiry));
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_exportby = new System.Windows.Forms.ComboBox();
            this.gb_receipt = new System.Windows.Forms.GroupBox();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gb_order = new System.Windows.Forms.GroupBox();
            this.btn_import = new System.Windows.Forms.Button();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_generate = new System.Windows.Forms.Button();
            this.opd_xlsx = new System.Windows.Forms.OpenFileDialog();
            this.gb_blank = new System.Windows.Forms.GroupBox();
            this.opt_2 = new System.Windows.Forms.RadioButton();
            this.opt_1 = new System.Windows.Forms.RadioButton();
            this.Pbar_status = new System.Windows.Forms.ProgressBar();
            this.gb_receipt.SuspendLayout();
            this.gb_order.SuspendLayout();
            this.gb_blank.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Kufi Arabic", 12F, System.Drawing.FontStyle.Underline);
            this.label1.Location = new System.Drawing.Point(53, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 31);
            this.label1.TabIndex = 84;
            this.label1.Text = " Purchased Order Status Inquiry";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(-1, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 36);
            this.button2.TabIndex = 83;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(67, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 85;
            this.label2.Text = "Export By";
            // 
            // cbo_exportby
            // 
            this.cbo_exportby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_exportby.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.cbo_exportby.FormattingEnabled = true;
            this.cbo_exportby.Items.AddRange(new object[] {
            "Received Order Date",
            "By Order"});
            this.cbo_exportby.Location = new System.Drawing.Point(159, 58);
            this.cbo_exportby.Name = "cbo_exportby";
            this.cbo_exportby.Size = new System.Drawing.Size(213, 24);
            this.cbo_exportby.TabIndex = 86;
            this.cbo_exportby.SelectedIndexChanged += new System.EventHandler(this.cbo_exportby_SelectedIndexChanged);
            // 
            // gb_receipt
            // 
            this.gb_receipt.Controls.Add(this.dtp_to);
            this.gb_receipt.Controls.Add(this.dtp_from);
            this.gb_receipt.Controls.Add(this.label4);
            this.gb_receipt.Controls.Add(this.label3);
            this.gb_receipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.gb_receipt.Location = new System.Drawing.Point(59, 98);
            this.gb_receipt.Name = "gb_receipt";
            this.gb_receipt.Size = new System.Drawing.Size(535, 89);
            this.gb_receipt.TabIndex = 87;
            this.gb_receipt.TabStop = false;
            this.gb_receipt.Text = "Received Order Date";
            // 
            // dtp_to
            // 
            this.dtp_to.Location = new System.Drawing.Point(293, 41);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(209, 22);
            this.dtp_to.TabIndex = 3;
            // 
            // dtp_from
            // 
            this.dtp_from.Location = new System.Drawing.Point(14, 41);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(209, 22);
            this.dtp_from.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(290, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(14, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "From";
            // 
            // gb_order
            // 
            this.gb_order.Controls.Add(this.btn_import);
            this.gb_order.Controls.Add(this.txt_path);
            this.gb_order.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.gb_order.Location = new System.Drawing.Point(59, 196);
            this.gb_order.Name = "gb_order";
            this.gb_order.Size = new System.Drawing.Size(535, 73);
            this.gb_order.TabIndex = 88;
            this.gb_order.TabStop = false;
            this.gb_order.Text = "By Order";
            // 
            // btn_import
            // 
            this.btn_import.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.btn_import.ForeColor = System.Drawing.Color.Transparent;
            this.btn_import.Location = new System.Drawing.Point(410, 18);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(87, 43);
            this.btn_import.TabIndex = 1;
            this.btn_import.Text = "Import";
            this.btn_import.UseVisualStyleBackColor = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(42, 30);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(334, 22);
            this.txt_path.TabIndex = 0;
            // 
            // btn_generate
            // 
            this.btn_generate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.btn_generate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_generate.ForeColor = System.Drawing.Color.Transparent;
            this.btn_generate.Location = new System.Drawing.Point(507, 384);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(87, 43);
            this.btn_generate.TabIndex = 2;
            this.btn_generate.Text = "Generate";
            this.btn_generate.UseVisualStyleBackColor = false;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // opd_xlsx
            // 
            this.opd_xlsx.FileName = "openFileDialog1";
            // 
            // gb_blank
            // 
            this.gb_blank.Controls.Add(this.opt_2);
            this.gb_blank.Controls.Add(this.opt_1);
            this.gb_blank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.gb_blank.Location = new System.Drawing.Point(59, 280);
            this.gb_blank.Name = "gb_blank";
            this.gb_blank.Size = new System.Drawing.Size(535, 89);
            this.gb_blank.TabIndex = 89;
            this.gb_blank.TabStop = false;
            // 
            // opt_2
            // 
            this.opt_2.AutoSize = true;
            this.opt_2.Location = new System.Drawing.Point(330, 35);
            this.opt_2.Name = "opt_2";
            this.opt_2.Size = new System.Drawing.Size(122, 20);
            this.opt_2.TabIndex = 1;
            this.opt_2.TabStop = true;
            this.opt_2.Text = "訂單托外狀況";
            this.opt_2.UseVisualStyleBackColor = true;
            // 
            // opt_1
            // 
            this.opt_1.AutoSize = true;
            this.opt_1.Location = new System.Drawing.Point(42, 35);
            this.opt_1.Name = "opt_1";
            this.opt_1.Size = new System.Drawing.Size(122, 20);
            this.opt_1.TabIndex = 0;
            this.opt_1.TabStop = true;
            this.opt_1.Text = "訂單採購狀況";
            this.opt_1.UseVisualStyleBackColor = true;
            // 
            // Pbar_status
            // 
            this.Pbar_status.Location = new System.Drawing.Point(59, 393);
            this.Pbar_status.Name = "Pbar_status";
            this.Pbar_status.Size = new System.Drawing.Size(430, 27);
            this.Pbar_status.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Pbar_status.TabIndex = 90;
            this.Pbar_status.Visible = false;
            // 
            // POstatus_inquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 487);
            this.Controls.Add(this.Pbar_status);
            this.Controls.Add(this.gb_blank);
            this.Controls.Add(this.btn_generate);
            this.Controls.Add(this.gb_order);
            this.Controls.Add(this.gb_receipt);
            this.Controls.Add(this.cbo_exportby);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Name = "POstatus_inquiry";
            this.Text = "POstatus_inquiry";
            this.Load += new System.EventHandler(this.POstatus_inquiry_Load);
            this.gb_receipt.ResumeLayout(false);
            this.gb_receipt.PerformLayout();
            this.gb_order.ResumeLayout(false);
            this.gb_order.PerformLayout();
            this.gb_blank.ResumeLayout(false);
            this.gb_blank.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_exportby;
        private System.Windows.Forms.GroupBox gb_receipt;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gb_order;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.OpenFileDialog opd_xlsx;
        private System.Windows.Forms.GroupBox gb_blank;
        private System.Windows.Forms.RadioButton opt_2;
        private System.Windows.Forms.RadioButton opt_1;
        private System.Windows.Forms.ProgressBar Pbar_status;
    }
}