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
    public partial class propos : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        DataSet ds;
        int index = 0;
        String path_img = "";
        Byte[] Image_stream;

        public propos()
        {
            InitializeComponent();
            buttonX1.Visible = true;
        }
        private void affiche()
        {

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
                { panel1.BackgroundImage = null; }
            }
            else
            { panel1.BackgroundImage = null; }
           
        }


        private void propos_Load(object sender, EventArgs e)
        {
            String req = "SELECT * FROM propos ";
            ds = met.recuperer_table(req, "propos");
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
            this.Close();
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

        private void propos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

    }
}
