using System;

namespace qPatterns.Core.Umbraco.Common
{
    public class FriendlyNameAttribute : Attribute
    {
        private readonly string _friendlyName;

        public FriendlyNameAttribute(string friendlyName)
        {
            _friendlyName = friendlyName;
        }

        public override string ToString()
        {
            return _friendlyName;
        }
    }
}
