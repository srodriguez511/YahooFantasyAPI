using System.Linq;

namespace OAuth
{
    /// <summary>
    /// Represents the original request token from yahoo
    /// </summary>
    public class RequestToken
    {
        /// <summary>
        /// The secret associated with the Request Token, provided in hexstring format.
        /// </summary>
        public string OauthTokenSecret { get; set; }

        /// <summary>
        /// The lifetime of the Request Token in seconds. The default number is 3600 seconds, or one hour.
        /// </summary>
        public string OauthExpiresIn { get; set; }

        /// <summary>
        /// The URL to the Yahoo! authorization page.
        /// </summary>
        public string XoauthRequestAuthUrl { get; set; }

        /// <summary>
        /// The Request Token that Yahoo! returns as a response to the request_token call. The Request Token is required during the User authorization process.
        /// </summary>
        public string OauthToken { get; set; }

        /// <summary>
        /// This parameter confirms that you are using OAuth 1.0 Rev. A. This parameter is always set to true.
        /// </summary>
        public string OauthCallbackConfirmed { get; set; }


        public RequestToken(string response)
        {
            ProcessResponse(response);
        }

        /// <summary>
        /// Split the response from yahoo into its appropriate parts
        /// </summary>
        /// <param name="response"></param>
        private void ProcessResponse(string response)
        {
            var parts = response.Split('&').ToList();

            var result = parts.First(x => x.Contains(KnownOAuthParameters.oauth_token_secret.ToString()));
            OauthTokenSecret = result.Substring(result.IndexOf('=') + 1);

            result = parts.First(x => x.Contains(KnownOAuthParameters.oauth_expires_in.ToString()));
            OauthExpiresIn = result.Substring(result.IndexOf('=') + 1);

            result = parts.First(x => x.Contains(KnownOAuthParameters.xoauth_request_auth_url.ToString()));
            XoauthRequestAuthUrl = result.Substring(result.IndexOf('=') + 1);

            result = parts.First(x => x.Contains(KnownOAuthParameters.oauth_token.ToString()));
            OauthToken = result.Substring(result.IndexOf('=') + 1);

            result = parts.First(x => x.Contains(KnownOAuthParameters.oauth_callback_confirmed.ToString()));
            OauthCallbackConfirmed = result.Substring(result.IndexOf('=') + 1);
        }
    }
}
