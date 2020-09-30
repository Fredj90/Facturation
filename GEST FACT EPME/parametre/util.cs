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
    public partial class util : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        int index = 0;
        DataSet ds;
        Boolean modif = false;
        private string xlibadmin = "mohsen";

        public util()
        {
            InitializeComponent();
            buttonX5.Visible = true;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;
            buttonX1.Visible = false;
            buttonX2.Visible = false;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
        }


        private void affiche()
        {
           
            textBox1.Text = ds.Tables[0].Rows[index].Field<Object>("code")+"";
            textBox2.Text = ds.Tables[0].Rows[index].Field<Object>("libelle")+"";
            PWD.Text = ds.Tables[0].Rows[index].Field<Object>("mp") + "";
            type.Text = ds.Tables[0].Rows[index].Field<Object>("type") + "";

            if (type.Text == "S")
                label5.Text = "Super Administrateur";
            else if (type.Text == "A")
                label5.Text = "Administrateur";
            else if (type.Text == "U")
                label5.Text = "Utilisateur";
            else
                label5.Text = "";
        }







        private void util_KeyDown(object sender, KeyEventArgs e)
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
                    {
                        if (index > 0)
                        {
                            index--;
                            affiche();
                        }
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox2.Focus();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox1.Focus();
        }


        private void util_Load(object sender, EventArgs e)
        {
           
            String req = "SELECT * FROM utilisateur where libelle != '" + xlibadmin + "'";
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
                        //buttonX5.Visible;
                    }
                }
            buttonX5.Visible = true;
            buttonX1.Visible = false;
            buttonX2.Visible = false;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            PWD.ReadOnly = true;

            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                PWD.Focus();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            // Bouton créer
            label5.Text = "Utilisateur";
            buttonX5.Visible = false;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
            buttonX1.Visible = true;
            buttonX2.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            PWD.Text = "";

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            PWD.ReadOnly = false;


            buttonX6.Visible = false;
            buttonX7.Visible = false;
            buttonX8.Visible = false;
            buttonX11.Visible = false;
            textBox1.Focus();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            // Bouton Modifier
            if (Program.ISSaDmin)
            {
                buttonX5.Visible = false;
                buttonX3.Visible = false;
                buttonX4.Visible = false;
                buttonX1.Visible = true;
                buttonX2.Visible = true;
                modif = true;
                textBox2.ReadOnly = false;
                PWD.ReadOnly = false;
                buttonX6.Visible = false;
                buttonX7.Visible = false;
                buttonX8.Visible = false;
                buttonX11.Visible = false;
                textBox2.Focus();
            }
            else if (Program.ISaDmin)
            {
                if (type.Text == "U" || type.Text=="A")
                {
                    buttonX5.Visible = false;
                    buttonX3.Visible = false;
                    buttonX4.Visible = false;
                    buttonX1.Visible = true;
                    buttonX2.Visible = true;
                    modif = true;
                    textBox2.ReadOnly = false;
                    PWD.ReadOnly = false;
                    buttonX6.Visible = false;
                    buttonX7.Visible = false;
                    buttonX8.Visible = false;
                    buttonX11.Visible = false;
                    textBox2.Focus();
                }
                else
                    MessageBox.Show("Seul Super Administrateur Peut Modifier");
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            // Bouton supprimer
            if (Program.ISSaDmin)
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
                label4.Visible = true;
                label4.Text = "Attention Suppression";
            }
            else if (Program.ISaDmin)
            {
                if (type.Text == "U" || type.Text == "A")
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
                    label4.Visible = true;
                    label4.Text = "Attention Suppression";
                }
                else
                    MessageBox.Show("Seul Super Administrateur Peut Supprimer");
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

        private void buttonX4_Click(object sender, EventArgs e)
        {
            // Bouton Ok suppression
            buttonX5.Visible = true;
            buttonX1.Visible = false;
            buttonX2.Visible = false;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;
            label4.Text = "";
            String msg = MessageBox.Show("Ete-vous sur", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (msg.Equals("Yes"))
            {
                String req = "DELETE FROM utilisateur Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];
                if (met.Execute(req))
                    MessageBox.Show("Suppression effectuée");
            }
            util_Load(sender, e);
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
            label4.Visible = false;
            label4.Text = "";
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            // Bouton Sauver
            if (Program.ISSaDmin || Program.ISaDmin)
            {
                if (superValidator1.Validate())
                {


                    if (!modif)
                    {
                        String sql = "Select Code From utilisateur Where code = '" + textBox1.Text + "'";
                        DataSet verif = met.recuperer_table(sql);
                        if (verif.Tables[0].Rows.Count == 0)
                        {
                            // Mode création
                            //(Access) string S = "#"+dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year + "#";
                            //(Mysql) string S =  + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day + "-" + dateTimePicker1.Value.Year;
                            String req = "INSERT INTO utilisateur(code,libelle,mp) Values ('" + textBox1.Text + "', '" + textBox2.Text + "','" + PWD.Text + "')";
                            if (met.Execute(req))
                                MessageBox.Show("Sauvgarde effectué");
                            util_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Code déja existant");
                        }
                    }
                    else
                    {
                        Boolean test = true;
                        if (!textBox1.Text.Equals(ds.Tables[0].Rows[index].Field<object>("code")))
                        {
                            String sql = "Select Code From utilisateur Where code = '" + textBox1.Text + "' ";
                            DataSet verif = met.recuperer_table(sql);
                            if (verif.Tables[0].Rows.Count != 0)
                                test = false;
                        }
                        if (test)
                        {
                            // Mode Modification
                            String req = "Update utilisateur Set code = '" + textBox1.Text + "', libelle = '" + textBox2.Text + "', mp = '" + PWD.Text + "'  Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];
                            if (met.Execute(req))
                                MessageBox.Show("Sauvgarde effectué");
                            modif = false;
                            util_Load(sender, e);
                            this.buttonX6.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Code déja existant");

                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Accés Non Autorisé");
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            // Bouton Annuler Sauvegarde
            buttonX5.Visible = true;
            buttonX1.Visible = false;
            buttonX2.Visible = false;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            affiche();
            superValidator1.ClearFailedValidations();
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }
}
