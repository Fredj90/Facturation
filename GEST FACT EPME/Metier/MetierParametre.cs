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
   public class MetierParametre
    {

        public  Double Timbre;
        public  Double tauxM;
        public String Code_Cli_Comptant = "";
        metier met = Program.met;
        public Boolean timbreste = true;
        public void Init()
        {
            
            Double Vtimbre = 0, VtauxM = 0;
            string sql1 = "Select value From parametre where param ='Timbre'";
            DataSet tmp1 = met.recuperer_table(sql1);
            if (tmp1.Tables[0].Rows.Count != 0)
            {
                Double.TryParse(tmp1.Tables[0].Rows[0].ItemArray[0] + "", out Vtimbre);
            }
            Timbre = Vtimbre;

            string sql = "Select value From parametre where param ='TauxMajoration'";
            DataSet tmp = met.recuperer_table(sql);
            if (tmp.Tables[0].Rows.Count != 0)
            {
                double.TryParse(tmp.Tables[0].Rows[0].ItemArray[0] + "", out VtauxM);
            }
            tauxM = VtauxM;

            String sqlcc = "SELECT codecomptant FROM pnumste WHERE codes='"+Program.Societe+"' and codee = '"+Program.Exercice+"'";
            DataSet tmpcc = met.recuperer_table(sqlcc);
            if (tmpcc.Tables[0].Rows.Count != 0)
            {
                Code_Cli_Comptant = tmpcc.Tables[0].Rows[0][0] + "";
            }
        }
    }
}

