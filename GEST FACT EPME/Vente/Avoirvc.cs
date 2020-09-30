using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace commerciale
{
    public partial class Avoirvc : System.Windows.Forms.Form
    {
        private metier met = Program.met;
        DataSet ds,ds4;
        MetierClient cli;
        public int wnum, xnum;
        int index = 0;
        MetierParametre metparam = new MetierParametre();
        double Timbre = 0;
        private double xqte = 0, xpu = 0, xtva = 0, xrem = 0, xfodec = 0, EMBALLAGE = 0 , xtaxe = 0;
        private double MNTNETHT = 0, MNTREM = 0, MNTFODEC = 0, MNTTVA = 0, MNTNETTTC = 0;
        private double THT = 0, TFODEC = 0, TREM = 0, TTVA = 0, TTTC = 0, TTAXE= 0;
        private double MNTTAXE = 0;
        private string numfactvc = "";
        public Avoirvc()
        {
            InitializeComponent();
        }

        private void factclibc_Load(object sender, EventArgs e)
        {
            String req = "SELECT * FROM pnumste where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
            ds = met.recuperer_table(req, "pnumste");
            if (ds != null)
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        index = ds.Tables[0].Rows.Count - 1;

                    }
                }
            increment();
            metparam.Init();
            datefact.Value = DateTime.Now;
            dated.Value = DateTime.Now;
            datef.Value = DateTime.Now;
        }
      

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (Tcodc.Text != "")
            {
                {
                    if (!dated.Text.Equals("") && !datef.Text.Equals(""))
                    {

                        string date1 = dated.Value.ToString("yyyy-MM-dd");
                        string date2 = datef.Value.ToString("yyyy-MM-dd");
                        string req20 = "select num,date,totalttc from eentc where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "'   and date>='" + date1 + "' AND date<='" + date2 + "' and codec= '" + Tcodc.Text + "' ";
                        ds = met.recuperer_table(req20, "eentl");
                        if (ds != null)
                        {
                            if (ds.Tables.Count != 0)
                            {
                                if (ds.Tables[0].Rows.Count != 0)
                                {
                                    try
                                    {
                                        //dgv_fact.Rows.Clear();
                                        ((DataView)dgv_fact.DataSource).Table.Clear();
                                    }
                                    catch { }

                                    //buttonX3.Visible = false;
                                    dgv_bl.DataSource = ds.Tables["eentl"].DefaultView;
                                }
                                else
                                {
                                    //buttonX3.Visible = false;
                                    try
                                    {
                                        ((DataView)dgv_bl.DataSource).Table.Clear();
                                    }
                                    catch { }
                                    try
                                    {
                                        //dgv_fact.Rows.Clear();
                                        ((DataView)dgv_fact.DataSource).Table.Clear();
                                    }
                                    catch { }
                                    Total();
                                    MessageBox.Show("Pas de Facturer");
                                }
                            }
                            

                        }
                    }
                    else
                        MessageBox.Show("Saisir les dates SVP");
                }
            }
            else
                MessageBox.Show("Saisir Client SVP");
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

            string req4 = "select distinct  l.num,l.codea, a.libelle , g.libelle as gamme , d.libelle as depot , l.qte , l.pu , l.tva ,l.taxe, l.tvaf , l.rem , l.netht , l.netttc,l.codesa,l.codeg,l.coded,l.codea as codeart,l.ID from lentvc l , article a , gamme g , depot d where l.codes='" + Program.Societe + "' and l.codee='" + Program.Exercice + "' and  l.codem='" + Program.Magasin + "' and l.codea = a.code and l.codes= a.codes and l.codee= a.codee and l.codea = g.codea and l.codeg=g.codeg  and l.codes=g.codes and l.codee=g.codee and l.coded= d.code and l.codes=d.codes and l.codee=d.codee and l.codem=d.codem ";
            string tmp = " and (";
            Boolean f = true;
            foreach (DataGridViewRow dr in dgv_bl.Rows)
            {
                if (!f)
                    tmp += " or ";
                dr.Cells["choix"].Value = true;

                tmp += "l.num = '" + dr.Cells["num"].Value + "'";
                f = false;
            }
            tmp += ")";
            req4 += tmp;
            ds4 = met.recuperer_table(req4, "lentcb");
            foreach (DataRow dr in ds4.Tables["lentcb"].Rows)
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

            dgv_fact.DataSource = ds4.Tables["lentcb"].DefaultView;
            Total();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dr in dgv_bl.Rows)
            {

                dr.Cells["choix"].Value = false;

            }

            try
            {
                //dgv_fact.Rows.Clear();
                ((DataView)dgv_fact.DataSource).Table.Clear();
            }
            catch { }
            Total();
        }

        private void dgv_bl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow drr in dgv_bl.Rows)
            {
                drr.Cells["choix"].Value = false;
            }
            if (dgv_bl.CurrentCell.ColumnIndex == 0)
                if (dgv_bl.CurrentCell.Value != null)
                    dgv_bl.CurrentCell.Value = !(Boolean)dgv_bl.CurrentCell.Value;
                else
                    dgv_bl.CurrentCell.Value = true;


            string req4 = "select distinct  l.num,l.codea, a.libelle , g.libelle as gamme , d.libelle as depot , l.qte,l.qte as QTEAvr , l.pu , l.tva, l.taxe , l.tvaf , l.rem , l.netht , l.netttc,l.codesa,l.codeg,l.coded,l.codea as codeart,l.ID from lentc l , article a , gamme g , depot d where l.codes='" + Program.Societe + "' and l.codee='" + Program.Exercice + "' and  l.codem='" + Program.Magasin + "' and l.codea = a.code and l.codes= a.codes and l.codee= a.codee and l.codea = g.codea and l.codeg=g.codeg  and l.codes=g.codes and l.codee=g.codee and l.coded= d.code and l.codes=d.codes and l.codee=d.codee and l.codem=d.codem ";
            string tmp = " and (";

            Boolean f = true;
            foreach (DataGridViewRow dr in dgv_bl.Rows)
            {
                if (dr.Cells["choix"].Value != null)
                    if ((Boolean)dr.Cells["choix"].Value)
                    {
                        if (!f)
                            tmp += " or ";
                        tmp += "l.num = '" + dr.Cells["num"].Value + "'";
                        f = false;
                        numfactvc = dr.Cells["num"].Value + "";
                    }
            }
            tmp += ")";
            req4 += tmp;

            if (!f)
            {
                ds4 = met.recuperer_table(req4, "lentcb");
                foreach (DataRow dr in ds4.Tables["lentcb"].Rows)
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

                dgv_fact.DataSource = ds4.Tables["lentcb"].DefaultView;
                Total();
            }
            else
                try
                {
                    //dgv_fact.Rows.Clear();
                    ((DataView)dgv_fact.DataSource).Table.Clear();
                }
                catch { }
                Total();
        }

        private void Total()
        {
            string xcodeart = "";
            xqte = xpu = xtva = xrem = xfodec = xtaxe = 0;
            MNTNETHT = MNTREM = MNTFODEC = MNTTVA = MNTNETTTC =  MNTTAXE = 0;
            THT = TFODEC = TREM = TTVA = TTTC = TTAXE = 0;

            foreach (DataGridViewRow dr in dgv_fact.Rows)
            {
                try
                {
                    xcodeart = (string)dr.Cells["a0"].Value + "";
                }
                catch { }


                Double.TryParse(dr.Cells["QTEAvr"].Value + "", out xqte);
                Double.TryParse(dr.Cells["a5"].Value + "", out xpu);
                Double.TryParse(dr.Cells["a6"].Value + "", out xtva);
                Double.TryParse(dr.Cells["a7"].Value + "", out xfodec);
                Double.TryParse(dr.Cells["a8"].Value + "", out xrem);
                Double.TryParse(dr.Cells["taxe"].Value + "", out xtaxe);

                String sql = "SELECT emb FROM article  where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' and code='" + xcodeart + "'";
                ds = met.recuperer_table(sql, "Article");
                if (ds != null)
                    if (ds.Tables["Article"].Rows.Count != 0)
                    {

                        DataRow dr1 = ds.Tables["Article"].Rows[0];
                        Double.TryParse(dr1["emb"] + "", out EMBALLAGE);

                    }


                MNTNETHT = xpu * (xqte)/EMBALLAGE;
                MNTREM = MNTNETHT * xrem / 100;
                MNTNETHT -= MNTREM;
                MNTFODEC = MNTNETHT * xfodec / 100;
                MNTNETHT += MNTFODEC;
                MNTTVA = MNTNETHT * xtva / 100;
                MNTNETTTC = MNTNETHT + MNTTVA;
                MNTTAXE = MNTNETTTC * xtaxe / 100;
                MNTNETTTC += MNTNETTTC * xtaxe / 100;
               

                THT += MNTNETHT + MNTREM;
                TFODEC += MNTFODEC;
                TREM += MNTREM;
                TTVA += MNTTVA;
                TTTC += MNTNETTTC;
                TTAXE += MNTTAXE;
            }

            TTTC += Timbre;
            textB1.Text = THT.ToString("N3");
            textB2.Text = TFODEC.ToString("N3");
            textB3.Text = TREM.ToString("N3");
            textB4.Text = TTVA.ToString("N3");
            textB5.Text = Timbre.ToString("N3");
            textB6.Text = TTTC.ToString("N3");
            textB7.Text = TTAXE.ToString("N3");
        }

 # region // Région Sauvegarde

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (dgv_fact.Rows.Count != 0)
            {
                test_numero();

                string date1 = datefact.Value.ToString("yyyy-MM-dd");

                string sql = "INSERT INTO eentvc (`codeu`, `codes`, `codee`, `codem`, `NUM`, `DATE`, `CODEC`, `nomc`,`adrc`," +
              "  `TOTALHT`, `fodec`, `TOTALREM`, `TOTALTVA`,TOTALTAXE,`TIMBRE` ,`TOTALTTC`,`nfact`) VALUES ("
              + "'" + Program.User + "',"
              + "'" + Program.Societe + "',"
              + "'" + Program.Exercice + "',"
              + "'" + Program.Magasin + "',"
              + "'" + nfact.Text + "',"
              + "'" + date1 + "',"
              + "'" + Tcodc.Text + "',"
              + "'" + Tnomc.Text + "',"
              + "'" + Tadrc.Text + "',"
              + "'" + THT + "',"
              + "'" + TFODEC + "',"
              + "'" + TREM + "',"
              + "'" + TTVA + "',"
              + "'" + TTAXE + "',"
              + "'" + 0 + "',"
              + "'" + TTTC + "',"
              + "'" + numfactvc + "'"
              + ")";
                met.Execute(sql);
                SaveLigne();
                MessageBox.Show("Sauvegarde effectué.");
                DesActiverVente();

                Double TTC = TTTC;
                String sqlcli = "Select solde1,debit,avoir,credit,solde,rem,retenue From client where codes = '" + Program.Societe + "' AND codee ='" + Program.Exercice + "' AND Code = '" + cli.Codec + "'";
                DataSet tmp1 = met.recuperer_table(sqlcli);
                double deb = 0, cre = 0, avr = 0, sld1 = 0, rem = 0, ret = 0;
                double.TryParse(tmp1.Tables[0].Rows[0]["solde1"] + "", out sld1);
                double.TryParse(tmp1.Tables[0].Rows[0]["debit"] + "", out deb);
                double.TryParse(tmp1.Tables[0].Rows[0]["credit"] + "", out cre);
                double.TryParse(tmp1.Tables[0].Rows[0]["avoir"] + "", out avr);
                double.TryParse(tmp1.Tables[0].Rows[0]["rem"] + "", out rem);
                double.TryParse(tmp1.Tables[0].Rows[0]["retenue"] + "", out ret);

                double Ndeb = avr + TTC;
                String upcli = "UPDATE client SET avoir = " + Ndeb
                     + ", solde=" + ((sld1 + deb) - (cre + rem + ret + Ndeb))
                     + " WHERE  codes = '" + Program.Societe + "' AND codee ='" + Program.Exercice + "' AND Code = '" + cli.Codec + "'";
                met.Execute(upcli);


            }
            else
                MessageBox.Show("Pas de donnée à Sauvegarder");

        }

        private void SaveLigne()
        {
            string date1 = datefact.Value.ToString("yyyy-MM-dd");
            foreach (DataGridViewRow dr in dgv_fact.Rows)
            {

                String xQTEAvr = "Null", xcodesa = "Null,", xa4 = "Null,", xtaxe = "0.00", xa5 = "Null,", xa6 = "Null,", xa7 = "Null,", xa8 = "Null,", xa9 = "Null,", xa10 = "Null";
                if (dr.Cells["a4"].Value != DBNull.Value)
                    xa4 = "'" + dr.Cells["a4"].Value + "',";
                if (dr.Cells["a5"].Value != DBNull.Value)
                    xa5 = "'" + dr.Cells["a5"].Value + "',";
                if (dr.Cells["a6"].Value != DBNull.Value)
                    xa6 = "'" + dr.Cells["a6"].Value + "',";
                if (dr.Cells["a7"].Value != DBNull.Value)
                    xa7 = "'" + dr.Cells["a7"].Value + "',";
                if (dr.Cells["a8"].Value != DBNull.Value)
                    xa8 = "'" + dr.Cells["a8"].Value + "',";
                if (dr.Cells["a9"].Value != DBNull.Value)
                    xa9 = "'" + dr.Cells["a9"].Value + "',";
                if (dr.Cells["a10"].Value != DBNull.Value)
                    xa10 = "'" + dr.Cells["a10"].Value + "'";
                if (dr.Cells["codesa"].Value != DBNull.Value)
                    xcodesa = "'" + dr.Cells["codesa"].Value + "',";

                if (dr.Cells["taxe"].Value != DBNull.Value)
                    xtaxe = "'" + dr.Cells["taxe"].Value + "',";
                if (dr.Cells["QTEAvr"].Value != DBNull.Value)
                    xQTEAvr = "'" + dr.Cells["QTEAvr"].Value + "',";
                Boolean xvstk = false;
                Double xqte = 0;
                Double.TryParse(dr.Cells["QTEAvr"].Value + "", out xqte);
                if (xqte != 0)
                {
                    String sql = "INSERT INTO lentvc (`codes`, `codee`, `codem`, `coded`, `codeg`, `NUM`, `DATE`,"
                                    + " `CODEA`, `CODESA`, `NBP`, `QTE`, `PU`, `TVA`,taxe, `TVAF`, `REM`, `netht`, `netttc`) VALUES ("
                                        + "'" + Program.Societe + "',"
                                        + "'" + Program.Exercice + "',"
                                        + "'" + Program.Magasin + "',"
                                        + "'" + dr.Cells["coded"].Value + "',"
                                        + "'" + dr.Cells["codeg"].Value + "',"
                                        + "'" + nfact.Text + "',"
                                        + "'" + date1 + "',"
                                        + "'" + dr.Cells["codeart"].Value + "',"
                                        + xcodesa
                                        + "Null,"
                                        + xQTEAvr
                                        + xa5
                                        + xa6
                                        + xtaxe
                                        + xa7
                                        + xa8
                                        + xa9
                                        + xa10
                                        + ")";
                    met.Execute(sql);


                    double QTESTK = 0, QTESOR = 0, QTEMAG = 0, QTESORMAG = 0, QTESTE = 0, QTESORSTE = 0;
                    string xcodea = "";
                    xcodea = dr.Cells["codeart"].Value + "";
                    string xcodeg = dr.Cells["codeg"].Value + "";
                    string xcoded = dr.Cells["coded"].Value + "";

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
                        string sqlup = "UPDATE artdep set qtestk = '" + (QTESTK + xqte) + "',qteavrc='" + (QTESOR + xqte) + "' where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea ='" + xcodea + "' and coded='" + xcoded + "' and codem='" + Program.Magasin + "' and codeg='" + xcodeg + "'";
                        met.Execute(sqlup);

                        sqlup = "UPDATE artmag set qtestk = '" + (QTEMAG + xqte) + "',qteavrc='" + (QTESORMAG + xqte) + "' where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea ='" + xcodea + "'  and codem='" + Program.Magasin + "'";
                        met.Execute(sqlup);

                        sqlup = "UPDATE article set qtestk = '" + (QTESTE + xqte) + "',qteavrc='" + (QTESORSTE + xqte) + "' where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code ='" + xcodea + "' ";
                        met.Execute(sqlup);

                    }
                    #endregion // Update stock



                }
            }
        }


        private void SaveIncrementationNumero()
        {
            String req = "SELECT * FROM pnumste where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
            DataSet dsi = met.recuperer_table(req, "pnum");
            string s2 = dsi.Tables[0].Rows[0].Field<Object>("avoirc") + "";
            String snum = nfact.Text.Substring(2, nfact.Text.Length - 2);
            int anum = int.Parse(snum);
            int xnum = int.Parse(s2);
            xnum++;
            if (anum >= xnum)
            {
                string s = anum.ToString().Trim();
                int l1 = s2.Trim().Length;
                int l2 = s.Length;
                for (int ii = l2; ii < l1; ii++)
                    s = "0" + s;
                string sqlinc = "UPDATE pnumste SET avoirc = '" + s + "' where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
                met.Execute(sqlinc);
            }
        }

        private void increment()
        {
            String req = "SELECT * FROM pnumste where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
            DataSet ds = met.recuperer_table(req, "pnum");
            int index = 0;
            if (ds != null)
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        index = ds.Tables[0].Rows.Count - 1;

                    }
                }
            string s1 = ds.Tables[0].Rows[index].Field<Object>("davoirc") + "";
            string s2 = ds.Tables[0].Rows[index].Field<Object>("avoirc") + "";
            int num = int.Parse(s2);
            num++;
            string s = num.ToString().Trim();
            int l1 = s2.Trim().Length;
            int l2 = s.Length;
            for (int i = l2; i < l1; i++)
                s = "0" + s;
            s = s1 + s;
            nfact.Text = s;
            nfact.Select(nfact.Text.Length, 0);
        }

        private void test_numero()
        {
            String sql = "SELECT num FROM eentvc WHERE num = '" + nfact.Text + "' AND codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "'  ";
            DataSet tmp = met.recuperer_table(sql, "eentvc");
            if (tmp.Tables["eentvc"].Rows.Count != 0)
                increment();
            SaveIncrementationNumero();
        }

        # endregion // Finregion Sauvegarde

 # region // Région Keypress

        private void nfact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                datefact.Focus();
        }

        private void datefact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                Tcodc.Focus();
        }

        
        private void Tcodc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                Tnomc.Focus();
        }


        private void Tnomc_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }


        private void cmbtypevente_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dated_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                datef.Focus();
        }

        private void datef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
               buttonX1.Focus();
        }

        # endregion Fin Région Keypress

 #region // Région Recherche Client 

        private void Tcodc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                if (Tcodc.Text != "")
                {
                    //buttonX3.Visible = false;
                    rechcli rcli = new rechcli("client", Tcodc.Text, null);
                    rcli.ShowDialog();
                    Tcodc.Text = rcli.code;
                    Tnomc.Text = rcli.libe;
                    Tadrc.Text = rcli.adre;

                    cli = new MetierClient(rcli.code);
                    Timbre = 0;
                    dated.Focus();
                    string req20 = "select num,date,totalttc from eentc where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "'  and codec= '" + Tcodc.Text + "'";
                     ds = met.recuperer_table(req20, "eentcb");
                     if (ds != null)
                     {
                         if (ds.Tables.Count != 0)
                         {
                             if (ds.Tables[0].Rows.Count != 0)
                             {
                                 cli = new MetierClient(Tcodc.Text);

                                 try
                                 {
                                     ((DataView)dgv_bl.DataSource).Table.Clear();
                                 }
                                 catch { }
                                 try
                                 {
                                     ((DataView)dgv_fact.DataSource).Table.Clear();
                                 }
                                 catch { }
                                 Total();
                             }
                             else
                             {
                                 Tcodc.Text = "";
                                 Tnomc.Text = "";
                                 Tadrc.Text = "";
                                 try
                                 {
                                     ((DataView)dgv_bl.DataSource).Table.Clear();
                                 }
                                 catch { }
                                 try
                                 {
                                     ((DataView)dgv_fact.DataSource).Table.Clear();
                                 }
                                 catch { }
                                 Total();
                                 MessageBox.Show("Client n'a pas de Facturer");
                             }
                         }
                     }
                    
                }
            }
        }

        private void Tnomc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                if (Tnomc.Text != "")
                {
                   // buttonX3.Visible = false;
                    rechcli rcli = new rechcli("client", null, Tnomc.Text);
                    rcli.ShowDialog();
                    Tcodc.Text = rcli.code;
                    Tnomc.Text = rcli.libe;
                    Tadrc.Text = rcli.adre;

                    cli = new MetierClient(rcli.code);
                    if (cli.TimbreFactClient)
                    {
                        Timbre = metparam.Timbre; ;
                    }
                    else
                        Timbre = 0;

                    string req20 = "select num,date,totalttc from eentc where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "'  and codec= '" + Tcodc.Text + "'";
                    ds = met.recuperer_table(req20, "eentcb");
                    if (ds != null)
                    {
                        if (ds.Tables.Count != 0)
                        {
                            if (ds.Tables[0].Rows.Count != 0)
                            {
                                cli = new MetierClient(Tcodc.Text);
                                try
                                {
                                    ((DataView)dgv_bl.DataSource).Table.Clear();
                                }
                                catch { }
                                try
                                {
                                    ((DataView)dgv_fact.DataSource).Table.Clear();
                                }
                                catch { }
                                Total();
                            }
                            else
                            {
                                Tcodc.Text = "";
                                Tnomc.Text = "";
                                Tadrc.Text = "";
                                try
                                {
                                    ((DataView)dgv_bl.DataSource).Table.Clear();
                                }
                                catch { }
                                try
                                {
                                    ((DataView)dgv_fact.DataSource).Table.Clear();
                                }
                                catch { }
                                Total();
                                MessageBox.Show("Client n'a pas de Facturer");
                            }
                        }
                    }
                    //cli = new MetierClient(Tcodc.Text);
                    //cmbtypevente.Focus();
                }
            }
        }

       
        # endregion Fin Recherche Client & Répresentant

        private void factclibl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    String msg = MessageBox.Show("Ete-vous sur", "Sortir", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                    if (msg.Equals("Yes"))
                    {
                        this.Close();
                    }
                    break;

                default:
                    // actions_sinon;
                    break;
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (dgv_fact.Rows.Count != 0)
            {
                String msg = MessageBox.Show("Etes-vous sûr de Quitter Sans Sauvegarde ", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (msg.Equals("Yes"))
                {
                    this.Close();
                }
            }
            else
                this.Close();
        }

        private void DesActiverVente()
        {
            buttonX3.Visible = false;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            dgv_fact.Enabled = false;

           
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            String ent = "", lent = "", numero = "", Nmvt = nfact.Text, typedition = ""; ;
            ent = "eentvc";
            lent = "lentvc";
            numero = "Avoir";
            typedition = "D";

            impression form = new impression(ent, lent, Nmvt, numero, typedition);
            form.ShowDialog();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_fact_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (dgv_fact.Columns[dgv_fact.CurrentCell.ColumnIndex].Name == "QTEAvr")
                {
                    Double xqte = 0, nqte = 0;
                    Double.TryParse(dgv_fact.Rows[e.RowIndex].Cells["a4"].Value + "", out xqte);
                    Double.TryParse(e.FormattedValue + "", out nqte);
                    if (xqte < nqte)
                    {
                        MessageBox.Show("Qte d'Avoir Superieur à la Qte du Facture");
                        e.Cancel = true;
                    }
                    else
                        Total();
                }
            }
            catch
            {
                e.Cancel = true; 
            }
        }

        private void dgv_fact_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_fact.Columns[dgv_fact.CurrentCell.ColumnIndex].Name == "QTEAvr")
            {
                Total();
            }
        }

        
     
    }
}
