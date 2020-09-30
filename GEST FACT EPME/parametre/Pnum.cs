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
    public partial class Pnum : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        DataSet ds;
        int index = 0;

        public Pnum()
        {
            InitializeComponent();
            buttonX1.Visible = true;
        }
        private void affiche()
        {

           
            t1.Text = ds.Tables[0].Rows[index].Field<Object>("dlivraison") + " ";
            t2.Text = ds.Tables[0].Rows[index].Field<Object>("livraison") + " ";
            t3.Text = ds.Tables[0].Rows[index].Field<Object>("dcomande") + " ";
            t4.Text = ds.Tables[0].Rows[index].Field<Object>("comande") + " ";
            t5.Text = ds.Tables[0].Rows[index].Field<Object>("ddevis") + " ";
            t6.Text = ds.Tables[0].Rows[index].Field<Object>("devis") + " ";
            t7.Text = ds.Tables[0].Rows[index].Field<Object>("dregcli") + " ";
            t8.Text = ds.Tables[0].Rows[index].Field<Object>("regcli") + " ";
            t9.Text = ds.Tables[0].Rows[index].Field<Object>("dentre") + " ";
            t10.Text = ds.Tables[0].Rows[index].Field<Object>("entre") + " ";
            t11.Text = ds.Tables[0].Rows[index].Field<Object>("dcomandef") + " ";
            t12.Text = ds.Tables[0].Rows[index].Field<Object>("comandef") + " ";
            t13.Text = ds.Tables[0].Rows[index].Field<Object>("dregfour") + " ";
            t14.Text = ds.Tables[0].Rows[index].Field<Object>("regfour") + " ";
            t15.Text = ds.Tables[0].Rows[index].Field<Object>("dbon") + " ";
            t16.Text = ds.Tables[0].Rows[index].Field<Object>("bon") + " ";
           

        }


        private void Pnum_Load(object sender, EventArgs e)
        {
            String req = "SELECT * FROM pnum where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' AND codem='" + Program.Magasin + "'";
            ds = met.recuperer_table(req, "pnum");
            if (ds != null)
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        index = ds.Tables[0].Rows.Count - 1;
                        affiche();
                        buttonX1.Focus();

                    }
                    
                }

           
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (Program.ISSaDmin)
            {
                String req = "Update pnum Set dlivraison = '" + t1.Text
                            + "', livraison = '" + t2.Text
                            + "', dcomande = '" + t3.Text
                            + "', comande = '" + t4.Text
                            + "', ddevis = '" + t5.Text
                            + "', devis = '" + t6.Text
                            + "', dcomandef = '" + t11.Text
                            + "', comandef = '" + t12.Text
                            + "', dregcli = '" + t7.Text
                            + "', regcli = '" + t8.Text
                            + "', dentre = '" + t9.Text
                            + "', entre = '" + t10.Text
                            + "', dregfour = '" + t13.Text
                            + "', regfour = '" + t14.Text
                            + "', dbon = '" + t15.Text
                            + "', bon = '" + t16.Text
                            + "' Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];

                if (met.Execute(req))
                    MessageBox.Show("Sauvgarde effectué");

                Pnum_Load(sender, e);
                this.buttonX1.Focus();
            }
            else
            {
                MessageBox.Show("Accés Non Autorisé");
            }
        }

        private void Pnum_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
