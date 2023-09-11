namespace COMPLETE_FLAT_UI
{
    partial class LikChk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LikChk));
            this.DataGen = new System.Windows.Forms.Button();
            this.Limi = new System.Windows.Forms.RadioButton();
            this.dishG = new System.Windows.Forms.RadioButton();
            this.IndishG = new System.Windows.Forms.RadioButton();
            this.ChkMat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PlsLable = new System.Windows.Forms.Label();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGen
            // 
            this.DataGen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.DataGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGen.ForeColor = System.Drawing.Color.Transparent;
            this.DataGen.Location = new System.Drawing.Point(18, 252);
            this.DataGen.Name = "DataGen";
            this.DataGen.Size = new System.Drawing.Size(122, 34);
            this.DataGen.TabIndex = 13;
            this.DataGen.Text = "Generate";
            this.DataGen.UseVisualStyleBackColor = false;
            this.DataGen.Click += new System.EventHandler(this.DataGen_Click);
            // 
            // Limi
            // 
            this.Limi.AutoSize = true;
            this.Limi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Limi.ForeColor = System.Drawing.Color.Black;
            this.Limi.Location = new System.Drawing.Point(6, 84);
            this.Limi.Name = "Limi";
            this.Limi.Size = new System.Drawing.Size(242, 20);
            this.Limi.TabIndex = 33;
            this.Limi.TabStop = true;
            this.Limi.Text = "托外材料 (Limination Materials)";
            this.Limi.UseVisualStyleBackColor = true;
            // 
            // dishG
            // 
            this.dishG.AutoSize = true;
            this.dishG.BackColor = System.Drawing.Color.White;
            this.dishG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dishG.ForeColor = System.Drawing.Color.Black;
            this.dishG.Location = new System.Drawing.Point(274, 84);
            this.dishG.Name = "dishG";
            this.dishG.Size = new System.Drawing.Size(248, 20);
            this.dishG.TabIndex = 34;
            this.dishG.TabStop = true;
            this.dishG.Text = "區分尺碼 (Distinguish Materials)";
            this.dishG.UseVisualStyleBackColor = false;
            // 
            // IndishG
            // 
            this.IndishG.AutoSize = true;
            this.IndishG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndishG.ForeColor = System.Drawing.Color.Black;
            this.IndishG.Location = new System.Drawing.Point(552, 84);
            this.IndishG.Name = "IndishG";
            this.IndishG.Size = new System.Drawing.Size(258, 20);
            this.IndishG.TabIndex = 35;
            this.IndishG.TabStop = true;
            this.IndishG.Text = "不分尺碼 (Indistinguish Materials)";
            this.IndishG.UseVisualStyleBackColor = true;
            // 
            // ChkMat
            // 
            this.ChkMat.Location = new System.Drawing.Point(161, 37);
            this.ChkMat.Name = "ChkMat";
            this.ChkMat.Size = new System.Drawing.Size(179, 22);
            this.ChkMat.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(17, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "材料代號 (Mat No):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.IndishG);
            this.groupBox1.Controls.Add(this.ChkMat);
            this.groupBox1.Controls.Add(this.dishG);
            this.groupBox1.Controls.Add(this.Limi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(822, 183);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Liku Materials Check";
            // 
            // PlsLable
            // 
            this.PlsLable.AutoSize = true;
            this.PlsLable.Font = new System.Drawing.Font("Modern No. 20", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlsLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.PlsLable.Location = new System.Drawing.Point(359, 225);
            this.PlsLable.Name = "PlsLable";
            this.PlsLable.Size = new System.Drawing.Size(0, 36);
            this.PlsLable.TabIndex = 40;
            this.PlsLable.UseMnemonic = false;
            this.PlsLable.UseWaitCursor = true;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrar.FlatAppearance.BorderSize = 0;
            this.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BtnCerrar.Image")));
            this.BtnCerrar.Location = new System.Drawing.Point(-2, 1);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(36, 32);
            this.BtnCerrar.TabIndex = 39;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // LikChk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(845, 579);
            this.Controls.Add(this.PlsLable);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.DataGen);
            this.Controls.Add(this.groupBox1);
            this.Name = "LikChk";
            this.Text = "LikChk";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DataGen;
        private System.Windows.Forms.RadioButton Limi;
        private System.Windows.Forms.RadioButton dishG;
        private System.Windows.Forms.RadioButton IndishG;
        private System.Windows.Forms.TextBox ChkMat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.Label PlsLable;
    }
}