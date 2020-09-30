namespace EPME
{
    partial class secteura
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(secteura));
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.textBox2 = new Mytext();
            this.requiredFieldValidator5 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.requiredFieldValidator4 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.label4 = new System.Windows.Forms.Label();
            this.buttonX8 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX7 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX11 = new DevComponents.DotNetBar.ButtonX();
            this.textBox1 = new Mytext();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonX9 = new DevComponents.DotNetBar.ButtonX();
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // superValidator1
            // 
            this.superValidator1.ErrorProvider = this.errorProvider1;
            this.superValidator1.Highlighter = this.highlighter1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBox2.Border.Class = "TextBoxBorder";
            this.textBox2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBox2.Location = new System.Drawing.Point(73, 72);
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(298, 26);
            this.textBox2.TabIndex = 178;
            this.superValidator1.SetValidator1(this.textBox2, this.requiredFieldValidator5);
            // 
            // requiredFieldValidator5
            // 
            this.requiredFieldValidator5.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator5.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 191;
            this.label3.Text = "Libéllé :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(313, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 181;
            // 
            // requiredFieldValidator4
            // 
            this.requiredFieldValidator4.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(90, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 182;
            // 
            // buttonX8
            // 
            this.buttonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX8.FocusCuesEnabled = false;
            this.buttonX8.Location = new System.Drawing.Point(364, 3);
            this.buttonX8.Name = "buttonX8";
            this.buttonX8.Size = new System.Drawing.Size(37, 26);
            this.buttonX8.TabIndex = 187;
            this.buttonX8.Text = "&Fin";
            this.buttonX8.Click += new System.EventHandler(this.buttonX8_Click);
            // 
            // buttonX7
            // 
            this.buttonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX7.FocusCuesEnabled = false;
            this.buttonX7.Location = new System.Drawing.Point(235, 3);
            this.buttonX7.Name = "buttonX7";
            this.buttonX7.Size = new System.Drawing.Size(37, 26);
            this.buttonX7.TabIndex = 186;
            this.buttonX7.Text = "&Début";
            this.buttonX7.Click += new System.EventHandler(this.buttonX7_Click);
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX6.FocusCuesEnabled = false;
            this.buttonX6.Location = new System.Drawing.Point(321, 3);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(37, 26);
            this.buttonX6.TabIndex = 185;
            this.buttonX6.Text = "&Préc";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // buttonX11
            // 
            this.buttonX11.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX11.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX11.FocusCuesEnabled = false;
            this.buttonX11.Location = new System.Drawing.Point(278, 3);
            this.buttonX11.Name = "buttonX11";
            this.buttonX11.Size = new System.Drawing.Size(37, 26);
            this.buttonX11.TabIndex = 184;
            this.buttonX11.Text = "&Suiv";
            this.buttonX11.Click += new System.EventHandler(this.buttonX11_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBox1.Border.Class = "TextBoxBorder";
            this.textBox1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox1.Location = new System.Drawing.Point(340, 46);
            this.textBox1.MaxLength = 3;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(29, 20);
            this.textBox1.TabIndex = 177;
            this.textBox1.Visible = false;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerColorTint = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.AutoExpandOnClick = true;
            this.buttonX5.Location = new System.Drawing.Point(2, 0);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(125, 26);
            this.buttonX5.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem2,
            this.buttonItem3});
            this.buttonX5.TabIndex = 183;
            this.buttonX5.Text = "Menu";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "Créer              F5";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem2.Image")));
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "Modifier          F6\r\n";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem3.Image")));
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "Supprimer       F7";
            this.buttonItem3.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // buttonX9
            // 
            this.buttonX9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX9.BackColor = System.Drawing.Color.White;
            this.buttonX9.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX9.FocusCuesEnabled = false;
            this.buttonX9.ForeColor = System.Drawing.Color.White;
            this.buttonX9.Location = new System.Drawing.Point(333, 146);
            this.buttonX9.Name = "buttonX9";
            this.buttonX9.Size = new System.Drawing.Size(57, 26);
            this.buttonX9.TabIndex = 190;
            this.buttonX9.Text = "Fermer";
            this.buttonX9.Click += new System.EventHandler(this.buttonX9_Click);
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.White;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.FocusCuesEnabled = false;
            this.buttonX1.ForeColor = System.Drawing.Color.White;
            this.buttonX1.Location = new System.Drawing.Point(113, 145);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(88, 26);
            this.buttonX1.TabIndex = 180;
            this.buttonX1.Text = "Annuler";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.BackColor = System.Drawing.Color.White;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX2.FocusCuesEnabled = false;
            this.buttonX2.ForeColor = System.Drawing.Color.White;
            this.buttonX2.Location = new System.Drawing.Point(15, 146);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(88, 26);
            this.buttonX2.TabIndex = 179;
            this.buttonX2.Text = "Sauver";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.BackColor = System.Drawing.Color.White;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX4.FocusCuesEnabled = false;
            this.buttonX4.ForeColor = System.Drawing.Color.White;
            this.buttonX4.Location = new System.Drawing.Point(15, 144);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(88, 26);
            this.buttonX4.TabIndex = 188;
            this.buttonX4.Text = "Supprimer";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.BackColor = System.Drawing.Color.White;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX3.FocusCuesEnabled = false;
            this.buttonX3.ForeColor = System.Drawing.Color.White;
            this.buttonX3.Location = new System.Drawing.Point(113, 143);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(88, 26);
            this.buttonX3.TabIndex = 189;
            this.buttonX3.Text = "Annuler";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // secteura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(403, 182);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonX8);
            this.Controls.Add(this.buttonX7);
            this.Controls.Add(this.buttonX6);
            this.Controls.Add(this.buttonX11);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonX5);
            this.Controls.Add(this.buttonX9);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX4);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "secteura";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secteur";
            this.Load += new System.EventHandler(this.secteura_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.secteura_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX buttonX8;
        private DevComponents.DotNetBar.ButtonX buttonX7;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        private DevComponents.DotNetBar.ButtonX buttonX11;
        private Mytext textBox1;
        private DevComponents.DotNetBar.ButtonX buttonX5;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonX buttonX9;
        private Mytext textBox2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator5;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator4;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
    }
}