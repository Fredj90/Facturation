﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EPME.Facture.rpt
{
    public partial class frm_DDIERSC : DevComponents.DotNetBar.Office2007Form
    {
        public String numf = "";
        public frm_DDIERSC()
        {
            InitializeComponent();
        }

        private void frm_fondation_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            String sql = "select* from facture where numf = '" + numf + "' and codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
            Program.met.recuperer_table(sql, ds, "facture");

            sql = "select* from ldivers where numf = '" + numf + "' and codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
            Program.met.recuperer_table(sql, ds, "ldivers");

            sql = "select* from ste where code='" + Program.Societe + "' ";
            Program.met.recuperer_table(sql, ds, "ste");

            sql = "select* from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
            Program.met.recuperer_table(sql, ds, "client");

            sql = "select* from modalite where  codes='" + Program.Societe + "'";
            Program.met.recuperer_table(sql, ds, "modalite");

            DDIVERSC editdevis1 = new DDIVERSC();
            editdevis1.DataDefinition.FormulaFields["numero"].Text = "'" + numf + "'";
            editdevis1.SetDataSource(ds);
            editdevis1.Refresh();
            crystalReportViewer1.ReportSource = editdevis1;
            crystalReportViewer1.Refresh();

        }
    }
}