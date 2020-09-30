using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace commerciale
{
    public partial class impetatliv : System.Windows.Forms.Form
    {
        private metier met = Program.met;
        DataSet ds;
     
        public impetatliv()
        {
            InitializeComponent();
        }

        private void impetatliv_Load(object sender, EventArgs e)
        {
            string sql = "select * from client where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
            ds = met.recuperer_table(sql, "client");

            dated.Value = DateTime.Now;
            datef.Value = DateTime.Now;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            string date1 = dated.Value.ToString("yyyy-MM-dd");
            string date2 = datef.Value.ToString("yyyy-MM-dd");

            string sql = "select * from exercice where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'";
            met.recuperer_table(sql, ds, "exercice");

            sql = "select * from ste where code='" + Program.Societe + "'";
            met.recuperer_table(sql, ds, "ste");

            if (codec.Text != "")
            {
                sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code = '" + codec.Text + "' ";
                met.recuperer_table(sql, ds, "client");
            }
            else
            {
                sql = "select * from client where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
                met.recuperer_table(sql, ds, "client");
            }

            if (codec.Text != "")
            {

                sql = "select * from eentl where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codem = '" + Program.Magasin + "'  and codec ='" + codec.Text + " ' and (date>='" + date1 + "' AND date<='" + date2 + "') and facture=false order by num";
                met.recuperer_table(sql, ds, "eentl");

            }
            else
            {

                sql = "select * from eentl where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "'  and codem = '" + Program.Magasin + "'  and (date>='" + date1 + "' AND date<='" + date2 + "') and facture=false order by num";
                met.recuperer_table(sql, ds, "eentl");

            }

            sql = "select * from magasin where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code = '" + Program.Magasin + "'";
            met.recuperer_table(sql, ds, "magasin");

            if (codec.Text != "")
            {
                if (ds.Tables["eentl"].Rows.Count != 0)
                {
                    commerciale.rptclient.Ilivcli ijr = new commerciale.rptclient.Ilivcli();
                    if (!dated.Text.Equals("") && !datef.Text.Equals(""))
                        ijr.xperiode = "Du : " + dated.Text + " Au : " + datef.Text;
                    else
                        ijr.xperiode = "";

                    ijr.ds = ds;
                    ijr.ShowDialog();
                }
            }
            else if (codec.Text == "")
            {
                if (ds.Tables["eentl"].Rows.Count != 0)
                {
                    commerciale.rptclient.Ilivcliglob ijr = new commerciale.rptclient.Ilivcliglob();
                    if (!dated.Text.Equals("") && !datef.Text.Equals(""))
                        ijr.xperiode = "Du : " + dated.Text + " Au : " + datef.Text;
                    else
                        ijr.xperiode = "";

                    ijr.ds = ds;
                    ijr.ShowDialog();
                }
            }
        }

        private void dated_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                datef.Focus();
        }

        private void datef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                codec.Focus();
        }

        private void codec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                buttonX1.Focus();
        }

        private void codec_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                if (codec.Text != "")
                {
                    rechcli rcli = new rechcli("client", codec.Text, null);
                    rcli.ShowDialog();
                    codec.Text = rcli.code;
                    nomc.Text = rcli.libe;
                    buttonX1.Focus();
                }

            }
        }

        private void nomc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                if (nomc.Text != "")
                {
                    rechcli rcli = new rechcli("client", null, nomc.Text);
                    rcli.ShowDialog();
                    codec.Text = rcli.code;
                    nomc.Text = rcli.libe;
                    buttonX1.Focus();
                }
            }
        }

        private void impetatliv_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    String msg = MessageBox.Show("Ete-vous sur", "Sortir", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                    if (msg.Equals("Yes"))
                    {
                        this.Close();
                    }
                    break;


                case Keys.F2:
                    {
                        buttonX1_Click(sender, e);
                    }
                    break;

                default:
                    // actions_sinon;
                    break;
            }
        }
    }
}
