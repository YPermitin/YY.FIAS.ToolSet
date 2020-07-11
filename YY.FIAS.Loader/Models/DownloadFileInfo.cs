using System;

namespace YY.FIAS.Loader
{
    public class DownloadFileInfo
    {
        public int VersionId { get; set; }
        public string TextVersion { get; set; }
        public Uri FiasCompleteDbfUrl { get; set; }
        public Uri FiasCompleteXmlUrl { get; set; }
        public Uri FiasDeltaDbfUrl { get; set; }
        public Uri FiasDeltaXmlUrl { get; set; }
        public Uri Kladr4ArjUrl { get; set; }
        public Uri Kladr47ZUrl { get; set; }
    }
}
