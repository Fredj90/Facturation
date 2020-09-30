using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace commerciale
{
    public partial class ModelVente : Form
    {
        private metier met = Program.met;
        public DataSet ds = new DataSet();
        public MetierClient cli = new MetierClient("");
        public MetierRep rep = new MetierRep("");
        public MetierArticle art;
        Control c = null;
        public int num, xnum;
        //int index = 0;
        Boolean act = false;
        public List<MetierArticle> Liste_article = new List<MetierArticle>();
        public Boolean ISMODIF = false;
        public Boolean affrech = false;
        int currentrow = 0;
        public Boolean ControlStock = true;
        public Boolean validaterow = false;
        public String NumFact;
        public Boolean change = false;
        public MetierVente MVent;
        public MetierParametre metparam = new MetierParametre();
        public Boolean close_save = true;
        Boolean force_supp = false;
        public Boolean ControlComplement = true;
        public Boolean ControlPrix = true;
        public Boolean ControlSauvegarde = false;
        public string impbon="";
       
        public ModelVente()
        {
            InitializeComponent();
        }

        protected void Model_Load(object sender, EventArgs e)
        {
            Program.desTfunction(this);
           // this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Modelvente_FormClosing);
            metparam.Init();
            dgv_fact.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgv_fact_EditingControlShowing);

            if (ISMODIF)
            {
                act = true;
                nfact.Enabled = false;
                MVent.ini(NumFact);
                MVent.load(NumFact);
                MVent.ISMODIF = true;
                Liste_article = MVent.listArt.ToList();
                Remplir_data();
                dgv_fact.Enabled = true;
                datefact.Focus();
                act = false;
            }
            else
            {
                MVent.ini(Liste_article, nfact.Text, cli, rep, datefact.Value, Tcom.Text,cmbtypevente.Text);
                increment();
                datefact.Value = DateTime.Now;
                if (MVent.cli != null)
                {
                    if (MVent.cli.Comptant)
                    {
                        cli = MVent.cli;
                        Tcodc.Text = cli.Codec;
                        Tnomc.Text = cli.NomC;
                        Tadrc.ReadOnly = false;
                        Tadrc.Text = cli.adrc;
                        dgv_fact.TabIndex = 0;
                        dgv_fact.Enabled = true;
                        dgv_fact.Focus();
                    }
                }
            }
        }

 #region DataGrid
        //Action
        private void dgv_fact_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            c = e.Control;
            affrech = true;
            e.Control.KeyUp += new KeyEventHandler(Control_KeyUp);
            e.Control.TextChanged += new EventHandler(Control_TextChanged);
            currentrow = dgv_fact.CurrentCell.RowIndex;
        }

        void Control_TextChanged(object sender, EventArgs e)
        {
            if (dgv_fact.CurrentCell == dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["codea"] || dgv_fact.CurrentCell == dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["libelle"])
            {
                affrech = true;
            }
            //throw new NotImplementedException();
        }

        void Control_KeyUp(object sender, KeyEventArgs e)
        {
            change = true;
            if (affrech && cli != null)
            {
                rechartmaj rechart;

                art = null;
                if (dgv_fact.Columns[dgv_fact.CurrentCell.ColumnIndex].Name == "codea")
                {
                    rechart = new rechartmaj("artdep", c.Text, null);
                    rechart.ShowDialog();
                    if (rechart.valider)
                    {
                        c.Text = rechart.code;
                        art = new MetierArticle(rechart.code, rechart.codeg, rechart.coded, cli.Codec, ControlComplement);
                        art.libelled = rechart.libelled;
                        art.libelleg = rechart.libelleg;
                        try
                        {
                            dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["codea"].Value = art.Code;
                        }
                        catch { }
                    }
                    else
                    {
                        force_supp = true;
                        dgv_fact.CancelEdit();
                        force_supp = false;
                    }
                    

                }
                else if (dgv_fact.Columns[dgv_fact.CurrentCell.ColumnIndex].Name == "libelle")
                {
                    rechart = new rechartmaj("artdep", null, c.Text);
                    rechart.ShowDialog();
                    if (rechart.valider)
                    {
                        c.Text = rechart.libe;
                        art = new MetierArticle(rechart.code, rechart.codeg, rechart.coded, cli.Codec, ControlComplement);
                        art.libelled = rechart.libelled;
                        art.libelleg = rechart.libelleg;
                        try
                        {
                            dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["libelle"].Value = art.Libelle;
                        }
                        catch { }
                    }
                    else
                    {
                        force_supp = true;
                        dgv_fact.CancelEdit();
                        force_supp = false;
                    }
                    
                }


                if (art != null)
                {
                    if (art.UtilisationTvaVente)
                    {
                        art.RemiseClient(cli);
                        if (cli.ExenorationClient)
                        {
                            art.TVA = 0;
                        }
                        if (!cli.RegimeClient && art.majoration)
                            art.TVA += art.TVA * metparam.tauxM / 100;
                                                   
                    }
                    else
                    {
                        art.TVA = 0;
                    }
                    if (cli.ExenorationClient || cli.RegimeClient || cli.Comptant)
                    {
                        art.TAXE = 0;
                    }
                    if (dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["numlist"].Value == null)
                    {
                        dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["numlist"].Value = Liste_article.Count;
                        art.isAvoir = MVent.IsAvoir;
                        Liste_article.Add(art);

                    }
                    else
                    {
                        int index = int.Parse(dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["numlist"].Value + "");
                        {
                            if (ControlStock && Liste_article[index].variationStock)
                            {
                                Liste_article[index].SupprimerLigne();
                                double Xqte = 0;
                                Double.TryParse(dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["qte"].Value + "", out Xqte);
                                art.isAvoir = MVent.IsAvoir;
                                if (MVent.IsAvoir)
                                {
                                    art.sauveLigne(-Xqte);
                                }
                                else
                                {
                                    art.sauveLigne(Xqte);
                                }
                            }
                            Liste_article[index] = art;
                        }
                    }
                    addarttodatagrid(art, dgv_fact.CurrentCell.RowIndex, Liste_article.Count - 1);
                    dgv_fact.CurrentCell = dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["qte"];
                }
                else if (dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["numlist"].Value != null)
                {
                    int index = int.Parse(dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["numlist"].Value + "");
                    art = Liste_article[index];
                }
                affrech = false;
            }
            //throw new NotImplementedException();
        }

        private void dgv_fact_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if(!act)
            {
                if (dgv_fact.CurrentRow.ReadOnly == false)
                {
                    if (dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["numlist"].Value != null)
                    {
                        if (dgv_fact.CurrentCell == dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["qte"])
                        {

                            int index = int.Parse(dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["numlist"].Value + "");
                            Double XQTE = 0;
                            Double.TryParse(dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["qte"].Value + "", out XQTE);
                            Liste_article[index].QTESAISIE = XQTE;
                            Liste_article[index].RemiseClient(cli);
                            if (ControlStock && Liste_article[index].variationStock)
                            {
                                if (MVent.IsAvoir)
                                {
                                    Liste_article[index].sauveLigne(-XQTE);
                                }
                                else
                                {
                                    Liste_article[index].sauveLigne(XQTE);
                                }
                            }
                            MAJLigne(Liste_article[index], dgv_fact.CurrentCell.RowIndex);
                        }
                        else if (dgv_fact.CurrentCell == dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["rem"])
                        {

                            int index = int.Parse(dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["numlist"].Value + "");
                            Double XREM = 0;
                            Double.TryParse(dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["rem"].Value + "", out XREM);
                            Liste_article[index].REM = XREM;
                            Liste_article[index].ChangerREM = false;
                            MAJLigne(Liste_article[index], dgv_fact.CurrentCell.RowIndex);
                        }
                        else if (dgv_fact.CurrentCell == dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["puht"])
                        {
                            try
                            {
                                int index = int.Parse(dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["numlist"].Value + "");
                                Double XPUHT = 0;
                                Double.TryParse(dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["puht"].Value + "", out XPUHT);
                                Liste_article[index].PUHT = XPUHT;
                                MAJLigne(Liste_article[index], dgv_fact.CurrentCell.RowIndex);
                            }
                            catch { }
                        }
                       
                    }
                }
            }
        }

        private void dgv_fact_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!act)
            {
                if (dgv_fact.CurrentRow.ReadOnly == false && dgv_fact.CurrentRow.IsNewRow == false)
                {
                    if (dgv_fact.CurrentCell == dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["qte"])
                    {
                        Double xqte = 0;
                        Double.TryParse(e.FormattedValue + "", out xqte);
                        if (!VerifStock(xqte))
                        {
                            if (MessageBox.Show("Stock Insuffisant.\nVoulez-vous Continuer?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                            {
                                e.Cancel = true;
                            }
                        }
                    }
                    else if (dgv_fact.CurrentCell == dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["puht"])
                    {
                        if (ControlPrix)
                        {
                            double xd = 0;
                            double.TryParse(dgv_fact.CurrentCell.Value + "", out xd);
                            if (xd == 0)
                            {
                                MessageBox.Show("Prix doit #0");
                                e.Cancel = true;
                            }
                        }
                    }
                    else if (dgv_fact.CurrentCell == dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["codea"] )
                    {
                        if (dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["codea"].Value == null)
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            act = true;
                            dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["codea"].ReadOnly = true;
                            dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["libelle"].ReadOnly = true;
                            act = false;
                        }
                    }
                    if (dgv_fact.CurrentCell == dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["libelle"])
                    {
                        if (dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["libelle"].Value == null)
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            act = true;
                            dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["codea"].ReadOnly = true;
                            dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["libelle"].ReadOnly = true;
                            act = false;
                        }
                    }
                    
                }
            }
        }

        private void dgv_fact_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            double xnet = 0;
            Double.TryParse(dgv_fact.Rows[e.RowIndex].Cells["netttc"].Value + "", out xnet);
            double xqte = 0;
            Double.TryParse(dgv_fact.Rows[e.RowIndex].Cells["qte"].Value + "", out xqte);
            double xpht = 0;
            Double.TryParse(dgv_fact.Rows[e.RowIndex].Cells["puht"].Value + "", out xpht);

            if (dgv_fact.RowCount != 1 && !dgv_fact.CurrentRow.IsNewRow)
            {
                if (ControlPrix)
                {
                    if (xnet == 0)
                    {
                        MessageBox.Show("Vérifier la Quantité et/ou Le Prix Unitaire");
                        validaterow = false;
                        try
                        {
                            //
                            e.Cancel = true;
                        }
                        catch { }
                    }
                    else
                        validaterow = true;
                }
                else
                {
                    if (xqte == 0)
                    {
                        MessageBox.Show("Vérifier la Quantité.");
                        validaterow = false;
                        try
                        {
                            //
                            e.Cancel = true;
                        }
                        catch { }
                    }
                    else
                        validaterow = true;
                }

            }

        }

        private void dgv_fact_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (!validaterow)
            {
                dgv_fact.CurrentCell = dgv_fact.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgv_fact_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_fact.CurrentCell != null)
                if (dgv_fact.Rows[e.RowIndex].Cells["codea"].Value != null)
                {
                    if (!dgv_fact.Rows[e.RowIndex].Cells["codea"].Value.Equals(String.Empty))
                    {
                        if (dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["numlist"].Value == null)
                        {
                            art = null;
                        }
                        else
                        {
                            int index = int.Parse(dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["numlist"].Value + "");
                            art = Liste_article[index];
                        }

                    }
                }

        }

        private void dgv_fact_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgv_fact.CurrentRow.ReadOnly == false)
            {
                Boolean del = force_supp;
                if (!del)
                {
                    if (MessageBox.Show("Voulez-vous Supprimer cette Ligne?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        del = true;
                    }
                }
                if (del)
                {
                    if (ControlStock && dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["numlist"].Value!=null)
                    {
                        int index = -1;
                        int.TryParse(dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["numlist"].Value + "", out index);
                        if (index != -1)
                        {
                            if (Liste_article[index].variationStock)
                            {
                                double d = 0;
                                double.TryParse(dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["qte"].Value + "", out d);
                                double d1 = Liste_article[index].QTEDERNIERSAISIE;
                                if (Liste_article[index].QTEINITIAL != 0)
                                {
                                    Liste_article[index].QTEDERNIERSAISIE = d;
                                    Liste_article[index].QTEINITIAL -= d;
                                }
                                Liste_article[index].SupprimerLigne();
                                Liste_article[index].QTEDERNIERSAISIE = d1;
                            }
                            for (int i = 0; i < Liste_article[index].Complements.Count; i++)
                            {
                                dgv_fact.Rows.RemoveAt(dgv_fact.CurrentRow.Index + 1);
                            }
                            Liste_article.RemoveAt(index);
                        }
                    }
                }
                else
                    e.Cancel = true;
            }
            else { e.Cancel = true; }
        }

        private void dgv_fact_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (!force_supp)
            {
                Remplir_data();
                change = true;
            }
        }

        private void dgv_fact_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            /*if (dgv_fact[e.ColumnIndex, e.RowIndex] != dgv_fact.CurrentRow.Cells["Codea"] && dgv_fact[e.ColumnIndex, e.RowIndex] != dgv_fact.CurrentRow.Cells["libelle"])
                if (dgv_fact.CurrentRow.Cells["numlist"].Value == null)
                {
                    try
                    {
                        dgv_fact.CurrentCell = dgv_fact.Rows[e.RowIndex].Cells["Codea"];
                    }
                    catch { }
                }*/
        }

        private void dgv_fact_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgv_fact[e.ColumnIndex, e.RowIndex] != dgv_fact.CurrentRow.Cells["Codea"] && dgv_fact[e.ColumnIndex, e.RowIndex] != dgv_fact.CurrentRow.Cells["libelle"])
                if (dgv_fact.CurrentRow.Cells["numlist"].Value == null)
                {
                    e.Cancel = true;
                }
        }

        private void Modelvente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!ControlSauvegarde)
            {
                if ((Liste_article.Count != 0 || MVent.listArt.Count != 0) && change)
                {
                    if (MessageBox.Show("Voulez-vous Quiter sans sauvegarde?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (ControlStock)
                        {
                            foreach (MetierArticle art in Liste_article)
                            {
                                if (art.variationStock)
                                {
                                    art.SupprimerLigne();
                                }
                            }
                            if (ISMODIF)
                            {
                                foreach (MetierArticle art in MVent.listArt)
                                {
                                    MetierArticle tmp = Liste_article.SingleOrDefault(l => l.ID == art.ID);
                                    if (tmp == null)
                                    {
                                        if (art.variationStock)
                                        {
                                            art.QTEDERNIERSAISIE = 0;
                                            {
                                                art.sauveLigne(art.QTESAISIE);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                        e.Cancel = true;
                }
            }
           
        }


        #endregion

#region // Fonction

        private void Remplir_data()
        {
            Boolean ancact = act;
            act = true;
            dgv_fact.Rows.Clear();
            
            int index = 0;
            nfact.Text = NumFact;
            datefact.Value = MVent.dat;
            Tcodc.Text = MVent.cli.Codec;
            Tnomc.Text = MVent.cli.NomC;
            Tadrc.Text = MVent.cli.adrc;
            try
            {
                Tcodr.Text = MVent.rep.CodeR;
                Tnomr.Text = MVent.rep.NomR;
                Tadrr.Text = MVent.rep.AdrR;
            }
            catch { }
            try
            {
                Tcom.Text = MVent.numcom;
            }
            catch { }
            cmbtypevente.Text = MVent.xtype;
            
            cli = MVent.cli;
            if (cli.Comptant)
            {
                Tadrc.ReadOnly = false;
            }
            rep = MVent.rep;
            foreach (MetierArticle art in Liste_article)
            {
                dgv_fact.Rows.Add();
                art.QteSock();
                addarttodatagrid(art, dgv_fact.Rows.Count - 2, index);
                MAJLigne(art, dgv_fact.Rows.Count - 2 - art.Complements.Count);
                dgv_fact.Rows[dgv_fact.Rows.Count - 2].Cells["codea"].ReadOnly = true;
                dgv_fact.Rows[dgv_fact.Rows.Count - 2].Cells["libelle"].ReadOnly = true;
                index++;
                
            }
            try
            {
                art = Liste_article[0];
            }
            catch { }
            dgv_fact.UpdateRowHeightInfo(0, true);
            act = ancact;
        }

        void addarttodatagrid(MetierArticle art, int index, int indexliste)
        {
            dgv_fact.Rows[index].Cells["codea"].Value = art.Code;
            dgv_fact.Rows[index].Cells["qte"].Value = art.QTESAISIE;
            dgv_fact.Rows[index].Cells["libelle"].Value = art.Libelle;
            dgv_fact.Rows[index].Cells["codeg"].Value = art.libelleg;
            dgv_fact.Rows[index].Cells["coded"].Value = art.libelled;
            dgv_fact.Rows[index].Cells["numlist"].Value = indexliste;

            try
            {
                dgv_fact.Rows[index].Cells["taxe"].Value = art.TAXE.ToString("N2");
            }
            catch { }
            try
            {
                dgv_fact.Rows[index].Cells["puht"].Value = art.PUHT.ToString("N3");
            }
            catch { }
            try
            {
                dgv_fact.Rows[index].Cells["tva"].Value = art.TVA.ToString("N2");
            }
            catch { }

            try
            {
                dgv_fact.Rows[index].Cells["tvaf"].Value = art.FODEC.ToString("N2");
            }
            catch { }

            try
            {
                dgv_fact.Rows[index].Cells["dpu"].Value = art.DernierPrixHT.ToString("N3");
            }
            catch { }
              
            try
            {
                dgv_fact.Rows[index].Cells["rem"].Value = cli.RemiseFixeClient.ToString("N2");
            }
            catch { }

            try
            {
                dgv_fact.Rows[index].Cells["qtestk"].Value = art.QTESTK.ToString("N3");
            }
            catch { }
         

            //....
            int ii = 0;
            foreach (complement cpl in art.Complements)
            {
                dgv_fact.Rows.Add();
                index++;
                dgv_fact.Rows[index].ReadOnly = true;
                dgv_fact.Rows[index].Cells["libelle"].Value = cpl.Libelle;
                dgv_fact.Rows[index].Cells["codesa"].Value = cpl.Code;
                dgv_fact.Rows[index].Cells["numlist"].Value = indexliste;
                dgv_fact.Rows[index].Cells["numcpl"].Value = ii;

                try
                {
                    dgv_fact.Rows[index].Cells["puht"].Value = cpl.PUHT.ToString("N3");
                }
                catch { }

                try
                {
                    dgv_fact.Rows[index].Cells["tva"].Value = cpl.TVA.ToString("N2");
                }
                catch { }
                ii++;
            }
        }

        private void MAJLigne(MetierArticle art, int Rowindex)
        {
            if (cli.ExenorationClient || cli.RegimeClient || cli.Comptant)
            {
                art.TAXE = 0;
            }
            else
                art.TAXE = art.TAXEINI;
            art.Calcul();
            dgv_fact.Rows[Rowindex].Cells["netht"].Value = art.MNTNETHT;
            dgv_fact.Rows[Rowindex].Cells["netttc"].Value = art.MNTNETTTC;
            dgv_fact.Rows[Rowindex].Cells["rem"].Value = art.REM;
            dgv_fact.Rows[Rowindex].Cells["taxe"].Value = art.TAXE;
            for (int i = 0; i < art.Complements.Count; i++)
            {
                int index = int.Parse(dgv_fact.Rows[Rowindex + i + 1].Cells["numcpl"].Value + "");
                dgv_fact.Rows[Rowindex + i + 1].Cells["netht"].Value = art.Complements[index].MNTNETHT;
                dgv_fact.Rows[Rowindex + i + 1].Cells["netttc"].Value = art.Complements[index].MNTNETTTC;
                dgv_fact.Rows[Rowindex + i + 1].Cells["qte"].Value = art.Complements[index].QTE;
            }
            Totaux();
        }

        private void Totaux()
        {
            double THT = 0, TFODEC = 0, TREM = 0, TTVA = 0, TTTC = 0,TTAXE=0;
            foreach (MetierArticle art in Liste_article)
            {
                THT += art.MNTNETHT + art.MNTREM;
                TFODEC += art.MNTFODEC;
                TREM += art.MNTREM;
                TTVA += art.MNTTVA;
                TTTC += art.MNTNETTTC;
                TTAXE += art.MNTTAXE;
                foreach (complement cpl in art.Complements)
                {
                    THT += cpl.MNTNETHT;
                    TTVA += cpl.MNTTVA;
                    TTTC += cpl.MNTNETTTC;
                }
            }
            if (cli.TimbreFactClient && MVent.UseTimbre)
            {
                MVent.TIMBRE = metparam.Timbre;
                TTTC += MVent.TIMBRE;
            }
            else
                MVent.TIMBRE = 0;
            textB1.Text = THT.ToString("N3");
            textB2.Text = TFODEC.ToString("N3");
            textB3.Text = TREM.ToString("N3");
            textB4.Text = TTVA.ToString("N3");
            textB5.Text = MVent.TIMBRE.ToString("N3");
            textB6.Text = TTTC.ToString("N3");
            textB7.Text = TTAXE.ToString("N3");
        }

        private Boolean VerifStock(Double xqte)
        {
            Boolean ret = true;
            if (ControlStock && dgv_fact.CurrentRow.Cells["numlist"].Value!=null)
            {
                int index = -1;
                int.TryParse(dgv_fact.CurrentRow.Cells["numlist"].Value + "", out index);
                if (Liste_article[index].variationStock)
                {
                    if (index != -1)
                    {
                        if (Liste_article[index].ID != 0)
                        {
                            Liste_article[index].QTEDERNIERSAISIE = - Liste_article[index].QTESAISIE;
                        }
                        if (MVent.IsAvoir)
                        {
                            Liste_article[index].sauveLigne(0-xqte);
                        }
                        else
                        {
                            Liste_article[index].sauveLigne(xqte);
                        }
                        if (Liste_article[index].QTESTK < 0)
                        {
                            ret = false;
                        }
                    }
                }
            }
            return ret;
        }
        # endregion

#region // Bouttons Sauvegarde && annuler Sauvegarde && supprimer Ligne

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (nfact.Text != "" && datefact.Text !="" && Tcodc.Text !="" )
            {
                if (dgv_fact.Rows.Count >= 2)
                {
                    MVent.numFact = nfact.Text;
                    MVent.numcom = Tcom.Text;
                    MVent.dat = datefact.Value;
                    MVent.xtype = cmbtypevente.Text;
                    MVent.listArt = Liste_article;
                    if (cli.Comptant)
                    {
                        MVent.cli.NomC = Tnomc.Text;
                        MVent.cli.adrc = Tadrc.Text;
                    }
                    MVent.save();
                  
                    MessageBox.Show("Sauvegarde effectué.");

                    ControlSauvegarde = true;

                    DesActiverVente();

                   
                }
                else
                    MessageBox.Show("Aucun Article ");
            }
            else
            {
                MessageBox.Show("Saisir Numéro, Date, Client ");
            }

        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (dgv_fact.CurrentRow.ReadOnly == false && !dgv_fact.CurrentRow.IsNewRow)
            {
                if (MessageBox.Show("Voulez-vous Supprimer cette Ligne?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    int index = -1;
                    int.TryParse(dgv_fact.CurrentRow.Cells["numlist"].Value + "", out index);
                    change = true;
                    if (ControlStock)
                    {

                        if (index != -1)
                        {
                            if (Liste_article[index].variationStock)
                            {
                                double d = 0;
                                double.TryParse(dgv_fact.Rows[dgv_fact.CurrentCell.RowIndex].Cells["qte"].Value + "", out d);
                                double d1 = Liste_article[index].QTEDERNIERSAISIE;
                                if (Liste_article[index].QTEINITIAL != 0)
                                {
                                    Liste_article[index].QTEDERNIERSAISIE = d;
                                    Liste_article[index].QTEINITIAL -= d;
                                }
                                Liste_article[index].SupprimerLigne();
                                Liste_article[index].QTEDERNIERSAISIE = d1;
                            }
                        }
                    }
                    int Rowindex = dgv_fact.CurrentRow.Index;
                    dgv_fact.Rows.Remove(dgv_fact.CurrentRow);
                    for (int i = 0; i < Liste_article[index].Complements.Count; i++)
                    {
                        dgv_fact.Rows.RemoveAt(Rowindex);
                    }
                    Liste_article.RemoveAt(index);
                  //  Liste_article.RemoveAt(index);
                    Remplir_data();
                    ControlSauvegarde = false;
                }
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            String msg = MessageBox.Show("Ete-vous sur", "Sortir", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (msg.Equals("Yes"))
            {
                this.Close();
            }
        }

        #endregion //sauvegarde

#region // Région Création Client & Répresentant

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Client form = new Client();
            form.ShowDialog();
        }

        // Création Représentant
        private void buttonX2_Click(object sender, EventArgs e)
        {
            Rep form = new Rep();
            form.ShowDialog();
        }
# endregion Fin Création Client & Répresentant

# region // Région Keypress

        private void nfact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                datefact.Focus();
        }

        private void datefact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                if (Tcom.Visible)
                    Tcom.Focus();
                else
                    Tcodc.Focus();
            }
            
        }

        private void Tcom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                Tcodc.Focus();
        }

        private void Tcodc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                Tnomc.Focus();
        }


        private void Tnomc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                if (Tnomc.Text != "")
                {
                    if (cli.Comptant)
                        Tadrc.Focus();
                    else
                    {
                        if (cmbtypevente.Visible)
                            cmbtypevente.Focus();
                        else if (Tcodr.Visible)
                            Tcodr.Focus();
                        else dgv_fact.Focus();
                    }
                }
        }


        private void cmbtypevente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                if (cmbtypevente.SelectedIndex != -1)
                Tcodr.Focus();
        }

        private void Tcodr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                Tnomr.Focus();
        }

        private void Tnomr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                if (Tnomr.Text != "")
                    dgv_fact.Focus();
        }

        private void Tadrc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                if (cmbtypevente.Visible)
                    cmbtypevente.Focus();
                else if (Tcodr.Visible)
                    Tcodr.Focus();
                else dgv_fact.Focus();
            }
        }

# endregion Fin Région Keypress

#region // Région Recherche Client & Répresentant

        private void Tcodc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                if (Tcodc.Text != "")
                {
                    rechcli rcli = new rechcli("client", Tcodc.Text, null);
                    rcli.ShowDialog();
                    if (rcli.valider)
                    {
                        cli = new MetierClient(rcli.code);
                        MVent.cli = cli;
                        change = true;
                        dgv_fact.Enabled = true;
                        foreach (DataGridViewRow dr in dgv_fact.Rows)
                        {
                            if (dr.Cells["numlist"].Value != null && dr.Cells["numcpl"].Value == null)
                            {
                                int index = int.Parse(dr.Cells["numlist"].Value + "");
                                Liste_article[index].RemiseClient(cli);
                                Liste_article[index].Calcul();
                                MAJLigne(Liste_article[index], dr.Index);
                            }
                        }
                        if (cli.Comptant)
                        {
                            Tnomc.Focus();
                            Tadrc.ReadOnly = false;
                        }
                        else
                        {
                            if (cmbtypevente.Visible)
                                cmbtypevente.Focus();
                            else if (Tcodr.Visible)
                                Tcodr.Focus();
                            else dgv_fact.Focus();
                            Tadrc.ReadOnly = true;
                        }
                    }
                    if (cli != null)
                    {
                        Tcodc.Text = cli.Codec;
                        Tnomc.Text = cli.NomC;
                        Tadrc.Text = cli.adrc;
                    }
                }
            }
        }

        private void Tnomc_KeyUp(object sender, KeyEventArgs e)
        {
            Boolean passage = true;
            if (cli != null)
            {
                if (cli.Comptant)
                {
                    passage = false;
                }
            }
            if (e.KeyData != Keys.Enter && passage)
            {
                if (Tnomc.Text != "")
                {
                    rechcli rcli = new rechcli("client", null, Tnomc.Text);
                    rcli.ShowDialog();
                    if (rcli.valider)
                    {
                        cli = new MetierClient(rcli.code);
                        MVent.cli = cli;
                        change = true;
                        dgv_fact.Enabled = true;
                        foreach (DataGridViewRow dr in dgv_fact.Rows)
                        {
                            if (dr.Cells["numlist"].Value != null && dr.Cells["numcpl"].Value == null)
                            {
                                int index = int.Parse(dr.Cells["numlist"].Value + "");
                                Liste_article[index].RemiseClient(cli);
                                Liste_article[index].Calcul();
                                MAJLigne(Liste_article[index], dr.Index);
                            }
                        }
                        if (cli.Comptant)
                        {
                            Tadrc.Focus();
                            Tadrc.ReadOnly = false;
                        }
                        else
                        {
                            if (cmbtypevente.Visible)
                                cmbtypevente.Focus();
                            else if (Tcodr.Visible)
                                Tcodr.Focus();
                            else dgv_fact.Focus();
                            Tadrc.ReadOnly = true;
                        }
                    }
                    if (cli != null)
                    {
                        Tcodc.Text = cli.Codec;
                        Tnomc.Text = cli.NomC;
                        Tadrc.Text = cli.adrc;
                    }
                }
            }
        }

        private void Tcodr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                if (Tcodr.Text != "")
                {
                    rechcli rcli = new rechcli("rep", Tcodr.Text, null);
                    rcli.ShowDialog();
                    if (rcli.valider)
                    {
                        rep = new MetierRep(rcli.code);
                        change = true;
                        MVent.rep = rep;
                        dgv_fact.Focus();
                    }
                    if (rep != null)
                    {
                        Tcodr.Text = rep.CodeR;
                        Tnomr.Text = rep.NomR;
                        Tadrr.Text = rep.AdrR;
                    }

                }
            }
        }

        private void Tnomr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                if (Tnomr.Text != "")
                {
                    rechcli rcli = new rechcli("rep", null, Tnomr.Text);
                    rcli.ShowDialog();
                    if (rcli.valider)
                    {
                        rep = new MetierRep(rcli.code);
                        change = true;
                        MVent.rep = rep;
                        dgv_fact.Focus();
                    }
                    if (rep != null)
                    {
                        Tcodr.Text = rep.CodeR;
                        Tnomr.Text = rep.NomR;
                        Tadrr.Text = rep.AdrR;
                    }
                }
            }
        }

        # endregion Fin Recherche Client & Répresentant

# region // Incrementation Numéro

        private void increment()
        {
            String req = "SELECT * FROM pnumste where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
            ds = met.recuperer_table(req, "pnumste");
            try
            {
                MVent.increment();
                NumFact = MVent.numFact;
                nfact.Text = NumFact;
                nfact.Select(nfact.Text.Length, 0);
            }
            catch { }
        }

# endregion // Incrementation

        private void datefact_ValueChanged(object sender, EventArgs e)
        {
            if (!act)
            {
                change = true;
            }
        }

        private void Tcom_TextChanged(object sender, EventArgs e)
        {
            if (!act)
            {
                change = true;
            }
        }

        private void ModelVente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

        private void ModelVente_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        buttonX4_Click(sender, e);
                    }
                    break;

                case Keys.F8:
                    {
                        if (buttonX3.Visible)
                            buttonX3_Click(sender, e);
                    }
                    break;

                case Keys.F10:
                    {
                        buttonX4_Click(sender, e);
                    }
                    break;

                case Keys.F2:
                    {
                        if (buttonX6.Visible)
                        buttonX6_Click(sender, e);
                    }
                    break;

                case Keys.F6:
                    {
                        if (buttonX7.Visible)
                            buttonX7_Click(sender, e);
                    }
                    break;

                case Keys.F9:
                    {
                        if (buttonX8.Visible)
                            buttonX8_Click(sender, e);
                    }
                    break;

                default:
                    // actions_sinon;
                    break;
            }
        }

        private void DesActiverVente()
        {
            buttonX3.Visible = false;
            buttonX4.Visible = false;
            buttonX5.Visible = false;
            buttonX6.Visible = true;
            buttonX7.Visible = true;
            buttonX9.Visible = true;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            dgv_fact.Enabled = false;

            //Réglement (Facture Seulement
            if (MVent.GetType().Name == "MetierFactureClient")
                buttonX8.Visible = true;
            else
                buttonX8.Visible = false;

        }
#region // Modification
        private void buttonX7_Click(object sender, EventArgs e)
        {
            if (MVent.GetType().Name == "MetierFactureClient")
            {
                string sqlfac = "Select montreg From eentc where codes = '" + Program.Societe + "' AND codee ='" + Program.Exercice + "' AND codem ='" + Program.Magasin + "'  AND num = '" + nfact.Text + "'";
                DataSet tmpf = met.recuperer_table(sqlfac);
                if (tmpf != null)
                {
                    if (tmpf.Tables.Count != 0)
                    {
                        if (tmpf.Tables[0].Rows.Count != 0)
                        {
                            double xmntreg = 0;

                            double.TryParse(tmpf.Tables[0].Rows[0]["montreg"] + "", out xmntreg);
                            if (xmntreg == 0)
                            {
                                buttonX3.Visible = true;
                                buttonX4.Visible = true;
                                buttonX5.Visible = true;
                                buttonX6.Visible = false;
                                buttonX7.Visible = false;
                                buttonX8.Visible = false;
                                buttonX9.Visible = false;
                                groupBox1.Enabled = true;
                                groupBox2.Enabled = true;
                                groupBox3.Enabled = true;
                                groupBox4.Enabled = true;
                                dgv_fact.Enabled = true;
                                ControlSauvegarde = false;
                                ISMODIF = true;
                                Model_Load(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Modification Impôssible !!! Facture Déja/Ou En Cours de Réglement");
                            }
                        }
                    }
                }
            }
            else
            {
                buttonX3.Visible = true;
                buttonX4.Visible = true;
                buttonX5.Visible = true;
                buttonX6.Visible = false;
                buttonX7.Visible = false;
                buttonX8.Visible = false;
                buttonX9.Visible = false;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
                dgv_fact.Enabled = true;
                ControlSauvegarde = false;
                ISMODIF = true;
                Model_Load(sender, e);
            }
        }
#endregion

#region // Impression
        private void buttonX6_Click(object sender, EventArgs e)
        {
            string sql = "Select value From parametre where param ='BonTicket'";
            DataSet tmp = met.recuperer_table(sql);
            if (tmp.Tables[0].Rows.Count != 0)
            {
                impbon = (string)tmp.Tables[0].Rows[0].ItemArray[0];
            }


            String ent = "", lent = "", numero = "", Nmvt = MVent.numFact, typedition = ""; ;
            object o = MVent.GetType();
            if (MVent.GetType().Name == "MetierLivraisonClient")
            {
                ent = "eentl";
                lent = "lentl";
                numero = "Bon de Livraison";
                typedition = "L";
            }
            else if (MVent.GetType().Name == "MetierFactureClientSansStock")
            {
                ent = "eentcs";
                lent = "lentcs";
                numero = "Facture";
                typedition = "F";
            }
            else if (MVent.GetType().Name == "MetierFactureClient")
            {
                ent = "eentc";
                lent = "lentc";
                numero = "Facture";
                typedition = "F";
            }
            else if (MVent.GetType().Name == "MetierBonClient")
            {
                ent = "eentcb";
                lent = "lentcb";
                numero = "Bon Comptoire";
                typedition = "B";
            }
            else if (MVent.GetType().Name == "MetierCommandeClient")
            {
                ent = "eentcc";
                lent = "lentcc";
                numero = "Bon de Commande";
                typedition = "C";
            }
            else if (MVent.GetType().Name == "MetierDevisClient")
            {
                ent = "eentd";
                lent = "lentd";
                numero = "Devis";
                typedition = "D";
            }
            else if (MVent.GetType().Name == "MetierAvoirClient")
            {
                ent = "eentvc";
                lent = "lentvc";
                numero = "Avoir";
                typedition = "D";
            }

            if (MVent.GetType().Name != "MetierBonClient")
            {
                impression form = new impression(ent, lent, Nmvt, numero, typedition);
                form.ShowDialog();
            }
            else if (MVent.GetType().Name == "MetierBonClient")
            {
                if (impbon == "Oui")
                {
                    //ds = new DataSet();
                    sql = "select * from exercice where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
                    met.recuperer_table(sql, ds, "exercice");

                    sql = "select * from ste where code='" + Program.Societe + "'";
                    met.recuperer_table(sql, ds, "ste");

                    sql = "SELECT * FROM entete  where codes='" + Program.Societe + "'";
                    met.recuperer_table(sql, ds, "entete");

                    sql = "select * from magasin where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code = '" + Program.Magasin + "'";
                    met.recuperer_table(sql, ds, "magasin");

                    sql = "select * from " + ent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num ='" + Nmvt + "'";
                    met.recuperer_table(sql, ds, "eentl");

                    sql = "select * from " + lent + " where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and num ='" + Nmvt + "'";
                    met.recuperer_table(sql, ds, "lentl");

                    sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  order by code";
                    met.recuperer_table(sql, ds, "client");

                    sql = "SELECT * FROM sarticle  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
                    met.recuperer_table(sql, ds, "sarticle");

                    sql = "SELECT * FROM gamme  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
                    met.recuperer_table(sql, ds, "gamme");

                    sql = "SELECT * FROM article WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' Order by code";
                    met.recuperer_table(sql, ds, "article");


                    commerciale.rptedit.Iticket ij = new commerciale.rptedit.Iticket();
                    ij.numero = numero;
                    ij.ds = ds;
                    ij.ShowDialog();
                }
                else
                {
                    impression form = new impression(ent, lent, Nmvt, numero, typedition);
                    form.ShowDialog();
                }

            }
            

        }
#endregion

#region // Reglement

        private void buttonX8_Click(object sender, EventArgs e)
        {
             string sqlfac = "Select montreg From eentc where codes = '" + Program.Societe + "' AND codee ='" + Program.Exercice + "' AND codem ='" + Program.Magasin + "'  AND num = '" + nfact.Text + "'";
             DataSet tmpf = met.recuperer_table(sqlfac);
             if (tmpf != null)
             {
                 if (tmpf.Tables.Count != 0)
                 {
                     if (tmpf.Tables[0].Rows.Count != 0)
                     {
                         double xmntreg = 0;

                         double.TryParse(tmpf.Tables[0].Rows[0]["montreg"] + "", out xmntreg);
                         if (xmntreg == 0)
                         {

                             if (cmbtypevente.Text == "COMPTANT")
                             {
                                 regfact form = new regfact();
                                 form.xnumfact = nfact.Text;
                                 Double.TryParse(textB6.Text, out form.xmntreg);
                                 form.mntreg.Text = textB6.Text;
                                 form.codec = Tcodc.Text;
                                 form.mntreg.Focus();
                                 form.ShowDialog();
                             }
                             else
                             {
                                 String msg = MessageBox.Show("Voulez Vous Régler", "Facture à Crédit", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                                 if (msg.Equals("Yes"))
                                 {
                                     regfact form = new regfact();
                                     form.xnumfact = nfact.Text;
                                     Double.TryParse(textB6.Text, out form.xmntreg);
                                     form.mntreg.Text = textB6.Text;
                                     form.codec = Tcodc.Text;
                                     form.mntreg.Focus();
                                     form.ShowDialog();
                                 }
                             }
                         }
                         else
                         {
                             MessageBox.Show("Facture Déja/Ou En Cours de Réglement. Si Partiel Aller Au Menu Finance ---> Réglement Client");
                         }
                     }
                 }
             }
        }
#endregion

#region //Fermer
        private void buttonX9_Click(object sender, EventArgs e)
        {
            if (MVent.GetType().Name == "MetierFactureClient")
            {
                string sqlfac = "Select montreg From eentc where codes = '" + Program.Societe + "' AND codee ='" + Program.Exercice + "' AND codem ='" + Program.Magasin + "'  AND num = '" + nfact.Text + "'";
                DataSet tmpf = met.recuperer_table(sqlfac);
                if (tmpf != null)
                {
                    if (tmpf.Tables.Count != 0)
                    {
                        if (tmpf.Tables[0].Rows.Count != 0)
                        {
                            double xmntreg = 0;

                            double.TryParse(tmpf.Tables[0].Rows[0]["montreg"] + "", out xmntreg);
                            if (xmntreg == 0)
                            {
                                if (cmbtypevente.Text == "COMPTANT")
                                {
                                    String msg = MessageBox.Show("Etes-vous sûr de Quitter Sans Réglement ", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                                    if (msg.Equals("Yes"))
                                    {
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    this.Close();
                                }
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                    }
                }
            }
            else
            {
                this.Close();
            }
        }
#endregion

    }
}
