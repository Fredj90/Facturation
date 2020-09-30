namespace EPME
{
    partial class rechartmaj
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Tcod = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Tlib = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.Tcod1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Tlib1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.a0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeg1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coded1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.a0,
            this.a8,
            this.a1,
            this.a9,
            this.a3,
            this.a2,
            this.a4,
            this.a5,
            this.a6,
            this.codeg1,
            this.coded1,
            this.code1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(142)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(12, 95);
            this.dataGridViewX1.MultiSelect = false;
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(831, 266);
            this.dataGridViewX1.TabIndex = 128;
            this.dataGridViewX1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewX1_CellFormatting);
            this.dataGridViewX1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewX1_DataError);
            this.dataGridViewX1.DoubleClick += new System.EventHandler(this.dataGridViewX1_DoubleClick);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(385, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 130;
            this.label2.Text = "Libéllé";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(105, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 129;
            this.label1.Text = "Code";
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
            this.Tcod.Location = new System.Drawing.Point(108, 26);
            this.Tcod.MaxLength = 15;
            this.Tcod.Name = "Tcod";
            this.Tcod.Size = new System.Drawing.Size(139, 20);
            this.Tcod.TabIndex = 126;
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
            this.Tlib.Location = new System.Drawing.Point(388, 26);
            this.Tlib.MaxLength = 15;
            this.Tlib.Name = "Tlib";
            this.Tlib.Size = new System.Drawing.Size(455, 20);
            this.Tlib.TabIndex = 127;
            this.Tlib.TextChanged += new System.EventHandler(this.Tlib_TextChanged);
            this.Tlib.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tlib_KeyDown);
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxX1.ForeColor = System.Drawing.Color.Cyan;
            this.textBoxX1.Location = new System.Drawing.Point(9, 371);
            this.textBoxX1.MaxLength = 15;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxX1.Size = new System.Drawing.Size(110, 27);
            this.textBoxX1.TabIndex = 131;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(120, 375);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 132;
            this.label3.Text = "Lignes";
            // 
            // Tcod1
            // 
            this.Tcod1.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.Tcod1.Border.Class = "TextBoxBorder";
            this.Tcod1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Tcod1.ForeColor = System.Drawing.Color.Cyan;
            this.Tcod1.Location = new System.Drawing.Point(108, 58);
            this.Tcod1.MaxLength = 15;
            this.Tcod1.Name = "Tcod1";
            this.Tcod1.Size = new System.Drawing.Size(139, 20);
            this.Tcod1.TabIndex = 133;
            this.Tcod1.TextChanged += new System.EventHandler(this.Tcod1_TextChanged);
            // 
            // Tlib1
            // 
            this.Tlib1.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.Tlib1.Border.Class = "TextBoxBorder";
            this.Tlib1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Tlib1.ForeColor = System.Drawing.Color.Cyan;
            this.Tlib1.Location = new System.Drawing.Point(388, 58);
            this.Tlib1.MaxLength = 15;
            this.Tlib1.Name = "Tlib1";
            this.Tlib1.Size = new System.Drawing.Size(455, 20);
            this.Tlib1.TabIndex = 134;
            this.Tlib1.TextChanged += new System.EventHandler(this.Tlib1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 136;
            this.label4.Text = "Commence par :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(12, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 135;
            this.label5.Text = "Contient :";
            // 
            // a0
            // 
            this.a0.DataPropertyName = "codea";
            this.a0.HeaderText = "Code";
            this.a0.Name = "a0";
            this.a0.ReadOnly = true;
            // 
            // a8
            // 
            this.a8.DataPropertyName = "code";
            this.a8.HeaderText = "Code";
            this.a8.Name = "a8";
            this.a8.ReadOnly = true;
            // 
            // a1
            // 
            this.a1.DataPropertyName = "libelle";
            this.a1.HeaderText = "Libelle";
            this.a1.MaxInputLength = 50;
            this.a1.Name = "a1";
            this.a1.ReadOnly = true;
            this.a1.Width = 200;
            // 
            // a9
            // 
            this.a9.DataPropertyName = "des";
            this.a9.HeaderText = "Libéllé";
            this.a9.Name = "a9";
            this.a9.ReadOnly = true;
            this.a9.Width = 200;
            // 
            // a3
            // 
            this.a3.DataPropertyName = "gamme";
            this.a3.HeaderText = "Gamme";
            this.a3.Name = "a3";
            this.a3.ReadOnly = true;
            // 
            // a2
            // 
            this.a2.DataPropertyName = "depot";
            this.a2.HeaderText = "Dépôt";
            this.a2.Name = "a2";
            this.a2.ReadOnly = true;
            // 
            // a4
            // 
            this.a4.DataPropertyName = "qtestk";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.Format = "N3";
            this.a4.DefaultCellStyle = dataGridViewCellStyle1;
            this.a4.HeaderText = "Stock";
            this.a4.Name = "a4";
            this.a4.ReadOnly = true;
            this.a4.Width = 120;
            // 
            // a5
            // 
            this.a5.DataPropertyName = "puht";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            this.a5.DefaultCellStyle = dataGridViewCellStyle2;
            this.a5.HeaderText = "P.U.H.T";
            this.a5.Name = "a5";
            this.a5.ReadOnly = true;
            // 
            // a6
            // 
            this.a6.DataPropertyName = "tva";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.a6.DefaultCellStyle = dataGridViewCellStyle3;
            this.a6.HeaderText = "TVA";
            this.a6.Name = "a6";
            this.a6.ReadOnly = true;
            this.a6.Width = 50;
            // 
            // codeg1
            // 
            this.codeg1.DataPropertyName = "codeg";
            this.codeg1.HeaderText = "codeg";
            this.codeg1.Name = "codeg1";
            this.codeg1.ReadOnly = true;
            this.codeg1.Visible = false;
            // 
            // coded1
            // 
            this.coded1.DataPropertyName = "coded";
            this.coded1.HeaderText = "coded";
            this.coded1.Name = "coded1";
            this.coded1.ReadOnly = true;
            this.coded1.Visible = false;
            // 
            // code1
            // 
            this.code1.DataPropertyName = "code1";
            this.code1.HeaderText = "Column1";
            this.code1.Name = "code1";
            this.code1.ReadOnly = true;
            this.code1.Visible = false;
            // 
            // rechartmaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(852, 411);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Tcod1);
            this.Controls.Add(this.Tlib1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tcod);
            this.Controls.Add(this.Tlib);
            this.MaximizeBox = false;
            this.Name = "rechartmaj";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recherche Article";
            this.Load += new System.EventHandler(this.rechartmaj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public DevComponents.DotNetBar.Controls.TextBoxX Tcod;
        private DevComponents.DotNetBar.Controls.TextBoxX Tlib;
        public DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private System.Windows.Forms.Label label3;
        public DevComponents.DotNetBar.Controls.TextBoxX Tcod1;
        private DevComponents.DotNetBar.Controls.TextBoxX Tlib1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn a0;
        private System.Windows.Forms.DataGridViewTextBoxColumn a8;
        private System.Windows.Forms.DataGridViewTextBoxColumn a1;
        private System.Windows.Forms.DataGridViewTextBoxColumn a9;
        private System.Windows.Forms.DataGridViewTextBoxColumn a3;
        private System.Windows.Forms.DataGridViewTextBoxColumn a2;
        private System.Windows.Forms.DataGridViewTextBoxColumn a4;
        private System.Windows.Forms.DataGridViewTextBoxColumn a5;
        private System.Windows.Forms.DataGridViewTextBoxColumn a6;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeg1;
        private System.Windows.Forms.DataGridViewTextBoxColumn coded1;
        private System.Windows.Forms.DataGridViewTextBoxColumn code1;
    }
}