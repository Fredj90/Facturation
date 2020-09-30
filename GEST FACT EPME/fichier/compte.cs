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
    public partial class compte : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        int index = 0, xindex = 0;
        DataSet ds;
        Boolean modif = false;
        decimal xsolde = 0;
        String path_img = "";
        Byte[] Image_stream;

        public compte()
        {
            InitializeComponent();
            buttonX5.Visible = true;
            buttonX10.Visible = false;
            buttonX2.Visible = false;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
        }

        private void affiche()
        {
            String req = "SELECT * FROM compte where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
            ds = met.recuperer_table(req, "compte");

            if (ds != null)
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        textBox1.Text = ds.Tables[0].Rows[index].Field<Object>("code").ToString();
                        textBox2.Text = ds.Tables[0].Rows[index].Field<Object>("libelle").ToString();
                        textBox3.Text = ds.Tables[0].Rows[index].Field<Object>("adr") + "";
                        textBox4.Text = ds.Tables[0].Rows[index].Field<Object>("var") + "";
                        textBox5.Text = ds.Tables[0].Rows[index].Field<Object>("telfixe") + "";
                        textBox6.Text = ds.Tables[0].Rows[index].Field<Object>("telgsm") + "";
                        textBoxX6.Text = ds.Tables[0].Rows[index].Field<Object>("obs") + "";

                        try
                        {
                            textBoxX1.Text = ds.Tables[0].Rows[index].Field<decimal>("solde1").ToString("N3");
                        }
                        catch { textBoxX1.Text = ""; }



                        if (ds.Tables[0].Rows[index].Field<Object>("image") != null)
                        {
                            if (!ds.Tables[0].Rows[index].Field<Object>("image").Equals(""))
                            {

                                byte[] tmpbyte = (byte[])ds.Tables[0].Rows[index].Field<Object>("image");
                                System.IO.MemoryStream str1 = new System.IO.MemoryStream(tmpbyte);
                                Image img = Image.FromStream(str1);
                                Image_stream = tmpbyte;
                                panel1.BackgroundImage = img;
                                str1.Close();
                            }
                            else
                            { panel1.BackgroundImage = null; }
                        }
                        else
                        {
                            panel1.BackgroundImage = null;
                            Image_stream = new byte[0];
                        }
                    }
                }

        }
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            // Bouton créer

            xindex = index;
            label24.Text = "Cliquer Içi Pr Ajouter image";
            panel1.Enabled = true;
            panel1.BackgroundImage = null;
            Image_stream = new byte[0];

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBoxX1.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBoxX6.Text = "";

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBoxX1.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBoxX6.ReadOnly = false;

            buttonX10.Visible = true;
            buttonX2.Visible = true;
            buttonX5.Visible = false;
            buttonX6.Visible = false;
            buttonX7.Visible = false;
            buttonX8.Visible = false;
            buttonX11.Visible = false;

            textBox1.Focus();
        }
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            // Bouton Modifier
            if (textBox4.Text != "N")
            {
                label24.Text = "Cliquer Içi Pr Modifier image";
                xindex = index;
                modif = true;

                panel1.Enabled = true;


                textBox1.ReadOnly = true;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBoxX1.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBoxX6.ReadOnly = false;

                buttonX10.Visible = true;
                buttonX2.Visible = true;
                buttonX5.Visible = false;
                buttonX6.Visible = false;
                buttonX7.Visible = false;
                buttonX8.Visible = false;
                buttonX11.Visible = false;

                textBox2.Focus();
            }
            else
            {
                xindex = index;
                modif = true;

                panel1.Enabled = false;


                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBoxX6.ReadOnly = true;


                textBoxX1.ReadOnly = false;
                buttonX10.Visible = true;
                buttonX2.Visible = true;
                buttonX5.Visible = false;
                buttonX6.Visible = false;
                buttonX7.Visible = false;
                buttonX8.Visible = false;
                buttonX11.Visible = false;
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            // Bouton supprimer

            if (textBox4.Text != "N")
            {
                buttonX5.Visible = false;
                buttonX10.Visible = false;
                buttonX2.Visible = false;
                buttonX3.Visible = true;
                buttonX4.Visible = true;

                buttonX6.Visible = false;
                buttonX7.Visible = false;
                buttonX8.Visible = false;
                buttonX11.Visible = false;
                label4.Visible = true;
                label4.Text = "Attention   Suppression";
            }
            else
             MessageBox.Show("Suppression Impôssible");
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            // Bouton Annuler Sauvegarde
            index = xindex;
            buttonX5.Visible = true;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;
            buttonX10.Visible = false;
            buttonX2.Visible = false;



            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBoxX1.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;


            affiche();
            superValidator1.ClearFailedValidations();
            label24.Text = "";
            modif = false;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            // Bouton Annuler Suppression
            buttonX5.Visible = true;
            buttonX3.Visible = false;
            buttonX4.Visible = false;

            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;

            label4.Visible = false;
            label4.Text = "";
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

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            // Bouton Recherche
            Rech form = new Rech();
            form.table = "compte";
            form.ShowDialog();
            if (form.code != 0)
            {
                List<DataColumn> lis = new List<DataColumn>();
                lis.Add(ds.Tables["compte"].Columns["ID"]);
                ds.Tables["compte"].PrimaryKey = lis.ToArray();
                index = ds.Tables["compte"].Rows.IndexOf(ds.Tables["compte"].Rows.Find(form.code));
                affiche();
            }
        }

        private void compte_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.F1:
                    {
                        buttonItem4_Click(sender, e);
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


        private void buttonX2_Click(object sender, EventArgs e)
        {
            // Bouton Sauver
            if (superValidator1.Validate())
            {
                string xsolde1 = "Null";

                if (!textBoxX1.Text.Trim().Equals(""))
                    xsolde1 = "'" + textBoxX1.Text + "'";


                if (!modif)
                {
                    String sql = "SELECT code FROM compte  WHERE code='" + textBox1.Text + "' AND codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "'";
                    DataSet verif = met.recuperer_table(sql);
                    if (verif.Tables[0].Rows.Count == 0)
                    {

                        String req = "INSERT INTO compte(codes,codee,code,libelle,adr,solde1,telfixe,telgsm,obs,var,image) Values ('" + Program.Societe
                        + "','" + Program.Exercice
                        + "','" + textBox1.Text
                        + "','" + textBox2.Text
                        + "','" + textBox3.Text
                        + "'," + xsolde1.ToString().Replace(Program.sep, string.Empty)
                        + ",'" + textBox5.Text
                        + "','" + textBox6.Text
                        + "','" + textBoxX6.Text
                        + "','" + textBox4.Text
                        + "',@image"
                        + ")";

                        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(req, met.mycon);
                        cmd.Parameters.Add("@image", MySql.Data.MySqlClient.MySqlDbType.LongBlob);
                        cmd.Parameters["@image"].Size = Image_stream.Length;
                        if (Image_stream.Length != 0)
                        {
                            cmd.Parameters["@image"].Value = Image_stream;
                        }
                        else
                        {
                            cmd.Parameters["@image"].Value = DBNull.Value;
                        }
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Sauvgarde effectué");


                        String req7 = "SELECT * FROM compte where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
                        ds = met.recuperer_table(req7, "compte");

                        string req8 = "SELECT MAX(ID) from compte ";
                        DataSet ds2 = met.recuperer_table(req8, "compte");


                        List<DataColumn> lis = new List<DataColumn>();
                        lis.Add(ds.Tables["compte"].Columns["ID"]);
                        ds.Tables["compte"].PrimaryKey = lis.ToArray();
                        DataRow[] dr1 = ds.Tables["compte"].Select("ID = '" + ds2.Tables[0].Rows[0].ItemArray[0] + "'");
                        if (dr1.Length != 0)
                        {
                            index = ds.Tables[0].Rows.IndexOf(dr1[0]);
                        }

                        affiche();
                        afficheb();
                    }
                    else
                    {
                        MessageBox.Show("Code déja existant");
                    }
                }
                else
                {

                    // Mode Modification
                    String req = "Update compte Set codes = '" + Program.Societe
                    + "', codee = '" + Program.Exercice
                    + "', code = '" + textBox1.Text
                    + "', libelle = '" + textBox2.Text
                    + "', adr = '" + textBox3.Text
                    + "',telfixe='" + textBox5.Text
                    + "',telgsm='" + textBox6.Text
                    + "',solde1=" + xsolde1.ToString().Replace(Program.sep, string.Empty)
                    + ",solde=" + xsolde.ToString().Replace(Program.sep, string.Empty)
                    + ",obs='" + textBoxX6.Text
                    + "',image=@image"
                    + " Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];


                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(req, met.mycon);
                    cmd.Parameters.Add("@image", MySql.Data.MySqlClient.MySqlDbType.LongBlob);
                    cmd.Parameters["@image"].Size = Image_stream.Length;
                    if (Image_stream.Length != 0)
                    {
                        cmd.Parameters["@image"].Value = Image_stream;
                    }
                    else
                    {
                        cmd.Parameters["@image"].Value = DBNull.Value;
                    }
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sauvgarde effectué");

                    modif = false;

                    String req2 = "SELECT * FROM compte where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
                    ds = met.recuperer_table(req2, "compte");
                    affiche();
                    afficheb();
                    this.buttonX6.Focus();

                }
            }

        }
        private void compte_Load(object sender, EventArgs e)
        {
            Program.desTfunction(this);
            String req = "SELECT * FROM compte where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";

            ds = met.recuperer_table(req, "compte");
            if (ds != null)
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        index = ds.Tables[0].Rows.Count - 1;
                        affiche();

                    }

                }
            afficheb();


        }

        private void afficheb()
        {
            panel1.Enabled = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBoxX1.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBoxX6.ReadOnly = true;

            buttonX10.Visible = false;
            buttonX2.Visible = false;
            buttonX5.Visible = true;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;
            label24.Text = "";
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            // Bouton Ok suppression
            buttonX5.Visible = true;
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
                String req = "DELETE FROM compte Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];
                if (met.Execute(req))
                {
                    MessageBox.Show("Suppression effectuée");
                }
            }

            String req5 = "SELECT * FROM compte where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
            ds = met.recuperer_table(req5, "compte");

            if (index > 1)
            {
                index--;
            }
            else
                index = 0;
            affiche();
            afficheb();
        }

       

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox2.Focus();

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox3.Focus();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox5.Focus();
        }

       
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox6.Focus();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox1.Focus();
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox5.Focus();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox3.Focus();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox3.Focus();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox1.Focus();
        }

        private void compte_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Fichier Image|*.jpg;*.gif;*.png";

            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                path_img = openFileDialog1.SafeFileName;
                Image img = Image.FromFile(openFileDialog1.SafeFileName);
                System.IO.FileStream fs = new System.IO.FileStream(path_img, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                Image_stream = new Byte[fs.Length];
                fs.Read(Image_stream, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                panel1.BackgroundImage = img;

            }
            else
            {
                path_img = "";
                panel1.BackgroundImage = null;
                Image_stream = new byte[0];
            }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
           
        }

       





    }
}
