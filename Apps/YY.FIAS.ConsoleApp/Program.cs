using System;
using System.Collections.Generic;
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
            string workDirectory = Path.Combine(Environment.CurrentDirectory, "TestData");
            IFIASLoader loader = new FIASLoader();
            DownloadFileInfo lastInfo = await loader.GetLastDownloadFileInfo();

            await Task.WhenAll(
                lastInfo.SaveFiasDeltaDbToDirectoryAsync(workDirectory),
                lastInfo.SaveFiasDeltaXmlToDirectoryAsync(workDirectory),
                lastInfo.SaveFiasCompleteDbfToDirectoryAsync(workDirectory),
                lastInfo.SaveFiasCompleteXmlToDirectoryAsync(workDirectory),
                lastInfo.SaveKladr47ZToDirectoryAsync(workDirectory),
                lastInfo.SaveKladr4ArjToDirectoryAsync(workDirectory)
            );

            string workDirectoryHistory = Path.Combine(Environment.CurrentDirectory, "FiasHistoryData");
            IFIASLoader loaderistory = new FIASLoader();
            IReadOnlyList<DownloadFileInfo> historyInfo = await loaderistory.GetAllDownloadFileInfo();

            foreach (var fileInfo in historyInfo)
            {
                string currentVersionPath = Path.Combine(workDirectoryHistory, fileInfo.VersionId.ToString());

                await Task.WhenAll(
                    fileInfo.SaveFiasDeltaDbToDirectoryAsync(currentVersionPath),
                    fileInfo.SaveFiasDeltaXmlToDirectoryAsync(currentVersionPath),
                    fileInfo.SaveFiasCompleteDbfToDirectoryAsync(currentVersionPath),
                    fileInfo.SaveFiasCompleteXmlToDirectoryAsync(currentVersionPath),
                    fileInfo.SaveKladr47ZToDirectoryAsync(currentVersionPath),
                    fileInfo.SaveKladr4ArjToDirectoryAsync(currentVersionPath)
                );
            }
        }
    }
}
