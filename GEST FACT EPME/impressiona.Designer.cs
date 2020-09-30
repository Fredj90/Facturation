namespace EPME
{
    partial class impressiona
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
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.rbpimp = new Myradio();
            this.rbord = new Myradio();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.White;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.FocusCuesEnabled = false;
            this.buttonX1.Location = new System.Drawing.Point(296, 95);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(71, 26);
            this.buttonX1.TabIndex = 60;
            this.buttonX1.Text = "&Fermer";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.BackColor = System.Drawing.Color.White;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX3.FocusCuesEnabled = false;
            this.buttonX3.Location = new System.Drawing.Point(129, 95);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(71, 26);
            this.buttonX3.TabIndex = 59;
            this.buttonX3.Text = "&Imprimer";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.Transparent;
            this.groupBox11.Controls.Add(this.rbpimp);
            this.groupBox11.Controls.Add(this.rbord);
            this.groupBox11.Location = new System.Drawing.Point(52, 22);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(397, 47);
            this.groupBox11.TabIndex = 58;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Mode";
            // 
            // rbpimp
            // 
            this.rbpimp.AutoSize = true;
            this.rbpimp.Location = new System.Drawing.Point(267, 19);
            this.rbpimp.Name = "rbpimp";
            this.rbpimp.Size = new System.Drawing.Size(110, 17);
            this.rbpimp.TabIndex = 36;
            this.rbpimp.TabStop = true;
            this.rbpimp.Text = "Papier Préimprimé";
            this.rbpimp.UseVisualStyleBackColor = true;
            this.rbpimp.CheckedChanged += new System.EventHandler(this.rbpimp_CheckedChanged);
            // 
            // rbord
            // 
            this.rbord.AutoSize = true;
            this.rbord.Location = new System.Drawing.Point(31, 19);
            this.rbord.Name = "rbord";
            this.rbord.Size = new System.Drawing.Size(102, 17);
            this.rbord.TabIndex = 35;
            this.rbord.TabStop = true;
            this.rbord.Text = "Papier Ordinaire";
            this.rbord.UseVisualStyleBackColor = true;
            this.rbord.CheckedChanged += new System.EventHandler(this.rbord_CheckedChanged);
            // 
            // impressiona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 142);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.groupBox11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "impressiona";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impression";
            this.Load += new System.EventHandler(this.impressiona_Load);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        public Myradio rbpimp;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private System.Windows.Forms.GroupBox groupBox11;
        public Myradio rbord;
    }
}