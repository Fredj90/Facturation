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
    public partial class demp : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        DateTime xdate = DateTime.Now;
               
        public demp()
        {
            InitializeComponent();
           
        }
       


        private void demp_Load(object sender, EventArgs e)
        {
            nbj.Focus();
        }


        private void buttonX9_Click(object sender, EventArgs e)
        {
            if (superValidator1.Validate())
            {
                DateTime datej = DateTime.Now;
                int Xnbj = 0;
                int.TryParse(nbj.Text, out Xnbj);
                xdate = datej.AddDays(Xnbj);
                String req = "Update propos Set imaged = '" + xdate.ToString("yyyy-MM-dd") + "', imagef = '21011966' ";
                met.Execute(req);
                MessageBox.Show("Redémarrer l'application SVP !");
                Application.Exit();
            }
        }

       

     

       

        

    }
}
