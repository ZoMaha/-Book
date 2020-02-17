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
        SqlConnection sqlConnection;
        public SampleDataController()
        {
            sqlConnection = new SqlConnection("Data Source=MARIA;" +
                "Initial Catalog=SubstancesReferenceBook;" +
                "Integrated Security=True");
            sqlConnection.Open();
        }

        [HttpGet("substances")]
        public List<Sub> listOfSubstances()
        {
            {
                ////¬ыбираем категории материалов
                //string queryTable = "SELECT * FROM " + " [dbo].[SubstCategories]";
                //SqlCommand command = new SqlCommand(queryTable, sqlConnection);
                //SqlDataReader reader = command.ExecuteReader();
                //List<string[]> Categories = new List<string[]>();

                //while (reader.Read())
                //{
                //    Categories.Add(new string[reader.FieldCount]);
                //    for (
                //        int i = 0; i < reader.FieldCount; i++)
                //    {
                //        //ƒанные представл€ем в виде строки     
                //        Categories[Categories.Count - 1][i] = reader[i].ToString();
                //    }

                //}
                //reader.Close();
            }

            //ћатериалы, добавить к ним категории
            string queryTable = "SELECT * FROM " + " [dbo].[Substances]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<Sub> data = new List<Sub>();

            //int label = 0;
            //—читываем данные, заполн€ем массив массивов
            while (reader.Read())
            {
                data.Add(new Sub()
                {
                    //ƒанные представл€ем в виде строки     
                    Id = Int32.Parse(reader[0].ToString()),
                    Name = reader[1].ToString(),
                    Descr = reader[2].ToString(),
                    CategoryID = reader[3].ToString()
                }
                );

                {
                    //»нформаци€ о категори€х
                    //for (int j = 0; j < Categories.Count; j++)
                    //{
                    //    if (Categories[j][0] == reader[3].ToString())
                    //    {
                    //        data[data.Count - 1].Category = new Category();
                    //        data[data.Count - 1].Category.Id = Int32.Parse(Categories[j][0].ToString());
                    //        data[data.Count - 1].Category.ParentId = Int32.Parse(Categories[j][1].ToString());
                    //        data[data.Count - 1].Category.Name = Categories[j][2].ToString();
                    //        data[data.Count - 1].Category.Descr = Categories[j][3].ToString();
                    //        j = Categories.Count;
                    //    }

                    //}
                    //data[data.Count - 1][reader.FieldCount] = readerCat[0].ToString();
                }

                //label++;
            }

            //ѕроверка работы запросов
            reader.Close();

            return data;
        }

        [HttpGet("categories")]
        public List<Category> listOfCategories()
        {
            //¬ыбираем категории материалов
            string queryTable = "SELECT * FROM " + " [dbo].[SubstCategories]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<Category> data = new List<Category>();

            while (reader.Read())
            {
                data.Add(new Category()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    ParentId = Int32.Parse(reader[1].ToString()),
                    Name = reader[2].ToString(),
                    Descr = reader[3].ToString()
                }
                );
            }

            reader.Close();
            return data;
        }

        [HttpGet("ps")]
        public List<PropSubstLinks> listOfOne()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[PropSubstLinks]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<PropSubstLinks> data = new List<PropSubstLinks>();

            while (reader.Read())
            {
                data.Add(new PropSubstLinks()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    PropId = Int32.Parse(reader[1].ToString()),
                    SubstId = Int32.Parse(reader[2].ToString()),
                    MinValue = Convert.ToDouble(reader[3].ToString()),
                    MaxValue = Convert.ToDouble(reader[4].ToString()),
                    DefaultValue = Convert.ToDouble(reader[5].ToString())
                }
                ); ;

            }

            reader.Close();
            return data;
        }

        [HttpGet("props")]
        public List<Props> listProps()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[Properties]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<Props> data = new List<Props>();

            while (reader.Read())
            {
                data.Add(new Props()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    Name = reader[1].ToString(),
                    Descr = reader[2].ToString(),
                    PropUnits = reader[3].ToString(),
                    Type = Int32.Parse(reader[4].ToString()),
                }
                );
               
                //data[data.Count - 1].PropUnits = "Bpvty";
                //data[data.Count - 1].Upd(data[data.Count - 1].Name, data[data.Count - 1].Descr, data[data.Count - 1].PropUnits, data[data.Count - 1].Type);
                

            
            }

            reader.Close();
            return data;
        }

        [HttpGet("StateVar")]
        public List<StateVariables> listOfStateVar()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[StateVariables]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<StateVariables> data = new List<StateVariables>();

            while (reader.Read())
            {
                data.Add(new StateVariables()
                {
                    //ƒанные представл€ем в виде строки     
                    Id = Int32.Parse(reader[0].ToString()),
                    Name = reader[1].ToString(),
                    Descr = reader[2].ToString(),
                    StateVarUnit = reader[3].ToString()
                }
                );
            }

            reader.Close();
            return data;
        }
               
        [HttpGet("Array")]
        public List<Array1DPropValues> listOf1DArray()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[Array1DPropValues]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<Array1DPropValues> data = new List<Array1DPropValues>();

            while (reader.Read())
            {
                data.Add(new Array1DPropValues()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    PropSubId = Int32.Parse(reader[1].ToString()),
                    StateVarId = Int32.Parse(reader[2].ToString()),
                    Values = new List<double> { Convert.ToDouble(reader[3].ToString()), Convert.ToDouble(reader[4].ToString()) },
                    VersionDate = Convert.ToDateTime(reader[5].ToString())
                }
                );
            }
            reader.Close();
            return data;
        }

        [HttpGet("scalar")]
        public List<ScalarPropValues> listOfScalar()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[ScalarPropValues]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<ScalarPropValues> data = new List<ScalarPropValues>();

            while (reader.Read())
            {
                data.Add(new ScalarPropValues()
                {
                    //ƒанные представл€ем в виде строки     
                    Id = Int32.Parse(reader[0].ToString()),
                    PropSubId = Int32.Parse(reader[1].ToString()),
                    Value = Convert.ToDouble(reader[2].ToString()),
                    VersionDate = Convert.ToDateTime(reader[3].ToString())
                }
                ) ;
            }

            reader.Close();
            return data;
        }

        [HttpGet("assoc")]
        public List<AssocPropValues> listOfAssoc()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[AssocPropValues]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<AssocPropValues> data = new List<AssocPropValues>();

            while (reader.Read())
            {
                data.Add(new AssocPropValues()
                {
                    //ƒанные представл€ем в виде строки     
                    Id = Int32.Parse(reader[0].ToString()),
                    PropSubId = Int32.Parse(reader[1].ToString()),
                    Key = reader[2].ToString(),
                    Value = Convert.ToDouble(reader[3].ToString()),
                    VersionDate = Convert.ToDateTime(reader[4].ToString())
                }
                );
            }

            reader.Close();
            return data;
        }
    
        [HttpGet("AllSources")]
        public List<PropValueSourceLinks> listOfSource()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[PropValueSourceLinks]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<PropValueSourceLinks> data = new List<PropValueSourceLinks>();

            while (reader.Read())
            {
                data.Add(new PropValueSourceLinks()
                {
                    
                    Id = Int32.Parse(reader[0].ToString()),
                    PropValueId = Int32.Parse(reader[1].ToString()),
                    SourceTypeId = Int32.Parse(reader[2].ToString()),
                    SourceId = Int32.Parse(reader[3].ToString()),
                }
                );
            }

            reader.Close();
            return data;
        }
    
        [HttpGet("types")]
        public List<SourceType> LlistOfSourceTypes()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[SourceType]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<SourceType> data = new List<SourceType>();

            while (reader.Read())
            {
                data.Add(new SourceType()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    Name = reader[1].ToString(),
                    Descr = reader[2].ToString()                    
                }
                );
            }

            reader.Close();
            return data;
        }

        [HttpGet("Sources")]
        public List<RefSources> lisOfRefSource()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[RefSources]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<RefSources> data = new List<RefSources>();

            while (reader.Read())
            {
                data.Add(new RefSources()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    sourse = reader[1].ToString()
                }
                );
            }
            reader.Close();
            return data;
        }
        public List<WebSources> lisOfWebSource()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[WebSources]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<WebSources> data = new List<WebSources>();

            while (reader.Read())
            {
                data.Add(new WebSources()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    sourse = reader[1].ToString()
                }
                );
            }
            reader.Close();
            return data;
        }
        public List<MeasureSources> lisOfMeasureSource()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[MeasureSources]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<MeasureSources> data = new List<MeasureSources>();

            while (reader.Read())
            {
                data.Add(new MeasureSources()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    sourse = reader[1].ToString()
                }
                );
            }
            reader.Close();
            return data;
        }
        public List<CalcSources> lisOfCalcSource()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[CalcSources]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<CalcSources> data = new List<CalcSources>();

            while (reader.Read())
            {
                data.Add(new CalcSources()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    sourse = Int32.Parse(reader[1].ToString())
                }
                );
            }
            reader.Close();
            return data;
        }

        //ƒобавить обновление и удаление данных
        //ћб это добавить как функции классов?, чтоб не прописывать каждое удаление
        //€ почитаю конешн
        //но мем в том, что на некоторые св€зи не настроена ни проверка, ни каскадное удаление/обновление


    }
}