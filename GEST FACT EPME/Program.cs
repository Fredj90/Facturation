using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EPME
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static String Societe = "";
        public static String LibSociete = "";
        public static String Exercice = "";
        public static String User = "";
        public static String LibUser = "";
        public static String TypUser = "";
        public static Boolean TFunction=true;
        public static Boolean ISaDmin = false;
        public static Boolean ISSaDmin = false;
        public static Boolean ISFodec = false;
        public static Boolean ISDemo = false;
        public static Boolean ISAret = false;
        public static metier met = new metier();
        public static String Str_con;
        public static Boolean Demo = true;
        public static string sep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
        [STAThread]

        static void Main()
        {
            Demo = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Connect());
           // Application.Run(new lstock());
        }

        public static void desfunctionf(Form frm)
        {
            //try
            //{
            //    Program.TFunction = true;
            //    ((Menugen)frm.MdiParent).buttonX2.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            //    ((Menugen)frm.MdiParent).buttonX1.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            //    ((Menugen)frm.MdiParent).buttonX3.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            //    ((Menugen)frm.MdiParent).buttonX4.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            //    ((Menugen)frm.MdiParent).buttonX5.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            //    ((Menugen)frm.MdiParent).buttonX6.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            //    ((Menugen)frm.MdiParent).buttonX7.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F7);
            //    ((Menugen)frm.MdiParent).buttonX8.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            //    ((Menugen)frm.MdiParent).buttonX9.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F9);
            //    ((Menugen)frm.MdiParent).buttonX10.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F10);
            //    ((Menugen)frm.MdiParent).buttonX11.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F11);
            //    ((Menugen)frm.MdiParent).buttonX12.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            //}
            //catch { }
        }

        public static void desTfunction(Form frm)
        {
            //try
            //{
            //    ((Menugen)frm.MdiParent).buttonX1.Shortcuts.Clear();
            //    ((Menugen)frm.MdiParent).buttonX1.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);

            //    ((Menugen)frm.MdiParent).buttonX2.Shortcuts.Clear();
            //    ((Menugen)frm.MdiParent).buttonX2.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);

            //    ((Menugen)frm.MdiParent).buttonX3.Shortcuts.Clear();
            //    ((Menugen)frm.MdiParent).buttonX3.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);

            //    ((Menugen)frm.MdiParent).buttonX4.Shortcuts.Clear();
            //    ((Menugen)frm.MdiParent).buttonX4.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);

            //    ((Menugen)frm.MdiParent).buttonX5.Shortcuts.Clear();
            //    ((Menugen)frm.MdiParent).buttonX5.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);

            //    ((Menugen)frm.MdiParent).buttonX6.Shortcuts.Clear();
            //    ((Menugen)frm.MdiParent).buttonX6.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);

            //    ((Menugen)frm.MdiParent).buttonX7.Shortcuts.Clear();
            //    ((Menugen)frm.MdiParent).buttonX7.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);

            //    ((Menugen)frm.MdiParent).buttonX8.Shortcuts.Clear();
            //    ((Menugen)frm.MdiParent).buttonX8.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);

            //    ((Menugen)frm.MdiParent).buttonX9.Shortcuts.Clear();
            //    ((Menugen)frm.MdiParent).buttonX9.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);

            //    ((Menugen)frm.MdiParent).buttonX10.Shortcuts.Clear();
            //    ((Menugen)frm.MdiParent).buttonX10.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);

            //    ((Menugen)frm.MdiParent).buttonX11.Shortcuts.Clear();
            //    ((Menugen)frm.MdiParent).buttonX11.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);

            //    ((Menugen)frm.MdiParent).buttonX12.Shortcuts.Clear();
            //    ((Menugen)frm.MdiParent).buttonX12.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);
            //}
            //catch { }
        }
    }
}
