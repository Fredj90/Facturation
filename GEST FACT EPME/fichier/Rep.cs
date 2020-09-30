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
    public partial class Rep : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        int index = 0 , xindex =0 ;
        DataSet ds;
        Boolean modif = false;
        String path_img = "";
        Byte[] Image_stream;

        public Rep()
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
            String req = "SELECT * FROM rep where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
            ds = met.recuperer_table(req, "Rep");

            if (ds != null)
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {

                        comboBox2.SelectedValue = ds.Tables[0].Rows[index].Field<Object>("coder");
                        comboBox3.SelectedValue = ds.Tables[0].Rows[index].Field<Object>("codesec");
                        textBox1.Text = ds.Tables[0].Rows[index].Field<Object>("code").ToString();
                        textBox2.Text = ds.Tables[0].Rows[index].Field<Object>("libelle").ToString();
                        textBox3.Text = ds.Tables[0].Rows[index].Field<Object>("adrf") + "";
                        textBox5.Text = ds.Tables[0].Rows[index].Field<Object>("telfixe") + "";
                        textBox6.Text = ds.Tables[0].Rows[index].Field<Object>("telgsm") + "";
                        textBoxX6.Text = ds.Tables[0].Rows[index].Field<Object>("obs") + "";

                        try
                        {
                            textBox4.Text = ds.Tables[0].Rows[index].Field<double>("taux").ToString("N2");
                        }
                        catch { textBox4.Text = ""; }

                        try
                        {
                            textBoxX1.Text = ds.Tables[0].Rows[index].Field<Decimal>("vente").ToString("N3");
                        }
                        catch { textBoxX1.Text = ""; }

                        try
                        {
                            textBoxX2.Text = ds.Tables[0].Rows[index].Field<Decimal>("com").ToString("N3");
                        }
                        catch { textBoxX2.Text = ""; }

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
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBoxX6.Text = "";

           
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
         
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
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
            buttonX9.Enabled = true;
            buttonX1.Enabled = true;
           
            textBox1.Focus();
        }
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            // Bouton Modifier
            if (ds.Tables[0].Rows.Count != 0)
            {
                xindex = index;

                modif = true;
                panel1.Enabled = true;

                textBox1.ReadOnly = true;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBoxX6.ReadOnly = false;

                comboBox2.Enabled = true;
                comboBox3.Enabled = true;

                buttonX10.Visible = true;
                buttonX2.Visible = true;
                buttonX5.Visible = false;
                buttonX6.Visible = false;
                buttonX7.Visible = false;
                buttonX8.Visible = false;
                buttonX11.Visible = false;
                buttonX9.Enabled = true;
                buttonX1.Enabled = true;

                textBox2.Focus();
            }
            else
                MessageBox.Show("Créer Représentant dabord");
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            // Bouton supprimer
            if (ds.Tables[0].Rows.Count != 0)
            {
                label24.Text = "Cliquer Içi Pr Modifier image";
                double x1 = 0;
                double w1 = 0;
                string req1 = "select vente from rep where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'  and code = '" + textBox1.Text + "' ";
                DataSet ds1 = met.recuperer_table(req1, "rep");
                if (ds1 != null)
                {
                    foreach (DataRow dr1 in ds1.Tables["rep"].Rows)
                    {
                        double.TryParse(dr1["vente"] + "", out x1);
                       

                        w1 += x1;
                    }

                    if (w1 == 0 )
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
                    {
                        MessageBox.Show("Représentant Mouvementé ! Suppression Impôssible");
                    }
                }
            }
            else
                MessageBox.Show("Créer Représentant dabord");
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
            buttonX9.Enabled = false;
            buttonX1.Enabled = false;

            comboBox2.Enabled = false;
            comboBox3.Enabled = false;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
           

            affiche();
            superValidator1.ClearFailedValidations();
            modif = false;
            label24.Text = "";
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
            form.table = "Rep";
            form.ShowDialog();
            if (form.code != 0)
            {
                List<DataColumn> lis = new List<DataColumn>();
                lis.Add(ds.Tables["Rep"].Columns["ID"]);
                ds.Tables["Rep"].PrimaryKey = lis.ToArray();
                index = ds.Tables["Rep"].Rows.IndexOf(ds.Tables["Rep"].Rows.Find(form.code));
                affiche();
            }
        }

        private void Rep_KeyDown(object sender, KeyEventArgs e)
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
                string xtaux="Null";

                if (!textBox4.Text.Trim().Equals(""))
                    xtaux = "'" + textBox4.Text + "'";
               

                if (!modif)
                {
                    String sql = "SELECT code FROM rep  WHERE code='" + textBox1.Text + "' AND codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "'";
                    DataSet verif = met.recuperer_table(sql);
                    if (verif.Tables[0].Rows.Count == 0)
                    {
                        
                             String req = "INSERT INTO Rep(codes,codee,code,coder,codesec,libelle,adrf,taux,telfixe,telgsm,obs,image) Values ('" +Program.Societe
                             + "','" + Program.Exercice
                             + "','" + textBox1.Text
                             + "','" + comboBox2.SelectedValue
                             + "','" + comboBox3.SelectedValue
                             + "','" + textBox2.Text
                             + "','" + textBox3.Text
                             + "'," + xtaux.ToString().Replace(Program.sep, string.Empty)
                             + ",'" + textBox5.Text
                             + "','" + textBox6.Text
                             + "','" + textBoxX6.Text
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


                        String req7 = "SELECT * FROM rep where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
                        ds = met.recuperer_table(req7, "rep");

                        string req8 = "SELECT MAX(ID) from rep ";
                        DataSet ds2 = met.recuperer_table(req8, "rep");


                        List<DataColumn> lis = new List<DataColumn>();
                        lis.Add(ds.Tables["rep"].Columns["ID"]);
                        ds.Tables["rep"].PrimaryKey = lis.ToArray();
                        DataRow[] dr1 = ds.Tables["rep"].Select("ID = '" + ds2.Tables[0].Rows[0].ItemArray[0] + "'");
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
                        String req = "Update Rep Set codes = '" + Program.Societe
                        +"', codee = '" + Program.Exercice
                        +"', code = '" + textBox1.Text
                        + "',coder='" + comboBox2.SelectedValue
                        + "',codesec='" + comboBox3.SelectedValue
                        +"', libelle = '" + textBox2.Text
                        +"', adrf = '" + textBox3.Text
                        +"',telfixe='" + textBox5.Text
                        +"',telgsm='" + textBox6.Text
                        + "',taux=" + xtaux.ToString().Replace(Program.sep, string.Empty)
                        +",obs='" + textBoxX6.Text 
                        +"',image=@image"
                        +" Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];


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

                        String req2 = "SELECT * FROM rep where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
                        ds = met.recuperer_table(req2, "Rep");
                        affiche();
                        afficheb();
                        this.buttonX6.Focus();
                   
                }
            }

        }
        private void Rep_Load(object sender, EventArgs e)
        {
            Program.desTfunction(this);

            string req2 = "Select  * from Region  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
            DataSet ds2 = met.recuperer_table(req2, "Region");
            BindingSource bs1 = new BindingSource(ds2, "Region");
            comboBox2.ValueMember = "Code";
            comboBox2.DisplayMember = "Libelle";
            comboBox2.DataSource = bs1;


            string req3 = "Select  * from secteur  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
            DataSet ds3 = met.recuperer_table(req3, "secteur");
            BindingSource bs3 = new BindingSource(ds3, "secteur");
            comboBox3.ValueMember = "Code";
            comboBox3.DisplayMember = "Libelle";
            comboBox3.DataSource = bs3;


            String req = "SELECT * FROM rep where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
           
            ds = met.recuperer_table(req, "Rep");
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
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBoxX6.ReadOnly = true;

            comboBox2.Enabled = false;
            comboBox3.Enabled = false;

            buttonX10.Visible = false;
            buttonX2.Visible = false;
            buttonX5.Visible = true;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;
            buttonX9.Enabled = false;
            buttonX1.Enabled = false;
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
            String msg = MessageBox.Show("Etes-vous sûr de Supprimer ", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
             if (msg.Equals("Yes"))
             {
                 String req = "DELETE FROM Rep Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];
                 if (met.Execute(req))
                 {
                   MessageBox.Show("Suppression effectuée");
                 }
             }

             String req5 = "SELECT * FROM rep where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
             ds = met.recuperer_table(req5, "Rep");

             if (index > 1)
             {
                 index--;
             }
             else
                 index = 0;
             affiche();
             afficheb();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Double xtaux = 0, xvente = 0, xcom = 0;

            Double.TryParse(textBox4.Text, out xtaux);
            Double.TryParse(textBoxX1.Text, out xvente);
            
           
            xcom = xvente  * xtaux/100;
            textBoxX2.Text = xcom.ToString("N3");
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
                textBox4.Focus();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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
                textBox4.Focus(); 
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

        private void Rep_FormClosed(object sender, FormClosedEventArgs e)
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

        private void buttonX9_Click(object sender, EventArgs e)
        {

            param frm = new param();
            frm.table = "region";
            frm.champs = "region";
            frm.Text = "Région";
            frm.ShowDialog();

            string req1 = "Select * from Region  where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "'";
            DataSet ds1 = met.recuperer_table(req1, "Region");
            BindingSource bs = new BindingSource(ds1, "Region");
            comboBox2.DataSource = bs;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            secteur frm = new secteur();
            frm.ShowDialog();

            string req1 = "Select * from secteur  where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "'";
            DataSet ds1 = met.recuperer_table(req1, "secteur");
            BindingSource bs = new BindingSource(ds1, "secteur");
            comboBox3.DataSource = bs;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!act)
            {
                String req7 = "SELECT * FROM secteur where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and coder = '" + comboBox2.SelectedValue + "' ";
                DataSet ds7 = met.recuperer_table(req7, "secteur");
                BindingSource bs7 = new BindingSource(ds7, "secteur");
                comboBox3.ValueMember = "Code";
                comboBox3.DisplayMember = "Libelle";
                comboBox3.DataSource = bs7;
                comboBox3.SelectedIndex = -1;
            }
        }

       


               
        
    }
}
