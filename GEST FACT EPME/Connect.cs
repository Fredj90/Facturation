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
    public partial class Connect : Office2007Form
    {
        metier met = Program.met;
        public int wnbres = 0, wnbrep = 0, xs;
        public DateTime wdateprog;
        public int wpasseprog;
        public DateTime wdatejours = DateTime.Now;

        
        
       public Connect()
        {
            InitializeComponent();
        }

        private void Connect_Load(object sender, EventArgs e)
        {
            DataSet ds = met.recuperer_table("Select * From ste order by code","ste");
            BindingSource bs = new BindingSource(ds, "ste");
            Soc.DisplayMember = "libelle";
            Soc.ValueMember = "code";
            Exerc.DisplayMember = "libelle";
            Exerc.ValueMember = "codee";
            Soc.DataSource = bs;

            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Soc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Soc.SelectedIndex != -1)
            {
                if (Exerc.DataSource!=null) (Exerc.DataSource)=null ;
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
            if (!Log.Text.Equals("") && !PWD.Text.Equals("") && Soc.SelectedIndex != -1 && Exerc.SelectedIndex != -1)
            {
                DataSet ds = met.recuperer_table("Select * From utilisateur Where libelle = '" + Log.Text + "' AND mp = '" + PWD.Text + "'", "utilisateur");
                if (ds.Tables["utilisateur"].Rows.Count != 0)
                {
                    Program.Societe = Soc.SelectedValue.ToString();
                    Program.Exercice = ((DataRowView)Exerc.SelectedValue).Row.ItemArray[2] + "";
                    Program.User = ds.Tables["utilisateur"].Rows[0].Field<String>("code");
                    Program.LibUser = ds.Tables["utilisateur"].Rows[0].Field<String>("libelle");
                    if (ds.Tables["utilisateur"].Rows[0].Field<String>("type").Equals("S"))
                    {
                        Program.ISSaDmin = true;
                        Program.ISaDmin = true;
                        Program.TypUser = "Super Administrateur";
                    }
                    if (ds.Tables["utilisateur"].Rows[0].Field<String>("type").Equals("A"))
                    {
                        Program.ISaDmin = true;
                        Program.TypUser = "Administrateur";
                    }
                    if (ds.Tables["utilisateur"].Rows[0].Field<String>("type").Equals("U"))
                    {
                       Program.TypUser = "Utilisateur";
                    }
                    /// Controle programme

                    String req = "SELECT * FROM propos";
                    DataSet ds2 = met.recuperer_table(req, "propos");
                    if (ds2 != null)
                    {
                        if (ds2.Tables.Count != 0)
                        {
                            if (ds2.Tables[0].Rows.Count != 0)
                            {
                                wdateprog = ds2.Tables[0].Rows[0].Field<DateTime>("imaged");
                            }
                        }
                    }

                    int wpasse = 850120156;
                    if (wdateprog < wdatejours)
                    {
                        String req1 = "Update propos Set imagef = " + wpasse + " ";
                        met.Execute(req1);
                    }


                    //String reqsp = "select * FROM propos ";
                    //DataSet dsprp = met.recuperer_table(reqsp, "propos");
                    //if (dsprp != null)
                    //{
                    //    if (dsprp.Tables.Count != 0)
                    //    {
                    //        wdateprog = dsprp.Tables[0].Rows[0].Field<DateTime>("imaged");
                    //        wpasseprog = dsprp.Tables[0].Rows[0].Field<int>("imagef");
                    //    }
                    //}


                    //if (wdateprog < wdatejours || wpasseprog != 21011966)
                    //{
                    //    Program.ISAret = true;
                    //    Program.ISDemo = true;
                    //}

                    ///

                    this.Hide();
                    Menugen1 mg = new Menugen1();
                    mg.Show();
                }
                else
                    MessageBox.Show("Verifier Votre Login et/ou Mot de passe");
            }
            else
                MessageBox.Show("Veillez Remplir Tous les champs");
        }

        private void Log_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PWD.Focus();
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

       

             
    }
}
