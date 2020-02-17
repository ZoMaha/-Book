using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;


namespace SubstancesReferenceBook
{
    public class Program
    {
        
        
        public static void Main(string[] args)
        {
            

            ////List<Sub> substances = new Lis
            //Sub substance_1 = new Sub();
            //substance_1.Test(sqlConnection);

            CreateWebHostBuilder(args).Build().Run();
            
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
