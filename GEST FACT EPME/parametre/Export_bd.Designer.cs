namespace EPME
{
    partial class Export_bd
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
            this.pgGetTotalRows = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pgGetTotalRows
            // 
            // 
            // 
            // 
            this.pgGetTotalRows.BackgroundStyle.Class = "";
            this.pgGetTotalRows.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pgGetTotalRows.Location = new System.Drawing.Point(12, 141);
            this.pgGetTotalRows.Name = "pgGetTotalRows";
            this.pgGetTotalRows.Size = new System.Drawing.Size(369, 27);
            this.pgGetTotalRows.TabIndex = 0;
            this.pgGetTotalRows.Text = "progressBarX1";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(138, 12);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(96, 31);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 1;
            this.buttonX1.Text = "Exporter";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "S";
            // 
            // Export_bd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(393, 180);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.pgGetTotalRows);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Export_bd";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportation";
            this.Load += new System.EventHandler(this.Export_bd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ProgressBarX pgGetTotalRows;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Label label1;
    }
}