using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
namespace EPME
{
    public partial class changer : Office2007Form
    {
        metier met = Program.met;
        public int wnbres = 0, wnbrep = 0, xs;
        public DateTime wdateprog;
        public int wpasseprog;
        public DateTime wdatejours = DateTime.Now;

        public changer()
        {
            InitializeComponent();
        }

        private void changer_Load(object sender, EventArgs e)
        {
            DataSet ds = met.recuperer_table("Select * From ste order by code", "ste");
            BindingSource bs = new BindingSource(ds, "ste");
            Soc.DisplayMember = "libelle";
            Soc.ValueMember = "code";
            ste.ValueMember = "libelle";
            ste.DisplayMember = "libelle";
            Exerc.DisplayMember = "libelle";
            Exerc.ValueMember = "codee";
            Soc.DataSource = bs;
            ste.DataSource = bs;


        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Soc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Soc.SelectedIndex != -1)
            {
                if (Exerc.DataSource != null) (Exerc.DataSource) = null;
                DataSet ds1 = met.recuperer_table("Select distinct * From magasin Where codes = '" + Soc.SelectedValue + "'", "magasin");
                BindingSource bs1 = new BindingSource(ds1, "magasin");
                magasin.DisplayMember = "libelle";
                magasin.ValueMember = "libelle";
                magasin.DataSource = bs1;

                DataSet dse = met.recuperer_table("SELECT e.* FROM `ste` s, exercice e  WHERE e.`codes`=s.`code` AND s.`code`='" + Soc.SelectedValue + "'", "exercice");
                BindingSource bs = new BindingSource(dse, "exercice");
                Exerc.DisplayMember = "libelle";
                Exerc.ValueMember = "code";
                Exerc.DataSource = bs;

            }
            else
            {
                (Exerc.DataSource) = null;
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (Soc.SelectedIndex != -1 && Exerc.SelectedIndex != -1)
            {

                Program.Societe = Soc.SelectedValue.ToString();
                Program.LibSociete = ste.SelectedValue.ToString();
                Program.ISFodec = (Boolean)(((DataSet)((BindingSource)Soc.DataSource).DataSource)).Tables[0].Rows[Soc.SelectedIndex]["fodec"];
                Program.Exercice = ((DataRowView)Exerc.SelectedValue).Row.ItemArray[2] + "";
                ((Menugen1)this.MdiParent).label1.Text = Program.LibSociete;
                ((Menugen1)this.MdiParent).label4.Text = Program.Exercice;
              
                this.Hide();
              

            }
            else
                MessageBox.Show("Veuillez Remplir Tous les champs");
        }

      

        private void PWD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Soc.Focus();
        }

        private void Exerc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonX2_Click(sender, e);
        }

        private void Soc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Exerc.Focus();

        }

        private void Mag_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }


    }
}
