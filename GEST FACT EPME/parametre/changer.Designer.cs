namespace EPME
{
    partial class changer
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
            this.magasin = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.ste = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Exerc = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Soc = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.SuspendLayout();
            // 
            // magasin
            // 
            this.magasin.DisplayMember = "Text";
            this.magasin.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.magasin.FormattingEnabled = true;
            this.magasin.ItemHeight = 14;
            this.magasin.Location = new System.Drawing.Point(328, 68);
            this.magasin.Name = "magasin";
            this.magasin.Size = new System.Drawing.Size(40, 20);
            this.magasin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.magasin.TabIndex = 147;
            this.magasin.Visible = false;
            // 
            // ste
            // 
            this.ste.DisplayMember = "Text";
            this.ste.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ste.FormattingEnabled = true;
            this.ste.ItemHeight = 14;
            this.ste.Location = new System.Drawing.Point(328, 37);
            this.ste.Name = "ste";
            this.ste.Size = new System.Drawing.Size(40, 20);
            this.ste.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ste.TabIndex = 145;
            this.ste.Visible = false;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.White;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.FocusCuesEnabled = false;
            this.buttonX1.ForeColor = System.Drawing.Color.White;
            this.buttonX1.Location = new System.Drawing.Point(234, 84);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(88, 26);
            this.buttonX1.TabIndex = 140;
            this.buttonX1.Text = "&Annuler";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.BackColor = System.Drawing.Color.White;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX2.FocusCuesEnabled = false;
            this.buttonX2.ForeColor = System.Drawing.Color.White;
            this.buttonX2.Location = new System.Drawing.Point(63, 84);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(88, 26);
            this.buttonX2.TabIndex = 139;
            this.buttonX2.Text = "&Connecter";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 144;
            this.label4.Text = "Exercice:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 143;
            this.label1.Text = "Societé :";
            // 
            // Exerc
            // 
            this.Exerc.DisplayMember = "Text";
            this.Exerc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Exerc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Exerc.FormattingEnabled = true;
            this.Exerc.ItemHeight = 14;
            this.Exerc.Location = new System.Drawing.Point(63, 47);
            this.Exerc.Name = "Exerc";
            this.Exerc.Size = new System.Drawing.Size(259, 20);
            this.Exerc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Exerc.TabIndex = 138;
            // 
            // Soc
            // 
            this.Soc.DisplayMember = "Text";
            this.Soc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Soc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Soc.FormattingEnabled = true;
            this.Soc.ItemHeight = 14;
            this.Soc.Location = new System.Drawing.Point(63, 21);
            this.Soc.Name = "Soc";
            this.Soc.Size = new System.Drawing.Size(259, 20);
            this.Soc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Soc.TabIndex = 136;
            this.Soc.SelectedIndexChanged += new System.EventHandler(this.Soc_SelectedIndexChanged);
            // 
            // changer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(374, 122);
            this.Controls.Add(this.magasin);
            this.Controls.Add(this.ste);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exerc);
            this.Controls.Add(this.Soc);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "changer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Changer";
            this.Load += new System.EventHandler(this.changer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx magasin;
        private DevComponents.DotNetBar.Controls.ComboBoxEx ste;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx Exerc;
        private DevComponents.DotNetBar.Controls.ComboBoxEx Soc;
    }
}