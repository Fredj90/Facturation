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
    public partial class Ilistecli : DevComponents.DotNetBar.Office2007Form
    {
        public DataSet ds;
        public string xfamille = "";
        public string xregion = "";
        public string xsecteur = ""; 
        public Ilistecli()
        {
            InitializeComponent();
        }

        private void Ilistecli_Load(object sender, EventArgs e)
        {
            listecli listecli1 = new listecli();

            if (xregion != "")
            {
                listecli1.DataDefinition.FormulaFields["region"].Text = "'Région : " + xregion + "'";
            }

            if (xsecteur != "")
            {
                listecli1.DataDefinition.FormulaFields["secteur"].Text = "'Section : " + xsecteur + "'";
            }

            if (xfamille != "")
            {
                listecli1.DataDefinition.FormulaFields["famille"].Text = "'Famille : " + xfamille + "'";
            }

            listecli1.SetDataSource(ds);
            listecli1.Refresh();
            crystalReportViewer1.ReportSource = listecli1;
            crystalReportViewer1.Refresh();
        }
    }
}
