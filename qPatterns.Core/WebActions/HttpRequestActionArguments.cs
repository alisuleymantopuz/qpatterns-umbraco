using System.Web;

namespace qPatterns.Core.WebActions
{
    public class HttpRequestActionArguments
    {
        public string GetValueForArgument(ActionArgumentKey key)
        {
            return HttpContext.Current.Request.QueryString[key.ToString()];
        }
    }
}
