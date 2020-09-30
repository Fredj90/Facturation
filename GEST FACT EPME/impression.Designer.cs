namespace EPME
{
    partial class impression
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
            this.rbpimp = new Myradio();
            this.rbord = new Myradio();
            this.refart = new System.Windows.Forms.CheckBox();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.Transparent;
            this.groupBox11.Controls.Add(this.rbpimp);
            this.groupBox11.Controls.Add(this.rbord);
            this.groupBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.Location = new System.Drawing.Point(24, 20);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(397, 69);
            this.groupBox11.TabIndex = 55;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Mode";
            this.groupBox11.Enter += new System.EventHandler(this.groupBox11_Enter);
            // 
            // rbpimp
            // 
            this.rbpimp.AutoSize = true;
            this.rbpimp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbpimp.Location = new System.Drawing.Point(31, 45);
            this.rbpimp.Name = "rbpimp";
            this.rbpimp.Size = new System.Drawing.Size(146, 19);
            this.rbpimp.TabIndex = 36;
            this.rbpimp.TabStop = true;
            this.rbpimp.Text = "Papier Préimprimé";
            this.rbpimp.UseVisualStyleBackColor = true;
            this.rbpimp.CheckedChanged += new System.EventHandler(this.rbpimp_CheckedChanged);
            // 
            // rbord
            // 
            this.rbord.AutoSize = true;
            this.rbord.Checked = true;
            this.rbord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbord.Location = new System.Drawing.Point(31, 19);
            this.rbord.Name = "rbord";
            this.rbord.Size = new System.Drawing.Size(131, 19);
            this.rbord.TabIndex = 35;
            this.rbord.TabStop = true;
            this.rbord.Text = "Papier Ordinaire";
            this.rbord.UseVisualStyleBackColor = true;
            this.rbord.CheckedChanged += new System.EventHandler(this.rbord_CheckedChanged);
            // 
            // refart
            // 
            this.refart.AutoSize = true;
            this.refart.Checked = true;
            this.refart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.refart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refart.Location = new System.Drawing.Point(55, 95);
            this.refart.Name = "refart";
            this.refart.Size = new System.Drawing.Size(198, 19);
            this.refart.TabIndex = 37;
            this.refart.Text = "Imprimer Réference Article";
            this.refart.UseVisualStyleBackColor = true;
            this.refart.CheckedChanged += new System.EventHandler(this.refart_CheckedChanged);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.White;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.FocusCuesEnabled = false;
            this.buttonX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(279, 131);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(122, 30);
            this.buttonX1.TabIndex = 57;
            this.buttonX1.Text = "&Fermer";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.BackColor = System.Drawing.Color.White;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX3.FocusCuesEnabled = false;
            this.buttonX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.Location = new System.Drawing.Point(61, 131);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(122, 30);
            this.buttonX3.TabIndex = 56;
            this.buttonX3.Text = "&Imprimer";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // impression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(453, 171);
            this.Controls.Add(this.refart);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.groupBox11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "impression";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impression";
            this.Load += new System.EventHandler(this.impression_Load);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox11;
        public Myradio rbpimp;
        public Myradio rbord;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private System.Windows.Forms.CheckBox refart;
    }
}