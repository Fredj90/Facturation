using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EPME.contact
{
    public partial class MAJContractD : DevComponents.DotNetBar.Office2007Form
    {
        MetierClient cli=null;
        Boolean change = false;
        public Boolean modif = false;
        private metier met = Program.met;
        public String IDContrat = "";
        List<string> Lsupp = new List<string>();
        Boolean act=false;
        public MAJContractD()
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
                        Tht.Focus();
                    }
                    if (cli != null)
                    {
                        Tcodc.Text = cli.Codec;
                        Tnomc.Text = cli.NomC;
                        Tadrc.Text = cli.adrc;
                    }
                }
            }
        }

        private void Tnomc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                Tgar.Focus();
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
                        Tht.Enabled = true;
                    }
                    if (cli != null)
                    {
                        Tcodc.Text = cli.Codec;
                        Tnomc.Text = cli.NomC;
                        Tadrc.Text = cli.adrc;
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
                    Tcodc.Focus();
            }
            
        }

        private void mygrid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 2 && e.RowIndex!=-1)
            {
                if (mygrid1[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    if (!(mygrid1[e.ColumnIndex, e.RowIndex].Value+"").Equals(""))
                    {
                        Double d = 0;
                        try
                        {
                            Double.TryParse(mygrid1[e.ColumnIndex, e.RowIndex].Value + "", out d);
                            mygrid1[e.ColumnIndex, e.RowIndex].Value = d.ToString(mygrid1.Columns[e.ColumnIndex].DefaultCellStyle.Format);
                        }
                        catch
                        {
                            mygrid1[e.ColumnIndex, e.RowIndex].Value = d.ToString(mygrid1.Columns[e.ColumnIndex].DefaultCellStyle.Format);
                        }
                    }
                }
            }
            calcultotal();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (cli != null)
            {
                if (!modif)
                {
                    Double xtht = 0, xtva = 0, xttc=0, xav=0, xgar = 0;
                    Double.TryParse(Tht.Text, out xtht);
                    Double.TryParse(Ttva.Text, out xtva);
                    Double.TryParse(Tttc.Text, out xttc);
                    Double.TryParse(Tavnc.Text, out xav);
                    Double.TryParse(Tgar.Text, out xgar);
                    String dat = datefact.Value.ToString("yyyy-MM-dd");
                    string sql = "INSERT INTO contrat (CODE,CODEC, NOMC,ADRC,DATEDEBUT, THT, TVA,TTC,VGAR,VAVANC, CODES) VALUE ("//, AVANCE,solde,reste
                        + "'" + nfact.Text + "',"
                        + "'" + Tcodc.Text + "',"
                        + "'" + Tnomc.Text + "',"
                        + "'" + Tadrc.Text + "',"
                        + "'" + dat + "',"
                        + "'" + xtht.ToString().Replace(Program.sep, string.Empty) + "',"
                        + "'" + xtva.ToString().Replace(Program.sep, string.Empty) + "',"
                        + "'" + xttc.ToString().Replace(Program.sep, string.Empty) + "',"
                        + "'" + xgar.ToString().Replace(Program.sep, string.Empty) + "',"
                        + "'" + xav.ToString().Replace(Program.sep, string.Empty) + "',"
                        + "'" + Program.Societe + "'"
                        + ")";
                    String sqlID = "Select Max(ID) FROM contrat";
                    met.Execute(sql);
                    DataSet dsID = met.recuperer_table(sqlID);
                    String ID = string.Empty;
                    try
                    {
                        ID = dsID.Tables[0].Rows[0].ItemArray[0] + "";
                    }
                    catch { }
                    //Pylones
                    String sqlF = "INSERT INTO lcontrat (NPYLON,TYPEPYLON,TYPEMASSIF,ORDRE,PORTEE,PORTEEMOY,PUFOND,PUMONTAGE,PUDEROULAGE,POIDS,PUPoids,VBETON,PUBETON,CODES,IDCONTRAT) values";
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
                            String xport = "Null", xportmoy = "Null", xpuf = "Null", xpum = "Null", xpud = "Null", xpoid = "Null", xpup = "Null", xvbp = "Null", xpuv = "Null";
                            if (dr.Cells["portee"].Value != null)
                            {
                                if (!(dr.Cells["portee"].Value + "").Equals(""))
                                {
                                    Double d1 = 0;
                                    Double.TryParse(dr.Cells["portee"].Value + "", out d1);
                                    xport = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                                }
                            }
                            if (dr.Cells["porteemoy"].Value != null)
                            {
                                if (!(dr.Cells["porteemoy"].Value+"").Equals(""))
                                {
                                    Double d1 = 0;
                                    Double.TryParse(dr.Cells["porteemoy"].Value + "", out d1);
                                    xportmoy = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                                }
                            }
                            if (dr.Cells["PUHTFondation"].Value != null)
                            {
                                if (!(dr.Cells["PUHTFondation"].Value + "").Equals(""))
                                {
                                    Double d1 = 0;
                                    Double.TryParse(dr.Cells["PUHTFondation"].Value + "", out d1);
                                    xpuf = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                                }
                            }
                            if (dr.Cells["PUHTMontage"].Value != null)
                            {
                                if (!(dr.Cells["PUHTMontage"].Value + "").Equals(""))
                                {
                                    Double d1 = 0;
                                    Double.TryParse(dr.Cells["PUHTMontage"].Value + "", out d1);
                                    xpum = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                                }
                            }
                            if (dr.Cells["PUHTDeroulage"].Value != null)
                            {
                                if (!(dr.Cells["PUHTDeroulage"].Value + "").Equals(""))
                                {
                                    Double d1 = 0;
                                    Double.TryParse(dr.Cells["PUHTDeroulage"].Value + "", out d1);
                                    xpud = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                                }
                            }
                            if (dr.Cells["Poids"].Value != null)
                            {
                                if (!(dr.Cells["Poids"].Value + "").Equals(""))
                                {
                                    Double d1 = 0;
                                    Double.TryParse(dr.Cells["Poids"].Value + "", out d1);
                                    xpoid = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                                }
                            }
                            if (dr.Cells["PUP"].Value != null)
                            {
                                if (!(dr.Cells["PUP"].Value + "").Equals(""))
                                {
                                    Double d1 = 0;
                                    Double.TryParse(dr.Cells["PUP"].Value + "", out d1);
                                    xpup = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                                }
                            }
                            if (dr.Cells["VBP"].Value != null)
                            {
                                if (!(dr.Cells["VBP"].Value + "").Equals(""))
                                {
                                    Double d1 = 0;
                                    Double.TryParse(dr.Cells["VBP"].Value + "", out d1);
                                    xvbp = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                                }
                            }
                            if (dr.Cells["PUV"].Value != null)
                            {
                                if (!(dr.Cells["PUV"].Value + "").Equals(""))
                                {
                                    Double d1 = 0;
                                    Double.TryParse(dr.Cells["PUV"].Value + "", out d1);
                                    xpuv = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                                }
                            }
                            sqlF += "'" + dr.Cells["Npylon"].Value + "'"
                                + ",'" + dr.Cells["TypePylone"].Value + "'"
                                + ",'" + dr.Cells["TypeMassif"].Value + "'"
                                 + ",'" + (dr.Index+1) + "'"
                                + "," + xport + ""
                                + "," + xportmoy + ""
                                + "," + xpuf + ""
                                + "," + xpum + ""
                                + "," + xpud + ""
                                + "," + xpoid + ""
                                + "," + xpup + ""
                                + "," + xvbp + ""
                                + "," + xpuv + ""
                                + ",'" + Program.Societe + "'"
                                + "," + ID + ")";
                            frst = false;
                        }
                    }
                    if (!frst)
                    {
                        met.Execute(sqlF);
                    }
                    MessageBox.Show("Enregistrement avec sucée.");
                }
                else
                {
                    Double xtht = 0, xtva = 0, xttc = 0, xav = 0, xgar = 0;
                    Double.TryParse(Tht.Text, out xtht);
                    Double.TryParse(Ttva.Text, out xtva);
                    Double.TryParse(Tttc.Text, out xttc);
                    Double.TryParse(Tavnc.Text, out xav);
                    Double.TryParse(Tgar.Text, out xgar);
                    String dat = datefact.Value.ToString("yyyy-MM-dd");
                    string sql = "UPDATE  contrat SET " // (,, ,,, , THT, TVA,TTC, AVANCE,solde,reste) VALUE ("
                        + "CODE='" + nfact.Text + "',"
                        + "CODEC='" + Tcodc.Text + "',"
                        + "NOMC='" + Tnomc.Text + "',"
                        + "ADRC='" + Tadrc.Text + "',"
                        + "THT='" + xtht.ToString().Replace(Program.sep, string.Empty) + "',"
                        + "TVA='" + xtva.ToString().Replace(Program.sep, string.Empty) + "',"
                        + "TTC='" + xttc.ToString().Replace(Program.sep, string.Empty) + "',"
                        + "VAVANC='" + xav.ToString().Replace(Program.sep, string.Empty) + "',"
                        + "VGAR='" + xgar.ToString().Replace(Program.sep, string.Empty) + "',"
                        + "DATEDEBUT='" + dat + "',"
                        + "CODES='" + Program.Societe + "'"
                        + "WHERE ID = "+IDContrat;
                    
                    met.Execute(sql);
                    String ID = IDContrat;
                   
                    //Pylones
                    foreach (string IDSUP in Lsupp)
                    {
                        String sqldel = "DELETE FROM lcontrat WHERE ID = "+IDSUP ;
                        met.Execute(sqldel);
                    }
                    String sqlF = "INSERT INTO lcontrat (NPYLON,TYPEPYLON,TYPEMASSIF,ORDRE,PORTEE,PORTEEMOY,PUFOND,PUMONTAGE,PUDEROULAGE,POIDS,PUPoids,VBETON,PUBETON,CODES,IDCONTRAT) values";
                    Boolean frst = true;
                    foreach (DataGridViewRow dr in mygrid1.Rows)
                    {
                        String xport = "Null", xportmoy = "Null", xpuf = "Null", xpum = "Null", xpud = "Null", xpoid = "Null", xpup = "Null", xvbp = "Null", xpuv = "Null";
                        if (dr.Cells["portee"].Value != null)
                        {
                            if (!(dr.Cells["portee"].Value + "").Equals(""))
                            {
                                Double d1 = 0;
                                Double.TryParse(dr.Cells["portee"].Value + "", out d1);
                                xport = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                            }
                        }
                        if (dr.Cells["porteemoy"].Value != null)
                        {
                            if (!(dr.Cells["porteemoy"].Value + "").Equals(""))
                            {
                                Double d1 = 0;
                                Double.TryParse(dr.Cells["porteemoy"].Value + "", out d1);
                                xportmoy = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                            }
                        }
                        if (dr.Cells["PUHTFondation"].Value != null)
                        {
                            if (!(dr.Cells["PUHTFondation"].Value + "").Equals(""))
                            {
                                Double d1 = 0;
                                Double.TryParse(dr.Cells["PUHTFondation"].Value + "", out d1);
                                xpuf = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                            }
                        }
                        if (dr.Cells["PUHTMontage"].Value != null)
                        {
                            if (!(dr.Cells["PUHTMontage"].Value + "").Equals(""))
                            {
                                Double d1 = 0;
                                Double.TryParse(dr.Cells["PUHTMontage"].Value + "", out d1);
                                xpum = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                            }
                        }
                        if (dr.Cells["PUHTDeroulage"].Value != null)
                        {
                            if (!(dr.Cells["PUHTDeroulage"].Value + "").Equals(""))
                            {
                                Double d1 = 0;
                                Double.TryParse(dr.Cells["PUHTDeroulage"].Value + "", out d1);
                                xpud = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                            }
                        }
                        if (dr.Cells["Poids"].Value != null)
                        {
                            if (!(dr.Cells["Poids"].Value + "").Equals(""))
                            {
                                Double d1 = 0;
                                Double.TryParse(dr.Cells["Poids"].Value + "", out d1);
                                xpoid = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                            }
                        }
                        if (dr.Cells["PUP"].Value != null)
                        {
                            if (!(dr.Cells["PUP"].Value + "").Equals(""))
                            {
                                Double d1 = 0;
                                Double.TryParse(dr.Cells["PUP"].Value + "", out d1);
                                xpup = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                            }
                        }
                        if (dr.Cells["VBP"].Value != null)
                        {
                            if (!(dr.Cells["VBP"].Value + "").Equals(""))
                            {
                                Double d1 = 0;
                                Double.TryParse(dr.Cells["VBP"].Value + "", out d1);
                                xvbp = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                            }
                        }
                        if (dr.Cells["PUV"].Value != null)
                        {
                            if (!(dr.Cells["PUV"].Value + "").Equals(""))
                            {
                                Double d1 = 0;
                                Double.TryParse(dr.Cells["PUV"].Value + "", out d1);
                                xpuv = "'" + d1.ToString().Replace(Program.sep, string.Empty) + "'";
                            }
                        }
                        if (dr.Cells["ID"].Value == null)
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
                                
                                sqlF += "'" + dr.Cells["Npylon"].Value + "'"
                                    + ",'" + dr.Cells["TypePylone"].Value + "'"
                                    + ",'" + dr.Cells["TypeMassif"].Value + "'"
                                     + ",'" + (dr.Index + 1) + "'"
                                    + "," + xport + ""
                                    + "," + xportmoy + ""
                                    + "," + xpuf + ""
                                    + "," + xpum + ""
                                    + "," + xpud + ""
                                    + "," + xpoid + ""
                                    + "," + xpup + ""
                                    + "," + xvbp + ""
                                    + "," + xpuv + ""
                                    + ",'" + Program.Societe + "'"
                                    + "," + ID + ")";
                                frst = false;
                            }
                        }
                        else 
                        {
                            String sqlu = "UPDATE lcontrat SET"
                           + " NPYLON='" + dr.Cells["Npylon"].Value + "'"
                                    + ",ORDRE='" + (dr.Index+1) + "'"
                                    + ",TYPEPYLON='" + dr.Cells["TypePylone"].Value + "'"
                                    + ",TYPEMASSIF='" + dr.Cells["TypeMassif"].Value + "'"
                                    + ", PORTEE=" + xport + ""
                                    + ", PORTEEMOY=" + xportmoy + ""
                                    + ",PUFOND=" + xpuf + ""
                                    + ",PUMONTAGE=" + xpum + ""
                                    + ",PUDEROULAGE=" + xpud + ""
                                    + ",POIDS=" + xpoid + ""
                                    + ",PUPoids=" + xpup + ""
                                    + ",VBETON=" + xvbp + ""
                                    + ",PUBETON=" + xpuv + ""
                                    + "  WHERE ID = " + dr.Cells["ID"].Value;
                            met.Execute(sqlu);
                        }
                    }
                    if (!frst)
                    {
                        met.Execute(sqlF);
                    }
                    MessageBox.Show("Enregistrement avec sucée.");
                }
            }
            else
                MessageBox.Show("Verifier Le Code Client.");
        }

        private void calcultotal()
        {
            if (act)
            {
                double TDeroulage = 0, TotalFond_dist = 0, TotalMont_dist = 0, TotalFond = 0, TotalMont = 0;
                foreach (DataGridViewRow dr in mygrid1.Rows)
                {

                    double xport = 0, xpud = 0, xportmoy = 0, xpumd = 0, xpufd = 0, xpoid, xpum = 0, xvoul, xpuf = 0;
                    double.TryParse(dr.Cells["portee"].Value + "", out xport);
                    double.TryParse(dr.Cells["PUHTDeroulage"].Value + "", out xpud);
                    double.TryParse(dr.Cells["porteemoy"].Value + "", out xportmoy);
                    double.TryParse(dr.Cells["PUHTMontage"].Value + "", out xpumd);
                    double.TryParse(dr.Cells["PUHTFondation"].Value + "", out xpufd);
                    double.TryParse(dr.Cells["Poids"].Value + "", out xpoid);
                    double.TryParse(dr.Cells["PUP"].Value + "", out xpum);
                    double.TryParse(dr.Cells["VBP"].Value + "", out xvoul);
                    double.TryParse(dr.Cells["PUV"].Value + "", out xpuf);
                    TDeroulage += xport * xpud;
                    TotalFond_dist += xportmoy * xpufd;
                    TotalMont_dist += xportmoy * xpumd;
                    TotalFond += xpoid * xpuf;
                    TotalMont += xvoul * xpum;
                }

                TD.Text = TDeroulage.ToString("N3");
                TMD.Text = TotalMont_dist.ToString("N3");
                TFD.Text = TotalFond_dist.ToString("N3");
                TM.Text = TotalMont.ToString("N3");
                TF.Text = TotalFond.ToString("N3");

                Double xtvad = 0, xtva = 0, xthtd = 0, xtht = 0, xttcd = 0, xttc = 0;
                xthtd = TDeroulage + TotalFond_dist + TotalMont_dist;
                xtht = TDeroulage + TotalFond + TotalMont;

                xtvad = xthtd * 0.18;
                xtva = xtht * .018;

                xttcd = xthtd * 1.18;
                xttc = xtht * 1.18;

                THT1.Text = xtht.ToString("N3");
                THTD.Text = xthtd.ToString("N3");

                TVAD.Text = xtvad.ToString("N3");
                TVA1.Text = xtva.ToString("N3");

                TTCD.Text = xttcd.ToString("N3");
                TTC1.Text = xttc.ToString("N3");

            }
        }

        private void textBoxX18_TextChanged(object sender, EventArgs e)
        {
            //Double pav = 0, TTC=0;
            //double.TryParse(TFD.Text, out TTC);
            //double.TryParse(textBoxX18.Text, out pav);
            //double av = TTC * pav / 100;
            //THTD.Text = av.ToString("N3");
        }

        private void MAJContract_Load(object sender, EventArgs e)
        {
            act = false;
            if (modif)
            {
                
                String sql = "SELECT * FROM contrat WHERE ID = " + IDContrat;
                DataSet dsc = met.recuperer_table(sql);
                try
                {
                    DataRow dr = dsc.Tables[0].Rows[0];
                    nfact.Text = dr["CODE"] + "";
                    cli = new MetierClient(dr["CODEC"] + "");
                    Tcodc.Text = dr["CODEC"] + "";
                    Tnomc.Text = dr["NOMC"] + "";
                    Tadrc.Text = dr["ADRC"] + "";
                    Tht.Text = ((decimal)dr["THT"]).ToString("N3");
                    Tgar.Text = dr.Field<decimal>("VGAR") .ToString("N2");
                    Tavnc.Text = dr.Field<decimal>("VAVANC").ToString("N2");
                    datefact.Value = dr.Field<DateTime>("DATEDEBUT");
                }
                catch { }
                string sqld = "SELECT * FROM lcontrat WHERE IDCONTRAT = " + IDContrat;
                DataSet dscd = met.recuperer_table(sqld);
                if (dscd != null)
                    if (dscd.Tables.Count != 0)
                    {
                        int i = 0;
                        foreach (DataRow dr in dscd.Tables[0].Rows)
                        {
                            mygrid1.Rows.Add();
                            mygrid1.Rows[i].Cells["Npylon"].Value = dr["NPYLON"];
                            mygrid1.Rows[i].Cells["TypePylone"].Value = dr["TYPEPYLON"];
                            mygrid1.Rows[i].Cells["TypeMassif"].Value = dr["TYPEMASSIF"];
                            mygrid1.Rows[i].Cells["Poids"].Value = dr["POIDS"];
                            mygrid1.Rows[i].Cells["PUP"].Value = dr["PUPoids"];
                            mygrid1.Rows[i].Cells["VBP"].Value = dr["VBETON"];
                            mygrid1.Rows[i].Cells["PUV"].Value = dr["PUBETON"];
                            mygrid1.Rows[i].Cells["porteemoy"].Value = dr["PORTEEMOY"];
                            mygrid1.Rows[i].Cells["PUHTFondation"].Value = dr["PUFOND"];
                            mygrid1.Rows[i].Cells["PUHTMontage"].Value = dr["PUMONTAGE"];
                            mygrid1.Rows[i].Cells["portee"].Value = dr["PORTEE"];
                            mygrid1.Rows[i].Cells["PUHTDeroulage"].Value = dr["PUDEROULAGE"];
                            mygrid1.Rows[i].Cells["ID"].Value = dr["ID"];
                            i++;
                        }
                    }
                
            }
            act = true;
            calcultotal();
        }

        private void mygrid1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Cells["ID"].Value != null)
            {
                Lsupp.Add(e.Row.Cells["ID"].Value + "");
            }
        }

        private void Tgar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                mygrid1.Focus();
            }
        }

        private void Tavnc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                Tgar.Focus();
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {

        }

        private void Tgar_Validated(object sender, EventArgs e)
        {
            double t1 = 0;
            double.TryParse(Tgar.Text, out t1);
            Tgar.Text = t1.ToString("N2");
           

        }

        private void Tavnc_Validated(object sender, EventArgs e)
        {
            double t1 = 0;
            double.TryParse(Tavnc.Text, out t1);
            Tavnc.Text = t1.ToString("N2");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Tht_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                Ttva.Focus();
            }
        }

        private void Ttva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                Tttc.Focus();
            }
        }

        private void Tttc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                Tavnc.Focus();
            }
        }

        private void Tht_Validated(object sender, EventArgs e)
        {
            double t1 = 0;
            double.TryParse(Tht.Text, out t1);
            Tht.Text = t1.ToString("N3");
        }

        private void Ttva_Validated(object sender, EventArgs e)
        {
            double t1 = 0;
            double.TryParse(Ttva.Text, out t1);
            Ttva.Text = t1.ToString("N3");
        }

        private void Tttc_Validated(object sender, EventArgs e)
        {
            double t1 = 0;
            double.TryParse(Tttc.Text, out t1);
            Tttc.Text = t1.ToString("N3");
        }

        private void Tavnc_TextChanged(object sender, EventArgs e)
        {
            double xtht = 0, xtva = 0, xtttc = 0;
            double.TryParse(Tht.Text, out xtht);
            xtva = xtht * 0.18;
            xtttc = xtht * 1.18;
            Ttva.Text = xtva.ToString("N3");
            Tttc.Text = xtttc.ToString("N3");
            calculav_gr();
        }

        private void calculav_gr()
        {
            double xtht = 0, xtva = 0, xtttc = 0, xav = 0, xgr = 0, nav = 0, ngr = 0;
            double.TryParse(Tht.Text, out xtht);
            double.TryParse(Ttva.Text, out xtva);
            double.TryParse(Tttc.Text, out xtttc);
            double.TryParse(Tavnc.Text, out xav);
            double.TryParse(Tgar.Text, out xgr);
            nav = xtht * xav / 100;
            ngr = xtht * xgr / 100;
            Vavnc.Text = nav.ToString("N3");
            Vgar.Text = ngr.ToString("N3");
        }

        
    }
}
