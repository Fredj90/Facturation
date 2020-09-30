using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Rendering;

namespace EPME.Facture
{
    public partial class Factcli1 : DevComponents.DotNetBar.Office2007Form
    {
      
        private metier met = Program.met;
        DataSet ds;
        Boolean first = true, xvstk = false;
        decimal xdeb,xven;
        public Factcli1()
        {
            InitializeComponent();
        }


        private void Factcli1_Load(object sender, EventArgs e)
        {
            Program.desTfunction(this);

            
        }

       
        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            charger_lignefacture();
        }

       
        private void dataGridViewX1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            charger_lignefacture();
        }

        private void charger_lignefacture()
        {
            if (dataGridViewX1.CurrentCell != null)
            {
                grid_fondation.Visible = false;
                Grid_montage.Visible = false;
                grid_deroulage.Visible = false;
                grid_divers.Visible = false;
                grid_FD.Visible = false;
                grid_MD.Visible = false;
                grid_DD.Visible = false;
                grid_AV.Visible = false;
                grid_GR.Visible = false;
                grid_TD.Visible = false;
                grid_TD.Rows.Clear();
                grid_GR.Rows.Clear();
                grid_AV.Rows.Clear();
                grid_DD.Rows.Clear();
                grid_MD.Rows.Clear();
                grid_FD.Rows.Clear();
                grid_divers.Rows.Clear();
                grid_fondation.Rows.Clear();
                Grid_montage.Rows.Clear();
                grid_deroulage.Rows.Clear();
                string xtype = dataGridViewX1.Rows[dataGridViewX1.CurrentCell.RowIndex].Cells["mode"].Value + "";
                string NumFact = dataGridViewX1.Rows[dataGridViewX1.CurrentCell.RowIndex].Cells["NuM"].Value + "";
                if (xtype == "F")
                {
                    string sqld = "select * from lfondation where codes = '" + Program.Societe + "' and codee='" + Program.Exercice + "' and numf = '" + NumFact + "'";
                    DataSet dsd = met.recuperer_table(sqld);
                    try
                    {
                        int i = 0;
                        foreach (DataRow dr in dsd.Tables[0].Rows)
                        {
                            grid_fondation.Rows.Add();
                            grid_fondation.Rows[i].Cells["NpylonF"].Value = dr["NPYLONE"];
                            grid_fondation.Rows[i].Cells["TypePyloneF"].Value = dr["TYPEPYLONE"];
                            grid_fondation.Rows[i].Cells["TypeMassifF"].Value = dr["Tmassif"];
                            grid_fondation.Rows[i].Cells["VBPF"].Value = dr["VBETPROPRETE"];
                            grid_fondation.Rows[i].Cells["VB350F"].Value = dr["VB350"];
                            grid_fondation.Rows[i].Cells["VTOTALF"].Value = dr["VTOTAL"];
                            grid_fondation.Rows[i].Cells["UF"].Value = dr["U"];
                            grid_fondation.Rows[i].Cells["PUHTFF"].Value = dr["PUHT"];
                            grid_fondation.Rows[i].Cells["PTHTF"].Value = dr["PTHT"];
                            grid_fondation.Rows[i].Cells["TVAFFF"].Value = dr["TVA"];
                            grid_fondation.Rows[i].Cells["IDF"].Value = dr["ID"];
                            i++;
                        }
                    }
                    catch { }
                    grid_fondation.Visible = true;
                    grid_fondation.Dock = DockStyle.Fill;
                }
                else if (xtype == "M")
                {
                    string sqld = "select * from lmontage where codes = '" + Program.Societe + "' and numf = '" + NumFact + "' and codee='" + Program.Exercice + "'";
                    DataSet dsd = met.recuperer_table(sqld);
                    try
                    {
                        int i = 0;
                        foreach (DataRow dr in dsd.Tables[0].Rows)
                        {
                            Grid_montage.Rows.Add();
                            Grid_montage.Rows[i].Cells["NpylonM"].Value = dr["NPYLONE"];
                            Grid_montage.Rows[i].Cells["TypePyloneM"].Value = dr["TYPEPYLONE"];

                            Grid_montage.Rows[i].Cells["VBPM"].Value = dr["POIDS"];
                            Grid_montage.Rows[i].Cells["UM"].Value = dr["U"];
                            Grid_montage.Rows[i].Cells["PUHTFM"].Value = dr["PUHT"];
                            Grid_montage.Rows[i].Cells["PTHTM"].Value = dr["PTHT"];
                            Grid_montage.Rows[i].Cells["TVAFFM"].Value = dr["TVA"];
                            Grid_montage.Rows[i].Cells["IDM"].Value = dr["ID"];
                            i++;
                        }
                    }
                    catch { }
                    Grid_montage.Visible = true;
                    Grid_montage.Dock = DockStyle.Fill;
                }
                else if (xtype == "D")
                {
                    string sqld = "select * from lderoulage where codes = '" + Program.Societe + "' and numf = '" + NumFact + "' and codee='" + Program.Exercice + "'";
                    DataSet dsd = met.recuperer_table(sqld);
                    try
                    {
                        int i = 0;
                        foreach (DataRow dr in dsd.Tables[0].Rows)
                        {
                            grid_deroulage.Rows.Add();
                            grid_deroulage.Rows[i].Cells["Npylon"].Value = dr["DESIGNATION"];
                            grid_deroulage.Rows[i].Cells["TypePylone"].Value = dr["SECTION"];

                            grid_deroulage.Rows[i].Cells["VBP"].Value = dr["QTE"];
                            grid_deroulage.Rows[i].Cells["U"].Value = dr["U"];
                            grid_deroulage.Rows[i].Cells["PUHTF"].Value = dr["PUHT"];
                            grid_deroulage.Rows[i].Cells["PTHT"].Value = dr["PTHT"];
                            grid_deroulage.Rows[i].Cells["TVAFF"].Value = dr["TVA"];
                            grid_deroulage.Rows[i].Cells["ID"].Value = dr["ID"];
                            i++;
                        }
                    }
                    catch { }
                    grid_deroulage.Visible = true;
                    grid_deroulage.Dock = DockStyle.Fill;
                }
                else if (xtype == "T")
                {
                    string sqld = "select * from ltravaux where codes = '" + Program.Societe + "' and numf = '" + NumFact + "' and codee='" + Program.Exercice + "'";
                    DataSet dsd = met.recuperer_table(sqld);
                    try
                    {
                        int i = 0;
                        foreach (DataRow dr in dsd.Tables[0].Rows)
                        {
                            grid_divers.Rows.Add();
                            grid_divers.Rows[i].Cells["NpylonT"].Value = dr["DESIGNATION"];

                            grid_divers.Rows[i].Cells["VBPT"].Value = dr["QTE"];
                            grid_divers.Rows[i].Cells["UT"].Value = dr["U"];
                            grid_divers.Rows[i].Cells["PUHTFT"].Value = dr["PUHT"];
                            grid_divers.Rows[i].Cells["PTHTT"].Value = dr["PTHT"];
                            grid_divers.Rows[i].Cells["TVAFFT"].Value = dr["TVA"];
                            grid_divers.Rows[i].Cells["IDT"].Value = dr["ID"];
                            i++;
                        }
                    }
                    catch { }
                    grid_divers.Visible = true;
                    grid_divers.Dock = DockStyle.Fill;
                }
                else if (xtype == "FD")
                {
                    string sqld = "select * from lfondation where codes = '" + Program.Societe + "' and codee='" + Program.Exercice + "' and numf = '" + NumFact + "'";
                    DataSet dsd = met.recuperer_table(sqld);
                    try
                    {
                        int i = 0;
                        foreach (DataRow dr in dsd.Tables[0].Rows)
                        {
                            grid_FD.Rows.Add();
                            grid_FD.Rows[i].Cells["NpylonFD"].Value = dr["NPYLONE"];
                            grid_FD.Rows[i].Cells["TypePyloneFD"].Value = dr["TYPEPYLONE"];
                            grid_FD.Rows[i].Cells["VBPFD"].Value = dr["QTE"];
                            grid_FD.Rows[i].Cells["UFD"].Value = dr["U"];
                            grid_FD.Rows[i].Cells["PUHTFFD"].Value = dr["PUHT"];
                            grid_FD.Rows[i].Cells["PTHTFD"].Value = dr["PTHT"];
                            grid_FD.Rows[i].Cells["TVAFFFD"].Value = dr["TVA"];
                            grid_FD.Rows[i].Cells["IDFD"].Value = dr["ID"];
                            i++;
                        }
                    }
                    catch { }
                    grid_FD.Visible = true;
                    grid_FD.Dock = DockStyle.Fill;
                }
                else if (xtype == "MD")
                {
                    string sqld = "select * from lmontage where codes = '" + Program.Societe + "' and numf = '" + NumFact + "' and codee='" + Program.Exercice + "'";
                    DataSet dsd = met.recuperer_table(sqld);
                    try
                    {
                        int i = 0;
                        foreach (DataRow dr in dsd.Tables[0].Rows)
                        {
                            grid_MD.Rows.Add();
                            grid_MD.Rows[i].Cells["NpylonMD"].Value = dr["NPYLONE"];
                            grid_MD.Rows[i].Cells["TypePyloneMD"].Value = dr["TYPEPYLONE"];

                            grid_MD.Rows[i].Cells["VBPMD"].Value = dr["POIDS"];
                            grid_MD.Rows[i].Cells["UMD"].Value = dr["U"];
                            grid_MD.Rows[i].Cells["PUHTFMD"].Value = dr["PUHT"];
                            grid_MD.Rows[i].Cells["PTHTMD"].Value = dr["PTHT"];
                            grid_MD.Rows[i].Cells["TVAFFMD"].Value = dr["TVA"];
                            grid_MD.Rows[i].Cells["IDMD"].Value = dr["ID"];
                            i++;
                        }
                    }
                    catch { }
                    grid_MD.Visible = true;
                    grid_MD.Dock = DockStyle.Fill;
                }
                else if (xtype == "DD")
                {
                    string sqld = "select * from lderoulage where codes = '" + Program.Societe + "' and numf = '" + NumFact + "' and codee='" + Program.Exercice + "'";
                    DataSet dsd = met.recuperer_table(sqld);
                    try
                    {
                        int i = 0;
                        foreach (DataRow dr in dsd.Tables[0].Rows)
                        {
                            grid_DD.Rows.Add();
                            grid_DD.Rows[i].Cells["NpylonDD"].Value = dr["NPYLONE"];
                            grid_DD.Rows[i].Cells["TypePyloneDD"].Value = dr["TYPEPYLONE"];

                            grid_DD.Rows[i].Cells["VBPDD"].Value = dr["QTE"];
                            grid_DD.Rows[i].Cells["UDD"].Value = dr["U"];
                            grid_DD.Rows[i].Cells["PUHTFDD"].Value = dr["PUHT"];
                            grid_DD.Rows[i].Cells["PTHTDD"].Value = dr["PTHT"];
                            grid_DD.Rows[i].Cells["TVAFFDD"].Value = dr["TVA"];
                            grid_DD.Rows[i].Cells["IDDD"].Value = dr["ID"];
                            i++;
                        }
                    }
                    catch { }
                    grid_DD.Visible = true;
                    grid_DD.Dock = DockStyle.Fill;
                }
                else if (xtype == "AV")
                {
                    string sqld = "select * from ltravaux where codes = '" + Program.Societe + "' and numf = '" + NumFact + "' and codee='" + Program.Exercice + "'";
                    DataSet dsd = met.recuperer_table(sqld);
                    try
                    {
                        int i = 0;
                        foreach (DataRow dr in dsd.Tables[0].Rows)
                        {
                            grid_AV.Rows.Add();
                            grid_AV.Rows[i].Cells["desav"].Value = dr["designation"];
                            grid_AV.Rows[i].Cells["Tauxav"].Value = dr["PUHT"];

                            grid_AV.Rows[i].Cells["mnttravaux"].Value = dr["taux"];
                            grid_AV.Rows[i].Cells["PTHTAV"].Value = dr["PTHT"];
                            grid_AV.Rows[i].Cells["TVAAV"].Value = dr["TVA"];
                            grid_AV.Rows[i].Cells["IDAV"].Value = dr["ID"];
                            i++;
                        }
                    }
                    catch { }
                    grid_AV.Visible = true;
                    grid_AV.Dock = DockStyle.Fill;
                }
                else if (xtype == "GR")
                {
                    string sqld = "select * from ltravaux where codes = '" + Program.Societe + "' and numf = '" + NumFact + "' and codee='" + Program.Exercice + "'";
                    DataSet dsd = met.recuperer_table(sqld);
                    try
                    {
                        int i = 0;
                        foreach (DataRow dr in dsd.Tables[0].Rows)
                        {
                            grid_GR.Rows.Add();
                            grid_GR.Rows[i].Cells["desgr"].Value = dr["designation"];
                            grid_GR.Rows[i].Cells["Tauxgr"].Value = dr["PUHT"];

                            grid_GR.Rows[i].Cells["mnttravauxgr"].Value = dr["taux"];
                            grid_GR.Rows[i].Cells["PTHTGR"].Value = dr["PTHT"];
                            grid_GR.Rows[i].Cells["TVAGR"].Value = dr["TVA"];
                            grid_GR.Rows[i].Cells["IDGR"].Value = dr["ID"];
                            i++;
                        }
                    }
                    catch { }
                    grid_GR.Visible = true;
                    grid_GR.Dock = DockStyle.Fill;
                }
                else if (xtype == "TD")
                {
                    string sqld = "select * from ldivers where codes = '" + Program.Societe + "' and numf = '" + NumFact + "' and codee='" + Program.Exercice + "'";
                    DataSet dsd = met.recuperer_table(sqld);
                    try
                    {
                        int i = 0;
                        foreach (DataRow dr in dsd.Tables[0].Rows)
                        {
                            grid_TD.Rows.Add();
                            grid_TD.Rows[i].Cells["NpylonTD"].Value = dr["NPYLONE"];
                            grid_TD.Rows[i].Cells["TypePyloneTD"].Value = dr["TYPEPYLONE"];

                            grid_TD.Rows[i].Cells["VBPTD"].Value = dr["QTE"];
                            grid_TD.Rows[i].Cells["UTD"].Value = dr["U"];
                            grid_TD.Rows[i].Cells["PUHTFTD"].Value = dr["PUHT"];
                            grid_TD.Rows[i].Cells["PTHTTD"].Value = dr["PTHT"];
                            grid_TD.Rows[i].Cells["TVAFFTD"].Value = dr["TVA"];
                            grid_TD.Rows[i].Cells["IDTD"].Value = dr["ID"];
                            i++;
                        }
                    }
                    catch { }
                    grid_TD.Visible = true;
                    grid_TD.Dock = DockStyle.Fill;
                }
            }
        }


        private void buttonX3_Click(object sender, EventArgs e)
        {
            // Bouton Supprimer Facture
            if (dataGridViewX1.Rows.Count != 0)
            {
                String msg = MessageBox.Show("Ete-vous sur", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (msg.Equals("Yes"))
                {
                    string sqlupdcontrat = "";
                    String del1 = "delete from facture where codes='" + Program.Societe + "' and numf = '" + dataGridViewX1.CurrentRow.Cells["NuM"].Value + "'";
                    string table = "";
                    if (dataGridViewX1.CurrentRow.Cells["Mode"].Value.Equals("F") || dataGridViewX1.CurrentRow.Cells["Mode"].Value.Equals("FD"))
                    {
                        table = "Lfondation";
                        sqlupdcontrat = "update lcontrat join lfondation on (lcontrat.ID = lfondation.IDLC) join facture on (facture.numf = lfondation.numf and facture.codes = lfondation.codes) set lcontrat.prorataf=lcontrat.prorataf-facture.prorata where facture.numf = '" + dataGridViewX1.CurrentRow.Cells["NuM"].Value + "' and facture.codes='"+Program.Societe+"'";
                        //sqlupdcontrat = "update lcontrat set prorataf=0 where ID in(select IDLC from lfondation where numf = '" + dataGridViewX1.CurrentRow.Cells["NuM"].Value + "')";
                    }
                    else if (dataGridViewX1.CurrentRow.Cells["Mode"].Value.Equals("M") || dataGridViewX1.CurrentRow.Cells["Mode"].Value.Equals("MD"))
                    {
                        table = "lmontage";
                        sqlupdcontrat = "update lcontrat join lmontage on (lcontrat.ID = lmontage.IDLC) join facture on (facture.numf = lmontage.numf and facture.codes = lmontage.codes) set lcontrat.proratam=lcontrat.proratam-facture.prorata where facture.numf = '" + dataGridViewX1.CurrentRow.Cells["NuM"].Value + "' and facture.codes='" + Program.Societe + "'";
                        //sqlupdcontrat = "update lcontrat set proratam=0 where ID in(select IDLC from lmontage where numf = '" + dataGridViewX1.CurrentRow.Cells["NuM"].Value + "')";
                    }
                    else if (dataGridViewX1.CurrentRow.Cells["Mode"].Value.Equals("DD") || dataGridViewX1.CurrentRow.Cells["Mode"].Value.Equals("D"))
                    {
                        table = "lderoulage";
                        sqlupdcontrat = "update lcontrat join lderoulage on (lcontrat.ID = lderoulage.IDLC) join facture on (facture.numf = lderoulage.numf and facture.codes = lderoulage.codes) set lcontrat.proratad=if(lcontrat.proratad >0, lcontrat.proratad-facture.prorata,0) where facture.numf = '" + dataGridViewX1.CurrentRow.Cells["NuM"].Value + "' and facture.codes='" + Program.Societe + "'";
                        //sqlupdcontrat = "update lcontrat set proratad=0 where ID in(select IDLC from lderoulage where numf = '" + dataGridViewX1.CurrentRow.Cells["NuM"].Value + "')";
                        string sqll = "select r1.max1,r2.max2,r1.prorata from (select max(lcontrat.id) AS max1,facture.prorata AS prorata from lcontrat join lderoulage on (lcontrat.ID = lderoulage.IDLC) join facture on (facture.numf = lderoulage.numf)  where ( facture.numf = '" + dataGridViewX1.CurrentRow.Cells["NuM"].Value + "') and facture.codes='" + Program.Societe + "') r1,(select max(id) as max2 from lcontrat WHERE lcontrat.idcontrat = (select distinct(lcontrat.idcontrat) AS ID1 from lcontrat join lderoulage on (lcontrat.ID = lderoulage.IDLC) join facture on (facture.numf = lderoulage.numf)  where ( facture.numf = '" + dataGridViewX1.CurrentRow.Cells["NuM"].Value + "' ) and facture.codes='" + Program.Societe + "')) r2;";
                        DataSet dsll = met.recuperer_table(sqll);
                        int max1 = 0, max2 = 0;Decimal  prorat = 0;
                        try {
                            int.TryParse(dsll.Tables[0].Rows[0]["max1"] + "", out max1);
                            int.TryParse(dsll.Tables[0].Rows[0]["max2"] + "", out max2);
                            Decimal.TryParse(dsll.Tables[0].Rows[0]["prorata"] + "", out prorat);
                            if (max2 == max1 + 1)
                            {
                                sqll = "update lcontrat set proratad = proratad - " + prorat + " WHERE ID = " + max2;
                                met.Execute(sqll);
                            }
                        }
                        catch { }
                    }
                    else if (dataGridViewX1.CurrentRow.Cells["Mode"].Value.Equals("AV") || dataGridViewX1.CurrentRow.Cells["Mode"].Value.Equals("GR") || dataGridViewX1.CurrentRow.Cells["Mode"].Value.Equals("T"))
                    {
                        table = "ltravaux";
                        if (dataGridViewX1.CurrentRow.Cells["Mode"].Value.Equals("AV"))
                        {
                            sqlupdcontrat = "update CONTRAT join  facture on (facture.numf = CONTRAT.NUMFAvance and facture.codes = CONTRAT.codes) set CONTRAT.NUMFAvance='',CONTRAT.Favance=0 where facture.numf = '" + dataGridViewX1.CurrentRow.Cells["NuM"].Value + "' and facture.codes='" + Program.Societe + "' ";
                        }
                        if (dataGridViewX1.CurrentRow.Cells["Mode"].Value.Equals("GR"))
                        {
                            sqlupdcontrat = "update CONTRAT join  facture on (facture.numf = CONTRAT.NUMFgarantie and facture.codes = CONTRAT.codes) set CONTRAT.NUMFgarantie='',CONTRAT.Fgarantie=0 where facture.numf = '" + dataGridViewX1.CurrentRow.Cells["NuM"].Value + "' and facture.codes='" + Program.Societe + "' ";
                        }
                    }
                    else if ( dataGridViewX1.CurrentRow.Cells["Mode"].Value.Equals("TD"))
                    {
                        table = "ldivers";
                    }
                    String del2 = "delete from " + table + " where codes='" + Program.Societe + "' and numf = '" + dataGridViewX1.CurrentRow.Cells["NuM"].Value + "'";
                    
                    try
                    {
                        met.Execute(sqlupdcontrat);
                    }
                    catch { }


                    met.Execute(del2);
                    met.Execute(del1);
                    buttonX1_Click(sender, e);

                    
                }
            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            {
                FFondation ff = new FFondation();
                ff.ShowDialog();
                buttonX1_Click(sender, e);
            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            {
                FMontage ff = new FMontage();
                ff.ShowDialog();
                buttonX1_Click(sender, e);
                buttonX1_Click(sender, e);
            }
        }
        private void buttonItem7_Click(object sender, EventArgs e)
        {
            FDeroulage ff = new FDeroulage();
            ff.ShowDialog();
            buttonX1_Click(sender, e);
            buttonX1_Click(sender, e);

            
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {

            // Bouton Recherche
            if (dataGridViewX1.Rows.Count != 0)
            {
                Rechfact form = new Rechfact();
                form.table = "Client";
                form.ShowDialog();
                if (!form.textBoxX3.Text.Equals(""))
                {
                    DataRow[] dr = ds.Tables["eentc"].Select("numf = '" + form.textBoxX3.Text + "'");
                    if (dr.Length != 0)
                    {
                        int i = ds.Tables[0].Rows.IndexOf(dr[0]);
                        dataGridViewX1.Rows[i].Selected = true;
                    }
                    else
                    {
                        MessageBox.Show("N° Facture n'existe pas.");
                    }
                }
                else if (!form.code.Equals("0") && !form.dateTimeInput1.Text.Equals("") && !form.dateTimeInput2.Text.Equals(""))
                {

                    string ddebut = form.dateTimeInput1.Value.ToString("yyyy-MM-dd");
                    string dfin = form.dateTimeInput2.Value.ToString("yyyy-MM-dd");
                    string req2 = "select num,date,codec,nomc,totalht,fodec,totalrem,totaltva,totaltaxe,timbre,totalttc,montavr,montreg,reste,mode,coder from eentc where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and (codec='" + form.code + "' AND date>='" + ddebut + "' AND date<='" + dfin + "') order by num";
                    ds = met.recuperer_table(req2, "eentc");
                    dataGridViewX1.DataSource = ds.Tables["eentc"].DefaultView;
                    if (dataGridViewX1.Rows.Count != 0)
                    {
                        charger_lignefacture();
                        total();
                    }
                    buttonX1.Visible = true;
                }
                else if (!form.code.Equals("0") && !form.dateTimeInput1.Text.Equals(""))
                {


                    string ddebut = form.dateTimeInput1.Value.ToString("yyyy-MM-dd");
                    string dfin = form.dateTimeInput2.Value.ToString("yyyy-MM-dd");
                    string req2 = "select num,date,codec,nomc,totalht,fodec,totalrem,totaltva,totaltaxe,timbre,totalttc,montavr,montreg,reste,mode,coder from eentc where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and (codec='" + form.code + "' AND date>='" + ddebut + "' ) order by num";
                    ds = met.recuperer_table(req2, "eentc");
                    dataGridViewX1.DataSource = ds.Tables["eentc"].DefaultView;
                    if (dataGridViewX1.Rows.Count != 0)
                    {
                        charger_lignefacture();
                        total();
                    }
                    buttonX1.Visible = true;
                }
                else if (!form.code.Equals("0"))
                {


                    string ddebut = form.dateTimeInput1.Value.ToString("yyyy-MM-dd");
                    string dfin = form.dateTimeInput2.Value.ToString("yyyy-MM-dd");
                    string req2 = "select num,date,codec,nomc,totalht,fodec,totalrem,totaltva,totaltaxe,timbre,totalttc,montavr,montreg,reste,mode,coder from eentc where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and  (codec='" + form.code + "') order by num";
                    ds = met.recuperer_table(req2, "eentc");
                    dataGridViewX1.DataSource = ds.Tables["eentc"].DefaultView;
                    if (dataGridViewX1.Rows.Count != 0)
                    {
                        charger_lignefacture();
                        total();
                    }
                    buttonX1.Visible = true;
                }
                else if (form.code.Equals("0") && !form.dateTimeInput1.Text.Equals("") && !form.dateTimeInput2.Text.Equals(""))
                {


                    string ddebut = form.dateTimeInput1.Value.ToString("yyyy-MM-dd");
                    string dfin = form.dateTimeInput2.Value.ToString("yyyy-MM-dd");
                    //string req2 = "select num,date,codec,nomc,totalht,fodec,totalrem,totaltva,totaltaxe,timbre,totalttc,montavr,montreg,reste,mode,coder from eentc where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' AND codem ='" + Program.Magasin + "' and (date>='" + ddebut + "' AND date<='" + dfin + "') order by num";
                    string req = "select NUMF,DATEF,codec,nomc,THT,RGARANTIE,RAVANCE,NETHT,TVA,TTC,RS50,RS15,timbre,NET,TYPE from facture where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and (DATEF>='" + ddebut + "' AND DATEF<='" + dfin + "') order by numf";
                    ds = met.recuperer_table(req, "eentc");
                    dataGridViewX1.DataSource = ds.Tables["eentc"].DefaultView;
                    if (dataGridViewX1.Rows.Count != 0)
                    {
                        charger_lignefacture();
                        total();
                    }
                    buttonX1.Visible = true;
                }
                else if (form.code.Equals("0") && !form.dateTimeInput1.Text.Equals(""))
                {


                    string ddebut = form.dateTimeInput1.Value.ToString("yyyy-MM-dd");
                    string dfin = form.dateTimeInput2.Value.ToString("yyyy-MM-dd");
                    string req2 = "select num,date,codec,nomc,totalht,fodec,totalrem,totaltva,totaltaxe,timbre,totalttc,montavr,montreg,reste,mode,coder from eentc where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and (date>='" + ddebut + "' ) order by num";
                    ds = met.recuperer_table(req2, "eentc");
                    dataGridViewX1.DataSource = ds.Tables["eentc"].DefaultView;
                    if (dataGridViewX1.Rows.Count != 0)
                    {
                        charger_lignefacture();
                        total();
                    }
                    buttonX1.Visible = true;
                }
                else
                    buttonX1_Click(sender, e);
            }
          
        }

        private void Factcli1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.F1:
                    {
                        buttonX4_Click(sender, e);
                    }
                    break;

                case Keys.F3:
                    {
                        superTabControl1.SelectedTab = tab1;
                    }
                    break;

                case Keys.F4:
                    {
                        superTabControl1.SelectedTab = tab2;
                    }
                    break;

                default:
                    // actions_sinon;
                    break;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            buttonX1.Visible = false;

            int indligne = 0;
            try
            { indligne = dataGridViewX1.CurrentCell.RowIndex; }
            catch { }
            string req = "select NUMF,DATEF,codec,nomc,THT,RGARANTIE,RAVANCE,NETHT,TVA,TTC,RS50,RS15,timbre,NET,TYPE from facture where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "'  order by numf";
            ds = met.recuperer_table(req, "eentc");
            dataGridViewX1.DataSource = ds.Tables["eentc"].DefaultView;
            if (dataGridViewX1.Rows.Count != 0)
            {
                if (indligne == 0)
                {
                    indligne = dataGridViewX1.Rows.Count - 1;
                }
                try
                {
                    dataGridViewX1.CurrentCell = dataGridViewX1.Rows[indligne].Cells[5];
                }
                catch { }
                dataGridViewX1.Rows[0].Selected = false;
                try
                {
                    dataGridViewX1.FirstDisplayedScrollingRowIndex = indligne;
                
                dataGridViewX1.Rows[indligne].Selected = true;}
                catch { }
                charger_lignefacture();
                total();
            }

        }

        private void total()
        {
            Decimal xth = 0 , xtva = 0, xttc = 0 , xavr = 0 , xtreg = 0 , xtsld = 0 ,xnet=0,xrs15=0,xrs50=0,xtimbre=0,xrav=0,xretgar=0;
         

            foreach (DataRow dr in ds.Tables["eentc"].Rows)
            {

                string xf = "";//dr.Field<string>("mode");

                try
                {
                    xth += dr.Field<Decimal>("tht");
                }
                catch { }

                

                try
                {
                    xtva += dr.Field<Decimal>("TVA");
                }
                catch { }
                try
                {
                    xttc += dr.Field<Decimal>("TTC");
                }
                catch { }

                try
                {
                    xnet += dr.Field<Decimal>("NET");
                }
                catch { }

                try
                {
                    xrs50 += dr.Field<Decimal>("RS50");
                }
                catch { }

                try
                {
                    xrs15 += dr.Field<Decimal>("RS15");
                }
                catch { }

                try
                {
                    xtimbre += dr.Field<Decimal>("timbre");
                }
                catch { }

                try
                {
                    xretgar += dr.Field<Decimal>("RGARANTIE");
                }
                catch { }

                try
                {
                    xrav += dr.Field<Decimal>("ravance");
                }
                catch { }

               

            }

            textBoxX1.Text = xth.ToString("N3");
            textBoxX3.Text = xtva.ToString("N3");
            textBoxX4.Text = xttc.ToString("N3");
            textBoxX5.Text = xtreg.ToString("N3");
            textBoxX6.Text = xtsld.ToString("N3");
            textBoxX7.Text = xavr.ToString("N3");

            textBoxX2.Text = xnet.ToString("N3");
            textBoxX8.Text = xrs15.ToString("N3");
            textBoxX9.Text = xrs50.ToString("N3");
            textBoxX10.Text = xtimbre.ToString("N3");
            textBoxX11.Text = xretgar.ToString("N3");
            textBoxX12.Text = xrav.ToString("N3");
        }

        private void dataGridViewX2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count != 0)
            {
                if ((dataGridViewX1.CurrentRow.Cells["TYPE"].Value + "").Equals("F"))
                {
                    FFondation ff = new FFondation();
                    ff.newf = false;
                    ff.NumFact = dataGridViewX1.CurrentRow.Cells["NuM"].Value + "";
                    ff.ShowDialog();
                    buttonX1_Click(sender, e);
                }
                else if ((dataGridViewX1.CurrentRow.Cells["TYPE"].Value + "").Equals("M"))
                {
                    FMontage ff = new FMontage();
                    ff.newf = false;
                    ff.NumFact = dataGridViewX1.CurrentRow.Cells["NuM"].Value + "";
                    ff.ShowDialog();
                    buttonX1_Click(sender, e);
                }
                else if ((dataGridViewX1.CurrentRow.Cells["TYPE"].Value + "").Equals("D"))
                {
                    FDeroulage ff = new FDeroulage();
                    ff.newf = false;
                    ff.NumFact = dataGridViewX1.CurrentRow.Cells["NuM"].Value + "";
                    ff.ShowDialog();
                    buttonX1_Click(sender, e);
                }
                else if ((dataGridViewX1.CurrentRow.Cells["TYPE"].Value + "").Equals("T"))
                {
                    FDivers ff = new FDivers();
                    ff.newf = false;
                    ff.NumFact = dataGridViewX1.CurrentRow.Cells["NuM"].Value + "";
                    ff.ShowDialog();
                    buttonX1_Click(sender, e);
                }
            }
        }


        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {
            superTabControl1.SelectedTab = tab2;
        }

        private void dataGridViewX2_DoubleClick(object sender, EventArgs e)
        {
            superTabControl1.SelectedTab = tab1;
        }

        private void superTabControlPanel2_Click(object sender, EventArgs e)
        {

        }

        private void Factcli1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

        private void dataGridViewX1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow dgr in dataGridViewX1.Rows)
            {


                string xtype = dgr.Cells["mode"].Value + "";
                Color c = Color.LightCyan;
                Color c1 = Color.Black;
                if (xtype == "D")
                {
                     c = Color.Yellow;
                     c1 = Color.Black;
                }
                else if (xtype == "DD")
                {
                    c = Color.Yellow;
                     c1 = Color.Black;
                }
                
                else if (xtype == "M")
                {
                     c = Color.Gray;
                     c1 = Color.White;
                }
                else if (xtype == "MD")
                {
                     c = Color.LightGray;
                     c1 = Color.Black;
                }
                else if (xtype == "F")
                {

                    c = Color.Red;
                    c1 = Color.White;
                }
                else if (xtype == "FD")
                {
                    c = Color.Orange;
                    c1 = Color.Black;
                }

                else if (xtype == "T")
                {
                    c = Color.Blue;
                    c1 = Color.WhiteSmoke;

                }
                else if (xtype == "AV")
                {
                    c =  Color.FromArgb(255, 255, 192);
                    c1 = Color.Black;

                }
                else if (xtype == "GR")
                {
                    c = Color.FromArgb(255, 224, 192);
                    c1 = Color.FromArgb(10, 10, 192);

                }
                //dgr.Cells["num"].Style.ForeColor = c1;
                //dgr.Cells["num"].Style.BackColor =c;
                //dgr.Cells["date"].Style.ForeColor = c1;
                //dgr.Cells["date"].Style.BackColor = c;
                //dgr.Cells["codec"].Style.ForeColor = c1;
                //dgr.Cells["codec"].Style.BackColor = c;
                //dgr.Cells["libellec"].Style.ForeColor = c1;
                //dgr.Cells["libellec"].Style.BackColor = c;

                dgr.Cells["totalht"].Style.ForeColor = c1;
                dgr.Cells["totalht"].Style.BackColor = c;
                dgr.Cells["RGARANTIE"].Style.ForeColor = c1;
                dgr.Cells["RGARANTIE"].Style.BackColor = c;
                dgr.Cells["totaltva"].Style.ForeColor = c1;
                dgr.Cells["totaltva"].Style.BackColor = c;
                dgr.Cells["Ravance"].Style.ForeColor = c1;
                dgr.Cells["Ravance"].Style.BackColor = c;
                dgr.Cells["totalttc"].Style.ForeColor = c1;
                dgr.Cells["totalttc"].Style.BackColor = c;
                dgr.Cells["timbre"].Style.ForeColor = c1;
                dgr.Cells["timbre"].Style.BackColor = c;
                dgr.Cells["NETHT"].Style.ForeColor = c1;
                dgr.Cells["NETHT"].Style.BackColor = c;
                dgr.Cells["montavr"].Style.ForeColor = c1;
                dgr.Cells["montavr"].Style.BackColor = c;
                dgr.Cells["montreg"].Style.ForeColor = c1;
                dgr.Cells["montreg"].Style.BackColor = c;
                dgr.Cells["reste"].Style.ForeColor = c1;
                dgr.Cells["reste"].Style.BackColor = c;

                dgr.Cells["RS50"].Style.ForeColor = c1;
                dgr.Cells["RS50"].Style.BackColor = c;
                dgr.Cells["RS15"].Style.ForeColor = c1;
                dgr.Cells["RS15"].Style.BackColor = c;
                dgr.Cells["NET"].Style.ForeColor = c1;
                dgr.Cells["NET"].Style.BackColor = c;
            }
        }

       

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count != 0)
            {
                if (dataGridViewX1.SelectedRows[0].Cells["mode"].Value.Equals("D"))
                {
                }
                else if (dataGridViewX1.SelectedRows[0].Cells["mode"].Value.Equals("L"))
                {
                   
                }
                else if (dataGridViewX1.SelectedRows[0].Cells["mode"].Value.Equals("B"))
                {
                   
                }
            }
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count != 0)
            {
               
            }
        }

        private void superTabControlPanel1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            FDivers ff = new FDivers();
            ff.ShowDialog();
            buttonX1_Click(sender, e);
            
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            FContart fc = new FContart();
            fc.ShowDialog();
            buttonX1_Click(sender, e);
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
           
            if (dataGridViewX1.Rows.Count != 0)
            {
                if ((dataGridViewX1.CurrentRow.Cells["TYPE"].Value + "").Equals("F"))
                {
                    rpt.frm_fondation ff = new rpt.frm_fondation();
                    ff.numf = dataGridViewX1.CurrentRow.Cells["NuM"].Value + "";
                    ff.ShowDialog();
                }
                if ((dataGridViewX1.CurrentRow.Cells["TYPE"].Value + "").Equals("FD"))
                {
                    rpt.frm_fondationC ff = new rpt.frm_fondationC();
                    ff.numf = dataGridViewX1.CurrentRow.Cells["NuM"].Value + "";
                    ff.ShowDialog();
                }
                else if ((dataGridViewX1.CurrentRow.Cells["TYPE"].Value + "").Equals("M"))
                {
                    rpt.frm_MONTAGE ff = new rpt.frm_MONTAGE();
                    ff.numf = dataGridViewX1.CurrentRow.Cells["NuM"].Value + "";
                    ff.ShowDialog();
                }
                else if ((dataGridViewX1.CurrentRow.Cells["TYPE"].Value + "").Equals("MD"))
                {
                    rpt.frm_MONTAGEC ff = new rpt.frm_MONTAGEC();
                    ff.numf = dataGridViewX1.CurrentRow.Cells["NuM"].Value + "";
                    ff.ShowDialog();
                }
                else if ((dataGridViewX1.CurrentRow.Cells["TYPE"].Value + "").Equals("D"))
                {
                    rpt.frm_DEROULAGE ff = new rpt.frm_DEROULAGE();
                    ff.numf = dataGridViewX1.CurrentRow.Cells["NuM"].Value + "";
                    ff.ShowDialog();
                }
                else if ((dataGridViewX1.CurrentRow.Cells["TYPE"].Value + "").Equals("DD"))
                {
                    rpt.frm_DEROULAGEC ff = new rpt.frm_DEROULAGEC();
                    ff.numf = dataGridViewX1.CurrentRow.Cells["NuM"].Value + "";
                    ff.ShowDialog();
                }
                else if ((dataGridViewX1.CurrentRow.Cells["TYPE"].Value + "").Equals("T"))
                {
                    rpt.frm_TRAVAUX ff = new rpt.frm_TRAVAUX();
                    ff.numf = dataGridViewX1.CurrentRow.Cells["NuM"].Value + "";
                    ff.ShowDialog();
                }
                else if ((dataGridViewX1.CurrentRow.Cells["TYPE"].Value + "").Equals("AV"))
                {
                    rpt.frm_TRAVAUXAV ff = new rpt.frm_TRAVAUXAV();
                    ff.numf = dataGridViewX1.CurrentRow.Cells["NuM"].Value + "";
                    ff.ShowDialog();
                }
                else if ((dataGridViewX1.CurrentRow.Cells["TYPE"].Value + "").Equals("GR"))
                {
                    rpt.frm_TRAVAUXGR ff = new rpt.frm_TRAVAUXGR();
                    ff.numf = dataGridViewX1.CurrentRow.Cells["NuM"].Value + "";
                    ff.ShowDialog();
                }
                else if ((dataGridViewX1.CurrentRow.Cells["TYPE"].Value + "").Equals("TD"))
                {
                    rpt.frm_DDIERSC ff = new rpt.frm_DDIERSC();
                    ff.numf = dataGridViewX1.CurrentRow.Cells["NuM"].Value + "";
                    ff.ShowDialog();
                }
            }
        }

        private void Factcli1_Shown(object sender, EventArgs e)
        {
            buttonX1_Click(sender, e);
            if (Program.ISDemo)
            {
                if (dataGridViewX1.Rows.Count > 30)
                {
                    buttonX5.Enabled = false;
                }
            }
            first = false;
        }

      

       

    }
}
