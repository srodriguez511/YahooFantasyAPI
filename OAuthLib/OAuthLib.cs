using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Security.Cryptography;

namespace OAuth
{
    /// <summary>
    /// Library to help with all oauth calls with yahoo
    /// </summary>
    public class OAuthLib
    {
        /// <summary>
        /// Allowed http characters
        /// </summary>
        private const string ALLOWED_CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

        /// <summary>
        /// Provided by yahoo
        /// </summary>
        public readonly string consumerKey = "dj0yJmk9VTYwakJlNUo0cW9XJmQ9WVdrOVFVMDFOR1ZNTlRBbWNHbzlNVEEwTXpVMU5UYzJNZy0tJnM9Y29uc3VtZXJzZWNyZXQmeD0zNg--";

        /// <summary>
        /// Provided by yahoo
        /// </summary>
        public readonly string consumerSecret;

        /// <summary>
        /// Base yahoo api url
        /// </summary>
        public readonly string BASE_LOGIN_URL = "https://api.login.yahoo.com/oauth/v2";

        /// <summary>
        /// Base url for the fantasy sports api
        /// </summary>
        public readonly string BASE_FANTASY_URL = "http://fantasysports.yahooapis.com/fantasy/v2";

        /// <summary>
        /// Signature method used in oauth
        /// </summary>
        public readonly string SignatureMethod = "HMAC-SHA1";

        /// <summary>
        /// OAuth version used
        /// </summary>
        public readonly string OauthVersion = "1.0";

        /// <summary>
        /// Out of bounds constant
        /// </summary>
        public readonly string Oob = "oob";

        /// <summary>
        /// The request token in the oauth procedure
        /// </summary>
        public RequestToken RequestToken { get; set; }

        /// <summary>
        /// The final access token step of the procedure
        /// </summary>
        public AccessToken AccessToken { get; set; }

        /// <summary>
        /// Generate a nonce 
        /// </summary>
        public string Nonce
        {
            get
            {
                return new Random().Next(123400, 9999999).ToString();
            }
        }

        /// <summary>
        /// Current timestamp 
        /// </summary>
        public string Timestamp
        {
            get
            {
                var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                return Convert.ToInt64(ts.TotalSeconds).ToString();
            }
        }

        public OAuthLib()
        {
            try
            {
                consumerSecret = System.IO.File.ReadAllText(@"E:\YahooFantasyAPI\consumersecret.secret");
            }
            catch (Exception)
            {
                throw new Exception("Could not retrieve consumer secret!");
            }
        }

        /// <summary>
        /// Sign the current url using the given keys
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <param name="httpMethod"></param>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        public string GetSignature(string url, List<UrlParameter> parameters, string httpMethod, string token, string tokenSecret)
        {
            try
            {
                //Add token if provided
                if (!string.IsNullOrEmpty(token))
                {
                    parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_token, token));
                }

                SortParameters(parameters);

                //normalize the url string
                var reqParams = new StringBuilder();
                foreach (var param in parameters)
                {
                    reqParams.AppendFormat("{0}={1}&", param.Name.ToString(), OAuthUrlEncode(param.Value));
                }
                string normalizedRequestParameters = reqParams.ToString().TrimEnd('&');

                var signatureBase = new StringBuilder();
                signatureBase.AppendFormat("{0}&", httpMethod.ToUpper());
                signatureBase.AppendFormat("{0}&", OAuthUrlEncode(url));
                signatureBase.AppendFormat("{0}", OAuthUrlEncode(normalizedRequestParameters));

                return HMACSHA1Encode(tokenSecret, signatureBase.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Failed to complete signature " + e.Message);
            }
        }

        /// <summary>
        /// HMAC-SHA signature method
        /// </summary>
        /// <param name="tokenSecret"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string HMACSHA1Encode(string tokenSecret, string data)
        {
            try
            {
                var hmacsha1 = new HMACSHA1();
                hmacsha1.Key = Encoding.ASCII.GetBytes(string.Format("{0}&{1}", OAuthUrlEncode(consumerSecret), string.IsNullOrEmpty(tokenSecret) ? "" : OAuthUrlEncode(tokenSecret)));
                byte[] dataBuffer = System.Text.Encoding.ASCII.GetBytes(data.ToString(CultureInfo.InvariantCulture));
                byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
                return Convert.ToBase64String(hashBytes);
            }
            catch (Exception e)
            {
                throw new Exception("Could not complete HMAC " + e.Message);
            }
        }

        /// <summary>
        /// Parameters to sign must be in sorted order
        /// </summary>
        /// <param name="parameters"></param>
        public static void SortParameters(List<UrlParameter> parameters)
        {
            parameters.Sort((q1, q2) => String.CompareOrdinal(q1.Name.ToString(), q2.Name.ToString()));
        }

        /// <summary>
        /// Encode the correct characters for transport
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string OAuthUrlEncode(string value)
        {
            var result = new StringBuilder();
            foreach (var symbol in value)
            {
                if (ALLOWED_CHARS.IndexOf(symbol) != -1)
                {
                    result.Append(symbol);
                }
                else
                {
                    result.Append('%' + String.Format("{0:X2}", (int)symbol));
                }
            }
            return result.ToString();
        }

    }


}
