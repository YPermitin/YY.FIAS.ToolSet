using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace YY.FIAS.Loader.API
{
    internal class APIHelper : IAPIHelper
    {
        private HttpClient _apiClient { get; set; }

        public APIHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            _apiClient = new HttpClient();
        }

        public async Task DownloadFile(Uri uriFile, string savePath)
        {
            var response = await _apiClient.GetAsync(uriFile);
            response.EnsureSuccessStatusCode();
            
            await using var ms = await response.Content.ReadAsStreamAsync();
                await using var fs = File.Create(savePath);
                    ms.Seek(0, SeekOrigin.Begin);
                    await ms.CopyToAsync(fs);
        }

        public async Task<string> GetContentAsString(Uri uri)
        {
            var response = await _apiClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
