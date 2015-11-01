using System;

namespace qPatterns.Core.Umbraco.Common
{
    public class GuidAttribute : Attribute
    {
        private readonly string _guid;

        public GuidAttribute(string guid)
        {
            _guid = guid;
        }

        public override string ToString()
        {
            return _guid;
        }
    }
}
