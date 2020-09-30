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
    public partial class rechartmaj : DevComponents.DotNetBar.Office2007Form
    {

        private metier met = Program.met;
        DataSet ds;

        public string table = "";
        public string code = "";
        public string libe = "";
        public string focus = "";
        public string coded = "";
        public string codeg = "";
        public string libelled = "";
        public string libelleg = "";
        public Boolean act = false;
        public int xlen;

        public Boolean valider = false;

        public rechartmaj(String table, string code, string libe)
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

       
        private void rechartmaj_Load(object sender, EventArgs e)
        {
            Tcod.Text = code;
            Tlib.Text = libe;

            Program.desTfunction(this);

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

            string req = "select s.codea ,s.codea as code,a.libelle, a.libelle as Des ,d.libelle as depot ,g.libelle as gamme ,s.qtestk ,a.puht ,a.tva, g.codeg ,d.code as coded from article a ,artdep s ,gamme g , depot d where s.codes = '" + Program.Societe + "' and s.codee = '" + Program.Exercice + "' and s.codem = '" + Program.Magasin + "'  and s.`codea` like '%" + Tcod.Text + "%' and a.codes=s.`codes` and a.codee=s.`codee` and s.`codes` = d.`codes` and s.`codee` = d.`codee` and s.`codem` = d.`codem` and s.`coded` = d.`code` and s.`codeg` = g.`codeg` and a.code=s.`codea` and s.`codea` = g.`codea` order by s.codea,g.libelle";
            DataSet ds = met.recuperer_table(req, table);

            dataGridViewX1.Columns["a0"].Visible = false;
            dataGridViewX1.Columns["a1"].Visible = false;

            if (ds != null)
            {
                textBoxX1.Text = ds.Tables[0].Rows.Count.ToString();
   
                dataGridViewX1.DataSource = ds.Tables[table].DefaultView;
               
                String lastnum = "";
                foreach (DataGridViewRow dgr in dataGridViewX1.Rows)
                {
                    string xcode = dgr.Cells["a0"].Value + "";
                    string xgamme = dgr.Cells["a3"].Value + "";

                    if (lastnum != xcode)
                    {
                        lastnum = xcode;
                    }
                    else
                    {
                        
                        dgr.Cells["a8"].Value = "";
                        dgr.Cells["a9"].Value = "";
                    }
                    if (xgamme == "Defaut")
                        dgr.Cells["a3"].Value = "";


                }
            }
        }

        private void Tcod1_TextChanged(object sender, EventArgs e)
        {

            xlen = Tcod1.TextLength;
            string xchamp = Tcod1.Text.Substring(0, xlen);

            string req = "select s.codea ,s.codea as code,a.libelle, a.libelle as Des ,d.libelle as depot ,g.libelle as gamme ,s.qtestk ,a.puht ,a.tva, g.codeg ,d.code as coded,SUBSTR(s.codea,1," + xlen.ToString() + ")  as code1 from article a ,artdep s ,gamme g , depot d where s.codes = '" + Program.Societe + "' and s.codee = '" + Program.Exercice + "' and s.codem = '" + Program.Magasin + "'  and SUBSTR(s.codea,1," + xlen.ToString() + ")= '" + Tcod1.Text + "' and a.codes=s.`codes` and a.codee=s.`codee` and s.`codes` = d.`codes` and s.`codee` = d.`codee` and s.`codem` = d.`codem` and s.`coded` = d.`code` and s.`codeg` = g.`codeg` and a.code=s.`codea` and s.`codea` = g.`codea` order by s.codea,g.libelle";
            DataSet ds = met.recuperer_table(req, table);

            dataGridViewX1.Columns["a0"].Visible = false;
            dataGridViewX1.Columns["a1"].Visible = false;

            if (ds != null)
            {
                textBoxX1.Text = ds.Tables[0].Rows.Count.ToString();

                dataGridViewX1.DataSource = ds.Tables[table].DefaultView;

                String lastnum = "";
                foreach (DataGridViewRow dgr in dataGridViewX1.Rows)
                {
                    string xcode = dgr.Cells["a0"].Value + "";
                    string xgamme = dgr.Cells["a3"].Value + "";

                    if (lastnum != xcode)
                    {
                        lastnum = xcode;
                    }
                    else
                    {
                        dgr.Cells["a8"].Value = "";
                        dgr.Cells["a9"].Value = "";
                    }
                    if (xgamme == "Defaut")
                        dgr.Cells["a3"].Value = "";


                }
            }
        }

        private void Tlib_TextChanged(object sender, EventArgs e)
        {

            string req = "select s.codea ,s.codea as code,a.libelle,a.libelle as Des ,d.libelle as depot ,g.libelle as gamme ,s.qtestk ,a.puht ,a.tva, g.codeg ,d.code as coded  from article a ,artdep s ,gamme g , depot d where s.codes = '" + Program.Societe + "' and s.codee = '" + Program.Exercice + "' and s.codem = '" + Program.Magasin + "' and a.`libelle` like '%" + Tlib.Text + "%' and a.codes=s.`codes` and a.codee=s.`codee` and s.`codes` = d.`codes` and s.`codee` = d.`codee` and s.`codem` = d.`codem` and s.`coded` = d.`code` and s.`codeg` = g.`codeg` and a.code=s.`codea` and s.`codea` = g.`codea` order by s.codea,g.libelle";
            ds = met.recuperer_table(req, table);

            dataGridViewX1.Columns["a0"].Visible = false;
            dataGridViewX1.Columns["a1"].Visible = false;
           

            if (ds != null)
            {
                textBoxX1.Text = ds.Tables[0].Rows.Count.ToString();

                dataGridViewX1.DataSource = ds.Tables[table].DefaultView;
               
                String lastnum = "";
                foreach (DataGridViewRow dgr in dataGridViewX1.Rows)
                {
                    string xcode = dgr.Cells["a0"].Value + "";
                    string xgamme = dgr.Cells["a3"].Value + "";

                    if (lastnum != xcode)
                    {
                        lastnum = xcode;
                    }
                    else
                    {
                       
                        dgr.Cells["a8"].Value = "";
                        dgr.Cells["a9"].Value = "";
                    }

                    if (xgamme == "Defaut")
                        dgr.Cells["a3"].Value = "";
                        

                }
            }
        }

        private void Tlib1_TextChanged(object sender, EventArgs e)
        {

            xlen = Tlib1.TextLength;
            string xchamp = Tlib1.Text.Substring(0, xlen);

            string req = "select s.codea ,s.codea as code,a.libelle,a.libelle as Des ,d.libelle as depot ,g.libelle as gamme ,s.qtestk ,a.puht ,a.tva, g.codeg ,d.code as coded,SUBSTR(a.libelle,1," + xlen.ToString() + ")  as code1  from article a ,artdep s ,gamme g , depot d where s.codes = '" + Program.Societe + "' and s.codee = '" + Program.Exercice + "' and s.codem = '" + Program.Magasin + "' and SUBSTR(a.libelle,1," + xlen.ToString() + ") = '" + Tlib1.Text + "' and a.codes=s.`codes` and a.codee=s.`codee` and s.`codes` = d.`codes` and s.`codee` = d.`codee` and s.`codem` = d.`codem` and s.`coded` = d.`code` and s.`codeg` = g.`codeg` and a.code=s.`codea` and s.`codea` = g.`codea` order by s.codea,g.libelle";
            ds = met.recuperer_table(req, table);

            dataGridViewX1.Columns["a0"].Visible = false;
            dataGridViewX1.Columns["a1"].Visible = false;


            if (ds != null)
            {
                textBoxX1.Text = ds.Tables[0].Rows.Count.ToString();

                dataGridViewX1.DataSource = ds.Tables[table].DefaultView;

                String lastnum = "";
                foreach (DataGridViewRow dgr in dataGridViewX1.Rows)
                {
                    string xcode = dgr.Cells["a0"].Value + "";
                    string xgamme = dgr.Cells["a3"].Value + "";

                    if (lastnum != xcode)
                    {
                        lastnum = xcode;
                    }
                    else
                    {
                       
                        dgr.Cells["a8"].Value = "";
                        dgr.Cells["a9"].Value = "";
                    }

                    if (xgamme == "Defaut")
                        dgr.Cells["a3"].Value = "";


                }
            }
        }

        private void dataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (dataGridViewX1.Rows.Count != 0)
                {
                    code = dataGridViewX1.CurrentRow.Cells["a0"].Value + "";
                    libe = dataGridViewX1.CurrentRow.Cells["a1"].Value + "";
                    coded = dataGridViewX1.CurrentRow.Cells["codeg1"].Value + "";
                    codeg = dataGridViewX1.CurrentRow.Cells["coded1"].Value + "";
                    libelled = dataGridViewX1.CurrentRow.Cells["a2"].Value + "";
                    libelleg = dataGridViewX1.CurrentRow.Cells["a3"].Value + "";
                    valider = true;
                    this.Close();
                }

            }
        }

        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {

            if (dataGridViewX1.Rows.Count != 0)
            {
                code = dataGridViewX1.CurrentRow.Cells["a0"].Value + "";
                libe = dataGridViewX1.CurrentRow.Cells["a1"].Value + "";
                coded = dataGridViewX1.CurrentRow.Cells["codeg1"].Value + "";
                codeg = dataGridViewX1.CurrentRow.Cells["coded1"].Value + "";
                libelled = dataGridViewX1.CurrentRow.Cells["a2"].Value + "";
                libelleg = dataGridViewX1.CurrentRow.Cells["a3"].Value + "";
                valider = true;
                this.Close();
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



        private void dataGridViewX1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (!act)
            {
                String lastnum = "", lastg = "", lastd = "";
                Boolean color = true, colorg = true, colord = true;
                foreach (DataGridViewRow dgr in dataGridViewX1.Rows)
                {

                    string xcode = dgr.Cells["a0"].Value + "";
                    string xgamme = dgr.Cells["a3"].Value + "";
                    string xdep = dgr.Cells["a2"].Value + "";


                    if (lastnum != xcode)
                    {
                        color = !color;
                        lastnum = xcode;
                    }

                    if (lastg != xgamme)
                    {
                        colorg = !colorg;
                        lastg = xgamme;
                    }

                    if (lastd != xdep)
                    {
                        colord = !colord;
                        lastd = xdep;
                    }

                    if (color)
                    {

                        dgr.Cells["a8"].Style.ForeColor = Color.Yellow;
                        dgr.Cells["a8"].Style.BackColor = Color.Blue;
                        dgr.Cells["a9"].Style.ForeColor = Color.Yellow;
                        dgr.Cells["a9"].Style.BackColor = Color.Blue;
                        dgr.Cells["a5"].Style.ForeColor = Color.Yellow;
                        dgr.Cells["a5"].Style.BackColor = Color.Blue;
                        dgr.Cells["a6"].Style.ForeColor = Color.Yellow;
                        dgr.Cells["a6"].Style.BackColor = Color.Blue;

                        dgr.Cells["a2"].Style.BackColor = Color.Blue;
                        dgr.Cells["a3"].Style.BackColor = Color.Blue;
                        dgr.Cells["a4"].Style.BackColor = Color.Blue;


                    }
                    else
                    {
                        dgr.Cells["a8"].Style.ForeColor = Color.Lime;
                        dgr.Cells["a8"].Style.BackColor = Color.MidnightBlue;
                        dgr.Cells["a9"].Style.ForeColor = Color.Lime;
                        dgr.Cells["a9"].Style.BackColor = Color.MidnightBlue;
                        dgr.Cells["a5"].Style.ForeColor = Color.Lime;
                        dgr.Cells["a5"].Style.BackColor = Color.MidnightBlue;
                        dgr.Cells["a6"].Style.ForeColor = Color.Lime;
                        dgr.Cells["a6"].Style.BackColor = Color.MidnightBlue;

                        dgr.Cells["a2"].Style.BackColor = Color.MidnightBlue;
                        dgr.Cells["a3"].Style.BackColor = Color.MidnightBlue;
                        dgr.Cells["a4"].Style.BackColor = Color.MidnightBlue;
                    }

                    if (colorg)
                    {
                        dgr.Cells["a3"].Style.ForeColor = Color.Magenta;
                        dgr.Cells["a4"].Style.ForeColor = Color.Magenta;

                    }
                    else
                    {


                        dgr.Cells["a3"].Style.ForeColor = Color.Yellow;
                        dgr.Cells["a4"].Style.ForeColor = Color.Yellow;
                    }

                    if (!colord)
                    {

                        dgr.Cells["a2"].Style.ForeColor = Color.Lime;

                    }
                    else
                    {

                        dgr.Cells["a2"].Style.ForeColor = Color.Cyan;
                    }

                }
            }
        }

        private void dataGridViewX1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


    }
}
