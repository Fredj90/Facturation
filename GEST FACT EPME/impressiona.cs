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
    public partial class impressiona : System.Windows.Forms.Form
    {
        metier met = Program.met;
        DataSet ds;

        public String Nmvt;
        public String ent;
        public string lent;
        public string numero;
        public string typedition ;
        string xmodele = "";

         private void impressiona_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        public impressiona(String ent,string lent, String Nmvt,string numero,string typedition)
        {
            this.ent = ent;
            this.lent = lent;
            this.Nmvt = Nmvt;
            this.numero= numero;
            this.typedition = typedition;

            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX3_Click(object sender, EventArgs e)
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

                sql = "select * from " + ent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num ='" + Nmvt + "'";
                met.recuperer_table(sql, ds, "eentf");

                

                sql = "select * from " + lent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num ='" + Nmvt + "'";
                met.recuperer_table(sql, ds, "lentl");

                sql = "select * from four where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  order by code";
                met.recuperer_table(sql, ds, "client");

                sql = "SELECT * FROM sarticle  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
                met.recuperer_table(sql, ds, "sarticle");

                sql = "SELECT * FROM gamme  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
                met.recuperer_table(sql, ds, "gamme");

                sql = "SELECT * FROM article WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
                met.recuperer_table(sql, ds, "article");

                if (xmodele == "PO" || xmodele == "")
                {

                    if (typedition == "E" || typedition == "C")
                    {

                        EPME.rptedit.Ieditent ij = new EPME.rptedit.Ieditent();
                        ij.numero = numero;
                        ij.ds = ds;
                        ij.ShowDialog();


                    }
                    else if (typedition == "F")
                    {
                        EPME.rptedit.Ieditfactf ij = new EPME.rptedit.Ieditfactf();
                        ij.numero = numero;
                        ij.ds = ds;
                        ij.ShowDialog();
                    }
                    else if (typedition == "L")
                    {
                        sql = "select * from eente where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num in(select numl from nbefacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "')";
                        met.recuperer_table(sql, ds, "eentl");

                        sql = "select * from nbefacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "'";
                        met.recuperer_table(sql, ds, "nbefacture");

                        sql = "select * from " + lent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num in(select numl from nbefacture where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and numf ='" + Nmvt + "')";
                        met.recuperer_table(sql, ds, "lentl");
                        EPME.rptedit.Ieditfactfbl ij = new EPME.rptedit.Ieditfactfbl();
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

        private void rbord_CheckedChanged(object sender, EventArgs e)
        {
            xmodele = "PO";
        }

        private void rbpimp_CheckedChanged(object sender, EventArgs e)
        {
            xmodele = "PP";
        }

    }
}
