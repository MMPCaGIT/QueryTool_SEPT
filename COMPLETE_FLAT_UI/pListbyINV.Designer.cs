namespace QUERY_TOOL
{
    partial class pListbyINV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pListbyINV));
            this.Query_EMC = new System.Windows.Forms.Button();
            this.Odr_Import = new System.Windows.Forms.Button();
            this.browseXLSX = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.browseFile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Query_EMC
            // 
            this.Query_EMC.BackColor = System.Drawing.SystemColors.Highlight;
            this.Query_EMC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Query_EMC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Query_EMC.Location = new System.Drawing.Point(19, 78);
            this.Query_EMC.Name = "Query_EMC";
            this.Query_EMC.Size = new System.Drawing.Size(162, 41);
            this.Query_EMC.TabIndex = 98;
            this.Query_EMC.Text = "Query";
            this.Query_EMC.UseVisualStyleBackColor = false;
            this.Query_EMC.Click += new System.EventHandler(this.Query_EMC_Click);
            // 
            // Odr_Import
            // 
            this.Odr_Import.BackColor = System.Drawing.SystemColors.Highlight;
            this.Odr_Import.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Odr_Import.Location = new System.Drawing.Point(19, 16);
            this.Odr_Import.Name = "Odr_Import";
            this.Odr_Import.Size = new System.Drawing.Size(162, 42);
            this.Odr_Import.TabIndex = 95;
            this.Odr_Import.Text = "Import";
            this.Odr_Import.UseVisualStyleBackColor = false;
            this.Odr_Import.Click += new System.EventHandler(this.Odr_Import_Click);
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
            this.button2.Location = new System.Drawing.Point(-6, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 36);
            this.button2.TabIndex = 101;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Highlight;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(19, 139);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 41);
            this.button3.TabIndex = 100;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 49);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(479, 10);
            this.progressBar1.TabIndex = 99;
            // 
            // browseFile
            // 
            this.browseFile.Location = new System.Drawing.Point(3, 23);
            this.browseFile.Name = "browseFile";
            this.browseFile.Size = new System.Drawing.Size(483, 20);
            this.browseFile.TabIndex = 97;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 96;
            this.label7.Text = "File Path";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.browseFile);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(557, 394);
            this.flowLayoutPanel1.TabIndex = 102;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Query_EMC);
            this.panel1.Controls.Add(this.Odr_Import);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(588, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 394);
            this.panel1.TabIndex = 103;
            // 
            // pListbyINV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 394);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button2);
            this.Name = "pListbyINV";
            this.Text = "pListbyINV";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Query_EMC;
        private System.Windows.Forms.Button Odr_Import;
        private System.Windows.Forms.OpenFileDialog browseXLSX;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox browseFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}