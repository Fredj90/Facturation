using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EPME.fichier
{
    public partial class harticle : DevComponents.DotNetBar.Office2007Form
    {
        private metier met = Program.met;
        string codea = "";
        public harticle(string codea)
        {
            this.codea = codea;
            InitializeComponent();
        }

        private void harticle_Load(object sender, EventArgs e)
        {
            String sql = "select datem, prixht from articlehist where codes = '" + Program.Societe + "' and codee ='" + Program.Exercice + "' and codea = '" + codea + "'";
            DataSet ds = met.recuperer_table(sql);
            try
            {
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }

            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
