using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EPME.fichier
{
    public partial class Ilisteartcli : DevComponents.DotNetBar.Office2007Form
    {
        public DataSet ds;
        public string xfamille = ""; 

        public Ilisteartcli()
        {
            InitializeComponent();
        }

        private void Ilisteartcli_Load(object sender, EventArgs e)
        {
            listeartcli listeartcli1 = new listeartcli();

            if (xfamille != "")
            {
                listeartcli1.DataDefinition.FormulaFields["famille"].Text = "'Famille : " + xfamille + "'";
            }

            listeartcli1.SetDataSource(ds);
            listeartcli1.Refresh();
            crystalReportViewer1.ReportSource = listeartcli1;
            crystalReportViewer1.Refresh();
        }
    }
}
