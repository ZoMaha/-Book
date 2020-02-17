using System;
using System.Data.SqlClient;

namespace SubstancesReferenceBook
{
    public class Props
    {
        public int Id;
        public string Name;
        public string Descr;
        public string PropUnits;
        public int Type;
        //public Value Value;
        //Source



        public void Upd(string nameUpd, string descrUpd, string propUnitsUpd, int typeUpd)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=MARIA;" +
                "Initial Catalog=SubstancesReferenceBook;" +
                "Integrated Security=True");
            sqlConnection1.Open();

            /*По идее на вход данные для обновления: ID, и что обновлять*/
            string queryTable1 = "UPDATE [dbo].[Properties] SET Name = '" + nameUpd + "', Descr = '" + descrUpd + "', PropUnits = '" + propUnitsUpd + "', ValueType = " + typeUpd + " WHERE ID =" + Id;
            
            SqlCommand command1 = new SqlCommand(queryTable1, sqlConnection1);
            command1.ExecuteNonQuery();
        }
        public void Delete(string nameUpd, string descrUpd, string propUnitsUpd, int typeUpd)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=MARIA;" +
                "Initial Catalog=SubstancesReferenceBook;" +
                "Integrated Security=True");
            sqlConnection1.Open();

            /*По идее на вход данные для обновления: ID, и что обновлять*/
            string queryTable1 = "DELETE [dbo].[Properties] WHERE ID =" + Id;

            SqlCommand command1 = new SqlCommand(queryTable1, sqlConnection1);
            command1.ExecuteNonQuery();
        }

    }
    

}