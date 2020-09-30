using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EPME
{
    public class MetierClient
    {
        public String Codec;
        public Boolean RegimeClient;
        public Boolean TimbreFactClient;
        public Boolean ExenorationClient;
        public Boolean CumulRemiseClient;
        public Double RemiseFixeClient;
        public Boolean Comptant;
        public Double PlafondCreditClient;
        public String NomC;
        public String adrc;
        public MetierClient(String Code)
        {
            Codec = Code;
            metier met = Program.met;
            String sql = "SELECT * from client where  codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code = '"+Code+"' ";
            DataSet ds = met.recuperer_table(sql, "client");
            if(ds!=null)
                if(ds.Tables.Count!=0)
                    if (ds.Tables["client"].Rows.Count != 0)
                    {
                        DataRow dr = ds.Tables["client"].Rows[0];
                        Double.TryParse(dr["remise"] + "", out RemiseFixeClient);
                        Double.TryParse(dr["plafond"] + "", out PlafondCreditClient);
                        RegimeClient = (Boolean)dr["regime"];
                        TimbreFactClient =  (Boolean)dr["timbre"];
                        ExenorationClient = (Boolean)dr["exenoration"];
                        CumulRemiseClient = (Boolean)dr["cumulrem"];
                        NomC = dr["libelle"]+"";
                        adrc = dr["adrl"]+"";
                        Comptant = false;
                        
                    }
        }

        public Double RemiseClient(string codea, string Qte)
        {
            double rem = 0;

            return rem;
        }

    }
}
