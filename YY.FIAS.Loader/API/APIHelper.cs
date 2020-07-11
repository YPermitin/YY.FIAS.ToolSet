using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace YY.FIAS.Loader.API
{
    internal class APIHelper : IAPIHelper
    {
        #region Private Members

        private HttpClient _apiClient { get; set; }

        #endregion

        #region Constructor

        public APIHelper()
        {
            InitializeClient();
        }

        #endregion

        #region Public Methods

        public async Task DownloadFileAsync(Uri uriFile, string savePath)
        {
            using (HttpResponseMessage response = _apiClient.GetAsync(uriFile, HttpCompletionOption.ResponseHeadersRead).Result)
            {
                response.EnsureSuccessStatusCode();

                await using (Stream contentStream = await response.Content.ReadAsStreamAsync(), fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                {
                    var totalRead = 0L;
                    var totalReads = 0L;
                    var buffer = new byte[8192];
                    var isMoreToRead = true;

                    do
                    {
                        var read = await contentStream.ReadAsync(buffer, 0, buffer.Length);
                        if (read == 0)
                        {
                            isMoreToRead = false;
                        }
                        else
                        {
                            await fileStream.WriteAsync(buffer, 0, read);

                            totalRead += read;
                            totalReads += 1;
                        }
                    }
                    while (isMoreToRead);
                }
            }
        }
        public async Task<string> GetContentAsStringAsync(Uri uri)
        {
            var response = await _apiClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        
        #endregion

        #region Private Methods

        private void InitializeClient()
        {
            _apiClient = new HttpClient();
        }

        #endregion
    }
}
