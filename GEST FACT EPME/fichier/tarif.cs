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
    public partial class tarif : DevComponents.DotNetBar.Office2007Form
    {

        private metier met = Program.met;
        DataSet ds, ds1;
        public int wnbre = 0;
        public tarif()
        {
            InitializeComponent();
        }

        private void tarif_Load(object sender, EventArgs e)
        {
            Program.desTfunction(this);
            String req1 = "SELECT * FROM FamilleClient where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
            DataSet ds1 = met.recuperer_table(req1, "FamilleClient");
            BindingSource bs = new BindingSource(ds1, "FamilleClient");
            comboBox1.ValueMember = "Code";
            comboBox1.DisplayMember = "Libelle";
            comboBox1.DataSource = bs;

            comboBox3.ValueMember = "Code";
            comboBox3.DisplayMember = "Libelle";
            comboBox3.DataSource = bs;


            String req2 = "SELECT * FROM FamilleArticle where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
            DataSet ds2 = met.recuperer_table(req2, "FamilleArticle");
            BindingSource bs2 = new BindingSource(ds2, "FamilleArticle");
            comboBox2.ValueMember = "Code";
            comboBox2.DisplayMember = "Libelle";
            comboBox2.DataSource = bs2;

            comboBox4.ValueMember = "Code";
            comboBox4.DisplayMember = "Libelle";
            comboBox4.DataSource = bs2;

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

            libc.DisplayMember = "libelle";
            libc.ValueMember = "code";

            string sql1 = "select * from client where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' ";
            DataSet dsa1 = met.recuperer_table(sql1, "client");
            BindingSource bs1 = new BindingSource(dsa1, "client");
            libc.DataSource = bs1;
            libc.DataPropertyName = "codec";


            liba.DisplayMember = "libelle";
            liba.ValueMember = "code";
            string sql2 = "select * from article where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' ";
            DataSet dsa2 = met.recuperer_table(sql2, "article");
            BindingSource bsa2 = new BindingSource(dsa2, "article");
            liba.DataSource = bsa2;
            liba.DataPropertyName = "codea";


            String req3 = "SELECT codec,codea,qdeb,qfin,remisem,remiseq FROM tarif where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' order by codec,codea,qdeb ";
            DataSet ds3 = met.recuperer_table(req3, "tarif");
            label2.Text = ds3.Tables[0].Rows.Count.ToString();
            if (ds3 != null)
            {
                mygrid2.DataSource = ds3.Tables["tarif"].DefaultView;
                mygrid2.Columns["c8"].Visible = false;
                mygrid2.Columns["c9"].Visible = false;

            }
        }

        private void tarif_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

        private void tarif_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {


                case Keys.Escape:
                    {
                        String msg = MessageBox.Show("Ete-vous sur", "Sortir", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                        if (msg.Equals("Yes"))
                        {
                            this.Close();
                        }
                        break;
                    }


                case Keys.F1:
                    {
                        tabControl1.SelectedTab = tabItem2;
                        comboBox1.Focus();
                    }
                    break;

                case Keys.F2:
                    {
                        tabControl1.SelectedTab = tabItem6;
                        comboBox3.Focus();
                    }
                    break;

                case Keys.F3:
                    {
                        tabControl1.SelectedTab = tabItem3;
                        codec.Focus();
                    }
                    break;

                case Keys.F4:
                    {
                        tabControl1.SelectedTab = tabItem1;
                        codec1.Focus();
                    }
                    break;
                case Keys.F5:
                    {
                        tabControl1.SelectedTab = tabItem4;
                        textBoxX1.Focus();
                    }
                    break;


                default:
                    // actions_sinon;
                    break;
            }

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            //   if (comboBox1.SelectedIndex!=-1 && comboBox1.SelectedIndex!=-1 && t1.Text!="")
            if (comboBox1.SelectedIndex != -1 && comboBox1.SelectedIndex != -1)
            {



                string sqlcli = "select code from client where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef = '" + comboBox1.SelectedValue + "'";
                DataSet dscli = met.recuperer_table(sqlcli, "client");
                if (dscli != null)
                {
                    wnbre = dscli.Tables[0].Rows.Count;

                    foreach (DataRow dr in dscli.Tables["client"].Rows)
                    {
                        string xcodec = dr.Field<string>("code");

                        string sqlart = "select code from article where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef = '" + comboBox2.SelectedValue + "'";
                        DataSet dsart = met.recuperer_table(sqlart, "article");
                        if (dsart != null)
                        {

                            foreach (DataRow dr1 in dsart.Tables["article"].Rows)
                            {
                                string xcodea = dr1.Field<string>("code");


                                //Suppression 
                                String req10 = "DELETE FROM tarif where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codec = '" + xcodec + "' and codea = '" + xcodea + "'   ";
                                met.Execute(req10);

                                double xqdeb = 0, xqfin = 0, xremm = 0, xremq = 0;

                                foreach (DataGridViewRow dgr in mygrid3.Rows)
                                {
                                    if (!dgr.IsNewRow)
                                    {

                                        try
                                        {
                                            xqdeb = double.Parse(dgr.Cells["qdeb"].Value + "");
                                        }
                                        catch { }

                                        try
                                        {
                                            xqfin = double.Parse(dgr.Cells["qfin"].Value + "");
                                        }
                                        catch { }

                                        try
                                        {
                                            xremm = double.Parse(dgr.Cells["remisem"].Value + "");
                                        }
                                        catch { }

                                        try
                                        {
                                            xremq = double.Parse(dgr.Cells["remiseq"].Value + "");
                                        }
                                        catch { }


                                        //Sauvegarde
                                        String req = "INSERT INTO tarif(codes,codee,codec,codea,qdeb,qfin,remisem,remiseq,typerem) Values ('" + Program.Societe
                                                    + "','" + Program.Exercice
                                                    + "','" + xcodec
                                                    + "','" + xcodea
                                                    + "', " + xqdeb
                                                    + ", " + xqfin
                                                    + ", " + xremm
                                                    + ", " + xremq
                                                    + ", " + true
                                                    + ")";

                                        met.Execute(req);

                                        xqdeb = 0; xqfin = 0; xremm = 0; xremq = 0;
                                    }

                                }

                            }
                        }
                    }



                    String req3 = "SELECT codec,codea,qdeb,qfin,remisem,remiseq FROM tarif where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  order by codec,codea,qdeb ";
                    DataSet ds3 = met.recuperer_table(req3, "tarif");
                    label2.Text = ds3.Tables[0].Rows.Count.ToString();
                    if (ds3 != null)
                    {
                        mygrid2.DataSource = ds3.Tables["tarif"].DefaultView;
                    }

                    MessageBox.Show(wnbre + " Clients effectués ");

                    mygrid3.Rows.Clear();
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;

                }

            }
            else
                MessageBox.Show(" Selectionner Famille Clients,Articles & Saisir Remise ");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControlPanel2_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void codea_TextChanged(object sender, EventArgs e)
        {
            if (codea.Text.Trim() != "")
            {
                string sql = "select distinct ID,code,libelle from article where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code like '%" + codea.Text + "%'";
                ds = met.recuperer_table(sql, "article");
                listBox1.Items.Clear();
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables["article"].Rows)
                    {
                        listBox1.Items.Add(dr["libelle"]);

                    }
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
                listBox1.Visible = false;
        }

        private void noma_TextChanged(object sender, EventArgs e)
        {
            if (noma.Text.Trim() != "")
            {


                string sql = "select distinct ID,code,libelle from article where  codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and libelle like '%" + noma.Text + "%'";
                ds = met.recuperer_table(sql, "article");
                listBox1.Items.Clear();
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables["article"].Rows)
                    {
                        listBox1.Items.Add(dr["libelle"]);
                    }
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

        private void noma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox1.Focus();
            else if (e.KeyCode == Keys.Enter)
                listBox1_DoubleClick(sender, e);
        }

        private void codea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox1.Focus();
            else if (e.KeyCode == Keys.Enter)
                listBox1_DoubleClick(sender, e);
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                listBox1_DoubleClick(sender, e);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {

                codea.Text = ds.Tables["article"].Rows[listBox1.SelectedIndex].Field<string>("code");
                noma.Text = ds.Tables["article"].Rows[listBox1.SelectedIndex].Field<string>("libelle");
                listBox1.Visible = false;

            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != -1 && codea.Text != "")
            {




                string sqlcli = "select code from client where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef = '" + comboBox1.SelectedValue + "'";
                DataSet dscli = met.recuperer_table(sqlcli, "client");
                if (dscli != null)
                {
                    wnbre = dscli.Tables[0].Rows.Count;

                    foreach (DataRow dr in dscli.Tables["client"].Rows)
                    {
                        string xcodec = dr.Field<string>("code");

                        string sqlart = "select code from article where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code = '" + codea.Text + "'";
                        DataSet dsart = met.recuperer_table(sqlart, "article");
                        if (dsart != null)
                        {

                            //Suppression 
                            String req10 = "DELETE FROM tarif where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codec = '" + xcodec + "' and codea = '" + codea.Text + "'   ";
                            met.Execute(req10);


                            double xqdeb = 0, xqfin = 0, xremm = 0, xremq = 0;

                            foreach (DataGridViewRow dgr in mygrid4.Rows)
                            {
                                if (!dgr.IsNewRow)
                                {

                                    try
                                    {
                                        xqdeb = double.Parse(dgr.Cells["q1"].Value + "");
                                    }
                                    catch { }

                                    try
                                    {
                                        xqfin = double.Parse(dgr.Cells["q2"].Value + "");
                                    }
                                    catch { }

                                    try
                                    {
                                        xremm = double.Parse(dgr.Cells["r1"].Value + "");
                                    }
                                    catch { }

                                    try
                                    {
                                        xremq = double.Parse(dgr.Cells["r2"].Value + "");
                                    }
                                    catch { }


                                    //Sauvegarde
                                    String req = "INSERT INTO tarif(codes,codee,codec,codea,qdeb,qfin,remisem,remiseq,typerem) Values ('" + Program.Societe
                                                + "','" + Program.Exercice
                                                + "','" + xcodec
                                                + "','" + codea.Text
                                                + "', " + xqdeb
                                                + ", " + xqfin
                                                + ", " + xremm
                                                + ", " + xremq
                                                + ", " + true
                                                + ")";

                                    met.Execute(req);

                                    xqdeb = 0; xqfin = 0; xremm = 0; xremq = 0;
                                }

                            }


                        }
                    }

                    String req3 = "SELECT codec,codea,qdeb,qfin,remisem,remiseq FROM tarif where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' order by codec,codea,qdeb ";
                    DataSet ds3 = met.recuperer_table(req3, "tarif");
                    label2.Text = ds3.Tables[0].Rows.Count.ToString();
                    if (ds3 != null)
                    {
                        mygrid2.DataSource = ds3.Tables["tarif"].DefaultView;
                    }

                    MessageBox.Show(wnbre + " Clients effectués ");

                    mygrid4.Rows.Clear();
                    comboBox3.SelectedIndex = -1;
                    codea.Text = "";
                    noma.Text = "";

                }

            }
            else
                MessageBox.Show(" Selectionner Famille Clients, Saisir Articles & Remise ");
        }

        private void codec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox2.Focus();
            else if (e.KeyCode == Keys.Enter)
                listBox2_DoubleClick(sender, e);
        }

        private void codec_TextChanged(object sender, EventArgs e)
        {
            if (codec.Text.Trim() != "")
            {
                string sql = "select distinct ID,code,libelle from client where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code like '%" + codec.Text + "%'";
                ds1 = met.recuperer_table(sql, "client");
                listBox2.Items.Clear();
                if (ds1 != null)
                {
                    foreach (DataRow dr in ds1.Tables["client"].Rows)
                    {
                        listBox2.Items.Add(dr["libelle"]);

                    }
                }
                if (listBox2.Items.Count != 0)
                {
                    listBox2.SelectedIndex = 0;
                    listBox2.Visible = true;
                }
                else
                    listBox2.Visible = false;


            }
            else
                listBox2.Visible = false;
        }

        private void nomc_TextChanged(object sender, EventArgs e)
        {
            if (nomc.Text.Trim() != "")
            {


                string sql = "select distinct ID,code,libelle from client where  codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and libelle like '%" + nomc.Text + "%'";
                ds1 = met.recuperer_table(sql, "client");
                listBox2.Items.Clear();
                if (ds1 != null)
                {
                    foreach (DataRow dr in ds1.Tables["client"].Rows)
                    {
                        listBox2.Items.Add(dr["libelle"]);
                    }
                }
                if (listBox2.Items.Count != 0)
                {
                    listBox2.SelectedIndex = 0;
                    listBox2.Visible = true;
                }
                else
                    listBox2.Visible = false;

            }
            else
            {
                listBox2.Visible = false;

            }
        }

        private void nomc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox2.Focus();
            else if (e.KeyCode == Keys.Enter)
                listBox2_DoubleClick(sender, e);
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                listBox2_DoubleClick(sender, e);
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {

                codec.Text = ds1.Tables["client"].Rows[listBox2.SelectedIndex].Field<string>("code");
                nomc.Text = ds1.Tables["client"].Rows[listBox2.SelectedIndex].Field<string>("libelle");
                listBox2.Visible = false;

            }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex != -1 && codec.Text != "")
            {



                string sqlcli = "select code from client where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code = '" + codec.Text + "'";
                DataSet dscli = met.recuperer_table(sqlcli, "client");
                if (dscli != null)
                {
                    wnbre = dscli.Tables[0].Rows.Count;


                    string sqlart = "select code from article where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codef = '" + comboBox4.SelectedValue + "'";
                    DataSet dsart = met.recuperer_table(sqlart, "article");
                    if (dsart != null)
                    {

                        foreach (DataRow dr1 in dsart.Tables["article"].Rows)
                        {
                            string xcodea = dr1.Field<string>("code");

                            //Suppression 
                            String req10 = "DELETE FROM tarif where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codec = '" + codec.Text + "' and codea = '" + xcodea + "'   ";
                            met.Execute(req10);


                            double xqdeb = 0, xqfin = 0, xremm = 0, xremq = 0;

                            foreach (DataGridViewRow dgr in mygrid5.Rows)
                            {
                                if (!dgr.IsNewRow)
                                {

                                    try
                                    {
                                        xqdeb = double.Parse(dgr.Cells["wq1"].Value + "");
                                    }
                                    catch { }

                                    try
                                    {
                                        xqfin = double.Parse(dgr.Cells["wq2"].Value + "");
                                    }
                                    catch { }

                                    try
                                    {
                                        xremm = double.Parse(dgr.Cells["wr1"].Value + "");
                                    }
                                    catch { }

                                    try
                                    {
                                        xremq = double.Parse(dgr.Cells["wr2"].Value + "");
                                    }
                                    catch { }


                                    //Sauvegarde
                                    String req = "INSERT INTO tarif(codes,codee,codec,codea,qdeb,qfin,remisem,remiseq,typerem) Values ('" + Program.Societe
                                                + "','" + Program.Exercice
                                                + "','" + codec.Text
                                                + "','" + xcodea
                                                + "', " + xqdeb
                                                + ", " + xqfin
                                                + ", " + xremm
                                                + ", " + xremq
                                                + ", " + true
                                                + ")";

                                    met.Execute(req);

                                    xqdeb = 0; xqfin = 0; xremm = 0; xremq = 0;
                                }

                            }



                        }
                    }

                    String req3 = "SELECT codec,codea,qdeb,qfin,remisem,remiseq FROM tarif where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' order by codec,codea,qdeb ";
                    DataSet ds3 = met.recuperer_table(req3, "tarif");
                    label2.Text = ds3.Tables[0].Rows.Count.ToString();
                    if (ds3 != null)
                    {
                        mygrid2.DataSource = ds3.Tables["tarif"].DefaultView;
                    }

                    MessageBox.Show(wnbre + " Clients effectués ");

                    mygrid5.Rows.Clear();
                    comboBox4.SelectedIndex = -1;
                    codec.Text = "";
                    nomc.Text = "";

                }

            }
            else
                MessageBox.Show(" Selectionner Famille Articles , Saisir Client & Remise ");
        }


        private void nomc1_TextChanged(object sender, EventArgs e)
        {
            if (nomc1.Text.Trim() != "")
            {


                string sql = "select distinct ID,code,libelle from client where  codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and libelle like '%" + nomc.Text + "%'";
                ds1 = met.recuperer_table(sql, "client");
                listBox3.Items.Clear();
                if (ds1 != null)
                {
                    foreach (DataRow dr in ds1.Tables["client"].Rows)
                    {
                        listBox3.Items.Add(dr["libelle"]);
                    }
                }
                if (listBox3.Items.Count != 0)
                {
                    listBox3.SelectedIndex = 0;
                    listBox3.Visible = true;
                }
                else
                    listBox3.Visible = false;

            }
            else
            {
                listBox3.Visible = false;

            }
        }

        private void codec1_TextChanged(object sender, EventArgs e)
        {
            if (codec1.Text.Trim() != "")
            {
                string sql = "select distinct ID,code,libelle from client where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code like '%" + codec.Text + "%'";
                ds1 = met.recuperer_table(sql, "client");
                listBox3.Items.Clear();
                if (ds1 != null)
                {
                    foreach (DataRow dr in ds1.Tables["client"].Rows)
                    {
                        listBox3.Items.Add(dr["libelle"]);

                    }
                }
                if (listBox3.Items.Count != 0)
                {
                    listBox3.SelectedIndex = 0;
                    listBox3.Visible = true;
                }
                else
                    listBox3.Visible = false;


            }
            else
                listBox3.Visible = false;
        }

        private void codec1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox3.Focus();
            else if (e.KeyCode == Keys.Enter)
                listBox3_DoubleClick(sender, e);
        }

        private void nomc1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox3.Focus();
            else if (e.KeyCode == Keys.Enter)
                listBox3_DoubleClick(sender, e);
        }

        private void listBox3_DoubleClick(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex != -1)
            {

                codec1.Text = ds1.Tables["client"].Rows[listBox3.SelectedIndex].Field<string>("code");
                nomc1.Text = ds1.Tables["client"].Rows[listBox3.SelectedIndex].Field<string>("libelle");
                listBox3.Visible = false;

            }
        }

        private void listBox3_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                listBox3_DoubleClick(sender, e);
        }

        private void codea1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox4.Focus();
            else if (e.KeyCode == Keys.Enter)
                listBox4_DoubleClick(sender, e);
        }

        private void codea1_TextChanged(object sender, EventArgs e)
        {
            if (codea1.Text.Trim() != "")
            {
                string sql = "select distinct ID,code,libelle from article where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code like '%" + codea.Text + "%'";
                ds = met.recuperer_table(sql, "article");
                listBox4.Items.Clear();
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables["article"].Rows)
                    {
                        listBox4.Items.Add(dr["libelle"]);

                    }
                }
                if (listBox4.Items.Count != 0)
                {
                    listBox4.SelectedIndex = 0;
                    listBox4.Visible = true;
                }
                else
                    listBox4.Visible = false;


            }
            else
                listBox4.Visible = false;
        }

        private void noma1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox4.Focus();
            else if (e.KeyCode == Keys.Enter)
                listBox4_DoubleClick(sender, e);
        }

        private void noma1_TextChanged(object sender, EventArgs e)
        {
            if (noma1.Text.Trim() != "")
            {


                string sql = "select distinct ID,code,libelle from article where  codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and libelle like '%" + noma.Text + "%'";
                ds = met.recuperer_table(sql, "article");
                listBox4.Items.Clear();
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables["article"].Rows)
                    {
                        listBox4.Items.Add(dr["libelle"]);
                    }
                }
                if (listBox4.Items.Count != 0)
                {
                    listBox4.SelectedIndex = 0;
                    listBox4.Visible = true;
                }
                else
                    listBox4.Visible = false;

            }
            else
            {
                listBox4.Visible = false;

            }
        }

        private void listBox4_DoubleClick(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex != -1)
            {

                codea1.Text = ds.Tables["article"].Rows[listBox4.SelectedIndex].Field<string>("code");
                noma1.Text = ds.Tables["article"].Rows[listBox4.SelectedIndex].Field<string>("libelle");
                listBox4.Visible = false;

            }
        }

        private void listBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                listBox4_DoubleClick(sender, e);
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            if (codea1.Text != "" && codec1.Text != "")
            {




                string sqlcli = "select code from client where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code = '" + codec1.Text + "'";
                DataSet dscli = met.recuperer_table(sqlcli, "client");
                if (dscli != null)
                {
                    wnbre = dscli.Tables[0].Rows.Count;


                    string sqlart = "select code from article where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code = '" + codea1.Text + "'";
                    DataSet dsart = met.recuperer_table(sqlart, "article");
                    if (dsart != null)
                    {


                        //Suppression 
                        String req10 = "DELETE FROM tarif where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codec = '" + codec1.Text + "' and codea = '" + codea1.Text + "'   ";
                        met.Execute(req10);

                        double xqdeb = 0, xqfin = 0, xremm = 0, xremq = 0;

                        foreach (DataGridViewRow dgr in mygrid1.Rows)
                        {
                            if (!dgr.IsNewRow)
                            {

                                try
                                {
                                    xqdeb = double.Parse(dgr.Cells["qd"].Value + "");
                                }
                                catch { }

                                try
                                {
                                    xqfin = double.Parse(dgr.Cells["qf"].Value + "");
                                }
                                catch { }

                                try
                                {
                                    xremm = double.Parse(dgr.Cells["rm"].Value + "");
                                }
                                catch { }

                                try
                                {
                                    xremq = double.Parse(dgr.Cells["rq"].Value + "");
                                }
                                catch { }


                                //Sauvegarde
                                String req = "INSERT INTO tarif(codes,codee,codec,codea,qdeb,qfin,remisem,remiseq,typerem) Values ('" + Program.Societe
                                            + "','" + Program.Exercice
                                            + "','" + codec1.Text
                                            + "','" + codea1.Text
                                            + "', " + xqdeb
                                            + ", " + xqfin
                                            + ", " + xremm
                                            + ", " + xremq
                                            + ", " + true
                                            + ")";

                                met.Execute(req);

                                xqdeb = 0; xqfin = 0; xremm = 0; xremq = 0;
                            }

                        }



                    }



                    String req3 = "SELECT codec,codea,qdeb,qfin,remisem,remiseq FROM tarif where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  order by codec,codea,qdeb ";
                    DataSet ds3 = met.recuperer_table(req3, "tarif");
                    label2.Text = ds3.Tables[0].Rows.Count.ToString();
                    if (ds3 != null)
                    {
                        mygrid2.DataSource = ds3.Tables["tarif"].DefaultView;
                    }

                    MessageBox.Show(wnbre + " Clients effectués ");

                    mygrid1.Rows.Clear();
                    codea1.Text = "";
                    noma1.Text = "";
                    codec1.Text = "";
                    nomc1.Text = "";

                }

            }
            else
                MessageBox.Show(" Saisir Client , Article & Remise ");
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            buttonX10.Visible = false;
            buttonX9.Visible = true;

            string req = "SELECT t.codec,t.codea,t.qdeb,t.qfin,t.remisem,t.remiseq FROM article a, client c, tarif t where t.codes='" + Program.Societe + "' and  t.codee='" + Program.Exercice + "'  and  a.`codes`=t.`codes` and  a.`codee`=t.`codee`  and a.`code`=t.`codea` and  c.`codes`=t.`codes` and  c.`codee`=t.`codee`  and c.`code`=t.`codec` and  a.libelle like '%" + textBoxX2.Text + "%' and  c.libelle like '%" + textBoxX1.Text + "%' order by t.codec,t.codea,t.qdeb ";
            DataSet ds3 = met.recuperer_table(req, "tarif");

            label2.Text = ds3.Tables[0].Rows.Count.ToString();
            if (ds3 != null)
            {
                mygrid2.DataSource = ds3.Tables["tarif"].DefaultView;
            }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

            buttonX10.Visible = false;
            buttonX9.Visible = true;

            string req = "SELECT t.codec,t.codea,t.qdeb,t.qfin,t.remisem,t.remiseq FROM article a, client c, tarif t where t.codes='" + Program.Societe + "' and  t.codee='" + Program.Exercice + "'  and  a.`codes`=t.`codes` and  a.`codee`=t.`codee`  and a.`code`=t.`codea` and  c.`codes`=t.`codes` and  c.`codee`=t.`codee`  and c.`code`=t.`codec` and  a.libelle like '%" + textBoxX2.Text + "%' and  c.libelle like '%" + textBoxX1.Text + "%' order by t.codec,t.codea,t.qdeb ";
            DataSet ds3 = met.recuperer_table(req, "tarif");
            label2.Text = ds3.Tables[0].Rows.Count.ToString();
            if (ds3 != null)
            {
                mygrid2.DataSource = ds3.Tables["tarif"].DefaultView;
            }
        }

        private void tabItem4_Click(object sender, EventArgs e)
        {
            textBoxX1.Focus();
        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            comboBox1.Focus();
        }

        private void tabItem6_Click(object sender, EventArgs e)
        {
            comboBox3.Focus();
        }

        private void tabItem3_Click(object sender, EventArgs e)
        {
            codec.Focus();
        }

        private void tabItem1_Click(object sender, EventArgs e)
        {
            codec1.Focus();
        }

        private void mygrid2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            String lastLib = "", lastlibc = "";
            Boolean color = true, change = true;
            foreach (DataGridViewRow dgr in mygrid2.Rows)
            {

                string xliba = dgr.Cells["liba"].Value + "";
                string xlibc = dgr.Cells["libc"].Value + "";
                if (lastLib != xliba)
                {
                    color = !color;
                    lastLib = xliba;
                }
                if (lastlibc != xlibc)
                {
                    change = !change;
                    lastlibc = xlibc;
                }

                if (change)
                {
                    dgr.Cells["libc"].Style.ForeColor = Color.Lime;
                    dgr.Cells["libc"].Style.BackColor = Color.DarkBlue;
                }
                else
                {
                    dgr.Cells["libc"].Style.ForeColor = Color.Lime;
                    dgr.Cells["libc"].Style.BackColor = Color.Blue;
                }

                if (color)
                {

                    dgr.Cells["liba"].Style.ForeColor = Color.Lime;
                    dgr.Cells["liba"].Style.BackColor = Color.Blue;
                    dgr.Cells["c3"].Style.ForeColor = Color.Lime;
                    dgr.Cells["c3"].Style.BackColor = Color.Blue;
                    dgr.Cells["c4"].Style.ForeColor = Color.Lime;
                    dgr.Cells["c4"].Style.BackColor = Color.Blue;
                    dgr.Cells["c5"].Style.ForeColor = Color.Yellow;
                    dgr.Cells["c5"].Style.BackColor = Color.Blue;
                    dgr.Cells["c6"].Style.ForeColor = Color.Lime;
                    dgr.Cells["c6"].Style.BackColor = Color.Blue;
                    dgr.Cells["c7"].Style.ForeColor = Color.Lime;
                    dgr.Cells["c7"].Style.BackColor = Color.Black;

                }
                else
                {

                    dgr.Cells["liba"].Style.ForeColor = Color.Lime;
                    dgr.Cells["liba"].Style.BackColor = Color.DarkBlue;
                    dgr.Cells["c3"].Style.ForeColor = Color.Lime;
                    dgr.Cells["c3"].Style.BackColor = Color.DarkBlue;
                    dgr.Cells["c4"].Style.ForeColor = Color.Lime;
                    dgr.Cells["c4"].Style.BackColor = Color.DarkBlue;
                    dgr.Cells["c5"].Style.ForeColor = Color.Yellow;
                    dgr.Cells["c5"].Style.BackColor = Color.DarkBlue;
                    dgr.Cells["c6"].Style.ForeColor = Color.Lime;
                    dgr.Cells["c6"].Style.BackColor = Color.DarkBlue;
                    dgr.Cells["c7"].Style.ForeColor = Color.Lime;
                    dgr.Cells["c7"].Style.BackColor = Color.Black;

                }
            }
        }

        private void mygrid2_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void mygrid2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            if (mygrid2.Rows.Count != 0)
            {
                buttonX10.Visible = true;
                buttonX9.Visible = false;
                foreach (DataGridViewRow dr in mygrid2.Rows)
                {
                    dr.Cells["c7"].Value = true;

                }
            }
            else
                MessageBox.Show(" Aucun Enregistrement à Sélectionner !");
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            if (mygrid2.Rows.Count != 0)
            {
                buttonX10.Visible = false;
                buttonX9.Visible = true;
                foreach (DataGridViewRow dr in mygrid2.Rows)
                {

                    dr.Cells["c7"].Value = false;

                }
            }
            else
                MessageBox.Show(" Aucun Enregistrement à Sélectionner !");

        }

        private void mygrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mygrid2.CurrentCell.ColumnIndex == 0)
                if (mygrid2.CurrentCell.Value != null)
                    mygrid2.CurrentCell.Value = !(Boolean)mygrid2.CurrentCell.Value;
                else
                    mygrid2.CurrentCell.Value = true;


        }

        private void buttonX11_Click(object sender, EventArgs e)
        {

            if (mygrid2.Rows.Count != 0)
            {
                String msg = MessageBox.Show("Etes-vous sûr de Supprimer ", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (msg.Equals("Yes"))
                {
                    wnbre = 0;
                    foreach (DataGridViewRow dgr in mygrid2.Rows)
                    {
                        if (dgr.Cells["c7"].Value != null)
                        {
                            if ((Boolean)dgr.Cells["c7"].Value)
                            {
                                string xcodea = dgr.Cells["c9"].Value + "";
                                string xcodec = dgr.Cells["c8"].Value + "";
                                //Suppression 
                                String req10 = "DELETE FROM tarif where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codec = '" + xcodec + "' and codea = '" + xcodea + "'   ";
                                met.Execute(req10);
                                wnbre++;
                            }
                        }
                    }
                    MessageBox.Show(wnbre + " Enregistrements Supprimées !!!");
                    textBoxX1.Text = ""; textBoxX2.Text = "";
                    string req = "SELECT t.codec,t.codea,t.qdeb,t.qfin,t.remisem,t.remiseq FROM article a, client c, tarif t where t.codes='" + Program.Societe + "' and  t.codee='" + Program.Exercice + "'  and  a.`codes`=t.`codes` and  a.`codee`=t.`codee`  and a.`code`=t.`codea` and  c.`codes`=t.`codes` and  c.`codee`=t.`codee`  and c.`code`=t.`codec` order by t.codec,t.codea,t.qdeb ";
                    DataSet ds3 = met.recuperer_table(req, "tarif");

                    label2.Text = ds3.Tables[0].Rows.Count.ToString();
                    if (ds3 != null)
                    {
                        mygrid2.DataSource = ds3.Tables["tarif"].DefaultView;
                        mygrid2.Columns["c8"].Visible = false;
                        mygrid2.Columns["c9"].Visible = false;
                    }
                }

            }
            else
                MessageBox.Show(" Aucun Enregistrement à Supprimer !");
        }
    }
}
