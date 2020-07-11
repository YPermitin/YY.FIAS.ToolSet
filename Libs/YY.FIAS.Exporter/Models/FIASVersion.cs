using System;
using System.Collections.Generic;
using System.Text;

namespace YY.FIAS.Exporter.Models
{
    public sealed class FIASVersion
    {
        #region Private Members

        public int _versionId { get; }
        public DateTime _versionDate { get; }
        public string _textVersion { get; }

        #endregion

        #region Public Members

        public int VersionId => _versionId;
        public DateTime VersionDate => _versionDate;
        public string TextVersion => _textVersion;

        #endregion

        #region Constructor

        public FIASVersion(int versionId, DateTime versionDate, string textVersion)
        {
            _versionId = versionId;
            _versionDate = versionDate;
            _textVersion = textVersion;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return TextVersion;
        }

        #endregion
    }
}
