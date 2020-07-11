
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YY.FIAS.Loader
{
    public interface IFIASLoader
    {
        Task<DownloadFileInfo> GetLastDownloadFileInfo();
        Task<IReadOnlyList<DownloadFileInfo>> GetAllDownloadFileInfo();
    }
}
