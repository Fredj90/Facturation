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
    public partial class FContart : DevComponents.DotNetBar.Office2007Form
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
       public FContart()
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
                        if (!Retenue)
                            checkBox1.Enabled = false;
                        checkBox1.Checked = Retenue;
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
                        if (!Retenue)
                            checkBox1.Enabled = false;
                        checkBox1.Checked = Retenue;
                        grd_contrat.Focus();
                    }
                }
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void buttonX2_Click(object sender, EventArgs e)
        {
           
        }


        private void textBoxX18_TextChanged(object sender, EventArgs e)
        {
        }

        private void FFondation_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Retenue;
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
            

            
            mygrid1.Rows.Clear();
            Boolean load = false;
            string sqld = "SELECT * FROM lcontrat WHERE codes='" + Program.Societe + "' and (poids is not null or pupoids is not null or vbeton is not null or portee is not null or porteemoy is not null or pumontage is not null or puderoulage is not null) and IDCONTRAT = " + IDContrat ;
            if (RF.Checked)
            {
                sqld += " AND PRORATAF<100";
                load = true;
            }
            else if (RM.Checked)
            {
                sqld += " AND PRORATAM<100";
                load = true;
            }
            else if (RD.Checked)
            {
                sqld = "SELECT * FROM lcontrat WHERE codes='" + Program.Societe + "' and IDCONTRAT = " + IDContrat;
                sqld += " AND PRORATAD<100";
                load = true;
            }
            else if (RDIV.Checked)
            {
                sqld = "SELECT * FROM lcontrat WHERE codes='" + Program.Societe + "' and IDCONTRAT = " + IDContrat;
                load = true;
            }
            if (load)
            {
                sqld += " ORDER BY `ORDRE`";
                DataSet dscd = met.recuperer_table(sqld);
                if (dscd != null)
                    if (dscd.Tables.Count != 0)
                    {
                        int i = 0;

                        foreach (DataRow dr in dscd.Tables[0].Rows)
                        {
                            mygrid1.Rows.Add();
                            mygrid1.Rows[i].Cells["x"].Value = false;
                            mygrid1.Rows[i].Cells["Npylon"].Value = dr["NPYLON"];
                            mygrid1.Rows[i].Cells["TypePylone"].Value = dr["TYPEPYLON"];
                            mygrid1.Rows[i].Cells["TypeMassif"].Value = dr["TYPEMASSIF"];
                            mygrid1.Rows[i].Cells["Poids"].Value = dr["POIDS"];
                            mygrid1.Rows[i].Cells["PUP"].Value = dr["PUPoids"];
                            mygrid1.Rows[i].Cells["VBP"].Value = dr["VBETON"];
                            mygrid1.Rows[i].Cells["PUV"].Value = dr["PUBETON"];
                            mygrid1.Rows[i].Cells["portee"].Value = dr["PORTEE"];
                            mygrid1.Rows[i].Cells["PUHTDeroulage"].Value = dr["PUDEROULAGE"];
                            mygrid1.Rows[i].Cells["porteemoy"].Value = dr["PORTEEMOY"];
                            mygrid1.Rows[i].Cells["PUHTFondation"].Value = dr["PUFOND"];
                            mygrid1.Rows[i].Cells["PUHTMontage"].Value = dr["PUMONTAGE"];
                            mygrid1.Rows[i].Cells["prorataf"].Value = dr["prorataf"];
                            mygrid1.Rows[i].Cells["proratam"].Value = dr["proratam"];
                            mygrid1.Rows[i].Cells["proratad"].Value = dr["proratad"];
                            mygrid1.Rows[i].Cells["ID"].Value = dr["ID"];
                            mygrid1.Rows[i].Cells["ordre"].Value = dr["ordre"];
                            double xp = 0;
                            double.TryParse(dr["prorataf"] + "", out xp);
                            if (xp >= 100)
                            {
                                mygrid1.Rows[i].Cells["prorataf"].Style.BackColor = Color.Green;
                                mygrid1.Rows[i].Cells["prorataf"].Style.ForeColor = Color.White;
                            }
                            else if (xp > 0)
                            {
                                mygrid1.Rows[i].Cells["prorataf"].Style.BackColor = Color.Wheat;
                                mygrid1.Rows[i].Cells["prorataf"].Style.ForeColor = Color.Black;
                            }
                            else
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
                            else
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
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            selection = !selection;
            foreach (DataGridViewRow dr in mygrid1.Rows)
            {
                dr.Cells["x"].Value = selection;
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            Double max = 100;
            Double souh = 70; 
            LSTid = new List<string>();
            foreach (DataGridViewRow dr in mygrid1.Rows)
            {
                Boolean xb = (Boolean)dr.Cells["x"].Value;
                if (xb)
                {
                    Double pro = 0;
                    Double.TryParse(dr.Cells["proratam"].Value + "", out pro);
                    if (100 - pro < max)
                    {
                        max = 100 - pro;
                    }
                    LSTid.Add(dr.Cells["ID"].Value + "");
                }
            }
            if (LSTid.Count != 0)
            {
                FCMontage mnt = new FCMontage();
                mnt.max = max;
                mnt.souh = souh;
                mnt.LSTid = LSTid;
                mnt.IDContrat = IDContrat;
                mnt.cli = cli;
                mnt.Retenue = Retenue;
                mnt.ShowDialog();
                this.Close();
            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            Double max = 100;
            Double souh = 70; 
            LSTid = new List<string>();
            foreach (DataGridViewRow dr in mygrid1.Rows)
            {
                Boolean xb = (Boolean)dr.Cells["x"].Value;
                if (xb)
                {
                    Double pro = 0;
                    Double.TryParse(dr.Cells["proratam"].Value + "", out pro);
                    if (100 - pro < max)
                    {
                        max = 100 - pro;
                    }
                    LSTid.Add(dr.Cells["ID"].Value + "");
                }
            }
            if (LSTid.Count != 0)
            {
                FCMontageSections mnt = new FCMontageSections();
                mnt.max = max;
                mnt.souh = souh;
                mnt.LSTid = LSTid;
                mnt.IDContrat = IDContrat;
                mnt.cli = cli;
                mnt.Retenue = Retenue;
                mnt.ShowDialog();
                this.Close();
            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            LSTid = new List<string>();
            foreach (DataGridViewRow dr in mygrid1.Rows)
            {
                Boolean xb = (Boolean)dr.Cells["x"].Value;
                if (xb)
                {
                    LSTid.Add(dr.Cells["ID"].Value + "");
                }
            }
            if (LSTid.Count != 0)
            {
                FCFondation mnt = new FCFondation();
                mnt.LSTid = LSTid;
                mnt.IDContrat = IDContrat;
                mnt.cli = cli;
                mnt.Retenue = Retenue;
                mnt.ShowDialog();
                this.Close();
            }
        }

       

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            LSTid = new List<string>();
            foreach (DataGridViewRow dr in mygrid1.Rows)
            {
                Boolean xb = (Boolean)dr.Cells["x"].Value;
                if (xb)
                {
                    LSTid.Add(dr.Cells["ID"].Value + "");
                }
            }
            if (LSTid.Count != 0)
            {
                FCFondationSections mnt = new FCFondationSections();
                mnt.LSTid = LSTid;
                mnt.IDContrat = IDContrat;
                mnt.cli = cli;
                mnt.Retenue = Retenue;
                mnt.ShowDialog();
                this.Close();
            }
        }

        private void RF_CheckedChanged(object sender, EventArgs e)
        {
            if (RF.Checked)
            {
                Deroul.Visible = false;
                Div.Visible = false;
                Msect.Visible = false;
                Mpoid.Visible = false;
                Fvol.Visible = true;
                Fsect.Visible = true;
                BAV.Visible = false;
                BLG.Visible = false;
                mygrid1.Columns["proratam"].Visible = false;
                mygrid1.Columns["proratad"].Visible = false;
                mygrid1.Columns["prorataf"].Visible = true;

                mygrid1.Columns["Poids"].Visible = false;
                mygrid1.Columns["PUP"].Visible = false;
                mygrid1.Columns["VBP"].Visible = true;
                mygrid1.Columns["PUV"].Visible = true;
                mygrid1.Columns["portee"].Visible = false;
                mygrid1.Columns["PUHTDeroulage"].Visible = false;
                mygrid1.Columns["porteemoy"].Visible = true;
                mygrid1.Columns["PUHTFondation"].Visible = true;
                mygrid1.Columns["PUHTMontage"].Visible = false;
            }
            else {
                Fvol.Visible = false;
                Fsect.Visible = false;
                mygrid1.Columns["VBP"].Visible = false;
                mygrid1.Columns["PUV"].Visible = false;
                mygrid1.Columns["porteemoy"].Visible = false;
                mygrid1.Columns["PUHTFondation"].Visible = false;
                mygrid1.Columns["prorataf"].Visible = false;
            }
            Tnomc.ReadOnly = false;
            Tcodc.ReadOnly = false;
            load_contrat(IDContrat);
            
        }

        private void RM_CheckedChanged(object sender, EventArgs e)
        {
            if (RM.Checked)
            {
                Deroul.Visible = false;
                Div.Visible = false;
                Msect.Visible = true;
                Mpoid.Visible = true;
                Fvol.Visible = false;
                Fsect.Visible = false;
                BAV.Visible = false;
                BLG.Visible = false;
                mygrid1.Columns["proratam"].Visible = true;
                mygrid1.Columns["proratad"].Visible = false;
                mygrid1.Columns["prorataf"].Visible = false;

                mygrid1.Columns["Poids"].Visible = true;
                mygrid1.Columns["PUP"].Visible = true;
                mygrid1.Columns["VBP"].Visible = false;
                mygrid1.Columns["PUV"].Visible = false;
                mygrid1.Columns["portee"].Visible = false;
                mygrid1.Columns["PUHTDeroulage"].Visible = false;
                mygrid1.Columns["porteemoy"].Visible = true;
                mygrid1.Columns["PUHTFondation"].Visible = false;
                mygrid1.Columns["PUHTMontage"].Visible = true;
            }
            else
            {
                Msect.Visible = false;
                Mpoid.Visible = false;
                mygrid1.Columns["proratam"].Visible = false;
                mygrid1.Columns["Poids"].Visible = false;
                mygrid1.Columns["PUP"].Visible = false;
                mygrid1.Columns["porteemoy"].Visible = false;
                mygrid1.Columns["PUHTMontage"].Visible = false;
            }
            Tnomc.ReadOnly = false;
            Tcodc.ReadOnly = false;
            load_contrat(IDContrat);
        }

        private void RD_CheckedChanged(object sender, EventArgs e)
        {
            if (RD.Checked)
            {
                Deroul.Visible = true;
                Div.Visible = false;
                Msect.Visible = false;
                Mpoid.Visible = false;
                Fvol.Visible = false;
                Fsect.Visible = false;
                BAV.Visible = false;
                BLG.Visible = false;
                mygrid1.Columns["proratam"].Visible = false;
                mygrid1.Columns["proratad"].Visible = true;
                mygrid1.Columns["prorataf"].Visible = false;

                mygrid1.Columns["Poids"].Visible = false;
                mygrid1.Columns["PUP"].Visible = false;
                mygrid1.Columns["VBP"].Visible = false;
                mygrid1.Columns["PUV"].Visible = false;
                mygrid1.Columns["portee"].Visible = true;
                mygrid1.Columns["PUHTDeroulage"].Visible = true;
                mygrid1.Columns["porteemoy"].Visible = false;
                mygrid1.Columns["PUHTFondation"].Visible = false;
                mygrid1.Columns["PUHTMontage"].Visible = false;
            }
            else
            {
                Deroul.Visible = false;
                mygrid1.Columns["proratad"].Visible = false;
                mygrid1.Columns["portee"].Visible = false;
                mygrid1.Columns["PUHTDeroulage"].Visible = false;
            }
            Tnomc.ReadOnly = false;
            Tcodc.ReadOnly = false;
            load_contrat(IDContrat);
        }

        private void RDIV_CheckedChanged(object sender, EventArgs e)
        {
            if (RDIV.Checked)
            {
                Deroul.Visible = false;
                Div.Visible = true;
                Msect.Visible = false;
                Mpoid.Visible = false;
                Fvol.Visible = false;
                Fsect.Visible = false;
                BAV.Visible = false;
                BLG.Visible = false;
                mygrid1.Columns["proratam"].Visible = true;
                mygrid1.Columns["proratad"].Visible = true;
                mygrid1.Columns["prorataf"].Visible = true;
                mygrid1.Columns["Poids"].Visible = true;
                mygrid1.Columns["PUP"].Visible = true;
                mygrid1.Columns["VBP"].Visible = true;
                mygrid1.Columns["PUV"].Visible = true;
                mygrid1.Columns["portee"].Visible = true;
                mygrid1.Columns["PUHTDeroulage"].Visible = true;
                mygrid1.Columns["porteemoy"].Visible = true;
                mygrid1.Columns["PUHTFondation"].Visible = true;
                mygrid1.Columns["PUHTMontage"].Visible = true;
            }
            else
            {
                Div.Visible = false;
                mygrid1.Columns["proratam"].Visible = false;
                mygrid1.Columns["proratad"].Visible = false;
                mygrid1.Columns["prorataf"].Visible = false;
                mygrid1.Columns["Poids"].Visible = false;
                mygrid1.Columns["PUP"].Visible = false;
                mygrid1.Columns["VBP"].Visible = false;
                mygrid1.Columns["PUV"].Visible = false;
                mygrid1.Columns["portee"].Visible = false;
                mygrid1.Columns["PUHTDeroulage"].Visible = false;
                mygrid1.Columns["porteemoy"].Visible = false;
                mygrid1.Columns["PUHTFondation"].Visible = false;
                mygrid1.Columns["PUHTMontage"].Visible = false;
            }
            Tnomc.ReadOnly = false;
            Tcodc.ReadOnly = false;
            load_contrat(IDContrat);
        }

        private void Deroul_Click(object sender, EventArgs e)
        {
            Boolean first = true;
            int last = 1;
            LSTid = new List<string>();
            if (mygrid1.Rows.Count < 2)
            {
                MessageBox.Show("Le Nombre des Pylone à Facturer doit Superieur à 1.");
                return;
            }
            foreach (DataGridViewRow dr in mygrid1.Rows)
            {
                Boolean xb = (Boolean)dr.Cells["x"].Value;
                if (xb)
                {
                    int ordre = 0;
                    int.TryParse(dr.Cells["ordre"].Value + "", out ordre);
                    if (first)
                    {
                        last = ordre;
                        first = false;
                    }
                    else
                    {
                        if (ordre != last + 1)
                        {
                            MessageBox.Show("Vérifier l'Ordre des Pylon.");
                            return;
                        }
                        else
                            last = ordre;
                    }
                    LSTid.Add(dr.Cells["ID"].Value + "");
                }
            }
            if (LSTid.Count != 0)
            {
                FCDeroulageSections mnt = new FCDeroulageSections();
                mnt.LSTid = LSTid;
                mnt.IDContrat = IDContrat;
                mnt.cli = cli;
                mnt.Retenue = Retenue;
                mnt.ShowDialog();
                this.Close();
            }
        }

        private void mygrid1_AllowUserToOrderColumnsChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RAV.Checked)
            {
                Deroul.Visible = false;
                Div.Visible = false;
                Msect.Visible = false;
                Mpoid.Visible = false;
                Fvol.Visible = false;
                Fsect.Visible = false;
                BAV.Visible = true;
                BLG.Visible = false;
                mygrid1.Visible = false;
                this.Height -= mygrid1.Height;
            }
            else
            {
                BAV.Visible = false;
                mygrid1.Visible = true;
                this.Height += mygrid1.Height;
            }
            Tnomc.ReadOnly = false;
            Tcodc.ReadOnly = false;
            //load_contrat(IDContrat);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RLG.Checked)
            {
                Deroul.Visible = false;
                Div.Visible = false;
                Msect.Visible = false;
                Mpoid.Visible = false;
                Fvol.Visible = false;
                Fsect.Visible = false;
                BAV.Visible = false;
                BLG.Visible = true;
                mygrid1.Visible = false;
                this.Height -= mygrid1.Height;
            }
            else
            {
                BLG.Visible = false;
                mygrid1.Visible = true;
                this.Height += mygrid1.Height;
            }
            Tnomc.ReadOnly = false;
            Tcodc.ReadOnly = false;
            //load_contrat(IDContrat);
        }

        private void FContart_Shown(object sender, EventArgs e)
        {
            
        }

        private void BAV_Click(object sender, EventArgs e)
        {
            if (IDContrat != "" )
            {
                if (!Fav)
                {
                    FCAvance mnt = new FCAvance();
                    mnt.IDContrat = IDContrat;
                    mnt.cli = cli;
                    mnt.Retenue = Retenue;
                    mnt.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Avance Facturée, N° Facture: " + numav);
                }
            }
        }

        private void Div_Click(object sender, EventArgs e)
        {
            LSTid = new List<string>();
            foreach (DataGridViewRow dr in mygrid1.Rows)
            {
                Boolean xb = (Boolean)dr.Cells["x"].Value;
                if (xb)
                {
                    LSTid.Add(dr.Cells["ID"].Value + "");
                }
            }
            if (LSTid.Count != 0)
            {
                FCDIVERS mnt = new FCDIVERS();
                mnt.LSTid = LSTid;
                mnt.IDContrat = IDContrat;
                mnt.cli = cli;
                mnt.Retenue = Retenue;
                mnt.ShowDialog();
                this.Close();
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            Retenue = checkBox1.Checked;
        }

        private void BLG_Click(object sender, EventArgs e)
        {
            if (IDContrat != "")
            {
                if (!Fgar)
                {
                    FCGarantie mnt = new FCGarantie();
                    mnt.IDContrat = IDContrat;
                    mnt.cli = cli;
                    mnt.Retenue = Retenue;
                    mnt.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Libération Garantie Facturée, N° Facture: " + numgar);
                }
            }
        }
    }
}
