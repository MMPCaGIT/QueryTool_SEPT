namespace QUERY_TOOL
{
    partial class Dispatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dispatch));
            this.Query_EMC = new System.Windows.Forms.Button();
            this.browseFile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Odr_Import = new System.Windows.Forms.Button();
            this.browseXLSX = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Query_EMC
            // 
            this.Query_EMC.BackColor = System.Drawing.SystemColors.Highlight;
            this.Query_EMC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Query_EMC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Query_EMC.Location = new System.Drawing.Point(614, 101);
            this.Query_EMC.Name = "Query_EMC";
            this.Query_EMC.Size = new System.Drawing.Size(162, 41);
            this.Query_EMC.TabIndex = 89;
            this.Query_EMC.Text = "Query";
            this.Query_EMC.UseVisualStyleBackColor = false;
            this.Query_EMC.Click += new System.EventHandler(this.Query_EMC_Click);
            // 
            // browseFile
            // 
            this.browseFile.Location = new System.Drawing.Point(103, 30);
            this.browseFile.Name = "browseFile";
            this.browseFile.Size = new System.Drawing.Size(483, 20);
            this.browseFile.TabIndex = 88;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 87;
            this.label7.Text = "File Path";
            // 
            // Odr_Import
            // 
            this.Odr_Import.BackColor = System.Drawing.SystemColors.Highlight;
            this.Odr_Import.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Odr_Import.Location = new System.Drawing.Point(614, 18);
            this.Odr_Import.Name = "Odr_Import";
            this.Odr_Import.Size = new System.Drawing.Size(162, 42);
            this.Odr_Import.TabIndex = 86;
            this.Odr_Import.Text = "Import";
            this.Odr_Import.UseVisualStyleBackColor = false;
            this.Odr_Import.Click += new System.EventHandler(this.Odr_Import_Click);
            // 
            // browseXLSX
            // 
            this.browseXLSX.FileName = ".xlsx";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Highlight;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(614, 172);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 41);
            this.button3.TabIndex = 90;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(106, 61);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(479, 10);
            this.progressBar1.TabIndex = 91;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(0, -5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 36);
            this.button2.TabIndex = 92;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Dispatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Query_EMC);
            this.Controls.Add(this.browseFile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Odr_Import);
            this.Name = "Dispatch";
            this.Text = "Dispatch";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Query_EMC;
        private System.Windows.Forms.TextBox browseFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Odr_Import;
        private System.Windows.Forms.OpenFileDialog browseXLSX;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button2;
    }
}