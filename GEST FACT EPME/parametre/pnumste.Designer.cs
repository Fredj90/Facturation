namespace EPME
{
    partial class pnumste
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pnumste));
            this.t1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.t2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.t5 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // t1
            // 
            // 
            // 
            // 
            this.t1.Border.Class = "TextBoxBorder";
            this.t1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.t1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t1.Location = new System.Drawing.Point(20, 50);
            this.t1.MaxLength = 3;
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(25, 22);
            this.t1.TabIndex = 2;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerColorTint = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Facture Client";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Image = ((System.Drawing.Image)(resources.GetObject("buttonX1.Image")));
            this.buttonX1.Location = new System.Drawing.Point(326, 150);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(108, 37);
            this.buttonX1.TabIndex = 16;
            this.buttonX1.Text = "Valider";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.t5);
            this.groupBox1.Controls.Add(this.t1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.t2);
            this.groupBox1.Location = new System.Drawing.Point(24, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 103);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pièces Client  ,  Fournisseur";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(322, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Code Client";
            // 
            // t2
            // 
            // 
            // 
            // 
            this.t2.Border.Class = "TextBoxBorder";
            this.t2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.t2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t2.Location = new System.Drawing.Point(43, 50);
            this.t2.MaxLength = 8;
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(62, 22);
            this.t2.TabIndex = 3;
            // 
            // t5
            // 
            // 
            // 
            // 
            this.t5.Border.Class = "TextBoxBorder";
            this.t5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.t5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t5.Location = new System.Drawing.Point(314, 50);
            this.t5.MaxLength = 10;
            this.t5.Name = "t5";
            this.t5.Size = new System.Drawing.Size(81, 22);
            this.t5.TabIndex = 6;
            // 
            // pnumste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(526, 202);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "pnumste";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paramétres   Numéro   Société";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pnumste_FormClosed);
            this.Load += new System.EventHandler(this.pnumste_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX t1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.TextBoxX t2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX t5;
    }
}