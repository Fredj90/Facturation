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
    public partial class ste : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        int index = 0;
        DataSet ds,ds1;
        Boolean modif = false;
        Boolean act = false;
        public ste()
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

            String req = "SELECT * FROM ste";
            ds = met.recuperer_table(req, "ste");

            if (ds != null)
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {

                        textBox1.Text = ds.Tables[0].Rows[index].Field<Object>("code") + "";
                        textBox2.Text = ds.Tables[0].Rows[index].Field<Object>("libelle") + "";
                        textBox3.Text = ds.Tables[0].Rows[index].Field<Object>("adr") + "";
                        textBox4.Text = ds.Tables[0].Rows[index].Field<Object>("mf") + "";
                        textBox5.Text = ds.Tables[0].Rows[index].Field<Object>("telfixe") + "";
                        textBox6.Text = ds.Tables[0].Rows[index].Field<Object>("telgsm") + "";
                        textBox7.Text = ds.Tables[0].Rows[index].Field<Object>("ncnss") + "";
                        textBox8.Text = ds.Tables[0].Rows[index].Field<Object>("var") + "";
                        textBox11.Text = ds.Tables[0].Rows[index].Field<Object>("responsable") + "";
                        textBox12.Text = ds.Tables[0].Rows[index].Field<Object>("fonction") + "";
                        Boolean bf = ds.Tables[0].Rows[index].Field<Boolean>("fodec");
                        if (bf)
                            rbf1.Checked = true;
                        else
                            rbf2.Checked = true;
                    }
                }
                      
        }
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            // Bouton créer

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox10.Text = "";
            //
            anne.Visible = true;
            label12.Visible = true;
            anne.SelectedIndex = -1;
            textBox10.Text = "";
            buttonX9.Visible = false;
           // buttonX13.Visible = true;
            //buttonX14.Visible = true;
            buttonX1.Visible = true;
            //

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox10.Visible = true;

            buttonX2.Visible = true;
           
            buttonX5.Visible = false;
            buttonX6.Visible = false;
            buttonX7.Visible = false;
            buttonX8.Visible = false;

            rbf1.Enabled = true;
            rbf2.Enabled = true;
          
            buttonX11.Visible = false;

            textBox1.Focus();
        }
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            // Bouton Modifier
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (textBox8.Text != "N")
                {

                    modif = true;
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = false;
                    textBox3.ReadOnly = false;
                    textBox4.ReadOnly = false;
                    textBox5.ReadOnly = false;
                    textBox6.ReadOnly = false;
                    textBox7.ReadOnly = false;

                    buttonX1.Visible = true;
                    buttonX2.Visible = true;
                    buttonX5.Visible = false;
                    buttonX6.Visible = false;
                    buttonX7.Visible = false;
                    buttonX8.Visible = false;
                    buttonX9.Visible = false;
                    buttonX11.Visible = false;

                    rbf1.Enabled = true;
                    rbf2.Enabled = true;

                    textBox2.Focus();
                }
                else
                {
                    MessageBox.Show("Impôssible de Modifier Sté Exemple ");
                }
            }
            else
                MessageBox.Show("Aucune Sté Créee");
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            // Bouton supprimer
            if (Program.Societe != textBox1.Text )
            {
                if (textBox8.Text != "N")
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
                    label4.Text = "Attention   Suppression";
                }
                else
                {
                    MessageBox.Show("Impôssible de Supprimer Sté Exemple ");
                }
            }
           else
            {
                MessageBox.Show("Impôssible de Supprimer Sté En Cours");
            }

        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            // Bouton Annuler Sauvegarde
            buttonX5.Visible = true;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;
            buttonX1.Visible = false;
            buttonX2.Visible = false;



            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;

            anne.Visible = false;

            affiche();
            superValidator1.ClearFailedValidations();
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
            form.table = "ste";
            form.ShowDialog();
            if (form.code != 0)
            {
                List<DataColumn> lis = new List<DataColumn>();
                lis.Add(ds.Tables["ste"].Columns["ID"]);
                ds.Tables["ste"].PrimaryKey = lis.ToArray();
                index = ds.Tables["ste"].Rows.IndexOf(ds.Tables["ste"].Rows.Find(form.code));
                affiche();
            }
        }

        private void ste_KeyDown(object sender, KeyEventArgs e)
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
            if (Program.ISSaDmin)
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {

                    if (!modif)
                    {

                        String req = "INSERT INTO ste(code,libelle,adr,mf,ncnss,responsable,fonction,telfixe,telgsm,fodec) Values ('" 
                            + textBox1.Text
                        + "','" + textBox2.Text
                        + "','" + textBox3.Text
                        + "','" + textBox4.Text
                        + "','" + textBox7.Text
                        + "','" + textBox11.Text
                        + "','" + textBox12.Text
                        + "','" + textBox5.Text
                        + "','" + textBox6.Text
                        + "', " + rbf1.Checked
                        + ")";

                        met.Execute(req);

                        String reqe = "INSERT INTO exercice(codes,codee,libelle) Values ('" + textBox1.Text
                       + "','" + anne.SelectedItem
                       + "','" + textBox10.Text
                       + "')";

                        met.Execute(reqe);

                        // Table pnumste
                        string xdfact = "FC";
                        string xfact = "000000";
                        string xcodec = "4100000";
                     
                        String reqpns = "";
                        reqpns = "INSERT INTO pnumste(codes,codee,dfacture,facture,codeclient) Values ('" + textBox1.Text
                        + "','" + anne.SelectedItem
                        + "','" + xdfact
                        + "','" + xfact
                        + "','" + xcodec
                        + "')";

                        met.Execute(reqpns);

                        string xcodecompte = "001";
                        string xcodesociete = "999";

                        String sqlent = "INSERT INTO entete(codes)  Values ('" + textBox1.Text + "' )";
                        met.Execute(sqlent);

                        string sqlmod = "INSERT INTO modalite(codes,code,libelle,Observation) Select ('" + textBox1.Text + "') as codes,code,libelle,Observation  FROM modalite WHERE codes = '999'";
                        met.Execute(sqlmod);

                        //xcodesociete = "999";
                        //String sqlpar = "INSERT INTO parametre(codes,param,value) (SELECT '" + textBox1.Text + "',param,value FROM parametre  WHERE codes = '" + xcodesociete + "')";
                        //met.Execute(sqlpar);


                        //string xcodefamille = "000";
                        //xcodesociete = "999";
                        //String sqlfam = "INSERT INTO familleclient(codes,codee,code,libelle,type) (SELECT '" + textBox1.Text + "','" + anne.SelectedItem + "',code,libelle,type FROM familleclient  WHERE codes = '" + xcodesociete + "' and code = '" + xcodefamille + "' )";
                        //met.Execute(sqlfam);


                        MessageBox.Show("Sauvgarde effectué");
                       
                        String req7 = "SELECT * FROM ste  Order by code ";
                        ds = met.recuperer_table(req7, "ste");

                        string req8 = "SELECT MAX(ID) from ste ";
                        DataSet ds2 = met.recuperer_table(req8, "ste");


                        List<DataColumn> lis = new List<DataColumn>();
                        lis.Add(ds.Tables["ste"].Columns["ID"]);
                        ds.Tables["ste"].PrimaryKey = lis.ToArray();
                        DataRow[] dr = ds.Tables["ste"].Select("ID = '" + ds2.Tables[0].Rows[0].ItemArray[0] + "'");
                        if (dr.Length != 0)
                        {
                            index = ds.Tables[0].Rows.IndexOf(dr[0]);
                        }

                        affiche();
                        afficheb();


                    }
                    else
                    {
                        Boolean test = true;
                        if (!textBox1.Text.Equals(ds.Tables[0].Rows[index].Field<object>("code")))
                        {
                            String sql = "Select Code From ste Where code = '" + textBox1.Text + "' ";
                            DataSet verif = met.recuperer_table(sql);
                            if (verif.Tables[0].Rows.Count != 0)
                                test = false;
                        }
                        if (test)
                        {
                            // Mode Modification
                            String req = "Update ste Set code = '" + textBox1.Text;
                            req += "', libelle = '" + textBox2.Text;
                            req += "', adr = '" + textBox3.Text;
                            req += "',mf   ='" + textBox4.Text;
                            req += "',telfixe='" + textBox5.Text;
                            req += "',telgsm='" + textBox6.Text;
                            req += "',ncnss='" + textBox7.Text;
                            req += "',responsable='" + textBox11.Text;
                            req += "',fonction='" + textBox12.Text;
                            req += "',fodec= " + rbf1.Checked;
                            req += " Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];

                            if (met.Execute(req))
                                MessageBox.Show("Sauvgarde effectué");
                            modif = false;
                            String req1 = "SELECT * FROM ste";
                            ds = met.recuperer_table(req1, "ste");
                            affiche();
                            afficheb();
                            this.buttonX6.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Code déja existant");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Code , Libéllé doivent êtres # Null");
                }
            }
            else
            {
                MessageBox.Show("Accés Non Autorisé");
            }
        }
        private void ste_Load(object sender, EventArgs e)
        {
            Program.desTfunction(this);
            String req1 = "SELECT * FROM exercice";
            ds1 = met.recuperer_table(req1, "exercice");

            String req = "SELECT * FROM ste";
            ds = met.recuperer_table(req, "ste");

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
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox10.Visible = false;
            buttonX1.Visible = false;
            buttonX2.Visible = false;
            buttonX5.Visible = true;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;
            rbf1.Enabled = false;
            rbf2.Enabled = false;
            anne.Visible = false;
            label12.Visible = false;
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
                String req = "DELETE FROM ste Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];
                if (met.Execute(req))
                    MessageBox.Show("Suppression effectuée");
            }
            ste_Load(sender, e);
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
                textBox7.Focus();
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox5.Focus();
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox5.Focus();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox7.Focus();
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
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

        private void buttonX1_Click(object sender, EventArgs e)
        {
            // Bouton Annuler Sauvegarde
            buttonX5.Visible = true;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;
            buttonX1.Visible = false;
            buttonX2.Visible = false;

            groupBox1.Visible = true;
            textBox9.Visible = false;
            textBox10.Visible = false;
            buttonX9.Visible = true;
            buttonX10.Visible = false;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox10.Visible = false;
            anne.Visible = false;

            rbf1.Enabled = false;
            rbf2.Enabled = false;

            affiche();
            superValidator1.ClearFailedValidations();
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            exercice form = new exercice();
            form.xcodes = textBox1.Text;
            form.ShowDialog();
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                comboBoxEx1.Focus();
        }
        private void comboBoxEx1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox10.Focus();
        }
        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                buttonX10.Focus();
        }

        

        private void buttonX10_Click_1(object sender, EventArgs e)
        {
           
            String msg = MessageBox.Show("Création Exercice ???","Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (msg.Equals("Yes"))
            {

                string sql1 = "Select Codes,codee From exercice Where codes = '" + textBox1.Text + "' and codee = '" + textBox9.Text + "' ";
                DataSet verif = met.recuperer_table(sql1);

                if (verif.Tables[0].Rows.Count == 0)
                {

                    String req1 = "INSERT INTO exercice(codes,codee,libelle) Values ('" + textBox1.Text
                    + "','" + textBox9.Text
                    + "','" + textBox10.Text
                    + "')";
                    if (met.Execute(req1))
                    {

                        progressBarX1.Maximum = 9;
                        progressBarX1.Value = 0;
                        progressBarX1.Visible = true;
                        
                        // Table client
                        string req3 = "Select * from client where codes='" + Program.Societe + "' and codee='" + comboBoxEx1.SelectedValue + "'";
                        DataSet tmp1 = met.recuperer_table(req3, "client");
                        foreach (DataRow dr in tmp1.Tables["client"].Rows)
                        {
                            string tsolde1 = "Null";
                            if (dr.Field<object>("solde") != null)
                                tsolde1 = dr.Field<object>("solde").ToString();

                            String req2 = "INSERT INTO Client(codes,codee,code,codef,coder,libelle,adrl,adrf,adrm,mf,telfixe,telfixe1,telgsm,telgsm1,fax,fax1,regime,timbre,exenoration,solde1,solde) Values ('" + Program.Societe
                            + "','" + textBox9.Text
                            + "','" + dr.Field<object>("code")
                            + "','" + dr.Field<object>("codef")
                            + "','" + dr.Field<object>("coder")
                            + "','" + dr.Field<object>("libelle")
                            + "','" + dr.Field<object>("adrl")
                            + "','" + dr.Field<object>("adrf")
                            + "','" + dr.Field<object>("adrm")
                            + "','" + dr.Field<object>("mf")
                            + "','" + dr.Field<object>("telfixe")
                            + "','" + dr.Field<object>("telfixe1")
                            + "','" + dr.Field<object>("telgsm")
                            + "','" + dr.Field<object>("telgsm1")
                            + "','" + dr.Field<object>("fax")
                            + "','" + dr.Field<object>("fax1")
                            + "'," + dr.Field<object>("regime")
                            + "," + dr.Field<object>("timbre")
                            + "," + dr.Field<object>("exenoration")
                            + "," + tsolde1
                            + "," + tsolde1
                            + ")";

                            met.Execute(req2);
                        }

                        progressBarX1.Value++;

                        // Table Famille Cliente
                        string req7 = "Select * from FamilleClient where codes='" + Program.Societe + "' and codee='" + comboBoxEx1.SelectedValue + "'";
                        DataSet tmp5 = met.recuperer_table(req7, "FamilleClient");
                        foreach (DataRow dr in tmp5.Tables["FamilleClient"].Rows)
                        {
                            string req2 = "insert into FamilleClient (codes,codee,code,libelle) values ('" + Program.Societe + "','" + textBox9.Text + "','" + dr.Field<Object>("code") + "' ,'" + dr.Field<object>("libelle") + "' )";
                            met.Execute(req2);
                        }

                        progressBarX1.Value++;
                        MessageBox.Show("Succés Création Exercice ");
                    }

                    String req12 = "SELECT * FROM exercice";
                    ds1 = met.recuperer_table(req12, "exercice");

                    String req13 = "SELECT * FROM ste";
                    ds = met.recuperer_table(req13, "ste");
                    affiche();
                    progressBarX1.Visible = false;
                    textBox9.Visible = false;
                    textBox10.Visible = false;
                    buttonX9.Visible = true;
                    buttonX10.Visible = false;
                    comboBoxEx1.Visible = false;

                    //ste_Load(sender, e);
                }
                else
                {

                    textBox9.Visible = false;
                    textBox10.Visible = false;
                    buttonX9.Visible = true;
                    buttonX10.Visible = false;

                    MessageBox.Show("Exercice déja existant");
                }
            }
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            progressBarX1.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            buttonX9.Visible = true;
            buttonX10.Visible = false;
            buttonX12.Visible = false;
            comboBoxEx1.Visible = false;
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && anne.SelectedIndex != -1)
            {
                String sql = "Select Code,libelle From ste Where code = '" + textBox1.Text + "'";
                DataSet verif = met.recuperer_table(sql,"ste");
                string xlibs = "";
                if (verif != null)
                {
                    if (verif.Tables.Count != 0)
                    {
                        if (verif.Tables[0].Rows.Count == 0)
                        {
                            
                            buttonX1.Visible = true;
                            buttonX2.Visible = false;

                        }
                        else
                        {
                             xlibs = verif.Tables[0].Rows[0].Field<Object>("libelle") + "";
                             MessageBox.Show("Sté Nommée "+ xlibs+" Existant");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Code,Libéllé,Exercice doivent être # Null");
                textBox1.Focus();
            }
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            
            buttonX1.Visible = true;
            buttonX2.Visible = false;
            textBox1.Focus();
        }



        private void buttonX16_Click(object sender, EventArgs e)
        {
            buttonX2.Visible = false;

            buttonX2.Visible = false;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ste));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonX8 = new DevComponents.DotNetBar.ButtonX();
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX7 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.label8 = new System.Windows.Forms.Label();
            this.requiredFieldValidator5 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator4 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.buttonX11 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.requiredFieldValidator8 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.requiredFieldValidator9 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.requiredFieldValidator6 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.requiredFieldValidator7 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.styleManager2 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.buttonX9 = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.anne = new Mycombo();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.comboItem11 = new DevComponents.Editors.ComboItem();
            this.comboItem12 = new DevComponents.Editors.ComboItem();
            this.comboItem13 = new DevComponents.Editors.ComboItem();
            this.comboItem14 = new DevComponents.Editors.ComboItem();
            this.comboItem15 = new DevComponents.Editors.ComboItem();
            this.comboItem16 = new DevComponents.Editors.ComboItem();
            this.comboItem17 = new DevComponents.Editors.ComboItem();
            this.comboItem18 = new DevComponents.Editors.ComboItem();
            this.comboItem19 = new DevComponents.Editors.ComboItem();
            this.comboItem20 = new DevComponents.Editors.ComboItem();
            this.comboItem21 = new DevComponents.Editors.ComboItem();
            this.comboItem22 = new DevComponents.Editors.ComboItem();
            this.comboItem23 = new DevComponents.Editors.ComboItem();
            this.comboItem24 = new DevComponents.Editors.ComboItem();
            this.comboItem25 = new DevComponents.Editors.ComboItem();
            this.comboItem26 = new DevComponents.Editors.ComboItem();
            this.comboItem27 = new DevComponents.Editors.ComboItem();
            this.comboItem28 = new DevComponents.Editors.ComboItem();
            this.comboItem29 = new DevComponents.Editors.ComboItem();
            this.comboItem30 = new DevComponents.Editors.ComboItem();
            this.comboItem31 = new DevComponents.Editors.ComboItem();
            this.comboItem32 = new DevComponents.Editors.ComboItem();
            this.comboItem33 = new DevComponents.Editors.ComboItem();
            this.comboItem34 = new DevComponents.Editors.ComboItem();
            this.comboItem35 = new DevComponents.Editors.ComboItem();
            this.comboItem36 = new DevComponents.Editors.ComboItem();
            this.comboItem37 = new DevComponents.Editors.ComboItem();
            this.comboItem38 = new DevComponents.Editors.ComboItem();
            this.comboItem39 = new DevComponents.Editors.ComboItem();
            this.comboItem40 = new DevComponents.Editors.ComboItem();
            this.comboItem41 = new DevComponents.Editors.ComboItem();
            this.comboItem42 = new DevComponents.Editors.ComboItem();
            this.comboItem43 = new DevComponents.Editors.ComboItem();
            this.comboItem44 = new DevComponents.Editors.ComboItem();
            this.comboItem45 = new DevComponents.Editors.ComboItem();
            this.comboItem46 = new DevComponents.Editors.ComboItem();
            this.comboItem47 = new DevComponents.Editors.ComboItem();
            this.comboItem48 = new DevComponents.Editors.ComboItem();
            this.comboItem49 = new DevComponents.Editors.ComboItem();
            this.comboItem50 = new DevComponents.Editors.ComboItem();
            this.comboItem51 = new DevComponents.Editors.ComboItem();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonX12 = new DevComponents.DotNetBar.ButtonX();
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonX10 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.comboItem102 = new DevComponents.Editors.ComboItem();
            this.comboItem101 = new DevComponents.Editors.ComboItem();
            this.comboItem100 = new DevComponents.Editors.ComboItem();
            this.comboItem99 = new DevComponents.Editors.ComboItem();
            this.comboItem98 = new DevComponents.Editors.ComboItem();
            this.comboItem97 = new DevComponents.Editors.ComboItem();
            this.comboItem96 = new DevComponents.Editors.ComboItem();
            this.comboItem95 = new DevComponents.Editors.ComboItem();
            this.comboItem94 = new DevComponents.Editors.ComboItem();
            this.comboItem93 = new DevComponents.Editors.ComboItem();
            this.comboItem92 = new DevComponents.Editors.ComboItem();
            this.comboItem91 = new DevComponents.Editors.ComboItem();
            this.comboItem90 = new DevComponents.Editors.ComboItem();
            this.comboItem89 = new DevComponents.Editors.ComboItem();
            this.comboItem88 = new DevComponents.Editors.ComboItem();
            this.comboItem87 = new DevComponents.Editors.ComboItem();
            this.comboItem86 = new DevComponents.Editors.ComboItem();
            this.comboItem85 = new DevComponents.Editors.ComboItem();
            this.comboItem84 = new DevComponents.Editors.ComboItem();
            this.comboItem83 = new DevComponents.Editors.ComboItem();
            this.comboItem82 = new DevComponents.Editors.ComboItem();
            this.comboItem81 = new DevComponents.Editors.ComboItem();
            this.comboItem80 = new DevComponents.Editors.ComboItem();
            this.comboItem79 = new DevComponents.Editors.ComboItem();
            this.comboItem78 = new DevComponents.Editors.ComboItem();
            this.comboItem77 = new DevComponents.Editors.ComboItem();
            this.comboItem76 = new DevComponents.Editors.ComboItem();
            this.comboItem75 = new DevComponents.Editors.ComboItem();
            this.comboItem74 = new DevComponents.Editors.ComboItem();
            this.comboItem73 = new DevComponents.Editors.ComboItem();
            this.comboItem72 = new DevComponents.Editors.ComboItem();
            this.comboItem71 = new DevComponents.Editors.ComboItem();
            this.comboItem70 = new DevComponents.Editors.ComboItem();
            this.comboItem69 = new DevComponents.Editors.ComboItem();
            this.comboItem68 = new DevComponents.Editors.ComboItem();
            this.comboItem67 = new DevComponents.Editors.ComboItem();
            this.comboItem66 = new DevComponents.Editors.ComboItem();
            this.comboItem65 = new DevComponents.Editors.ComboItem();
            this.comboItem64 = new DevComponents.Editors.ComboItem();
            this.comboItem63 = new DevComponents.Editors.ComboItem();
            this.comboItem62 = new DevComponents.Editors.ComboItem();
            this.comboItem61 = new DevComponents.Editors.ComboItem();
            this.comboItem60 = new DevComponents.Editors.ComboItem();
            this.comboItem59 = new DevComponents.Editors.ComboItem();
            this.comboItem58 = new DevComponents.Editors.ComboItem();
            this.comboItem57 = new DevComponents.Editors.ComboItem();
            this.comboItem56 = new DevComponents.Editors.ComboItem();
            this.comboItem55 = new DevComponents.Editors.ComboItem();
            this.comboItem54 = new DevComponents.Editors.ComboItem();
            this.comboItem53 = new DevComponents.Editors.ComboItem();
            this.comboItem52 = new DevComponents.Editors.ComboItem();
            this.rbf1 = new System.Windows.Forms.RadioButton();
            this.rbf2 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerColorTint = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "M. Fiscal :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Code :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Fixe   :";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX3.Location = new System.Drawing.Point(130, 390);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.buttonX3.Size = new System.Drawing.Size(81, 27);
            this.buttonX3.TabIndex = 105;
            this.buttonX3.Text = "&Annuler";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(72, 79);
            this.textBox3.MaxLength = 50;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(308, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Libéllé :";
            // 
            // buttonX8
            // 
            this.buttonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX8.FocusCuesEnabled = false;
            this.buttonX8.Location = new System.Drawing.Point(376, 0);
            this.buttonX8.Name = "buttonX8";
            this.buttonX8.Size = new System.Drawing.Size(37, 26);
            this.buttonX8.TabIndex = 111;
            this.buttonX8.Text = "&Fin";
            this.buttonX8.Click += new System.EventHandler(this.buttonX8_Click);
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX6.FocusCuesEnabled = false;
            this.buttonX6.Location = new System.Drawing.Point(333, 0);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(37, 26);
            this.buttonX6.TabIndex = 109;
            this.buttonX6.Text = "&Préc";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // buttonX7
            // 
            this.buttonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX7.FocusCuesEnabled = false;
            this.buttonX7.Location = new System.Drawing.Point(247, 0);
            this.buttonX7.Name = "buttonX7";
            this.buttonX7.Size = new System.Drawing.Size(37, 26);
            this.buttonX7.TabIndex = 110;
            this.buttonX7.Text = "&Début";
            this.buttonX7.Click += new System.EventHandler(this.buttonX7_Click);
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.AutoExpandOnClick = true;
            this.buttonX5.Location = new System.Drawing.Point(0, 0);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(149, 26);
            this.buttonX5.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem2,
            this.buttonItem3,
            this.buttonItem4});
            this.buttonX5.TabIndex = 107;
            this.buttonX5.Text = "&Menu Société";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "Créer                  F5";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem2.Image")));
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "Modifier              F6\r\n";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem3.Image")));
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "Supprimer          F7";
            this.buttonItem3.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // buttonItem4
            // 
            this.buttonItem4.GlobalItem = false;
            this.buttonItem4.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem4.Image")));
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "Recherche         F1";
            this.buttonItem4.Click += new System.EventHandler(this.buttonItem4_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Adresse:";
            // 
            // requiredFieldValidator5
            // 
            this.requiredFieldValidator5.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator5.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator4
            // 
            this.requiredFieldValidator4.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // buttonX11
            // 
            this.buttonX11.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX11.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX11.FocusCuesEnabled = false;
            this.buttonX11.Location = new System.Drawing.Point(290, 0);
            this.buttonX11.Name = "buttonX11";
            this.buttonX11.Size = new System.Drawing.Size(37, 26);
            this.buttonX11.TabIndex = 108;
            this.buttonX11.Text = "&Suiv";
            this.buttonX11.Click += new System.EventHandler(this.buttonX11_Click);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX4.Location = new System.Drawing.Point(24, 390);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.buttonX4.Size = new System.Drawing.Size(81, 27);
            this.buttonX4.TabIndex = 106;
            this.buttonX4.Text = "&Supprimer";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "GSM :";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.White;
            this.textBox5.Location = new System.Drawing.Point(71, 25);
            this.textBox5.MaxLength = 12;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(106, 20);
            this.textBox5.TabIndex = 4;
            this.textBox5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox5_KeyDown);
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.White;
            this.textBox6.Location = new System.Drawing.Point(71, 55);
            this.textBox6.MaxLength = 12;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(106, 20);
            this.textBox6.TabIndex = 5;
            this.textBox6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox6_KeyDown);
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // superValidator1
            // 
            this.superValidator1.ErrorProvider = this.errorProvider1;
            this.superValidator1.Highlighter = this.highlighter1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(72, 17);
            this.textBox1.MaxLength = 3;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(29, 20);
            this.textBox1.TabIndex = 0;
            this.superValidator1.SetValidator1(this.textBox1, this.requiredFieldValidator8);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // requiredFieldValidator8
            // 
            this.requiredFieldValidator8.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator8.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(72, 48);
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(310, 20);
            this.textBox2.TabIndex = 1;
            this.superValidator1.SetValidator1(this.textBox2, this.requiredFieldValidator9);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // requiredFieldValidator9
            // 
            this.requiredFieldValidator9.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator9.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.White;
            this.textBox9.Location = new System.Drawing.Point(714, 314);
            this.textBox9.MaxLength = 4;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(37, 20);
            this.textBox9.TabIndex = 4;
            this.superValidator1.SetValidator1(this.textBox9, this.requiredFieldValidator6);
            this.textBox9.Visible = false;
            this.textBox9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox9_KeyPress);
            // 
            // requiredFieldValidator6
            // 
            this.requiredFieldValidator6.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator6.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(211, -2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 102;
            this.label4.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox6);
            this.groupBox7.Controls.Add(this.textBox5);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Location = new System.Drawing.Point(27, 269);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(190, 107);
            this.groupBox7.TabIndex = 100;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Téléphone";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox12);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.textBox11);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.textBox8);
            this.groupBox5.Controls.Add(this.textBox7);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.textBox3);
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(27, 39);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(391, 225);
            this.groupBox5.TabIndex = 99;
            this.groupBox5.TabStop = false;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.White;
            this.textBox8.Location = new System.Drawing.Point(107, 18);
            this.textBox8.MaxLength = 12;
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(28, 20);
            this.textBox8.TabIndex = 22;
            this.textBox8.Visible = false;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.White;
            this.textBox7.Location = new System.Drawing.Point(72, 188);
            this.textBox7.MaxLength = 15;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(123, 20);
            this.textBox7.TabIndex = 11;
            this.textBox7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox7_KeyDown);
            this.textBox7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "N° CNSS:";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(71, 159);
            this.textBox4.MaxLength = 20;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(123, 20);
            this.textBox4.TabIndex = 9;
            this.textBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox4_KeyDown);
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // requiredFieldValidator7
            // 
            this.requiredFieldValidator7.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator7.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // styleManager2
            // 
            this.styleManager2.ManagerColorTint = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.styleManager2.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            // 
            // buttonX9
            // 
            this.buttonX9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX9.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX9.FocusCuesEnabled = false;
            this.buttonX9.Location = new System.Drawing.Point(48, 41);
            this.buttonX9.Name = "buttonX9";
            this.buttonX9.Size = new System.Drawing.Size(90, 26);
            this.buttonX9.TabIndex = 111;
            this.buttonX9.Text = "&Créer Exercice";
            this.buttonX9.Click += new System.EventHandler(this.buttonX9_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.anne);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.buttonX9);
            this.groupBox1.Location = new System.Drawing.Point(223, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 106);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exercice";
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.White;
            this.textBox10.Location = new System.Drawing.Point(17, 57);
            this.textBox10.MaxLength = 20;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(130, 20);
            this.textBox10.TabIndex = 122;
            this.textBox10.Visible = false;
            // 
            // anne
            // 
            this.anne.DisplayMember = "Text";
            this.anne.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.anne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.anne.FormattingEnabled = true;
            this.anne.ItemHeight = 14;
            this.anne.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5,
            this.comboItem6,
            this.comboItem7,
            this.comboItem8,
            this.comboItem9,
            this.comboItem10,
            this.comboItem11,
            this.comboItem12,
            this.comboItem13,
            this.comboItem14,
            this.comboItem15,
            this.comboItem16,
            this.comboItem17,
            this.comboItem18,
            this.comboItem19,
            this.comboItem20,
            this.comboItem21,
            this.comboItem22,
            this.comboItem23,
            this.comboItem24,
            this.comboItem25,
            this.comboItem26,
            this.comboItem27,
            this.comboItem28,
            this.comboItem29,
            this.comboItem30,
            this.comboItem31,
            this.comboItem32,
            this.comboItem33,
            this.comboItem34,
            this.comboItem35,
            this.comboItem36,
            this.comboItem37,
            this.comboItem38,
            this.comboItem39,
            this.comboItem40,
            this.comboItem41,
            this.comboItem42,
            this.comboItem43,
            this.comboItem44,
            this.comboItem45,
            this.comboItem46,
            this.comboItem47,
            this.comboItem48,
            this.comboItem49,
            this.comboItem50,
            this.comboItem51});
            this.anne.Location = new System.Drawing.Point(60, 21);
            this.anne.Name = "anne";
            this.anne.Size = new System.Drawing.Size(64, 20);
            this.anne.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.anne.TabIndex = 121;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "2000";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "2001";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "2002";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "2003";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "2004";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "2005";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "2006";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "2007";
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "2008";
            // 
            // comboItem10
            // 
            this.comboItem10.Text = "2009";
            // 
            // comboItem11
            // 
            this.comboItem11.Text = "2010";
            // 
            // comboItem12
            // 
            this.comboItem12.Text = "2011";
            // 
            // comboItem13
            // 
            this.comboItem13.Text = "2012";
            // 
            // comboItem14
            // 
            this.comboItem14.Text = "2013";
            // 
            // comboItem15
            // 
            this.comboItem15.Text = "2014";
            // 
            // comboItem16
            // 
            this.comboItem16.Text = "2015";
            // 
            // comboItem17
            // 
            this.comboItem17.Text = "2016";
            // 
            // comboItem18
            // 
            this.comboItem18.Text = "2017";
            // 
            // comboItem19
            // 
            this.comboItem19.Text = "2018";
            // 
            // comboItem20
            // 
            this.comboItem20.Text = "2019";
            // 
            // comboItem21
            // 
            this.comboItem21.Text = "2020";
            // 
            // comboItem22
            // 
            this.comboItem22.Text = "2021";
            // 
            // comboItem23
            // 
            this.comboItem23.Text = "2022";
            // 
            // comboItem24
            // 
            this.comboItem24.Text = "2023";
            // 
            // comboItem25
            // 
            this.comboItem25.Text = "2024";
            // 
            // comboItem26
            // 
            this.comboItem26.Text = "2025";
            // 
            // comboItem27
            // 
            this.comboItem27.Text = "2026";
            // 
            // comboItem28
            // 
            this.comboItem28.Text = "2027";
            // 
            // comboItem29
            // 
            this.comboItem29.Text = "2028";
            // 
            // comboItem30
            // 
            this.comboItem30.Text = "2029";
            // 
            // comboItem31
            // 
            this.comboItem31.Text = "2030";
            // 
            // comboItem32
            // 
            this.comboItem32.Text = "2031";
            // 
            // comboItem33
            // 
            this.comboItem33.Text = "2032";
            // 
            // comboItem34
            // 
            this.comboItem34.Text = "2033";
            // 
            // comboItem35
            // 
            this.comboItem35.Text = "2034";
            // 
            // comboItem36
            // 
            this.comboItem36.Text = "2035";
            // 
            // comboItem37
            // 
            this.comboItem37.Text = "2036";
            // 
            // comboItem38
            // 
            this.comboItem38.Text = "2037";
            // 
            // comboItem39
            // 
            this.comboItem39.Text = "2038";
            // 
            // comboItem40
            // 
            this.comboItem40.Text = "2039";
            // 
            // comboItem41
            // 
            this.comboItem41.Text = "2040";
            // 
            // comboItem42
            // 
            this.comboItem42.Text = "2041";
            // 
            // comboItem43
            // 
            this.comboItem43.Text = "2042";
            // 
            // comboItem44
            // 
            this.comboItem44.Text = "2043";
            // 
            // comboItem45
            // 
            this.comboItem45.Text = "2044";
            // 
            // comboItem46
            // 
            this.comboItem46.Text = "2045";
            // 
            // comboItem47
            // 
            this.comboItem47.Text = "2046";
            // 
            // comboItem48
            // 
            this.comboItem48.Text = "2047";
            // 
            // comboItem49
            // 
            this.comboItem49.Text = "2048";
            // 
            // comboItem50
            // 
            this.comboItem50.Text = "2049";
            // 
            // comboItem51
            // 
            this.comboItem51.Text = "2050";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 120;
            this.label12.Text = "Année :";
            this.label12.Visible = false;
            // 
            // buttonX12
            // 
            this.buttonX12.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX12.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX12.FocusCuesEnabled = false;
            this.buttonX12.Location = new System.Drawing.Point(494, 333);
            this.buttonX12.Name = "buttonX12";
            this.buttonX12.Size = new System.Drawing.Size(63, 26);
            this.buttonX12.TabIndex = 114;
            this.buttonX12.Text = "Annuler";
            this.buttonX12.Visible = false;
            this.buttonX12.Click += new System.EventHandler(this.buttonX12_Click);
            // 
            // progressBarX1
            // 
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.Class = "";
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.Location = new System.Drawing.Point(580, 364);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new System.Drawing.Size(171, 24);
            this.progressBarX1.TabIndex = 115;
            this.progressBarX1.Text = "progressBarX1";
            this.progressBarX1.Visible = false;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 14;
            this.comboBoxEx1.Location = new System.Drawing.Point(623, 307);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(52, 20);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 114;
            this.comboBoxEx1.Visible = false;
            this.comboBoxEx1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxEx1_KeyPress);
            // 
            // buttonX10
            // 
            this.buttonX10.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX10.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX10.FocusCuesEnabled = false;
            this.buttonX10.Location = new System.Drawing.Point(507, 365);
            this.buttonX10.Name = "buttonX10";
            this.buttonX10.Size = new System.Drawing.Size(63, 26);
            this.buttonX10.TabIndex = 113;
            this.buttonX10.Text = "&Sauver";
            this.buttonX10.Visible = false;
            this.buttonX10.Click += new System.EventHandler(this.buttonX10_Click_1);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.White;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.FocusCuesEnabled = false;
            this.buttonX1.ForeColor = System.Drawing.Color.White;
            this.buttonX1.Location = new System.Drawing.Point(114, 387);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(88, 26);
            this.buttonX1.TabIndex = 130;
            this.buttonX1.Text = "&Annuler";
            this.buttonX1.Visible = false;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.BackColor = System.Drawing.Color.White;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX2.FocusCuesEnabled = false;
            this.buttonX2.ForeColor = System.Drawing.Color.White;
            this.buttonX2.Location = new System.Drawing.Point(23, 387);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(88, 26);
            this.buttonX2.TabIndex = 131;
            this.buttonX2.Text = "&Sauver";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // comboItem102
            // 
            this.comboItem102.Text = "2050";
            // 
            // comboItem101
            // 
            this.comboItem101.Text = "2049";
            // 
            // comboItem100
            // 
            this.comboItem100.Text = "2048";
            // 
            // comboItem99
            // 
            this.comboItem99.Text = "2047";
            // 
            // comboItem98
            // 
            this.comboItem98.Text = "2046";
            // 
            // comboItem97
            // 
            this.comboItem97.Text = "2045";
            // 
            // comboItem96
            // 
            this.comboItem96.Text = "2044";
            // 
            // comboItem95
            // 
            this.comboItem95.Text = "2043";
            // 
            // comboItem94
            // 
            this.comboItem94.Text = "2042";
            // 
            // comboItem93
            // 
            this.comboItem93.Text = "2041";
            // 
            // comboItem92
            // 
            this.comboItem92.Text = "2040";
            // 
            // comboItem91
            // 
            this.comboItem91.Text = "2039";
            // 
            // comboItem90
            // 
            this.comboItem90.Text = "2038";
            // 
            // comboItem89
            // 
            this.comboItem89.Text = "2037";
            // 
            // comboItem88
            // 
            this.comboItem88.Text = "2036";
            // 
            // comboItem87
            // 
            this.comboItem87.Text = "2035";
            // 
            // comboItem86
            // 
            this.comboItem86.Text = "2034";
            // 
            // comboItem85
            // 
            this.comboItem85.Text = "2033";
            // 
            // comboItem84
            // 
            this.comboItem84.Text = "2032";
            // 
            // comboItem83
            // 
            this.comboItem83.Text = "2031";
            // 
            // comboItem82
            // 
            this.comboItem82.Text = "2030";
            // 
            // comboItem81
            // 
            this.comboItem81.Text = "2029";
            // 
            // comboItem80
            // 
            this.comboItem80.Text = "2028";
            // 
            // comboItem79
            // 
            this.comboItem79.Text = "2027";
            // 
            // comboItem78
            // 
            this.comboItem78.Text = "2026";
            // 
            // comboItem77
            // 
            this.comboItem77.Text = "2025";
            // 
            // comboItem76
            // 
            this.comboItem76.Text = "2024";
            // 
            // comboItem75
            // 
            this.comboItem75.Text = "2023";
            // 
            // comboItem74
            // 
            this.comboItem74.Text = "2022";
            // 
            // comboItem73
            // 
            this.comboItem73.Text = "2021";
            // 
            // comboItem72
            // 
            this.comboItem72.Text = "2020";
            // 
            // comboItem71
            // 
            this.comboItem71.Text = "2019";
            // 
            // comboItem70
            // 
            this.comboItem70.Text = "2018";
            // 
            // comboItem69
            // 
            this.comboItem69.Text = "2017";
            // 
            // comboItem68
            // 
            this.comboItem68.Text = "2016";
            // 
            // comboItem67
            // 
            this.comboItem67.Text = "2015";
            // 
            // comboItem66
            // 
            this.comboItem66.Text = "2014";
            // 
            // comboItem65
            // 
            this.comboItem65.Text = "2013";
            // 
            // comboItem64
            // 
            this.comboItem64.Text = "2012";
            // 
            // comboItem63
            // 
            this.comboItem63.Text = "2011";
            // 
            // comboItem62
            // 
            this.comboItem62.Text = "2010";
            // 
            // comboItem61
            // 
            this.comboItem61.Text = "2009";
            // 
            // comboItem60
            // 
            this.comboItem60.Text = "2008";
            // 
            // comboItem59
            // 
            this.comboItem59.Text = "2007";
            // 
            // comboItem58
            // 
            this.comboItem58.Text = "2006";
            // 
            // comboItem57
            // 
            this.comboItem57.Text = "2005";
            // 
            // comboItem56
            // 
            this.comboItem56.Text = "2004";
            // 
            // comboItem55
            // 
            this.comboItem55.Text = "2003";
            // 
            // comboItem54
            // 
            this.comboItem54.Text = "2002";
            // 
            // comboItem53
            // 
            this.comboItem53.Text = "2001";
            // 
            // comboItem52
            // 
            this.comboItem52.Text = "2000";
            // 
            // rbf1
            // 
            this.rbf1.AutoSize = true;
            this.rbf1.Location = new System.Drawing.Point(6, 22);
            this.rbf1.Name = "rbf1";
            this.rbf1.Size = new System.Drawing.Size(41, 17);
            this.rbf1.TabIndex = 20;
            this.rbf1.Text = "Oui";
            this.rbf1.UseVisualStyleBackColor = true;
            // 
            // rbf2
            // 
            this.rbf2.AutoSize = true;
            this.rbf2.Checked = true;
            this.rbf2.Location = new System.Drawing.Point(50, 22);
            this.rbf2.Name = "rbf2";
            this.rbf2.Size = new System.Drawing.Size(44, 17);
            this.rbf2.TabIndex = 21;
            this.rbf2.TabStop = true;
            this.rbf2.Text = "Non";
            this.rbf2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbf2);
            this.groupBox2.Controls.Add(this.rbf1);
            this.groupBox2.Location = new System.Drawing.Point(636, 407);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(98, 52);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fodec";
            this.groupBox2.Visible = false;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.Color.White;
            this.textBox11.Location = new System.Drawing.Point(71, 102);
            this.textBox11.MaxLength = 50;
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(308, 20);
            this.textBox11.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "GERANT:";
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.Color.White;
            this.textBox12.Location = new System.Drawing.Point(71, 128);
            this.textBox12.MaxLength = 50;
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(308, 20);
            this.textBox12.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(2, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "FONCTION:";
            // 
            // ste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(439, 437);
            this.Controls.Add(this.buttonX12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.progressBarX1);
            this.Controls.Add(this.comboBoxEx1);
            this.Controls.Add(this.buttonX10);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX8);
            this.Controls.Add(this.buttonX6);
            this.Controls.Add(this.buttonX7);
            this.Controls.Add(this.buttonX5);
            this.Controls.Add(this.buttonX11);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ste";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Société";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ste_FormClosed);
            this.Load += new System.EventHandler(this.ste_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ste_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void ste_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }
       


    }
}
