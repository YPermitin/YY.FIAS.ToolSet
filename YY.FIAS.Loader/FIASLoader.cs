using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YY.FIAS.Loader.API;

namespace YY.FIAS.Loader
{
    public class FIASLoader : IFIASLoader
    {
        private readonly IAPIHelper _apiHelper;

        public FIASLoader()
        {
            _apiHelper = new APIHelper();
        }

        public async Task<DownloadFileInfo> GetLastDownloadFileInfo()
        {
            Uri methodUri = new Uri("http://fias.nalog.ru/WebServices/Public/GetLastDownloadFileInfo");
            string contentDownloadFileInfo = await _apiHelper.GetContentAsStringAsync(methodUri);
            DownloadFileInfo lastFileInfo = JsonConvert.DeserializeObject<DownloadFileInfo>(contentDownloadFileInfo);

            return lastFileInfo;
        }

        public async Task<IReadOnlyList<DownloadFileInfo>> GetAllDownloadFileInfo()
        {
            Uri methodUri = new Uri("http://fias.nalog.ru/WebServices/Public/GetAllDownloadFileInfo");
            string contentAllDownloadFileInfo = await _apiHelper.GetContentAsStringAsync(methodUri);
            List<DownloadFileInfo> allFileInfo = JsonConvert.DeserializeObject<List<DownloadFileInfo>>(contentAllDownloadFileInfo);

            return allFileInfo;
        }
    }
}
