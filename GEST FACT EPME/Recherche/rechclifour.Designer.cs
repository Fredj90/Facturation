namespace EPME
{
    partial class rechcli
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.Tcod = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Tlib = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
           // this.lentdTableAdapter1 = new EPME.commerceDataSetTableAdapters.lentdTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.tcod1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tlib1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.c0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 119;
            this.label1.Text = "Contient :";
            // 
            // Tcod
            // 
            this.Tcod.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.Tcod.Border.Class = "TextBoxBorder";
            this.Tcod.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Tcod.ForeColor = System.Drawing.Color.Cyan;
            this.Tcod.Location = new System.Drawing.Point(111, 28);
            this.Tcod.MaxLength = 15;
            this.Tcod.Name = "Tcod";
            this.Tcod.Size = new System.Drawing.Size(115, 20);
            this.Tcod.TabIndex = 0;
            this.Tcod.TextChanged += new System.EventHandler(this.Tcod_TextChanged);
            this.Tcod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tcod_KeyDown);
            // 
            // Tlib
            // 
            this.Tlib.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.Tlib.Border.Class = "TextBoxBorder";
            this.Tlib.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Tlib.ForeColor = System.Drawing.Color.Cyan;
            this.Tlib.Location = new System.Drawing.Point(259, 28);
            this.Tlib.MaxLength = 15;
            this.Tlib.Name = "Tlib";
            this.Tlib.Size = new System.Drawing.Size(342, 20);
            this.Tlib.TabIndex = 1;
            this.Tlib.TextChanged += new System.EventHandler(this.Tlib_TextChanged);
            this.Tlib.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tlib_KeyDown);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c0,
            this.code1,
            this.c1,
            this.c2,
            this.c5,
            this.c6,
            this.c7});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(17, 92);
            this.dataGridViewX1.MultiSelect = false;
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(584, 259);
            this.dataGridViewX1.TabIndex = 2;
            this.dataGridViewX1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewX1_CellFormatting);
            this.dataGridViewX1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewX1_DataError);
            this.dataGridViewX1.DoubleClick += new System.EventHandler(this.dataGridViewX1_DoubleClick);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            // 
            // lentdTableAdapter1
            // 
            //this.lentdTableAdapter1.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(17, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 123;
            this.label4.Text = "Commence par :";
            // 
            // tcod1
            // 
            this.tcod1.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.tcod1.Border.Class = "TextBoxBorder";
            this.tcod1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tcod1.ForeColor = System.Drawing.Color.Cyan;
            this.tcod1.Location = new System.Drawing.Point(111, 60);
            this.tcod1.MaxLength = 15;
            this.tcod1.Name = "tcod1";
            this.tcod1.Size = new System.Drawing.Size(115, 20);
            this.tcod1.TabIndex = 121;
            this.tcod1.TextChanged += new System.EventHandler(this.Tcod1_TextChanged);
            // 
            // tlib1
            // 
            this.tlib1.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.tlib1.Border.Class = "TextBoxBorder";
            this.tlib1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tlib1.ForeColor = System.Drawing.Color.Cyan;
            this.tlib1.Location = new System.Drawing.Point(259, 60);
            this.tlib1.MaxLength = 15;
            this.tlib1.Name = "tlib1";
            this.tlib1.Size = new System.Drawing.Size(342, 20);
            this.tlib1.TabIndex = 122;
            this.tlib1.TextChanged += new System.EventHandler(this.Tlib1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(156, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 125;
            this.label5.Text = "Code ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(341, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 126;
            this.label6.Text = "Libéllé";
            // 
            // c0
            // 
            this.c0.DataPropertyName = "code";
            this.c0.HeaderText = "Code";
            this.c0.Name = "c0";
            this.c0.ReadOnly = true;
            // 
            // code1
            // 
            this.code1.DataPropertyName = "code1";
            this.code1.HeaderText = "Column1";
            this.code1.Name = "code1";
            this.code1.ReadOnly = true;
            this.code1.Visible = false;
            // 
            // c1
            // 
            this.c1.DataPropertyName = "libelle";
            this.c1.HeaderText = "Libelle";
            this.c1.Name = "c1";
            this.c1.ReadOnly = true;
            this.c1.Width = 200;
            // 
            // c2
            // 
            this.c2.DataPropertyName = "adrf";
            this.c2.HeaderText = "Adresse";
            this.c2.Name = "c2";
            this.c2.ReadOnly = true;
            this.c2.Width = 230;
            // 
            // c5
            // 
            this.c5.DataPropertyName = "acompte";
            this.c5.HeaderText = "acompte";
            this.c5.Name = "c5";
            this.c5.ReadOnly = true;
            this.c5.Visible = false;
            // 
            // c6
            // 
            this.c6.DataPropertyName = "solde1";
            this.c6.HeaderText = "Column1";
            this.c6.Name = "c6";
            this.c6.ReadOnly = true;
            this.c6.Visible = false;
            // 
            // c7
            // 
            this.c7.DataPropertyName = "regsoldn1";
            this.c7.HeaderText = "Column1";
            this.c7.Name = "c7";
            this.c7.ReadOnly = true;
            this.c7.Visible = false;
            // 
            // rechcli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(620, 363);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tcod1);
            this.Controls.Add(this.tlib1);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tcod);
            this.Controls.Add(this.Tlib);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "rechcli";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recherche ";
            this.Load += new System.EventHandler(this.rechcli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public DevComponents.DotNetBar.Controls.TextBoxX Tcod;
        private DevComponents.DotNetBar.Controls.TextBoxX Tlib;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
       // private commerceDataSetTableAdapters.lentdTableAdapter lentdTableAdapter1;
        private System.Windows.Forms.Label label4;
        public DevComponents.DotNetBar.Controls.TextBoxX tcod1;
        private DevComponents.DotNetBar.Controls.TextBoxX tlib1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0;
        private System.Windows.Forms.DataGridViewTextBoxColumn code1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2;
        private System.Windows.Forms.DataGridViewTextBoxColumn c5;
        private System.Windows.Forms.DataGridViewTextBoxColumn c6;
        private System.Windows.Forms.DataGridViewTextBoxColumn c7;
    }
}