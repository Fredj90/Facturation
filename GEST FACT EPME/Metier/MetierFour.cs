using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EPME
{
    public class MetierFour
    {
        public Boolean FodecFactFour;
        public Boolean TimbreFactFour;
        public String Codec = "";
        public String Nomc = "";
        public String Adrc = "";
         public MetierFour(String Code)
        {
            metier met = Program.met;
            String sql = "SELECT * from four where  codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code = '"+Code+"' ";
            DataSet ds = met.recuperer_table(sql, "four");
            if(ds!=null)
                if(ds.Tables.Count!=0)
                    if (ds.Tables["four"].Rows.Count != 0)
                    {
                        DataRow dr = ds.Tables["four"].Rows[0];
                        
                        FodecFactFour = (Boolean)dr["fodecfact"];
                        TimbreFactFour = (Boolean)dr["timbre"];
                        Codec = dr["code"] + "";
                        Nomc = dr["libelle"] + "";
                        Adrc = dr["adrf"] + "";
                    }
         }
    }

}
