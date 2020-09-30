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
    public partial class modalite : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        int index = 0 , xindex =0 ;
        DataSet ds;
        Boolean modif = false;

        public modalite()
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
              String req = "SELECT * FROM modalite where codes='" + Program.Societe + "'   Order by code ";
            ds = met.recuperer_table(req);
            if (ds != null)
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        textBox1.Text = ds.Tables[0].Rows[index].Field<Object>("code") + "";
                        textBox2.Text = ds.Tables[0].Rows[index].Field<Object>("libelle") + "";
                        textBox3.Text = ds.Tables[0].Rows[index].Field<Object>("Observation") + "";
                    }
                }
        }


        private void modalite_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox2.Focus();
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox1.Focus();
        }

        private void modalite_Load(object sender, EventArgs e)
        {
            Program.desTfunction(this);
            String req = "SELECT * FROM modalite where codes='" + Program.Societe + "'   Order by code ";
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
                        //toolStripButton1_Click(sender, e);
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
            textBox3.Text = "";
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;

            buttonX6.Visible = false;
            buttonX7.Visible = false;
            buttonX8.Visible = false;
            buttonX11.Visible = false;
            buttonX9.Visible = false;
            textBox1.Focus();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            // Bouton Modifier
            xindex = index;
            buttonX5.Visible = false;
            buttonX1.Visible = true;
            buttonX2.Visible = true;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
            modif = true;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            buttonX6.Visible = false;
            buttonX7.Visible = false;
            buttonX8.Visible = false;
            buttonX11.Visible = false;
            buttonX9.Visible = false;
            textBox2.Focus();
            textBox3.ReadOnly = false;
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            // Bouton supprimer

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
            label4.Text = "Attention Suppression";
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

            // Bouton Sauver
            if (superValidator1.Validate())
            {


                if (!modif)
                {

                    String req = "INSERT INTO modalite(codes,code,libelle,Observation) Values ('" + Program.Societe + "','" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text.Replace("'", "\\'") + "')";
                    if (met.Execute(req))
                    {
                        MessageBox.Show("Sauvgarde effectué");
                    }
                    String req1 = "SELECT * FROM modalite where codes='" + Program.Societe + "'  Order by code ";
                    ds = met.recuperer_table(req1);
                    afficheb();
                    affiche();

                }
                else
                {
                    Boolean test = true;
                    if (!textBox1.Text.Equals(ds.Tables[0].Rows[index].Field<object>("code")))
                    {
                        String sql = "SELECT code FROM modalite where codes='" + Program.Societe + "'";
                        DataSet verif = met.recuperer_table(sql);
                        if (verif.Tables[0].Rows.Count != 0)
                            test = false;
                    }
                    if (test)
                    {
                        // Mode Modification
                        String req = "Update modalite Set codes='" + Program.Societe + "',code = '" + textBox1.Text + "', libelle = '" + textBox2.Text + "',Obsertvation='"+textBox3.Text.Replace("'","\\'")+"' Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];

                        if (met.Execute(req))
                        {
                            MessageBox.Show("Sauvgarde effectué");
                        }

                        modif = false;

                        String req1 = "SELECT * FROM modalite where codes='" + Program.Societe + "'  Order by code ";
                        ds = met.recuperer_table(req1);
                        afficheb();
                        affiche();
                        this.buttonX6.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Code déja existant");

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
            affiche();
            superValidator1.ClearFailedValidations();
            modif = false;
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            // Bouton Ok suppression
            
            String msg = MessageBox.Show("Ete-vous sur", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (msg.Equals("Yes"))
            {

                String req = "DELETE FROM modalite Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];
                if (met.Execute(req))
                    MessageBox.Show("Suppression effectuée");
            }
            String req1 = "SELECT * FROM modalite where codes='" + Program.Societe + "'   Order by code ";
            ds = met.recuperer_table(req1);
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

        private void modalite_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }


    }
}
