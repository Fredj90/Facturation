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
    public partial class Client : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        int index = 0 , xindex =0 ;
        DataSet ds,ds1;
        Boolean act = false;
        public int num, xnum;
        Boolean modif = false;
        String path_img = "";
        Byte[] Image_stream;

        Boolean maj = false;

        public Client()
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
            act = true;
           String req = "SELECT * FROM Client where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "'";
           ds = met.recuperer_table(req, "Client");

            if (ds != null)
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                       
                        textBox1.Text = ds.Tables[0].Rows[index].Field<Object>("code") + "";
                        textBox2.Text = ds.Tables[0].Rows[index].Field<Object>("libelle") + "";
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
                        

                        try
                        {
                            textBox13.Text = ds.Tables[0].Rows[index].Field<double>("remise").ToString("N2");
                        }
                        catch { textBox13.Text = ""; }

                        try
                        {
                            textBox14.Text = ds.Tables[0].Rows[index].Field<Decimal>("plafond").ToString("N3");
                        }
                        catch { textBox14.Text = ""; }

                        Boolean breg = ds.Tables[0].Rows[index].Field<Boolean>("regime");
                        if (breg)
                            radioButton1.Checked = true;
                        else
                            radioButton2.Checked = true;

                        Boolean bt = ds.Tables[0].Rows[index].Field<Boolean>("timbre");
                        if (bt)
                            radioButton3.Checked = true;
                        else
                            radioButton4.Checked = true;

                        Boolean bex = ds.Tables[0].Rows[index].Field<Boolean>("exenoration");
                        if (bex)
                            radioButton5.Checked = true;
                        else
                            radioButton6.Checked = true;

                        Boolean bcr = ds.Tables[0].Rows[index].Field<Boolean>("cumulrem");
                        if (bcr)
                            radioButton7.Checked = true;
                        else
                            radioButton8.Checked = true;
                    }
                }
            act = false;
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

        private void Client_KeyDown(object sender, KeyEventArgs e)
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

                case Keys.F8:
                    {
                        if (maj)
                        buttonX2_Click(sender, e);
                    }
                    break;

                case Keys.F10:
                    {
                        if (maj)
                        buttonX1_Click(sender, e);
                    }
                    break;

                case Keys.F1:
                    {
                        buttonItem4_Click(sender, e);
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
                textBox9.Focus();
        }
  
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar.Equals('\r'))
            //    comboBox1.Focus();   
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar.Equals('\r'))
            //    comboBox2.Focus();   
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
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
            //if (e.KeyChar.Equals('\r'))
            //    textBoxX1.Focus();
        }
     
        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                radioButton1.Focus();
        }
  
        private void radioButton1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                radioButton5.Focus();
        }

        private void radioButton5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                radioButton3.Focus();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            Program.desTfunction(this);
           // String req1 = "SELECT * FROM FamilleClient where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
           //DataSet ds1 = met.recuperer_table(req1, "FamilleClient");
           //BindingSource bs = new BindingSource(ds1, "FamilleClient");
           //comboBox1.ValueMember = "Code";
           //comboBox1.DisplayMember = "Libelle";
           //comboBox1.DataSource = bs;

           //string req2 = "Select  * from Region  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
           //DataSet ds2 = met.recuperer_table(req2, "Region");
           //BindingSource bs1 = new BindingSource(ds2, "Region");
           //comboBox2.ValueMember = "Code";
           //comboBox2.DisplayMember = "Libelle";
           //comboBox2.DataSource = bs1;


           //string req3 = "Select  * from secteur  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
           //DataSet ds3 = met.recuperer_table(req3, "secteur");
           //BindingSource bs3 = new BindingSource(ds3, "secteur");
           //comboBox3.ValueMember = "Code";
           //comboBox3.DisplayMember = "Libelle";
           //comboBox3.DataSource = bs3;


           String req = "SELECT * FROM Client where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "'";
                   
           ds = met.recuperer_table(req, "Client");
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
                        buttonX5.Visible = true;
                    }
                }

            afficheb();
        }

        private void increment()
        {

            string s2 = ds1.Tables[0].Rows[index].Field<Object>("codeclient") + "";
            num = int.Parse(s2);
            num++;
            string s = num.ToString().Trim();
            int l1 = s2.Trim().Length;
            int l2 = s.Length;
            for (int i = l2; i < l1; i++)
                s = "0" + s;
            textBox1.Text = s;
        }

        private void afficheb()
        {
            maj = false;
              
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
            textBox13.ReadOnly = true;
            textBox14.ReadOnly = true;

            buttonX5.Visible = true;
            buttonX1.Visible = false;
            buttonX2.Visible = false;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;

            groupBox4.Enabled = false;

        }
      
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            // Bouton créer
            maj = true;
            xindex = index;
            buttonX5.Visible = false;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
            buttonX1.Visible = true;
            buttonX2.Visible = true;

           
            Image_stream = new byte[0];

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            
            textBox13.Text = "";
            textBox14.Text = "";

            

            groupBox4.Enabled = true;
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = true;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = true;
            radioButton7.Checked = false;
            radioButton8.Checked = true;

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
            textBox13.ReadOnly = false;
            textBox14.ReadOnly = false;


            buttonX6.Visible = false;
            buttonX7.Visible = false;
            buttonX8.Visible = false;
            buttonX11.Visible = false;
            
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
                xindex = index;
                buttonX5.Visible = false;
                buttonX3.Visible = false;
                buttonX4.Visible = false;
                buttonX1.Visible = true;
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
                textBox13.ReadOnly = false;
                textBox14.ReadOnly = false;


                buttonX6.Visible = false;
                buttonX7.Visible = false;
                buttonX8.Visible = false;
                buttonX11.Visible = false;

                groupBox4.Enabled = true;

                textBox2.Focus();
            }
            else
                MessageBox.Show("Créer Client dabord");
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            // Bouton supprimer
            if (ds.Tables[0].Rows.Count != 0)
            {
                maj = true;
                 double x1 = 0 , x2 =0 , x3 =0, x4 =0;
                double w1 = 0, w2 = 0, w3 = 0, w4 = 0;
                string req1 = "select solde1,debit,credit,avoir from client where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'  and code = '" + textBox1.Text + "' ";
                DataSet ds1 = met.recuperer_table(req1, "client");
                if (ds1 != null)
                {
                    foreach (DataRow dr1 in ds1.Tables["client"].Rows)
                    {
                        double.TryParse(dr1["solde1"] + "", out x1);
                        double.TryParse(dr1["debit"] + "", out x2);
                        double.TryParse(dr1["credit"] + "", out x3);
                        double.TryParse(dr1["avoir"] + "", out x4);
                    
                        w1 += x1; w2 += x2; w3 += x3; w4 += x4; 
                    }

                    if (w1 == 0 && w2 == 0 && w3 == 0 && w4 == 0 )
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
                        label12.Visible = true;
                        label12.Text = "Attention   Suppression";
                    }
                    else
                    {
                        MessageBox.Show("Client Mouvementé ! Suppression Impôssible");
                        maj = false;
                    }
                }
            }
            else
                MessageBox.Show("Créer Client dabord");
            
        }
  
        private void buttonItem4_Click(object sender, EventArgs e)
        {
            // Bouton Recherche
            Rech form = new Rech();
            form.table = "Client";
            form.ShowDialog();
            if (form.code != 0)
            {
                List<DataColumn> lis = new List<DataColumn>();
                lis.Add(ds.Tables["Client"].Columns["ID"]);
                ds.Tables["Client"].PrimaryKey = lis.ToArray();
                index = ds.Tables["Client"].Rows.IndexOf(ds.Tables["Client"].Rows.Find(form.code));
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
            label12.Text = "";
            String msg = MessageBox.Show("Etes-vous sûr de Supprimer ","Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (msg.Equals("Yes"))
            {
                String req = "DELETE FROM Client Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];
              
                if (met.Execute(req))
                {
                   MessageBox.Show("Suppression effectuée");
                }
            }
            string req5 = "SELECT * FROM client WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
            ds = met.recuperer_table(req5, "client");

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
            label12.Visible = false;
            label12.Text = "";
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            // Bouton Sauver
            if (superValidator1.Validate())
            {

                string xsld1 = "Null", xsld = "Null", xrem="NULL",xplafond="NULL";
                

                if (!textBox13.Text.Trim().Equals(""))
                     xrem = "'" + textBox13.Text + "'";

                if (!textBox14.Text.Trim().Equals(""))
                    xplafond = "'" + textBox14.Text + "'";

                if (!modif) // Création
                {

                    String sql = "SELECT code FROM Client where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' and code='"+textBox1.Text +"'";
                    DataSet verif = met.recuperer_table(sql);

                    if (verif.Tables[0].Rows.Count == 0) // Code Inexistant
                    {
                       
                        String req = "INSERT INTO Client(codes,codee,code,libelle,adrl,adrf,adrm,mf,telfixe,telfixe1,telgsm,telgsm1,fax,fax1,regime,timbre,exenoration,solde1,plafond,solde,remise,cumulrem) Values ('" + Program.Societe
                         + "','" + Program.Exercice
                         + "','" + textBox1.Text                         
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
                         + "'," + radioButton1.Checked
                         + ", " + radioButton3.Checked
                         + ", " + radioButton5.Checked
                         + ", " + xsld1.ToString().Replace(Program.sep, string.Empty)
                         + ", " + xplafond.ToString().Replace(Program.sep, string.Empty)
                         + ", " + xsld.ToString().Replace(Program.sep, string.Empty)
                         + ", " + xrem.ToString().Replace(Program.sep, string.Empty)
                         + ", " + radioButton7.Checked
                         + ")";

                        met.Execute(req);
                      

                        // Incrémentation code client
                        String req2 = "SELECT * FROM pnumste where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
                        ds = met.recuperer_table(req2, "pnumste");
                        string s2 = ds.Tables[0].Rows[index].Field<Object>("codeclient") + "";
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
                            string sqlinc = "UPDATE pnumste SET codeclient = '" + s + "' where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
                            met.Execute(sqlinc);
                        }

                       

                        MessageBox.Show("Sauvgarde effectué");
                        
                         String req7 = "SELECT * FROM client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
                         ds = met.recuperer_table(req7, "client");

                         string req8 = "SELECT MAX(ID) from client ";
                         DataSet ds2 = met.recuperer_table(req8, "client");


                         List<DataColumn> lis = new List<DataColumn>();
                         lis.Add(ds.Tables["client"].Columns["ID"]);
                         ds.Tables["client"].PrimaryKey = lis.ToArray();
                         DataRow[] dr1 = ds.Tables["client"].Select("ID = '" + ds2.Tables[0].Rows[0].ItemArray[0] + "'");
                         if (dr1.Length != 0)
                         {
                             index = ds.Tables[0].Rows.IndexOf(dr1[0]);
                         }

                         affiche();
                         afficheb();
                    }
                    else // Code Existant
                    {
                        MessageBox.Show("Code déja existant");
                    }
                }
                else // Modification
                {
                   
                        // Mode Modification
                        String req = "Update Client Set codes = '" + Program.Societe
                        + "', codee = '"+ Program.Exercice
                        + "', code = '" + textBox1.Text
                        + "', libelle = '" + textBox2.Text
                        + "', adrl = '" + textBox3.Text
                        + "', adrf = '" + textBox4.Text
                        + "', adrm='" + textBox5.Text
                        + "', mf='" + textBox9.Text
                        + "',telfixe='" + textBox6.Text
                        + "',telfixe1='" + textBox10.Text
                        + "',telgsm='" + textBox7.Text
                        + "',telgsm1='" + textBox11.Text
                        + "',fax='" + textBox8.Text
                        + "',fax1='" + textBox12.Text
                        + "',regime = " + radioButton1.Checked
                        + ",timbre= " + radioButton3.Checked
                        + ",exenoration= " + radioButton5.Checked
                        + ",solde1=" + xsld1.ToString().Replace(Program.sep, string.Empty)
                        + ",plafond=" + xplafond.ToString().Replace(Program.sep, string.Empty)
                        + ",solde=" + xsld.ToString().Replace(Program.sep, string.Empty)
                        + ",remise=" + xrem.ToString().Replace(Program.sep, string.Empty)
                        + ",cumulrem=" + radioButton7.Checked
                        + " Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];


                        met.Execute(req);

                        MessageBox.Show("Sauvgarde effectué");
                       

                        modif = false;
                        String req4 = "SELECT * FROM Client where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
                        ds = met.recuperer_table(req4, "Client");
                        affiche();
                        afficheb();
                        this.buttonX6.Focus();
                    
                }
            }

            maj = false;
                
            
        }
        
        private void buttonX1_Click(object sender, EventArgs e)
        {
            // Bouton Annuler Sauvegarde

            String msg = MessageBox.Show("Ete-vous sur", "Annuler Saisie", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (msg.Equals("Yes"))
            {

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
                textBox13.ReadOnly = true;
                textBox14.ReadOnly = true;

                groupBox4.Enabled = false;

                affiche();

                superValidator1.ClearFailedValidations();
                modif = false;
                maj = false;
                buttonX5.Focus();
            }
           
            
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox11.Focus(); 
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox10.Focus(); 
        }
 
        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox12.Focus(); 
        }
  
        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox8.Focus(); 
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox7.Focus(); 
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox6.Focus(); 
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox5.Focus(); 
                
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Up)
            //    comboBox1.Focus();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox9.Focus(); 
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox2.Focus(); 
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox1.Focus(); 
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
            //if (e.KeyCode == Keys.Up)
            //    comboBox2.Focus(); 
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            //Double sld1 = 0, deb = 0, cre = 0,  avr = 0 , sld = 0;

            //Double.TryParse(textBoxX1.Text, out sld1);
            //Double.TryParse(textBoxX2.Text, out deb);
            //Double.TryParse(textBoxX5.Text, out avr);
            //Double.TryParse(textBoxX3.Text, out cre);
            //sld = sld1 + deb - avr - cre;
            //textBoxX4.Text = sld.ToString("N3");
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }


        private void buttonItem5_Click(object sender, EventArgs e)
        {
            impcli form = new impcli();
            form.ShowDialog();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
        }
    }
}
