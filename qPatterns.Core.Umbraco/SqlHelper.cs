using umbraco.DataLayer;

namespace qPatterns.Core.Umbraco
{
    public static class SqlHelper
    {
        public static ISqlHelper SqlObject
        {
            // ReSharper disable CSharpWarnings::CS0618
            get { return umbraco.BusinessLogic.Application.SqlHelper; }
            // ReSharper restore CSharpWarnings::CS0618
        }
    }
}
