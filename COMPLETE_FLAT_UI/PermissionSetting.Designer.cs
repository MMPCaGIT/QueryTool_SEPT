namespace QUERY_TOOL
{
    partial class PermissionSetting
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Order Cancel");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Order Change");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Liku Mateiral Check");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Order Consumption");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Costing", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Cargo List");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Carton Weight");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Material Weight");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Customs", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("PI Checking");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("SMTT");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Purchasing", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Assembly Error Check");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Stitching Error Check");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Material Search");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("DR Order and LIne Check");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Others", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Data Query", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode9,
            treeNode12,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("BI Reports");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Modify User ");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("User Registration");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("User Permissions");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("User Setting", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21,
            treeNode22});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DataGen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(0, 57);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "odrCnacel";
            treeNode1.Text = "Order Cancel";
            treeNode2.Name = "odrChange";
            treeNode2.Text = "Order Change";
            treeNode3.Name = "likMatChk";
            treeNode3.Text = "Liku Mateiral Check";
            treeNode4.Name = "odrConsm";
            treeNode4.Text = "Order Consumption";
            treeNode5.Name = "cositng";
            treeNode5.Text = "Costing";
            treeNode6.Name = "cargoList";
            treeNode6.Text = "Cargo List";
            treeNode7.Name = "cartonWgh";
            treeNode7.Text = "Carton Weight";
            treeNode8.Name = "matWgh";
            treeNode8.Text = "Material Weight";
            treeNode9.Name = "customs";
            treeNode9.Text = "Customs";
            treeNode10.Name = "piChk";
            treeNode10.Text = "PI Checking";
            treeNode11.Name = "smtt";
            treeNode11.Text = "SMTT";
            treeNode12.Name = "purchasing";
            treeNode12.Text = "Purchasing";
            treeNode13.Name = "assErorChk";
            treeNode13.Text = "Assembly Error Check";
            treeNode14.Name = "stitErrorChk";
            treeNode14.Text = "Stitching Error Check";
            treeNode15.Name = "matSearch";
            treeNode15.Text = "Material Search";
            treeNode16.Name = "drOdrlineChk";
            treeNode16.Text = "DR Order and LIne Check";
            treeNode17.Name = "other";
            treeNode17.Text = "Others";
            treeNode18.Checked = true;
            treeNode18.Name = "dataQuery";
            treeNode18.Text = "Data Query";
            treeNode19.Checked = true;
            treeNode19.Name = "BiReports";
            treeNode19.Text = "BI Reports";
            treeNode20.Name = "modifyUser";
            treeNode20.Text = "Modify User ";
            treeNode21.Name = "userReg";
            treeNode21.Text = "User Registration";
            treeNode22.Name = "userPermis";
            treeNode22.Text = "User Permissions";
            treeNode23.Checked = true;
            treeNode23.Name = "userSetting";
            treeNode23.Text = "User Setting";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19,
            treeNode23});
            this.treeView1.Size = new System.Drawing.Size(800, 346);
            this.treeView1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(129, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(289, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "User Name";
            // 
            // DataGen
            // 
            this.DataGen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.DataGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGen.ForeColor = System.Drawing.Color.Transparent;
            this.DataGen.Location = new System.Drawing.Point(608, 7);
            this.DataGen.Name = "DataGen";
            this.DataGen.Size = new System.Drawing.Size(122, 34);
            this.DataGen.TabIndex = 13;
            this.DataGen.Text = "Query";
            this.DataGen.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.panel1.Controls.Add(this.DataGen);
            this.panel1.Controls.Add(this.BtnCerrar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 57);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 403);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 59);
            this.panel2.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(149)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(636, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 34);
            this.button1.TabIndex = 13;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrar.FlatAppearance.BorderSize = 0;
            this.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar.Image = global::QUERY_TOOL.Properties.Resources.Close;
            this.BtnCerrar.Location = new System.Drawing.Point(754, 5);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(38, 38);
            this.BtnCerrar.TabIndex = 4;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            // 
            // PermissionSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel1);
            this.Name = "PermissionSetting";
            this.Text = "PermissionSetting";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DataGen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnCerrar;
    }
}