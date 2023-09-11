namespace QUERY_TOOL
{
    partial class micWithAcc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(micWithAcc));
            this.browseXLSX = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.DataGen = new System.Windows.Forms.Button();
            this.MatLable = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BB1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textID = new System.Windows.Forms.TextBox();
            this.byId = new System.Windows.Forms.CheckBox();
            this.byDate = new System.Windows.Forms.CheckBox();
            this.shoe = new System.Windows.Forms.RadioButton();
            this.sole = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseXLSX
            // 
            this.browseXLSX.FileName = ".xlsx";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(3, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 36);
            this.button2.TabIndex = 101;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(562, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 16);
            this.label2.TabIndex = 105;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(301, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 104;
            this.label1.Text = "From";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(595, 45);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(184, 20);
            this.dateTimePicker2.TabIndex = 103;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(362, 45);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(179, 20);
            this.dateTimePicker1.TabIndex = 102;
            // 
            // DataGen
            // 
            this.DataGen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.DataGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGen.ForeColor = System.Drawing.Color.Transparent;
            this.DataGen.Location = new System.Drawing.Point(25, 195);
            this.DataGen.Name = "DataGen";
            this.DataGen.Size = new System.Drawing.Size(122, 34);
            this.DataGen.TabIndex = 108;
            this.DataGen.Text = "Generate";
            this.DataGen.UseVisualStyleBackColor = false;
            this.DataGen.Click += new System.EventHandler(this.DataGen_Click);
            // 
            // MatLable
            // 
            this.MatLable.AutoSize = true;
            this.MatLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.MatLable.Location = new System.Drawing.Point(53, 9);
            this.MatLable.Name = "MatLable";
            this.MatLable.Size = new System.Drawing.Size(235, 16);
            this.MatLable.TabIndex = 109;
            this.MatLable.Text = "Material Import Data with A/C No.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BB1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.textID);
            this.panel1.Controls.Add(this.byId);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.byDate);
            this.panel1.Controls.Add(this.shoe);
            this.panel1.Controls.Add(this.DataGen);
            this.panel1.Controls.Add(this.sole);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 236);
            this.panel1.TabIndex = 110;
            // 
            // BB1
            // 
            this.BB1.AutoSize = true;
            this.BB1.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB1.ForeColor = System.Drawing.Color.Black;
            this.BB1.Location = new System.Drawing.Point(25, 142);
            this.BB1.Name = "BB1";
            this.BB1.Size = new System.Drawing.Size(54, 20);
            this.BB1.TabIndex = 114;
            this.BB1.TabStop = true;
            this.BB1.Text = "BB1";
            this.BB1.UseVisualStyleBackColor = true;
            this.BB1.Click += new System.EventHandler(this.BB1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(301, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 112;
            this.label3.Text = "ID_No.";
            // 
            // textID
            // 
            this.textID.Location = new System.Drawing.Point(362, 92);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(179, 20);
            this.textID.TabIndex = 111;
            // 
            // byId
            // 
            this.byId.AutoSize = true;
            this.byId.ForeColor = System.Drawing.Color.Black;
            this.byId.Location = new System.Drawing.Point(143, 95);
            this.byId.Name = "byId";
            this.byId.Size = new System.Drawing.Size(52, 17);
            this.byId.TabIndex = 110;
            this.byId.Text = "By ID";
            this.byId.UseVisualStyleBackColor = true;
            this.byId.Click += new System.EventHandler(this.byId_Click);
            // 
            // byDate
            // 
            this.byDate.AutoSize = true;
            this.byDate.ForeColor = System.Drawing.Color.Black;
            this.byDate.Location = new System.Drawing.Point(143, 44);
            this.byDate.Name = "byDate";
            this.byDate.Size = new System.Drawing.Size(96, 17);
            this.byDate.TabIndex = 109;
            this.byDate.Text = "By Import Date";
            this.byDate.UseVisualStyleBackColor = true;
            this.byDate.Click += new System.EventHandler(this.byDate_Click);
            // 
            // shoe
            // 
            this.shoe.AutoSize = true;
            this.shoe.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.shoe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shoe.ForeColor = System.Drawing.Color.Black;
            this.shoe.Location = new System.Drawing.Point(25, 47);
            this.shoe.Name = "shoe";
            this.shoe.Size = new System.Drawing.Size(62, 20);
            this.shoe.TabIndex = 106;
            this.shoe.TabStop = true;
            this.shoe.Text = "Shoe";
            this.shoe.UseVisualStyleBackColor = true;
            this.shoe.Click += new System.EventHandler(this.shoe_Click);
            // 
            // sole
            // 
            this.sole.AutoSize = true;
            this.sole.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.sole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sole.ForeColor = System.Drawing.Color.Black;
            this.sole.Location = new System.Drawing.Point(25, 97);
            this.sole.Name = "sole";
            this.sole.Size = new System.Drawing.Size(58, 20);
            this.sole.TabIndex = 107;
            this.sole.TabStop = true;
            this.sole.Text = "Sole";
            this.sole.UseVisualStyleBackColor = true;
            this.sole.Click += new System.EventHandler(this.sole_Click);
            // 
            // micWithAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 236);
            this.Controls.Add(this.MatLable);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Name = "micWithAcc";
            this.Text = "micWithAcc";
            this.Load += new System.EventHandler(this.micWithAcc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog browseXLSX;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button DataGen;
        private System.Windows.Forms.Label MatLable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox byId;
        private System.Windows.Forms.CheckBox byDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.RadioButton BB1;
        private System.Windows.Forms.RadioButton shoe;
        private System.Windows.Forms.RadioButton sole;
    }
}