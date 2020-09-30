namespace commerciale
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Tcod = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Tlib = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.a0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(212, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 125;
            this.label2.Text = "Libéllé";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(1, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 124;
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
            this.Tcod.Location = new System.Drawing.Point(39, 11);
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
            this.Tlib.Location = new System.Drawing.Point(254, 13);
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
            this.a1});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(142)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(4, 42);
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
            // recha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 305);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.label2);
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

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public DevComponents.DotNetBar.Controls.TextBoxX Tcod;
        private DevComponents.DotNetBar.Controls.TextBoxX Tlib;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn a0;
        private System.Windows.Forms.DataGridViewTextBoxColumn a1;
    }
}