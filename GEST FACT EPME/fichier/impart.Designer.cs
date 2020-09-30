namespace EPME
{
    partial class impart
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
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.rbnom = new Myradio();
            this.rbcode = new Myradio();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.cmbsec = new Mycombo();
            this.label3 = new System.Windows.Forms.Label();
            this.nomc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.codec = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.Transparent;
            this.groupBox11.Controls.Add(this.rbnom);
            this.groupBox11.Controls.Add(this.rbcode);
            this.groupBox11.Location = new System.Drawing.Point(17, 88);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(402, 47);
            this.groupBox11.TabIndex = 59;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Triage";
            // 
            // rbnom
            // 
            this.rbnom.AutoSize = true;
            this.rbnom.Location = new System.Drawing.Point(333, 19);
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
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.White;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.FocusCuesEnabled = false;
            this.buttonX1.ForeColor = System.Drawing.Color.White;
            this.buttonX1.Location = new System.Drawing.Point(348, 157);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(71, 26);
            this.buttonX1.TabIndex = 58;
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
            this.buttonX3.Location = new System.Drawing.Point(19, 157);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(71, 26);
            this.buttonX3.TabIndex = 57;
            this.buttonX3.Text = "&Imprimer";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // cmbsec
            // 
            this.cmbsec.DisplayMember = "Text";
            this.cmbsec.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbsec.FormattingEnabled = true;
            this.cmbsec.ItemHeight = 14;
            this.cmbsec.Location = new System.Drawing.Point(63, 12);
            this.cmbsec.Name = "cmbsec";
            this.cmbsec.Size = new System.Drawing.Size(356, 20);
            this.cmbsec.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbsec.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Famille:";
            // 
            // nomc
            // 
            this.nomc.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.nomc.Border.Class = "TextBoxBorder";
            this.nomc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.nomc.Location = new System.Drawing.Point(141, 48);
            this.nomc.MaxLength = 50;
            this.nomc.Name = "nomc";
            this.nomc.Size = new System.Drawing.Size(278, 20);
            this.nomc.TabIndex = 165;
            this.nomc.TextChanged += new System.EventHandler(this.nomc_TextChanged);
            this.nomc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nomc_KeyDown);
            // 
            // codec
            // 
            this.codec.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.codec.Border.Class = "TextBoxBorder";
            this.codec.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.codec.Location = new System.Drawing.Point(64, 48);
            this.codec.MaxLength = 10;
            this.codec.Name = "codec";
            this.codec.Size = new System.Drawing.Size(77, 20);
            this.codec.TabIndex = 164;
            this.codec.TextChanged += new System.EventHandler(this.codec_TextChanged);
            this.codec.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codec_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 166;
            this.label8.Text = "Client :";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.ForeColor = System.Drawing.Color.SkyBlue;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(63, 64);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(356, 108);
            this.listBox1.TabIndex = 167;
            this.listBox1.Visible = false;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            // 
            // impart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(449, 195);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.nomc);
            this.Controls.Add(this.codec);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.cmbsec);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.Name = "impart";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impression Article";
            this.Load += new System.EventHandler(this.impart_Load);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox11;
        public Myradio rbnom;
        public Myradio rbcode;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private Mycombo cmbsec;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX nomc;
        private DevComponents.DotNetBar.Controls.TextBoxX codec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBox1;
    }
}