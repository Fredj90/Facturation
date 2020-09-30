using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Rendering;



namespace EPME
{
    public partial class orgstkmag : DevComponents.DotNetBar.Office2007Form
    {

        private metier met = Program.met;

        DataSet ds,ds4;
        public orgstkmag()
        {
            InitializeComponent();
            buttonX9.Visible = false;
        }

        private void orgstk_Load(object sender, EventArgs e)
        {
            string req3 = "select code,libelle from famillearticle where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' ";
            DataSet ds3 = met.recuperer_table(req3, "famillearticle");
            mygrid1.DataSource = ds3.Tables["famillearticle"].DefaultView;

           
            libelled.DisplayMember = "libelle";
            libelled.ValueMember = "code";

            string sql1 = "select * from depot where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem = '" + Program.Magasin + "'";
            DataSet dsa1 = met.recuperer_table(sql1, "depot");
            BindingSource bs1 = new BindingSource(dsa1, "depot");
            libelled.DataSource = bs1;
            libelled.DataPropertyName = "coded";


        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
          
            {


                buttonX2.Visible = true;
                buttonX1.Visible = false;
                buttonX3.Visible = true;
                buttonX4.Visible = false;
                buttonX9.Visible = true;
                string req4 = "select code,libelle,ID from article where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' ";
                string tmp = " and (";
                Boolean f = true;
                foreach (DataGridViewRow dr in mygrid1.Rows)
                {
                    if (!f)
                        tmp += " or ";
                    dr.Cells[0].Value = true;

                    tmp += "codef = '" + dr.Cells[1].Value + "'";
                    f = false;
                }
                tmp += ")";
                req4 += tmp;
                ds4 = met.recuperer_table(req4, "article");
                mygrid2.DataSource = ds4.Tables["article"].DefaultView;
            }
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            buttonX1.Visible = true;
            buttonX2.Visible = false;
            buttonX3.Visible = false;
            buttonX4.Visible = false;
            buttonX9.Visible = false;
            foreach (DataGridViewRow dr in mygrid1.Rows)
            {

                dr.Cells[0].Value = false;

            }
            //
            buttonX4_Click(sender, e);
            try
            {
                ((DataView)mygrid2.DataSource).Table.Clear();
            }
            catch { }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            buttonX3.Visible = true;
            buttonX4.Visible = false;

            foreach (DataGridViewRow dr in mygrid2.Rows)
            {

                dr.Cells[0].Value = false;

            }
            groupBox1.Visible = false;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (mygrid2.RowCount != 0)
            {
                buttonX3.Visible = false;
                buttonX4.Visible = true;
                foreach (DataGridViewRow dr in mygrid2.Rows)
                {

                    dr.Cells[0].Value = true;

                }
                groupBox1.Visible = true;
            }
            else
                groupBox1.Visible = false;
        }

        private void orgstk_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.desfunctionf(this);
        }

        private void mygrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            {

                if (mygrid1.CurrentCell.ColumnIndex == 0)
                    if (mygrid1.CurrentCell.Value != null)
                        mygrid1.CurrentCell.Value = !(Boolean)mygrid1.CurrentCell.Value;
                    else
                        mygrid1.CurrentCell.Value = true;
                buttonX3.Visible = true;
                buttonX4.Visible = false;
                groupBox1.Visible = false;

                string req4 = "select code,libelle,ID from article where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "'";
                string tmp = " and (";
                Boolean f = true;
                foreach (DataGridViewRow dr in mygrid1.Rows)
                {
                    if (dr.Cells[0].Value != null)
                        if ((Boolean)dr.Cells[0].Value)
                        {
                            if (!f)
                                tmp += " or ";
                            tmp += "codef = '" + dr.Cells[1].Value + "'";
                            f = false;
                        }
                }
                tmp += ")";
                req4 += tmp;
                if (!f)
                {
                    ds4 = met.recuperer_table(req4, "article");
                    mygrid2.DataSource = ds4.Tables["article"].DefaultView;
                }
                else
                {
                    buttonX3.Visible = false;
                    buttonX4.Visible = false;
                    try
                    {
                        ((DataView)mygrid2.DataSource).Table.Clear();
                    }
                    catch { }
                }
            }
           
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void mygrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mygrid2.CurrentCell.ColumnIndex == 0)
                if (mygrid2.CurrentCell.Value != null)
                    mygrid2.CurrentCell.Value = !(Boolean)mygrid2.CurrentCell.Value;
                else
                    mygrid2.CurrentCell.Value = true;
            Boolean f = false;
            foreach (DataGridViewRow dr in mygrid2.Rows)
            {
                if (dr.Cells[0].Value != null)
                    if ((Boolean)dr.Cells[0].Value)
                    {

                        f = true;
                    }
            }
            groupBox1.Visible = f;
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (Program.ISSaDmin)
            {
               

                progressBarX1.Value = 0;
                progressBarX1.Visible = true;
                foreach (DataGridViewRow dgr in mygrid2.Rows)
                {
                    progressBarX1.Maximum = mygrid2.Rows.Count;

                    if (dgr.Cells["choixp"].Value != null)
                    {
                        if ((Boolean)dgr.Cells["choixp"].Value)
                        {
                            double xqtedep = 0,  xstk = 0;
                            Double xtqte = 0, xtqte1 = 0;
                            Double xtqte2 = 0, xtqte3 = 0 ;
                            Double wtqte =0, wtqte1 =0 ;
                            double wtqte2 = 0,wtqte3 =0, wstk =0, wqtedep = 0;
                            string req1 = "";

                            string xcode = dgr.Cells["codea"].Value + "";

                           

                            ////// Article Dépot

                          
                            string reqd = "";
                            reqd = "SELECT code FROM depot  where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' ";
                            DataSet dsd = met.recuperer_table(reqd, "depot");
                            foreach (DataRow drp in dsd.Tables["depot"].Rows)
                            {
                                

                                string wcoded = drp.Field<string>("code");




                                string reqg = "";
                                reqg = "SELECT codeg,libelle FROM gamme  where codea ='" + xcode + "' and codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' ";
                                DataSet dsg = met.recuperer_table(reqg, "gamme");

                                foreach (DataRow drg in dsg.Tables["gamme"].Rows)
                                {

                                    xtqte = xtqte1 =  0 ;
                                    xtqte2 = xtqte3 =  xstk = xqtedep = 0 ;

                                    string wcodeg = drg.Field<string>("codeg");

                                    req1 = "SELECT qtedep FROM artdep WHERE codes='" + Program.Societe + "' AND codee='" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and codea ='" + xcode + "' and coded = '" + wcoded + "' and codeg = '" + wcodeg + "' ";
                                    ds = met.recuperer_table(req1, "artdep");

                                    if (ds.Tables[0].Rows.Count != 0)
                                    {
                                        try
                                        {
                                            xqtedep = ds.Tables[0].Rows[0].Field<double>("qtedep");
                                        }
                                        catch { xqtedep = 0; }

                                        try
                                        {
                                            wqtedep += ds.Tables[0].Rows[0].Field<double>("qtedep");
                                        }
                                        catch {}
                                    }

                                  
                                    //req1 = "SELECT  coded,codeg,num,codea,qte,ID  FROM lentf  where coded ='" + wcoded + "' and codeg = '" + wcodeg + "'  and  codea = '" + xcode + "' and codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "'  ";
                                    req1 = "SELECT distinct l.coded,l.codeg,l.num,l.codea,l.qte,e.type,l.ID  FROM lentf l, eentf e  where l.coded ='" + wcoded + "' and l.codeg = '" + wcodeg + "'  and  l.codea = '" + xcode + "' and e.num=l.num and e.type='C' and l.codes='" + Program.Societe + "' and l.codee = '" + Program.Exercice + "' and l.codem='" + Program.Magasin + "' ";
                                    ds = met.recuperer_table(req1, "lentf");



                                    foreach (DataRow dr in ds.Tables["lentf"].Rows)
                                    {


                                        try
                                        {
                                            xtqte2 += dr.Field<Double>("qte");
                                           
                                        }
                                        catch { }

                                        try
                                        {
                                            wtqte2 += dr.Field<Double>("qte");

                                        }
                                        catch { }



                                    }

                                    req1 = "SELECT distinct l.coded,l.codeg,l.num,l.codea,l.qte,l.ID  FROM lente l, eente e  where l.coded ='" + wcoded + "' and l.codeg = '" + wcodeg + "'  and  l.codea = '" + xcode + "' and l.codes='" + Program.Societe + "' and l.codee = '" + Program.Exercice + "' and l.codem='" + Program.Magasin + "' ";
                                    ds = met.recuperer_table(req1, "lente");

                                    foreach (DataRow dr in ds.Tables["lente"].Rows)
                                    {


                                        try
                                        {
                                            xtqte2 += dr.Field<Double>("qte");
                                           
                                        }
                                        catch { }

                                        try
                                        {
                                            wtqte2 += dr.Field<Double>("qte");

                                        }
                                        catch { }


                                    }


                                    req1 = "SELECT distinct l.coded,l.codeg,l.num,l.codea,l.qte,l.ID  FROM lentcb l, eentcb e  where l.coded ='" + wcoded + "' and l.codeg = '" + wcodeg + "'  and  l.codea = '" + xcode + "' and l.codes='" + Program.Societe + "' and l.codee = '" + Program.Exercice + "' and l.codem='" + Program.Magasin + "' ";
                                    ds = met.recuperer_table(req1, "lentcb");

                                    foreach (DataRow dr in ds.Tables["lentcb"].Rows)
                                    {


                                        try
                                        {
                                            xtqte += dr.Field<Double>("qte");

                                        }
                                        catch { }

                                        try
                                        {
                                            wtqte += dr.Field<Double>("qte");

                                        }
                                        catch { }


                                    }


                                    //req1 = "SELECT  coded,codeg,num,codea,qte,ID  FROM lentc  where coded ='" + wcoded + "' and codeg = '" + wcodeg + "'  and  codea = '" + xcode + "' and codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "'  ";
                                    req1 = "SELECT distinct l.coded,l.codeg,l.num,l.codea,l.qte,l.ID  FROM lentc l, eentc e  where l.coded ='" + wcoded + "' and l.codeg = '" + wcodeg + "'  and  l.codea = '" + xcode + "' and e.num=l.num and e.mode='D' and l.codes='" + Program.Societe + "' and l.codee = '" + Program.Exercice + "' and l.codem='" + Program.Magasin + "' ";
                                    ds = met.recuperer_table(req1, "lentc");



                                    foreach (DataRow dr in ds.Tables["lentc"].Rows)
                                    {


                                        try
                                        {
                                            xtqte += dr.Field<Double>("qte");
                                           
                                        }
                                        catch { }

                                        try
                                        {
                                            wtqte += dr.Field<Double>("qte");

                                        }
                                        catch { }



                                    }


                                    req1 = "SELECT distinct l.coded,l.codeg,l.num,l.codea,l.qte,l.ID  FROM lentl l, eentl e  where l.coded ='" + wcoded + "' and l.codeg = '" + wcodeg + "'  and  l.codea = '" + xcode + "' and l.codes='" + Program.Societe + "' and l.codee = '" + Program.Exercice + "' and l.codem='" + Program.Magasin + "'  ";
                                    ds = met.recuperer_table(req1, "lentl");

                                    foreach (DataRow dr in ds.Tables["lentl"].Rows)
                                    {


                                        try
                                        {
                                            xtqte += dr.Field<Double>("qte");
                                        }
                                        catch { }

                                        try
                                        {
                                            wtqte += dr.Field<Double>("qte");
                                        }
                                        catch { }



                                    }

                                  
                                    req1 = "SELECT  coded,codeg,num,codea,qte,ID  FROM lentvc  where coded ='" + wcoded + "' and codeg = '" + wcodeg + "'  and  codea = '" + xcode + "' and codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' ";
                                    ds = met.recuperer_table(req1, "lentvc");


                                    foreach (DataRow dr in ds.Tables["lentvc"].Rows)
                                    {


                                        try
                                        {
                                            xtqte1 += dr.Field<Double>("qte");
                                        }
                                        catch { }

                                        try
                                        {
                                            wtqte1 += dr.Field<Double>("qte");
                                        }
                                        catch { }


                                    }

                                    
                                    req1 = "SELECT  coded,codeg,num,codea,qte,ID  FROM lentvf  where coded ='" + wcoded + "' and codeg = '" + wcodeg + "'  and  codea = '" + xcode + "' and codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "'   ";
                                    ds = met.recuperer_table(req1, "lentvf");


                                    foreach (DataRow dr in ds.Tables["lentvf"].Rows)
                                    {


                                        try
                                        {
                                            xtqte3 += dr.Field<Double>("qte");
                                        }
                                        catch { }

                                        try
                                        {
                                            wtqte3 += dr.Field<Double>("qte");
                                        }
                                        catch { }



                                    }


                                    //////Sauvegarde Article Dépot
                                    
                                    xstk = xqtedep + xtqte2 - xtqte3 - xtqte + xtqte1;

                                    string reqt1 = "";
                                    reqt1 = "Update artdep set qteent = " + xtqte2.ToString().Replace(Program.sep, string.Empty)
                                                  + ",qteavrc=" + xtqte1.ToString().Replace(Program.sep, string.Empty)
                                                  + ",qtesor=" + xtqte.ToString().Replace(Program.sep, string.Empty)
                                                  + ",qteavrf=" + xtqte3.ToString().Replace(Program.sep, string.Empty)
                                                  + ",qtestk=" + xstk.ToString().Replace(Program.sep, string.Empty)
                                                  + " Where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and codea = '" + xcode + "' and coded ='" + wcoded + "' and codeg='" + wcodeg + "' ";
                                     met.Execute(reqt1);
                                   
                                }
                            }

                            wstk = wqtedep + wtqte2 - wtqte3 - wtqte  + wtqte1;
                            string reqt2 = "Update artmag set qteent = " + wtqte2.ToString().Replace(Program.sep, string.Empty)
                                         + ",qteavrc=" + wtqte1.ToString().Replace(Program.sep, string.Empty)
                                         + ",qtesor=" + wtqte.ToString().Replace(Program.sep, string.Empty)
                                         + ",qteavrf=" + wtqte3.ToString().Replace(Program.sep, string.Empty)
                                         + ",qtestk=" + wstk.ToString().Replace(Program.sep, string.Empty)
                                         + " Where codes='" + Program.Societe + "' and codee = '" + Program.Exercice + "' and codem='" + Program.Magasin + "' and codea = '" + xcode + "' ";
                            met.Execute(reqt2);
                        }
                    }
                    progressBarX1.Value++;
                }

                progressBarX1.Visible = false;
                MessageBox.Show("Réorganisation  effectuée avec Succés");
            }
            else
            {
                MessageBox.Show("Accés Non Autorisé");
            }

           

        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            // Bouton Recherche
            Rechart form = new Rechart();
            form.table = "article";
            form.ShowDialog();
            form.textBoxX7.Focus();
            if (form.code != 0)
            {
                List<DataColumn> lis = new List<DataColumn>();
                lis.Add(ds4.Tables["article"].Columns["ID"]);
                ds4.Tables["article"].PrimaryKey = lis.ToArray();
                DataRow[] dr = ds4.Tables["article"].Select("ID = '" + form.code + "'");
                if (dr.Length != 0)
                {
                    int i = ds4.Tables[0].Rows.IndexOf(dr[0]);
                    mygrid2.Rows[i].Selected = true;
                }
            }
        }

       

    }
}
