namespace qPatterns.Core.Authentication
{
    public interface IFormsAuthentication
    {
       void SetAuthorizationToken(string token);
       string GetAuthorizationToken();
       void SignOut();
    }                
}
