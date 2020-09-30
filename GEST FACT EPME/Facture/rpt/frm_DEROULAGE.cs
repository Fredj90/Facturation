using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EPME.Facture.rpt
{
    public partial class frm_DEROULAGE : DevComponents.DotNetBar.Office2007Form
    {
        public String numf = "";
        public frm_DEROULAGE()
        {
            InitializeComponent();
        }

        private void frm_fondation_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            String sql = "select* from facture where numf = '" + numf + "' and codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
            Program.met.recuperer_table(sql, ds, "facture");

            sql = "select* from lDEROULAGE where numf = '" + numf + "' and codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
            Program.met.recuperer_table(sql, ds, "lDEROULAGE");

            sql = "select* from ste where code='" + Program.Societe + "' ";
            Program.met.recuperer_table(sql, ds, "ste");

            sql = "select* from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
            Program.met.recuperer_table(sql, ds, "client");

            sql = "select* from modalite where  codes='" + Program.Societe + "'";
            Program.met.recuperer_table(sql, ds, "modalite");

            DEROULAGE100 editdevis1 = new DEROULAGE100();
            editdevis1.DataDefinition.FormulaFields["numero"].Text = "'" + numf + "'";
            editdevis1.SetDataSource(ds);
            editdevis1.Refresh();
            crystalReportViewer1.ReportSource = editdevis1;
            crystalReportViewer1.Refresh();

        }
    }
}
