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
    public partial class MAJContract : DevComponents.DotNetBar.Office2007Form
    {
        MetierClient cli=null;
        Boolean change = false;
        public Boolean modif = false;
        private metier met = Program.met;
        public String IDContrat = "";
        List<string> Lsupp = new List<string>();
        public MAJContract()
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
                        Tgar.Focus();
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
                        Tgar.Enabled = true;
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
           
            //if(e.RowIndex!=-1)
            //if (e.ColumnIndex == 3 || e.ColumnIndex == 5 || e.ColumnIndex == 7)
            //{
            //    double qte = 0, puht = 0, tva=18,tht=0,ttc=0;
            //    double.TryParse(mygrid1.Rows[e.RowIndex].Cells[3].Value + "", out qte);
            //    double.TryParse(mygrid1.Rows[e.RowIndex].Cells[5].Value + "", out puht);
            //    double.TryParse(mygrid1.Rows[e.RowIndex].Cells[7].Value + "", out tva);
            //    if (mygrid1.Rows[e.RowIndex].Cells[7].Value == null)
            //        tva = 18;
            //    tht = qte * puht;
            //    ttc = tht * (1 + (tva / 100));
            //    mygrid1.Rows[e.RowIndex].Cells[3].Value = qte.ToString("N5");
            //    mygrid1.Rows[e.RowIndex].Cells[5].Value = puht.ToString("N3");
            //    mygrid1.Rows[e.RowIndex].Cells[6].Value = tht.ToString("N3");
            //    mygrid1.Rows[e.RowIndex].Cells[7].Value = tva.ToString("N2");
            //    mygrid1.Rows[e.RowIndex].Cells[8].Value = ttc.ToString("N3");
            //    calcultotal();
            //}
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
                    String dat = datefact.Value.ToString("yyyy-MM-dd");
                    string sql = "INSERT INTO contrat (CODE,CODEC, NOMC,ADRC,DATEDEBUT,VGAR,VAVANC, CODES) VALUE ("//, THT, TVA,TTC, AVANCE,solde,reste
                        + "'" + nfact.Text + "',"
                        + "'" + Tcodc.Text + "',"
                        + "'" + Tnomc.Text + "',"
                        + "'" + Tadrc.Text + "',"
                        + "'" + dat + "',"
                        + "'" + Tgar.Text + "',"
                        + "'" + Tavnc.Text + "',"
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
                    String sqlF = "INSERT INTO lcontrat (NPYLON,TYPEPYLON,TYPEMASSIF,POIDS,PUPoids,VBETON,PUBETON,DISTANCE,PUDISTANCE,CODES,IDCONTRAT) values";
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
                            sqlF += "'" + dr.Cells["Npylon"].Value + "'"
                                + ",'" + dr.Cells["TypePylone"].Value + "'"
                                + ",'" + dr.Cells["TypeMassif"].Value + "'"
                                + ",'" + (dr.Cells["Poids"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                + ",'" + (dr.Cells["PUP"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                + ",'" + (dr.Cells["VBP"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                + ",'" + (dr.Cells["PUV"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                + ",'" + (dr.Cells["distance"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                + ",'" + (dr.Cells["PUD"].Value + "").Replace(Program.sep, string.Empty) + "'"
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
                    String dat = datefact.Value.ToString("yyyy-MM-dd");
                    string sql = "UPDATE  contrat SET " // (,, ,,, , THT, TVA,TTC, AVANCE,solde,reste) VALUE ("
                        + "CODE='" + nfact.Text + "',"
                        + "CODEC='" + Tcodc.Text + "',"
                        + "NOMC='" + Tnomc.Text + "',"
                        + "ADRC='" + Tadrc.Text + "',"
                        + "VGAR='" + Tgar.Text + "',"
                        + "VAVANC='" + Tavnc.Text + "',"
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
                    String sqlF = "INSERT INTO lcontrat (NPYLON,TYPEPYLON,TYPEMASSIF,POIDS,PUPoids,VBETON,PUBETON,DISTANCE,PUDISTANCE,CODES,IDCONTRAT) values";
                    Boolean frst = true;
                    foreach (DataGridViewRow dr in mygrid1.Rows)
                    {
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
                                + ",'" + (dr.Cells["Poids"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                + ",'" + (dr.Cells["PUP"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                + ",'" + (dr.Cells["VBP"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                + ",'" + (dr.Cells["PUV"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                + ",'" + (dr.Cells["distance"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                + ",'" + (dr.Cells["PUD"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                + ",'" + Program.Societe + "'"
                                + "," + ID + ")";
                                frst = false;
                            }
                        }
                        else 
                        {
                            String sqlu = "UPDATE lcontrat SET"
                           + " NPYLON='" + dr.Cells["Npylon"].Value + "'"
                                    + ",TYPEPYLON='" + dr.Cells["TypePylone"].Value + "'"
                                    + ",TYPEMASSIF='" + dr.Cells["TypeMassif"].Value + "'"
                                    + ",POIDS='" + (dr.Cells["Poids"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                    + ",PUPoids='" + (dr.Cells["PUP"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                    + ",VBETON='" + (dr.Cells["VBP"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                    + ",PUBETON='" + (dr.Cells["PUV"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                    + ",DISTANCE='" + (dr.Cells["distance"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                    + ",PUDISTANCE='" + (dr.Cells["PUD"].Value + "").Replace(Program.sep, string.Empty) + "'"
                                    +"  WHERE ID = "+dr.Cells["ID"].Value;
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
            double THT = 0, TVA = 0, TTC = 0;
            foreach(DataGridViewRow dr in mygrid1.Rows)
            {
                double xtht = 18, xtva = 0, xttc = 0;
                double.TryParse(dr.Cells[6].Value + "", out xtht);
                double.TryParse(dr.Cells[7].Value + "", out xtva);
                double.TryParse(dr.Cells[8].Value + "", out xttc);
                THT += xtht;
                TVA += (THT * xtva / 100);
                TTC += xttc;
            }

            textBoxX12.Text = THT.ToString("N3");
            textBoxX13.Text = TVA.ToString("N3");
            textBoxX16.Text = TTC.ToString("N3");
            Double pav = 0;
            double.TryParse(textBoxX18.Text, out pav);
            double av = TTC * pav/100;
            textBoxX17.Text = av.ToString("N3");
            
        }

        private void textBoxX18_TextChanged(object sender, EventArgs e)
        {
            Double pav = 0, TTC=0;
            double.TryParse(textBoxX16.Text, out TTC);
            double.TryParse(textBoxX18.Text, out pav);
            double av = TTC * pav / 100;
            textBoxX17.Text = av.ToString("N3");
        }

        private void MAJContract_Load(object sender, EventArgs e)
        {
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
                Tavnc.Focus();
            }
        }

        private void Tavnc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                mygrid1.Focus();
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
    }
}
