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
    public partial class impfour : DevComponents.DotNetBar.Office2007Form
    {
        metier met = Program.met;
        DataSet ds;
        string xtrie = "";

        public impfour()
        {
            InitializeComponent();
        }

        private void impfour_Load(object sender, EventArgs e)
        {
            String req2 = "SELECT * FROM famillefour where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
            ds = met.recuperer_table(req2, "famillefour");
            BindingSource bs2 = new BindingSource(ds, "famillefour");

            cmbsec.ValueMember = "Code";
            cmbsec.DisplayMember = "Libelle";
            cmbsec.DataSource = bs2;
            cmbsec.SelectedIndex = -1;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (!Program.ISAret)
            {
                string sql = "select * from exercice where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
                met.recuperer_table(sql, ds, "exercice");

                sql = "select * from ste where code='" + Program.Societe + "'";
                met.recuperer_table(sql, ds, "ste");

                sql = "select * from magasin where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code = '" + Program.Magasin + "'";
                met.recuperer_table(sql, ds, "magasin");

                if (xtrie == "code")
                {
                    if (cmbsec.SelectedIndex == -1)
                        sql = "select * from four where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' order by code";
                    else
                        sql = "select * from four where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef ='" + cmbsec.SelectedValue + "' order by code";
                   
                }
                else if (xtrie == "nom")
                {
                    if (cmbsec.SelectedIndex == -1)
                        sql = "select * from four where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' order by libelle";
                    else
                        sql = "select * from four where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef ='" + cmbsec.SelectedValue + "' order by libelle";
                   
                }
                else
                {
                    if (cmbsec.SelectedIndex == -1)
                        sql = "select * from four where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' order by code";
                    else
                        sql = "select * from four where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef ='" + cmbsec.SelectedValue + "' order by code";
                }

                met.recuperer_table(sql, ds, "four");

                EPME.fichier.Ilistefour ij = new EPME.fichier.Ilistefour();
                if (cmbsec.SelectedIndex != -1)
                {
                    ij.xfamille = cmbsec.Text;
                }
                else
                {
                    ij.xfamille = "";
                }
                ij.ds = ds;
                ij.ShowDialog();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbcode_CheckedChanged(object sender, EventArgs e)
        {
            xtrie = "code";
        }

        private void rbnom_CheckedChanged(object sender, EventArgs e)
        {
            xtrie = "nom";
        }


    }
}
