using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EPME
{
   public class MetierRep
    {
        public Double TauxComRep;
        public String CodeR;
        public String NomR;
        public String AdrR;
        public MetierRep(String Code)
        {
            this.CodeR = Code;
            metier met = Program.met;
            String sql = "SELECT * from rep where  codes = '" + Program.Societe + "' and codee = '" + Program.Exercice + "' and code = '"+Code+"' ";
            DataSet ds = met.recuperer_table(sql, "rep");
            if(ds!=null)
                if(ds.Tables.Count!=0)
                    if (ds.Tables["rep"].Rows.Count != 0)
                    {
                        DataRow dr = ds.Tables["rep"].Rows[0];
                        Double.TryParse(dr["taux"] + "", out TauxComRep);
                        NomR = dr["libelle"] + "";
                        AdrR = dr["adrf"] + "";
                    }
        }
    }
}
