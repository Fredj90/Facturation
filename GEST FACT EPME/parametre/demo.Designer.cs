namespace EPME
{
    partial class demp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(demp));
            this.buttonX9 = new DevComponents.DotNetBar.ButtonX();
            this.nbj = new Mytext();
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonX9
            // 
            this.buttonX9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX9.BackColor = System.Drawing.Color.White;
            this.buttonX9.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX9.FocusCuesEnabled = false;
            this.buttonX9.ForeColor = System.Drawing.Color.White;
            this.buttonX9.Location = new System.Drawing.Point(47, 95);
            this.buttonX9.Name = "buttonX9";
            this.buttonX9.Size = new System.Drawing.Size(88, 26);
            this.buttonX9.TabIndex = 11;
            this.buttonX9.Text = "&Sauver";
            this.buttonX9.Click += new System.EventHandler(this.buttonX9_Click);
            // 
            // nbj
            // 
            this.nbj.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.nbj.Border.Class = "TextBoxBorder";
            this.nbj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.nbj.Location = new System.Drawing.Point(66, 31);
            this.nbj.MaxLength = 40;
            this.nbj.Name = "nbj";
            this.nbj.Size = new System.Drawing.Size(41, 20);
            this.nbj.TabIndex = 0;
            this.superValidator1.SetValidator1(this.nbj, this.requiredFieldValidator1);
            // 
            // superValidator1
            // 
            this.superValidator1.ContainerControl = this;
            this.superValidator1.ErrorProvider = this.errorProvider1;
            this.superValidator1.Highlighter = this.highlighter1;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // demp
            // 
            this.ClientSize = new System.Drawing.Size(183, 155);
            this.Controls.Add(this.nbj);
            this.Controls.Add(this.buttonX9);
            this.MaximizeBox = false;
            this.Name = "demp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.demp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX9;
        private Mytext nbj;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
    }
}