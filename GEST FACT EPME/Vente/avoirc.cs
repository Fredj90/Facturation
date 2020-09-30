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
    public partial class avoirc : System.Windows.Forms.Form
    {
        
        private metier met = Program.met;
        DataSet ds;

        Boolean first = true, xvstk = false;
        public avoirc()
        {
            InitializeComponent();
        }

       


        private void avoirc_Load(object sender, EventArgs e)
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
               
                // Chargement ligne Avoir
                string req1 = "select distinct  l.num,l.codea, a.libelle , g.libelle as gamme , d.libelle as depot , l.qte , l.pu , l.tva ,l.taxe, l.tvaf , l.rem , l.netht , l.netttc,l.codesa,l.ID   from lentvc l , article a , gamme g , depot d where l.codes='" + Program.Societe + "' and l.codee='" + Program.Exercice + "' and l.num= '" + dataGridViewX1.SelectedRows[0].Cells["num"].Value + "' and  l.codem='" + Program.Magasin + "' and l.codea = a.code and l.codes= a.codes and l.codee= a.codee and l.codea = g.codea and l.codeg=g.codeg  and l.codes=g.codes and l.codee=g.codee and l.coded= d.code and l.codes=d.codes and l.codee=d.codee and l.codem=d.codem ";
                DataSet ds1 = met.recuperer_table(req1, "lentvc");

                foreach (DataRow dr in ds1.Tables["lentvc"].Rows)
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
                dataGridViewX2.DataSource = ds1.Tables["lentvc"].DefaultView;

            }
        }


        private void buttonX3_Click(object sender, EventArgs e)
        {
            // Bouton Supprimer Avoir
            if (dataGridViewX1.Rows.Count != 0)
            {
                string sql = "select * from eentvc where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and num = '" + dataGridViewX1.SelectedRows[0].Cells[0].Value + "'";
                DataSet dss = met.recuperer_table(sql, "eentvc");
                if (dss.Tables["eentvc"].Rows.Count != 0)
                {

                    String msg = MessageBox.Show("Ete-vous sur", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                    if (msg.Equals("Yes"))
                    {

                        String req = "DELETE FROM eentvc Where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and num = '" + dataGridViewX1.SelectedRows[0].Cells[0].Value + "'";

                        if (met.Execute(req))
                        {
                            String sqlqte = "Select * From lentvc Where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and num = '" + dataGridViewX1.SelectedRows[0].Cells[0].Value + "'";
                            DataSet dstavr = met.recuperer_table(sqlqte);
                            if (dstavr != null)
                            {
                                if (dstavr.Tables.Count != 0)
                                {
                                    foreach (DataRow dr1 in dstavr.Tables[0].Rows)
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
                                        string sql1 = "Select qtestk,qteavrc from artdep where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea ='" + xcodea + "' and coded='" + xcoded + "' and codem='" + Program.Magasin + "' and codeg='" + xcodeg + "'";
                                        DataSet ds1 = met.recuperer_table(sql1, "artdep");
                                        if (ds1 != null)
                                            if (ds1.Tables.Count != 0)
                                                if (ds1.Tables["artdep"].Rows.Count != 0)
                                                {
                                                    Double.TryParse(ds1.Tables["artdep"].Rows[0]["qtestk"] + "", out QTESTK);
                                                    Double.TryParse(ds1.Tables["artdep"].Rows[0]["qteavrc"] + "", out QTESOR);
                                                }

                                        string sql2 = "Select qtestk,qteavrc from artmag where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea ='" + xcodea + "'  and codem='" + Program.Magasin + "'";
                                        DataSet ds2 = met.recuperer_table(sql2, "artmag");
                                        if (ds2 != null)
                                            if (ds2.Tables.Count != 0)
                                                if (ds2.Tables["artmag"].Rows.Count != 0)
                                                {
                                                    Double.TryParse(ds2.Tables["artmag"].Rows[0]["qtestk"] + "", out QTEMAG);
                                                    Double.TryParse(ds2.Tables["artmag"].Rows[0]["qteavrc"] + "", out QTESORMAG);
                                                }

                                        string sql3 = "Select qtestk,qteavrc,vstk from article where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code ='" + xcodea + "' ";
                                        DataSet ds3 = met.recuperer_table(sql3, "article");
                                        if (ds3 != null)
                                            if (ds3.Tables.Count != 0)
                                                if (ds3.Tables["article"].Rows.Count != 0)
                                                {
                                                    xvstk = ds3.Tables["article"].Rows[0].Field<Boolean>("vstk");
                                                    Double.TryParse(ds3.Tables["article"].Rows[0]["qtestk"] + "", out QTESTE);
                                                    Double.TryParse(ds3.Tables["article"].Rows[0]["qteavrc"] + "", out QTESORSTE);
                                                }



                                        if (xvstk == true)
                                        {
                                            string sqlup = "UPDATE artdep set qtestk = '" + (QTESTK - xqte) + "',qteavrc='" + (QTESOR - xqte) + "' where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea ='" + xcodea + "' and coded='" + xcoded + "' and codem='" + Program.Magasin + "' and codeg='" + xcodeg + "'";
                                            met.Execute(sqlup);

                                            sqlup = "UPDATE artmag set qtestk = '" + (QTEMAG - xqte) + "',qteavrc='" + (QTESORMAG - xqte) + "' where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea ='" + xcodea + "'  and codem='" + Program.Magasin + "'";
                                            met.Execute(sqlup);

                                            sqlup = "UPDATE article set qtestk = '" + (QTESTE - xqte) + "',qteavrc='" + (QTESORSTE - xqte) + "' where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code ='" + xcodea + "' ";
                                            met.Execute(sqlup);

                                        }
                                        #endregion // Update stock

                                        #region Update Client
                                        Decimal xdeb = 0, xven = 0;
                                        String req5 = "Select code,avoir,solde From client where codes = '" + Program.Societe + "' AND codee ='" + Program.Exercice + "' AND Code = '" + dataGridViewX1.SelectedRows[0].Cells["codec"].Value + "'";
                                        DataSet dsc = met.recuperer_table(req5, "client");
                                        decimal wdeb = 0, wsld = 0;
                                        try
                                        {
                                            wdeb = dsc.Tables["client"].Rows[0].Field<decimal>("avoir");

                                        }
                                        catch { }

                                        try
                                        {
                                            wsld = dsc.Tables["client"].Rows[0].Field<decimal>("solde");
                                        }
                                        catch { }

                                        try
                                        {
                                            decimal.TryParse(dataGridViewX1.SelectedRows[0].Cells["TOTALTTC"].Value + "", out xdeb);
                                        }
                                        catch { }

                                        String upcli = "UPDATE client SET avoir = " + (wdeb - xdeb)
                                                     + ", solde=" + (wsld + xdeb)
                                                      + " where codes = '" + Program.Societe + "' AND codee ='" + Program.Exercice + "' AND Code = '" + dataGridViewX1.SelectedRows[0].Cells["codec"].Value + "'";
                                        met.Execute(upcli);


                                        /*String req6 = "Select code,vente,taux,com From rep where codes = '" + Program.Societe + "' AND codee ='" + Program.Exercice + "' AND Code = '" + dataGridViewX1.SelectedRows[0].Cells["coder"].Value + "'";
                                        DataSet dsr = met.recuperer_table(req6, "rep");
                                        decimal wven = 0, nven = 0;
                                        double wcom = 0, wtaux = 0;
                                        try
                                        {
                                            wven = dsr.Tables["rep"].Rows[0].Field<decimal>("vente");

                                        }
                                        catch { }
                                        try
                                        {
                                            wtaux = dsr.Tables["rep"].Rows[0].Field<double>("taux");

                                        }
                                        catch { }

                                        try
                                        {
                                            decimal.TryParse(dataGridViewX1.SelectedRows[0].Cells["TOTALHT"].Value + "", out xven);
                                        }
                                        catch { }

                                        nven = wven + xven;
                                        wcom = (double)nven * (wtaux / 100);
                                        String uprep = "UPDATE rep SET vente = " + nven
                                                     + ", com=" + wcom
                                                      + " where codes = '" + Program.Societe + "' AND codee ='" + Program.Exercice + "' AND Code = '" + dataGridViewX1.SelectedRows[0].Cells["coder"].Value + "'";
                                        met.Execute(uprep);
                                        */


                                        #endregion
                                    }
                                }
                            }
                            String req1 = "DELETE FROM lentvc Where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and num = '" + dataGridViewX1.SelectedRows[0].Cells[0].Value + "'";
                            if (met.Execute(req1))
                                MessageBox.Show("Suppression effectuée");
                        }
                        buttonX1_Click(sender, e);
                    }
                }
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
                    DataRow[] dr = ds.Tables["eentvc"].Select("num = '" + form.textBoxX3.Text + "'");
                    if (dr.Length != 0)
                    {
                        int i = ds.Tables[0].Rows.IndexOf(dr[0]);
                        dataGridViewX1.Rows[i].Selected = true;
                    }
                    else
                    {
                        MessageBox.Show("N° Avoir n'existe pas.");
                    }
                }
                else if (!form.code.Equals("0") && !form.dateTimeInput1.Text.Equals("") && !form.dateTimeInput2.Text.Equals(""))
                {

                    string ddebut = form.dateTimeInput1.Value.ToString("yyyy-MM-dd");
                    string dfin = form.dateTimeInput2.Value.ToString("yyyy-MM-dd");
                    string req2 = "select num,date,codec,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc from eentvc where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and (codec='" + form.code + "' AND date>='" + ddebut + "' AND date<='" + dfin + "') order by num";
                    ds = met.recuperer_table(req2, "eentvc");
                    dataGridViewX1.DataSource = ds.Tables["eentvc"].DefaultView;
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
                    string req2 = "select num,date,codec,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc from eentvc where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and (codec='" + form.code + "' AND date>=#" + ddebut + "# ) order by num";
                    ds = met.recuperer_table(req2, "eentvc");
                    dataGridViewX1.DataSource = ds.Tables["eentvc"].DefaultView;
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
                    string req2 = "select num,date,codec,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc from eentvc where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and (codec='" + form.code + "') order by num";
                    ds = met.recuperer_table(req2, "eentvc");
                    dataGridViewX1.DataSource = ds.Tables["eentvc"].DefaultView;
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
                    string req2 = "select num,date,codec,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc from eentvc where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and (date>='" + ddebut + "' AND date<='" + dfin + "') order by num";
                    ds = met.recuperer_table(req2, "eentvc");
                    dataGridViewX1.DataSource = ds.Tables["eentvc"].DefaultView;
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
                    string req2 = "select num,date,codec,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc from eentvc where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and (date>=#" + ddebut + "# ) order by num";
                    ds = met.recuperer_table(req2, "eentvc");
                    dataGridViewX1.DataSource = ds.Tables["eentvc"].DefaultView;
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

        private void avoirc_KeyDown(object sender, KeyEventArgs e)
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


            string req = "select num,nfact,date,codec,totalht,fodec,totalrem,totaltva,totaltaxe,totalttc from eentvc where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "'  order by num";
            ds = met.recuperer_table(req, "eentvc");
            dataGridViewX1.DataSource = ds.Tables["eentvc"].DefaultView;
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
            foreach (DataRow dr in ds.Tables["eentvc"].Rows)
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

        private void avoirc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

        private void dataGridViewX1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridViewX2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count != 0)
            {
                ModelVente form = new ModelVente();
                form.MVent = new MetierAvoirClient();
                SizeF s = new SizeF(form.groupBox1.Size.Width + form.groupBox4.Size.Width + form.groupBox2.Size.Width, form.groupBox1.Size.Height);
                form.groupBox1.Size = s.ToSize();
                form.groupBox4.Visible = false;
                form.groupBox2.Visible = false;
                form.Tcom.Visible = false;
                form.ControlStock = true;
                form.LCOM.Visible = false;
                form.Lnum.Text = "N° Avoir";
                this.Visible = false;
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

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Avoirvc form = new Avoirvc();
            int ind = 0;
            try
            { ind = dataGridViewX1.CurrentRow.Index; }
            catch { }
            form.ShowDialog();
            buttonX1_Click(sender, e);
            this.Visible = true;
            dataGridViewX1.CurrentCell = dataGridViewX1[1, ind];

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            ModelVente form = new ModelVente();

            form.MVent = new MetierAvoirClient();
            SizeF s = new SizeF(form.groupBox1.Size.Width + form.groupBox4.Size.Width + form.groupBox2.Size.Width, form.groupBox1.Size.Height);
            form.groupBox1.Size = s.ToSize();
            form.groupBox4.Visible = false;
            form.groupBox2.Visible = false;
            form.Tcom.Visible = false;
            form.ControlStock = true;
            form.LCOM.Visible = false;
            form.Lnum.Text = "N° Avoir";
            this.Visible = false;
            form.ShowDialog();
            this.Visible = true;
            buttonX1_Click(sender, e);
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count != 0)
            {
                String Nmvt = dataGridViewX1.SelectedRows[0].Cells["NuM"].Value + "";
                String ent = "eentvc";
                String lent = "lentvc";
                String numero = "Avoir";
                String typedition = "D";
                impression form = new impression(ent, lent, Nmvt, numero, typedition);
                form.ShowDialog();
            }
        }

       
    }
}
