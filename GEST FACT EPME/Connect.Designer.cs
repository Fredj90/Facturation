namespace EPME
{
    partial class Connect
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
            this.PWD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Log = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Soc = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Exerc = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // PWD
            // 
            this.PWD.BackColor = System.Drawing.Color.White;
            this.PWD.Location = new System.Drawing.Point(63, 53);
            this.PWD.MaxLength = 10;
            this.PWD.Name = "PWD";
            this.PWD.Size = new System.Drawing.Size(259, 20);
            this.PWD.TabIndex = 2;
            this.PWD.UseSystemPasswordChar = true;
            this.PWD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PWD_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 121;
            this.label3.Text = "M.Passe:";
            // 
            // Log
            // 
            this.Log.BackColor = System.Drawing.Color.White;
            this.Log.Location = new System.Drawing.Point(63, 20);
            this.Log.MaxLength = 50;
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(259, 20);
            this.Log.TabIndex = 1;
            this.Log.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Log_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 119;
            this.label2.Text = "Login     :";
            // 
            // Soc
            // 
            this.Soc.DisplayMember = "Text";
            this.Soc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Soc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Soc.FormattingEnabled = true;
            this.Soc.ItemHeight = 14;
            this.Soc.Location = new System.Drawing.Point(63, 90);
            this.Soc.Name = "Soc";
            this.Soc.Size = new System.Drawing.Size(259, 20);
            this.Soc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Soc.TabIndex = 3;
            this.Soc.SelectedIndexChanged += new System.EventHandler(this.Soc_SelectedIndexChanged);
            this.Soc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Soc_KeyDown);
            // 
            // Exerc
            // 
            this.Exerc.DisplayMember = "Text";
            this.Exerc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Exerc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Exerc.FormattingEnabled = true;
            this.Exerc.ItemHeight = 14;
            this.Exerc.Location = new System.Drawing.Point(63, 124);
            this.Exerc.Name = "Exerc";
            this.Exerc.Size = new System.Drawing.Size(259, 20);
            this.Exerc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Exerc.TabIndex = 5;
            this.Exerc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Exerc_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 124;
            this.label1.Text = "Societé :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 125;
            this.label4.Text = "Exercice:";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.BackColor = System.Drawing.Color.White;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX2.FocusCuesEnabled = false;
            this.buttonX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.ForeColor = System.Drawing.Color.White;
            this.buttonX2.Location = new System.Drawing.Point(10, 167);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(133, 36);
            this.buttonX2.TabIndex = 6;
            this.buttonX2.Text = "&Connecter";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.White;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.FocusCuesEnabled = false;
            this.buttonX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.ForeColor = System.Drawing.Color.White;
            this.buttonX1.Location = new System.Drawing.Point(187, 167);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(135, 36);
            this.buttonX1.TabIndex = 7;
            this.buttonX1.Text = "&Annuler";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(369, 236);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exerc);
            this.Controls.Add(this.Soc);
            this.Controls.Add(this.PWD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Connect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection";
            this.Load += new System.EventHandler(this.Connect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PWD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx Soc;
        private DevComponents.DotNetBar.Controls.ComboBoxEx Exerc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}