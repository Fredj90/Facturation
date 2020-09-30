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
    public partial class Menugen1 : DevComponents.DotNetBar.Office2007RibbonForm
    {
        private int childFormNumber = 0;
        private metier met = Program.met;

        public Menugen1()
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

        }

    

        private void ficheClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client form = new Client();
            form.MdiParent = this;
            form.Show();
            this.buttonX7.Focus();

        }



      

        private void ficheFournisseurToolStripMenuItem_Click(object sender, EventArgs e)
        {

            EPME.Facture.Factcli1 fc = new Facture.Factcli1();
            fc.MdiParent = this;
            fc.Show();

        }


      


        private void Menugen_Load(object sender, EventArgs e)
        {
            label1.Text = Program.LibSociete;
            label4.Text = Program.Exercice;

            this.Text = "GFACT/EPME V.1.0       [ Utilisateur:   " + Program.LibUser + "    (" + Program.TypUser + ") ]";

            if (Program.User == "00")
            {
                tVAToolStripMenuItem.Visible = true;
                toolStripSeparator20.Visible = true;
                purgeDonnéesToolStripMenuItem.Enabled = true;
            }

            if (Program.ISSaDmin)
            {
                sociétéToolStripMenuItem.Enabled = true;
                sauvegardeBasesDonnéesToolStripMenuItem.Enabled = true;
                restaurerBaseDonnéesToolStripMenuItem.Enabled = true;

            }

            if (Program.ISaDmin)
            {
                utilisateurToolStripMenuItem.Enabled = true;
                numéroStéToolStripMenuItem.Enabled = true;
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

                sqlcount = "Select Count(id) FROM eentl";
                 count = 0;
                 ds = met.recuperer_table(sqlcount);
                if (ds != null)
                    if (ds.Tables.Count != 0)
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            int.TryParse(ds.Tables[0].Rows[0].ItemArray[0] + "", out count);
                        }

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

                sqlcount = "Select Count(id) FROM eentcb";
                count = 0;
                ds = met.recuperer_table(sqlcount);
                if (ds != null)
                    if (ds.Tables.Count != 0)
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            int.TryParse(ds.Tables[0].Rows[0].ItemArray[0] + "", out count);
                        }
                

                sqlcount = "Select Count(id) FROM eente";
                count = 0;
                ds = met.recuperer_table(sqlcount);
                if (ds != null)
                    if (ds.Tables.Count != 0)
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            int.TryParse(ds.Tables[0].Rows[0].ItemArray[0] + "", out count);
                        }
                

                sqlcount = "Select Count(id) FROM eentf";
                count = 0;
                ds = met.recuperer_table(sqlcount);
                if (ds != null)
                    if (ds.Tables.Count != 0)
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            int.TryParse(ds.Tables[0].Rows[0].ItemArray[0] + "", out count);
                        }
               


            }
        }

        private void Menugen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Contract contract = new Contract();
            contract.MdiParent = this;
            contract.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            EPME.Facture.Factcli1 fc = new Facture.Factcli1();
            fc.MdiParent = this;
            fc.Show();
        }

        private void sociétéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ste st = new ste();
            st.MdiParent=this;
            st.Show();
        }

        private void affectationRemiseClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contract contract = new Contract();
            contract.MdiParent = this;
            contract.Show();
        }

        private void sUIVIECONTRATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Etat_Contra frm = new Etat_Contra();
            frm.MdiParent = this;
            frm.Show();
        }

        private void entêteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entete ent = new entete();
            ent.MdiParent = this;
            ent.Show();
        }

        private void utilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util usr = new util();
            usr.MdiParent = this;
            usr.Show();
        }

        private void numéroStéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnumste usr = new pnumste();
            usr.MdiParent = this;
            usr.Show();
        }

        private void paramètresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            param usr = new param();
            usr.MdiParent = this;
            usr.Show();
        }

        private void changerSociétéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changer usr = new changer();
            usr.MdiParent = this;
            usr.Show();
        }

        private void sauvegardeBasesDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export_bd exp = new Export_bd();
            exp.MdiParent = this;
            exp.Show();
        }

        private void restaurerBaseDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Import_bd imp = new Import_bd();
            imp.MdiParent = this;
            imp.Show();
        }

        private void modeDePayementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modalite mod = new modalite();
            mod.MdiParent = this;
            mod.Show();
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    
      

             
       
       

    }
}
