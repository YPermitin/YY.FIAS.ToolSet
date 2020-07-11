using System;
using System.IO;
using System.Threading.Tasks;
using YY.FIAS.Loader.API;

namespace YY.FIAS.Loader
{
    public sealed class DownloadFileInfo
    {
        private readonly IAPIHelper _apiHelper;

        public int VersionId { get; set; }
        public string TextVersion { get; set; }
        public Uri FiasCompleteDbfUrl { get; set; }
        public Uri FiasCompleteXmlUrl { get; set; }
        public Uri FiasDeltaDbfUrl { get; set; }
        public Uri FiasDeltaXmlUrl { get; set; }
        public Uri Kladr4ArjUrl { get; set; }
        public Uri Kladr47ZUrl { get; set; }

        internal DownloadFileInfo()
        {
            _apiHelper = new APIHelper();
        }

        public async Task SaveFiasCompleteDbfFile(string fileToSave)
        {
            FileInfo fileToSaveInfo = new FileInfo(fileToSave);
            if (fileToSaveInfo.Directory != null)
            {
                if (!fileToSaveInfo.Directory.Exists)
                    fileToSaveInfo.Directory.Create();
            }

            await _apiHelper.DownloadFile(FiasCompleteDbfUrl, fileToSave);
        }
        public async Task SaveFiasCompleteDbfToDirectory(string directoryToSave)
        {
            string fileToSave = Path.Combine(directoryToSave, "FiasCompleteDbf.dbf");
            await SaveFiasCompleteDbfFile(fileToSave);
        }

        public async Task SaveFiasCompleteXmlFile(string fileToSave)
        {
            FileInfo fileToSaveInfo = new FileInfo(fileToSave);
            if (fileToSaveInfo.Directory != null)
            {
                if (!fileToSaveInfo.Directory.Exists)
                    fileToSaveInfo.Directory.Create();
            }

            await _apiHelper.DownloadFile(FiasCompleteXmlUrl, fileToSave);
        }
        public async Task SaveFiasCompleteXmlToDirectory(string directoryToSave)
        {
            string fileToSave = Path.Combine(directoryToSave, "SaveFiasCompleteXml.xml");
            await SaveFiasCompleteXmlFile(fileToSave);
        }

        public async Task SaveFiasDeltaDbFile(string fileToSave)
        {
            FileInfo fileToSaveInfo = new FileInfo(fileToSave);
            if (fileToSaveInfo.Directory != null)
            {
                if (!fileToSaveInfo.Directory.Exists)
                    fileToSaveInfo.Directory.Create();
            }

            await _apiHelper.DownloadFile(FiasDeltaDbfUrl, fileToSave);
        }
        public async Task SaveFiasDeltaDbToDirectory(string directoryToSave)
        {
            string fileToSave = Path.Combine(directoryToSave, "SaveFiasDeltaDb.dbf");
            await SaveFiasDeltaDbFile(fileToSave);
        }

        public async Task SaveFiasDeltaXmlFile(string fileToSave)
        {
            FileInfo fileToSaveInfo = new FileInfo(fileToSave);
            if (fileToSaveInfo.Directory != null)
            {
                if (!fileToSaveInfo.Directory.Exists)
                    fileToSaveInfo.Directory.Create();
            }

            await _apiHelper.DownloadFile(FiasDeltaXmlUrl, fileToSave);
        }
        public async Task SaveFiasDeltaXmlToDirectory(string directoryToSave)
        {
            string fileToSave = Path.Combine(directoryToSave, "FiasDeltaXml.xml");
            await SaveFiasDeltaXmlFile(fileToSave);
        }

        public async Task SaveKladr4ArjFile(string fileToSave)
        {
            FileInfo fileToSaveInfo = new FileInfo(fileToSave);
            if (fileToSaveInfo.Directory != null)
            {
                if (!fileToSaveInfo.Directory.Exists)
                    fileToSaveInfo.Directory.Create();
            }

            await _apiHelper.DownloadFile(Kladr4ArjUrl, fileToSave);
        }
        public async Task SaveKladr4ArjToDirectory(string directoryToSave)
        {
            string fileToSave = Path.Combine(directoryToSave, "Kladr4Arj.arj");
            await SaveKladr4ArjFile(fileToSave);
        }

        public async Task SaveKladr47ZFile(string fileToSave)
        {
            FileInfo fileToSaveInfo = new FileInfo(fileToSave);
            if (fileToSaveInfo.Directory != null)
            {
                if (!fileToSaveInfo.Directory.Exists)
                    fileToSaveInfo.Directory.Create();
            }

            await _apiHelper.DownloadFile(Kladr47ZUrl, fileToSave);
        }
        public async Task SaveKladr47ZToDirectory(string directoryToSave)
        {
            string fileToSave = Path.Combine(directoryToSave, "Kladr47Z.7z");
            await SaveKladr47ZFile(fileToSave);
        }
    }
}
