using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Rendering;

namespace commerciale
{
    public partial class devcli1 : System.Windows.Forms.Form
    {
       
        private metier met = Program.met;
        DataSet ds;
       
        Boolean first = true;
        public devcli1()
        {
            InitializeComponent();
        }

       

        private void devcli1_Load(object sender, EventArgs e)
        {

            Program.desTfunction(this);

            buttonX1_Click(sender, e);
            if (Program.ISDemo)
            {
                if (dataGridViewX1.Rows.Count > 30)
                {
                    buttonX5.Enabled = false;
                }
            }
            first = false;
        }


        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            charger_lignefacture();
        }


        private void dataGridViewX1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            charger_lignefacture();
        }

        private void charger_lignefacture()
        {
            if (first)
                dataGridViewX1.Rows[dataGridViewX1.Rows.Count - 1].Selected = true;
            if (dataGridViewX1.SelectedRows.Count != 0)
            {
                // devis
                if (!(Boolean)dataGridViewX1.SelectedRows[0].Cells["facture"].Value)
                {
                    buttonX2.Enabled = true;
                }
                else
                { buttonX2.Enabled = false; }

                // Chargement ligne devis
                string req1 = "select distinct  l.num,l.codea, a.libelle , g.libelle as gamme , d.libelle as depot , l.qte , l.pu , l.tva , l.taxe, l.tvaf , l.rem , l.netht , l.netttc,l.codesa,l.ID   from lentd l , article a , gamme g , depot d where l.codes='" + Program.Societe + "' and l.codee='" + Program.Exercice + "' and l.num= '" + dataGridViewX1.SelectedRows[0].Cells["num"].Value + "' and  l.codem='" + Program.Magasin + "' and l.codea = a.code and l.codes= a.codes and l.codee= a.codee and l.codea = g.codea and l.codeg=g.codeg  and l.codes=g.codes and l.codee=g.codee and l.coded= d.code and l.codes=d.codes and l.codee=d.codee and l.codem=d.codem ";
                DataSet ds1 = met.recuperer_table(req1, "lentd");

                foreach (DataRow dr in ds1.Tables["lentd"].Rows)
                {

                    if (dr["codesa"] != DBNull.Value)
                    {
                        string sql = "select libelle from sarticle where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codea= '" + dr["codea"] + "' and code = '" + dr["codesa"] + "'";
                        DataSet dtmp = met.recuperer_table(sql, "sarticle");
                        dr["libelle"] = dtmp.Tables[0].Rows[0][0];
                        dr["codea"] = DBNull.Value;
                        dr["gamme"] = DBNull.Value;
                        dr["depot"] = DBNull.Value;
                    }

                }
                dataGridViewX2.DataSource = ds1.Tables["lentd"].DefaultView;

            }
        }


        private void buttonX3_Click(object sender, EventArgs e)
        {
            // Bouton Supprimer Livraison
            if (dataGridViewX1.Rows.Count != 0)
            {
                string sql = "select * from eentd where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and num = '" + dataGridViewX1.SelectedRows[0].Cells[0].Value + "' and facture = false";
                DataSet dss = met.recuperer_table(sql, "eentd");
                if (dss.Tables["eentd"].Rows.Count != 0)
                {

                    String msg = MessageBox.Show("Ete-vous sur", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                    if (msg.Equals("Yes"))
                    {

                        String req = "DELETE FROM eentd Where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "'  and num = '" + dataGridViewX1.SelectedRows[0].Cells[0].Value + "'";

                        if (met.Execute(req))
                        {
                            String req1 = "DELETE FROM lentd Where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "'  and num = '" + dataGridViewX1.SelectedRows[0].Cells[0].Value + "'";
                            if (met.Execute(req1))
                                MessageBox.Show("Suppression effectuée");
                        }
                        buttonX1_Click(sender, e);
                    }
                }
                else
                    MessageBox.Show("Devis déja Facturée", "Impossible");
            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            // Bouton créer Facture
            //factcli form = new factcli();
            //form.ShowDialog();

        }

        private void buttonX4_Click(object sender, EventArgs e)
        {

            // Bouton Recherche
            if (dataGridViewX1.Rows.Count != 0)
            {
                Rechfact form = new Rechfact();
                form.table = "Client";
                form.ShowDialog();
                if (!form.textBoxX3.Text.Equals(""))
                {
                    DataRow[] dr = ds.Tables["eentd"].Select("num = '" + form.textBoxX3.Text + "'");
                    if (dr.Length != 0)
                    {
                        int i = ds.Tables[0].Rows.IndexOf(dr[0]);
                        dataGridViewX1.Rows[i].Selected = true;
                    }
                    else
                    {
                        MessageBox.Show("N° Livraison n'existe pas.");
                    }
                }
                else if (!form.code.Equals("0") && !form.dateTimeInput1.Text.Equals("") && !form.dateTimeInput2.Text.Equals(""))
                {

                    string ddebut = form.dateTimeInput1.Value.ToString("yyyy-MM-dd");
                    string dfin = form.dateTimeInput2.Value.ToString("yyyy-MM-dd");
                    string req2 = "select num,date,codec,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc,facture from eentd where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and (codec='" + form.code + "' AND date>='" + ddebut + "' AND date<='" + dfin + "') order by num";
                    ds = met.recuperer_table(req2, "eentd");
                    dataGridViewX1.DataSource = ds.Tables["eentd"].DefaultView;
                    if (dataGridViewX1.Rows.Count != 0)
                    {
                        charger_lignefacture();
                        total();
                    }
                    buttonX1.Visible = true;
                }
                else if (!form.code.Equals("0") && !form.dateTimeInput1.Text.Equals(""))
                {

                    string ddebut = form.dateTimeInput1.Value.ToString("yyyy-MM-dd");
                    string dfin = form.dateTimeInput2.Value.ToString("yyyy-MM-dd");
                    string req2 = "select num,date,codec,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc,facture from eentd where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and (codec='" + form.code + "' AND date>=#" + ddebut + "# ) order by num";
                    ds = met.recuperer_table(req2, "eentd");
                    dataGridViewX1.DataSource = ds.Tables["eentd"].DefaultView;
                    if (dataGridViewX1.Rows.Count != 0)
                    {
                        charger_lignefacture();
                        total();
                    }
                    buttonX1.Visible = true;
                }
                else if (!form.code.Equals("0"))
                {

                    string ddebut = form.dateTimeInput1.Value.ToString("yyyy-MM-dd");
                    string dfin = form.dateTimeInput2.Value.ToString("yyyy-MM-dd");
                    string req2 = "select num,date,codec,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc,facture from eentd where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and (codec='" + form.code + "') order by num";
                    ds = met.recuperer_table(req2, "eentd");
                    dataGridViewX1.DataSource = ds.Tables["eentd"].DefaultView;
                    if (dataGridViewX1.Rows.Count != 0)
                    {
                        charger_lignefacture();
                        total();
                    }
                    buttonX1.Visible = true;
                }
                else if (form.code.Equals("0") && !form.dateTimeInput1.Text.Equals("") && !form.dateTimeInput2.Text.Equals(""))
                {

                    string ddebut = form.dateTimeInput1.Value.ToString("yyyy-MM-dd");
                    string dfin = form.dateTimeInput2.Value.ToString("yyyy-MM-dd");
                    string req2 = "select num,date,codec,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc,facture from eentd where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and (date>='" + ddebut + "' AND date<='" + dfin + "') order by num";
                    ds = met.recuperer_table(req2, "eentd");
                    dataGridViewX1.DataSource = ds.Tables["eentd"].DefaultView;
                    if (dataGridViewX1.Rows.Count != 0)
                    {
                        charger_lignefacture();
                        total();
                    }
                    buttonX1.Visible = true;
                }
                else if (form.code.Equals("0") && !form.dateTimeInput1.Text.Equals(""))
                {

                    string ddebut = form.dateTimeInput1.Value.ToString("yyyy-MM-dd");
                    string dfin = form.dateTimeInput2.Value.ToString("yyyy-MM-dd");
                    string req2 = "select num,date,codec,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc,facture from eentd where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and (date>=#" + ddebut + "# ) order by num";
                    ds = met.recuperer_table(req2, "eentd");
                    dataGridViewX1.DataSource = ds.Tables["eentd"].DefaultView;
                    if (dataGridViewX1.Rows.Count != 0)
                    {
                        charger_lignefacture();
                        total();
                    }
                    buttonX1.Visible = true;
                }
                else
                    buttonX1_Click(sender, e);
            }

        }

        private void devcli1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.F1:
                    {
                        buttonX4_Click(sender, e);
                    }
                    break;

                case Keys.F3:
                    {
                        superTabControl1.SelectedTab = tab1;
                    }
                    break;

                case Keys.F4:
                    {
                        superTabControl1.SelectedTab = tab2;
                    }
                    break;

                default:
                    // actions_sinon;
                    break;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            buttonX1.Visible = false;
            
            libellec.DisplayMember = "libelle";
            libellec.ValueMember = "code";

            string sql1 = "select * from client where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
            DataSet dsc = met.recuperer_table(sql1, "client");
            BindingSource bsc = new BindingSource(dsc, "client");
            libellec.DataSource = bsc;
            libellec.DataPropertyName = "codec";


            string req = "select num,date,codec,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc,facture from eentd where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "'  order by num";
            ds = met.recuperer_table(req, "eentd");
            dataGridViewX1.DataSource = ds.Tables["eentd"].DefaultView;
            if (dataGridViewX1.Rows.Count != 0)
            {
                if (first)
                {
                    dataGridViewX1.CurrentCell = dataGridViewX1.Rows[dataGridViewX1.Rows.Count - 1].Cells[0];
                }
                dataGridViewX1.Rows[0].Selected = false;
                dataGridViewX1.FirstDisplayedScrollingRowIndex = dataGridViewX1.Rows.Count - 1;
                dataGridViewX1.Rows[dataGridViewX1.Rows.Count - 1].Selected = true;
                charger_lignefacture();
                total();
            }
        }

        private void dataGridViewX1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            charger_lignefacture();
        }

        private void dataGridViewX1_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            charger_lignefacture();
        }

        private void total()
        {
            Decimal xth = 0, xtrem = 0, xtva = 0, xttc = 0,xfodec=0,xttaxe=0;
            foreach (DataRow dr in ds.Tables["eentd"].Rows)
            {
                try
                {
                    xth += dr.Field<Decimal>("totalht");
                }
                catch { }

                try
                {
                    xfodec += dr.Field<Decimal>("fodec");
                }
                catch { }

                try
                {
                    xtrem += dr.Field<Decimal>("totalrem");
                }
                catch { }

                try
                {
                    xtva += dr.Field<Decimal>("totaltva");
                }
                catch { }

                try
                {
                    xttaxe += dr.Field<Decimal>("totaltaxe");
                }
                catch { }

                try
                {
                    xttc += dr.Field<Decimal>("totalttc");
                }
                catch { }

                textBoxX1.Text = xth.ToString("N3");
                textBoxX2.Text = xtrem.ToString("N3");
                textBoxX3.Text = xtva.ToString("N3");
                textBoxX4.Text = xttc.ToString("N3");
                textBoxX5.Text = xfodec.ToString("N3");
                textBoxX6.Text = xttaxe.ToString("N3");

            }
        }

        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {
            superTabControl1.SelectedTab = tab2;
        }

        private void dataGridViewX2_DoubleClick(object sender, EventArgs e)
        {
            superTabControl1.SelectedTab = tab1;
        }

        private void devcli1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

        private void dataGridViewX1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridViewX2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            ModelVente form = new ModelVente();

            form.MVent = new MetierDevisClient();
            form.ControlStock = false;
            SizeF s = new SizeF(form.groupBox1.Size.Width + form.groupBox4.Size.Width + form.groupBox2.Size.Width, form.groupBox1.Size.Height);
            form.groupBox1.Size = s.ToSize();
            form.groupBox4.Visible = false;
            form.groupBox2.Visible = false;
            form.Tcom.Visible = false;
            form.ControlStock = false;
            form.LCOM.Visible = false;
            form.Lnum.Text = "N° Devis";
            this.Visible = false;
            form.ShowDialog();
            this.Visible = true;
            buttonX1_Click(sender, e);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count != 0)
            {
                ModelVente form = new ModelVente();
                form.MVent = new MetierDevisClient();
                SizeF s = new SizeF(form.groupBox1.Size.Width + form.groupBox4.Size.Width + form.groupBox2.Size.Width, form.groupBox1.Size.Height);
                form.groupBox1.Size = s.ToSize();
                form.groupBox4.Visible = false;
                form.groupBox2.Visible = false;
                form.Tcom.Visible = false;
                form.LCOM.Visible = false;
                form.Lnum.Text = "N° Devis";
                form.ControlStock = false;
                form.NumFact = dataGridViewX1.CurrentRow.Cells["NuM"].Value + "";
                form.ISMODIF = true;
                this.Visible = false;
                int ind = dataGridViewX1.CurrentRow.Index;
                form.ShowDialog();
                buttonX1_Click(sender, e);
                this.Visible = true;
                dataGridViewX1.CurrentCell = dataGridViewX1[1, ind];
            }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count != 0)
            {
                String Nmvt = dataGridViewX1.SelectedRows[0].Cells["NuM"].Value + "";
                String ent = "eentd";
                String lent = "lentd";
                String numero = "Devis";
                String typedition = "D";
                impression form = new impression(ent, lent, Nmvt, numero, typedition);
                form.ShowDialog();
            }
        }

    }
}
