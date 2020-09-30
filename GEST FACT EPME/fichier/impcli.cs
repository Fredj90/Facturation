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
    public partial class impcli : DevComponents.DotNetBar.Office2007Form
    {
        metier met = Program.met;
        DataSet ds;
        string xtrie = "";
        Boolean act = false;
        public impcli()
        {
            InitializeComponent();
        }

        private void impcli_Load(object sender, EventArgs e)
        {
            act = true;
            string req0 = "Select  * from Region  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
            DataSet ds0 = met.recuperer_table(req0, "Region");
            BindingSource bs0 = new BindingSource(ds0, "Region");
            cmbreg.ValueMember = "Code";
            cmbreg.DisplayMember = "Libelle";
            cmbreg.DataSource = bs0;


            string req3 = "Select  * from secteur  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
            DataSet ds3 = met.recuperer_table(req3, "secteur");
            BindingSource bs3 = new BindingSource(ds3, "secteur");
            cmbs.ValueMember = "Code";
            cmbs.DisplayMember = "Libelle";
            cmbs.DataSource = bs3;


            String req2 = "SELECT * FROM familleclient where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
            ds = met.recuperer_table(req2, "familleclient");
            BindingSource bs2 = new BindingSource(ds, "familleclient");

            cmbsec.ValueMember = "Code";
            cmbsec.DisplayMember = "Libelle";
            cmbsec.DataSource = bs2;
            cmbreg.SelectedIndex = -1;
            cmbs.SelectedIndex = -1;
            cmbsec.SelectedIndex = -1;
            act = false;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (!Program.ISAret)
            {
                string sql = "select * from exercice where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
                met.recuperer_table(sql, ds, "exercice");

                sql = "select * from ste where code='" + Program.Societe + "'";
                met.recuperer_table(sql, ds, "ste");

                if (xtrie == "code")
                {
                    if (cmbreg.SelectedIndex == -1)
                    {
                        cmbs.SelectedIndex = -1;
                        if (cmbsec.SelectedIndex == -1)
                            sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' order by code";
                        else
                            sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef ='" + cmbsec.SelectedValue + "' order by code";

                    }
                    else
                    {
                        if (cmbs.SelectedIndex == -1)
                        {
                            if (cmbsec.SelectedIndex == -1)
                                sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and coder = '" + cmbreg.SelectedValue + "' order by code";
                            else
                                sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef ='" + cmbsec.SelectedValue + "' and coder = '" + cmbreg.SelectedValue + "' order by code";
                        }
                        else
                        {
                            if (cmbsec.SelectedIndex == -1)
                                sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and coder = '" + cmbreg.SelectedValue + "' and codesec = '" + cmbs.SelectedValue + "' order by code";
                            else
                                sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef ='" + cmbsec.SelectedValue + "' and coder = '" + cmbreg.SelectedValue + "' and codesec = '" + cmbs.SelectedValue + "' order by code";
                        }
                    }
                }
                else if (xtrie == "nom")
                {
                    if (cmbreg.SelectedIndex == -1)
                    {
                        cmbs.SelectedIndex = -1;
                        if (cmbsec.SelectedIndex == -1)
                            sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' order by libelle";
                        else
                            sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef ='" + cmbsec.SelectedValue + "' order by libelle";
                    }
                    else
                    {
                        if (cmbs.SelectedIndex == -1)
                        {
                            if (cmbsec.SelectedIndex == -1)
                                sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and coder = '" + cmbreg.SelectedValue + "' order by libelle";
                            else
                                sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef ='" + cmbsec.SelectedValue + "' and coder = '" + cmbreg.SelectedValue + "' order by libelle";
                        }

                        else
                        {
                           
                                if (cmbsec.SelectedIndex == -1)
                                    sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and coder = '" + cmbreg.SelectedValue + "' and codesec = '" + cmbs.SelectedValue + "' order by libelle";
                                else
                                    sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef ='" + cmbsec.SelectedValue + "' and coder = '" + cmbreg.SelectedValue + "' and codesec = '" + cmbs.SelectedValue + "' order by libelle";
                            
                        }
                    }
                }
                else
                {
                    if (cmbreg.SelectedIndex == -1)
                    {
                        cmbs.SelectedIndex = -1;
                        if (cmbsec.SelectedIndex == -1)
                            sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' order by code";
                        else
                            sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef ='" + cmbsec.SelectedValue + "' order by code";

                    }
                    else
                    {
                        if (cmbs.SelectedIndex == -1)
                        {
                            if (cmbsec.SelectedIndex == -1)
                                sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and coder = '" + cmbreg.SelectedValue + "' order by code";
                            else
                                sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef ='" + cmbsec.SelectedValue + "' and coder = '" + cmbreg.SelectedValue + "' order by code";
                        }
                        else
                        {
                            if (cmbsec.SelectedIndex == -1)
                                sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and coder = '" + cmbreg.SelectedValue + "' and codesec = '" + cmbs.SelectedValue + "' order by code";
                            else
                                sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef ='" + cmbsec.SelectedValue + "' and coder = '" + cmbreg.SelectedValue + "' and codesec = '" + cmbs.SelectedValue + "' order by code";
                        }
                    }
                }
               
                met.recuperer_table(sql, ds, "client");



                EPME.fichier.Ilistecli ij = new EPME.fichier.Ilistecli();
                if (cmbsec.SelectedIndex != -1)
                {
                    ij.xfamille = cmbsec.Text;
                }
                else
                {
                    ij.xfamille = "";
                }

                if (cmbreg.SelectedIndex != -1)
                {
                    ij.xregion = cmbreg.Text;
                }
                else
                {
                    ij.xregion = "";
                }

                if (cmbs.SelectedIndex != -1)
                {
                    ij.xsecteur = cmbs.Text;
                }
                else
                {
                    ij.xsecteur = "";
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

        private void cmbreg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!act)
            {
                String req7 = "SELECT * FROM secteur where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and coder = '" + cmbreg.SelectedValue + "' ";
                DataSet ds7 = met.recuperer_table(req7, "secteur");
                BindingSource bs7 = new BindingSource(ds7, "secteur");
                cmbs.ValueMember = "Code";
                cmbs.DisplayMember = "Libelle";
                cmbs.DataSource = bs7;
                cmbs.SelectedIndex = -1;
            }
        }
       

    }
}
