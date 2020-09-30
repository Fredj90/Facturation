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
    public partial class orgfour : DevComponents.DotNetBar.Office2007Form
    {

        private metier met = Program.met;

        DataSet ds, ds4;
        public orgfour()
        {
            InitializeComponent();
            buttonX9.Visible = false;
        }

        private void orgfour_Load(object sender, EventArgs e)
        {
            string req3 = "select code,libelle from famillefour where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' ";
            DataSet ds3 = met.recuperer_table(req3, "famillefour");
            mygrid1.DataSource = ds3.Tables["famillefour"].DefaultView;




        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            {


                buttonX2.Visible = true;
                buttonX1.Visible = false;
                buttonX3.Visible = true;
                buttonX4.Visible = false;
                buttonX9.Visible = true;
                string req4 = "select code,libelle,ID from four where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' ";
                string tmp = " and (";
                Boolean f = true;
                foreach (DataGridViewRow dr in mygrid1.Rows)
                {
                    if (!f)
                        tmp += " or ";
                    dr.Cells[0].Value = true;

                    tmp += "codef = '" + dr.Cells[1].Value + "'";
                    f = false;
                }
                tmp += ")";
                req4 += tmp;
                ds4 = met.recuperer_table(req4, "four");
                mygrid2.DataSource = ds4.Tables["four"].DefaultView;
            }

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            buttonX1.Visible = true;
            buttonX2.Visible = false;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
            buttonX9.Visible = false;
            foreach (DataGridViewRow dr in mygrid1.Rows)
            {

                dr.Cells[0].Value = false;

            }
            //
            buttonX4_Click(sender, e);
            try
            {
                ((DataView)mygrid2.DataSource).Table.Clear();
            }
            catch { }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            buttonX3.Visible = true;
            buttonX4.Visible = false;

            foreach (DataGridViewRow dr in mygrid2.Rows)
            {

                dr.Cells[0].Value = false;

            }
            groupBox1.Visible = false;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (mygrid2.RowCount != 0)
            {
                buttonX3.Visible = false;
                buttonX4.Visible = true;
                foreach (DataGridViewRow dr in mygrid2.Rows)
                {

                    dr.Cells[0].Value = true;

                }
                groupBox1.Visible = true;
            }
            else
                groupBox1.Visible = false;
        }

        private void orgfour_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

        private void mygrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            {

                if (mygrid1.CurrentCell.ColumnIndex == 0)
                    if (mygrid1.CurrentCell.Value != null)
                        mygrid1.CurrentCell.Value = !(Boolean)mygrid1.CurrentCell.Value;
                    else
                        mygrid1.CurrentCell.Value = true;
                buttonX3.Visible = true;
                buttonX4.Visible = false;
                groupBox1.Visible = false;

                string req4 = "select code,libelle,ID from four where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
                string tmp = " and (";
                Boolean f = true;
                foreach (DataGridViewRow dr in mygrid1.Rows)
                {
                    if (dr.Cells[0].Value != null)
                        if ((Boolean)dr.Cells[0].Value)
                        {
                            if (!f)
                                tmp += " or ";
                            tmp += "codef = '" + dr.Cells[1].Value + "'";
                            f = false;
                        }
                }
                tmp += ")";
                req4 += tmp;
                if (!f)
                {
                    ds4 = met.recuperer_table(req4, "four");
                    mygrid2.DataSource = ds4.Tables["four"].DefaultView;
                }
                else
                {
                    buttonX3.Visible = false;
                    buttonX4.Visible = false;
                    try
                    {
                        ((DataView)mygrid2.DataSource).Table.Clear();
                    }
                    catch { }
                }
            }

        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void mygrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mygrid2.CurrentCell.ColumnIndex == 0)
                if (mygrid2.CurrentCell.Value != null)
                    mygrid2.CurrentCell.Value = !(Boolean)mygrid2.CurrentCell.Value;
                else
                    mygrid2.CurrentCell.Value = true;
            Boolean f = false;
            foreach (DataGridViewRow dr in mygrid2.Rows)
            {
                if (dr.Cells[0].Value != null)
                    if ((Boolean)dr.Cells[0].Value)
                    {

                        f = true;
                    }
            }
            groupBox1.Visible = f;
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (Program.ISSaDmin)
            {

                string xnfact;

                progressBarX1.Value = 0;
                progressBarX1.Visible = true;
                foreach (DataGridViewRow dgr in mygrid2.Rows)
                {
                    progressBarX1.Maximum = mygrid2.Rows.Count;

                    if (dgr.Cells["choixp"].Value != null)
                    {
                        if ((Boolean)dgr.Cells["choixp"].Value)
                        {
                            decimal xreg = 0, xttc = 0, xavr = 0, xttc1 = 0, xret = 0, xrem = 0, xsld1 = 0;
                            decimal zmnt = 0, zttc = 0, zavr = 0, zreg = 0, zrem = 0, zret = 0;


                            string xcode = dgr.Cells["codea"].Value + "";


                            ////// four
                            string req = "Select ID,code,libelle,solde1 from four where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and code ='" + xcode + "'  ";
                            ds = met.recuperer_table(req, "four");

                            if (ds.Tables[0].Rows.Count != 0)
                            {
                                try
                                {
                                    xsld1 = ds.Tables[0].Rows[0].Field<decimal>("solde1");
                                }
                                catch { }

                            }

                            string req1 = "Select Sum(totalttc) as totalttc,Sum(montret1) as retenue,Sum(montrem) as remise from eentf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem='" + Program.Magasin + "' and codec='" + xcode + "' ";
                            DataSet tmp1 = met.recuperer_table(req1, "eentf");

                            try
                            {
                                xttc += tmp1.Tables[0].Rows[0].Field<Decimal>("totalttc");
                                xret += tmp1.Tables[0].Rows[0].Field<Decimal>("retenue");
                                xrem += tmp1.Tables[0].Rows[0].Field<Decimal>("remise");
                            }
                            catch { }



                            string req2 = "Select Sum(totalttc) as totalttc from eente where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem='" + Program.Magasin + "'  and codec='" + xcode + "' and facture = false ";
                            DataSet tmp2 = met.recuperer_table(req2, "eente");

                            try
                            {
                                xttc1 += tmp2.Tables[0].Rows[0].Field<Decimal>("totalttc");
                            }
                            catch { }


                            string req3 = "Select Sum(totalttc) as totalttc from eentvf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem='" + Program.Magasin + "'  and codec='" + xcode + "'";
                            DataSet tmp3 = met.recuperer_table(req3, "eentvf");

                            try
                            {
                                xavr += tmp3.Tables[0].Rows[0].Field<Decimal>("totalttc");
                            }
                            catch { }


                            string req4 = "Select Sum(mont) as mont from eregf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem='" + Program.Magasin + "' and codec='" + xcode + "'";
                            DataSet tmp4 = met.recuperer_table(req4, "eregf");

                            try
                            {
                                xreg += tmp4.Tables[0].Rows[0].Field<Decimal>("mont");
                            }
                            catch { }

                            ////// Sauvergarde four
                            String req5 = "Update four Set debit = " + (xttc + xttc1)
                                   + ", credit = " + xreg
                                   + ", avoir   = " + xavr
                                   + ", retenue  = " + xret
                                   + ", rem      = " + xrem
                                   + ", solde    = " + ((xsld1 + xttc + xttc1) - (xavr + xreg + xret + xrem))
                                   + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and code='" + xcode + "'";

                            met.Execute(req5);

                            // Retour Montant avoir & montant reglement a 0 pour facture four
                            string req10 = "Select montavr,montreg from eentf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem='" + Program.Magasin + "' and codec='" + xcode + "'";
                            DataSet tmp10 = met.recuperer_table(req10, "eentf");
                            foreach (DataRow dr3 in tmp10.Tables["eentf"].Rows)
                            {


                                String req6 = "Update eentf Set MONTAVR = " + zmnt
                                         + ", montreg = " + zmnt
                                         + ", montrem = " + zmnt
                                         + ", montret1 = " + zmnt
                                         + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codec='" + xcode + "'";
                                met.Execute(req6);
                            }

                            // calcul Montant avoir  pour facture four

                            string req11 = "Select totalttc,nfact from eentvf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem='" + Program.Magasin + "'  and codec='" + xcode + "'";
                            DataSet tmp11 = met.recuperer_table(req11, "eentvf");
                            foreach (DataRow dr3 in tmp11.Tables["eentvf"].Rows)
                            {

                                xnfact = dr3.Field<string>("nfact");
                                try
                                {
                                    zmnt = dr3.Field<Decimal>("totalttc");
                                }
                                catch { }

                                String req7 = "Update eentf Set MONTAVR = " + zmnt
                                            + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem='" + Program.Magasin + "'  and num ='" + xnfact + "'";
                                met.Execute(req7);

                            }

                            // calcul Montant reglement  pour facture four
                            string req17 = "Select num from eentf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem='" + Program.Magasin + "'   and codec='" + xcode + "'";
                            DataSet tmp17 = met.recuperer_table(req17, "eentf");
                            decimal wzmnt = 0, wrem = 0, wret = 0;
                            foreach (DataRow dr3 in tmp17.Tables["eentf"].Rows)
                            {
                                xnfact = dr3.Field<string>("num");

                                string req7 = "Select mont,mntrem,mntret,nfact from lregf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem='" + Program.Magasin + "'  and nfact ='" + xnfact + "'";
                                DataSet tmp7 = met.recuperer_table(req7, "lregf");

                                foreach (DataRow dr2 in tmp7.Tables["lregf"].Rows)
                                {

                                    try
                                    {
                                        wzmnt += dr2.Field<Decimal>("mont");
                                    }
                                    catch { }

                                    try
                                    {
                                        wrem += dr2.Field<Decimal>("mntrem");
                                    }
                                    catch { }

                                    try
                                    {
                                        wret += dr2.Field<Decimal>("mntret");
                                    }
                                    catch { }

                                }

                                String req8 = "Update eentf Set MONTREG = " + wzmnt
                                          + ", montrem = " + wrem
                                          + ", montret1 = " + wret
                                          + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem='" + Program.Magasin + "' and num ='" + xnfact + "'";
                                met.Execute(req8);
                                wzmnt =  wrem = wret =0 ;
                            }

                            //calcul  solde facture four
                            string req12 = "Select num,totalttc,montavr,montreg,montrem,montret1,reste from eentf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem='" + Program.Magasin + "'   and codec='" + xcode + "'";
                            DataSet tmp12 = met.recuperer_table(req12, "eentf");
                            foreach (DataRow dr3 in tmp12.Tables["eentf"].Rows)
                            {

                                xnfact = dr3.Field<string>("num");
                                try
                                {
                                    zttc = dr3.Field<Decimal>("totalttc");
                                }
                                catch { }

                                try
                                {
                                    zavr = dr3.Field<Decimal>("montavr");
                                }
                                catch { }

                                try
                                {
                                    zreg = dr3.Field<Decimal>("montreg");
                                }
                                catch { }

                                try
                                {
                                    zrem = dr3.Field<Decimal>("montrem");
                                }
                                catch { }

                                try
                                {
                                    zret = dr3.Field<Decimal>("montret1");
                                }
                                catch { }

                                String req9 = "Update eentf Set reste = " + ((zttc - (zavr + zreg + zrem + zret)))
                                       + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'  and num ='" + xnfact + "'";
                                met.Execute(req9);

                            }





                            progressBarX1.Value++;
                        }
                    }
                }

                progressBarX1.Visible = false;
                MessageBox.Show("Réorganisation  effectuée avec Succés");
            }
            else
            {
                MessageBox.Show("Accés Non Autorisé");
            }


        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            // Bouton Recherche
            Rech form = new Rech();
            form.table = "four";
            form.ShowDialog();
            form.textBoxX2.Focus();
            if (form.code != 0)
            {
                List<DataColumn> lis = new List<DataColumn>();
                lis.Add(ds4.Tables["four"].Columns["ID"]);
                ds4.Tables["four"].PrimaryKey = lis.ToArray();
                DataRow[] dr = ds4.Tables["four"].Select("ID = '" + form.code + "'");
                if (dr.Length != 0)
                {
                    int i = ds4.Tables[0].Rows.IndexOf(dr[0]);
                    mygrid2.Rows[i].Selected = true;
                }
            }
        }



    }
}
