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
    public partial class parametres : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        DataSet ds;
        

        public parametres()
        {
            InitializeComponent();
            buttonX1.Visible = true;
        }
        private void affiche()
        {
            foreach (DataRow dr in ds.Tables["parametre"].Rows)
            {
                string xparam = dr.Field<string>("param");

                if (xparam.Equals("TauxMajoration"))
                    t1.Text = dr.Field<string>("value");
                else if (xparam.Equals("Timbre"))
                    t2.Text = dr.Field<string>("value");
                else if (xparam.Equals("Cumulqteclient"))
                    c1.Text = dr.Field<string>("value");
                else if (xparam.Equals("Cumulqtefour"))
                    c2.Text = dr.Field<string>("value");
                else if (xparam.Equals("CumulRemiseClient"))
                    c3.Text = dr.Field<string>("value");
                else if (xparam.Equals("BonTicket"))
                    c4.Text = dr.Field<string>("value");
                else if (xparam.Equals("RCB"))
                    c5.Text = dr.Field<string>("value");
                else if (xparam.Equals("RCL"))
                    c6.Text = dr.Field<string>("value");
                else if (xparam.Equals("RCF"))
                    c7.Text = dr.Field<string>("value");
                else if (xparam.Equals("RCA"))
                    c8.Text = dr.Field<string>("value");
                else if (xparam.Equals("RCR"))
                    c9.Text = dr.Field<string>("value");
                else if (xparam.Equals("RFL"))
                    c10.Text = dr.Field<string>("value");
                else if (xparam.Equals("RFF"))
                    c11.Text = dr.Field<string>("value");
                else if (xparam.Equals("RFA"))
                    c12.Text = dr.Field<string>("value");
                else if (xparam.Equals("RFR"))
                    c13.Text = dr.Field<string>("value");
               
                
            }
           

        }


        private void param_Load(object sender, EventArgs e)
        {
            String req = "SELECT * FROM parametre where codes='" + Program.Societe + "'";
            ds = met.recuperer_table(req, "parametre");
            if (ds != null)
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                       affiche();
                        buttonX1.Focus();

                    }

                }


        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (Program.ISSaDmin)
            {
                foreach (DataRow dr in ds.Tables["parametre"].Rows)
                {
                    string xparam = dr.Field<string>("param");

                    String req = "";
                    if (xparam.Equals("TauxMajoration"))
                        req = "Update parametre Set value = '" + t1.Text
                              + "' Where codes='" + Program.Societe + "' and param = '" + xparam + "' ";
                    else if (xparam.Equals("Timbre"))
                        req = "Update parametre Set value = '" + t2.Text
                             + "' Where codes='" + Program.Societe + "'  and param = '" + xparam + "' ";
                    else if (xparam.Equals("Cumulqteclient"))
                        req = "Update parametre Set value = '" + c1.SelectedItem
                              + "' Where codes='" + Program.Societe + "' and param = '" + xparam + "' ";
                    else if (xparam.Equals("Cumulqtefour"))
                        req = "Update parametre Set value = '" + c2.SelectedItem
                              + "' Where codes='" + Program.Societe + "' and param = '" + xparam + "' ";
                    else if (xparam.Equals("CumulRemiseClient"))
                        req = "Update parametre Set value = '" + c3.SelectedItem
                              + "' Where codes='" + Program.Societe + "' and param = '" + xparam + "' ";
                    else if (xparam.Equals("BonTicket"))
                        req = "Update parametre Set value = '" + c4.SelectedItem
                              + "' Where codes='" + Program.Societe + "' and param = '" + xparam + "' ";
                    else if (xparam.Equals("RCB"))
                        req = "Update parametre Set value = '" + c5.SelectedItem
                              + "' Where codes='" + Program.Societe + "' and param = '" + xparam + "' ";
                    else if (xparam.Equals("RCL"))
                        req = "Update parametre Set value = '" + c6.SelectedItem
                              + "' Where codes='" + Program.Societe + "' and param = '" + xparam + "' ";
                    else if (xparam.Equals("RCF"))
                        req = "Update parametre Set value = '" + c7.SelectedItem
                              + "' Where codes='" + Program.Societe + "' and param = '" + xparam + "' ";
                    else if (xparam.Equals("RCA"))
                        req = "Update parametre Set value = '" + c8.SelectedItem
                              + "' Where codes='" + Program.Societe + "' and param = '" + xparam + "' ";
                    else if (xparam.Equals("RCR"))
                        req = "Update parametre Set value = '" + c9.SelectedItem
                              + "' Where codes='" + Program.Societe + "' and param = '" + xparam + "' ";
                    else if (xparam.Equals("RFL"))
                        req = "Update parametre Set value = '" + c10.SelectedItem
                              + "' Where codes='" + Program.Societe + "' and param = '" + xparam + "' ";
                    else if (xparam.Equals("RFF"))
                        req = "Update parametre Set value = '" + c11.SelectedItem
                              + "' Where codes='" + Program.Societe + "' and param = '" + xparam + "' ";
                    else if (xparam.Equals("RFA"))
                        req = "Update parametre Set value = '" + c12.SelectedItem
                              + "' Where codes='" + Program.Societe + "' and param = '" + xparam + "' ";
                    else if (xparam.Equals("RFR"))
                        req = "Update parametre Set value = '" + c13.SelectedItem
                              + "' Where codes='" + Program.Societe + "' and param = '" + xparam + "' ";


                    met.Execute(req);
                }

                MessageBox.Show("Sauvegarde effectué");

                param_Load(sender, e);
                this.buttonX1.Focus();
            }
            else
            {
                MessageBox.Show("Accés Non Autorisé");
            }
        }

        
        
       
    }
}
