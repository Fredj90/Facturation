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
    public partial class pnumste : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        DataSet ds;
        int index = 0;

        public pnumste()
        {
            InitializeComponent();
            buttonX1.Visible = true;
        }
        private void affiche()
        {


            t1.Text = ds.Tables[0].Rows[index].Field<Object>("dfacture") + " ";
            t2.Text = ds.Tables[0].Rows[index].Field<Object>("facture") + " ";
            t5.Text = ds.Tables[0].Rows[index].Field<Object>("codeclient") + " ";
           
           
        }


        private void pnumste_Load(object sender, EventArgs e)
        {
            String req = "SELECT * FROM pnumste where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "'";
            ds = met.recuperer_table(req, "pnumste");
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
                String req = "Update pnumste Set dfacture = '" + t1.Text
                            + "', facture = '" + t2.Text
                            + "', codeclient = '" + t5.Text
                            + "' Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];

                if (met.Execute(req))
                    MessageBox.Show("Sauvgarde effectué");

                pnumste_Load(sender, e);
                this.buttonX1.Focus();
            }
            else
            {
                MessageBox.Show("Accés Non Autorisé");
            }
        }

        private void pnumste_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}

