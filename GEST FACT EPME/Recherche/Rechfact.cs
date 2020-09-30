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
    public partial class Rechfact : DevComponents.DotNetBar.Office2007Form
    {
        metier met = Program.met;
        DataSet ds;
        public string code="0";
        public string table;

        public Rechfact()
        {
            InitializeComponent();
          
            listBox1.Visible = false;
        }


        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxX2.Text.Trim() != "")
            {
              

                string sql = "select distinct ID,code,libelle from " + table + " where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code like '%" + textBoxX2.Text + "%'";
                ds = met.recuperer_table(sql, table);
                listBox1.Items.Clear();
                foreach (DataRow dr in ds.Tables[table].Rows)
                {
                    listBox1.Items.Add(dr["libelle"]);
                }
                if (listBox1.Items.Count != 0)
                {
                    listBox1.SelectedIndex = 0;
                    listBox1.Visible = true;
                }
                else
                {
                    listBox1.Visible = false;
                    
                }
            }
        }
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxX1.Text.Trim() != "")
            {
               

                string sql = "select distinct ID,code,libelle from " + table + " where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and libelle like '%" + textBoxX1.Text + "%'";
                ds = met.recuperer_table(sql, table);
                listBox1.Items.Clear();
                foreach (DataRow dr in ds.Tables[table].Rows)
                {
                    listBox1.Items.Add(dr["libelle"]);
                }
                if (listBox1.Items.Count != 0)
                {
                    listBox1.SelectedIndex = 0;
                    listBox1.Visible = true;
                }
                else
                {
                    listBox1.Visible = false;
                  
                }
            }

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                code = ds.Tables[table].Rows[listBox1.SelectedIndex].Field<string>("code");
                this.Close();
            }
        }

      

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox1.Focus();
        }


        private void textBoxX2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox1.Focus();
        }

        private void Rechfact_Load(object sender, EventArgs e)
        {

        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {
            if (textBoxX3.Text.Trim() != "")
            {
                buttonX2.Visible = true;
                textBoxX2.Visible = false;
                textBoxX1.Visible = false;
                dateTimeInput1.Visible = false;
                dateTimeInput2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
            }
            else
            {
                buttonX2.Visible = false;
                textBoxX2.Visible = true;
                textBoxX1.Visible = true;
                dateTimeInput1.Visible = true;
                dateTimeInput2.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
 
            }
        }

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
            buttonX1.Visible = true;
        }

       

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxX3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                this.Close();
        }

        private void textBoxX2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox1.Focus();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                listBox1_DoubleClick(sender, e);
        }

        private void dateTimeInput1_Click(object sender, EventArgs e)
        {

        }

           

       
    }
}
