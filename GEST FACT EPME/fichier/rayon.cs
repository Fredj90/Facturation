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
    public partial class rayon : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        int index = 0 , xindex =0 ;
        DataSet ds, ds1;
        public int num, xnum;
        Boolean modif = false, sortir = false;

        public rayon()
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
            String req = "SELECT * FROM rayon where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' Order by code ";
            ds = met.recuperer_table(req);
            if (ds.Tables[0].Rows.Count != 0)
            {
                secteur.SelectedValue = ds.Tables[0].Rows[index].Field<Object>("codesec") + "";
                textBox1.Text = ds.Tables[0].Rows[index].Field<Object>("code") + "";
                textBox2.Text = ds.Tables[0].Rows[index].Field<Object>("libelle") + "";
            }

        }



        private void rayon_KeyDown(object sender, KeyEventArgs e)
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



        private void rayon_Load(object sender, EventArgs e)
        {
            Program.desTfunction(this);

            String req5 = "SELECT * FROM secteura where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "'";
            DataSet ds5 = met.recuperer_table(req5, "secteura");
            BindingSource bs5 = new BindingSource(ds5, "secteura");
            secteur.ValueMember = "Code";
            secteur.DisplayMember = "Libelle";
            secteur.DataSource = bs5;

            String req = "SELECT * FROM rayon where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' Order by code ";
            ds = met.recuperer_table(req,"rayon");
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
            secteur.Enabled = true;

            buttonX6.Visible = false;
            buttonX7.Visible = false;
            buttonX8.Visible = false;
            buttonX11.Visible = false;
            buttonX9.Visible = false;
            String req1 = "SELECT * FROM pnum where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' ";
            ds1 = met.recuperer_table(req1, "pnum");
            if (ds1 != null)
                if (ds1.Tables.Count != 0)
                {
                    if (ds1.Tables[0].Rows.Count != 0)
                    {
                        index = ds1.Tables[0].Rows.Count - 1;

                    }
                }


            increment();

            textBox2.Focus();
        }

        private void increment()
        {

            string s2 = ds1.Tables[0].Rows[index].Field<Object>("rayon") + "";
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
                secteur.Enabled = true;
                buttonX6.Visible = false;
                buttonX7.Visible = false;
                buttonX8.Visible = false;
                buttonX11.Visible = false;
                buttonX9.Visible = false;
                textBox2.Focus();
            }
            else
            {
                MessageBox.Show("Aucun enregistrement");
            }

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            // Bouton supprimer
            if (ds.Tables[0].Rows.Count != 0)
            {
                Boolean test = true;

                String req2 = "SELECT * FROM emplacement where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and coder='" + textBox1.Text + "' ";
                DataSet ds2 = met.recuperer_table(req2, "emplacement");
                if (ds2 != null)
                    if (ds2.Tables["emplacement"].Rows.Count != 0)
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
                    MessageBox.Show("Suppression Impossible, Rayon Utilisé");
                }
            }
            else
            {
                MessageBox.Show("Aucun enregistrement");
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

                String sql = "SELECT code FROM rayon where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and code='" + textBox1.Text + "'";
                DataSet verif = met.recuperer_table(sql);
                if (verif.Tables[0].Rows.Count != 0)
                    test = false;


                if (!modif)
                {

                    if (test)
                    {
                        String req = "INSERT INTO rayon(codes,codee,codem,codesec,code,libelle) Values ('" + Program.Societe + "','" + Program.Exercice + "','" + Program.Magasin + "','" + secteur.SelectedValue + "','" + textBox1.Text + "', '" + textBox2.Text + "')";
                        met.Execute(req);

                        String req2 = "SELECT * FROM pnum where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codem = '" + Program.Magasin+ "'";
                        ds = met.recuperer_table(req2, "pnum");
                        string s2 = ds.Tables[0].Rows[index].Field<Object>("rayon") + "";
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
                            string sqlinc = "UPDATE pnum SET rayon = '" + s + "' where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "'";
                            met.Execute(sqlinc);
                        }

                        MessageBox.Show("Sauvegarde éffectué");

                        String req1 = "SELECT * FROM rayon where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' Order by code ";
                        ds = met.recuperer_table(req1, "rayon");

                        string req5 = "SELECT MAX(ID) from rayon ";
                        DataSet ds2 = met.recuperer_table(req5, "rayon");


                        List<DataColumn> lis = new List<DataColumn>();
                        lis.Add(ds.Tables["rayon"].Columns["ID"]);
                        ds.Tables["rayon"].PrimaryKey = lis.ToArray();
                        DataRow[] dr = ds.Tables["rayon"].Select("ID = '" + ds2.Tables[0].Rows[0].ItemArray[0] + "'");
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
                        String req = "Update rayon Set codes='" + Program.Societe + "',codee='" + Program.Exercice + "',codem='" + Program.Magasin + "',codesec ='" + secteur.SelectedValue + "',code = '" + textBox1.Text + "', libelle = '" + textBox2.Text + "' Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];

                        if (met.Execute(req))
                        {
                            MessageBox.Show("Sauvegarde éffectué");
                        }

                        modif = false;

                        String req1 = "SELECT * FROM rayon where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codem = '" + Program.Magasin + "' Order by code ";
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
            secteur.Enabled = false;

            if (!sortir)
                affiche();

            superValidator1.ClearFailedValidations();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            // Bouton Ok suppression

            String msg = MessageBox.Show("Etes - Vous Sûr de Supprimer ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (msg.Equals("Yes"))
            {

                String req = "DELETE FROM rayon Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];
                if (met.Execute(req))
                    MessageBox.Show("Suppression éffectuée");


                String req1 = "SELECT * FROM rayon where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' Order by code ";
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
            secteur.Enabled = false;

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

        private void buttonX10_Click(object sender, EventArgs e)
        {

        }

        private void rayon_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }





    }
}
