namespace EPME
{
    partial class orgclient
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonX9 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.xdate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.mygrid2 = new Mygrid();
            this.codea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.libellea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.choixp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mygrid1 = new Mygrid();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.libelle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.choix = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.xdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mygrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mygrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonX9
            // 
            this.buttonX9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX9.BackColor = System.Drawing.Color.White;
            this.buttonX9.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX9.FocusCuesEnabled = false;
            this.buttonX9.ForeColor = System.Drawing.Color.White;
            this.buttonX9.Location = new System.Drawing.Point(137, 169);
            this.buttonX9.Name = "buttonX9";
            this.buttonX9.Size = new System.Drawing.Size(94, 26);
            this.buttonX9.TabIndex = 199;
            this.buttonX9.Text = "&Recherche";
            this.buttonX9.Click += new System.EventHandler(this.buttonX9_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.White;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.FocusCuesEnabled = false;
            this.buttonX1.ForeColor = System.Drawing.Color.White;
            this.buttonX1.Location = new System.Drawing.Point(339, 8);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(94, 26);
            this.buttonX1.TabIndex = 188;
            this.buttonX1.Text = "&Sélectioner Tous";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.BackColor = System.Drawing.Color.White;
            this.buttonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX5.FocusCuesEnabled = false;
            this.buttonX5.ForeColor = System.Drawing.Color.White;
            this.buttonX5.Location = new System.Drawing.Point(70, 34);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(94, 26);
            this.buttonX5.TabIndex = 12;
            this.buttonX5.Text = "&Réorganiser";
            this.buttonX5.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // xdate
            // 
            // 
            // 
            // 
            this.xdate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.xdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.xdate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.xdate.ButtonDropDown.Visible = true;
            this.xdate.Location = new System.Drawing.Point(542, 53);
            // 
            // 
            // 
            this.xdate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.xdate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.xdate.MonthCalendar.BackgroundStyle.Class = "";
            this.xdate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.xdate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.xdate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.xdate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.xdate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.xdate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.xdate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.xdate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.xdate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.xdate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.xdate.MonthCalendar.DisplayMonth = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.xdate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.xdate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.xdate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.xdate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.xdate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.xdate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.xdate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.xdate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.xdate.MonthCalendar.TodayButtonVisible = true;
            this.xdate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.xdate.Name = "xdate";
            this.xdate.Size = new System.Drawing.Size(83, 20);
            this.xdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.xdate.TabIndex = 198;
            this.xdate.Visible = false;
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.BackColor = System.Drawing.Color.White;
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX6.FocusCuesEnabled = false;
            this.buttonX6.ForeColor = System.Drawing.Color.White;
            this.buttonX6.Location = new System.Drawing.Point(536, 14);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(94, 26);
            this.buttonX6.TabIndex = 195;
            this.buttonX6.Text = "&Fermer";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.BackColor = System.Drawing.Color.White;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX2.FocusCuesEnabled = false;
            this.buttonX2.ForeColor = System.Drawing.Color.White;
            this.buttonX2.Location = new System.Drawing.Point(323, 8);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(124, 26);
            this.buttonX2.TabIndex = 190;
            this.buttonX2.Text = "&Désélectioner Tous";
            this.buttonX2.Visible = false;
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // mygrid2
            // 
            this.mygrid2.AllowUserToAddRows = false;
            this.mygrid2.AllowUserToDeleteRows = false;
            this.mygrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mygrid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codea,
            this.libellea,
            this.choixp,
            this.ID});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mygrid2.DefaultCellStyle = dataGridViewCellStyle1;
            this.mygrid2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(142)))));
            this.mygrid2.Location = new System.Drawing.Point(9, 199);
            this.mygrid2.Name = "mygrid2";
            this.mygrid2.ReadOnly = true;
            this.mygrid2.Size = new System.Drawing.Size(438, 326);
            this.mygrid2.TabIndex = 191;
            this.mygrid2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mygrid2_CellClick);
            // 
            // codea
            // 
            this.codea.DataPropertyName = "code";
            this.codea.HeaderText = "Code";
            this.codea.MaxInputLength = 15;
            this.codea.Name = "codea";
            this.codea.ReadOnly = true;
            // 
            // libellea
            // 
            this.libellea.DataPropertyName = "libelle";
            this.libellea.HeaderText = "Libéllé";
            this.libellea.MaxInputLength = 50;
            this.libellea.Name = "libellea";
            this.libellea.ReadOnly = true;
            this.libellea.Width = 300;
            // 
            // choixp
            // 
            this.choixp.HeaderText = "Choix";
            this.choixp.Name = "choixp";
            this.choixp.ReadOnly = true;
            this.choixp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.choixp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.choixp.Width = 50;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // mygrid1
            // 
            this.mygrid1.AllowUserToAddRows = false;
            this.mygrid1.AllowUserToDeleteRows = false;
            this.mygrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mygrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.libelle,
            this.choix});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mygrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.mygrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(142)))));
            this.mygrid1.Location = new System.Drawing.Point(12, 37);
            this.mygrid1.Name = "mygrid1";
            this.mygrid1.ReadOnly = true;
            this.mygrid1.Size = new System.Drawing.Size(438, 115);
            this.mygrid1.TabIndex = 187;
            this.mygrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mygrid1_CellClick);
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "Code";
            this.code.MaxInputLength = 3;
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 50;
            // 
            // libelle
            // 
            this.libelle.DataPropertyName = "libelle";
            this.libelle.HeaderText = "Libéllé";
            this.libelle.MaxInputLength = 50;
            this.libelle.Name = "libelle";
            this.libelle.ReadOnly = true;
            this.libelle.Width = 350;
            // 
            // choix
            // 
            this.choix.HeaderText = "Choix";
            this.choix.Name = "choix";
            this.choix.ReadOnly = true;
            this.choix.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.choix.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.choix.Width = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 189;
            this.label3.Text = "Famille";
            // 
            // progressBarX1
            // 
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.Class = "";
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.Location = new System.Drawing.Point(445, 501);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new System.Drawing.Size(263, 24);
            this.progressBarX1.TabIndex = 197;
            this.progressBarX1.Text = "progressBarX1";
            this.progressBarX1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonX5);
            this.groupBox1.Location = new System.Drawing.Point(461, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 89);
            this.groupBox1.TabIndex = 196;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Traitement";
            this.groupBox1.Visible = false;
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.BackColor = System.Drawing.Color.White;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX3.FocusCuesEnabled = false;
            this.buttonX3.ForeColor = System.Drawing.Color.White;
            this.buttonX3.Location = new System.Drawing.Point(339, 169);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(94, 26);
            this.buttonX3.TabIndex = 192;
            this.buttonX3.Text = "&Sélectioner Tous";
            this.buttonX3.Visible = false;
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.BackColor = System.Drawing.Color.White;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX4.FocusCuesEnabled = false;
            this.buttonX4.ForeColor = System.Drawing.Color.White;
            this.buttonX4.Location = new System.Drawing.Point(322, 169);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(124, 26);
            this.buttonX4.TabIndex = 194;
            this.buttonX4.Text = "&Désélectioner Tous";
            this.buttonX4.Visible = false;
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 193;
            this.label4.Text = "Client";
            // 
            // orgclient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(717, 533);
            this.Controls.Add(this.buttonX9);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.xdate);
            this.Controls.Add(this.buttonX6);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.mygrid2);
            this.Controls.Add(this.mygrid1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBarX1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.Name = "orgclient";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Organisation Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.orgclient_FormClosed);
            this.Load += new System.EventHandler(this.orgclient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mygrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mygrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX9;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX5;
        public DevComponents.Editors.DateTimeAdv.DateTimeInput xdate;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private Mygrid mygrid2;
        private System.Windows.Forms.DataGridViewTextBoxColumn codea;
        private System.Windows.Forms.DataGridViewTextBoxColumn libellea;
        private System.Windows.Forms.DataGridViewCheckBoxColumn choixp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private Mygrid mygrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn libelle;
        private System.Windows.Forms.DataGridViewCheckBoxColumn choix;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private System.Windows.Forms.Label label4;
    }
}