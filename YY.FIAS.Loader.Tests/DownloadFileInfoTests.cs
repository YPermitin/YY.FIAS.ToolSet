using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace YY.FIAS.Loader.Tests
{
    public class DownloadFileInfoTests
    {
        private readonly string _workDirectory;
        private readonly IFIASLoader _loader;
        private DownloadFileInfo _fileInfo;

        public DownloadFileInfoTests()
        {
            _loader = new FIASLoader();
            _workDirectory = Path.Combine(Environment.CurrentDirectory, "TestData");
        }

        #region Public Methods

        [Fact]
        public async void SaveFiasCompleteDbfFileTest()
        {
            DownloadFileInfo lastInfo = await GetDownloadFileInfo();

            string pathFiasCompleteDbfFile = Path.Combine(_workDirectory, "SaveFiasCompleteDbfFileTest.dbf");
            await lastInfo.SaveFiasCompleteDbfFile(pathFiasCompleteDbfFile);
        }
        [Fact]
        public async void SaveFiasCompleteDbfToDirectoryTest()
        {
            DownloadFileInfo lastInfo = await GetDownloadFileInfo();

            string pathFiasCompleteDbfFile = Path.Combine(_workDirectory, "SaveFiasCompleteDbfToDirectoryTest.dbf");
            await lastInfo.SaveFiasCompleteDbfToDirectory(pathFiasCompleteDbfFile);
        }

        [Fact]
        public async void SaveFiasCompleteXmlFileTest()
        {
            DownloadFileInfo lastInfo = await GetDownloadFileInfo();

            string pathFiasCompleteDbfFile = Path.Combine(_workDirectory, "SaveFiasCompleteXmlFileTest.dbf");
            await lastInfo.SaveFiasCompleteXmlFile(pathFiasCompleteDbfFile);
        }
        [Fact]
        public async void SaveFiasCompleteXmlToDirectoryTest()
        {
            DownloadFileInfo lastInfo = await GetDownloadFileInfo();

            string pathFiasCompleteDbfFile = Path.Combine(_workDirectory, "SaveFiasCompleteXmlToDirectoryTest.dbf");
            await lastInfo.SaveFiasCompleteXmlToDirectory(pathFiasCompleteDbfFile);
        }

        [Fact]
        public async void SaveFiasDeltaDbFileTest()
        {
            DownloadFileInfo lastInfo = await GetDownloadFileInfo();

            string pathFiasCompleteDbfFile = Path.Combine(_workDirectory, "SaveFiasDeltaDbFileTest.dbf");
            await lastInfo.SaveFiasDeltaDbFile(pathFiasCompleteDbfFile);
        }
        [Fact]
        public async void SaveFiasDeltaDbToDirectoryTest()
        {
            DownloadFileInfo lastInfo = await GetDownloadFileInfo();

            string pathFiasCompleteDbfFile = Path.Combine(_workDirectory, "SaveFiasDeltaDbToDirectoryTest.dbf");
            await lastInfo.SaveFiasDeltaDbToDirectory(pathFiasCompleteDbfFile);
        }

        [Fact]
        public async void SaveFiasDeltaXmlFileTest()
        {
            DownloadFileInfo lastInfo = await GetDownloadFileInfo();

            string pathFiasCompleteDbfFile = Path.Combine(_workDirectory, "SaveFiasDeltaXmlFileTest.dbf");
            await lastInfo.SaveFiasDeltaXmlFile(pathFiasCompleteDbfFile);
        }
        [Fact]
        public async void SaveFiasDeltaXmlToDirectoryTest()
        {
            DownloadFileInfo lastInfo = await GetDownloadFileInfo();

            string pathFiasCompleteDbfFile = Path.Combine(_workDirectory, "SaveFiasDeltaXmlToDirectoryTest.dbf");
            await lastInfo.SaveFiasDeltaXmlToDirectory(pathFiasCompleteDbfFile);
        }

        [Fact]
        public async void SaveKladr4ArjFileTest()
        {
            DownloadFileInfo lastInfo = await GetDownloadFileInfo();

            string pathFiasCompleteDbfFile = Path.Combine(_workDirectory, "SaveKladr4ArjFileTest.dbf");
            await lastInfo.SaveKladr4ArjFile(pathFiasCompleteDbfFile);
        }
        [Fact]
        public async void SaveKladr4ArjToDirectoryTest()
        {
            DownloadFileInfo lastInfo = await GetDownloadFileInfo();

            string pathFiasCompleteDbfFile = Path.Combine(_workDirectory, "SaveKladr4ArjToDirectoryTest.dbf");
            await lastInfo.SaveKladr4ArjToDirectory(pathFiasCompleteDbfFile);
        }

        [Fact]
        public async void SaveKladr47ZFileTest()
        {
            DownloadFileInfo lastInfo = await GetDownloadFileInfo();

            string pathFiasCompleteDbfFile = Path.Combine(_workDirectory, "SaveKladr47ZFileTest.dbf");
            await lastInfo.SaveKladr47ZFile(pathFiasCompleteDbfFile);
        }
        [Fact]
        public async void SaveKladr47ZToDirectoryTest()
        {
            DownloadFileInfo lastInfo = await GetDownloadFileInfo();

            string pathFiasCompleteDbfFile = Path.Combine(_workDirectory, "SaveKladr47ZToDirectoryTest.dbf");
            await lastInfo.SaveKladr47ZToDirectory(pathFiasCompleteDbfFile);
        }

        #endregion

        #region Private Methods

        private async Task<DownloadFileInfo> GetDownloadFileInfo()
        {
            return _fileInfo ??= await _loader.GetLastDownloadFileInfo();
        }

        #endregion
    }
}
