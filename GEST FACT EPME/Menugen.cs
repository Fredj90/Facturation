using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EPME
{
    public partial class Menugen : Form
    {
        private int childFormNumber = 0;
        private metier met = Program.met;

        public Menugen()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void familleClientToolStripMenuItem_Click(object sender, EventArgs e)
        {

            param frm = new param();
            frm.table = "familleclient";
            frm.champs = "familleclient";
            frm.Text = "Famille Client";
            frm.MdiParent = this;
            frm.Show();
            this.buttonX7.Focus();

        }

        private void ficheClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client form = new Client();
            form.MdiParent = this;
            form.Show();
            this.buttonX7.Focus();

        }


        private void modalitéPaiementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modalite form = new modalite();
            form.MdiParent = this;
            form.Show();
            this.buttonX7.Focus();

        }

        private void familleArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //famille frm = new famille();
            param frm = new param();
            frm.table = "famillearticle";
            frm.champs = "famillearticle";
            frm.Text = "Famille Article";
            frm.MdiParent = this;
            frm.Show();
            this.buttonX7.Focus();

        }

        private void familleFournisseurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //famille frm = new famille();
            param frm = new param();
            frm.table = "famillefour";
            frm.champs = "famillefour";
            frm.Text = "Famille Fournisseur";
            frm.MdiParent = this;
            frm.Show();
            this.buttonX7.Focus();

        }

        private void ficheFournisseurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Four form = new Four();
            form.MdiParent = this;
            form.Show();
            this.buttonX7.Focus();

        }


        private void régionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.TFunction)
            {
                //famille frm = new famille();
                param frm = new param();
                frm.table = "region";
                frm.champs = "region";
                frm.Text = "Régions";
                frm.MdiParent = this;
                frm.Show();
                this.buttonX7.Focus();
            }

        }

        private void ficheArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.TFunction)
            {
                Article form = new Article();
                form.MdiParent = this;
                form.Show();
                this.buttonX7.Focus();
            }

        }
        private void ficheReprésentantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.TFunction)
            {
                Rep form = new Rep();
                form.MdiParent = this;
                form.Show();
                this.buttonX7.Focus();
            }

        }
        private void comptesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.TFunction)
            {
                compte form = new compte();
                form.MdiParent = this;
                form.Show();
                this.buttonX7.Focus();
                Program.TFunction = false;
            }
        }

        private void Menugen_Load(object sender, EventArgs e)
        {
            label1.Text = Program.LibSociete;
            label6.Text = Program.LibMagasin;
            label4.Text = Program.Exercice;
            label5.Text = Program.LibEnteteMagasin;

            this.Text = "GCOM V.2.0       [ Utilisateur:   " + Program.LibUser + "    (" + Program.TypUser + ") ]";

            if (Program.User == "00")
            {
                tVAToolStripMenuItem.Visible = true;
                toolStripSeparator20.Visible = true;
                purgeDonnéesToolStripMenuItem.Enabled = true;
            }

            if (Program.ISSaDmin)
            {
                etatStockToolStripMenuItem.Visible = true;
                valeurStockSociétéToolStripMenuItem.Visible = true;
                organisationStockSociétéToolStripMenuItem.Visible = true;
                toolStripSeparator40.Visible = true;
                toolStripSeparator25.Visible = true;
                sociétéToolStripMenuItem.Enabled = true;
                magasinToolStripMenuItem.Enabled = true;
                sauvegardeBasesDonnéesToolStripMenuItem.Enabled = true;
                restaurerBaseDonnéesToolStripMenuItem.Enabled = true;

            }

            if (Program.ISaDmin)
            {
                utilisateurToolStripMenuItem.Enabled = true;
                dépôtToolStripMenuItem.Enabled = true;
                numéroToolStripMenuItem.Enabled = true;
                numéroStéToolStripMenuItem.Enabled = true;
                organisationClientsToolStripMenuItem.Enabled = true;
                organisationFournisseurToolStripMenuItem.Enabled = true;
                organisationStockToolStripMenuItem.Enabled = true;
                paramètresToolStripMenuItem.Enabled = true;

            }

            if (Program.User == "00")
            {
                if (Program.ISDemo)
                {
                    demp form = new demp();
                    form.MdiParent = this;
                    form.Show();
                }
            }

            if (Program.ISDemo)
            {
                string sqlcount = "Select Count(id) FROM eentcb";
                int count = 0;
                DataSet ds = met.recuperer_table(sqlcount);
                if(ds!=null)
                    if(ds.Tables.Count!=0)
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            int.TryParse(ds.Tables[0].Rows[0].ItemArray[0] + "", out count);
                        }
                if (count > 30)
                    buttonItem8.Enabled = false;

                sqlcount = "Select Count(id) FROM eentl";
                 count = 0;
                 ds = met.recuperer_table(sqlcount);
                if (ds != null)
                    if (ds.Tables.Count != 0)
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            int.TryParse(ds.Tables[0].Rows[0].ItemArray[0] + "", out count);
                        }
                if (count > 30)
                    buttonItem1.Enabled = false;

                sqlcount = "Select Count(id) FROM eentc";
                count = 0;
                ds = met.recuperer_table(sqlcount);
                if (ds != null)
                    if (ds.Tables.Count != 0)
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            int.TryParse(ds.Tables[0].Rows[0].ItemArray[0] + "", out count);
                        }
                if (count > 30)
                {
                    buttonItem3.Enabled = false;
                    buttonItem7.Enabled = false;
                }

                sqlcount = "Select Count(id) FROM eentcc";
                count = 0;
                ds = met.recuperer_table(sqlcount);
                if (ds != null)
                    if (ds.Tables.Count != 0)
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            int.TryParse(ds.Tables[0].Rows[0].ItemArray[0] + "", out count);
                        }
                if (count > 30)
                    buttonItem2.Enabled = false;

                sqlcount = "Select Count(id) FROM eentcb";
                count = 0;
                ds = met.recuperer_table(sqlcount);
                if (ds != null)
                    if (ds.Tables.Count != 0)
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            int.TryParse(ds.Tables[0].Rows[0].ItemArray[0] + "", out count);
                        }
                if (count > 30)
                    buttonItem8.Enabled = false;

                sqlcount = "Select Count(id) FROM eente";
                count = 0;
                ds = met.recuperer_table(sqlcount);
                if (ds != null)
                    if (ds.Tables.Count != 0)
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            int.TryParse(ds.Tables[0].Rows[0].ItemArray[0] + "", out count);
                        }
                if (count > 30)
                    buttonItem4.Enabled = false;

                sqlcount = "Select Count(id) FROM eentf";
                count = 0;
                ds = met.recuperer_table(sqlcount);
                if (ds != null)
                    if (ds.Tables.Count != 0)
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            int.TryParse(ds.Tables[0].Rows[0].ItemArray[0] + "", out count);
                        }
                if (count > 30)
                {
                    buttonItem5.Enabled = false;
                    buttonItem6.Enabled = false;
                }


            }
        }

        private void numéroStéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnumste form = new pnumste();
            form.MdiParent = this;
            form.Show();

        }

        private void numéroToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Pnum form = new Pnum();
            form.MdiParent = this;
            form.Show();
        }


        private void testToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            bon1 form = new bon1();
            form.MdiParent = this;
            form.Show();

        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Factcli1 form = new Factcli1();
            form.MdiParent = this;
            form.Show();

        }

        private void factureFournisseurToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Factfour1 form = new Factfour1();
            form.MdiParent = this;
            form.Show();

        }

        private void livraisonClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            livcli1 form = new livcli1();
            form.MdiParent = this;
            form.Show();

        }
        private void avoirClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            avoirc form = new avoirc();
            form.MdiParent = this;
            form.Show();

        }
        private void commandeClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comandec form = new comandec();
            form.MdiParent = this;
            form.Show();

        }
        private void entréFournisseurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entfour1 form = new entfour1();
            form.MdiParent = this;
            form.Show();

        }
        private void avoirFournisseurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            avoirf form = new avoirf();
            form.MdiParent = this;
            form.Show();

        }


        private void devisClientToolStripMenuItem_Click(object sender, EventArgs e)
        {

            devcli1 form = new devcli1();
            form.MdiParent = this;
            form.Show();

        }

        private void sociétéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ste form = new ste();
            form.MdiParent = this;
            form.Show();

        }

        private void utilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {

            util form = new util();
            form.MdiParent = this;
            form.Show();

        }

        private void Menugen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void comandeFournisseurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comandef form = new comandef();
            form.MdiParent = this;
            form.Show();

        }

        private void valeurStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            valstock form = new valstock();
            form.MdiParent = this;
            form.Show();

        }

        private void etatStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stock form = new stock();
            form.MdiParent = this;
            form.Show();

        }

        private void balanceClientToolStripMenuItem_Click(object sender, EventArgs e)
        {

            balancec form = new balancec();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
        }

        private void balanceFournisseurToolStripMenuItem_Click(object sender, EventArgs e)
        {

            balancef form = new balancef();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();

        }

        private void balanceReprésentantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            balancer form = new balancer();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
        }

        private void purgeDonnéesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            purge form = new purge();
            form.MdiParent = this;
            form.Show();

        }

        private void organisationDonéesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            orgdonne form = new orgdonne();
            form.MdiParent = this;
            form.Show();

        }

        private void organisationStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orgstkmag form = new orgstkmag();
            form.MdiParent = this;
            form.Show();

        }

        private void organisationClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orgclient form = new orgclient();
            form.MdiParent = this;
            form.Show();
        }

        private void organisationFournisseurToolStripMenuItem_Click(object sender, EventArgs e)
        {

            orgfour form = new orgfour();
            form.MdiParent = this;
            form.Show();
        }

        private void magasinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            magasin form = new magasin();
            form.MdiParent = this;
            form.Show();

        }

        private void stockMagasinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stockmag form = new stockmag();
            form.MdiParent = this;
            form.Show();

        }

        private void rechercheArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recharticle form = new recharticle();
            form.MdiParent = this;
            form.Show();


        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (Program.TFunction)
            {
                recharticle form = new recharticle();
                form.MdiParent = this;
                form.Show();
                form.textBoxX1.Focus();
                Program.TFunction = false;

            }
        }

        # region // Bon comptoir

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (met.verif_invent())
            {

                ModelVente form = new ModelVente();
                form.MVent = new MetierBonClient();
                form.ControlStock = true;
                SizeF s = new SizeF(form.groupBox1.Size.Width + form.groupBox4.Size.Width + form.groupBox2.Size.Width, form.groupBox1.Size.Height);
                form.groupBox1.Size = s.ToSize();
                form.groupBox4.Visible = false;
                form.groupBox2.Visible = false;
                form.Tcom.Visible = false;
                form.ControlStock = true;
                form.LCOM.Visible = false;
                Point p = new Point(700, 19);
                form.ldate.Location = p;
                Point p1 = new Point(744, 15);
                form.datefact.Location = p1;
                form.Lnum.Text = "N° Bon";
                form.Show();

            }

        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            if (met.verif_invent())
            {
                ModelVente form = new ModelVente();
                form.MVent = new MetierBonClient();
                SizeF s = new SizeF(form.groupBox1.Size.Width + form.groupBox4.Size.Width + form.groupBox2.Size.Width, form.groupBox1.Size.Height);
                form.groupBox1.Size = s.ToSize();
                form.groupBox4.Visible = false;
                form.groupBox2.Visible = false;
                form.Tcom.Visible = false;
                form.ControlStock = true;
                form.LCOM.Visible = false;
                Point p = new Point(700, 19);
                form.ldate.Location = p;
                Point p1 = new Point(744, 15);
                form.datefact.Location = p1;
                form.Lnum.Text = "N° Bon";
                form.Show();
            }
        }
        #endregion // bon comptoir

        # region // Bon livraison
        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (met.verif_invent())
            {

                ModelVente form = new ModelVente();
                form.MVent = new MetierLivraisonClient();
                SizeF s = new SizeF(form.groupBox1.Size.Width + form.groupBox4.Size.Width, form.groupBox1.Size.Height);
                form.groupBox1.Size = s.ToSize();
                form.groupBox4.Visible = false;
                form.ControlStock = true;
                form.Lnum.Text = "N° livraison:";
                form.Show();

            }

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (met.verif_invent())
            {


                ModelVente form = new ModelVente();
                form.MVent = new MetierLivraisonClient();
                form.ControlStock = false;
                SizeF s = new SizeF(form.groupBox1.Size.Width + form.groupBox4.Size.Width, form.groupBox1.Size.Height);
                form.groupBox1.Size = s.ToSize();
                form.groupBox4.Visible = false;
                form.ControlStock = true;
                form.Lnum.Text = "N° livraison:";
                form.Show();

            }


        }
        #endregion // Bon livraison

        # region //  Facture D
        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (met.verif_invent())
            {

                ModelVente form = new ModelVente();
                form.MVent = new MetierFactureClient();
                form.ControlStock = true;
                form.Lnum.Text = "N° Facture:";
                form.Show();

            }

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (met.verif_invent())
            {

                ModelVente form = new ModelVente();
                form.MVent = new MetierFactureClient();
                form.ControlStock = true;
                form.Lnum.Text = "N° Facture:";
                form.Show();

            }

        }
        #endregion // Facture

        # region //  Facture Livr
        private void buttonX5_Click(object sender, EventArgs e)
        {
            factclibc form = new factclibc();
            form.Show();
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            factclibc form = new factclibc();
            form.Show();

        }
        #endregion // Facture Liv

        #region //Facture comptoir
        private void buttonX6_Click(object sender, EventArgs e)
        {
            facturecb form = new facturecb();
            form.Show();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            facturecb form = new facturecb();
            form.Show();
        }

        #endregion

        # region //Bon Entre
        private void buttonX7_Click(object sender, EventArgs e)
        {
            if (met.verif_invent())
            {

                ModelAchat form = new ModelAchat();
                form.MVent = new MetierEntrerFour();
                form.Lnum.Text = "N° Entré:";
                form.ControlPrix = false;
                form.Show();

            }


          

        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            if (met.verif_invent())
            {

                ModelAchat form = new ModelAchat();
                form.MVent = new MetierEntrerFour();
                form.Lnum.Text = "N° Entré:";
                form.ControlPrix = false;
                form.Show();

            }



        }
        # endregion

        # region //Fact Fournisseur
        private void buttonX8_Click(object sender, EventArgs e)
        {
            if (met.verif_invent())
            {
                ModelAchat form = new ModelAchat();
                form.MVent = new MetierFactureFour();
                form.Lnum.Text = "N° Facture:";
                form.Lent.Text = "N° Fact Four :";
                form.ControlPrix = false;
                form.Show();
            }


            
        }
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            if (met.verif_invent())
            {

                ModelAchat form = new ModelAchat();
                form.MVent = new MetierFactureFour();
                form.Lnum.Text = "N° Facture:";
                form.Lent.Text = "N° Fact Four :";
                form.ControlPrix = false;
                form.Show();

            }
          
        }

        #endregion

        #region // Fact Entre Fournisseur
        private void buttonX9_Click(object sender, EventArgs e)
        {
            factfourbl form = new factfourbl();
            form.Show();
        }
        private void buttonItem6_Click(object sender, EventArgs e)
        {
            factfourbl form = new factfourbl();
            form.Show();
        }

        #endregion

        private void dépôtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            depot form = new depot();
            form.MdiParent = this;
            form.Show();
            Program.TFunction = false;
        }

        private void relevéClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            relevec form = new relevec();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void devisClientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //devic form = new devic();
            journald form = new journald();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void etatsFournisseurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            relevef form = new relevef();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void venteFamilleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ventefam form = new ventefam();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void achatFamilleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            achatfam form = new achatfam();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void stockFamilleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stockfam form = new stockfam();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void valeurStockSociétéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            valstocks form = new valstocks();
            form.MdiParent = this;
            form.Show();
            Program.TFunction = false;
        }

        private void venteArticlePériodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            venteart form = new venteart();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void achatArticlePériodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            achatart form = new achatart();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            propos form = new propos();
            form.MdiParent = this;
            form.Show();
            Program.TFunction = false;
        }

        private void stockArticlePériodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stockart form = new stockart();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void journalCaisseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jrncaisse form = new jrncaisse();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void etatPaiementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.TFunction)
            {
                paiement form = new paiement();
                form.MdiParent = this;
                form.Show();
                form.dated.Focus();
                Program.TFunction = false;
            }
        }

        private void etatRéglementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.TFunction)
            {
                reglement form = new reglement();
                form.MdiParent = this;
                form.Show();
                form.dated.Focus();
                Program.TFunction = false;
            }
        }

        private void dépenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.TFunction)
            {
                depense form = new depense();
                form.MdiParent = this;
                form.Show();
                this.buttonX7.Focus();
                Program.TFunction = false;
            }
        }

        private void recettesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.TFunction)
            {
                recette form = new recette();
                form.MdiParent = this;
                form.Show();
                this.buttonX7.Focus();
                Program.TFunction = false;
            }
        }

        private void versementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.TFunction)
            {
                versement form = new versement();
                form.MdiParent = this;
                form.Show();
                this.buttonX7.Focus();
                Program.TFunction = false;
            }
        }

        private void réglementClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.TFunction)
            {
                reglementc form = new reglementc();
                form.MdiParent = this;
                form.Show();
                this.buttonX7.Focus();
                Program.TFunction = false;
            }
        }

        private void paiementFournisseursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.TFunction)
            {
                paiementc form = new paiementc();
                form.MdiParent = this;
                form.Show();
                this.buttonX7.Focus();
                Program.TFunction = false;
            }
        }

        private void journalVenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            journalv form = new journalv();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void blNonFacturésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blnfacture form = new blnfacture();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void journalBonsComptoirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bcnfacture form = new bcnfacture();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void journalFacturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            journalf form = new journalf();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void journalAvoirsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            journala form = new journala();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void journalAchatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            journalach form = new journalach();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void journalEntrésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            journale form = new journale();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void journalAvoirFournisseurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            journalaa form = new journalaa();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void journalFacturesFournisseursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            journalfa form = new journalfa();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void organisationStockSociétéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orgstk form = new orgstk();
            form.MdiParent = this;
            form.Show();
        }

        private void tVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tva form = new tva();
            form.MdiParent = this;
            form.Show();
        }

        private void paramètresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parametres form = new parametres();
            form.MdiParent = this;
            form.Show();
        }

        private void affectationRemiseClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tarif form = new tarif();
            form.MdiParent = this;
            form.Show();
        }

        private void sauvegardeBasesDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export_bd exp = new Export_bd();
            exp.ShowDialog();
        }

        private void restaurerBaseDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Import_bd exp = new Import_bd();
            exp.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            relevec form = new relevec();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            relevef form = new relevef();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            journalach form = new journalach();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            journalv form = new journalv();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            jrncaisse form = new jrncaisse();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            if (Program.TFunction)
            {
                jrncaisse form = new jrncaisse();
                form.MdiParent = this;
                form.Show();
                form.dated.Focus();
                Program.TFunction = false;

            }
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            sinvent form = new sinvent();
            form.Show();
        }
        private void buttonItem11_Click(object sender, EventArgs e)
        {
            cinvent form = new cinvent();
            form.Show();
        }


        private void entêteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            entete form = new entete();
            form.Show();
        }

        private void changerSociétéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changer form = new changer();
            form.MdiParent = this;
            form.Show();
        }

        private void journalComptableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            journalcomptable form = new journalcomptable();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;

        }

        private void journalAchatComptableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            journalcomptableach form = new journalcomptableach();
            form.MdiParent = this;
            form.Show();
            form.dated.Focus();
            Program.TFunction = false;
        }

        private void facturePerformatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Factclis1 form = new Factclis1();
            form.MdiParent = this;
            form.Show();
        }

             
       
       

    }
}
