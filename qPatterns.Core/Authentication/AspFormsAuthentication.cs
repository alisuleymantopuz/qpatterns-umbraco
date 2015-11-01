using System.Web;
using System.Web.Security;

namespace qPatterns.Core.Authentication
{
    public class AspFormsAuthentication : IFormsAuthentication 
    {
        public void SetAuthorizationToken(string token)
        {
            FormsAuthentication.SetAuthCookie(token, true);       
        }

        public string GetAuthorizationToken()
        {
            return HttpContext.Current.User.Identity.Name;
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
