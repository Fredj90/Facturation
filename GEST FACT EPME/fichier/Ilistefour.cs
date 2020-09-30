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
    public partial class Ilistefour : DevComponents.DotNetBar.Office2007Form
    {
        public DataSet ds;
        public string xfamille = ""; 

        public Ilistefour()
        {
            InitializeComponent();
        }

        private void Ilistefour_Load(object sender, EventArgs e)
        {
            listefour listefour1 = new listefour();

            if (xfamille != "")
            {
                listefour1.DataDefinition.FormulaFields["famille"].Text = "'Famille : " + xfamille + "'";
            }

            listefour1.SetDataSource(ds);
            listefour1.Refresh();
            crystalReportViewer1.ReportSource = listefour1;
            crystalReportViewer1.Refresh();
        }
    }
}
