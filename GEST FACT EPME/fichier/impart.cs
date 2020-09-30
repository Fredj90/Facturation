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
    public partial class impart : DevComponents.DotNetBar.Office2007Form
    {
        metier met = Program.met;
        DataSet ds;
        string xtrie = "";

        public impart()
        {
            InitializeComponent();
        }

        private void impart_Load(object sender, EventArgs e)
        {
            String req2 = "SELECT * FROM famillearticle where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
            ds = met.recuperer_table(req2, "famillearticle");
            BindingSource bs2 = new BindingSource(ds, "famillearticle");

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

                sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' order by code";
                met.recuperer_table(sql, ds, "client");

              

                if (xtrie == "code")
                {
                    sql = "select distinct t.* from tarif t, article a where t.codes='" + Program.Societe + "' and t.codee = '" + Program.Exercice + "'  AND a.`codes`=t.`codes`  AND t.`codee`=a.`codee`  AND a.`code`=t.`Codea` order by t.codea";
                    met.recuperer_table(sql, ds, "tarif");

                    if (cmbsec.SelectedIndex == -1)
                        sql = "select * from article where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' order by code";
                    else
                        sql = "select * from article where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef ='" + cmbsec.SelectedValue + "' order by code";

                }
                else if (xtrie == "nom")
                {
                    sql = "select distinct t.* from tarif t, article a where t.codes='" + Program.Societe + "' and t.codee = '" + Program.Exercice + "'  AND a.`codes`=t.`codes`  AND t.`codee`=a.`codee`  AND a.`code`=t.`Codea` order by a.libelle";
                    met.recuperer_table(sql, ds, "tarif");

                    if (cmbsec.SelectedIndex == -1)
                        sql = "select * from article where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' order by libelle";
                    else
                        sql = "select * from article where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef ='" + cmbsec.SelectedValue + "' order by libelle";

                }
                else
                {
                    sql = "select distinct  t.* from tarif t, article a where t.codes='" + Program.Societe + "' and t.codee = '" + Program.Exercice + "'  AND a.`codes`=t.`codes`  AND t.`codee`=a.`codee`  AND a.`code`=t.`Codea` order by t.codea";
                    met.recuperer_table(sql, ds, "tarif");
                    if (cmbsec.SelectedIndex == -1)
                        sql = "select * from article where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' order by code";
                    else
                        sql = "select * from article where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef ='" + cmbsec.SelectedValue + "' order by code";
                }
                met.recuperer_table(sql, ds, "article");

                if (codec.Text == "")
                {
                    sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' order by code";
                    met.recuperer_table(sql, ds, "client");
                }
                else
                {
                    sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code = '" + codec.Text + "' order by code";
                    met.recuperer_table(sql, ds, "client");
                }

              

                if (codec.Text == "")
                {
                    EPME.fichier.Ilisteart ij = new EPME.fichier.Ilisteart();
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
                else
                {
                    EPME.fichier.Ilisteartcli ij = new EPME.fichier.Ilisteartcli();
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

        private void codec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox1.Focus();
            else if (e.KeyCode == Keys.Enter)
                listBox1_DoubleClick(sender, e);
        }

        private void codec_TextChanged(object sender, EventArgs e)
        {
            if (codec.Text.Trim() != "")
            {
                string sql = "select distinct ID,code,libelle from client where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code like '%" + codec.Text + "%'";
                ds = met.recuperer_table(sql, "client");
                listBox1.Items.Clear();
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables["Client"].Rows)
                    {
                        listBox1.Items.Add(dr["libelle"]);

                    }
                    if (listBox1.Items.Count != 0)
                    {
                        listBox1.SelectedIndex = 0;
                        listBox1.Visible = true;
                    }
                    else
                        listBox1.Visible = false;
                }
            }
        }

        private void nomc_TextChanged(object sender, EventArgs e)
        {

            if (nomc.Text.Trim() != "")
            {


                string sql = "select distinct ID,code,libelle from client where  codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and libelle like '%" + nomc.Text + "%'";
                ds = met.recuperer_table(sql, "client");
                listBox1.Items.Clear();
                foreach (DataRow dr in ds.Tables["client"].Rows)
                {
                    listBox1.Items.Add(dr["libelle"]);
                }
                if (listBox1.Items.Count != 0)
                {
                    listBox1.SelectedIndex = 0;
                    listBox1.Visible = true;
                }
                else
                    listBox1.Visible = false;

            }
            else
            {
                listBox1.Visible = false;

            }
        }

        private void nomc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox1.Focus();
            else if (e.KeyCode == Keys.Enter)
                listBox1_DoubleClick(sender, e);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex != -1)
            {

                codec.Text = ds.Tables["Client"].Rows[listBox1.SelectedIndex].Field<string>("code");
                nomc.Text = ds.Tables["Client"].Rows[listBox1.SelectedIndex].Field<string>("libelle");
                listBox1.Visible = false;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                listBox1_DoubleClick(sender, e);
        }


    }
}
