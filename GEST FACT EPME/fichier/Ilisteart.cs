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
    public partial class Ilisteart : DevComponents.DotNetBar.Office2007Form
    {
        public DataSet ds;
        public string xfamille = ""; 

        public Ilisteart()
        {
            InitializeComponent();
        }

        private void Ilisteart_Load(object sender, EventArgs e)
        {
            listeart listeart1 = new listeart();

            if (xfamille != "")
            {
                listeart1.DataDefinition.FormulaFields["famille"].Text = "'Famille : " + xfamille + "'";
            }

            listeart1.SetDataSource(ds);
            listeart1.Refresh();
            crystalReportViewer1.ReportSource = listeart1;
            crystalReportViewer1.Refresh();
        }
    }
}
