using System.ServiceModel;

namespace YahooService
{
    /// <summary>
    /// This is the internal class which handles the direct requests through WCF
    /// These requests simply return strings and we can return them as C# Streams
    /// </summary>
    internal class InternalLoginContract : ClientBase<IYahooLoginContract>, IYahooLoginContract
    {
        /// <summary>
        /// First step of the oauth service is to get the request token
        /// </summary>
        /// <param name="consumer_key"></param>
        /// <param name="nonce"></param>
        /// <param name="timestamp"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public System.IO.Stream GetRequestToken(string consumer_key, string nonce, string timestamp, string signature)
        {
            return Channel.GetRequestToken(consumer_key, nonce, timestamp, signature);
        }

        /// <summary>
        /// Second phase is to get the acces token using the given verifier from the user
        /// </summary>
        /// <param name="consumerKey"></param>
        /// <param name="nonce"></param>
        /// <param name="timestamp"></param>
        /// <param name="verifier"></param>
        /// <param name="token"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public System.IO.Stream GetAccessToken(string consumerKey, string nonce, string timestamp, string verifier, string token, string signature)
        {
            return Channel.GetAccessToken(consumerKey, nonce, timestamp, verifier, token, signature);
        }
    }
}
