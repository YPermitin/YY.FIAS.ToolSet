using System;
using System.Threading.Tasks;

namespace YY.FIAS.Loader.API
{
    internal interface IAPIHelper
    {
        Task DownloadFile(Uri uriFile, string savePath);
        Task<string> GetContentAsString(Uri uri);
    }
}