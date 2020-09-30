namespace EPME
{
    partial class impfour
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
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbsec = new Mycombo();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.rbnom = new Myradio();
            this.rbcode = new Myradio();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.White;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.FocusCuesEnabled = false;
            this.buttonX1.ForeColor = System.Drawing.Color.White;
            this.buttonX1.Location = new System.Drawing.Point(211, 142);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(71, 26);
            this.buttonX1.TabIndex = 53;
            this.buttonX1.Text = "&Fermer";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.BackColor = System.Drawing.Color.White;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX3.FocusCuesEnabled = false;
            this.buttonX3.ForeColor = System.Drawing.Color.White;
            this.buttonX3.Location = new System.Drawing.Point(44, 142);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(71, 26);
            this.buttonX3.TabIndex = 52;
            this.buttonX3.Text = "&Imprimer";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Famille:";
            // 
            // cmbsec
            // 
            this.cmbsec.DisplayMember = "Text";
            this.cmbsec.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbsec.FormattingEnabled = true;
            this.cmbsec.ItemHeight = 14;
            this.cmbsec.Location = new System.Drawing.Point(59, 26);
            this.cmbsec.Name = "cmbsec";
            this.cmbsec.Size = new System.Drawing.Size(269, 20);
            this.cmbsec.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbsec.TabIndex = 50;
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.Transparent;
            this.groupBox11.Controls.Add(this.rbnom);
            this.groupBox11.Controls.Add(this.rbcode);
            this.groupBox11.Location = new System.Drawing.Point(13, 67);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(315, 47);
            this.groupBox11.TabIndex = 54;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Triage";
            // 
            // rbnom
            // 
            this.rbnom.AutoSize = true;
            this.rbnom.Location = new System.Drawing.Point(243, 19);
            this.rbnom.Name = "rbnom";
            this.rbnom.Size = new System.Drawing.Size(46, 17);
            this.rbnom.TabIndex = 36;
            this.rbnom.TabStop = true;
            this.rbnom.Text = "Nom";
            this.rbnom.UseVisualStyleBackColor = true;
            this.rbnom.CheckedChanged += new System.EventHandler(this.rbnom_CheckedChanged);
            // 
            // rbcode
            // 
            this.rbcode.AutoSize = true;
            this.rbcode.Location = new System.Drawing.Point(31, 19);
            this.rbcode.Name = "rbcode";
            this.rbcode.Size = new System.Drawing.Size(50, 17);
            this.rbcode.TabIndex = 35;
            this.rbcode.TabStop = true;
            this.rbcode.Text = "Code";
            this.rbcode.UseVisualStyleBackColor = true;
            this.rbcode.CheckedChanged += new System.EventHandler(this.rbcode_CheckedChanged);
            // 
            // impfour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(346, 194);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.cmbsec);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.Name = "impfour";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impression Fournisseur";
            this.Load += new System.EventHandler(this.impfour_Load);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private Mycombo cmbsec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox11;
        public Myradio rbnom;
        public Myradio rbcode;
    }
}