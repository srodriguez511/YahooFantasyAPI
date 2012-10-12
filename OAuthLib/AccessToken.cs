using System.Linq;
using System.Web;

namespace OAuth
{
    /// <summary>
    /// Represents a returned Access Token from Yahoo
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// The final auth token. Note that yahoo returns it as an encoded item and we decode upon storing it.
        /// </summary>
        public string oauth_token { get; set; }

        /// <summary>
        /// Token secret provided by yahoo
        /// </summary>
        public string oauth_token_secret { get; set; }

        /// <summary>
        /// The persistent credential used by Yahoo! to identify the Consumer after a User has authorized access to private data. 
        /// Include this credential in your request to refresh the Access Token once it expires.
        /// </summary>
        public string oauth_session_handle { get; set; }

        /// <summary>
        /// Lifetime of the Access Token in seconds (3600, or 1 hour).
        /// </summary>
        public string oauth_expires_in { get; set; }

        /// <summary>
        /// Lifetime of the oauth_session_handle in seconds.
        /// </summary>
        public string oauth_authorization_expires_in { get; set; }

        /// <summary>
        /// The introspective GUID of the currently logged in User. For more information of the GUID
        /// </summary>
        public string xoauth_yahoo_guid { get; set; }

        public AccessToken(string response)
        {
            ProcessResponse(response);
        }

        /// <summary>
        /// Simply split the string into its parts
        /// </summary>
        /// <param name="response"></param>
        private void ProcessResponse(string response)
        {
            var parts = response.Split('&').ToList();

            var result = parts.First(x => x.Contains(KnownOAuthParameters.oauth_token.ToString()));
            oauth_token = HttpUtility.UrlDecode(result.Substring(result.IndexOf('=') + 1));

            result = parts.First(x => x.Contains(KnownOAuthParameters.oauth_token_secret.ToString()));
            oauth_token_secret = result.Substring(result.IndexOf('=') + 1);

            result = parts.First(x => x.Contains(KnownOAuthParameters.oauth_session_handle.ToString()));
            oauth_session_handle = result.Substring(result.IndexOf('=') + 1);

            result = parts.First(x => x.Contains(KnownOAuthParameters.oauth_expires_in.ToString()));
            oauth_expires_in = result.Substring(result.IndexOf('=') + 1);

            result = parts.First(x => x.Contains(KnownOAuthParameters.oauth_authorization_expires_in.ToString()));
            oauth_authorization_expires_in = result.Substring(result.IndexOf('=') + 1);

            result = parts.First(x => x.Contains(KnownOAuthParameters.xoauth_yahoo_guid.ToString()));
            xoauth_yahoo_guid = result.Substring(result.IndexOf('=') + 1);
        }
    }
}
