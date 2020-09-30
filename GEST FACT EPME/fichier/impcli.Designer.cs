namespace EPME
{
    partial class impcli
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
            this.cmbsec = new Mycombo();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.rbnom = new Myradio();
            this.rbcode = new Myradio();
            this.cmbreg = new Mycombo();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbs = new Mycombo();
            this.label2 = new System.Windows.Forms.Label();
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
            this.buttonX1.Location = new System.Drawing.Point(250, 216);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(71, 26);
            this.buttonX1.TabIndex = 49;
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
            this.buttonX3.Location = new System.Drawing.Point(83, 216);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(71, 26);
            this.buttonX3.TabIndex = 48;
            this.buttonX3.Text = "&Imprimer";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // cmbsec
            // 
            this.cmbsec.DisplayMember = "Text";
            this.cmbsec.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbsec.FormattingEnabled = true;
            this.cmbsec.ItemHeight = 14;
            this.cmbsec.Location = new System.Drawing.Point(73, 100);
            this.cmbsec.Name = "cmbsec";
            this.cmbsec.Size = new System.Drawing.Size(267, 20);
            this.cmbsec.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbsec.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Famille:";
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.Transparent;
            this.groupBox11.Controls.Add(this.rbnom);
            this.groupBox11.Controls.Add(this.rbcode);
            this.groupBox11.Location = new System.Drawing.Point(25, 145);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(315, 47);
            this.groupBox11.TabIndex = 55;
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
            // cmbreg
            // 
            this.cmbreg.DisplayMember = "Text";
            this.cmbreg.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbreg.FormattingEnabled = true;
            this.cmbreg.ItemHeight = 14;
            this.cmbreg.Location = new System.Drawing.Point(73, 12);
            this.cmbreg.Name = "cmbreg";
            this.cmbreg.Size = new System.Drawing.Size(267, 20);
            this.cmbreg.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbreg.TabIndex = 56;
            this.cmbreg.SelectedIndexChanged += new System.EventHandler(this.cmbreg_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Région :";
            // 
            // cmbs
            // 
            this.cmbs.DisplayMember = "Text";
            this.cmbs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbs.FormattingEnabled = true;
            this.cmbs.ItemHeight = 14;
            this.cmbs.Location = new System.Drawing.Point(73, 55);
            this.cmbs.Name = "cmbs";
            this.cmbs.Size = new System.Drawing.Size(267, 20);
            this.cmbs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbs.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Section :";
            // 
            // impcli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(384, 260);
            this.Controls.Add(this.cmbs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbreg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.cmbsec);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.Name = "impcli";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impression Client";
            this.Load += new System.EventHandler(this.impcli_Load);
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
        private Mycombo cmbreg;
        private System.Windows.Forms.Label label1;
        private Mycombo cmbs;
        private System.Windows.Forms.Label label2;
    }
}