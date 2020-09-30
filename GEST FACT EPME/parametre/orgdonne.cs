using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EPME
{
    public partial class orgdonne : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
       
       
        DataSet ds;
      

        public orgdonne()
        {
            InitializeComponent();
           
        }

        private void orgdonne_Load(object sender, EventArgs e)
        {
          
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

          
            progressBarX1.Value = 0;
            progressBarX1.Visible = true;
            string xnfact ;
            decimal zmnt = 0 , zttc=0 , zavr=0 , zreg=0;

            string req = "Select ID,code,libelle,solde1 from client where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' order by code ";
            ds = met.recuperer_table(req, "client");
            progressBarX1.Maximum = (ds.Tables["client"].Rows.Count)/3;
            foreach (DataRow dr in ds.Tables["client"].Rows)
            {
                decimal xreg = 0, xttc = 0, xavr = 0, xttc1 = 0, xsld1 = 0;

                textBoxX1.Text = dr.Field<string>("code");
                textBoxX2.Text = dr.Field<string>("libelle");
                label1.Text = "Client";
                this.Update();

                try
                {
                    xsld1 = dr.Field<Decimal>("solde1");
                }
                catch { }



                string req1 = "Select Sum(totalttc) as totalttc from eentc where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codec='" + textBoxX1.Text + "' ";
                DataSet tmp1 = met.recuperer_table(req1, "eentc");

                try
                {
                    xttc += tmp1.Tables[0].Rows[0].Field<Decimal>("totalttc");
                }
                catch { }



                string req2 = "Select Sum(totalttc) as totalttc from eentl where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codec='" + textBoxX1.Text + "' and facture = false ";
                DataSet tmp2 = met.recuperer_table(req2, "eentl");

                try
                {
                    xttc1 += tmp2.Tables[0].Rows[0].Field<Decimal>("totalttc");
                }
                catch { }


                string req3 = "Select Sum(totalttc) as totalttc from eentvc where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codec='" + textBoxX1.Text + "'";
                DataSet tmp3 = met.recuperer_table(req3, "eentvc");

                try
                {
                    xavr += tmp3.Tables[0].Rows[0].Field<Decimal>("totalttc");
                }
                catch { }


                string req4 = "Select Sum(mont) as mont from eregc where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codec='" + textBoxX1.Text + "'";
                DataSet tmp4 = met.recuperer_table(req4, "eregc");

                try
                {
                    xreg += tmp4.Tables[0].Rows[0].Field<Decimal>("mont");
                }
                catch { }


                String req5 = "Update Client Set debit = " + (xttc + xttc1)
                       + ", credit = " + xreg
                       + ", avoir   = " + xavr
                       + ", solde   = " + ((xsld1 + xttc + xttc1) - (xavr + xreg))
                       + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and code='" + textBoxX1.Text + "'";

                met.Execute(req5);

                progressBarX1.Value++;
            }

            string reqr = "Select ID,code,libelle,taux from rep where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' order by code ";
            ds = met.recuperer_table(reqr, "rep");
            progressBarX1.Maximum = (ds.Tables["rep"].Rows.Count)/3;
            foreach (DataRow dr in ds.Tables["rep"].Rows)
            {
                decimal xven = 0, xven1 = 0;
                double xtaux = 0, xcom = 0;

                textBoxX1.Text = dr.Field<string>("code");
                textBoxX2.Text = dr.Field<string>("libelle");
                label1.Text = "Représentant";
                this.Update();

                try
                {
                    xtaux = dr.Field<double>("taux");
                }
                catch { }



                string req1 = "Select Sum(totalht) as totalht from eentc where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and coder='" + textBoxX1.Text + "' ";
                DataSet tmp1 = met.recuperer_table(req1, "eentc");

                try
                {
                    xven += tmp1.Tables[0].Rows[0].Field<Decimal>("totalht");
                }
                catch { }


                string req2 = "Select Sum(totalht) as totalht from eentl where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and coder='" + textBoxX1.Text + "' and facture = false ";
                DataSet tmp2 = met.recuperer_table(req2, "eentl");

                try
                {
                    xven1 += tmp2.Tables[0].Rows[0].Field<Decimal>("totalht");
                }
                catch { }



                xcom = (double)(xven + xven1) * (xtaux / 100);
                String req5 = "Update rep Set vente = " + (xven + xven1)
                       + ", com = " + xcom
                       + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and code='" + textBoxX1.Text + "'";

                met.Execute(req5);
              
                progressBarX1.Value++;
            }
            

            string reqf = "Select ID,code,libelle,solde1 from four where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' order by code ";
            ds = met.recuperer_table(reqf, "four");
            progressBarX1.Maximum += (ds.Tables["four"].Rows.Count) / 3;
            foreach (DataRow dr in ds.Tables["four"].Rows)
            {
                decimal wreg = 0, wttc = 0, wavr = 0, wttc1 = 0, wsld1 = 0;

                textBoxX1.Text = dr.Field<string>("code");
                textBoxX2.Text = dr.Field<string>("libelle");
                label1.Text = "Fournisseur";
                this.Update();

                try
                {
                    wsld1 = dr.Field<Decimal>("solde1");
                }
                catch { }



                string req1 = "Select Sum(totalttc) as totalttc from eentf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codec='" + textBoxX1.Text + "' ";
                DataSet tmp1 = met.recuperer_table(req1, "eentf");

                try
                {
                    wttc += tmp1.Tables[0].Rows[0].Field<Decimal>("totalttc");
                }
                catch { }



                string req2 = "Select Sum(totalttc) as totalttc from eente where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codec='" + textBoxX1.Text + "' and facture = false ";
                DataSet tmp2 = met.recuperer_table(req2, "eente");

                try
                {
                    wttc1 += tmp2.Tables[0].Rows[0].Field<Decimal>("totalttc");
                }
                catch { }



                string req3 = "Select Sum(totalttc) as totalttc from eentvf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codec='" + textBoxX1.Text + "'";
                DataSet tmp3 = met.recuperer_table(req3, "eentvf");

                try
                {
                    wavr += tmp3.Tables[0].Rows[0].Field<Decimal>("totalttc");
                }
                catch { }


                string req4 = "Select Sum(mont) as mont from eregf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codec='" + textBoxX1.Text + "'";
                DataSet tmp4 = met.recuperer_table(req4, "eregf");

                try
                {
                    wreg += tmp4.Tables[0].Rows[0].Field<Decimal>("mont");
                }
                catch { }



                String req5 = "Update four Set debit = " + (wttc + wttc1)
                       + ", credit = " + wreg
                       + ", avoir   = " + wavr
                       + ", solde   = " + ((wsld1 + wttc + wttc1) - (wavr + wreg))
                       + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and code='" + textBoxX1.Text + "'";

                met.Execute(req5);
                

                progressBarX1.Value++;
            }

            // Retour Montant avoir & montant reglement a 0 pour facture client
            string req10 = "Select montavr,montreg from eentc where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
            DataSet tmp10 = met.recuperer_table(req10, "eentc");
            foreach (DataRow dr3 in tmp10.Tables["eentc"].Rows)
            {
                                            

                String req5 = "Update eentc Set MONTAVR = " + zmnt
                         + ", montreg = " + zmnt
                         + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
                met.Execute(req5);
            }

            // Retour Montant avoir & montant reglement a 0 pour facture fournisseur
            string req11 = "Select montavr,montreg from eentf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
            DataSet tmp11 = met.recuperer_table(req11, "eentf");
            foreach (DataRow dr3 in tmp11.Tables["eentf"].Rows)
            {


                String req5 = "Update eentf Set MONTAVR = " + zmnt
                         + ", montreg = " + zmnt
                         + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
                met.Execute(req5);
            }

            // calcul Montant avoir  pour facture client
            string req6 = "Select totalttc,nfact from eentvc where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
            DataSet tmp6 = met.recuperer_table(req6, "eentvc");
            foreach (DataRow dr3 in tmp6.Tables["eentvc"].Rows)
            {

                xnfact = dr3.Field<string>("nfact");
                try
                {
                    zmnt = dr3.Field<Decimal>("totalttc");
                }
                catch { }

                String req5 = "Update eentc Set MONTAVR = " + zmnt
                       + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and num ='" + xnfact + "'";
                met.Execute(req5);
               
            }
            // calcul Montant reglement  pour facture client
            string req17 = "Select num from eentc where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
            DataSet tmp17 = met.recuperer_table(req17, "eentc");
            decimal wzmnt = 0;
            foreach (DataRow dr3 in tmp17.Tables["eentc"].Rows)
            {
                xnfact = dr3.Field<string>("num");

                string req7 = "Select mont,nfact from lregc where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and nfact ='" + xnfact + "'";
                DataSet tmp7 = met.recuperer_table(req7, "lregc");

                foreach (DataRow dr2 in tmp7.Tables["lregc"].Rows)
                {

                    try
                    {
                        wzmnt  += dr2.Field<Decimal>("mont");
                    }
                    catch { }

                   

                }

                 String req5 = "Update eentc Set MONTREG = " + wzmnt
                           + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and num ='" + xnfact + "'";
                 met.Execute(req5);
                 wzmnt = 0;
            }
            // calcul Montant avoir  pour facture fournisseur
            string req8 = "Select totalttc,nfact from eentvf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
            DataSet tmp8 = met.recuperer_table(req8, "eentvf");
            foreach (DataRow dr3 in tmp8.Tables["eentvf"].Rows)
            {

                xnfact = dr3.Field<string>("nfact");
                try
                {
                    zmnt = dr3.Field<Decimal>("totalttc");
                }
                catch { }

                String req5 = "Update eentf Set MONTAVR = " + zmnt
                       + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and num ='" + xnfact + "'";
                met.Execute(req5);
              
            }
            // calcul Montant reglement  pour facture fournisseur
            string req19 = "Select num from eentf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
            DataSet tmp19 = met.recuperer_table(req19, "eentf");
            decimal zzmnt = 0;
            foreach (DataRow dr3 in tmp19.Tables["eentf"].Rows)
            {
                xnfact = dr3.Field<string>("num");

                string req7 = "Select mont,nfact from lregf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and nfact ='" + xnfact + "'";
                DataSet tmp7 = met.recuperer_table(req7, "lregf");

                foreach (DataRow dr2 in tmp7.Tables["lregf"].Rows)
                {

                    try
                    {
                        zzmnt += dr2.Field<Decimal>("mont");
                    }
                    catch { }



                }

                String req5 = "Update eentf Set MONTREG = " + zzmnt
                          + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and num ='" + xnfact + "'";
                met.Execute(req5);
                zzmnt = 0;
            }

            //calcul  solde facture client
            string req12 = "Select num,totalttc,montavr,montreg,reste from eentc where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
            DataSet tmp12 = met.recuperer_table(req12, "eentc");
            foreach (DataRow dr3 in tmp12.Tables["eentc"].Rows)
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

                String req5 = "Update eentc Set reste = " + ((zttc-(zavr+zreg)))
                       + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'  and num ='" + xnfact + "'";
                met.Execute(req5);
               
            }



            //calcul  solde facture fournisseur
            string req13 = "Select num,totalttc,montavr,montreg,reste from eentf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
            DataSet tmp13 = met.recuperer_table(req13, "eentf");
            foreach (DataRow dr3 in tmp13.Tables["eentf"].Rows)
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

                String req5 = "Update eentf Set reste = " + ((zttc - (zavr + zreg)))
                       + " Where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'  and num ='" + xnfact + "'";
                met.Execute(req5);
                
            }
           
           
            MessageBox.Show("Organisation effectuée");
            progressBarX1.Visible = false;
            textBoxX1.Text = "";
            textBoxX2.Text = "";
            label1.Text = "";
        }

      

        private void orgdonne_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

     }
}
