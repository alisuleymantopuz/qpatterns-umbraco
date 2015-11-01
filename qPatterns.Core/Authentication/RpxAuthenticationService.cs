using qPatterns.Core.Configuration;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace qPatterns.Core.Authentication
{
    public class RpxAuthenticationService : IExternalAuthenticationService
    {
        public CoreConfiguration CoreConfiguration { get; private set; }

        public RpxAuthenticationService(CoreConfiguration coreConfiguration)
        {
            CoreConfiguration = coreConfiguration;
        }
        public User GetUserDetailsFrom(string token)
        {
            User user = new User();
            
            string parameters = string.Format("apiKey={0}&token={1}&format=xml", ApplicationSettingsFactory.GetApplicationSettings().RpxApiKey, token);
            string response;
            using (var w = new WebClient())
            {                
                response = w.UploadString("https://rpxnow.com/api/v2/auth_info", parameters);
            }
            var xmlResponse = XDocument.Parse(response);
            var userProfile = (from x in xmlResponse.Descendants("profile")
                               select new
                               {   id = x.Element("identifier").Value,                                 
                                   email = (string)x.Element("email") ?? "No Email"
                               }).SingleOrDefault();
            
            if (userProfile != null)
            {                                            
                user.AuthenticationToken = userProfile.id;
                user.Email = userProfile.email;
                user.IsAuthenticated = true;
            }
            else            
                user.IsAuthenticated = false;            

            return user;
        }
    }
}