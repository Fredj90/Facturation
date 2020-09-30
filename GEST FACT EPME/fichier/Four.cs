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
    public partial class Four : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        int index = 0 , xindex =0 ;
        DataSet ds,ds1;
        public int num, xnum;
        Boolean modif = false;
        String path_img = "";
        Byte[] Image_stream;
        Boolean maj = false;
       
        public Four()
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
            string req = "SELECT * FROM four where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
            ds = met.recuperer_table(req,"four");

            if (ds != null)
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {

                        comboBox1.SelectedValue = ds.Tables[0].Rows[index].Field<Object>("codef");
                        textBox1.Text = ds.Tables[0].Rows[index].Field<Object>("code").ToString();
                        textBox2.Text = ds.Tables[0].Rows[index].Field<Object>("libelle").ToString();
                        textBox3.Text = ds.Tables[0].Rows[index].Field<Object>("adrl") + "";
                        textBox4.Text = ds.Tables[0].Rows[index].Field<Object>("adrf") + "";
                        textBox5.Text = ds.Tables[0].Rows[index].Field<Object>("adrm") + "";
                        textBox6.Text = ds.Tables[0].Rows[index].Field<Object>("telfixe") + "";
                        textBox7.Text = ds.Tables[0].Rows[index].Field<Object>("telgsm") + "";
                        textBox8.Text = ds.Tables[0].Rows[index].Field<Object>("fax") + "";
                        textBox9.Text = ds.Tables[0].Rows[index].Field<Object>("mf") + "";
                        textBox10.Text = ds.Tables[0].Rows[index].Field<Object>("telfixe1") + "";
                        textBox11.Text = ds.Tables[0].Rows[index].Field<Object>("telgsm1") + "";
                        textBox12.Text = ds.Tables[0].Rows[index].Field<Object>("fax1") + "";
                        textBoxX6.Text = ds.Tables[0].Rows[index].Field<Object>("obs") + "";

                        try
                        {
                            textBoxX1.Text = ds.Tables[0].Rows[index].Field<Decimal>("solde1").ToString("N3");
                        }
                        catch { textBoxX1.Text = ""; }

                        try
                        {
                            textBoxX2.Text = ds.Tables[0].Rows[index].Field<Decimal>("debit").ToString("N3");
                        }
                        catch { textBoxX2.Text = ""; }

                        try
                        {
                            textBoxX3.Text = ds.Tables[0].Rows[index].Field<Decimal>("credit").ToString("N3");
                        }
                        catch { textBoxX3.Text = ""; }


                        try
                        {
                            textBoxX5.Text = ds.Tables[0].Rows[index].Field<Decimal>("avoir").ToString("N3");
                        }
                        catch { textBoxX5.Text = ""; }

                        try
                        {
                            textBoxX4.Text = ds.Tables[0].Rows[index].Field<Decimal>("solde").ToString("N3");
                        }
                        catch { textBoxX4.Text = ""; }

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


                        Boolean bt = ds.Tables[0].Rows[index].Field<Boolean>("timbre");
                        if (bt)
                            radioButton3.Checked = true;
                        else
                            radioButton4.Checked = true;

                        Boolean btf = ds.Tables[0].Rows[index].Field<Boolean>("fodecfact");
                        if (btf)
                            radioButton1.Checked = true;
                        else
                            radioButton2.Checked = true;
                    }
                }
          

        }

     

        
      

        private void Four_KeyDown(object sender, KeyEventArgs e)
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
                        if (!maj)
                        {
                            index++;
                            affiche();
                        }
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
                case Keys.F8:
                    {
                        if (maj)
                            buttonX2_Click(sender, e);
                    }
                    break;

                case Keys.F10:
                    {
                        if (maj)
                            buttonX10_Click(sender, e);
                    }
                    break;

                case Keys.F2:
                    {
                        buttonItem5_Click(sender, e);
                    }
                    break;
                case Keys.Subtract:
                    {
                        if (index > 0)
                        {
                            if (!maj)
                            {
                                index--;
                                affiche();
                            }
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
            /*else if (!e.KeyChar.Equals('\b'))
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
            }*/
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                comboBox1.Focus();
                           
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox9.Focus();
        }
   
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
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
                textBox7.Focus();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox8.Focus();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox10.Focus();
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox11.Focus();
        }
 
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox12.Focus();
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBoxX1.Focus();
        }

        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox1.Focus();
        }

        private void Four_Load(object sender, EventArgs e)
        {
            Program.desTfunction(this);
            string req1 = "Select * from FamilleFour  where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
            DataSet ds1 = met.recuperer_table(req1, "FamilleFour");
            BindingSource bs = new BindingSource(ds1, "FamilleFour");
            comboBox1.ValueMember = "Code";
            comboBox1.DisplayMember = "Libelle";
            comboBox1.DataSource = bs;

            string req = "SELECT * FROM four where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
            ds = met.recuperer_table(req,"four");
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
                       // Buttonx5_Click(sender, e);
                        //buttonX5 
                    }
                }
         

            afficheb();
        }

        private void afficheb()
        {
            maj = false;
            buttonX5.Visible = true;
            panel1.Enabled = false;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;
            textBoxX1.ReadOnly = true;
            textBoxX6.ReadOnly = true;
            comboBox1.Enabled = false;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;
            buttonX12.Enabled = false;
            buttonX10.Visible = false;
            buttonX2.Visible = false;

            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            label24.Text = "";
        }
      
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox1.Focus(); 
        }
 
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox2.Focus(); 

        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                comboBox1.Focus();   
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox9.Focus(); 
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox3.Focus(); 
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox4.Focus(); 
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox5.Focus(); 
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox6.Focus(); 
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox7.Focus(); 
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox8.Focus(); 
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox10.Focus(); 
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox11.Focus(); 
        }
 
        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox12.Focus(); 
        }
        
        private void buttonX10_Click(object sender, EventArgs e)
        {
            // Bouton Annuler Sauvegarde
               String msg = MessageBox.Show("Ete-vous sur", "Annuler Saisie", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
               if (msg.Equals("Yes"))
               {
                   index = xindex;
                   buttonX5.Visible = true;
                   buttonX6.Visible = true;
                   buttonX7.Visible = true;
                   buttonX8.Visible = true;
                   buttonX11.Visible = true;
                   buttonX10.Visible = false;
                   buttonX2.Visible = false;

                   buttonX12.Enabled = false;

                   textBox1.ReadOnly = true;
                   textBox2.ReadOnly = true;
                   textBox3.ReadOnly = true;
                   textBox4.ReadOnly = true;
                   textBox5.ReadOnly = true;
                   textBox6.ReadOnly = true;
                   textBox7.ReadOnly = true;
                   textBox8.ReadOnly = true;
                   textBox9.ReadOnly = true;
                   textBox10.ReadOnly = true;
                   textBox11.ReadOnly = true;
                   textBox12.ReadOnly = true;
                   textBoxX1.ReadOnly = true;
                   comboBox1.Enabled = false;

                   radioButton3.Enabled = false;
                   radioButton4.Enabled = false;
                   radioButton1.Enabled = false;
                   radioButton2.Enabled = false;

                   affiche();
                   superValidator1.ClearFailedValidations();
                   label24.Text = "";
                   maj = false;
                   modif = false;
                   buttonX5.Focus();
               }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            // Bouton Sauver
            if (superValidator1.Validate())
            {
                string xsld1 = "Null" , xsld="Null" ;
                if (!textBoxX1.Text.Trim().Equals(""))
                    xsld1 = "'" + textBoxX1.Text + "'";

                if (!textBoxX4.Text.Trim().Equals(""))
                    xsld = "'" + textBoxX4.Text + "'";

                if (!modif)
                {
                    String sql = "SELECT code FROM four  where  codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' and code ='" + textBox1.Text + "'";
                    DataSet verif = met.recuperer_table(sql);
                    if (verif.Tables[0].Rows.Count == 0)
                    {
                        // Mode création
                        //(Access) string S = "#"+dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year + "#";
                        //(Mysql) string S =  + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day + "-" + dateTimePicker1.Value.Year;
                        String req = "INSERT INTO Four(codes,codee,code,codef,libelle,adrl,adrf,adrm,mf,telfixe,telfixe1,telgsm,telgsm1,fax,fax1,timbre,fodecfact,solde1,solde,obs,image) Values ('" + Program.Societe
                             + "','" + Program.Exercice
                             + "','" + textBox1.Text
                             + "','" + comboBox1.SelectedValue
                             + "','" + textBox2.Text
                             + "','" + textBox3.Text
                             + "','" + textBox4.Text
                             + "','" + textBox5.Text
                             + "','" + textBox9.Text
                             + "','" + textBox6.Text
                             + "','" + textBox10.Text
                             + "','" + textBox7.Text
                             + "','" + textBox11.Text
                             + "','" + textBox8.Text
                             + "','" + textBox12.Text
                             + "', " + radioButton3.Checked
                             + ", " + radioButton1.Checked
                             + ", " + xsld1.Replace(Program.sep, string.Empty)
                             + ", " + xsld.Replace(Program.sep, string.Empty)
                             + ",'" + textBoxX6.Text
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

                        // Incrémentation code fournisseur
                        String req2 = "SELECT * FROM pnumste where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
                        ds = met.recuperer_table(req2, "pnumste");
                        string s2 = ds.Tables[0].Rows[index].Field<Object>("codefour") + "";
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
                            string sqlinc = "UPDATE pnumste SET codefour = '" + s + "' where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
                            met.Execute(sqlinc);
                        }

                       

                       

                        String req7 = "SELECT * FROM four where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
                        ds = met.recuperer_table(req7, "four");

                        string req8 = "SELECT MAX(ID) from four ";
                        DataSet ds2 = met.recuperer_table(req8, "four");


                        List<DataColumn> lis = new List<DataColumn>();
                        lis.Add(ds.Tables["four"].Columns["ID"]);
                        ds.Tables["four"].PrimaryKey = lis.ToArray();
                        DataRow[] dr1 = ds.Tables["four"].Select("ID = '" + ds2.Tables[0].Rows[0].ItemArray[0] + "'");
                        if (dr1.Length != 0)
                        {
                            index = ds.Tables[0].Rows.IndexOf(dr1[0]);
                        }

                        MessageBox.Show("Sauvgarde effectué");

                        string req4 = "SELECT * FROM four where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
                        ds = met.recuperer_table(req4, "four");

                        affiche();
                        afficheb();
                    }
                    else
                    {
                        MessageBox.Show("Code déja existant");
                    }
                }
                else // Modification
                {

                    // Mode Modification
                    String req = "Update Four Set codes = '" + Program.Societe
                    + "', codee = '" + Program.Exercice
                    + "', code = '" + textBox1.Text
                    + "', libelle = '" + textBox2.Text
                    + "', adrf = '" + textBox3.Text
                    + "', adrl = '" + textBox4.Text
                    + "', adrm='" + textBox5.Text
                    + "', mf='" + textBox9.Text
                    + "',telfixe='" + textBox6.Text
                    + "',telfixe1='" + textBox10.Text
                    + "',telgsm='" + textBox7.Text
                    + "',telgsm1='" + textBox11.Text
                    + "',fax='" + textBox8.Text
                    + "',fax1='" + textBox12.Text
                    + "',codef='" + comboBox1.SelectedValue
                    + "',timbre = " + radioButton3.Checked
                    + ",fodecfact = " + radioButton1.Checked
                    + ",solde1=" + xsld1.Replace(Program.sep, string.Empty)
                    + ",solde=" + xsld.Replace(Program.sep, string.Empty)
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
                    string req4 = "SELECT * FROM four where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
                    ds = met.recuperer_table(req4, "four");
                    affiche();
                    afficheb();
                    this.buttonX6.Focus();

                }
            }

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
               String req = "DELETE FROM Four Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];
               if (met.Execute(req))
                {
                   MessageBox.Show("Suppression effectuée");
                }
            }
            string req5 = "SELECT * FROM four WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
            ds = met.recuperer_table(req5, "four");

            if (index > 1)
            {
                index--;
            }
            else
                index = 0;
            affiche();
            afficheb();
        }

        private void increment()
        {

            string s2 = ds1.Tables[0].Rows[index].Field<Object>("codefour") + "";
            num = int.Parse(s2);
            num++;
            string s = num.ToString().Trim();
            int l1 = s2.Trim().Length;
            int l2 = s.Length;
            for (int i = l2; i < l1; i++)
                s = "0" + s;
            textBox1.Text = s;
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            // Bouton créer
            maj = true;
            label24.Text = "Cliquer Içi Pr Ajouter image";
            xindex = index;
            buttonX10.Visible = true;
            buttonX2.Visible = true;
            buttonX5.Visible = false;

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
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBoxX1.Text = "";
            textBoxX2.Text = "";
            textBoxX3.Text = "";
            textBoxX4.Text = "";
            textBoxX5.Text = "";


            comboBox1.SelectedIndex = -1;
            comboBox1.Enabled = true;

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;

            radioButton1.Checked = false;
            radioButton2.Checked = true;
            radioButton1.Checked = true;
            radioButton2.Checked = false;

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
            textBox11.ReadOnly = false;
            textBox12.ReadOnly = false;
            textBoxX1.ReadOnly = true;
            textBoxX1.ReadOnly = false;
            textBoxX6.ReadOnly = false;

            buttonX6.Visible = false;
            buttonX7.Visible = false;
            buttonX8.Visible = false;
            buttonX11.Visible = false;
            buttonX12.Enabled = true;
            //
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
            //
            textBox2.Focus();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            // Bouton Modifier
            if (ds.Tables[0].Rows.Count != 0)
            {
                maj = true;
                label24.Text = "Cliquer Içi Pr Modifier image";
                xindex = index;
                buttonX5.Visible = false;

                panel1.Enabled = true;



                buttonX10.Visible = true;
                buttonX2.Visible = true;
                modif = true;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox9.ReadOnly = false;
                textBox10.ReadOnly = false;
                textBox11.ReadOnly = false;
                textBox12.ReadOnly = false;
                textBoxX1.ReadOnly = true;
                textBoxX1.ReadOnly = false;
                textBoxX6.ReadOnly = false;

                buttonX6.Visible = false;
                buttonX7.Visible = false;
                buttonX8.Visible = false;
                buttonX11.Visible = false;
                buttonX12.Enabled = true;


                comboBox1.Enabled = true;

                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;


                textBox2.Focus();
            }
            else
                MessageBox.Show("Créer Fournisseur dabord");
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            // Bouton supprimer
            if (ds.Tables[0].Rows.Count != 0)
            {
                  double x1 = 0 , x2 =0 , x3 =0, x4 =0;
                double w1 = 0, w2 = 0, w3 = 0, w4 = 0;
                string req1 = "select solde1,debit,credit,avoir from four where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'  and code = '" + textBox1.Text + "' ";
                DataSet ds1 = met.recuperer_table(req1, "four");
                if (ds1 != null)
                {
                    foreach (DataRow dr1 in ds1.Tables["four"].Rows)
                    {
                        double.TryParse(dr1["solde1"] + "", out x1);
                        double.TryParse(dr1["debit"] + "", out x2);
                        double.TryParse(dr1["credit"] + "", out x3);
                        double.TryParse(dr1["avoir"] + "", out x4);
                    
                        w1 += x1; w2 += x2; w3 += x3; w4 += x4; 
                    }

                    if (w1 == 0 && w2 == 0 && w3 == 0 && w4 == 0)
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
                        MessageBox.Show("Fournisseur Mouvementé ! Suppression Impôssible");
                    }
                }
            }
            else
                MessageBox.Show("Créer Fournisseur dabord");
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

        private void buttonX12_Click(object sender, EventArgs e)
        {
            param frm = new param();
            frm.table = "famillefour";
            frm.champs = "famillefour";
            frm.Text = "famille Fournisseur";
            frm.ShowDialog();

            string req1 = "Select * from FamilleFour";
            DataSet ds1 = met.recuperer_table(req1, "FamilleFour");
            BindingSource bs = new BindingSource(ds1, "FamilleFour");
            comboBox1.DataSource = bs;
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            // Bouton Recherche
            Rech form = new Rech();
            form.table = "Four";
            form.ShowDialog();
            if (form.code != 0)
            {
                List<DataColumn> lis = new List<DataColumn>();
                lis.Add(ds.Tables["Four"].Columns["ID"]);
                ds.Tables["Four"].PrimaryKey = lis.ToArray();
                index = ds.Tables["Four"].Rows.IndexOf(ds.Tables["Four"].Rows.Find(form.code));
                affiche();
            }
        }
               
        private void textBoxX1_TextChanged_1(object sender, EventArgs e)
        {
            Double sld1 = 0, deb = 0, cre = 0, avr = 0, sld = 0;

            Double.TryParse(textBoxX1.Text, out sld1);
            Double.TryParse(textBoxX2.Text, out deb);
            Double.TryParse(textBoxX5.Text, out avr);
            Double.TryParse(textBoxX3.Text, out cre);
            sld = sld1 + deb - avr - cre;
            textBoxX4.Text = sld.ToString("N3");
        }

        private void Four_FormClosed(object sender, FormClosedEventArgs e)
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

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            impfour form = new impfour();
            form.ShowDialog();
        }

        
       
                                     
            
                       

    }
}
