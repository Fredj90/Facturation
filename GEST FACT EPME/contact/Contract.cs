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

namespace EPME
{
    public partial class Contract : DevComponents.DotNetBar.Office2007Form
    {
      
        private metier met = Program.met;
        DataSet ds;
        Boolean first = true, xvstk = false;
        decimal xdeb,xven;
        public Contract()
        {
            InitializeComponent();
        }


        private void Factcli1_Load(object sender, EventArgs e)
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
           // charger_lignefacture();
        }

        private void charger_lignefacture()
        {
            mygrid1.Rows.Clear();
            string sqld = "SELECT * FROM lcontrat WHERE IDCONTRAT = " + dataGridViewX1.CurrentRow.Cells["IDC"].Value + " ORDER BY ORDRE";
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
                        mygrid1.Rows[i].Cells["prorataf"].Value = dr["prorataf"];
                        mygrid1.Rows[i].Cells["proratam"].Value = dr["proratam"];
                        mygrid1.Rows[i].Cells["ID"].Value = dr["ID"];
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
                        else {
                            mygrid1.Rows[i].Cells["prorataf"].Style.BackColor = Color.Red;
                            mygrid1.Rows[i].Cells["prorataf"].Style.ForeColor = Color.Yellow;
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
                            mygrid1.Rows[i].Cells["proratam"].Style.ForeColor = Color.Yellow;
                        }
                        i++;
                    }
                }
            
        }


        private void buttonX3_Click(object sender, EventArgs e)
        {
            // Bouton Supprimer Facture
            if (dataGridViewX1.Rows.Count != 0)
            {
            
            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            {
               

            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            // Bouton créer Facture BL

           
            buttonX1_Click(sender, e);
        }
        private void buttonItem7_Click(object sender, EventArgs e)
        {
            // Bouton créer Facture Co

            
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {

        }

        private void Factcli1_KeyDown(object sender, KeyEventArgs e)
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
            
            
            string req = "select CODE, codec,nomc,solde, ID from contrat where codes = '" + Program.Societe + "' order by CODE";
            ds = met.recuperer_table(req, "contrat");
            dataGridViewX1.DataSource = ds.Tables["contrat"].DefaultView;
            if (dataGridViewX1.Rows.Count != 0)
            {
                if (first)
                {
                    dataGridViewX1.CurrentCell = dataGridViewX1.Rows[dataGridViewX1.Rows.Count - 1].Cells[2];
                }
                dataGridViewX1.Rows[0].Selected = false;
                dataGridViewX1.FirstDisplayedScrollingRowIndex = dataGridViewX1.Rows.Count - 1;
                dataGridViewX1.Rows[dataGridViewX1.Rows.Count - 1].Selected = true;
                //charger_lignefacture();
                //total();
            }
           // dataGridViewX1_CellFormatting();
        }

        private void total()
        {
            Decimal xth = 0 , xtrem = 0, xtva = 0, xttc = 0 , xavr = 0 , xtreg = 0 ,xttaxe=0, xtsld = 0 ,xfodec=0;
            Decimal x1 = 0, x2 = 0 ,x3 = 0;
            foreach (DataRow dr in ds.Tables["eentc"].Rows)
            {

                string xf = dr.Field<string>("mode");

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
                    xttc += dr.Field<Decimal>("totalttc");
                }
                catch { }
                try
                {
                    xtreg += dr.Field<Decimal>("montreg");
                }
                catch { }
                try
                {
                    xtsld += dr.Field<Decimal>("reste");
                }
                catch { }
                try
                {
                    xttaxe += dr.Field<Decimal>("totaltaxe");
                }
                catch { }

                try
                {
                    xavr += dr.Field<Decimal>("montavr");
                }
                catch { }

                if (xf=="D")
                {
                    try
                    {
                        x1 += dr.Field<Decimal>("totalttc");
                    }
                    catch { }
                }
                else if (xf=="L")
                {
                    try
                    {
                        x2 += dr.Field<Decimal>("totalttc");
                    }
                    catch { }
                }
                else if (xf == "B")
                {
                    try
                    {
                        x3 += dr.Field<Decimal>("totalttc");
                    }
                    catch { }
                }

             
                textBoxX5.Text = xtreg.ToString("N3");
                textBoxX6.Text = xtsld.ToString("N3");
                textBoxX7.Text = xavr.ToString("N3");
               
            }
        }

        private void dataGridViewX2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count != 0)
            {
                EPME.contact.MAJContractD ff = new EPME.contact.MAJContractD();
                ff.modif = true;
                ff.IDContrat = dataGridViewX1.CurrentRow.Cells["IDC"].Value + "";
                ff.ShowDialog();
                buttonX1_Click(sender, e);
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

        private void superTabControlPanel2_Click(object sender, EventArgs e)
        {

        }

        private void Factcli1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

        private void dataGridViewX1_CellFormatting()
        {
            
        }

       

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count != 0)
            {
                
            }
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count != 0)
            {
               
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            EPME.contact.MAJContractD maj = new contact.MAJContractD();
            maj.ShowDialog();
        }

        private void superTabControl1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {

        }

    }
}
