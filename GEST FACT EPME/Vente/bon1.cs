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
    public partial class bon1 : System.Windows.Forms.Form
    {

        private metier met = Program.met;
        DataSet ds;

        Boolean first = true, xvstk = false;
        decimal xdeb;
        public bon1()
        {
            InitializeComponent();
        }




        private void bon1_Load(object sender, EventArgs e)
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
                // Bon Comptoir Facturé ou Non
                if (!(Boolean)dataGridViewX1.SelectedRows[0].Cells["facture"].Value)
                {
                    buttonX2.Enabled = true;
                    buttonX3.Enabled = true; 
                }
                else
                {
                    buttonX2.Enabled = false;
                    buttonX3.Enabled = false; 
                }

                // Chargement ligne Bon Comptoir
                string req1 = "select distinct  l.num,l.codea, a.libelle , g.libelle as gamme , d.libelle as depot , l.qte , l.pu , l.tva ,l.taxe, l.tvaf , l.rem , l.netht , l.netttc,l.codesa,l.ID   from lentcb l , article a , gamme g , depot d where l.codes='" + Program.Societe + "' and l.codee='" + Program.Exercice + "' and l.num= '" + dataGridViewX1.SelectedRows[0].Cells["num"].Value + "' and  l.codem='" + Program.Magasin + "' and l.codea = a.code and l.codes= a.codes and l.codee= a.codee and l.codea = g.codea and l.codeg=g.codeg  and l.codes=g.codes and l.codee=g.codee and l.coded= d.code and l.codes=d.codes and l.codee=d.codee and l.codem=d.codem ";
                DataSet ds1 = met.recuperer_table(req1, "lentcb");

                foreach (DataRow dr in ds1.Tables["lentcb"].Rows)
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
                dataGridViewX2.DataSource = ds1.Tables["lentcb"].DefaultView;

            }
        }


        private void buttonX3_Click(object sender, EventArgs e)
        {
            // Bouton Supprimer Bon Comptoir
            if (dataGridViewX1.Rows.Count != 0)
            {
                string sql = "select * from eentcb where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and num = '" + dataGridViewX1.SelectedRows[0].Cells["NuM"].Value + "' and facture = false";
                DataSet dss = met.recuperer_table(sql, "eentcb");
                if (dss.Tables["eentcb"].Rows.Count != 0)
                {

                    String msg = MessageBox.Show("Ete-vous sur", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                    if (msg.Equals("Yes"))
                    {

                        string req1 = "Select * from lentcb where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem='" + Program.Magasin + "'  and  num = '" + dataGridViewX1.SelectedRows[0].Cells["NuM"].Value + "' ";
                        DataSet tmp1 = met.recuperer_table(req1, "lentcb");
                        foreach (DataRow dr1 in tmp1.Tables["lentcb"].Rows)
                        {
                            double xqte = 0, QTESTK = 0, QTESOR = 0, QTEMAG = 0, QTESORMAG = 0, QTESTE = 0, QTESORSTE = 0;
                            string xcodea = "";
                            xcodea = dr1.Field<string>("codea" + "");
                            string xcodeg = dr1.Field<string>("codeg" + "");
                            string xcoded = dr1.Field<string>("coded" + "");
                            try
                            {
                                xqte = dr1.Field<double>("qte");
                            }
                            catch { }

                            #region // Update stock
                            string sql1 = "Select qtestk,qtesor from artdep where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea ='" + xcodea + "' and coded='" + xcoded + "' and codem='" + Program.Magasin + "' and codeg='" + xcodeg + "'";
                            DataSet ds1 = met.recuperer_table(sql1, "artdep");
                            if (ds1 != null)
                                if (ds1.Tables.Count != 0)
                                    if (ds1.Tables["artdep"].Rows.Count != 0)
                                    {
                                        Double.TryParse(ds1.Tables["artdep"].Rows[0]["qtestk"] + "", out QTESTK);
                                        Double.TryParse(ds1.Tables["artdep"].Rows[0]["qtesor"] + "", out QTESOR);
                                    }

                            string sql2 = "Select qtestk,qtesor from artmag where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea ='" + xcodea + "'  and codem='" + Program.Magasin + "'";
                            DataSet ds2 = met.recuperer_table(sql2, "artmag");
                            if (ds2 != null)
                                if (ds2.Tables.Count != 0)
                                    if (ds2.Tables["artmag"].Rows.Count != 0)
                                    {
                                        Double.TryParse(ds2.Tables["artmag"].Rows[0]["qtestk"] + "", out QTEMAG);
                                        Double.TryParse(ds2.Tables["artmag"].Rows[0]["qtesor"] + "", out QTESORMAG);
                                    }

                            string sql3 = "Select qtestk,qtesor,vstk from article where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code ='" + xcodea + "' ";
                            DataSet ds3 = met.recuperer_table(sql3, "article");
                            if (ds3 != null)
                                if (ds3.Tables.Count != 0)
                                    if (ds3.Tables["article"].Rows.Count != 0)
                                    {
                                        xvstk = ds3.Tables["article"].Rows[0].Field<Boolean>("vstk");
                                        Double.TryParse(ds3.Tables["article"].Rows[0]["qtestk"] + "", out QTESTE);
                                        Double.TryParse(ds3.Tables["article"].Rows[0]["qtesor"] + "", out QTESORSTE);
                                    }



                            if (xvstk == true)
                            {
                                string sqlup = "UPDATE artdep set qtestk = '" + (QTESTK + xqte) + "',qtesor='" + (QTESOR - xqte) + "' where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea ='" + xcodea + "' and coded='" + xcoded + "' and codem='" + Program.Magasin + "' and codeg='" + xcodeg + "'";
                                met.Execute(sqlup);

                                sqlup = "UPDATE artmag set qtestk = '" + (QTEMAG + xqte) + "',qtesor='" + (QTESORMAG - xqte) + "' where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea ='" + xcodea + "'  and codem='" + Program.Magasin + "'";
                                met.Execute(sqlup);

                                sqlup = "UPDATE article set qtestk = '" + (QTESTE + xqte) + "',qtesor='" + (QTESORSTE - xqte) + "' where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code ='" + xcodea + "' ";
                                met.Execute(sqlup);

                            }
                            #endregion // Update stock
                        }


                        String req5 = "Select code,debit,solde From client where codes = '" + Program.Societe + "' AND codee ='" + Program.Exercice + "'  AND Code = '" + dataGridViewX1.SelectedRows[0].Cells["CODEC"].Value + "'";
                        DataSet dsc = met.recuperer_table(req5, "client");
                        decimal wdeb = 0, wsld = 0;
                        try
                        {
                            wdeb = dsc.Tables["client"].Rows[0].Field<decimal>("debit");

                        }
                        catch { }
                        try
                        {
                            wsld = dsc.Tables["client"].Rows[0].Field<decimal>("solde");
                        }
                        catch { }
                        try
                        {
                            decimal.TryParse(dataGridViewX1.SelectedRows[0].Cells[7].Value + "", out xdeb);
                        }
                        catch { }

                        String upcli = "UPDATE client SET debit = " + (wdeb - xdeb)
                                     + ", solde=" + (wsld - xdeb)
                                      + " where codes = '" + Program.Societe + "' AND codee ='" + Program.Exercice + "'  AND Code = '" + dataGridViewX1.SelectedRows[0].Cells["CODEC"].Value + "'";
                        met.Execute(upcli);





                        String req3 = "DELETE FROM eentcb Where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and num = '" + dataGridViewX1.SelectedRows[0].Cells["NuM"].Value + "'";

                        if (met.Execute(req3))
                        {
                            String req4 = "DELETE FROM lentcb Where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and num = '" + dataGridViewX1.SelectedRows[0].Cells["NuM"].Value + "'";
                            if (met.Execute(req4))
                                MessageBox.Show("Suppression effectuée");
                        }
                        buttonX1_Click(sender, e);
                    }
                }
                else
                    MessageBox.Show("Bon Comptoir déja Facturée", "Impossible");
            }
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
                    DataRow[] dr = ds.Tables["eentcb"].Select("num = '" + form.textBoxX3.Text + "'");
                    if (dr.Length != 0)
                    {
                        int i = ds.Tables[0].Rows.IndexOf(dr[0]);
                        dataGridViewX1.Rows[i].Selected = true;
                    }
                    else
                    {
                        MessageBox.Show("N° Bon Comptoir n'existe pas.");
                    }
                }
                else if (!form.code.Equals("0") && !form.dateTimeInput1.Text.Equals("") && !form.dateTimeInput2.Text.Equals(""))
                {


                    string ddebut = form.dateTimeInput1.Value.ToString("yyyy-MM-dd");
                    string dfin = form.dateTimeInput2.Value.ToString("yyyy-MM-dd");
                    string req2 = "select num,date,codec,nomc,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc,facture from eentcb where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and (codec='" + form.code + "' AND date>='" + ddebut + "' AND date<='" + dfin + "') order by num";
                    ds = met.recuperer_table(req2, "eentcb");
                    dataGridViewX1.DataSource = ds.Tables["eentcb"].DefaultView;
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
                    string req2 = "select num,date,codec,nomc,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc,facture from eentcb where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and (codec='" + form.code + "' AND date>=#" + ddebut + "# ) order by num";
                    ds = met.recuperer_table(req2, "eentcb");
                    dataGridViewX1.DataSource = ds.Tables["eentcb"].DefaultView;
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
                    string req2 = "select num,date,codec,nomc,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc,facture from eentcb where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and (codec='" + form.code + "') order by num";
                    ds = met.recuperer_table(req2, "eentcb");
                    dataGridViewX1.DataSource = ds.Tables["eentcb"].DefaultView;
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
                    string req2 = "select num,date,codec,nomc,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc,facture from eentcb where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and (date>='" + ddebut + "' AND date<='" + dfin + "') order by num";
                    ds = met.recuperer_table(req2, "eentcb");
                    dataGridViewX1.DataSource = ds.Tables["eentcb"].DefaultView;
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
                    string req2 = "select num,date,codec,nomc,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc,facture from eentcb where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and (date>=#" + ddebut + "# ) order by num";
                    ds = met.recuperer_table(req2, "eentcb");
                    dataGridViewX1.DataSource = ds.Tables["eentcb"].DefaultView;
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

        private void bon1_KeyDown(object sender, KeyEventArgs e)
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



            string req = "select num,date,codec,nomc,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc,facture from eentcb where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' order by num";
            ds = met.recuperer_table(req, "eentcb");
            dataGridViewX1.DataSource = ds.Tables["eentcb"].DefaultView;
            if (dataGridViewX1.Rows.Count != 0)
            {
                if (first)
                {

                    dataGridViewX1.CurrentCell = dataGridViewX1.Rows[dataGridViewX1.Rows.Count - 1].Cells[1];

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
            Decimal xth = 0, xtrem = 0, xtva = 0, xttc = 0, xfodec = 0, xtfact = 0, xtnfact = 0 , xttaxe=0;
            foreach (DataRow dr in ds.Tables["eentcb"].Rows)
            {
                Boolean xf = dr.Field<Boolean>("facture");

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


                if (xf)
                {
                    try
                    {
                        xtfact += dr.Field<Decimal>("totalttc");
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        xtnfact += dr.Field<Decimal>("totalttc");
                    }
                    catch { }
                }

                textBoxX1.Text = xth.ToString("N3");
                textBoxX2.Text = xtrem.ToString("N3");
                textBoxX3.Text = xtva.ToString("N3");
                textBoxX4.Text = xttc.ToString("N3");
                textBoxX5.Text = xfodec.ToString("N3");
                textBoxX6.Text = xtfact.ToString("N3");
                textBoxX7.Text = xtnfact.ToString("N3");
                textBoxX8.Text = xttaxe.ToString("N3");

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

        private void bon1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (met.verif_invent())
            {

                ModelVente form = new ModelVente();
                form.MVent = new MetierBonClient();
                SizeF s = new SizeF(form.groupBox3.Width, groupBox1.Size.Height);
                form.groupBox1.Size = s.ToSize();
                form.groupBox4.Visible = false;
                form.groupBox2.Visible = false;
                form.Tcom.Visible = false;
                form.ControlStock = true;
                form.LCOM.Visible = false;
                Point p = new Point(700, 19);
                form.ldate.Location = p;
                Point p1 = new Point(744, 15);
                form.datefact.Location = p1;
                form.Lnum.Text = "N° Bon";
                this.Visible = false;
                
                form.ShowDialog();
                this.Visible = true;
                buttonX1_Click(sender, e);

            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count != 0)
            {
                ModelVente form = new ModelVente();
                form.MVent = new MetierBonClient();
                SizeF s = new SizeF(groupBox1.Size.Width + form.groupBox4.Size.Width + form.groupBox2.Size.Width, groupBox1.Size.Height);
                form.groupBox1.Size = s.ToSize();
                form.groupBox4.Visible = false;
                form.groupBox2.Visible = false;
                form.Tcom.Visible = false;
                form.LCOM.Visible = false;
                form.Lnum.Text = "N° Bon";
                form.ControlStock = true;
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

        private void dataGridViewX1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow dgr in dataGridViewX1.Rows)
            {


                Boolean xtype = (Boolean)dgr.Cells["facture"].Value;

                if (xtype)
                {
                    dgr.Cells["num"].Style.ForeColor = Color.White;
                    dgr.Cells["num"].Style.BackColor = Color.Red;
                    dgr.Cells["date"].Style.ForeColor = Color.White;
                    dgr.Cells["date"].Style.BackColor = Color.Red;
                    dgr.Cells["codec"].Style.ForeColor = Color.White;
                    dgr.Cells["codec"].Style.BackColor = Color.Red;
                    dgr.Cells["libellec"].Style.ForeColor = Color.White;
                    dgr.Cells["libellec"].Style.BackColor = Color.Red;

                    dgr.Cells["totalht"].Style.ForeColor = Color.White;
                    dgr.Cells["totalht"].Style.BackColor = Color.Red;
                    dgr.Cells["fodec"].Style.ForeColor = Color.White;
                    dgr.Cells["fodec"].Style.BackColor = Color.Red;
                    dgr.Cells["totaltva"].Style.ForeColor = Color.White;
                    dgr.Cells["totaltva"].Style.BackColor = Color.Red;
                    dgr.Cells["totalrem"].Style.ForeColor = Color.White;
                    dgr.Cells["totalrem"].Style.BackColor = Color.Red;
                    dgr.Cells["totalttc"].Style.ForeColor = Color.White;
                    dgr.Cells["totalttc"].Style.BackColor = Color.Red;
                    dgr.Cells["facture"].Style.ForeColor = Color.White;
                    dgr.Cells["facture"].Style.BackColor = Color.Red;
                    dgr.Cells["totaltaxe"].Style.ForeColor = Color.White;
                    dgr.Cells["totaltaxe"].Style.BackColor = Color.Red;
                }

                else
                {

                    dgr.Cells["num"].Style.ForeColor = Color.White;
                    dgr.Cells["num"].Style.BackColor = Color.Blue;
                    dgr.Cells["date"].Style.ForeColor = Color.White;
                    dgr.Cells["date"].Style.BackColor = Color.Blue;
                    dgr.Cells["codec"].Style.ForeColor = Color.White;
                    dgr.Cells["codec"].Style.BackColor = Color.Blue;
                    dgr.Cells["libellec"].Style.ForeColor = Color.White;
                    dgr.Cells["libellec"].Style.BackColor = Color.Blue;

                    dgr.Cells["totalht"].Style.ForeColor = Color.White;
                    dgr.Cells["totalht"].Style.BackColor = Color.Blue;
                    dgr.Cells["fodec"].Style.ForeColor = Color.White;
                    dgr.Cells["fodec"].Style.BackColor = Color.Blue;
                    dgr.Cells["totaltva"].Style.ForeColor = Color.White;
                    dgr.Cells["totaltva"].Style.BackColor = Color.Blue;
                    dgr.Cells["totalrem"].Style.ForeColor = Color.White;
                    dgr.Cells["totalrem"].Style.BackColor = Color.Blue;
                    dgr.Cells["totalttc"].Style.ForeColor = Color.White;
                    dgr.Cells["totalttc"].Style.BackColor = Color.Blue;
                    dgr.Cells["facture"].Style.ForeColor = Color.White;
                    dgr.Cells["facture"].Style.BackColor = Color.Blue;
                    dgr.Cells["totaltaxe"].Style.ForeColor = Color.White;
                    dgr.Cells["totaltaxe"].Style.BackColor = Color.Blue;

                }
            }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count != 0)
            {
                String Nmvt = dataGridViewX1.SelectedRows[0].Cells["NuM"].Value + "";
                String ent = "eentcb";
                String lent = "lentcb";
                String numero = "Bon Comptoir";
                String typedition = "B";
                string impbon = "";

                string sql = "Select value From parametre where param ='BonTicket'";
                DataSet tmp = met.recuperer_table(sql);
                if (tmp.Tables[0].Rows.Count != 0)
                {
                    impbon = (string)tmp.Tables[0].Rows[0].ItemArray[0];
                }

                if (impbon == "Oui")
                {
                    ds = new DataSet();
                    sql = "select * from exercice where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
                    met.recuperer_table(sql, ds, "exercice");

                    sql = "select * from ste where code='" + Program.Societe + "'";
                    met.recuperer_table(sql, ds, "ste");

                    sql = "SELECT * FROM entete  where codes='" + Program.Societe + "'";
                    met.recuperer_table(sql, ds, "entete");

                    sql = "select * from magasin where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code = '" + Program.Magasin + "'";
                    met.recuperer_table(sql, ds, "magasin");

                    sql = "select * from " + ent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num ='" + Nmvt + "'";
                    met.recuperer_table(sql, ds, "eentl");

                    sql = "select * from " + lent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num ='" + Nmvt + "'";
                    met.recuperer_table(sql, ds, "lentl");

                    sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  order by code";
                    met.recuperer_table(sql, ds, "client");

                    sql = "SELECT * FROM sarticle  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
                    met.recuperer_table(sql, ds, "sarticle");

                    sql = "SELECT * FROM gamme  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
                    met.recuperer_table(sql, ds, "gamme");

                    sql = "SELECT * FROM article WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
                    met.recuperer_table(sql, ds, "article");


                    commerciale.rptedit.Iticket ij = new commerciale.rptedit.Iticket();
                    ij.numero = numero;
                    ij.ds = ds;
                    ij.ShowDialog();
                }
                else
                {
                    impression form = new impression(ent, lent, Nmvt, numero, typedition);
                    form.ShowDialog();
                }
            }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count != 0)
            {
                String numfact = dataGridViewX1.SelectedRows[0].Cells["NuM"].Value + "";
                facturecbd fct = new facturecbd();
                fct.BNum = numfact;
                fct.ShowDialog();
                buttonX1_Click(sender, e);
            }
        }

    }
}
