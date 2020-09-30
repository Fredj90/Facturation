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
    public partial class purge : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        DataSet ds;

        public purge()
        {
            InitializeComponent();
            buttonX1.Visible = false;
        }

        private void purge_Load(object sender, EventArgs e)
        {
            string req = "Select * from Nomtable";
            ds = met.recuperer_table(req, "Nomtable");

            checkedListBox1.Items.Clear();
            foreach (DataRow dr in ds.Tables["Nomtable"].Rows)
            {
                checkedListBox1.Items.Add(dr.Field<object>("libelle"));
            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            String msg = MessageBox.Show("Ete-vous sur","Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (msg.Equals("Yes"))
            {
                progressBarX1.Maximum = checkedListBox1.CheckedIndices.Count;
                progressBarX1.Value = 0;
                progressBarX1.Visible = true;
                foreach (int i in checkedListBox1.CheckedIndices)
                {
                    String table = ds.Tables["Nomtable"].Rows[i].Field<string>("nom");
                    String sql = "Delete From "+ table + " where codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "'";
                    met.Execute(sql);
                    progressBarX1.Value++;
                }
                progressBarX1.Visible = false;
                MessageBox.Show("suppression avec succée");
            }

        }

              
     
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if ((checkedListBox1.CheckedIndices.Count != 1) || (checkedListBox1.CheckedIndices.Count == 0 && e.NewValue == CheckState.Checked))
            buttonX1.Visible = true;
            else if (checkedListBox1.CheckedIndices.Count == 1 && e.NewValue == CheckState.Unchecked)
                buttonX1.Visible = false;
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }

            buttonX1.Visible = true;
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            buttonX1.Visible = false;
        }

        private void purge_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

       
     }
}
