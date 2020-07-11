using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YY.FIAS.Loader
{
    public interface IFIASLoader
    {
        Task<DownloadFileInfo> GetLastDownloadFileInfo();
        Task<IReadOnlyList<DownloadFileInfo>> GetAllDownloadFileInfo();
    }
}
