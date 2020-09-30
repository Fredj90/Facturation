using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EPME
{
    public partial class rechcli : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        DataSet ds;
        public Double mntacompte = 0;
        public Double SoldeN1 = 0;
        public Double RegSoldeN1 = 0;
        public string table = "";
        public string code = "";
        public string libe= "";
        public string adre = "";
        public string focus = "";
        public Boolean valider = false;
        public int xlen ;
        public rechcli(String table, string code, string libe)
        {
            if (code != null)
            {
                this.code = code;
                this.focus = "1";
            }
            if (libe != null)
            {
                this.libe = libe;
                this.focus = "2";
            }
            this.table = table;
            InitializeComponent();
        }

        private void rechcli_Load(object sender, EventArgs e)
        {
            Program.desTfunction(this);

            Tcod.Text = code;
            Tlib.Text = libe;

            if (focus == "2")
            {
                Tlib.TabIndex = 0;
                Tcod.TabIndex = 1;
                Tlib.Select(Tlib.Text.Length, 0);
            }
            else if (focus == "1")
            {
                Tcod.TabIndex = 0;
                Tlib.TabIndex = 1;
                Tcod.Select(Tcod.Text.Length, 0);
            }
        }

        private void Tcod_TextChanged(object sender, EventArgs e)
        {


            string req = "SELECT code,libelle,adrf,acompte, solde1,regsoldn1 FROM " + table + " where codes='" + Program.Societe + "' and  codee='" + Program.Exercice + "' and code like '%" + Tcod.Text + "%' order by code";
            ds = met.recuperer_table(req, table);
            if (ds != null)
            {
                dataGridViewX1.DataSource = ds.Tables[table].DefaultView;
                              
            }
        }

        private void Tcod1_TextChanged(object sender, EventArgs e)
        {
           
            xlen = tcod1.TextLength;
            string xchamp = tcod1.Text.Substring(0, xlen);

            string req = "SELECT code,libelle,adrf,SUBSTR(code,1," + xlen.ToString() + ") as code1,acompte, solde1,regsoldn1  FROM " + table + " where codes='" + Program.Societe + "' and  codee='" + Program.Exercice + "' and SUBSTR(code,1," + xlen.ToString() + ") = '" + tcod1.Text + "' order by code";
            ds = met.recuperer_table(req, table);
            if (ds != null)
            {
                dataGridViewX1.DataSource = ds.Tables[table].DefaultView;

            }
        }

        private void Tlib1_TextChanged(object sender, EventArgs e)
        {
           
            xlen = tlib1.TextLength;
            string xchamp = tlib1.Text.Substring(0, xlen);

            string req = "SELECT code,libelle,adrf,SUBSTR(libelle,1," + xlen.ToString() + ")  as code1,acompte, solde1,regsoldn1   FROM " + table + " where codes='" + Program.Societe + "' and  codee='" + Program.Exercice + "' and SUBSTR(libelle,1," + xlen.ToString() + ") = '" + tlib1.Text + "' order by code";
            ds = met.recuperer_table(req, table);
            if (ds != null)
            {
                dataGridViewX1.DataSource = ds.Tables[table].DefaultView;

            }
            
        }

        private void Tlib_TextChanged(object sender, EventArgs e)
        {

            string req = "SELECT code,libelle,adrf,acompte, solde1,regsoldn1 FROM " + table + " where codes='" + Program.Societe + "' and  codee='" + Program.Exercice + "' and libelle like '%" + Tlib.Text + "%' order by code";
            ds = met.recuperer_table(req, table);
            if (ds != null)
            {
                dataGridViewX1.DataSource = ds.Tables[table].DefaultView;

            }
        }

        private void dataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (dataGridViewX1.Rows.Count != 0)
                {
                    code = dataGridViewX1.CurrentRow.Cells["c0"].Value + "";
                    libe = dataGridViewX1.CurrentRow.Cells["c1"].Value + "";
                    adre = dataGridViewX1.CurrentRow.Cells["c2"].Value + "";
                    Double.TryParse(dataGridViewX1.CurrentRow.Cells["c5"].Value + "", out mntacompte);
                    Double.TryParse(dataGridViewX1.CurrentRow.Cells["c6"].Value + "", out SoldeN1);
                    Double.TryParse(dataGridViewX1.CurrentRow.Cells["c7"].Value + "", out RegSoldeN1);
                    valider = true;
                    this.Close();
                }
                
            }
        }

        private void Tcod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                dataGridViewX1.Focus();
            }
        }

        private void Tlib_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                dataGridViewX1.Focus();
            }
        }

        private void dataGridViewX1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count != 0)
            {
                code = dataGridViewX1.CurrentRow.Cells["c0"].Value + "";
                libe = dataGridViewX1.CurrentRow.Cells["c1"].Value + "";
                adre = dataGridViewX1.CurrentRow.Cells["c2"].Value + "";
                Double.TryParse(dataGridViewX1.CurrentRow.Cells["c5"].Value + "", out mntacompte);
                Double.TryParse(dataGridViewX1.CurrentRow.Cells["c6"].Value + "", out SoldeN1);
                Double.TryParse(dataGridViewX1.CurrentRow.Cells["c7"].Value + "", out RegSoldeN1);
                valider = true;
                this.Close();
            }
        }

        private void dataGridViewX1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            String lastnum = "";
            Boolean color = true;
            foreach (DataGridViewRow dgr in dataGridViewX1.Rows)
            {

                string xcode = dgr.Cells["c0"].Value + "";



                if (lastnum != xcode)
                {
                    color = !color;
                    lastnum = xcode;
                }


                if (color)
                {

                    dgr.Cells["c0"].Style.ForeColor = Color.Yellow;
                    dgr.Cells["c0"].Style.BackColor = Color.Blue;
                    dgr.Cells["c1"].Style.ForeColor = Color.Yellow;
                    dgr.Cells["c1"].Style.BackColor = Color.Blue;
                    dgr.Cells["c2"].Style.ForeColor = Color.Yellow;
                    dgr.Cells["c2"].Style.BackColor = Color.Blue;


                }
                else
                {
                    dgr.Cells["c0"].Style.ForeColor = Color.Lime;
                    dgr.Cells["c0"].Style.BackColor = Color.MidnightBlue;
                    dgr.Cells["c1"].Style.ForeColor = Color.Lime;
                    dgr.Cells["c1"].Style.BackColor = Color.MidnightBlue;
                    dgr.Cells["c2"].Style.ForeColor = Color.Lime;
                    dgr.Cells["c2"].Style.BackColor = Color.MidnightBlue;



                }
            }
        }

        

        
    }
}
