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
    public partial class param : DevComponents.DotNetBar.Office2007Form
    {
        metier met = Program.met;
        public int code;
        public string table, champs, xtype = "";
        Boolean modif = false;
        public string xcodep;
        DataSet ds, ds1;
        int index = 0;
        public int num, xnum;

        public param()
        {
            InitializeComponent();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            modif = false;
            buttonX5.Visible = false;
            buttonX1.Visible = true;
            buttonX2.Visible = true;
       
            mytext1.ReadOnly = false;
            mytext2.ReadOnly = false;
            mytext2.Text = "";
            mygrid1.Enabled = false;

            String req1 = "SELECT * FROM pnumste where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
            ds1 = met.recuperer_table(req1, "pnumste");
            if (ds1 != null)
                if (ds1.Tables.Count != 0)
                {
                    if (ds1.Tables[0].Rows.Count != 0)
                    {
                        index = ds1.Tables[0].Rows.Count - 1;

                    }
                }


            increment();
           
            mytext2.Focus();

        }

        private void increment()
        {

            string s2 = ds1.Tables[0].Rows[index].Field<Object>(champs) + "";
            num = int.Parse(s2);
            num++;
            string s = num.ToString().Trim();
            int l1 = s2.Trim().Length;
            int l2 = s.Length;
            for (int i = l2; i < l1; i++)
                s = "0" + s;
            mytext1.Text = s;
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            // Bouton Modifier
            modif = true;
            buttonX5.Visible = false;
            buttonX1.Visible = true;
            buttonX2.Visible = true;
         
            mytext1.ReadOnly = false;
            mytext2.ReadOnly = false;
            mygrid1.Enabled = false;

            mytext2.Focus();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (mygrid1.SelectedRows != null)
                if (mygrid1.SelectedRows.Count != 0)
                {
                    Boolean test = true;
                    if (table == "familleclient")
                    {
                        String req2 = "SELECT codef FROM client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codef='" + mytext1.Text + "' ";
                        DataSet ds2 = met.recuperer_table(req2, "client");
                        if (ds2 != null)
                            if (ds2.Tables["client"].Rows.Count != 0)
                            {
                                test = false;
                            }

                    }

                    if (table == "famillefour")
                    {
                        String req2 = "SELECT codef FROM four where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codef='" + mytext1.Text + "' ";
                        DataSet ds2 = met.recuperer_table(req2, "four");
                        if (ds2 != null)
                            if (ds2.Tables["four"].Rows.Count != 0)
                            {
                                test = false;
                            }

                    }

                    if (table == "famillearticle")
                    {
                        String req2 = "SELECT codef FROM article where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codef='" + mytext1.Text + "' ";
                        DataSet ds2 = met.recuperer_table(req2, "article");
                        if (ds2 != null)
                            if (ds2.Tables["article"].Rows.Count != 0)
                            {
                                test = false;
                            }

                    }

                    if (table == "region")
                    {
                        String req2 = "SELECT coder FROM client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and coder='" + mytext1.Text + "' ";
                        DataSet ds2 = met.recuperer_table(req2, "client");
                        if (ds2 != null)
                            if (ds2.Tables["client"].Rows.Count != 0)
                            {
                                test = false;
                            }

                    }

                    if (test)
                    {
                        String msg = MessageBox.Show("Vous êtes Sur de supprimer ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                        if (msg.Equals("Yes"))
                        {
                            String sql = "DELETE FROM " + table + " WHERE ID = " + mygrid1.SelectedRows[0].Cells["c1"].Value;
                            met.Execute(sql);


                            int ind = mygrid1.SelectedRows[0].Index;
                            load_data();
                            if (mygrid1.Rows.Count != 0)
                            {
                                if (ind < mygrid1.Rows.Count)
                                {
                                    mygrid1.CurrentCell = mygrid1.Rows[ind].Cells[1];
                                    mygrid1.Rows[ind].Selected = true;
                                }
                                else
                                {
                                    ind = mygrid1.Rows.Count - 1;
                                    mygrid1.CurrentCell = mygrid1.Rows[ind].Cells[1];
                                    mygrid1.Rows[ind].Selected = true;
                                }
                            }

                            dgv_click();
                            buttonX1_Click(sender, e);
                            MessageBox.Show("Suppression avec succée");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Suppression Impossible, " + table + " Utilisée");
                    }
                }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            buttonX5.Visible = true;
            buttonX1.Visible = false;
            buttonX2.Visible = false;
           

           
            mytext1.ReadOnly = true;
            mytext2.ReadOnly = true;
           
            mygrid1.Enabled = true;
            dgv_click();
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            String msg = MessageBox.Show("Ete-vous sur", "Sortir", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (msg.Equals("Yes"))
            {
                this.Close();
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            buttonX5.Visible = true;
            buttonX1.Visible = false;
            buttonX2.Visible = false;
          
        }


        private void rimp_Load(object sender, EventArgs e)
        {
            Program.desTfunction(this);

            load_data();
            if (mygrid1.Rows.Count != 0)
                mygrid1.Rows[0].Selected = true;
            dgv_click();
        }

        private void load_data()
        {
            String sql = "SELECT ID,code,libelle FROM " + table + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  order by code";
            DataSet ds = met.recuperer_table(sql, table);
            try
            {
                mygrid1.DataSource = ds.Tables[table].DefaultView;
            }
            catch { }


        }

        private void dgv_click()
        {
            if (mygrid1.SelectedRows != null)
                if (mygrid1.SelectedRows.Count != 0)
                {

                    mytext1.Text = mygrid1.SelectedRows[0].Cells["c0"].Value.ToString();
                    mytext2.Text = mygrid1.SelectedRows[0].Cells["c3"].Value.ToString();
                  


                }
        }






        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (!modif)
            {
                if (superValidator1.Validate())
                {
                    String req = "INSERT INTO " + table + "(codes,codee,code,libelle) Values ('" + Program.Societe + "','" + Program.Exercice + "','" + mytext1.Text + "', '" + mytext2.Text + "')";
                    met.Execute(req);

                    String req2 = "SELECT * FROM pnumste where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
                    ds = met.recuperer_table(req2, "pnumste");
                    string s2 = ds.Tables[0].Rows[index].Field<Object>(champs) + "";
                    String snum = mytext1.Text;
                    int anum = int.Parse(snum);
                    xnum = int.Parse(s2);
                    xnum++;
                    if (anum >= xnum)
                    {
                        string s = anum.ToString().Trim();
                        int l1 = s2.Trim().Length;
                        int l2 = s.Length;
                        for (int ii = l2; ii < l1; ii++)
                            s = "0" + s;
                        string sqlinc = "UPDATE pnumste SET " + champs + " = '" + s + "' where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
                        met.Execute(sqlinc);
                    }
                   
                

                    load_data();
                    if (mygrid1.Rows.Count != 0)
                    {
                        mygrid1.CurrentCell = mygrid1.Rows[mygrid1.Rows.Count - 1].Cells[1];
                        mygrid1.Rows[mygrid1.Rows.Count - 1].Selected = true;
                    }
                    dgv_click();
                    buttonX1_Click(sender, e);


                }
            }
            else
            {
                if (superValidator1.Validate())
                {
                    String req = "Update " + table + " Set codes='" + Program.Societe + "',codee='" + Program.Exercice + "',code = '" + mytext1.Text + "', libelle = '" + mytext2.Text + "' WHERE ID = " + mygrid1.SelectedRows[0].Cells["c1"].Value;
                    met.Execute(req);
                    int ind = mygrid1.SelectedRows[0].Index;
                    load_data();
                    if (mygrid1.Rows.Count != 0)
                    {
                        mygrid1.CurrentCell = mygrid1.Rows[ind].Cells[1];
                        mygrid1.Rows[ind].Selected = true;
                    }
                    dgv_click();
                    buttonX1_Click(sender, e);

                }
            }

           
        }

        private void mygrid1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgv_click();
        }

        private void mygrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_click();
        }

        private void mygrid1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void rimp_KeyDown(object sender, KeyEventArgs e)
        {
            //////////////
            switch (e.KeyCode)
            {

                case Keys.Escape:
                    String msg = MessageBox.Show("Ete-vous sur", "Sortir", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                    if (msg.Equals("Yes"))
                    {
                        this.Close();
                    }
                    break;

                case Keys.F5:
                    {
                        buttonItem1_Click(sender, e);
                    }
                    break;

                case Keys.F6:
                    {
                        buttonItem2_Click(sender, e);
                    }
                    break;

                case Keys.F7:
                    {
                        buttonItem3_Click(sender, e);
                    }
                    break;

                case Keys.F10:
                    {
                      
                            buttonX9_Click(sender, e);
                    }
                    break;


                default:
                    // actions_sinon;
                    break;
            }

        }

        private void mygrid1_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

      
        private void param_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

       

       

    }
}
