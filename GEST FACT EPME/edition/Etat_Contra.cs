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
    public partial class Etat_Contra : DevComponents.DotNetBar.Office2007Form
    {
        MetierClient cli=null;
        Boolean change = false;
        Boolean modif = false;
        private metier met = Program.met;
        public Boolean newf = true;
        public Boolean Retenue = true;
       public String NumFact = "";
       Boolean selection = false;
       String IDContrat = "";
       List<string> LSTid = new List<string>();
       Boolean Fav = false, Fgar = false;
       string numav = "", numgar = "";
       public Etat_Contra()
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
                        load_contrat();
                        grd_contrat.Focus();
                    }
                    if (cli != null)
                    {
                        Tcodc.Text = cli.Codec;
                        Tnomc.Text = cli.NomC;
                        Retenue = cli.ExenorationClient;
                        grd_contrat.Focus();
                    }
                }
            }
        }

        private void Tnomc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                grd_contrat.Focus();
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
                        load_contrat();
                    }
                    if (cli != null)
                    {
                        Tcodc.Text = cli.Codec;
                        Tnomc.Text = cli.NomC;
                        Retenue = cli.ExenorationClient;
                        grd_contrat.Focus();
                    }
                }
            }
        }

        private void FFondation_Load(object sender, EventArgs e)
        {
            mygrid1.AllowUserToOrderColumns = true;
            mygrid1.AllowUserToOrderColumns = false;
        }

        private void nfact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                mygrid1.Focus();
            }
        }

        public void load_contrat()
        {
            grd_contrat.Rows.Clear();
            String sql = "SELECT * FROM Contrat Where CODEC = '"+cli.Codec+"' and fermer = false";
            DataSet dsc = met.recuperer_table(sql);
            if (dsc.Tables.Count != 0)
            {
                int i = 0;
                foreach (DataRow dr in dsc.Tables[0].Rows)
                {
                    grd_contrat.Rows.Add();
                    grd_contrat.Rows[i].Cells["CODE"].Value = dr["CODE"];
                    grd_contrat.Rows[i].Cells["IDC"].Value = dr["ID"];
                    grd_contrat.Rows[i].Cells["Fgarantie"].Value = dr["Fgarantie"];
                    grd_contrat.Rows[i].Cells["Favance"].Value = dr["Favance"];
                    grd_contrat.Rows[i].Cells["NUMFgarantie"].Value = dr["NUMFgarantie"];
                    grd_contrat.Rows[i].Cells["NUMFAvance"].Value = dr["NUMFAvance"];
                    grd_contrat.Rows[i].Cells["XTHT"].Value = dr["THT"];
                    grd_contrat.Rows[i].Cells["XTVA"].Value = dr["TVA"];
                    grd_contrat.Rows[i].Cells["XTTC"].Value = dr["TTC"];
                    grd_contrat.Rows[i].ReadOnly = true;
                    i++;
                }
            }
        }

        private void grd_contrat_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void grd_contrat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                if (grd_contrat.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) { grd_contrat.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true; }
                else {
                    Boolean val = (Boolean)grd_contrat.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    grd_contrat.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !val;
                }
                if (grd_contrat.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals(true))
                {
                    foreach (DataGridViewRow drv in grd_contrat.Rows)
                    {
                        if (drv.Index != e.RowIndex)
                        {
                            drv.Cells[0].Value = false;
                        }
                    }
                    IDContrat = grd_contrat.Rows[e.RowIndex].Cells["IDC"].Value + "";
                    isgar.Checked = (bool)grd_contrat.Rows[e.RowIndex].Cells["Fgarantie"].Value;
                    isav.Checked = (bool)grd_contrat.Rows[e.RowIndex].Cells["Favance"].Value;
                    load_contrat(IDContrat);
                    try
                    {
                        numav = grd_contrat.Rows[e.RowIndex].Cells["NUMFAvance"].Value + "";
                        numgar = grd_contrat.Rows[e.RowIndex].Cells["NUMFgarantie"].Value + "";
                        Fav = (Boolean)grd_contrat.Rows[e.RowIndex].Cells["Favance"].Value;
                        Fgar = (Boolean)grd_contrat.Rows[e.RowIndex].Cells["Fgarantie"].Value;
                    }
                    catch { }
                }
                else
                {
                    mygrid1.Rows.Clear();
                }
            }
        }

        private void load_contrat(String IDContrat)
        {
            #region Remplir datagrid
            mygrid1.Rows.Clear();
            string sqld = "SELECT * FROM lcontrat WHERE codes='" + Program.Societe + "' and IDCONTRAT = " + IDContrat;// and (poids is not null or pupoids is not null or vbeton is not null or portee is not null or porteemoy is not null or pumontage is not null or puderoulage is not null)
            sqld += " ORDER BY `ORDRE`";
            DataSet dscd = met.recuperer_table(sqld);
            if (dscd != null)
                if (dscd.Tables.Count != 0)
                {
                    int i = 0;

                    foreach (DataRow dr in dscd.Tables[0].Rows)
                    {
                        mygrid1.Rows.Add();
                        //mygrid1.Rows[i].Cells["x"].Value = false;
                        mygrid1.Rows[i].Cells["Npylon"].Value = dr["NPYLON"];
                        mygrid1.Rows[i].Cells["TypePylone"].Value = dr["TYPEPYLON"];
                        //mygrid1.Rows[i].Cells["TypeMassif"].Value = dr["TYPEMASSIF"];
                        //mygrid1.Rows[i].Cells["Poids"].Value = dr["POIDS"];
                        //mygrid1.Rows[i].Cells["PUP"].Value = dr["PUPoids"];
                        //mygrid1.Rows[i].Cells["VBP"].Value = dr["VBETON"];
                        //mygrid1.Rows[i].Cells["PUV"].Value = dr["PUBETON"];
                        //mygrid1.Rows[i].Cells["portee"].Value = dr["PORTEE"];
                        //mygrid1.Rows[i].Cells["PUHTDeroulage"].Value = dr["PUDEROULAGE"];
                        //mygrid1.Rows[i].Cells["porteemoy"].Value = dr["PORTEEMOY"];
                        //mygrid1.Rows[i].Cells["PUHTFondation"].Value = dr["PUFOND"];
                        //mygrid1.Rows[i].Cells["PUHTMontage"].Value = dr["PUMONTAGE"];
                        if (dr["poids"] != DBNull.Value || dr["porteemoy"] != DBNull.Value)
                        {
                            mygrid1.Rows[i].Cells["prorataf"].Value = dr["prorataf"];
                        }
                        else
                        {
                            mygrid1.Rows[i].Cells["prorataf"].Style.BackColor = Color.Gray;
                        }
                        if (dr["vbeton"] != DBNull.Value || dr["porteemoy"] != DBNull.Value)
                        {
                            mygrid1.Rows[i].Cells["proratam"].Value = dr["proratam"];
                        }
                        else
                        {
                            mygrid1.Rows[i].Cells["proratam"].Style.BackColor = Color.Gray;
                        }
                        mygrid1.Rows[i].Cells["proratad"].Value = dr["proratad"];
                        mygrid1.Rows[i].Cells["ID"].Value = dr["ID"];
                        mygrid1.Rows[i].Cells["ordre"].Value = dr["ordre"];

                        Boolean frst = true;
                        String numf = "";
                        String sql = "Select numf From lfondation Where codes='" + Program.Societe + "' and IDLC = " + dr["ID"];
                        DataSet ds = met.recuperer_table(sql);
                        try
                        {
                            numf = "";
                            foreach (DataRow ddr in ds.Tables[0].Rows)
                            {
                                if (!frst)
                                    numf += " + ";
                                frst = false;
                                numf += ddr[0] + "";
                            }
                        }
                        catch { numf = ""; }
                        mygrid1.Rows[i].Cells["FactureF"].Value = numf;

                        frst = true;
                        sql = "Select numf From lmontage Where codes='" + Program.Societe + "' and IDLC = " + dr["ID"];
                        ds = met.recuperer_table(sql);
                        try
                        {
                            numf = "";
                            foreach (DataRow ddr in ds.Tables[0].Rows)
                            {
                                if (!frst)
                                    numf += " + ";
                                frst = false;
                                numf += ddr[0] + "";
                            }
                        }
                        catch { numf = ""; }
                        mygrid1.Rows[i].Cells["FactureM"].Value = numf;

                        if ((decimal)dr["proratad"] !=0)
                        {
                            frst = true;
                            sql = "Select distinct numf From lderoulage Where codes='" + Program.Societe + "' and (IDLC = " + dr["ID"] + " OR IDLC1 = " + dr["ID"] + ") and qte<>0";
                            ds = met.recuperer_table(sql);
                            try
                            {
                                numf = "";
                                foreach (DataRow ddr in ds.Tables[0].Rows)
                                {
                                    if (!frst)
                                        numf += " + ";
                                    frst = false;
                                    numf += ddr[0] + "";
                                }
                            }
                            catch { numf = ""; }
                            mygrid1.Rows[i].Cells["FactureD"].Value = numf;
                        }
                        frst = true;
                        sql = "Select `PUHT`, `TVA`, `NUMF` From ldivers Where codes='" + Program.Societe + "' and IDLC = " + dr["ID"];
                        ds = met.recuperer_table(sql);
                        try
                        {
                            double wttc = 0;
                            numf = "";
                            foreach (DataRow ddr in ds.Tables[0].Rows)
                            {
                                if (!frst)
                                    numf += " + ";
                                frst = false;
                                double xtva = 0, xtht = 0, xttc = 0;
                                double.TryParse(ds.Tables[0].Rows[0]["TVA"] + "", out xtva);
                                double.TryParse(ds.Tables[0].Rows[0]["PUHT"] + "", out xtht);
                                xttc = xtht * (1 + xtva / 100);
                                wttc += xttc;
                                numf += ddr["NUMF"] + "";
                            }

                            mygrid1.Rows[i].Cells["Divers"].Value = wttc.ToString("N3");
                        }
                        catch { numf = ""; }
                        mygrid1.Rows[i].Cells["FactureDiv"].Value = numf;

                        double xp = 0;
                        double.TryParse(dr["prorataf"] + "", out xp);
                        if (xp >= 100 )
                        {
                            mygrid1.Rows[i].Cells["prorataf"].Style.BackColor = Color.Green;
                            mygrid1.Rows[i].Cells["prorataf"].Style.ForeColor = Color.White;
                        }
                        else if (xp > 0)
                        {
                            mygrid1.Rows[i].Cells["prorataf"].Style.BackColor = Color.Wheat;
                            mygrid1.Rows[i].Cells["prorataf"].Style.ForeColor = Color.Black;
                        }
                        else if( ( (dr["poids"] != DBNull.Value || dr["porteemoy"] != DBNull.Value)))
                        {
                            mygrid1.Rows[i].Cells["prorataf"].Style.BackColor = Color.Red;
                            mygrid1.Rows[i].Cells["prorataf"].Style.ForeColor = Color.White;
                        }
                        double.TryParse(dr["proratam"] + "", out xp);
                        if (xp >= 100)
                        {
                            mygrid1.Rows[i].Cells["proratam"].Style.BackColor = Color.Green;
                            mygrid1.Rows[i].Cells["proratam"].Style.ForeColor = Color.White;
                        }
                        else if (xp > 0)
                        {
                            mygrid1.Rows[i].Cells["proratam"].Style.BackColor = Color.Wheat;
                            mygrid1.Rows[i].Cells["proratam"].Style.ForeColor = Color.Black;
                        }
                        else if (((dr["vbeton"] != DBNull.Value || dr["porteemoy"] != DBNull.Value)))
                        {
                            mygrid1.Rows[i].Cells["proratam"].Style.BackColor = Color.Red;
                            mygrid1.Rows[i].Cells["proratam"].Style.ForeColor = Color.White;
                        }
                        double.TryParse(dr["proratad"] + "", out xp);
                        if (xp >= 100)
                        {
                            mygrid1.Rows[i].Cells["proratad"].Style.BackColor = Color.Green;
                            mygrid1.Rows[i].Cells["proratad"].Style.ForeColor = Color.White;
                        }
                        else if (xp > 0)
                        {
                            mygrid1.Rows[i].Cells["proratad"].Style.BackColor = Color.Wheat;
                            mygrid1.Rows[i].Cells["proratad"].Style.ForeColor = Color.Black;
                        }
                        else
                        {
                            mygrid1.Rows[i].Cells["proratad"].Style.BackColor = Color.Red;
                            mygrid1.Rows[i].Cells["proratad"].Style.ForeColor = Color.White;
                        }
                        i++;
                    }
                }
            #endregion

            String sqlt = "select sum(Timbre) as Timbre,sum(tht) as tht, sum(ravance) as rav,sum(rgarantie) as rgar,sum(netht) as net,sum(tva) as tva,sum(ttc) as ttc,sum(rs50) as r50,sum(rs15) as r15,sum(net) as nttc from facture where codes='" + Program.Societe + "' and contrat = " + IDContrat;
            DataSet dst = met.recuperer_table(sqlt);
            try {
                double xTimbre = 0, xtht = 0, xrgar = 0, xrav = 0, xnet = 0, xtva = 0, xttc = 0, xr50 = 0, xr15 = 0, xnttc = 0;
                Double.TryParse(dst.Tables[0].Rows[0]["tht"] + "", out xtht);
                Double.TryParse(dst.Tables[0].Rows[0]["rgar"] + "", out xrgar);
                Double.TryParse(dst.Tables[0].Rows[0]["rav"] + "", out xrav);
                Double.TryParse(dst.Tables[0].Rows[0]["net"] + "", out xnet);
                Double.TryParse(dst.Tables[0].Rows[0]["tva"] + "", out xtva);
                Double.TryParse(dst.Tables[0].Rows[0]["ttc"] + "", out xttc);
                Double.TryParse(dst.Tables[0].Rows[0]["r50"] + "", out xr50);
                Double.TryParse(dst.Tables[0].Rows[0]["r15"] + "", out xr15);
                Double.TryParse(dst.Tables[0].Rows[0]["nttc"] + "", out xnttc);
                Double.TryParse(dst.Tables[0].Rows[0]["Timbre"] + "", out xTimbre);

                if (isgar.Checked)
                    xtht -= xrgar;
                if (isav.Checked)
                    xtht -= xrav;
                Ttht.Text = xtht.ToString("N3");
                Trgar.Text = xrgar.ToString("N3");
                Trav.Text = xrav.ToString("N3");
                Tnet.Text = xnet.ToString("N3");
                Ttva.Text = xtva.ToString("N3");
                Tttc.Text = xttc.ToString("N3");
                Tr50.Text = xr50.ToString("N3");
                Tr15.Text = xr15.ToString("N3");
                Tnttc.Text = xnttc.ToString("N3");
                textBoxX1.Text = xTimbre.ToString("N3");
            }

            catch { }
        }

        private void FContart_Shown(object sender, EventArgs e)
        {
            
        }

    }
}
