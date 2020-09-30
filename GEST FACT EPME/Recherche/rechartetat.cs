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
    public partial class recha : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        DataSet ds;

        public string table = "";
        public string code = "";
        public string libe = "";
        public string focus = "";
        public int xlen;

         public recha(String table, string code, string libe)
        {
            if (code != null)
            {
                this.code = code;
                this.focus = "1";
            }
            if (libe != null)
            {
                this.libe = libe;
                this.focus = "2";
            }
            this.table = table;
            InitializeComponent();
        }

        private void recha_Load(object sender, EventArgs e)
        {
            Tcod.Text = code;
            Tlib.Text = libe;

            Program.desTfunction(this);

            if (focus == "2")
            {
                Tlib.TabIndex = 0;
                Tcod.TabIndex = 1;
                Tlib.Select(Tlib.Text.Length, 0);
            }
            else if (focus == "1")
            {
                Tcod.TabIndex = 0;
                Tlib.TabIndex = 1;
                Tcod.Select(Tcod.Text.Length, 0);
            }
        }

        private void Tcod_TextChanged(object sender, EventArgs e)
        {
           

            string req = "SELECT code,libelle FROM " + table + " where codes='" + Program.Societe + "' and  codee='" + Program.Exercice + "' and code like '%" + Tcod.Text + "%' and  libelle like '%" + Tlib.Text + "%'  order by code";
            ds = met.recuperer_table(req, table);
            if (ds != null)
            {
                dataGridViewX1.DataSource = ds.Tables[table].DefaultView;
               
            }
        }
        private void Tcod1_TextChanged(object sender, EventArgs e)
        {
           
            xlen = Tcod1.TextLength;
            string xchamp = Tcod1.Text.Substring(0, xlen);

            string req = "SELECT code,libelle,SUBSTR(code,1," + xlen.ToString() + ")  as code1 FROM " + table + "  where codes='" + Program.Societe + "' and  codee='" + Program.Exercice + "' and SUBSTR(code,1," + xlen.ToString() + ") = '" + Tcod1.Text + "'  order by code";

            ds = met.recuperer_table(req, table);
            if (ds != null)
            {
                dataGridViewX1.DataSource = ds.Tables[table].DefaultView;

            }
        }

        private void Tlib_TextChanged(object sender, EventArgs e)
        {
           
            string req = "SELECT code,libelle FROM " + table + "  where codes='" + Program.Societe + "' and  codee='" + Program.Exercice + "' and code like '%" + Tcod.Text + "%' and  libelle like '%" + Tlib.Text + "%'  order by code";

            ds = met.recuperer_table(req, table);
            if (ds != null)
            {
                dataGridViewX1.DataSource = ds.Tables[table].DefaultView;
             
            }
        }

        private void Tlib1_TextChanged(object sender, EventArgs e)
        {
          
            xlen = Tlib1.TextLength;
            string xchamp = Tlib1.Text.Substring(0, xlen);

            string req = "SELECT code,libelle,SUBSTR(libelle,1," + xlen.ToString() + ") as code1  FROM " + table + "  where codes='" + Program.Societe + "' and  codee='" + Program.Exercice + "' and SUBSTR(libelle,1," + xlen.ToString() + ") = '" + Tlib1.Text + "'  order by code";

            ds = met.recuperer_table(req, table);
            if (ds != null)
            {
                dataGridViewX1.DataSource = ds.Tables[table].DefaultView;

            }
        }

        private void dataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (dataGridViewX1.Rows.Count != 0)
                {
                    code = dataGridViewX1.CurrentRow.Cells["a0"].Value + "";
                    libe = dataGridViewX1.CurrentRow.Cells["a1"].Value + "";
                    this.Close();
                }

            }
        }

        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {

            if (dataGridViewX1.Rows.Count != 0)
            {
                code = dataGridViewX1.CurrentRow.Cells["a0"].Value + "";
                libe = dataGridViewX1.CurrentRow.Cells["a1"].Value + "";
                this.Close();
            }



        }

        private void Tcod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                dataGridViewX1.Focus();
            }
        }

        private void Tlib_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                dataGridViewX1.Focus();
            }
        }

       

        private void dataGridViewX1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            String lastnum = "";
            Boolean color = true;
            foreach (DataGridViewRow dgr in dataGridViewX1.Rows)
            {

                string xcode = dgr.Cells["a0"].Value + "";



                if (lastnum != xcode)
                {
                    color = !color;
                    lastnum = xcode;
                }


                if (color)
                {

                    dgr.Cells["a0"].Style.ForeColor = Color.Yellow;
                    dgr.Cells["a0"].Style.BackColor = Color.Blue;
                    dgr.Cells["a1"].Style.ForeColor = Color.Yellow;
                    dgr.Cells["a1"].Style.BackColor = Color.Blue;
                  


                }
                else
                {
                    dgr.Cells["a0"].Style.ForeColor = Color.Lime;
                    dgr.Cells["a0"].Style.BackColor = Color.MidnightBlue;
                    dgr.Cells["a1"].Style.ForeColor = Color.Lime;
                    dgr.Cells["a1"].Style.BackColor = Color.MidnightBlue;
                  


                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    

      
        


    }
}
