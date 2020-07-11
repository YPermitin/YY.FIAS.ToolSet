using System;
using System.Collections.Generic;
using YY.FIAS.Exporter.Models;
using YY.FIAS.Loader;

namespace YY.FIAS.Exporter
{
    public class FIASExporter
    {
        #region Private Membeers

        private IFIASLoader _loader;
        private IFIASStorage _storage;

        #endregion

        #region Constructor
        public FIASExporter()
        {
            _loader = new FIASLoader();
        }

        #endregion

        #region Public Members

        public void SetStorage(IFIASStorage storage)
        {
            _storage = storage;
        }


        public FIASVersion GetCurrentVersion()
        {
            return _storage.GetCurrentVersion();
        }
        public IReadOnlyList<DownloadFileInfo> CheckForUpdates()
        {
            return _storage.CheckForUpdates();
        }


        public void PrepareForUpgrade()
        {
            _storage.PrepareForUpgrade();
        }
        public void ApplyUpgrade()
        {
            _storage.ApplyUpgrade();
        }

        #endregion
    }
}
