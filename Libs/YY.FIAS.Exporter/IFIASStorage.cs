using System;
using System.Collections.Generic;
using System.Text;
using YY.FIAS.Exporter.Models;
using YY.FIAS.Loader;

namespace YY.FIAS.Exporter
{
    public interface IFIASStorage
    {
        FIASVersion GetCurrentVersion();
        IReadOnlyList<DownloadFileInfo> CheckForUpdates();
        void PrepareForUpgrade();
        void ApplyUpgrade();
    }
}
