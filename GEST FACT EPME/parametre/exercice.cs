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
    public partial class exercice : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        
        DataSet ds, ds1;
      
        public string xcodes = "";

       

        public exercice()
        {
            InitializeComponent();
        }

        private void exercice_Load(object sender, EventArgs e)
        {
           
             //string req = "select * from exercice where codes='"+Program .Societe+"'";
            string req = "select * from exercice where codes='" + xcodes + "' ";
            comboBoxEx1.DisplayMember = "codee";
            comboBoxEx1.ValueMember = "codee";
            BindingSource bs = new BindingSource(met.recuperer_table(req, "exercice"), "exercice");
            comboBoxEx1.DataSource = bs;
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
            if (Program.ISSaDmin)
            {
                String msg = MessageBox.Show("Voulez-Vous Créer Exercice ???", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (msg.Equals("Yes"))
                {
                    if (comboBoxEx1.Items.Count != 0)
                    {

                        string sql1 = "Select Codes,codee From exercice Where codes = '" + xcodes + "' and codee = '" + anne.SelectedItem + "' ";
                        DataSet verif = met.recuperer_table(sql1);

                        if (verif.Tables[0].Rows.Count == 0)
                        {

                            String req1 = "INSERT INTO exercice(codes,codee,libelle) Values ('" + xcodes
                            + "','" + anne.SelectedItem
                            + "','" + textBox10.Text
                            + "')";
                            if (met.Execute(req1))
                            {

                                progressBarX1.Maximum = 8;
                                progressBarX1.Value = 0;
                                progressBarX1.Visible = true;

                                // Table xxxxx
                                // Table yyyyy
                                
                                MessageBox.Show("Création Exercice Avec Succés");
                            }

                            String req12 = "SELECT * FROM exercice";
                            ds1 = met.recuperer_table(req12, "exercice");

                            String req13 = "SELECT * FROM ste";
                            ds = met.recuperer_table(req13, "ste");

                        }
                        else
                        {
                            MessageBox.Show("Exercice déja Existant");
                        }
                    }
                   

                } // fin message (yes/no)
            }
            else
            {
                MessageBox.Show("Accés Non Autorisé");
            }
        }


        private void buttonX12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
