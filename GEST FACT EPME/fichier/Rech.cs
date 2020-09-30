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
    public partial class Rech : DevComponents.DotNetBar.Office2007Form
    {
        metier met = Program.met;
        DataSet ds;
        public int code;
        public string table;

        public Rech()
        {
            InitializeComponent();
            buttonX6.Visible = false;
            listBox1.Visible = false;
        }

     
        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxX2.Text.Trim() != "")
            {
                buttonX6.Visible = true;

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
                    buttonX6.Visible = false;
                }
            }
        }
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxX1.Text.Trim() != "")
            {
                buttonX6.Visible = true;

                string sql = "select distinct ID,code,libelle from " + table + " where  codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and libelle like '%" + textBoxX1.Text + "%'";
                ds = met.recuperer_table(sql,table);
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
                    buttonX6.Visible = false;
                }
            }

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                code = ds.Tables[table].Rows[listBox1.SelectedIndex].Field<int>("ID");
                this.Close();
            }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                code = ds.Tables[table].Rows[listBox1.SelectedIndex].Field<int>("ID");
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

        private void Rech_Load(object sender, EventArgs e)
        {
            //Program.desTfunction(this);
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                listBox1_DoubleClick(sender, e);
        }

        private void Rech_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Program.desfunctionf(this);
        }

             
    }
}
