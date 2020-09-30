using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EPME
{
    class metier
    {
        public metier()
        {
            OpenDBConnexion();
        }
        public Boolean exit = false;
        // déclaration de la variable connexion
        // public OleDbConnection dbCon;
        // private string dbFile = @"|DataDirectory|\Base\commerce.mdb";

        public MySqlConnection mycon;

        private bool OpenDBConnexion()
        {
            bool connectSucceeded = false;
            System.IO.StreamReader str = new System.IO.StreamReader(Application.StartupPath + "/config.inf");
            string strcon = "";
            try
            {
                strcon = str.ReadLine();
                strcon += ";database=EPME;charset=utf8";
                Program.Str_con = strcon;
            }
            catch
            {

            }
            str.Close();

          
            mycon = new MySqlConnection(strcon);
            try
            {
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                if (ping.Send(mycon.DataSource).Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    
                    mycon.Open();
                    connectSucceeded = true;
                }
                else
                {
                    MessageBox.Show("Impossible de connecter.\n Le serveur " + mycon.DataSource + " Inaccéssible. ");
                    exit = true;
                }
            }
            catch (Exception)
            {
                verif_db();
            }

            return connectSucceeded;
        }

        public DataSet recuperer_table(String req)
        {
            try
            {
                

                MySqlDataAdapter myadap = new MySqlDataAdapter(req, mycon);
                DataSet ds = new DataSet();

                myadap.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }


        }

        public DataSet recuperer_table(String req, DataSet ds, String Table)
        {
            try
            {
                MySqlDataAdapter myadap = new MySqlDataAdapter(req, mycon);
                try
                {
                    ds.Tables[Table].Rows.Clear();
                }
                catch { }
                myadap.Fill(ds, Table);
                return ds;
            }
            catch
            {
                return null;
            }


        }

        public DataSet recuperer_table(String req, String Table)
        {
            try
            {
                
                MySqlDataAdapter myadap = new MySqlDataAdapter(req, mycon);
                DataSet ds = new DataSet();

                myadap.Fill(ds, Table);
                return ds;
            }
            catch
            {
                return null;
            }


        }

        public Boolean Execute(String req)
        {
            MySqlCommand cmd = new MySqlCommand(req, mycon);

            int i = cmd.ExecuteNonQuery();
            if (i == 0)
            {
                return false;
            }
            else
            {
                mycon.BeginTransaction().Commit();
                return true;

            }
        }

        public void increment(string v, string v1)
        {
            int i = int.Parse(v1);
            i++;
            string r = i.ToString();
            int l1 = v1.Length;
            int l2 = r.Length;
            for (int j = l2; j < l1; j++)
                r = "0" + r;
            v1 = v + r;

        }

        public string aligner(decimal mnt)
        {
            string s = mnt.ToString("00000#.000");
            string[] T = s.Split('.');
            string retour = T[0] + T[1];
            return retour;
        }


        public string alignerint(int i)
        {
            string s = i.ToString("0#");
            string retour = s;
            return retour;
        }

        public string espace(string chaine, int nb)
        {
            int l1 = chaine.Trim().Length;
            string chv = "";
            for (int i = l1; i < nb; i++)
                chv = chv + " ";
            return chv;
        }

        public void verif_db()
        {
            System.IO.StreamReader str = new System.IO.StreamReader("config.inf");
            string strcon = "";
            try
            {
                strcon = str.ReadLine();
                strcon += ";database=information_schema;charset=utf8";
            }
            catch { }
            str.Close();
            MySqlConnection contest = new MySqlConnection(strcon);
            try
            {
                object o = contest.DataSource;
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                if (ping.Send(contest.DataSource).Status == System.Net.NetworkInformation.IPStatus.Success)
                {




                    contest.Open();
                    string sql = "SELECT * FROM `information_schema`.`SCHEMATA` where schema_name ='EPME'";
                    try
                    {
                        MySqlDataAdapter myadap = new MySqlDataAdapter(sql, contest);
                        DataSet ds = new DataSet();
                        myadap.Fill(ds);
                        if (ds.Tables.Count != 0)
                            if (ds.Tables[0].Rows.Count == 0)
                            {
                                String bas = bas_str();
                                String[] Tbas = bas.Split(new char[] { ';' });
                                Boolean first = true;
                                foreach (string req in Tbas)
                                {
                                    if (first)
                                    {
                                        MySqlCommand cmd = new MySqlCommand(req, contest);
                                        int i = cmd.ExecuteNonQuery();
                                        OpenDBConnexion();
                                        first = false;
                                    }
                                    else
                                    {

                                        string req1 = req.Replace('\n', ' ');
                                        req1 = req1.Replace('\r', ' ');
                                        if (req1 != "  ")
                                        {
                                            MySqlCommand cmd = new MySqlCommand(req1, mycon);
                                            int i = cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                    }
                    catch
                    {
                    }
                }

            }
            catch
            {

            }
        }

        private String bas_str()
        {
            System.IO.StreamReader str = new System.IO.StreamReader("conf.dll");
            string strbas = "";
            try
            {
                strbas = str.ReadToEnd();
            }
            catch { }
            str.Close();
            return strbas;
        }

        public String CString(Object str)
        {
            return (str + "").Replace("\'", "\\");
        }

        //public Boolean verif_invent()
        //{
        //    Boolean ret = false;
        //    string sql = "select * from einvent where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and valide = false";
        //    DataSet ds = recuperer_table(sql, "einvent");
        //    if (ds != null)
        //        if (ds.Tables.Count != 0)
        //        {
        //            if (ds.Tables[0].Rows.Count == 0)
        //            {
        //                sql = "select * from einvent where codes='" + Program.Societe + "' and codee='" + Program.Exercice + "' and codem = '" + Program.Magasin + "' and valide = true";
        //                ds = recuperer_table(sql, "einvent");
        //                if (ds != null)
        //                    if (ds.Tables.Count != 0)
        //                    {
        //                        if (ds.Tables[0].Rows.Count != 0)
        //                        {
        //                            ret = true;
        //                        }
        //                        else
        //                            MessageBox.Show("Aucun Inventaire ");
        //                    }

        //            }
        //            else
        //                MessageBox.Show("Valider  Inventaire SVP");

        //        }
        //    return ret;

        //}
 
    }
}
