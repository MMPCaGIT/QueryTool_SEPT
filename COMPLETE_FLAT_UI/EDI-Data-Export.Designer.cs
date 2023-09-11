namespace COMPLETE_FLAT_UI
{
    partial class EDI_Data_Export
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EDI_Data_Export));
            this.browseXLSX = new System.Windows.Forms.OpenFileDialog();
            this.browseFile = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.browTxt = new System.Windows.Forms.TextBox();
            this.statusSMTT = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseXLSX
            // 
            this.browseXLSX.FileName = ".xlsx";
            // 
            // browseFile
            // 
            this.browseFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.browseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseFile.ForeColor = System.Drawing.Color.Transparent;
            this.browseFile.Location = new System.Drawing.Point(666, 84);
            this.browseFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.browseFile.Name = "browseFile";
            this.browseFile.Size = new System.Drawing.Size(94, 42);
            this.browseFile.TabIndex = 64;
            this.browseFile.Text = "Import";
            this.browseFile.UseVisualStyleBackColor = false;
            this.browseFile.Click += new System.EventHandler(this.browseFile_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(666, 158);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 39);
            this.button3.TabIndex = 67;
            this.button3.Text = "Query";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // browTxt
            // 
            this.browTxt.Location = new System.Drawing.Point(104, 96);
            this.browTxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.browTxt.Name = "browTxt";
            this.browTxt.ReadOnly = true;
            this.browTxt.Size = new System.Drawing.Size(554, 20);
            this.browTxt.TabIndex = 83;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calisto MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(243, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(303, 36);
            this.label9.TabIndex = 80;
            this.label9.Text = "Export MIC Format";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 96);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 82;
            this.label7.Text = "File Path";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.statusSMTT);
            this.panel1.Controls.Add(this.browTxt);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.browseFile);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 304);
            this.panel1.TabIndex = 2;
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
            // 
            // EDI_Data_Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "EDI_Data_Export";
            this.Text = "EDI_Data_Export";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button browseFile;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox browTxt;
        private System.Windows.Forms.Label statusSMTT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog browseXLSX;
    }
}