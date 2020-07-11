using System;
using System.Collections.Generic;
using Xunit;

namespace YY.FIAS.Loader.Tests
{
    public class FIASLoaderTests
    {
        [Fact]
        public async void GetLastDownloadFileInfoTest()
        {
            IFIASLoader loader = new FIASLoader();
            DownloadFileInfo lastInfo = await loader.GetLastDownloadFileInfo();

            Assert.NotNull(lastInfo);
            Assert.True(lastInfo.VersionId > 0);
            Assert.True(lastInfo.VersiodDate > DateTime.MinValue);
        }

        [Fact]
        public async void GetAllDownloadFileInfoTest()
        {
            IFIASLoader loader = new FIASLoader();
            IReadOnlyList<DownloadFileInfo> allInfo = await loader.GetAllDownloadFileInfo();

            Assert.NotNull(allInfo);
            Assert.True(allInfo.Count > 0);
        }
    }
}
