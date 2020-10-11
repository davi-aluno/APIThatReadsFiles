using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ASPNetCoreWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateDirectory();
            CreateFile();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void CreateDirectory()
        {
            DirectoryInfo di = new DirectoryInfo(@"files");

            try
            {
                if (di.Exists)
                {
                    Console.WriteLine("Diretorio j� existe!");
                }
                else
                {
                    di.Create();
                    Console.WriteLine("Diretorio criado!");
                }
                Console.WriteLine("Diretorio > " + di.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void CreateFile()
        {
            string filename = @"files/Produtos.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.Write("Fone de ouvido\nCelular\nImpressora\nNotebook");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " | " + e.StackTrace);
            }
        }
    }
}
