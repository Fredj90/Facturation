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
    public partial class Rechart : DevComponents.DotNetBar.Office2007Form
    {
        metier met = Program.met;
        DataSet ds;
        public int code;
        public string table;
        public string list;

        public Rechart()
        {
            InitializeComponent();
            buttonX6.Visible = false;
            listBox1.Visible = false;
            list = "";
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
            if (listBox1.SelectedIndex != -1 || listBox2.SelectedIndex != -1 || listBox3.SelectedIndex != -1)
            {
                if (list == "1")
                {
                    code = ds.Tables[table].Rows[listBox1.SelectedIndex].Field<int>("ID");
                }
                else
                    if (list == "2")
                    {
                        code = ds.Tables[table].Rows[listBox2.SelectedIndex].Field<int>("ID");
                    }
                    else
                        code = ds.Tables[table].Rows[listBox3.SelectedIndex].Field<int>("ID");

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

        private void textBoxX3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox1.Focus();
        }

        private void textBoxX4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox1.Focus();
        } 
        private void textBoxX2_TextChanged_1(object sender, EventArgs e)
        {
            if (textBoxX2.Text.Trim() != "")
            {
                buttonX6.Visible = true;
                list = "1";

                string sql = "select distinct ID,code,libelle from " + table + " where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code like '%" + textBoxX2.Text + "%' and libelle like '%" + textBoxX1.Text + "%' and codeo like '%" + textBoxX3.Text + "%' and marque like '%" + textBoxX4.Text + "%'";
                ds = met.recuperer_table(sql, table);
                listBox1.Items.Clear();
                foreach (DataRow dr in ds.Tables[table].Rows)
                {
                    listBox1.Items.Add(dr["code"] + " " + dr["libelle"]);
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
                    list = "";
                }
            }
        }

        private void textBoxX1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBoxX1.Text.Trim() != "")
            {
                buttonX6.Visible = true;
                list = "1";
                string sql = "select distinct ID,code,libelle from " + table + " where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code like '%" + textBoxX2.Text + "%' and libelle like '%" + textBoxX1.Text + "%' and codeo like '%" + textBoxX3.Text + "%' and marque like '%" + textBoxX4.Text + "%'";
                ds = met.recuperer_table(sql, table);
                listBox1.Items.Clear();
                foreach (DataRow dr in ds.Tables[table].Rows)
                {
                    listBox1.Items.Add(dr["code"] + " " + dr["libelle"]);
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
                    list = "";
                }
            }

        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {
            if (textBoxX3.Text.Trim() != "")
            {
                buttonX6.Visible = true;
                list = "1";

                string sql = "select distinct ID,code,libelle,codeo,marque from " + table + " where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and  code like '%" + textBoxX2.Text + "%' and libelle like '%" + textBoxX1.Text + "%' and codeo like '%" + textBoxX3.Text + "%' and marque like '%" + textBoxX4.Text + "%'";
                ds = met.recuperer_table(sql, table);
                listBox1.Items.Clear();
                foreach (DataRow dr in ds.Tables[table].Rows)
                {
                    listBox1.Items.Add(dr["code"] + " " + dr["libelle"]);
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
                    list = "";
                }
            }
        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
            if (textBoxX4.Text.Trim() != "")
            {
                buttonX6.Visible = true;
                list = "1";

                string sql = "select distinct ID,code,libelle,codeo,marque from " + table + " where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and  code like '%" + textBoxX2.Text + "%' and libelle like '%" + textBoxX1.Text + "%' and codeo like '%" + textBoxX3.Text + "%' and marque like '%" + textBoxX4.Text + "%'";
                ds = met.recuperer_table(sql, table);
                listBox1.Items.Clear();
                foreach (DataRow dr in ds.Tables[table].Rows)
                {
                    listBox1.Items.Add(dr["code"] + " " + dr["libelle"]);
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
                    list = "";
                }
            }
        }

        private void Rechart_Load(object sender, EventArgs e)
        {
            //Program.desTfunction(this);
        }

        private void textBoxX7_TextChanged(object sender, EventArgs e)
        {
            if (textBoxX7.Text.Trim() != "")
            {
                buttonX6.Visible = true;
                list = "2";

                string sql = "select distinct ID,code,libelle from " + table + "  where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code like '%" + textBoxX7.Text + "%' and libelle like '%" + textBoxX5.Text + "%'";
                ds = met.recuperer_table(sql, table);
                listBox2.Items.Clear();
                foreach (DataRow dr in ds.Tables[table].Rows)
                {
                    listBox2.Items.Add(dr["code"] + " " + dr["libelle"]);
                }
                if (listBox2.Items.Count != 0)
                {
                    listBox2.SelectedIndex = 0;
                    listBox2.Visible = true;
                  
                }
                else
                {
                    listBox2.Visible = false;
                    buttonX6.Visible = false;
                    list = "";
                }
            }
        }

        private void textBoxX5_TextChanged(object sender, EventArgs e)
        {
            if (textBoxX5.Text.Trim() != "")
            {
                buttonX6.Visible = true;
                list = "2";

                string sql = "select distinct ID,code,libelle from " + table + " where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code like '%" + textBoxX7.Text + "%' and libelle like '%" + textBoxX5.Text + "%'";
                ds = met.recuperer_table(sql, table);
                listBox2.Items.Clear();
                foreach (DataRow dr in ds.Tables[table].Rows)
                {
                    listBox2.Items.Add(dr["code"] + " " +dr["libelle"]);
                }
                if (listBox2.Items.Count != 0)
                {
                    listBox2.SelectedIndex = 0;
                    listBox2.Visible = true;
                 
                }
                else
                {
                    listBox2.Visible = false;
                    buttonX6.Visible = false;
                     list="";
                }
            }
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                code = ds.Tables[table].Rows[listBox2.SelectedIndex].Field<int>("ID");
                this.Close();
            }
        }

        private void textBoxX7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox2.Focus();
        }

        private void textBoxX5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                listBox2.Focus();
        }

        private void textBoxX9_TextChanged(object sender, EventArgs e)
        {
            if (textBoxX9.Text.Trim() != "")
            {
                buttonX6.Visible = true;
                list = "3";

                string sql = "select distinct ID,code,libelle,dext,dint,haut from " + table + " where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and dext like '%" + textBoxX9.Text + "%' and dint like '%" + textBoxX10.Text + "%' and haut like '%" + textBoxX8.Text + "%'";
                ds = met.recuperer_table(sql, table);
                listBox3.Items.Clear();
                foreach (DataRow dr in ds.Tables[table].Rows)
                {
                    listBox3.Items.Add(dr["code"] + " " + dr["libelle"]+" D.EXT: "+dr["dext"]+" D.Int: "+dr["dint"]+" Haut: "+dr["haut"]);
                }
                if (listBox3.Items.Count != 0)
                {
                    listBox3.SelectedIndex = 0;
                    listBox3.Visible = true;

                }
                else
                {
                    listBox3.Visible = false;
                    buttonX6.Visible = false;
                    list = "";
                }
            }
        }

        private void textBoxX10_TextChanged(object sender, EventArgs e)
        {
            if (textBoxX10.Text.Trim() != "")
            {
                buttonX6.Visible = true;
                list = "3";

                string sql = "select distinct ID,code,libelle,dext,dint,haut from " + table + " where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and dext like '%" + textBoxX9.Text + "%' and dint like '%" + textBoxX10.Text + "%' and haut like '%" + textBoxX8.Text + "%'";
                ds = met.recuperer_table(sql, table);
                listBox3.Items.Clear();
                foreach (DataRow dr in ds.Tables[table].Rows)
                {
                    listBox3.Items.Add(dr["code"] + " " + dr["libelle"] + " D.Ext: " + dr["dext"] + " D.Int :" + dr["dint"] + " Haut :" + dr["haut"]);
                }
                if (listBox3.Items.Count != 0)
                {
                    listBox3.SelectedIndex = 0;
                    listBox3.Visible = true;

                }
                else
                {
                    listBox3.Visible = false;
                    buttonX6.Visible = false;
                    list = "";
                }
            }
        }

        private void textBoxX8_TextChanged(object sender, EventArgs e)
        {
            if (textBoxX8.Text.Trim() != "")
            {
                buttonX6.Visible = true;
                list = "3";

                string sql = "select distinct ID,code,libelle,dext,dint,haut from " + table + " where codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and dext like '%" + textBoxX9.Text + "%' and dint like '%" + textBoxX10.Text + "%' and haut like '%" + textBoxX8.Text + "%'";
                ds = met.recuperer_table(sql, table);
                listBox3.Items.Clear();
                foreach (DataRow dr in ds.Tables[table].Rows)
                {
                    listBox3.Items.Add(dr["code"] + " " + dr["libelle"] + " D.Ext: " + dr["dext"] + " D.Int: " + dr["dint"] + " Haut: " + dr["haut"]);
                }
                if (listBox3.Items.Count != 0)
                {
                    listBox3.SelectedIndex = 0;
                    listBox3.Visible = true;

                }
                else
                {
                    listBox3.Visible = false;
                    buttonX6.Visible = false;
                    list = "";
                }
            }
        }

        private void listBox3_DoubleClick(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex != -1)
            {
                code = ds.Tables[table].Rows[listBox3.SelectedIndex].Field<int>("ID");
                this.Close();
            }
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                listBox2_DoubleClick(sender, e);
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                listBox1_DoubleClick(sender, e);
        }

        private void listBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                listBox3_DoubleClick(sender, e);
        }

        private void Rechart_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Program.desfunctionf(this);
        }

        private void Rechart_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {


                case Keys.Escape:
                    {
                        String msg = MessageBox.Show("Ete-vous sur", "Sortir", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                        if (msg.Equals("Yes"))
                        {
                            this.Close();
                        }
                        break;
                    }
                   
               
                case Keys.F1:
                    {
                        superTabControl1.SelectedTab = superTabItem2;
                        textBoxX7.Focus();
                    }
                    break;

                case Keys.F2:
                    {
                        superTabControl1.SelectedTab = superTabItem3;
                        textBoxX9.Focus();
                    }
                    break;

                case Keys.F3:
                    {
                        superTabControl1.SelectedTab = superTabItem1;
                        textBoxX2.Focus();
                    }
                    break;

               
                  
            }
        }

       
    }
    
}
