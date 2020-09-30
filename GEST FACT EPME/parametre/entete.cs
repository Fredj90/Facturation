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
    public partial class entete : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        DataSet ds;
        int index = 0;
        String path_img = "";
        Byte[] Image_stream;

        public entete()
        {
            InitializeComponent();
            buttonX1.Visible = true;
        }

        private void affiche()
        {


            t1.Text = ds.Tables[0].Rows[index].Field<Object>("ligne1") + " ";
            t2.Text = ds.Tables[0].Rows[index].Field<Object>("ligne2") + " ";
            t3.Text = ds.Tables[0].Rows[index].Field<Object>("ligne3") + " ";
            t4.Text = ds.Tables[0].Rows[index].Field<Object>("ligne4") + " ";
            t5.Text = ds.Tables[0].Rows[index].Field<Object>("ligne5") + " ";
            t6.Text = ds.Tables[0].Rows[index].Field<Object>("ligne6") + " ";
            t7.Text = ds.Tables[0].Rows[index].Field<Object>("ligne7") + " ";
            t8.Text = ds.Tables[0].Rows[index].Field<Object>("ligne8") + " ";

            if (ds.Tables[0].Rows[index].Field<Object>("image") != null)
            {
                if (!ds.Tables[0].Rows[index].Field<Object>("image").Equals(""))
                {

                    byte[] tmpbyte = (byte[])ds.Tables[0].Rows[index].Field<Object>("image");
                    System.IO.MemoryStream str1 = new System.IO.MemoryStream(tmpbyte);
                    Image img = Image.FromStream(str1);
                    Image_stream = tmpbyte;
                    panel1.BackgroundImage = img;
                    str1.Close();
                }
                else
                {
                    panel1.BackgroundImage = null;
                    Image_stream = new byte[0];
                }
            }
            else
            {
                panel1.BackgroundImage = null;
                Image_stream = new byte[0];
            }

        }


        private void entete_Load(object sender, EventArgs e)
        {
            String req = "SELECT * FROM entete where codes='" + Program.Societe + "'";
            ds = met.recuperer_table(req, "entete");
            if (ds != null)
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        index = ds.Tables[0].Rows.Count - 1;
                        affiche();
                        buttonX1.Focus();

                    }

                }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (Program.ISSaDmin)
            {
                String req = "Update entete Set ligne1 = '" + t1.Text
                            + "', ligne2 = '" + t2.Text
                            + "', ligne3 = '" + t3.Text
                            + "', ligne4 = '" + t4.Text
                            + "', ligne5 = '" + t5.Text
                            + "', ligne6 = '" + t6.Text
                            + "', ligne7 = '" + t7.Text
                            + "', ligne8 = '" + t8.Text
                            + "',image=@image"
                            + " Where ID = " + ds.Tables[0].Rows[index].ItemArray[0];

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(req, met.mycon);
                cmd.Parameters.Add("@image", MySql.Data.MySqlClient.MySqlDbType.LongBlob);
                cmd.Parameters["@image"].Size = Image_stream.Length;
                if (Image_stream.Length != 0)
                {
                    cmd.Parameters["@image"].Value = Image_stream;
                }
                else
                {
                    cmd.Parameters["@image"].Value = DBNull.Value;
                }
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sauvgarde effectué");

                entete_Load(sender, e);
                this.buttonX1.Focus();
            }
            else
            {
                MessageBox.Show("Accés Non Autorisé");
            }
        }

        private void entete_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Fichier Image|*.jpg;*.gif;*.png";

            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                path_img = openFileDialog1.SafeFileName;
                Image img = Image.FromFile(openFileDialog1.SafeFileName);
                System.IO.FileStream fs = new System.IO.FileStream(path_img, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                Image_stream = new Byte[fs.Length];
                fs.Read(Image_stream, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                panel1.BackgroundImage = img;

            }
            else
            {
                path_img = "";
                panel1.BackgroundImage = null;
                Image_stream = new byte[0];
            }
        }

       
       

    }
}
