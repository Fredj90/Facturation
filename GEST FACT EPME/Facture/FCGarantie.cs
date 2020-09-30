using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EPME.Facture
{
    public partial class FCGarantie : DevComponents.DotNetBar.Office2007Form
    {
       public MetierClient cli=null;
        Boolean change = false;
        Boolean modif = false;
        private metier met = Program.met;
        public Boolean newf = true;
        public Boolean Retenue;
        public String NumFact = "";
        public String typecalc = "";
        public string IDContrat = "";
        public FCGarantie()
        {
            InitializeComponent();
        }

        private void Tcodc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                Tnomc.Focus();
        }

        private void Tcodc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                if (Tcodc.Text != "")
                {
                    rechcli rcli = new rechcli("client", Tcodc.Text, null);
                    rcli.ShowDialog();
                    if (rcli.valider)
                    {
                        cli = new MetierClient(rcli.code);
                        change = true;
                        mygrid1.Enabled = true;
                        mygrid1.Focus();
                    }
                    if (cli != null)
                    {
                        Tcodc.Text = cli.Codec;
                        Tnomc.Text = cli.NomC;
                        Tadrc.Text = cli.adrc;
                        Retenue = cli.ExenorationClient;
                        mygrid1.Focus();
                    }
                }
            }
        }

        private void Tnomc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                mygrid1.Focus();
            }
        }

        private void Tnomc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                if (Tnomc.Text != "")
                {
                    rechcli rcli = new rechcli("client", null, Tnomc.Text);
                    rcli.ShowDialog();
                    if (rcli.valider)
                    {
                        cli = new MetierClient(rcli.code);
                        change = true;
                        mygrid1.Enabled = true;
                    }
                    if (cli != null)
                    {
                        Tcodc.Text = cli.Codec;
                        Tnomc.Text = cli.NomC;
                        Tadrc.Text = cli.adrc;
                        Retenue = cli.ExenorationClient;
                        mygrid1.Focus();
                    }
                }
            }
        }

        private void nfact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                datefact.Focus();
        }

        private void datefact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                    tref.Focus();
            }
            
        }

        private void mygrid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
            {
                //double  qte = 0, puht = 0, tva=18,tht=0,ttc=0;
                //double.TryParse(mygrid1.Rows[e.RowIndex].Cells["VBP"].Value + "", out qte);
                //double.TryParse(mygrid1.Rows[e.RowIndex].Cells["PUHTF"].Value + "", out puht);
                //double.TryParse(mygrid1.Rows[e.RowIndex].Cells["TVAFF"].Value + "", out tva);
                //if (mygrid1.Rows[e.RowIndex].Cells["TVAFF"].Value == null)
                //    tva = 18;
                //tht = qte * puht;
                //ttc = tht * (1 + (tva / 100));
                //mygrid1.Rows[e.RowIndex].Cells["VBP"].Value = qte.ToString("N5");
                //mygrid1.Rows[e.RowIndex].Cells["PUHTF"].Value = puht.ToString("N3");
                //mygrid1.Rows[e.RowIndex].Cells["PTHT"].Value = tht.ToString("N3");
                //mygrid1.Rows[e.RowIndex].Cells["TVAFF"].Value = tva.ToString("N2");
                //mygrid1.Rows[e.RowIndex].Cells["TTCF"].Value = ttc.ToString("N3");
                //calcultotal();
            }
        }


        private void buttonX4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string test_sauve()
        {
            String error = "";
            if (cli == null)
            {
                Tcodc.Focus();
                error = "saisir Code Client";
            }
            if (mygrid1.Rows.Count == 0)
            {
                mygrid1.Focus();
                error = "Verifier Ligne Facture";
            }
            if (datefact.Text.Equals(""))
            {
                datefact.Focus();
                error = "saisir Date Facture";
            }
            foreach (DataGridViewRow dr in mygrid1.Rows)
            {
                if (!dr.IsNewRow)
                {
                    if ((dr.Cells["Npylon"].Value+"").Equals("") || dr.Cells["Npylon"].Value.Equals(null))
                    {
                        mygrid1.CurrentCell = dr.Cells["Npylon"];
                        mygrid1.Focus();
                        error = "Verifier Ligne Facture";
                        break;
                    }
                    
                    
                    if ((dr.Cells["VBP"].Value+"").Equals("") || dr.Cells["VBP"].Value.Equals(null))
                    {
                        mygrid1.CurrentCell = dr.Cells["VBP"];
                        mygrid1.Focus();
                        error = "Verifier Ligne Facture";
                        break;
                    }
                    if ((dr.Cells["U"].Value+"").Equals("") || dr.Cells["U"].Value.Equals(null))
                    {
                        mygrid1.CurrentCell = dr.Cells["U"];
                        mygrid1.Focus();
                        error = "Verifier Ligne Facture";
                        break;
                    }
                    if ((dr.Cells["PUHTF"].Value+"").Equals("") || dr.Cells["PUHTF"].Value.Equals(null))
                    {
                        mygrid1.CurrentCell = dr.Cells["PUHTF"];
                        mygrid1.Focus();
                        error = "Verifier Ligne Facture";
                        break;
                    }
                }
            }
            return error;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (cli != null)
            {
                if (!modif)
                {
                    string err = test_sauve();
                    if (err.Equals(""))
                    {
                        SaveIncrementationNumero();
                        String dat = datefact.Value.ToString("yyyy-MM-dd");
                        string sql = "INSERT INTO Facture (NUMF,REF,NREF,VREF,CODEC, NOMC,ADRC,DATEF, CODES,CODEE, THT,NETHT, TVA,TIMBRE,TTC,RS50,RS15,NET,MODEP,type,VGARANTIE,VAVANCE,prorata,Contrat) VALUE ("
                            + "'" + met.CString(nfact.Text) + "',"
                            + "'" + met.CString(tref.Text) + "',"
                            + "'" + met.CString(tnref.Text) + "',"
                            + "'" + met.CString(tvref.Text )+ "',"
                            + "'" + Tcodc.Text + "',"
                            + "'" + Tnomc.Text + "',"
                            + "'" + met.CString(Tadrc.Text) + "',"
                            + "'" + dat + "',"
                            + "'" + Program.Societe + "',"
                            + "'" + Program.Exercice + "',"
                            + "'" + tbrut.Text.Replace(Program.sep, string.Empty) + "',"
                            + "'" + tbrut.Text.Replace(Program.sep, string.Empty) + "',"
                            + "'" + Ttva.Text.Replace(Program.sep, string.Empty) + "',"
                            + "'" + Ttimbre.Text.Replace(Program.sep, string.Empty) + "',"
                            + "'" + Tttc.Text.Replace(Program.sep, string.Empty) + "',"
                            + "'" + rs50.Text.Replace(Program.sep, string.Empty) + "',"
                            + "'" + rs15.Text.Replace(Program.sep, string.Empty) + "',"
                            + "'" + net.Text.Replace(Program.sep, string.Empty) + "',"
                            + "'" + Modep.SelectedValue + "',"
                            + "'GR',"
                            + "'" + Tpret.Text.Replace(Program.sep, string.Empty) + "',"
                            + "'" + tpav.Text.Replace(Program.sep, string.Empty) + "',"
                            + "'" + tprorata.Text.Replace(Program.sep, string.Empty) + "',"
                            + "" + IDContrat + ""
                            + ")";

                        met.Execute(sql);

                        sql = "UPDATE contrat set Fgarantie = true, NUMFgarantie='" + met.CString(nfact.Text) + "' WHERE ID = " + IDContrat;
                        met.Execute(sql);
                        //Montage
                        String sqlF = "insert INTO ltravaux (DESIGNATION,QTE,U,PUHT,taux,PTHT,TVA,CODES,CODEE,NUMF) values";
                        Boolean frst = true;
                        foreach (DataGridViewRow dr in mygrid1.Rows)
                        {
                            if (!dr.IsNewRow)
                            {
                                if (!frst)
                                {
                                    sqlF += ",(";
                                }
                                else
                                {
                                    sqlF += "(";
                                }
                                sqlF += "'" + met.CString( dr.Cells["Npylon"].Value)+ "'"
                                    + ",'" + (dr.Cells["VBP"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                    + ",'" + met.CString(dr.Cells["U"].Value) + "'"
                                    + ",'" + (dr.Cells["PUHTF"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                    + ",'" + (dr.Cells["Taux"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                    + ",'" + (dr.Cells["PTHT"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                    + ",'" + (dr.Cells["TVAFF"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                    + ",'" + Program.Societe + "'"
                                    + ",'" + Program.Exercice + "'"
                                    + ",'" + nfact.Text + "')";
                                frst = false;
                            }
                        }
                        if (!frst)
                        {
                            met.Execute(sqlF);
                        }
                        MessageBox.Show("Sauvgard avec sucée.");
                        buttonX2.Visible = false;
                        buttonX3.Visible = true ;
                    }
                    else
                        MessageBox.Show(err);
                }
                else
                {
                    string err = test_sauve();
                    if (err.Equals(""))
                    {
                        String dat = datefact.Value.ToString("yyyy-MM-dd");
                        string sql = "UPDATE Facture SET REF='" +met.CString( tref.Text)
                            + "',NREF='" + met.CString(tnref.Text)
                            + "',VREF='" + met.CString(tvref.Text)
                            + "',CODEC='" + met.CString(Tcodc.Text)
                            + "', NOMC='" + met.CString(Tnomc.Text)
                            + "',ADRC='" + met.CString(Tadrc.Text)
                            + "',DATEF='" + dat
                            + "', CODES='" + Program.Societe
                            + "', CODEE='" + Program.Exercice
                            + "', THT='" + Ttht.Text.Replace(Program.sep, string.Empty)
                            + "',RAVANCE='" + Tav.Text.Replace(Program.sep, string.Empty)
                            + "',RGARANTIE='" + Tret.Text.Replace(Program.sep, string.Empty)
                            + "',NETHT='" + Tnetht.Text.Replace(Program.sep, string.Empty)
                            + "', TVA='" + Ttva.Text.Replace(Program.sep, string.Empty)
                            + "',TIMBRE='" + Ttimbre.Text.Replace(Program.sep, string.Empty)
                            + "',TTC='" + Tttc.Text.Replace(Program.sep, string.Empty)
                            + "'RS50='" + rs50.Text.Replace(Program.sep, string.Empty) + "',"
                            + "'RS15='" + rs15.Text.Replace(Program.sep, string.Empty) + "',"
                            + "'NET='" + net.Text.Replace(Program.sep, string.Empty) + "',"
                            + "',MODEP='" + Modep.SelectedValue
                            + "',type='T',VGARANTIE='" + Tpret.Text.Replace(Program.sep, string.Empty)
                            + "',VAVANCE='" + tpav.Text.Replace(Program.sep, string.Empty)
                            + "',prorata='" + tprorata.Text.Replace(Program.sep, string.Empty)
                            + "'WHERE codes='" + Program.Societe
                            + "' and numf = '" + NumFact + "'";

                        met.Execute(sql);

                        //Fondation
                        met.Execute("DELETE  FROM ltravaux WHERE codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and numf='" + NumFact + "'");
                        String sqlF = "INSERT INTO ltravaux (DESIGNATION,QTE,U,PUHT,PTHT,TVA,CODES,CODEE,NUMF) values";
                        Boolean frst = true;
                        foreach (DataGridViewRow dr in mygrid1.Rows)
                        {
                            if (!dr.IsNewRow)
                            {
                                if (!frst)
                                {
                                    sqlF += ",(";
                                }
                                else
                                {
                                    sqlF += "(";
                                }
                                sqlF += "'" + met.CString(dr.Cells["Npylon"].Value) + "'"
                                    + ",'" + (dr.Cells["VBP"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                    + ",'" + met.CString(dr.Cells["U"].Value) + "'"
                                    + ",'" + (dr.Cells["PUHTF"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                    + ",'" + (dr.Cells["PTHT"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                    + ",'" + (dr.Cells["TVAFF"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                    + ",'" + Program.Societe + "'"
                                    + ",'" + Program.Exercice + "'"
                                    + ",'" + nfact.Text + "')";
                                frst = false;
                            }
                        }
                        if (!frst)
                        {
                            met.Execute(sqlF);
                        }
                        MessageBox.Show("Sauvgard avec sucée.");
                        buttonX2.Visible = false;
                        buttonX3.Visible = true;
                    }
                    else
                        MessageBox.Show(err);
                }
            }
            else
                MessageBox.Show("Verifier Le Code Client.");
        }

        private void calcultotal()
        {
            double THT = 0, NETTHT = 0, TVA = 0, TTC = 0, Timbre = 0,  brut = 0, trs50 = 0, trs15 = 0, tnet = 0;
            double.TryParse(Ttimbre.Text, out Timbre);
            double.TryParse(tbrut.Text, out brut);

            TVA = brut * 0.18;
            Ttva.Text = TVA.ToString("N3");
            double.TryParse(Ttva.Text, out TVA);
            TTC = brut + TVA;
            Tttc.Text = TTC.ToString("N3");

            if (Retenue)
            {
                trs50 = TVA * 50 / 100;
                trs15 = TTC * 1.5 / 100;
                rs50.Text = trs50.ToString("N3");
                rs15.Text = trs15.ToString("N3");
            }
            else
            {
                rs50.Text = 0.ToString("N3");
                rs15.Text = 0.ToString("N3");
            }



            tnet = TTC + Timbre - trs50 - trs15;
            net.Text = tnet.ToString("N3");

            Ttht.Text = THT.ToString("N3");
            tbrut.Text = brut.ToString("N3");
        }

        private void textBoxX18_TextChanged(object sender, EventArgs e)
        {
            calcultotal();
        }

        private void FFondation_Load(object sender, EventArgs e)
        {
            String sqlmp = "Select * From modalite where codes='"+Program.Societe+"'";
           DataSet dsm= met.recuperer_table(sqlmp,"modalite");
           BindingSource bs = new BindingSource(dsm, "modalite");
           Modep.DisplayMember = "libelle";
           Modep.ValueMember = "Code";
           Modep.DataSource = bs;

           rbnht.Checked = true;
           rbht.Checked = false;

           if (newf)
           {
               increment();
               nfact.Text = NumFact;
           }
        }

        private void increment()
        {
            String req = "SELECT * FROM pnumste where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
            DataSet ds = met.recuperer_table(req, "pnumste");
            int index = 0;
            if (ds != null)
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        index = ds.Tables[0].Rows.Count - 1;

                    }
                }
            string s1 = ds.Tables[0].Rows[index].Field<Object>("dfacture") + "";
            string s2 = ds.Tables[0].Rows[index].Field<Object>("facture") + "";
            int num = int.Parse(s2);
            num++;
            string s = num.ToString().Trim();
            int l1 = s2.Trim().Length;
            int l2 = s.Length;
            for (int i = l2; i < l1; i++)
                s = "0" + s;
            s = s1 + s;
            NumFact = s;
        }

        public  void SaveIncrementationNumero()
        {
            String req = "SELECT * FROM pnumste where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
            DataSet dsi = met.recuperer_table(req, "pnumste");
            string s2 = dsi.Tables[0].Rows[0].Field<Object>("facture") + "";
            String snum = NumFact.Substring(2, NumFact.Length - 2);
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
                string sqlinc = "UPDATE pnumste SET facture = '" + s + "' where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
                met.Execute(sqlinc);
            }
            else {
                increment();
                SaveIncrementationNumero();
                nfact.Text = NumFact;
            }
        }

        private void tref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                tnref.Focus();
            }
        }

        private void tnref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                tvref.Focus();
            }
        }

        private void tvref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                Tcodc.Focus();
            }
        }

        private void tprorata_TextChanged(object sender, EventArgs e)
        {
            calcultotal();
        }

        private void Tpret_TextChanged(object sender, EventArgs e)
        {
            calcultotal();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            rpt.frm_TRAVAUXGR ff = new rpt.frm_TRAVAUXGR();
            ff.numf = nfact.Text + "";
            ff.ShowDialog();
        }

        private void tprorata_Validated(object sender, EventArgs e)
        {
            double t1 = 0;
            double.TryParse(tprorata.Text, out t1);
            tprorata.Text = t1.ToString("N2");
        }

        private void Tpret_Validated(object sender, EventArgs e)
        {
            double t1 = 0;
            double.TryParse(Tpret.Text, out t1);
            Tpret.Text = t1.ToString("N2");
        }

        private void tpav_Validated(object sender, EventArgs e)
        {
            double t1 = 0;
            double.TryParse(tpav.Text, out t1);
            tpav.Text = t1.ToString("N2");
        }

        private void rbnht_CheckedChanged(object sender, EventArgs e)
        {
            typecalc = "NHT";
            calcultotal();
        }

        private void rbht_CheckedChanged(object sender, EventArgs e)
        {
            typecalc = "HT";
            calcultotal();
        }

        private void FCAvance_Shown(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM contrat WHERE ID = " + IDContrat;
            DataSet ds = met.recuperer_table(sql);
            try
            {


                DataRow dr = ds.Tables[0].Rows[0];

                Tcodc.Text = dr["CODEC"] + "";
                cli = new MetierClient(Tcodc.Text);
                Tnomc.Text = dr["NOMC"] + "";
                Tadrc.Text = dr["ADRC"] + "";

                sql = "select sum(rgarantie) as gr,sum(tht) as THT from facture where codes ='" + Program.Societe + "' and contrat=" + IDContrat + " and `type`<> 'AV'";
                DataSet dssum = met.recuperer_table(sql);
                DataRow drsum = dssum.Tables[0].Rows[0];
                double xtht = 0, xtva = 0, xttc = 0, xav = 0;
                double.TryParse(drsum["THT"] + "", out xtht);
                double.TryParse(dr["TVA"] + "", out xtva);
                double.TryParse(dr["TTC"] + "", out xttc);
                double.TryParse(dr["VGAR"] + "", out xav);
                double ntht = 0, ntva = 0, nttc = 0, nav = 0;


                //double.TryParse(drsum["gr"] + "", out ntht);
                ntht = xtht * xav / 100;
                String th = ntht.ToString("N3");
                double.TryParse(th, out ntht);
                ntva = ntht * 0.18;
                th = ntva.ToString("N3");
                double.TryParse(th, out ntva);
                nttc = ntht + ntva;
                tbrut.Text = ntht.ToString("N3");
                calcultotal();
                mygrid1.Rows.Add();
                {
                    DataGridViewRow drr = mygrid1.Rows[0];
                    drr.Height = 120;
                    drr.Cells["Npylon"].Style.WrapMode = DataGridViewTriState.True;
                    drr.Cells["Npylon"].Value = "Libération de la retenue de garantie de " + xav .ToString("N2")+ " sur le Traveaux du Marchéde sous traitance EPME/" + Tnomc.Text + " du " + ((DateTime)dr["DATEDEBUT"]).ToString("dd/MM/yyyy") + "";
                    drr.Cells["PUHTF"].Value = xtht.ToString("N3");
                    drr.Cells["Taux"].Value = xav.ToString("N2");
                    drr.Cells["PTHT"].Value = ntht.ToString("N3");
                    drr.Cells["TVAFF"].Value = ntva.ToString("N3");
                    drr.Cells["TTCF"].Value = nttc.ToString("N3");
                    drr.Cells["VBP"].Value = "1";
                    drr.Cells["U"].Value = "U";
                }

            }
            catch { }
        }

        private void tbrut_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
