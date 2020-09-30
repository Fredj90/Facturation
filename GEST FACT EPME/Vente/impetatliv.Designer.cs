namespace commerciale
{
    partial class impetatliv
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
            this.nomc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.codec = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.dated = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.datef = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datef)).BeginInit();
            this.SuspendLayout();
            // 
            // nomc
            // 
            this.nomc.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.nomc.Border.Class = "TextBoxBorder";
            this.nomc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.nomc.Location = new System.Drawing.Point(443, 15);
            this.nomc.MaxLength = 50;
            this.nomc.Name = "nomc";
            this.nomc.Size = new System.Drawing.Size(257, 20);
            this.nomc.TabIndex = 161;
            this.nomc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nomc_KeyUp);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.nomc);
            this.groupBox3.Controls.Add(this.codec);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.buttonX1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dated);
            this.groupBox3.Controls.Add(this.datef);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(10, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(819, 47);
            this.groupBox3.TabIndex = 167;
            this.groupBox3.TabStop = false;
            // 
            // codec
            // 
            this.codec.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.codec.Border.Class = "TextBoxBorder";
            this.codec.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.codec.Location = new System.Drawing.Point(366, 15);
            this.codec.MaxLength = 10;
            this.codec.Name = "codec";
            this.codec.Size = new System.Drawing.Size(77, 20);
            this.codec.TabIndex = 160;
            this.codec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codec_KeyPress);
            this.codec.KeyUp += new System.Windows.Forms.KeyEventHandler(this.codec_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(325, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 162;
            this.label8.Text = "Client :";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.White;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.FocusCuesEnabled = false;
            this.buttonX1.Location = new System.Drawing.Point(703, 12);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(98, 26);
            this.buttonX1.TabIndex = 159;
            this.buttonX1.Text = "&Imprimer  [ F2 ]";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 122;
            this.label1.Text = "Fin    :";
            // 
            // dated
            // 
            // 
            // 
            // 
            this.dated.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dated.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dated.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dated.ButtonDropDown.Visible = true;
            //this.dated.IsPopupCalendarOpen = false;
            this.dated.Location = new System.Drawing.Point(62, 15);
            // 
            // 
            // 
            this.dated.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dated.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dated.MonthCalendar.BackgroundStyle.Class = "";
            this.dated.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dated.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dated.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dated.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dated.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dated.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dated.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dated.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dated.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dated.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dated.MonthCalendar.DisplayMonth = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dated.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dated.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dated.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dated.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dated.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dated.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dated.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dated.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dated.MonthCalendar.TodayButtonVisible = true;
            this.dated.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dated.Name = "dated";
            this.dated.Size = new System.Drawing.Size(83, 20);
            this.dated.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dated.TabIndex = 1;
            this.dated.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dated_KeyPress);
            // 
            // datef
            // 
            // 
            // 
            // 
            this.datef.BackgroundStyle.Class = "DateTimeInputBackground";
            this.datef.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.datef.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.datef.ButtonDropDown.Visible = true;
            //this.datef.IsPopupCalendarOpen = false;
            this.datef.Location = new System.Drawing.Point(235, 15);
            // 
            // 
            // 
            this.datef.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.datef.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.datef.MonthCalendar.BackgroundStyle.Class = "";
            this.datef.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.datef.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.datef.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.datef.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.datef.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.datef.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.datef.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.datef.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.datef.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.datef.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.datef.MonthCalendar.DisplayMonth = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.datef.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.datef.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.datef.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.datef.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.datef.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.datef.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.datef.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.datef.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.datef.MonthCalendar.TodayButtonVisible = true;
            this.datef.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.datef.Name = "datef";
            this.datef.Size = new System.Drawing.Size(83, 20);
            this.datef.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.datef.TabIndex = 2;
            this.datef.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.datef_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "Début :";
            // 
            // impetatliv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(839, 81);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "impetatliv";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impression Etats Livraisons";
            this.Load += new System.EventHandler(this.impetatliv_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.impetatliv_KeyDown);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datef)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX nomc;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevComponents.DotNetBar.Controls.TextBoxX codec;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Label label1;
        public DevComponents.Editors.DateTimeAdv.DateTimeInput dated;
        public DevComponents.Editors.DateTimeAdv.DateTimeInput datef;
        private System.Windows.Forms.Label label2;
    }
}