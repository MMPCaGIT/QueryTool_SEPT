namespace QUERY_TOOL
{
    partial class purf13
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
            this.label1 = new System.Windows.Forms.Label();
            this.matTxt = new System.Windows.Forms.TextBox();
            this.DataGen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(57, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 16);
            this.label1.TabIndex = 41;
            this.label1.Text = "材料代號 (Mat No):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // matTxt
            // 
            this.matTxt.Location = new System.Drawing.Point(201, 93);
            this.matTxt.Name = "matTxt";
            this.matTxt.Size = new System.Drawing.Size(179, 20);
            this.matTxt.TabIndex = 40;
            // 
            // DataGen
            // 
            this.DataGen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.DataGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGen.ForeColor = System.Drawing.Color.Transparent;
            this.DataGen.Location = new System.Drawing.Point(60, 177);
            this.DataGen.Name = "DataGen";
            this.DataGen.Size = new System.Drawing.Size(122, 34);
            this.DataGen.TabIndex = 38;
            this.DataGen.Text = "Generate";
            this.DataGen.UseVisualStyleBackColor = false;
            this.DataGen.Click += new System.EventHandler(this.DataGen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Kufi Arabic", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 31);
            this.label3.TabIndex = 84;
            this.label3.Text = "Purchasing F 1 -3";
            // 
            // purf13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 374);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.matTxt);
            this.Controls.Add(this.DataGen);
            this.Name = "purf13";
            this.Text = "purf13";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox matTxt;
        private System.Windows.Forms.Button DataGen;
        private System.Windows.Forms.Label label3;
    }
}