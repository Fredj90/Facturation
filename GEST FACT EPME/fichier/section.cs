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
    public partial class secteur : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        int index = 0, xindex = 0;
        DataSet ds, ds1;
        public int num, xnum;
        Boolean modif = false, sortir = false;

        public secteur()
        {
            InitializeComponent();
            buttonX5.Visible = true;
            buttonX1.Visible = false;
            buttonX2.Visible = false;
            buttonX3.Visible = false;
            buttonX4.Visible = false;

        }

        private void affiche()
        {
            String req = "SELECT * FROM secteur where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
            ds = met.recuperer_table(req);
            if (ds.Tables[0].Rows.Count != 0)
            {
                textBox1.Text = ds.Tables[0].Rows[index].Field<Object>("code") + "";
                textBox2.Text = ds.Tables[0].Rows[index].Field<Object>("libelle") + "";
                rayon.SelectedValue = ds.Tables[0].Rows[index].Field<Object>("coder") + "";
            }

        }



        private void secteur_KeyDown(object sender, KeyEventArgs e)
        {
            //////////////
            switch (e.KeyCode)
            {


                case Keys.Add:

                    if (index < ds.Tables[0].Rows.Count - 1)
                    {
                        index++;
                        affiche();
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

                case Keys.Subtract:

                    if (index > 0)
                    {
                        index--;
                        affiche();
                    }

                    break;

                default:
                    // actions_sinon;
                    break;
            }

        }



        private void secteur_Load(object sender, EventArgs e)
        {
            Program.desTfunction(this);
            String req5 = "SELECT * FROM region where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
            DataSet ds5 = met.recuperer_table(req5, "region");
            BindingSource bs5 = new BindingSource(ds5, "region");
            rayon.ValueMember = "Code";
            rayon.DisplayMember = "Libelle";
            rayon.DataSource = bs5;



            String req = "SELECT * FROM secteur where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
            ds = met.recuperer_table(req);
            if (ds != null)
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        index = ds.Tables[0].Rows.Count - 1;
                        affiche();

                    }
                    else
                    {
                        buttonItem1_Click(sender, e);
                    }
                }
            afficheb();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox1.Focus();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            // Bouton créer
            xindex = index;
            buttonX5.Visible = false;
            buttonX1.Visible = true;
            buttonX2.Visible = true;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            rayon.Enabled = true;


            buttonX6.Visible = false;
            buttonX7.Visible = false;
            buttonX8.Visible = false;
            buttonX11.Visible = false;
            buttonX9.Visible = false;
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

            rayon.SelectedIndex = -1;
            rayon.Focus();
        }

        private void increment()
        {

            string s2 = ds1.Tables[0].Rows[index].Field<Object>("secteur") + "";
            num = int.Parse(s2);
            num++;
            string s = num.ToString().Trim();
            int l1 = s2.Trim().Length;
            int l2 = s.Length;
            for (int i = l2; i < l1; i++)
                s = "0" + s;
            textBox1.Text = s;
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            // Bouton Modifier
            if (ds.Tables[0].Rows.Count != 0)
            {
                xindex = index;
                buttonX5.Visible = false;
                buttonX1.Visible = true;
                buttonX2.Visible = true;
                buttonX3.Visible = false;
                buttonX4.Visible = false;
                modif = true;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = false;
                buttonX6.Visible = false;
                buttonX7.Visible = false;
                buttonX8.Visible = false;
                buttonX11.Visible = false;
                buttonX9.Visible = false;
                rayon.Enabled = true;
                textBox2.Focus();
            }
            else
            {
                MessageBox.Show("Aucun Enregistrement");
            }

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            // Bouton supprimer
            if (ds.Tables[0].Rows.Count != 0)
            {
                Boolean test = true;

                String req2 = "SELECT codesec FROM client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codesec='" + textBox1.Text + "' ";
                DataSet ds2 = met.recuperer_table(req2, "client");
                if (ds2 != null)
                    if (ds2.Tables["client"].Rows.Count != 0)
                    {
                        test = false;
                    }


                if (test)
                {
                    buttonX5.Visible = false;
                    buttonX1.Visible = false;
                    buttonX2.Visible = false;
                    buttonX3.Visible = true;
                    buttonX4.Visible = true;
                    buttonX6.Visible = false;
                    buttonX7.Visible = false;
                    buttonX8.Visible = false;
                    buttonX11.Visible = false;
                    buttonX9.Visible = false;
                    label4.Visible = true;
                    label4.Text = "";
                }
                else
                {
                    MessageBox.Show("Suppression Impossible, Section Utilisée");
                }
            }
            else
            {
                MessageBox.Show("Aucun Enregistrement");
            }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            index = 0;
            affiche();
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            index = ds.Tables[0].Rows.Count - 1;
            affiche();
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            if (index < ds.Tables[0].Rows.Count - 1)
            {
                index++;
                affiche();
            }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {

            if (index > 0)
            {
                index--;
                affiche();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Boolean test = true;
            // Bouton Sauver
            if (superValidator1.Validate())
            {

                String sql = "SELECT code FROM secteur where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and coder = '"+ rayon.SelectedValue +"' and code='" + textBox1.Text + "'";
                DataSet verif = met.recuperer_table(sql);
                if (verif.Tables[0].Rows.Count != 0)
                    test = false;


                if (!modif)
                {

                    if (test)
                    {
                        String req = "INSERT INTO secteur(codes,codee,coder,code,libelle) Values ('" + Program.Societe + "','" + Program.Exercice + "','" + rayon.SelectedValue + "','" + textBox1.Text + "', '" + textBox2.Text + "')";
                        met.Execute(req);

                        String req2 = "SELECT * FROM pnumste where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
                        ds = met.recuperer_table(req2, "pnumste");
                        string s2 = ds.Tables[0].Rows[index].Field<Object>("secteur") + "";
                        String snum = textBox1.Text;
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
                            string sqlinc = "UPDATE pnumste SET secteur = '" + s + "' where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
                            met.Execute(sqlinc);
                        }

                        MessageBox.Show("Sauvegarde éffectué");

                        String req1 = "SELECT * FROM secteur where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
                        ds = met.recuperer_table(req1, "secteur");

                        string req5 = "SELECT MAX(ID) from secteur ";
                        DataSet ds2 = met.recuperer_table(req5, "secteur");


                        List<DataColumn> lis = new List<DataColumn>();
                        lis.Add(ds.Tables["secteur"].Columns["ID"]);
                        ds.Tables["secteur"].PrimaryKey = lis.ToArray();
                        DataRow[] dr = ds.Tables["secteur"].Select("ID = '" + ds2.Tables[0].Rows[0].ItemArray[0] + "'");
                        if (dr.Length != 0)
                        {
                            index = ds.Tables[0].Rows.IndexOf(dr[0]);
                        }

                        test = true;

                        afficheb();
                        affiche();
                    }
                    else
                    {
                        MessageBox.Show("Code déja existant");
                        test = true;
                    }

                }
                else
                {




                    {
                        // Mode Modification
                        String req = "Update secteur Set codes='" + Program.Societe + "',codee='" + Program.Exercice + "',coder = '" + rayon.SelectedValue + "',code = '" + textBox1.Text + "', libelle = '" + textBox2.Text + "' Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];

                        if (met.Execute(req))
                        {
                            MessageBox.Show("Sauvegarde éffectué");
                        }

                        modif = false;

                        String req1 = "SELECT * FROM secteur where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
                        ds = met.recuperer_table(req1);
                        test = true;
                        afficheb();
                        affiche();
                        this.buttonX6.Focus();
                    }

                }

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            // Bouton Annuler Sauvegarde
            index = xindex;
            buttonX5.Visible = true;
            buttonX1.Visible = false;
            buttonX2.Visible = false;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;
            buttonX9.Visible = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            rayon.Enabled = false;

            if (!sortir)
                affiche();

            superValidator1.ClearFailedValidations();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            // Bouton Ok suppression

            String msg = MessageBox.Show("Etes - Vous Sûr ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (msg.Equals("Yes"))
            {

                String req = "DELETE FROM secteur Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];
                if (met.Execute(req))
                    MessageBox.Show("Suppression éffectué");

                String req1 = "SELECT * FROM secteur where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
                ds = met.recuperer_table(req1);
            }

            label4.Text = "";
            if (index > 1)
            {
                index--;
            }
            else
                index = 0;
            affiche();
            afficheb();


        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            // Bouton Annuler Suppression
            buttonX5.Visible = true;
            buttonX1.Visible = false;
            buttonX2.Visible = false;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;
            buttonX9.Visible = true;
            label4.Visible = false;
            label4.Text = "";
        }

        private void afficheb()
        {
            buttonX5.Visible = true;
            buttonX1.Visible = false;
            buttonX2.Visible = false;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            rayon.Enabled = false;

            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;
            buttonX9.Visible = true;
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox2.Focus();
            else if (!e.KeyChar.Equals('\b'))
            {
                try
                {
                    // Changer chaine de caractere numerique en entier 
                    int.Parse(e.KeyChar.ToString());

                }
                catch
                {
                    // ne prenne pas en considération chaine caracter non numérique
                    e.Handled = true;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void secteur_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {

        }



    }
}
