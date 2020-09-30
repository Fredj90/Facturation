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
    public partial class orgstk : DevComponents.DotNetBar.Office2007Form
    {

        private metier met = Program.met;

        DataSet ds,ds4;
        public orgstk()
        {
            InitializeComponent();
            buttonX9.Visible = false;
        }

        private void orgstk_Load(object sender, EventArgs e)
        {
            string req3 = "select code,libelle from famillearticle where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' ";
            DataSet ds3 = met.recuperer_table(req3, "famillearticle");
            mygrid1.DataSource = ds3.Tables["famillearticle"].DefaultView;

           
            libelled.DisplayMember = "libelle";
            libelled.ValueMember = "code";

            string sql1 = "select * from depot where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem = '" + Program.Magasin + "'";
            DataSet dsa1 = met.recuperer_table(sql1, "depot");
            BindingSource bs1 = new BindingSource(dsa1, "depot");
            libelled.DataSource = bs1;
            libelled.DataPropertyName = "coded";


        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
          
            {


                buttonX2.Visible = true;
                buttonX1.Visible = false;
                buttonX3.Visible = true;
                buttonX4.Visible = false;
                buttonX9.Visible = true;
                string req4 = "select code,libelle,ID from article where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' ";
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
                ds4 = met.recuperer_table(req4, "article");
                mygrid2.DataSource = ds4.Tables["article"].DefaultView;
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

        private void orgstk_FormClosed(object sender, FormClosedEventArgs e)
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

                string req4 = "select code,libelle,ID from article where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
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
                    ds4 = met.recuperer_table(req4, "article");
                    mygrid2.DataSource = ds4.Tables["article"].DefaultView;
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
               

                progressBarX1.Value = 0;
                progressBarX1.Visible = true;
                foreach (DataGridViewRow dgr in mygrid2.Rows)
                {
                    progressBarX1.Maximum = mygrid2.Rows.Count;

                    if (dgr.Cells["choixp"].Value != null)
                    {
                        if ((Boolean)dgr.Cells["choixp"].Value)
                        {
                            double xqtedep = 0, xstk = 0;
                            Double xqteavrc = 0, xqteavrf = 0, xqtesor = 0, xqteent = 0;
                           
                          
                            string req1 = "";

                            string xcode = dgr.Cells["codea"].Value + "";


                            ////// Article Magasin

                            req1 = "SELECT codea,qtedep,qteent,qtesor,qteavrc,qteavrf,qtestk FROM artmag WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "'  and codea ='" + xcode + "' ";
                            ds = met.recuperer_table(req1, "artmag");
                            if (ds != null)
                            {
                                if (ds.Tables.Count != 0)
                                {
                                    if (ds.Tables[0].Rows.Count != 0)
                                    {
                                        foreach (DataRow dr in ds.Tables["artmag"].Rows)
                                        {
                                            try
                                            {
                                                xqtedep += dr.Field<double>("qtedep");
                                            }
                                            catch { }

                                            try
                                            {
                                                xqteavrc += dr.Field<double>("qteavrc");
                                            }
                                            catch { }

                                            try
                                            {
                                                xqteavrf += dr.Field<double>("qteavrf");
                                            }
                                            catch { }
                                            try
                                            {
                                                xqteent += dr.Field<double>("qteent");
                                            }
                                            catch { }
                                            try
                                            {
                                                xqtesor += dr.Field<double>("qtesor");
                                            }
                                            catch { }
                                            try
                                            {
                                                xstk += dr.Field<double>("qtestk");
                                            }
                                            catch { }
                                        }

                                        //// Sauvegarde Article Societe


                                        String reqt1 = "Update article set qteent = " + xqteent.ToString().Replace(Program.sep, string.Empty)
                                                      + ",qteavrc=" + xqteavrc.ToString().Replace(Program.sep, string.Empty)
                                                      + ",qtesor=" + xqtesor.ToString().Replace(Program.sep, string.Empty)
                                                      + ",qteavrf=" + xqteavrf.ToString().Replace(Program.sep, string.Empty)
                                                      + ",qtestk=" + xstk.ToString().Replace(Program.sep, string.Empty)
                                                      + ",qtedep=" + xqtedep.ToString().Replace(Program.sep, string.Empty)
                                                      + " Where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code = '" + xcode + "' ";
                                        met.Execute(reqt1);
                                    }
                                }
                            }
                        }
                    }
                    progressBarX1.Value++;
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
            Rechart form = new Rechart();
            form.table = "article";
            form.ShowDialog();
            form.textBoxX7.Focus();
            if (form.code != 0)
            {
                List<DataColumn> lis = new List<DataColumn>();
                lis.Add(ds4.Tables["article"].Columns["ID"]);
                ds4.Tables["article"].PrimaryKey = lis.ToArray();
                DataRow[] dr = ds4.Tables["article"].Select("ID = '" + form.code + "'");
                if (dr.Length != 0)
                {
                    int i = ds4.Tables[0].Rows.IndexOf(dr[0]);
                    mygrid2.Rows[i].Selected = true;
                }
            }
        }

       

    }
}
