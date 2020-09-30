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
    public partial class Article : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        int index = 0 , xindex =0;
        DataSet ds;
        Boolean modif = false;
        Boolean act = false;
        List<Cdepot> LstDepot = new List<Cdepot>();
        String path_img = "";
        List<object> SuppSart = new List<object>();
        List<object> SuppGamme = new List<object>();
        Byte[] Image_stream;
        Boolean maj = false;
        Decimal ancpuht = 0;
        public Article()
        {
            InitializeComponent();
            buttonX5.Visible = true;
            buttonX1.Visible = false;
            buttonX2.Visible = false;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
        }

        private void calcularticle()
        {
            //début calcul
            Double wmarge = 0, wpaht = 0, wpattc, wpuht = 0, wputtc = 0, wtva = 0, wpvpht = 0, wpvpttc = 0;
            Double.TryParse(textBoxX13.Text, out wmarge);
            Double.TryParse(cmbtva.SelectedValue + "", out wtva);
            Double.TryParse(textBoxX11.Text, out wpaht);
            Double.TryParse(textBoxX16.Text, out wpvpht);

            wpattc = wpaht + wpaht * wtva / 100;

            if (wmarge != 0)
                wpuht = wpaht + wpaht * wmarge / 100;
            else
                Double.TryParse(textBoxX14.Text, out wpuht);

            wputtc = wpuht + wpuht * wtva / 100;
            wpvpttc = wpvpht + wpvpht * wtva / 100;
            textBoxX11.Text = wpaht.ToString("N3");
            textBoxX12.Text = wpattc.ToString("N3");
            textBoxX14.Text = wpuht.ToString("N3");
            textBoxX15.Text = wputtc.ToString("N3");
            textBoxX16.Text = wpvpht.ToString("N3");
            textBoxX17.Text = wpvpttc.ToString("N3");
            //fin calcul
        }

         private void affiche()
        {
            act = true;
            string req = "SELECT * FROM article WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
            ds = met.recuperer_table(req, "Article");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    label27.Text = ds.Tables[0].Rows[index].Field<Object>("um") + "";
                    textBoxX1.Text = ds.Tables[0].Rows[index].Field<Object>("code") + ""; // Objet Non null
                    textBoxX30.Text = ds.Tables[0].Rows[index].Field<Object>("codeb") + ""; // Objet Non null
                    textBoxX2.Text = ds.Tables[0].Rows[index].Field<Object>("libelle") + "";
                    textBoxX3.Text = ds.Tables[0].Rows[index].Field<Object>("codeo") + ""; // Objet null
                    textBoxX4.Text = ds.Tables[0].Rows[index].Field<Object>("marque") + "";
                    textBoxX5.Text = ds.Tables[0].Rows[index].Field<Object>("um") + "";
                    textBoxX6.Text = ds.Tables[0].Rows[index].Field<Object>("cara") + "";
                    cmbtva.SelectedValue = ds.Tables[0].Rows[index].Field<Object>("tva") + "";
                    cmbfodec.SelectedValue = ds.Tables[0].Rows[index].Field<Object>("fodec") + "";
                    cmbtaxe.SelectedValue = ds.Tables[0].Rows[index].Field<Object>("taxe") + "";
                    cmbfama.SelectedValue = ds.Tables[0].Rows[index].Field<Object>("codef") + "";


                    Boolean bvstk = ds.Tables[0].Rows[index].Field<Boolean>("vstk");
                    if (bvstk)
                        radioButton2.Checked = true;
                    else
                        radioButton1.Checked = true;

                    Boolean bvpa = ds.Tables[0].Rows[index].Field<Boolean>("vpa");
                    if (bvpa)
                        radioButton5.Checked = true;
                    else
                        radioButton6.Checked = true;

                    Boolean bbenef = ds.Tables[0].Rows[index].Field<Boolean>("benef");
                    if (bbenef)
                        radioButton4.Checked = true;
                    else
                        radioButton3.Checked = true;

                    Boolean bmajore = ds.Tables[0].Rows[index].Field<Boolean>("majore");
                    if (bmajore)
                        radioButton8.Checked = true;
                    else
                        radioButton7.Checked = true;

                    Boolean vente = ds.Tables[0].Rows[index].Field<Boolean>("vente");
                    if (vente)
                        checkBoxX1.Checked = true;
                    else
                        checkBoxX1.Checked = false;

                    Boolean achat = ds.Tables[0].Rows[index].Field<Boolean>("achat");
                    if (achat)
                        checkBoxX2.Checked = true;
                    else
                        checkBoxX2.Checked = false;

                    Boolean tvavente = ds.Tables[0].Rows[index].Field<Boolean>("tvavente");
                    if (tvavente)
                        checkBoxX3.Checked = true;
                    else
                        checkBoxX3.Checked = false;

                    Boolean tvaachat = ds.Tables[0].Rows[index].Field<Boolean>("tvaachat");
                    if (tvaachat)
                        checkBoxX4.Checked = true;
                    else
                        checkBoxX4.Checked = false;


                    try
                    {
                        textBoxX7.Text = ds.Tables[0].Rows[index].Field<double>("qtedep").ToString("N3");
                    }
                    catch { textBoxX7.Text = ""; }

                    try
                    {
                        textBoxX8.Text = ds.Tables[0].Rows[index].Field<double>("qteent").ToString("N3");
                    }
                    catch { textBoxX8.Text = ""; }

                    try
                    {
                        textBoxX9.Text = ds.Tables[0].Rows[index].Field<double>("qtesor").ToString("N3");
                    }
                    catch { textBoxX9.Text = ""; }

                    try
                    {
                        textBoxX10.Text = ds.Tables[0].Rows[index].Field<double>("qtestk").ToString("N3");
                    }
                    catch { textBoxX10.Text = ""; }

                    try
                    {
                        textBoxX21.Text = ds.Tables[0].Rows[index].Field<double>("qteavrc").ToString("N3");
                    }
                    catch { textBoxX21.Text = ""; }

                    try
                    {
                        textBoxX22.Text = ds.Tables[0].Rows[index].Field<double>("qteavrf").ToString("N3");
                    }
                    catch { textBoxX22.Text = ""; }

                    try
                    {
                        textBoxX31.Text = ds.Tables[0].Rows[index].Field<double>("emb").ToString("N0");
                    }
                    catch { textBoxX31.Text = ""; }

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





                    try
                    {
                        textBoxX11.Text = ds.Tables[0].Rows[index].Field<Decimal>("paht").ToString("N3");
                    }
                    catch { textBoxX11.Text = ""; }

                    try
                    {
                        textBoxX12.Text = ds.Tables[0].Rows[index].Field<Decimal>("pattc").ToString("N3");
                    }
                    catch { textBoxX12.Text = ""; }

                    try
                    {
                        textBoxX13.Text = ds.Tables[0].Rows[index].Field<double>("marge").ToString("N2");
                    }
                    catch { textBoxX13.Text = ""; }

                    try
                    {
                        textBoxX14.Text = ds.Tables[0].Rows[index].Field<Decimal>("puht").ToString("N3");
                        ancpuht = ds.Tables[0].Rows[index].Field<Decimal>("puht");
                    }
                    catch { textBoxX14.Text = ""; }

                    try
                    {
                        textBoxX15.Text = ds.Tables[0].Rows[index].Field<Decimal>("puttc").ToString("N3");
                    }
                    catch { textBoxX15.Text = ""; }

                    try
                    {
                        textBoxX16.Text = ds.Tables[0].Rows[index].Field<Decimal>("pvpht").ToString("N3");
                    }
                    catch { textBoxX16.Text = ""; }

                    try
                    {
                        textBoxX17.Text = ds.Tables[0].Rows[index].Field<Decimal>("pvpttc").ToString("N3");
                    }
                    catch { textBoxX17.Text = ""; }

                    try
                    {
                        textBoxX18.Text = ds.Tables[0].Rows[index].Field<double>("dext").ToString("N2");
                    }
                    catch { textBoxX18.Text = ""; }

                    try
                    {
                        textBoxX19.Text = ds.Tables[0].Rows[index].Field<double>("dint").ToString("N2");
                    }
                    catch { textBoxX19.Text = ""; }

                    try
                    {
                        textBoxX20.Text = ds.Tables[0].Rows[index].Field<double>("haut").ToString("N2");
                    }
                    catch { textBoxX20.Text = ""; }

                    // Article Magasin
                    String reqmag = "SELECT * FROM artmag  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and codea='" + textBoxX1.Text + "'";
                    DataSet dsmag = met.recuperer_table(reqmag, "artmag");

                    if (dsmag != null)
                        if (dsmag.Tables[0].Rows.Count != 0)
                        {
                            try
                            {
                                textBoxX29.Text = dsmag.Tables[0].Rows[0].Field<double>("qteseuil").ToString("N3");
                            }
                            catch { textBoxX29.Text = ""; }

                            try
                            {
                                textBoxX28.Text = dsmag.Tables[0].Rows[0].Field<double>("qtedep").ToString("N3");
                            }
                            catch { textBoxX28.Text = ""; }

                            try
                            {
                                textBoxX27.Text = dsmag.Tables[0].Rows[0].Field<double>("qteent").ToString("N3");
                            }
                            catch { textBoxX27.Text = ""; }

                            try
                            {
                                textBoxX26.Text = dsmag.Tables[0].Rows[0].Field<double>("qtesor").ToString("N3");
                            }
                            catch { textBoxX26.Text = ""; }

                            try
                            {
                                textBoxX25.Text = dsmag.Tables[0].Rows[0].Field<double>("qtestk").ToString("N3");
                            }
                            catch { textBoxX25.Text = ""; }

                            try
                            {
                                textBoxX24.Text = dsmag.Tables[0].Rows[0].Field<double>("qteavrc").ToString("N3");
                            }
                            catch { textBoxX24.Text = ""; }

                            try
                            {
                                textBoxX23.Text = dsmag.Tables[0].Rows[0].Field<double>("qteavrf").ToString("N3");
                            }
                            catch { textBoxX23.Text = ""; }
                        }

                    // Article Dépot
                    String reqartd = "SELECT d.`libelle` as Depot, g.`libelle` as Gamme,ad.qtedep,ad.qteent,ad.qteavrc,ad.qtesor,ad.qteavrf,ad.qtestk  FROM artdep ad, depot d, gamme g  where ad.codes='" + Program.Societe + "' and ad.codee = '" + Program.Exercice + "' and ad.codem = '" + Program.Magasin + "' and ad.codea='" + textBoxX1.Text + "' AND g.`codeg` = ad.`codeg` AND d.`code`=ad.`coded` AND ad.`codes`=d.`codes` AND ad.`codee`=d.`codee` AND ad.`codem`=d.`codem` AND g.`codes`=ad.`codes` AND ad.`codee`=g.`codee` AND ad.`codea`=g.`codea`";
                    DataSet dsartd = met.recuperer_table(reqartd, "artdep");
                    if (dsartd != null)
                    {
                        if (dsartd.Tables[0].Rows.Count != 0)
                        {
                            if (dsartd.Tables[0].Rows[0]["Gamme"].ToString() == "Defaut")
                            {

                                mygrid2.Columns["Column2"].Visible = false;
                            }
                            else
                                mygrid2.Columns["Column2"].Visible = true;
                        }

                        mygrid2.DataSource = dsartd.Tables["artdep"].DefaultView;
                    }

                    // Chercher nbre de dépots
                    String reqd = "SELECT * FROM depot  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "'";
                    DataSet dsd = met.recuperer_table(reqd, "depot");
                    if (dsd != null)
                        if (dsd.Tables.Count != 0)
                        {
                            if (dsd.Tables[0].Rows.Count == 1)
                            {
                                tabItem8.Text = "Stk Dépôt / Gamme";
                                mygrid2.Columns["Column1"].Visible = true;
                            }
                            else
                            {
                                tabItem8.Text = "Stk Dépôt / Gamme";
                                mygrid2.Columns["Column1"].Visible = true;
                            }
                        }
                    if (dsartd.Tables[0].Rows[0]["Gamme"].ToString() == "Defaut" && dsd.Tables[0].Rows.Count == 1)
                    {

                        tabItem8.Visible = true;
                    }
                    else
                        tabItem8.Visible = true;




                    depot.SelectedIndex = -1;
                    try
                    {
                        LstDepot.Clear();
                        for (int y1 = 0; y1 < depot.Items.Count; y1++)
                        {
                            secteur.SelectedIndex = -1;
                            rayon.SelectedIndex = -1;
                            etagere.SelectedIndex = -1;
                            casier.SelectedIndex = -1;
                            depot.SelectedIndex = y1;
                            Cdepot cd = new Cdepot();
                            cd.coded = "" + depot.SelectedValue;
                            cd.codesec = "" + secteur.SelectedValue;
                            cd.coder = "" + rayon.SelectedValue;
                            cd.codep = "" + etagere.SelectedValue;
                            cd.codec = "" + casier.SelectedValue;
                            LstDepot.Add(cd);

                        }
                        depot.SelectedIndex = 0;
                    }
                    catch { }

                    // Gamme
                    String reqg = "SELECT codeg,libelle FROM gamme  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea='" + textBoxX1.Text + "' and codeg<>'0000000000'";
                    DataSet dsg = met.recuperer_table(reqg, "gamme");

                    if (dsg != null)
                        mygrid1.DataSource = dsg.Tables["gamme"].DefaultView;


                    // sous article
                    String reqs = "SELECT code,libelle,pu,tva FROM sarticle  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea='" + textBoxX1.Text + "'";
                    DataSet dss = met.recuperer_table(reqs, "sarticle");

                    if (dss != null)
                        mygrid3.DataSource = dss.Tables["sarticle"].DefaultView;

                    act = false;
                }
            }
        }


        private void buttonItem1_Click(object sender, EventArgs e)
        {
            label5.Text = "Cliquer Içi Pour ajouter une image";

            // Bouton créer
            xindex = index;
            maj = true;

            // Chercher Dépot
            String reqd = "SELECT * FROM depot  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin+ "'";
            DataSet dsd = met.recuperer_table(reqd, "depot");
            if (dsd != null)
                 if (dsd.Tables.Count != 0)
                 {
                     if (dsd.Tables[0].Rows.Count != 0)
                     {

                         try
                         {
                             ((System.Data.DataView)mygrid1.DataSource).Table.Clear();
                         }
                         catch { }

                         try
                         {
                             ((System.Data.DataView)mygrid2.DataSource).Table.Clear();
                         }
                         catch { }

                         try
                         {
                             ((System.Data.DataView)mygrid3.DataSource).Table.Clear();
                         }
                         catch { }

                         LstDepot.Clear();
                         for (int y1 = 0; y1 < depot.Items.Count; y1++)
                         {
                             secteur.SelectedIndex = -1;
                             rayon.SelectedIndex = -1;
                             etagere.SelectedIndex = -1;
                             casier.SelectedIndex = -1;
                             depot.SelectedIndex = y1;
                             Cdepot cd = new Cdepot();
                             cd.coded = "" + depot.SelectedValue;
                             cd.codesec = "" + secteur.SelectedValue;
                             cd.coder = "" + rayon.SelectedValue;
                             cd.codep = "" + etagere.SelectedValue;
                             cd.codec = "" + casier.SelectedValue;
                             LstDepot.Add(cd);

                         }

                         panel1.Enabled = true;
                         panel1.BackgroundImage = null;
                         Image_stream = new byte[0];

                         buttonX1.Visible = true;
                         buttonX2.Visible = true;
                         buttonX5.Visible = false;
                         buttonX6.Visible = false;
                         buttonX7.Visible = false;
                         buttonX8.Visible = false;
                         buttonX11.Visible = false;

                         buttonX10.Enabled = true;

                         buttonX16.Enabled = true;
                         buttonX19.Enabled = true;
                         buttonX20.Enabled = true;
                         buttonX21.Enabled = true;

                         textBoxX1.Text = "";
                         textBoxX2.Text = "";
                         textBoxX3.Text = "";
                         textBoxX4.Text = "";
                         textBoxX5.Text = "";
                         textBoxX6.Text = "";

                         textBoxX7.Text = "";
                         textBoxX8.Text = "";
                         textBoxX9.Text = "";
                         textBoxX10.Text = "";
                         textBoxX11.Text = "";
                         textBoxX12.Text = "";
                         textBoxX13.Text = "";
                         textBoxX14.Text = "";
                         textBoxX15.Text = "";
                         textBoxX16.Text = "";
                         textBoxX17.Text = "";
                         textBoxX18.Text = "";
                         textBoxX19.Text = "";
                         textBoxX20.Text = "";
                         textBoxX21.Text = "";
                         textBoxX22.Text = "";
                         textBoxX29.Text = "";
                         textBoxX30.Text = "";
                         textBoxX31.Text = "1";

                         textBoxX1.ReadOnly = false;
                         textBoxX2.ReadOnly = false;
                         textBoxX3.ReadOnly = false;
                         textBoxX4.ReadOnly = false;
                         textBoxX5.ReadOnly = false;

                         textBoxX7.ReadOnly = false;
                         textBoxX11.ReadOnly = false;
                         textBoxX13.ReadOnly = false;
                         textBoxX14.ReadOnly = false;
                         textBoxX16.ReadOnly = false;
                         textBoxX18.ReadOnly = false;
                         textBoxX19.ReadOnly = false;
                         textBoxX20.ReadOnly = false;
                         textBoxX29.ReadOnly = false;
                         textBoxX30.ReadOnly = false;
                         textBoxX31.ReadOnly = false;

                         cmbfama.SelectedIndex = -1;
                         cmbtva.SelectedIndex = -1;
                         cmbfodec.SelectedIndex = -1;
                         cmbtaxe.SelectedIndex = -1;

                         checkBoxX1.Enabled = true;
                         checkBoxX2.Enabled = true;
                         checkBoxX1.Checked = true;
                         checkBoxX2.Checked = true;

                         checkBoxX3.Enabled = true;
                         checkBoxX4.Enabled = true;
                         checkBoxX3.Checked = true;
                         checkBoxX4.Checked = true;

                         radioButton1.Checked = false;
                         radioButton2.Checked = true;

                         radioButton3.Checked = false;
                         radioButton4.Checked = true;

                         radioButton7.Checked = true;
                         radioButton8.Checked = false;

                         radioButton5.Checked = false;
                         radioButton6.Checked = true;

                         cmbtva.Enabled = true;
                         cmbfodec.Enabled = true;
                         cmbtaxe.Enabled = true;
                         cmbfama.Enabled = true;

                         secteur.SelectedIndex = -1;
                         rayon.SelectedIndex = -1;
                         etagere.SelectedIndex = -1;
                         casier.SelectedIndex = -1;

                         secteur.Enabled = true;
                         rayon.Enabled = true;
                         etagere.Enabled = true;
                         casier.Enabled = true;

                         mygrid1.Enabled = true;
                         mygrid3.Enabled = true;
                         textBoxX1.Focus();
                        
                        
                     }
                     else
                         MessageBox.Show("Il Faut Créer Au moins 1 Dépôt");

                 }
          
            
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            SuppSart.Clear();
            // Bouton Modifier
            if (ds.Tables[0].Rows.Count != 0)
            {
                maj = true;
                label5.Text = "Cliquer Içi Pour Modifier l'image";
                xindex = index;
                buttonX5.Visible = false;
                buttonX1.Visible = true;
                buttonX2.Visible = true;
                buttonX6.Visible = false;
                buttonX7.Visible = false;
                buttonX8.Visible = false;
                buttonX11.Visible = false;

                panel1.Enabled = true;

                buttonX10.Enabled = true;
                buttonX16.Enabled = true;
                buttonX19.Enabled = true;
                buttonX20.Enabled = true;
                buttonX21.Enabled = true;

                textBoxX1.ReadOnly = true;
                textBoxX2.ReadOnly = false;
                textBoxX3.ReadOnly = false;
                textBoxX2.ReadOnly = false;
                textBoxX3.ReadOnly = false;
                textBoxX4.ReadOnly = false;
                textBoxX5.ReadOnly = false;
                textBoxX6.ReadOnly = false;

                textBoxX7.ReadOnly = false;
                textBoxX11.ReadOnly = false;
                textBoxX13.ReadOnly = false;
                textBoxX14.ReadOnly = false;
                textBoxX16.ReadOnly = false;
                textBoxX18.ReadOnly = false;
                textBoxX19.ReadOnly = false;
                textBoxX20.ReadOnly = false;
                textBoxX29.ReadOnly = false;
                textBoxX30.ReadOnly = false;
                textBoxX31.ReadOnly = false;

                checkBoxX1.Enabled = true;
                checkBoxX2.Enabled = true;
                checkBoxX3.Enabled = true;
                checkBoxX4.Enabled = true;


                cmbtva.Enabled = true;
                cmbfodec.Enabled = true;
                cmbtaxe.Enabled = true;
                cmbfama.Enabled = true;
                secteur.Enabled = true;
                rayon.Enabled = true;
                etagere.Enabled = true;
                casier.Enabled = true;
                mygrid1.Enabled = true;
                mygrid3.Enabled = true;
                textBoxX30.Focus();


               String reqartd = "SELECT d.`libelle` as Depot, g.`libelle` as Gamme,ad.qtedep,ad.qteent,ad.qteavrc,ad.qtesor,ad.qteavrf,ad.qtestk  FROM artdep ad, depot d, gamme g  where ad.codes='" + Program.Societe + "' and ad.codee = '" + Program.Exercice + "' and ad.codem = '" + Program.Magasin + "' and ad.codea='" + textBoxX1.Text + "' AND g.`codeg` = ad.`codeg` AND d.`code`=ad.`coded` AND ad.`codes`=d.`codes` AND ad.`codee`=d.`codee` AND ad.`codem`=d.`codem` AND g.`codes`=ad.`codes` AND ad.`codee`=g.`codee` AND ad.`codea`=g.`codea`";
               DataSet dsartd = met.recuperer_table(reqartd, "artdep");
               if (dsartd != null)
               {
                    if (dsartd.Tables[0].Rows[0]["Gamme"].ToString() == "Defaut" )
                        mygrid1.Enabled = false;

               }
                modif = true;
              
            }
            else
                MessageBox.Show("Créer Article dabord");

           
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            // Bouton supprimer
            if (ds.Tables[0].Rows.Count != 0)
            {
                double x1 = 0 , x2 =0 , x3 =0, x4 =0, x5 =0 , x6 =0;
                double w1 = 0, w2 = 0, w3 = 0, w4 = 0, w5 = 0, w6 = 0;
                string req1 = "select qtedep,qteent,qtesor,qteavrc,qteavrf,qtestk from artmag where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'  and codea = '" + textBoxX1.Text + "' ";
                DataSet ds1 = met.recuperer_table(req1, "artmag");
                if (ds1 != null)
                {
                    foreach (DataRow dr1 in ds1.Tables["artmag"].Rows)
                    {
                        double.TryParse(dr1["qtedep"] + "", out x1);
                        double.TryParse(dr1["qtesor"] + "", out x2);
                        double.TryParse(dr1["qteent"] + "", out x3);
                        double.TryParse(dr1["qteavrc"] + "", out x4);
                        double.TryParse(dr1["qteavrf"] + "", out x5);
                        double.TryParse(dr1["qtestk"] + "", out x6);
                        w1 += x1; w2 += x2; w3 += x3; w4 += x4; w5 += x5; w6 += x6;
                    }

                    if (w1 == 0 && w2 == 0 && w3 == 0 && w4 == 0 && w5 == 0 && w6 == 0)
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
                    }
                    else
                    {
                        MessageBox.Show("Article Mouvementé ! Suppression Impôssible");
                    }
                }
            }
            else
                MessageBox.Show("Créer Article dabord");
           
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {

            // Bouton Recherche
            Rechart form = new Rechart();
            form.table = "Article";
            form.ShowDialog();
            if (form.code != 0)
            {
                List<DataColumn> lis = new List<DataColumn>();
                lis.Add(ds.Tables["Article"].Columns["ID"]);
                ds.Tables["Article"].PrimaryKey = lis.ToArray();
                index = ds.Tables["Article"].Rows.IndexOf(ds.Tables["Article"].Rows.Find(form.code));
                affiche();
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
            String msg = MessageBox.Show("Etes-vous sûr de Supprimer ", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (msg.Equals("Yes"))
             {

                String reqa    = "DELETE FROM Article Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];
                String reqartd = "DELETE FROM artdep where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea='" + textBoxX1.Text + "'";
                String reqartm = "DELETE FROM artmag where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea='" + textBoxX1.Text + "'";
                String reqempl = "DELETE FROM emplacement where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codea='" + textBoxX1.Text + "'";
                String reqgam  = "DELETE FROM gamme where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea='" + textBoxX1.Text + "'";
                String reqsart = "DELETE FROM sarticle where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codea='" + textBoxX1.Text + "'";

                if (met.Execute(reqa) && met.Execute(reqartd) && met.Execute(reqartm) && met.Execute(reqempl) && met.Execute(reqgam) && met.Execute(reqsart))
                 {
                    MessageBox.Show("Suppression effectuée");
                 }
                else
                    MessageBox.Show("Suppression echouée");

             }
            string req5 = "SELECT * FROM article WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
            ds = met.recuperer_table(req5, "Article");

            if (index > 1)
            {
                index--;
            }
            else
                index = 0;
            affiche();
            afficheb();

        }

        private void Article_Load(object sender, EventArgs e)
        {
           Program.desTfunction(this);
           string req2 = "Select * from Tva where actif";
           DataSet ds2 = met.recuperer_table(req2, "Tva");
           BindingSource bs2 = new BindingSource(ds2, "Tva");
           cmbtva.ValueMember = "taux";
           cmbtva.DisplayMember = "taux";
           cmbtva.DataSource = bs2;

           string req3 = "Select * from Fodec";
           DataSet ds3 = met.recuperer_table(req3, "Fodec");
           BindingSource bs3 = new BindingSource(ds3, "Fodec");
           cmbfodec.ValueMember = "taux";
           cmbfodec.DisplayMember = "taux";
           cmbfodec.DataSource = bs3;

           string req13 = "Select * from taxe";
           DataSet ds13 = met.recuperer_table(req13, "taxe");
           BindingSource bs13 = new BindingSource(ds13, "taxe");
           cmbtaxe.ValueMember = "taux";
           cmbtaxe.DisplayMember = "taux";
           cmbtaxe.DataSource = bs13;


           String req4 = "SELECT * FROM FamilleArticle where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "'";
           DataSet ds4 = met.recuperer_table(req4, "FamilleArticle");
           BindingSource bs4 = new BindingSource(ds4, "FamilleArticle");
           cmbfama.ValueMember = "code";
           cmbfama.DisplayMember = "libelle";
           cmbfama.DataSource = bs4;

           String req9 = "SELECT * FROM secteura where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codem = '" + Program.Magasin + "' Order by code ";
           DataSet ds9 = met.recuperer_table(req9, "secteura");
           BindingSource bs9 = new BindingSource(ds9, "secteura");
           secteur.ValueMember = "Code";
           secteur.DisplayMember = "Libelle";
           secteur.DataSource = bs9;

           String req5 = "SELECT * FROM rayon where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codem = '" + Program.Magasin + "' Order by code ";
           DataSet ds5 = met.recuperer_table(req5, "rayon");
           BindingSource bs5 = new BindingSource(ds5, "rayon");
           rayon.ValueMember = "Code";
           rayon.DisplayMember = "Libelle";
           rayon.DataSource = bs5;

           String req6 = "SELECT * FROM etagere where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codem = '" + Program.Magasin + "' Order by code ";
           DataSet ds6 = met.recuperer_table(req6, "etagere");
           BindingSource bs6 = new BindingSource(ds6, "etagere");
           etagere.ValueMember = "Code";
           etagere.DisplayMember = "Libelle";
           etagere.DataSource = bs6;

           String req7 = "SELECT * FROM casier where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codem = '" + Program.Magasin + "' Order by code ";
           DataSet ds7 = met.recuperer_table(req7, "casier");
           BindingSource bs7 = new BindingSource(ds7, "casier");
           casier.ValueMember = "Code";
           casier.DisplayMember = "Libelle";
           casier.DataSource = bs7;

           String req18 = "SELECT * FROM Depot where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codem = '" + Program.Magasin + "' Order by code ";
           DataSet ds18 = met.recuperer_table(req18, "depot");
           BindingSource bs18 = new BindingSource(ds18, "depot");
           depot.ValueMember = "Code";
           depot.DisplayMember = "Libelle";
           depot.DataSource = bs18;
           

           string req = "SELECT * FROM article WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
            ds = met.recuperer_table(req, "Article");
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
                        buttonX5.Visible = true;
                    }
                }

            afficheb();
            buttonX5.Focus();
        }

        private void afficheb()
        {
            maj = false;
            buttonX1.Visible = false;
            buttonX2.Visible = false;
            buttonX5.Visible = true;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX8.Visible = true;
            buttonX11.Visible = true;

            panel1.Enabled = false;

            buttonX10.Enabled = false;
            buttonX16.Enabled = false;
            buttonX19.Enabled = false;
            buttonX20.Enabled = false;
            buttonX21.Enabled = false;

            textBoxX1.ReadOnly = true;
            textBoxX2.ReadOnly = true;
            textBoxX3.ReadOnly = true;
            textBoxX2.ReadOnly = true;
            textBoxX3.ReadOnly = true;
            textBoxX4.ReadOnly = true;
            textBoxX5.ReadOnly = true;
            textBoxX6.ReadOnly = true;
       
            textBoxX7.ReadOnly = true;
            textBoxX11.ReadOnly = true;
            textBoxX13.ReadOnly = true;
            textBoxX14.ReadOnly = true;
            textBoxX16.ReadOnly = true;
            textBoxX18.ReadOnly = true;
            textBoxX19.ReadOnly = true;
            textBoxX20.ReadOnly = true;
            textBoxX29.ReadOnly = true;
            textBoxX30.ReadOnly = true;
            textBoxX31.ReadOnly = true;

            checkBoxX1.Enabled = false;
            checkBoxX2.Enabled = false;
            checkBoxX3.Enabled = false;
            checkBoxX4.Enabled = false;

            cmbtva.Enabled = false;
            cmbfodec.Enabled = false;
            cmbtaxe.Enabled = false;
            cmbfama.Enabled = false;
            secteur.Enabled = false;
            rayon.Enabled = false;
            etagere.Enabled = false;
            mygrid1.Enabled = false;
            mygrid3.Enabled = false;
            casier.Enabled = false;
            label5.Text = "";
        }
        private void buttonX1_Click(object sender, EventArgs e)
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
                  buttonX1.Visible = false;
                  buttonX2.Visible = false;


                  buttonX10.Enabled = false;
                  buttonX16.Enabled = false;
                  buttonX19.Enabled = false;
                  buttonX20.Enabled = false;
                  buttonX21.Enabled = false;

                  textBoxX1.ReadOnly = true;
                  textBoxX2.ReadOnly = true;
                  textBoxX3.ReadOnly = true;
                  textBoxX2.ReadOnly = true;
                  textBoxX3.ReadOnly = true;
                  textBoxX4.ReadOnly = true;
                  textBoxX5.ReadOnly = true;
                  textBoxX6.ReadOnly = true;
                  textBoxX7.ReadOnly = true;
                  textBoxX11.ReadOnly = true;
                  textBoxX13.ReadOnly = true;
                  textBoxX14.ReadOnly = true;
                  textBoxX16.ReadOnly = true;
                  textBoxX18.ReadOnly = true;
                  textBoxX19.ReadOnly = true;
                  textBoxX20.ReadOnly = true;
                  textBoxX29.ReadOnly = true;
                  textBoxX30.ReadOnly = true;
                  textBoxX31.ReadOnly = true;

                  checkBoxX1.Enabled = false;
                  checkBoxX2.Enabled = false;
                  checkBoxX3.Enabled = false;
                  checkBoxX4.Enabled = false;

                  cmbtva.Enabled = false;
                  cmbfodec.Enabled = false;
                  cmbtaxe.Enabled = false;
                  cmbfama.Enabled = false;
                  secteur.Enabled = false;
                  rayon.Enabled = false;
                  etagere.Enabled = false;
                  casier.Enabled = false;
                  mygrid1.Enabled = false;
                  mygrid3.Enabled = false;
                  affiche();
                  superValidator1.ClearFailedValidations();
                  label5.Text = "";
                  modif = false;
                  maj = false;
                  buttonX5.Focus();
              }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            // Bouton Sauver
            if (superValidator1.Validate())
            {
               
                calcularticle();
                char[] li= "nnn jjj".ToCharArray();
                string xtva = "Null", xfodec = "Null", xpaht = "Null", xmarge = "Null", xpuht = "Null", xpvpht = "Null", xpattc = "Null", xputtc = "Null", xpvpttc = "Null", xqteseuil = "Null",xqtedep="Null",xqtestk="Null";
                string xdext = "Null", xdint = "Null", xhaut = "Null" , xqteavrc = "Null" , xqteavrf = "Null" ;
                string xemb = "NULL", xtaxe="NULL" ;
                if (cmbtva.SelectedIndex != -1)
                    xtva = "'" + cmbtva.SelectedValue + "'";
                if (cmbfodec.SelectedIndex != -1)
                    xfodec = "'" + cmbfodec.SelectedValue + "'";
                if (cmbtaxe.SelectedIndex != -1)
                    xtaxe = "'" + cmbtaxe.SelectedValue + "'";
                if (!textBoxX7.Text.Trim().Equals(""))
                    xqtedep = "'" + textBoxX7.Text + "'";
                if (!textBoxX29.Text.Trim().Equals(""))
                    xqteseuil = "'" + textBoxX29.Text + "'";
                if (!textBoxX10.Text.Trim().Equals(""))
                    xqtestk = "'" + textBoxX10.Text + "'";
                if (!textBoxX21.Text.Trim().Equals(""))
                    xqteavrc = "'" + textBoxX21.Text + "'";
                if (!textBoxX22.Text.Trim().Equals(""))
                    xqteavrf = "'" + textBoxX22.Text + "'";
                if (!textBoxX11.Text.Trim().Equals(""))
                    xpaht = "'" + textBoxX11.Text + "'";
                if (!textBoxX13.Text.Trim().Equals(""))
                    xmarge = "'" + textBoxX13.Text + "'";
                if (!textBoxX12.Text.Trim().Equals(""))
                    xpattc = "'" + textBoxX12.Text + "'";
                if (!textBoxX14.Text.Trim().Equals(""))
                    xpuht = "'" + textBoxX14.Text  + "'";
                if (!textBoxX15.Text.Trim().Equals(""))
                    xputtc = "'" + textBoxX15.Text + "'";
                if (!textBoxX16.Text.Trim().Equals(""))
                    xpvpht = "'" + textBoxX16.Text + "'";
                if (!textBoxX17.Text.Trim().Equals(""))
                    xpvpttc = "'" + textBoxX17.Text + "'";
                if (!textBoxX18.Text.Trim().Equals(""))
                    xdext = "'" + textBoxX18.Text + "'";
                if (!textBoxX19.Text.Trim().Equals(""))
                    xdint = "'" + textBoxX19.Text + "'";
                if (!textBoxX20.Text.Trim().Equals(""))
                    xhaut = "'" + textBoxX20.Text + "'";
                if (!textBoxX31.Text.Trim().Equals(""))
                    xemb = "'" + textBoxX31.Text + "'";
                else
                    xemb = "'1'";
                double d = 0;
                Double.TryParse(textBoxX31.Text, out d);
                if(d==0)
                    xemb = "'1'";

                if (!modif)
                {

                    String sql = "SELECT code FROM article  where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' and code='" + textBoxX1.Text + "'";
                    DataSet verif = met.recuperer_table(sql);

                    if (verif.Tables[0].Rows.Count == 0)
                    {
                       
                        String req = "INSERT INTO Article(codes,codee,code,codeb,libelle,codeo,marque,cara,codef,um,tva,fodec,taxe,paht,marge,puht,pvpht,pattc,puttc,pvpttc,qteseuil,dext,dint,haut,vpa,vstk,benef,majore,vente,achat,tvavente,tvaachat,qtedep,qtestk,emb,image) Values ('" + Program.Societe
                         + "','" + Program.Exercice
                         + "','" + textBoxX1.Text
                         + "','" + textBoxX30.Text
                         + "','" + textBoxX2.Text
                         + "','" + textBoxX3.Text
                         + "','" + textBoxX4.Text
                         + "','" + textBoxX6.Text
                         + "','" + cmbfama.SelectedValue
                         + "','" + textBoxX5.Text
                         + "'," + xtva.Replace(Program.sep, string.Empty)
                         + "," + xfodec.Replace(Program.sep, string.Empty)
                         + "," + xtaxe.Replace(Program.sep, string.Empty)
                         + "," + xpaht.Replace(Program.sep, string.Empty)
                         + "," + xmarge.Replace(Program.sep, string.Empty)
                         + "," + xpuht.Replace(Program.sep, string.Empty)
                         + "," + xpvpht.Replace(Program.sep, string.Empty)
                         + "," + xpattc.Replace(Program.sep, string.Empty)
                         + "," + xputtc.Replace(Program.sep, string.Empty)
                         + "," + xpvpttc.Replace(Program.sep, string.Empty)
                         + "," + xqteseuil.Replace(Program.sep, string.Empty)
                         + "," + xdext.Replace(Program.sep, string.Empty)
                         + "," + xdint.Replace(Program.sep, string.Empty)
                         + "," + xhaut.Replace(Program.sep, string.Empty)
                         + "," + radioButton5.Checked
                         + "," + radioButton2.Checked
                         + "," + radioButton4.Checked
                         + "," + radioButton8.Checked
                         + "," + checkBoxX1.Checked
                         + "," + checkBoxX2.Checked
                         + "," + checkBoxX3.Checked
                         + "," + checkBoxX4.Checked
                         + ", " + xqtedep.Replace(Program.sep, string.Empty)
                         + ", " + xqtestk.Replace(Program.sep, string.Empty)
                         + ", " + xemb.Replace(Program.sep, string.Empty)
                         + ",@image"
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
                        ////////////////////////////////Historique Prix de vente
                        string dat1 = DateTime.Now.ToString("yyyy-MM-dd");
                        String sqlhist = "insert into articlehist (codes,codee,codea,datem,prixht) value ('" + Program.Societe + "','" + Program.Exercice + "','" + textBoxX1.Text + "','" + dat1 + "'," + xpuht.Replace(Program.sep, string.Empty) + ")";
                        met.Execute(sqlhist);

                        ///////////////////////////////////////////////////////////
                        // Sauvegarde Emplacement Article
                        foreach (Cdepot u in LstDepot)
                        {
                            String req10 = "DELETE FROM emplacement where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codem = '" + Program.Magasin + "' and coded='" + u.coded + "'  and codea = '" + textBoxX1.Text + "' ";
                            met.Execute(req10);

                            String reqemp = "INSERT INTO emplacement(codes,codee,codem,coded,codea,codesec,coder,codep,codec) Values ('" + Program.Societe
                                                            + "','" + Program.Exercice
                                                            + "','" + Program.Magasin
                                                            + "','" + u.coded
                                                            + "','" + textBoxX1.Text
                                                            + "','" + u.codesec
                                                            + "','" + u.coder
                                                            + "','" + u.codep
                                                            + "','" + u.codec
                                                            + "')";
                            met.Execute(reqemp);

                        }
                        LstDepot.Clear();

                        Boolean sauve = false;
                        { // Sauvegarde gamme & article dépot Si article a des gammes
                            int xcodeg = 1;
                            foreach (DataGridViewRow dgr in mygrid1.Rows)
                            {
                                if (!dgr.IsNewRow)
                                {
                                    string xlibg = dgr.Cells["libelle"].Value + "";

                                    String req10 = "DELETE FROM gamme where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'   and codea = '" + textBoxX1.Text + "'  and codeg = '" + xcodeg + "'";
                                    met.Execute(req10);

                                    sauve = true;
                                    // sauvegarde gamme
                                    String reqgam = "INSERT INTO gamme(codes,codee,codea,codeg,libelle) Values ('" + Program.Societe
                                                                    + "','" + Program.Exercice
                                                                    + "','" + textBoxX1.Text
                                                                    + "','" + xcodeg
                                                                    + "','" + xlibg
                                                                    + "')";
                                    met.Execute(reqgam);

                                    // Sauvegarde Article dépot
                                    string reqdep = "select code,codem from depot where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
                                    DataSet dsdep = met.recuperer_table(reqdep, "depot");
                                    foreach (DataRow dr in dsdep.Tables["depot"].Rows)
                                    {
                                        string xcoded = dr["code"].ToString();
                                        string xcodem = dr["codem"].ToString();
                                        String reqartd = "INSERT INTO artdep(codes,codee,codem,coded,codea,codeg) Values ('" + Program.Societe
                                                                  + "','" + Program.Exercice
                                                                  + "','" + xcodem
                                                                  + "','" + xcoded
                                                                  + "','" + textBoxX1.Text
                                                                  + "','" + xcodeg
                                                                  + "')";
                                        met.Execute(reqartd);
                                    }

                                }
                                xcodeg++;
                            }
                        } // Fin Sauvegarde gamme & article dépot Si article a des gammes

                       


                        { // Sauvegarde gamme & article depot  Si article n'a pas de gamme
                            if (!sauve)
                            {
                                // sauvegarde gamme
                                String reqgam = "INSERT INTO gamme(codes,codee,codea,codeg,libelle) Values ('" + Program.Societe
                                                                   + "','" + Program.Exercice
                                                                   + "','" + textBoxX1.Text
                                                                   + "','" + "0000000000"
                                                                   + "','" + "Defaut"
                                                                   + "')";
                                met.Execute(reqgam);


                                // Sauvegarde Article dépot 
                                string reqdep = "select code,codem from depot where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' ";
                                DataSet dsdep = met.recuperer_table(reqdep, "depot");
                                foreach (DataRow dr in dsdep.Tables["depot"].Rows)
                                {
                                    string xcoded = dr["code"].ToString();
                                    string xcodem = dr["codem"].ToString();
                                    String reqartd = "INSERT INTO artdep(codes,codee,codem,coded,codea,codeg) Values ('" + Program.Societe
                                                              + "','" + Program.Exercice
                                                              + "','" + xcodem
                                                              + "','" + xcoded
                                                              + "','" + textBoxX1.Text
                                                              + "','" + "0000000000"
                                                              + "')";
                                    met.Execute(reqartd);
                                }

                            }
                        } // Fin Sauvegarde gamme & article depot  Si article n'a pas de gamme


                        // Sauvegarde Article magasin
                        string reqmag = "select code from magasin where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' ";
                        DataSet dsmag = met.recuperer_table(reqmag, "magasin");

                        foreach (DataRow dr in dsmag.Tables["magasin"].Rows)
                        {
                            string xcodem = dr["code"].ToString();

                            String reqartm = "INSERT INTO artmag(codes,codee,codem,codea,qteseuil) Values ('" + Program.Societe
                                                                   + "','" + Program.Exercice
                                                                   + "','" + xcodem
                                                                   + "','" + textBoxX1.Text
                                                                   + "'," + xqteseuil.Replace(Program.sep, string.Empty)
                                                                   + ")";
                            met.Execute(reqartm);
                        }

                        { // Sauvegarde sous article
                            int xcodeb = 1;
                            double wtva = 0;
                            decimal wpu = 0;
                            foreach (DataGridViewRow dgr in mygrid3.Rows)
                            {
                                if (!dgr.IsNewRow)
                                {

                                    string xlibg = dgr.Cells["libelles"].Value + "";

                                    try
                                    {
                                        wtva = (double)dgr.Cells["tva"].Value;
                                    }
                                    catch { }

                                    try
                                    {
                                        wpu = (decimal)dgr.Cells["pu"].Value;
                                    }
                                    catch { }

                                    String req10 = "DELETE FROM sarticle where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'   and codea = '" + textBoxX1.Text + "'  and code = '" + xcodeb + "'";
                                    met.Execute(req10);

                                    // sauvegarde sous article
                                    String reqgam = "INSERT INTO sarticle(codes,codee,codea,code,libelle,pu,tva) Values ('" + Program.Societe
                                                                    + "','" + Program.Exercice
                                                                    + "','" + textBoxX1.Text
                                                                    + "','" + xcodeb
                                                                    + "','" + xlibg
                                                                    + "'," + wpu
                                                                    + "," + wtva
                                                                    + ")";
                                    met.Execute(reqgam);


                                }
                                xcodeb++;
                            }
                        } // Fin Sauvegarde sous article





                        MessageBox.Show("Sauvgarde effectué");

                        String req7 = "SELECT * FROM article where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' Order by code ";
                        ds = met.recuperer_table(req7, "article");

                        string req8 = "SELECT MAX(ID) from article ";
                        DataSet ds2 = met.recuperer_table(req8, "article");


                        List<DataColumn> lis = new List<DataColumn>();
                        lis.Add(ds.Tables["article"].Columns["ID"]);
                        ds.Tables["article"].PrimaryKey = lis.ToArray();
                        DataRow[] dr1 = ds.Tables["article"].Select("ID = '" + ds2.Tables[0].Rows[0].ItemArray[0] + "'");
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
                else // Modification
                {
                                         
                        String req = "Update Article Set codes = '" + Program.Societe
                        + "', codee = '" + Program.Exercice
                        + "', code =  '" + textBoxX1.Text
                        + "', codeb = '" + textBoxX30.Text
                        + "', libelle = '" + textBoxX2.Text
                        + "', codeo = '" + textBoxX3.Text
                        + "', marque = '" + textBoxX4.Text
                        + "', cara = '" + textBoxX6.Text
                        + "', codef='" + cmbfama.SelectedValue
                        + "',um='" + textBoxX5.Text
                        + "',tva=" + xtva.Replace(Program.sep, string.Empty)
                        + ",fodec=" + xfodec.Replace(Program.sep, string.Empty)
                        + ",taxe=" + xtaxe.Replace(Program.sep, string.Empty)
                        + ",paht=" + xpaht.Replace(Program.sep, string.Empty)
                        + ",marge=" + xmarge.Replace(Program.sep, string.Empty)
                        + ",puht=" + xpuht.Replace(Program.sep, string.Empty)
                        + ",pvpht=" + xpvpht.Replace(Program.sep, string.Empty)
                        + ",pattc=" + xpattc.Replace(Program.sep, string.Empty)
                        + ",puttc=" + xputtc.Replace(Program.sep, string.Empty)
                        + ",pvpttc=" + xpvpttc.Replace(Program.sep, string.Empty)
                        + ",dext=" + xdext.Replace(Program.sep, string.Empty)
                        + ",dint=" + xdint.Replace(Program.sep, string.Empty)
                        + ",haut=" + xhaut.Replace(Program.sep, string.Empty)
                        + ",vpa=" + radioButton5.Checked
                        + ",vstk=" + radioButton2.Checked
                        + ",benef=" + radioButton4.Checked
                        + ",majore=" + radioButton8.Checked
                        + ",vente=" + checkBoxX1.Checked
                        + ",achat=" + checkBoxX2.Checked
                        + ",tvavente=" + checkBoxX3.Checked
                        + ",tvaachat=" + checkBoxX4.Checked
                        + ",qtedep=" + xqtedep.Replace(Program.sep, string.Empty)
                        + ",qtestk=" + xqtestk.Replace(Program.sep, string.Empty)
                        + ",emb=" + xemb.Replace(Program.sep, string.Empty)
                        + ",image=@image"
                        + " Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];

                        // met.Execute(req);
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
                        ////////////////////////////////Historique Prix de vente
                        
                        decimal npuht = 0;
                        try 
                        {
                            decimal.TryParse(textBoxX14.Text, out npuht);
                            
                            
                        }
                        catch { }
                        if (npuht != ancpuht)
                        {
                            string dat1 = DateTime.Now.ToString("yyyy-MM-dd");
                            String sqlhist = "insert into articlehist (codes,codee,codea,datem,prixht) value ('" + Program.Societe + "','" + Program.Exercice + "','" + textBoxX1.Text + "','" + dat1 + "'," + xpuht.Replace(Program.sep, string.Empty) + ")";
                            met.Execute(sqlhist);
                        }

                        ///////////////////////////////////////////////////////////
                        // Sauvegarde Emplacement Article
                        foreach (Cdepot u in LstDepot)
                        {

                            String req10 = "DELETE FROM emplacement where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codem = '" + Program.Magasin + "' and coded='" + u.coded + "'  and codea = '" + textBoxX1.Text + "' ";
                            met.Execute(req10);

                            String reqemp = "INSERT INTO emplacement(codes,codee,codem,coded,codea,codesec,coder,codep,codec) Values ('" + Program.Societe
                                                            + "','" + Program.Exercice
                                                            + "','" + Program.Magasin
                                                            + "','" + u.coded
                                                            + "','" + textBoxX1.Text
                                                            + "','" + u.codesec
                                                            + "','" + u.coder
                                                            + "','" + u.codep
                                                            + "','" + u.codec
                                                            + "')";
                            met.Execute(reqemp);

                        }
                        LstDepot.Clear();


                        { // Sauvegarde Gamme

                          
                            foreach (DataGridViewRow dgr in mygrid1.Rows)
                            {

                                if (!dgr.IsNewRow)
                                {

                                    string xlibg = dgr.Cells["libelle"].Value + "";
                                    string xcodeg = dgr.Cells["codeg"].Value + "";

                                    
                                    String sql = "SELECT codeg FROM gamme  where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' and codea='" + textBoxX1.Text + "' and codeg = '"+xcodeg+"'";
                                    DataSet verif = met.recuperer_table(sql);

                                    if (verif.Tables[0].Rows.Count != 0)
                                    {

                                        // sauvegarde gamme
                                        String reqgam = "Update gamme Set  codes   = '" + Program.Societe
                                                                        + "', codee   = '" + Program.Exercice
                                                                        + "', codea   = '" + textBoxX1.Text
                                                                        + "', codeg    = '" + xcodeg
                                                                        + "', libelle = '" + xlibg
                                                                        + "' Where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' and codea='" + textBoxX1.Text + "' and codeg = " + xcodeg;
                                        met.Execute(reqgam);


                                    }
                                    else
                                    {
                                        long c = 0;
                                        string reqc = "SELECT MAX(codeg) FROM gamme  where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' and codea='" + textBoxX1.Text + "' ";
                                        DataSet dsc = met.recuperer_table(reqc);
                                        if(dsc!=null)
                                            if(dsc.Tables.Count!=0)
                                                if (ds.Tables[0].Rows.Count != 0)
                                                {
                                                    long.TryParse(dsc.Tables[0].Rows[0][0] + "", out c);
                                                }
                                        c++;
                                        String reqgam = "INSERT INTO gamme(codes,codee,codea,codeg,libelle) Values ('" + Program.Societe
                                                                  + "','" + Program.Exercice
                                                                  + "','" + textBoxX1.Text
                                                                  + "','" + c
                                                                  + "','" + xlibg
                                                                  + "')";
                                        met.Execute(reqgam);

                                        // Sauvegarde Article dépot
                                        string reqdep = "select code,codem from depot where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
                                        DataSet dsdep = met.recuperer_table(reqdep, "depot");
                                        foreach (DataRow dr in dsdep.Tables["depot"].Rows)
                                        {
                                            string xcoded = dr["code"].ToString();
                                            string xcodem = dr["codem"].ToString();
                                            String reqartd = "INSERT INTO artdep(codes,codee,codem,coded,codea,codeg) Values ('" + Program.Societe
                                                                      + "','" + Program.Exercice
                                                                      + "','" + xcodem
                                                                      + "','" + xcoded
                                                                      + "','" + textBoxX1.Text
                                                                      + "','" + c
                                                                      + "')";
                                            met.Execute(reqartd);
                                        }

                                    }
                                }
                              
                            }
                            foreach (object o in SuppGamme)
                            {
                                string reqs = "DELETE FROM gamme WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' and codea='" + textBoxX1.Text + "' and codeg ='" + o + "'";
                                met.Execute(reqs);
                                string reqd = "DELETE FROM artdep WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' and codea='" + textBoxX1.Text + "' and codeg ='" + o + "'";
                                met.Execute(reqd);

                            }



                        } // Fin Sauvegarde gamme


                    /////////////////////////////////////////////////////
                        { // Sauvegarde sous article


                            foreach (DataGridViewRow dgr in mygrid3.Rows)
                            {

                                double wtva = 0;
                                decimal wpu = 0;
                                if (!dgr.IsNewRow)
                                {

                                    string xlibg = dgr.Cells["libelles"].Value + "";
                                    string xcodeb = dgr.Cells["code"].Value + "";

                                    try
                                    {
                                        wtva = (double)dgr.Cells["tva"].Value;
                                    }
                                    catch { }

                                    try
                                    {
                                        wpu = (decimal)dgr.Cells["pu"].Value;
                                    }
                                    catch { }

                                    String sql = "SELECT code FROM sarticle  where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' and codea='" + textBoxX1.Text + "' and code = '" + xcodeb + "'";
                                    DataSet verif = met.recuperer_table(sql);

                                    if (verif.Tables[0].Rows.Count != 0)
                                    {

                                        // sauvegarde sous article
                                        String reqgam = "Update sarticle Set  codes   = '" + Program.Societe
                                                                        + "', codee   = '" + Program.Exercice
                                                                        + "', codea   = '" + textBoxX1.Text
                                                                        + "', code    = '" + xcodeb
                                                                        + "', libelle = '" + xlibg
                                                                        + "', pu      = " + wpu
                                                                        + ",  tva     = " + wtva
                                                                        + " Where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' and codea='" + textBoxX1.Text + "' and code = " + xcodeb;
                                        met.Execute(reqgam);


                                    }
                                    else
                                    {
                                        long c = 0;
                                        string reqc = "SELECT MAX(code) FROM sarticle  where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' and codea='" + textBoxX1.Text + "' ";
                                        DataSet dsc = met.recuperer_table(reqc);
                                        if (dsc != null)
                                            if (dsc.Tables.Count != 0)
                                                if (ds.Tables[0].Rows.Count != 0)
                                                {
                                                    long.TryParse(dsc.Tables[0].Rows[0][0] + "", out c);
                                                }
                                        c++;
                                        //xcodeb = (int)c;
                                        String reqgam = "INSERT INTO sarticle(codes,codee,codea,code,libelle,pu,tva) Values ('" + Program.Societe
                                                                  + "','" + Program.Exercice
                                                                  + "','" + textBoxX1.Text
                                                                  + "','" + c
                                                                  + "','" + xlibg
                                                                  + "'," + wpu
                                                                  + "," + wtva
                                                                  + ")";
                                        met.Execute(reqgam);
                                    }
                                }

                            }
                            foreach (object o in SuppSart)
                            {
                                string reqs = "DELETE FROM sarticle WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' and codea='" + textBoxX1.Text + "' and code ='" + o + "'";
                                met.Execute(reqs);
                            }



                        } // Fin Sauvegarde sous article

                    /////////////////////////////////////////////////////


                       


                        MessageBox.Show("Sauvegarde effectué");

                        modif = false;
                        string req6 = "SELECT * FROM article WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
                        ds = met.recuperer_table(req6, "article");
                        affiche();
                        afficheb();
                        this.buttonX6.Focus();
                   
                }
            }
                
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            index = 0;
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

        private void buttonX8_Click(object sender, EventArgs e)
        {
            index = ds.Tables[0].Rows.Count - 1;
            affiche();

        }

        private void Article_KeyDown(object sender, KeyEventArgs e)
        {

            //////////////
            switch (e.KeyCode)
            {

               
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
                            buttonX1_Click(sender, e);
                    }
                    break;
                case Keys.F11:
                    {
                            buttonX9_Click(sender, e);
                    }
                    break;

                case Keys.F2:
                    {
                        buttonItem5_Click(sender, e);
                    }
                    break;
                case Keys.Escape:
                      String msg = MessageBox.Show("Ete-vous sur","Sortir", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                      if (msg.Equals("Yes"))
                      {
                          this.Close();
                      }
                      break;
                
                default:
                    // actions_sinon;
                    break;
            }

        }

        private void textBoxX11_TextChanged(object sender, EventArgs e)
        {
            Double tva = 0, ht = 0, ttc = 0;
            Double.TryParse(cmbtva.SelectedValue + "", out tva);
            Double.TryParse(textBoxX11.Text, out ht);
            ttc = ht + ht * tva / 100;
            textBoxX12.Text = ttc.ToString("N3");

           if (modif)
            {

                Double marg = 0, xht = 0, pvht = 0,  pvttc = 0;
                Double.TryParse(textBoxX13.Text, out marg);
                Double.TryParse(textBoxX11.Text, out xht);
                act = true;
                pvht = xht + xht * marg / 100;
                pvttc = pvht + pvht * tva / 100;
                textBoxX14.Text = pvht.ToString("N3");
                textBoxX15.Text = pvttc.ToString("N3");
                act = false;
            }
            
        }
      
        private void textBoxX13_TextChanged(object sender, EventArgs e)
        {
            if (!act)
            {
                Double marg = 0, ht = 0, pvht = 0, tva = 0, pvttc=0;
                Double.TryParse(textBoxX13.Text, out marg);
                Double.TryParse(cmbtva.SelectedValue + "", out tva);
                Double.TryParse(textBoxX11.Text, out ht);
                pvht = ht + ht * marg / 100;
                pvttc = pvht + pvht * tva / 100;
                act = true;

                textBoxX14.Text = pvht.ToString("N3");
                textBoxX15.Text = pvttc.ToString("N3");
                act = false;

            }
        }

        private void textBoxX14_TextChanged(object sender, EventArgs e)
        {
            if (!act)
            {
                act = true;
                textBoxX13.Text = "";
                Double tva = 0, ht = 0, ttc = 0;
                Double.TryParse(cmbtva.SelectedValue + "", out tva);
                Double.TryParse(textBoxX14.Text, out ht);
                ttc = ht + ht * tva / 100;
                textBoxX15.Text = ttc.ToString("N3");
                act = false;
            }

        }

        private void textBoxX16_TextChanged(object sender, EventArgs e)
        {
            
            Double tva = 0, ht = 0, ttc = 0;
            Double.TryParse(cmbtva.SelectedValue + "", out tva);
            Double.TryParse(textBoxX16.Text, out ht);
            ttc = ht + ht * tva / 100;
            textBoxX17.Text = ttc.ToString("N3");
           
        }

        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBoxX30.Focus();
        }

        private void textBoxX30_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBoxX3.Focus();
        }

        private void textBoxX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                cmbfama.Focus();
        }

        private void textBoxX3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBoxX4.Focus();
        }

        private void textBoxX4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBoxX2.Focus();
        }

        private void textBoxX5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                cmbtva.Focus();
        }

        private void cmblstk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                cmbtva.Focus();
        }

        private void cmbtva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                cmbfodec.Focus();
        }

        private void cmbfodec_KeyPress(object sender, KeyPressEventArgs e)
        {
                           
        }

        private void textBoxX6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBoxX7.Focus();
        }

        private void textBoxX11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBoxX13.Focus();
        }

        private void textBoxX13_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar.Equals('\r'))
                textBoxX14.Focus();
        }

        private void textBoxX14_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar.Equals('\r'))
                textBoxX16.Focus();
        }

        private void textBoxX16_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar.Equals('\r'))
                textBoxX1.Focus();
        }
  
        private void textBoxX18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBoxX19.Focus();
        }

        private void textBoxX19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBoxX20.Focus();
        }
     
        private void textBoxX20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBoxX3.Focus();
        }
        
        private void textBoxX7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBoxX1.Focus();
        }

        private void cmbtva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modif) 
               calcularticle();
        }

        private void textBoxX16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBoxX14.Focus(); 
        }

        private void textBoxX14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBoxX13.Focus(); 
        }

        private void textBoxX13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBoxX11.Focus(); 
        }

        private void textBoxX11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBoxX5.Focus(); 
        }

        private void textBoxX6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBoxX5.Focus();
        }

        private void textBoxX5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBoxX2.Focus(); 
        }

        private void textBoxX4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBoxX3.Focus(); 
        }

        private void textBoxX3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBoxX20.Focus(); 
        }
     
        private void textBoxX30_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBoxX1.Focus();
        }

        private void textBoxX2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBoxX30.Focus(); 
        }

        private void textBoxX7_KeyDown(object sender, KeyEventArgs e)
        {
        }
       
        private void textBoxX19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBoxX18.Focus(); 
        }
      
        private void textBoxX20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBoxX19.Focus(); 

        }
   
        private void textBoxX18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBoxX5.Focus(); 

        }
      
        private void buttonX10_Click(object sender, EventArgs e)
        {
            param frm = new param();
            frm.table = "famillearticle";
            frm.champs = "famillearticle";
            frm.Text = "Famille Article";
            frm.ShowDialog();
           

            string req4 = "Select * from FamilleArticle  where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "'";
            DataSet ds4 = met.recuperer_table(req4, "FamilleArticle");
            BindingSource bs4 = new BindingSource(ds4, "FamilleArticle");
            cmbfama.DataSource = bs4;
        }

        private void textBoxX7_TextChanged(object sender, EventArgs e)
        {
            if (!act)
            {
                Double dep = 0, ent = 0, sor = 0, stk = 0, avrc = 0, avrf = 0;

                Double.TryParse(textBoxX7.Text, out dep);
                Double.TryParse(textBoxX8.Text, out ent);
                Double.TryParse(textBoxX9.Text, out sor);
                Double.TryParse(textBoxX21.Text, out avrc);
                Double.TryParse(textBoxX22.Text, out avrf);

                stk = dep + ent + avrc - sor - avrf;
                textBoxX7.Text = dep.ToString("N3");
                textBoxX8.Text = ent.ToString("N3");
                textBoxX9.Text = sor.ToString("N3");
                textBoxX10.Text = stk.ToString("N3");
                textBoxX21.Text = avrc.ToString("N3");
                textBoxX22.Text = avrf.ToString("N3");
            }
        }

        private void buttonX21_Click(object sender, EventArgs e)
        {

            secteura form = new secteura();
            form.ShowDialog();
            int inds = secteur.SelectedIndex;
            int indr = rayon.SelectedIndex;
            int inde = etagere.SelectedIndex;
            int indc = casier.SelectedIndex;
            string req1 = "Select * from secteura  where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' AND codem='" + Program.Magasin + "'";
            DataSet ds1 = met.recuperer_table(req1, "secteura");
            BindingSource bs = new BindingSource(ds1, "secteura");
            secteur.DataSource = bs;
            if (inds < secteur.Items.Count)
            {
                secteur.SelectedIndex = inds;
                rayon.SelectedIndex = indr;
                etagere.SelectedIndex = inde;
                casier.SelectedIndex = indc;
            }
        }

        private void buttonX16_Click(object sender, EventArgs e)
        {

            rayon form = new rayon();
            form.ShowDialog();
            int inds = secteur.SelectedIndex;
            int indr = rayon.SelectedIndex;
            int inde = etagere.SelectedIndex;
            int indc = casier.SelectedIndex;
            string req1 = "Select * from rayon  where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' AND codem='" + Program.Magasin + "'";
            DataSet ds1 = met.recuperer_table(req1, "rayon");
            BindingSource bs = new BindingSource(ds1, "rayon");
            rayon.DataSource = bs;
            if (inds < secteur.Items.Count)
            {
                secteur.SelectedIndex = inds;
                rayon.SelectedIndex = indr;
                etagere.SelectedIndex = inde;
                casier.SelectedIndex = indc;
            }
        }



        private void secteur_SelectedIndexChanged(object sender, EventArgs e)
        {

            String req7 = "SELECT * FROM rayon where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and codesec = '" + secteur.SelectedValue + "' ";
            DataSet ds7 = met.recuperer_table(req7, "rayon");
            BindingSource bs7 = new BindingSource(ds7, "rayon");
            rayon.ValueMember = "Code";
            rayon.DisplayMember = "Libelle";
            rayon.DataSource = bs7;
            rayon.SelectedIndex = -1;
            etagere.SelectedIndex = -1;
            casier.SelectedIndex = -1;
            
        }

        private void rayon_SelectedIndexChanged(object sender, EventArgs e)
        {

            String req7 = "SELECT * FROM etagere where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and codesec = '" + secteur.SelectedValue + "' and coder = '" + rayon.SelectedValue + "'";
            DataSet ds7 = met.recuperer_table(req7, "etagere");
            BindingSource bs7 = new BindingSource(ds7, "etagere");
            etagere.ValueMember = "Code";
            etagere.DisplayMember = "Libelle";
            etagere.DataSource = bs7;
            etagere.SelectedIndex = -1;
            casier.SelectedIndex = -1;
            casier.DataSource = null;
        }

        private void etagere_SelectedIndexChanged(object sender, EventArgs e)
        {
            String req8 = "SELECT * FROM casier where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and codesec = '" + secteur.SelectedValue + "' and coder = '" + rayon.SelectedValue + "' and codep = '" + etagere.SelectedValue + "'";
            DataSet ds8 = met.recuperer_table(req8, "casier");
            BindingSource bs8 = new BindingSource(ds8, "casier");
            casier.ValueMember = "Code";
            casier.DisplayMember = "Libelle";
            casier.DataSource = bs8;
            casier.SelectedIndex = -1;
        }

        private void depot_SelectedIndexChanged(object sender, EventArgs e)
        {
            secteur.SelectedIndex = -1;
            rayon.SelectedIndex = -1;
            etagere.SelectedIndex = -1;
            casier.SelectedIndex = -1;
            if (depot.SelectedIndex != -1)
            {
                string req1 = "SELECT * FROM emplacement WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' AND codem='" + Program.Magasin + "' and codea = '" + textBoxX1.Text + "' AND Coded = '"+depot.SelectedValue +"'";
                DataSet ds1 = met.recuperer_table(req1, "emplacement");
                if (ds1 != null)
                {
                    if (ds1.Tables.Count != 0)
                    {
                        if (ds1.Tables[0].Rows.Count != 0)
                        {
                            secteur.SelectedValue = ds1.Tables[0].Rows[0].Field<Object>("codesec") + "";
                            rayon.SelectedValue = ds1.Tables[0].Rows[0].Field<Object>("coder") + "";
                            etagere.SelectedValue = ds1.Tables[0].Rows[0].Field<Object>("codep") + "";
                            casier.SelectedValue = ds1.Tables[0].Rows[0].Field<Object>("codec") + "";
                        }
                    }
                }
            }
        }

        private class Cdepot
        {
            public string coded;
            public string codesec;
            public string coder;
            public string codep;
            public string codec;
         }

        private void casier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (casier.SelectedIndex != -1 && depot.SelectedIndex != -1 && etagere.SelectedIndex != -1 && rayon.SelectedIndex != -1 && secteur.SelectedIndex != -1)
            {
                if (depot.SelectedIndex < LstDepot.Count)
                {
                    LstDepot[depot.SelectedIndex].codesec = "" + secteur.SelectedValue;
                    LstDepot[depot.SelectedIndex].coder = "" + rayon.SelectedValue;
                    LstDepot[depot.SelectedIndex].codep = "" + etagere.SelectedValue;
                    LstDepot[depot.SelectedIndex].codec = "" + casier.SelectedValue;
                }
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Article_FormClosed(object sender, FormClosedEventArgs e)
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

           

        private void mygrid3_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (modif)
            {
                string req1 = "select codea,codesa from lentl where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'  and codea = '" + textBoxX1.Text + "' and codesa = '" + mygrid3.SelectedRows[0].Cells["code"].Value + "' ";
                DataSet ds1 = met.recuperer_table(req1, "lentl");

                string req2 = "select codea,codesa from lentc where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'  and codea = '" + textBoxX1.Text + "' and codesa = '" + mygrid3.SelectedRows[0].Cells["code"].Value + "' ";
                DataSet ds2 = met.recuperer_table(req2, "lentc");

                string req3 = "select codea,codesa from lente where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'  and codea = '" + textBoxX1.Text + "' and codesa = '" + mygrid3.SelectedRows[0].Cells["code"].Value + "' ";
                DataSet ds3 = met.recuperer_table(req3, "lente");

                string req4 = "select codea,codesa from lentf where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'  and codea = '" + textBoxX1.Text + "' and codesa = '" + mygrid3.SelectedRows[0].Cells["code"].Value + "' ";
                DataSet ds4 = met.recuperer_table(req4, "lentf");

                if (ds1 != null && ds2 != null && ds3 != null && ds4 != null)
                {
                    if (ds1.Tables[0].Rows.Count == 0 && ds2.Tables[0].Rows.Count == 0 && ds3.Tables[0].Rows.Count == 0 && ds4.Tables[0].Rows.Count == 0 )
                    {
                        try
                        {

                            SuppSart.Add(e.Row.Cells["code"].Value);
                        }
                        catch { }
                    }
                    else
                    {
                        MessageBox.Show("Sous Article Utilisé ! Suppression Impossible");
                        e.Cancel = true;
                    }
                }
               
            }
        }

        private void mygrid1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (modif)
            {
                double x1 = 0, x2 = 0, x3 = 0, x4 = 0, x5 = 0, x6 = 0;
                double w1 = 0, w2 = 0, w3 = 0, w4 = 0, w5 = 0, w6 = 0;
                string req1 = "select codem,coded,codea,codeg,qtedep,qteent,qtesor,qteavrc,qteavrf,qtestk from artdep where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'  and codea = '" + textBoxX1.Text + "' and codeg = '" + mygrid1.SelectedRows[0].Cells["codeg"].Value + "' ";
                DataSet ds1 = met.recuperer_table(req1,"artdep");
                if (ds1 != null)
                {
                    foreach (DataRow dr1 in ds1.Tables["artdep"].Rows)
                    {
                        double.TryParse(dr1["qtedep"] + "", out x1);
                        double.TryParse(dr1["qtesor"] + "", out x2);
                        double.TryParse(dr1["qteent"] + "", out x3);
                        double.TryParse(dr1["qteavrc"] + "", out x4);
                        double.TryParse(dr1["qteavrf"] + "", out x5);
                        double.TryParse(dr1["qtestk"] + "", out x6);
                        w1 += x1; w2 += x2; w3 += x3; w4 += x4; w5 += x5; w6 += x6;
                    }

                    if (w1 == 0 && w2 == 0 && w3 == 0 && w4 == 0 && w5 == 0 && w6 == 0)
                    {
                        try
                        {

                            SuppGamme.Add(e.Row.Cells["codeg"].Value);
                        }
                        catch { }
                    }
                    else
                    {
                        MessageBox.Show("Gamme Utilisée ! Suppression Impossible");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            impart form = new impart();
            form.ShowDialog();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void buttonX9_Click_1(object sender, EventArgs e)
        {
            fichier.harticle frm = new fichier.harticle(textBoxX1.Text);
            frm.ShowDialog();
        }

       

     

       

      
       
        
            
      
    }
}
