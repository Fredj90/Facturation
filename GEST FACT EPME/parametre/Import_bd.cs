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
    public partial class Import_bd : DevComponents.DotNetBar.Office2007Form
    {
        MySqlBackup mb;
        string constr;
        List<String> LTable = new List<string>();
      
        Timer TimerImport;
        int PercentageComplete = 0;
        public Import_bd()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (Program.ISSaDmin)
            {
                constr = Program.Str_con;
                OpenFileDialog of = new OpenFileDialog();
                of.Multiselect = false;
                if (of.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                else
                {
                    mb = new MySqlBackup(constr);
                    mb.ImportInfo.EncryptionKey = "Harrazi";
                    mb.ImportInfo.EnableEncryption = true;
                    mb.ImportInfo.FileName = of.FileName;

                    TimerImport = new Timer();
                    TimerImport.Interval = 10;
                    TimerImport.Tick += new EventHandler(TimerImport_Tick);
                    TimerImport.Start();
                    mb.ImportProgressChanged += new MySqlBackup.importProgressChange(mb_ImportProgressChanged);
                    mb.ImportInfo.SetTargetDatabase("commerce", "utf8");
                    mb.Import();
                }
            }
            else
            {
                MessageBox.Show("Accés Non Autorisé");
            }
        }
        void TimerImport_Tick(object sender, EventArgs e)
        {
            if (PercentageComplete == 100)
                this.Close();
        }

        void mb_ImportProgressChanged(object sender, ImportProgressArg e)
        {
            PercentageComplete = e.PercentageCompleted;
            label1.Text = PercentageComplete + " %";
            label1.Refresh();
            pgGetTotalRows.Value = PercentageComplete;
            
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

        private void Import_bd_Load(object sender, EventArgs e)
        {

        }
    }
}
