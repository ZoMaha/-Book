using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace SubstancesReferenceBook.Controllers
{
    //[Route("[controller]")]
    public class SampleDataController : Controller
    {
        [HttpGet("one")]
        public List<string[]> listOfProperties()
        {
            SqlConnection sqlConnection;
            sqlConnection = new SqlConnection("Data Source=MARIA;" +
                "Initial Catalog=SubstancesReferenceBook;" +
                "Integrated Security=True");
            sqlConnection.Open();

            //�������� ��������� ����������
            string queryTable = "SELECT * FROM " + " [dbo].[SubstCategories]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> Categories = new List<string[]>();

            while (reader.Read())
            {
                Categories.Add(new string[reader.FieldCount]);
                for (
                    int i = 0; i < reader.FieldCount; i++)
                {
                    //������ ������������ � ���� ������     
                    Categories[Categories.Count - 1][i] = reader[i].ToString();
                }

            }
            reader.Close();


            //�������� ������� -> ���������, �������� � ��� ���������
            queryTable = "SELECT * FROM " + " [dbo].[Substances]";
            command = new SqlCommand(queryTable, sqlConnection);
            reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            int label = 0;
            //��������� ������, ��������� ������ ��������
            while (reader.Read())
            {
                data.Add(new string[reader.FieldCount+1]);
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    //������ ������������ � ���� ������     
                    data[data.Count - 1][i] = reader[i].ToString();
                }

                //���������� � ����������, ��������� � ���������� 
                for (int j = 0; j < Categories.Count; j++)
                {
                    if (Categories[j][0] == data[data.Count - 1][3])
                    {
                        data[data.Count - 1][3] = Categories[j][2];
                        data[data.Count - 1][4] = Categories[j][3];
                        j = Categories.Count;
                    }

                }
                    //data[data.Count - 1][reader.FieldCount] = readerCat[0].ToString();

                    label++;
            }

            //�������� ������ ��������
            int k = 1;
            return data;
        }
    }
              
}


