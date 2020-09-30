namespace EPME
{
    partial class recha
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
            this.label3 = new System.Windows.Forms.Label();
            this.Tcod1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Tlib1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.a0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(120, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 124;
            this.label1.Text = "Code";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.Tcod.Location = new System.Drawing.Point(107, 29);
            this.Tcod.MaxLength = 15;
            this.Tcod.Name = "Tcod";
            this.Tcod.Size = new System.Drawing.Size(139, 20);
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
            this.Tlib.Location = new System.Drawing.Point(276, 29);
            this.Tlib.MaxLength = 15;
            this.Tlib.Name = "Tlib";
            this.Tlib.Size = new System.Drawing.Size(298, 20);
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
            this.a0,
            this.a1,
            this.code1});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(142)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(23, 94);
            this.dataGridViewX1.MultiSelect = false;
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(548, 255);
            this.dataGridViewX1.TabIndex = 2;
            this.dataGridViewX1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewX1_CellFormatting);
            this.dataGridViewX1.DoubleClick += new System.EventHandler(this.dataGridViewX1_DoubleClick);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(365, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 129;
            this.label3.Text = "Libéllé";
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
            this.Tcod1.Location = new System.Drawing.Point(107, 61);
            this.Tcod1.MaxLength = 15;
            this.Tcod1.Name = "Tcod1";
            this.Tcod1.Size = new System.Drawing.Size(139, 20);
            this.Tcod1.TabIndex = 126;
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
            this.Tlib1.Location = new System.Drawing.Point(276, 61);
            this.Tlib1.MaxLength = 15;
            this.Tlib1.Name = "Tlib1";
            this.Tlib1.Size = new System.Drawing.Size(298, 20);
            this.Tlib1.TabIndex = 127;
            this.Tlib1.TextChanged += new System.EventHandler(this.Tlib1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(23, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 131;
            this.label4.Text = "Commence par :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(23, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 130;
            this.label2.Text = "Contient :";
            // 
            // a0
            // 
            this.a0.DataPropertyName = "code";
            this.a0.HeaderText = "Code";
            this.a0.Name = "a0";
            this.a0.ReadOnly = true;
            this.a0.Width = 120;
            // 
            // a1
            // 
            this.a1.DataPropertyName = "libelle";
            this.a1.HeaderText = "Libelle";
            this.a1.MaxInputLength = 50;
            this.a1.Name = "a1";
            this.a1.ReadOnly = true;
            this.a1.Width = 378;
            // 
            // code1
            // 
            this.code1.DataPropertyName = "code1";
            this.code1.HeaderText = "Column1";
            this.code1.Name = "code1";
            this.code1.ReadOnly = true;
            this.code1.Visible = false;
            // 
            // recha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(596, 361);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Tcod1);
            this.Controls.Add(this.Tlib1);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tcod);
            this.Controls.Add(this.Tlib);
            this.MaximizeBox = false;
            this.Name = "recha";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recherche Article";
            this.Load += new System.EventHandler(this.recha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public DevComponents.DotNetBar.Controls.TextBoxX Tcod;
        private DevComponents.DotNetBar.Controls.TextBoxX Tlib;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.Label label3;
        public DevComponents.DotNetBar.Controls.TextBoxX Tcod1;
        private DevComponents.DotNetBar.Controls.TextBoxX Tlib1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn a0;
        private System.Windows.Forms.DataGridViewTextBoxColumn a1;
        private System.Windows.Forms.DataGridViewTextBoxColumn code1;
    }
}