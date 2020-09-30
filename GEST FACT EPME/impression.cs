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
    public partial class impression : System.Windows.Forms.Form
    {
        metier met = Program.met;
        DataSet ds;
        Boolean act = true;
        public String Nmvt;
        public String ent;
        public string lent;
        public string numero;
        public string typedition ;
        string xmodele = "";
       

        private void impression_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }
        public impression(String ent,string lent, String Nmvt,string numero,string typedition)
        {
            this.ent = ent;
            this.lent = lent;
            this.Nmvt = Nmvt;
            this.numero= numero;
            this.typedition = typedition;

            InitializeComponent();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            //if (Program.ISAret)
            {
               

                ds = new DataSet();
                string sql = "select * from exercice where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
                met.recuperer_table(sql, ds, "exercice");

                sql = "select * from ste where code='" + Program.Societe + "'";
                met.recuperer_table(sql, ds, "ste");

                sql = "SELECT * FROM entete  where codes='" + Program.Societe + "'";
                met.recuperer_table(sql, ds, "entete");

                sql = "select * from magasin where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code = '" + Program.Magasin + "'";
                met.recuperer_table(sql, ds, "magasin");

                sql = "select * from " + ent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num ='"+Nmvt+"'";
                met.recuperer_table(sql, ds, "eentl");

                sql = "select * from " + lent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num ='" + Nmvt + "'";
                met.recuperer_table(sql, ds, "lentl");

               sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  order by code";
               met.recuperer_table(sql, ds, "client");
              
               sql = "SELECT * FROM sarticle  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
               met.recuperer_table(sql, ds, "sarticle");

               sql = "SELECT * FROM gamme  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
               met.recuperer_table(sql, ds, "gamme");

               sql = "SELECT * FROM article WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
               met.recuperer_table(sql, ds, "article");

               if (!Program.ISFodec)
               {
                   if (xmodele == "PO" || xmodele=="")
                   {
                       if (typedition == "L" || typedition == "C" || typedition == "B")
                       {

                           EPME.rptedit.Ieditliv ij = new EPME.rptedit.Ieditliv();
                           ij.imprref = refart.CheckState.Equals(CheckState.Checked);
                           ij.numero = numero;
                           ij.ds = ds;
                           ij.ShowDialog();


                       }
                       else if (typedition == "F")
                       {
                           EPME.rptedit.Ieditfact ij = new EPME.rptedit.Ieditfact();
                           ij.imprref = refart.CheckState.Equals(CheckState.Checked);
                           ij.numero = numero;
                           ij.ds = ds;
                           ij.ShowDialog();
                       }
                       else if (typedition == "D")
                       {
                           EPME.rptedit.Ieditdevis ij = new EPME.rptedit.Ieditdevis();
                           ij.imprref = refart.CheckState.Equals(CheckState.Checked);
                           ij.numero = numero;
                           ij.ds = ds;
                           ij.ShowDialog();
                       }
                       else if (typedition == "FL")
                       {
                           sql = "select * from " + ent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num ='" + Nmvt + "'";
                           met.recuperer_table(sql, ds, "eentf");

                           sql = "select * from eentl where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num in(select numl from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "')";
                           met.recuperer_table(sql, ds, "eentl");

                           sql = "select * from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "'";
                           met.recuperer_table(sql, ds, "nbefacture");

                           sql = "select * from " + lent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num in(select numl from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "')";
                           met.recuperer_table(sql, ds, "lentl");
                           EPME.rptedit.Ieditfactbl ij = new EPME.rptedit.Ieditfactbl();
                           ij.imprref = refart.CheckState.Equals(CheckState.Checked);
                           ij.numero = numero;
                           ij.ds = ds;
                           ij.ShowDialog();
                       }
                       else if (typedition == "FB")
                       {
                           sql = "select * from " + ent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num ='" + Nmvt + "'";
                           met.recuperer_table(sql, ds, "eentf");

                           sql = "select * from eentcb where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num in(select numl from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "')";
                           met.recuperer_table(sql, ds, "eentl");

                           sql = "select * from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "'";
                           met.recuperer_table(sql, ds, "nbefacture");

                           sql = "select * from " + lent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num in(select numl from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "')";
                           met.recuperer_table(sql, ds, "lentl");
                           EPME.rptedit.Ieditfactbl ij = new EPME.rptedit.Ieditfactbl();
                           ij.imprref = refart.CheckState.Equals(CheckState.Checked);
                           ij.cmp = true;
                           ij.numero = numero;
                           ij.ds = ds;
                           ij.ShowDialog();
                       }
                   }
                   else
                   {
                       if (typedition == "L" || typedition == "C" || typedition == "B")
                       {

                           EPME.rptedit.preimpr.Ieditliv ij = new EPME.rptedit.preimpr.Ieditliv();
                           ij.imprref = refart.CheckState.Equals(CheckState.Checked);
                           ij.numero = numero;
                           ij.ds = ds;
                           ij.ShowDialog();


                       }
                       else if (typedition == "F")
                       {
                           EPME.rptedit.preimpr.Ieditfact ij = new EPME.rptedit.preimpr.Ieditfact();
                           ij.imprref = refart.CheckState.Equals(CheckState.Checked);
                           ij.numero = numero;
                           ij.ds = ds;
                           ij.ShowDialog();
                       }
                       else if (typedition == "D")
                       {
                           EPME.rptedit.preimpr.Ieditdevis ij = new EPME.rptedit.preimpr.Ieditdevis();
                           ij.imprref = refart.CheckState.Equals(CheckState.Checked);
                           ij.numero = numero;
                           ij.ds = ds;
                           ij.ShowDialog();
                       }
                       else if (typedition == "FL")
                       {
                           sql = "select * from " + ent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num ='" + Nmvt + "'";
                           met.recuperer_table(sql, ds, "eentf");

                           sql = "select * from eentl where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num in(select numl from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "')";
                           met.recuperer_table(sql, ds, "eentl");

                           sql = "select * from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "'";
                           met.recuperer_table(sql, ds, "nbefacture");

                           sql = "select * from " + lent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num in(select numl from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "')";
                           met.recuperer_table(sql, ds, "lentl");
                           EPME.rptedit.preimpr.Ieditfactbl ij = new EPME.rptedit.preimpr.Ieditfactbl();
                           ij.imprref = refart.CheckState.Equals(CheckState.Checked);
                           ij.numero = numero;
                           ij.ds = ds;
                           ij.ShowDialog();
                       }
                       else if (typedition == "FB")
                       {
                           sql = "select * from " + ent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num ='" + Nmvt + "'";
                           met.recuperer_table(sql, ds, "eentf");

                           sql = "select * from eentcb where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num in(select numl from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "')";
                           met.recuperer_table(sql, ds, "eentl");

                           sql = "select * from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "'";
                           met.recuperer_table(sql, ds, "nbefacture");

                           sql = "select * from " + lent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num in(select numl from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "')";
                           met.recuperer_table(sql, ds, "lentl");
                           EPME.rptedit.preimpr.Ieditfactbl ij = new EPME.rptedit.preimpr.Ieditfactbl();
                           ij.imprref = refart.CheckState.Equals(CheckState.Checked);
                           ij.cmp = true;
                           ij.numero = numero;
                           ij.ds = ds;
                           ij.ShowDialog();
                       }
                   }
               }
               else
               {
                   if (xmodele == "PO" || xmodele == "")
                   {
                       if (typedition == "L" || typedition == "C" || typedition == "B" || typedition == "D")
                       {
                           EPME.rptedit.Ieditlivfodec ij = new EPME.rptedit.Ieditlivfodec();
                           ij.numero = numero;
                           ij.imprref = refart.CheckState.Equals(CheckState.Checked);
                           ij.ds = ds;
                           ij.ShowDialog();
                       }
                       else if (typedition == "F")
                       {
                           EPME.rptedit.Ieditfactfodec ij = new EPME.rptedit.Ieditfactfodec();
                           ij.imprref = refart.CheckState.Equals(CheckState.Checked);
                           ij.numero = numero;
                           ij.ds = ds;
                           ij.ShowDialog();
                       }
                       else if (typedition == "D")
                       {
                           EPME.rptedit.Ieditdevis ij = new EPME.rptedit.Ieditdevis();
                           ij.imprref = refart.CheckState.Equals(CheckState.Checked);
                           ij.numero = numero;
                           ij.ds = ds;
                           ij.ShowDialog();
                       }
                       else if (typedition == "FL")
                       {
                           sql = "select * from " + ent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num ='" + Nmvt + "'";
                           met.recuperer_table(sql, ds, "eentf");

                           sql = "select * from eentl where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num in(select numl from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "')";
                           met.recuperer_table(sql, ds, "eentl");

                           sql = "select * from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "'";
                           met.recuperer_table(sql, ds, "nbefacture");

                           sql = "select * from " + lent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num in(select numl from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "')";
                           met.recuperer_table(sql, ds, "lentl");
                           EPME.rptedit.Ieditfactbl ij = new EPME.rptedit.Ieditfactbl();
                           ij.imprref = refart.CheckState.Equals(CheckState.Checked);
                           ij.numero = numero;
                           ij.ds = ds;
                           ij.ShowDialog();
                       }
                       else if (typedition == "FB")
                       {
                           sql = "select * from " + ent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num ='" + Nmvt + "'";
                           met.recuperer_table(sql, ds, "eentf");

                           sql = "select * from eentcb where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num in(select numl from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "')";
                           met.recuperer_table(sql, ds, "eentl");

                           sql = "select * from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "'";
                           met.recuperer_table(sql, ds, "nbefacture");

                           sql = "select * from " + lent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num in(select numl from nblfacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "')";
                           met.recuperer_table(sql, ds, "lentl");
                           EPME.rptedit.Ieditfactbl ij = new EPME.rptedit.Ieditfactbl();
                           ij.imprref = refart.CheckState.Equals(CheckState.Checked);
                           ij.cmp = true;
                           ij.numero = numero;
                           ij.ds = ds;
                           ij.ShowDialog();
                       }
                   }
                   else
                   { 
                       // préimprimé
                   }
               }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbord_CheckedChanged(object sender, EventArgs e)
        {
            xmodele = "PO";
        }

        private void rbpimp_CheckedChanged(object sender, EventArgs e)
        {
            xmodele = "PP";
        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void refart_CheckedChanged(object sender, EventArgs e)
        {
            if (act)
            {
                act = false;
                refart.Checked = !refart.Checked;
                act = true;
            }
        }

       
    }
}
