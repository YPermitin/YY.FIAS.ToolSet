
using System.Collections.Generic;
using System.Threading.Tasks;
using YY.FIAS.Loader.API;

namespace YY.FIAS.Loader
{
    public interface IFIASLoader
    {
        Task<DownloadFileInfo> GetLastDownloadFileInfo();
        Task<IReadOnlyList<DownloadFileInfo>> GetAllDownloadFileInfo();
    }
}
