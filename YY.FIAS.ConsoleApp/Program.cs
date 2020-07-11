using System;
using System.IO;
using System.Threading.Tasks;
using YY.FIAS.Loader;

namespace YY.FIAS.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Начало загрузки данных ФИАС...");

            MainAsync(args).Wait();

            Console.WriteLine("Загрузка завершена.");
            Console.ReadKey();
        }

        static async Task MainAsync(string[] args)
        {
            string workDirectory = Path.Combine(Environment.CurrentDirectory, "TestData"); ;
            IFIASLoader loader = new FIASLoader();
            DownloadFileInfo lastInfo = await loader.GetLastDownloadFileInfo();

            await Task.WhenAll(
                lastInfo.SaveFiasDeltaDbToDirectory(workDirectory),
                lastInfo.SaveFiasDeltaXmlToDirectory(workDirectory),
                lastInfo.SaveFiasCompleteDbfToDirectory(workDirectory),
                lastInfo.SaveFiasCompleteXmlToDirectory(workDirectory),
                lastInfo.SaveKladr47ZToDirectory(workDirectory),
                lastInfo.SaveKladr4ArjToDirectory(workDirectory)
            );
        }
    }
}
