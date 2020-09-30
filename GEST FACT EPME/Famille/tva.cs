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
    public partial class tva : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        int index = 0 , xindex =0;
        DataSet ds;
        Boolean modif = false;
        public tva()
        {
            InitializeComponent();
            toolStrip1.Visible = true;
            toolStrip2.Visible = false;
            toolStrip3.Visible = false;
             
        }


        private void affiche()
        {
            textBox1.Text = ds.Tables[0].Rows[index].ItemArray[1].ToString();
            textBox2.Text = ds.Tables[0].Rows[index].ItemArray[2].ToString();
            if ((Boolean)ds.Tables[0].Rows[index].ItemArray[3])
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
        }

      
        private void toolStripButton1_Click(object sender, EventArgs e) 

        {
            // Bouton créer
            xindex = index;
            toolStrip1.Visible = false;
            toolStrip3.Visible = false;
            toolStrip2.Visible = true;
            toolStrip2.Location = toolStrip1.Location;
            textBox1.Text = "";
            textBox2.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;

        }

        private void toolStripButton4_Click(object sender, EventArgs e) 
        {
            if (superValidator1.Validate())
            {
                // Bouton Sauver
                toolStrip1.Visible = true;
                toolStrip2.Visible = false;
                toolStrip3.Visible = false;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;

                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;

                if (!modif)
                {
                    // Mode création
                    //(Access) string S = "#"+dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year + "#";
                    //(Mysql) string S =  + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day + "-" + dateTimePicker1.Value.Year;
                    String req = "INSERT INTO tva(libelle, taux, actif) Values ('" + textBox1.Text + "', " + textBox2.Text + ", " + radioButton1.Checked + ")";
                    if (met.Execute(req))
                        MessageBox.Show("Sauvgarde effectué");
                    tva_Load(sender, e);
                }
                else
                {
                    // Mode Modification
                    String req = "Update tva Set Libelle = '" + textBox1.Text + "', taux = " + textBox2.Text + ", actif = " + radioButton1.Checked + " Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];
                    if (met.Execute(req))
                        MessageBox.Show("Sauvgarde effectué");
                    modif = false;
                    tva_Load(sender, e);
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            // Bouton Annuler Sauvegarde
            index = xindex;
            toolStrip1.Visible = true;
            toolStrip2.Visible = false;
            toolStrip3.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            affiche();
            superValidator1.ClearFailedValidations();
            modif = false;

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // Bouton supprimer
            toolStrip3.Location = toolStrip1.Location;
            toolStrip1.Visible = false;
            toolStrip2.Visible = false;
            toolStrip3.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            // Bouton Annuler Suppression
            toolStrip1.Visible = true;
            toolStrip2.Visible = false;
            toolStrip3.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            // Bouton Ok suppression
            toolStrip1.Visible = true;
            toolStrip2.Visible = false;
            toolStrip3.Visible = false;
             String msg = MessageBox.Show("Ete-vous sur","Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
             if (msg.Equals("Yes"))
             {
                 String req = "DELETE FROM tva Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];
                 if (met.Execute(req))
                     MessageBox.Show("Suppression effectuée");
             }
            tva_Load(sender,e);
            
        }

        private void tva_Load(object sender, EventArgs e)
        {
            Program.desTfunction(this);
            String req = "SELECT * FROM tva";
            ds = met.recuperer_table(req);
            if(ds!=null)
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        index = ds.Tables[0].Rows.Count - 1;
                        affiche();
                        
                    }
                    else
                    {
                        toolStripButton1_Click(sender, e);
                    }
                }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // Bouton Modifier
            xindex = index;
            toolStrip1.Visible = false;
            toolStrip3.Visible = false;
            toolStrip2.Visible = true;
            toolStrip2.Location = toolStrip1.Location;
            modif = true;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            textBox1.Focus() ;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index < ds.Tables[0].Rows.Count-1)
            {
                index++;
                affiche() ; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                affiche();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            index = ds.Tables[0].Rows.Count - 1;
            affiche(); 
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            index =0;
            affiche();
        }

        private void tva_KeyDown(object sender, KeyEventArgs e)
        {
            //////////////
            switch (e.KeyCode)
            {
                case  Keys.S:

                    if (index < ds.Tables[0].Rows.Count - 1)
                    {
                        index++;
                        affiche();
                    }
                     break;
                
                case Keys.Add :

                     if (index < ds.Tables[0].Rows.Count - 1)
                     {
                         index++;
                         affiche();
                     }
                     break;
               
                     
                case Keys.P:
                     {
                         if (index > 0)
                         {
                             index--;
                             affiche();
                         }
                     }
                     break;
               
                case Keys.Subtract :
                     {
                         if (index > 0)
                         {
                             index--;
                             affiche();
                         }
                     }
                     break;

             default:
                  // actions_sinon;
                   break;
             }
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox2.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                radioButton1.Focus();
        }

        private void radioButton1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox1.Focus();
        }

        private void radioButton2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                textBox1.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox1.Focus(); 
        }

        private void tva_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

        
          
      
                            
    }
}
