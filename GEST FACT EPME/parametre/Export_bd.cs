using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EPME
{
    public partial class Export_bd : DevComponents.DotNetBar.Office2007Form
    {
        MySqlBackup mb;
        string constr;
        List<String> LTable = new List<string>();
        Timer TimerExport;
       
        int PercentageGetTotalRowsCompleted = 0;
        string CurrentTableName = "";
       
        public Export_bd()
        {
            InitializeComponent();
        }

        private void Export_bd_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (Program.ISSaDmin)
            {
                constr = Program.Str_con;
                LoadTables();
                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = "commerce_" + DateTime.Now.ToString("yyyy_MM_dd_HHmmss") + ".sql";
                if (sf.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                mb = new MySqlBackup(constr);
                mb.ExportInfo.EncryptionKey = "Harrazi";
                mb.ExportInfo.EnableEncryption = true;
                mb.ExportInfo.FileName = sf.FileName;
                mb.ExportInfo.MaxSqlLength = 1024;
                mb.ExportInfo.ExportRows = true;
                mb.ExportInfo.ExportTableStructure = true;
                mb.ExportInfo.ExportViews = true;
                mb.ExportInfo.ExportTriggers = true;
                mb.ExportInfo.ExportEvents = true;
                mb.ExportInfo.ExportFunctions = true;
                mb.ExportInfo.AsynchronousMode = true;
                mb.ExportInfo.CalculateTotalRowsFromDatabase = true;
                mb.ExportInfo.AutoCloseConnection = true;
                mb.ExportInfo.RecordDumpTime = true;
                mb.ExportInfo.TableCustomSql = GetTableSql();


                TimerExport = new Timer();
                TimerExport.Interval = 10;
                TimerExport.Tick += new EventHandler(TimerExport_Tick);
                TimerExport.Start();
                mb.ExportProgressChanged += new MySqlBackup.exportProgressChange(mb_ExportProgressChanged);
                mb.Export();


                buttonX1.Visible = false;
            }
            else
            {
                MessageBox.Show("Accés Non Autorisé");
            }
        }

        void TimerExport_Tick(object sender, EventArgs e)
        {
            pgGetTotalRows.Value = PercentageGetTotalRowsCompleted;
            label1.Text = CurrentTableName;
            label1.Refresh();
            if (PercentageGetTotalRowsCompleted == 100)
                this.Close();
           
        }


        void mb_ExportProgressChanged(object sender, ExportProgressArg e)
        {
            PercentageGetTotalRowsCompleted = e.PercentageGetTotalRowsCompleted;
            CurrentTableName = e.CurrentTableName;

        }

        Dictionary<string, string> GetTableSql()
        {
            Dictionary<string, string> dicTableSql = new Dictionary<string, string>();
            foreach (String dgvr in LTable)
            {
                string tablename = dgvr;
                string sql = "";
                if (sql == "")
                {
                    sql = string.Format("SELECT * FROM `{0}`;", tablename);
                }
                dicTableSql.Add(tablename, sql);
            }
            if (dicTableSql.Count == 0)
                return null;
            return dicTableSql;
        }

        void LoadTables()
        {
            mb = new MySqlBackup(constr);
            string[] tables = mb.DatabaseInfo.TableNames;
            LTable.Clear();
            foreach (string s in tables)
            {
                LTable.Add(s);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
