namespace QUERY_TOOL
{
    partial class MatPriceSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatPriceSearch));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataGen = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.opt_date = new System.Windows.Forms.RadioButton();
            this.dt_from = new System.Windows.Forms.DateTimePicker();
            this.dt_to = new System.Windows.Forms.DateTimePicker();
            this.opt_bymaterial = new System.Windows.Forms.RadioButton();
            this.txt_mat = new System.Windows.Forms.TextBox();
            this.lbl_matname = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 355);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 24);
            this.panel1.TabIndex = 86;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(589, 259);
            this.panel2.TabIndex = 87;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.opt_bymaterial);
            this.groupBox1.Controls.Add(this.txt_mat);
            this.groupBox1.Controls.Add(this.lbl_matname);
            this.groupBox1.Controls.Add(this.dt_to);
            this.groupBox1.Controls.Add(this.dt_from);
            this.groupBox1.Controls.Add(this.opt_date);
            this.groupBox1.Location = new System.Drawing.Point(16, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 219);
            this.groupBox1.TabIndex = 80;
            this.groupBox1.TabStop = false;
            // 
            // DataGen
            // 
            this.DataGen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.DataGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGen.ForeColor = System.Drawing.Color.Transparent;
            this.DataGen.Location = new System.Drawing.Point(431, 315);
            this.DataGen.Name = "DataGen";
            this.DataGen.Size = new System.Drawing.Size(122, 34);
            this.DataGen.TabIndex = 26;
            this.DataGen.Text = "Search";
            this.DataGen.UseVisualStyleBackColor = false;
            this.DataGen.Click += new System.EventHandler(this.DataGen_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(589, 38);
            this.panel3.TabIndex = 88;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Kufi Arabic", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 31);
            this.label3.TabIndex = 83;
            this.label3.Text = "Material Price Search";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(3, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 36);
            this.button2.TabIndex = 82;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // opt_date
            // 
            this.opt_date.AutoSize = true;
            this.opt_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.opt_date.Location = new System.Drawing.Point(41, 18);
            this.opt_date.Name = "opt_date";
            this.opt_date.Size = new System.Drawing.Size(81, 20);
            this.opt_date.TabIndex = 82;
            this.opt_date.TabStop = true;
            this.opt_date.Text = "By Date";
            this.opt_date.UseVisualStyleBackColor = true;
            this.opt_date.Click += new System.EventHandler(this.opt_date_Click);
            // 
            // dt_from
            // 
            this.dt_from.Location = new System.Drawing.Point(40, 56);
            this.dt_from.Name = "dt_from";
            this.dt_from.Size = new System.Drawing.Size(200, 20);
            this.dt_from.TabIndex = 83;
            // 
            // dt_to
            // 
            this.dt_to.Location = new System.Drawing.Point(317, 56);
            this.dt_to.Name = "dt_to";
            this.dt_to.Size = new System.Drawing.Size(200, 20);
            this.dt_to.TabIndex = 84;
            // 
            // opt_bymaterial
            // 
            this.opt_bymaterial.AutoSize = true;
            this.opt_bymaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.opt_bymaterial.Location = new System.Drawing.Point(40, 127);
            this.opt_bymaterial.Name = "opt_bymaterial";
            this.opt_bymaterial.Size = new System.Drawing.Size(149, 20);
            this.opt_bymaterial.TabIndex = 87;
            this.opt_bymaterial.TabStop = true;
            this.opt_bymaterial.Text = "By Material Name";
            this.opt_bymaterial.UseVisualStyleBackColor = true;
            this.opt_bymaterial.Click += new System.EventHandler(this.opt_bymaterial_Click);
            // 
            // txt_mat
            // 
            this.txt_mat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_mat.Location = new System.Drawing.Point(222, 169);
            this.txt_mat.Name = "txt_mat";
            this.txt_mat.Size = new System.Drawing.Size(300, 22);
            this.txt_mat.TabIndex = 85;
            // 
            // lbl_matname
            // 
            this.lbl_matname.AutoSize = true;
            this.lbl_matname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_matname.Location = new System.Drawing.Point(45, 169);
            this.lbl_matname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_matname.Name = "lbl_matname";
            this.lbl_matname.Size = new System.Drawing.Size(109, 16);
            this.lbl_matname.TabIndex = 86;
            this.lbl_matname.Text = "Material Name";
            // 
            // MatPriceSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 379);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DataGen);
            this.Controls.Add(this.panel3);
            this.Name = "MatPriceSearch";
            this.Text = "Material Price Search";
            this.Load += new System.EventHandler(this.MatPriceSearch_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button DataGen;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dt_to;
        private System.Windows.Forms.DateTimePicker dt_from;
        private System.Windows.Forms.RadioButton opt_date;
        private System.Windows.Forms.RadioButton opt_bymaterial;
        private System.Windows.Forms.TextBox txt_mat;
        private System.Windows.Forms.Label lbl_matname;
    }
}