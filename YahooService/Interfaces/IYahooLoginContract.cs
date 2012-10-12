using System.ServiceModel;
using System.ServiceModel.Web;

namespace YahooService
{
    /// <summary>
    /// URI Templates for all oauth login portions
    /// </summary>
    [ServiceContract]
    public interface IYahooLoginContract
    {
        [OperationContract]
        [WebInvoke(
            UriTemplate = "get_request_token?oauth_callback=oob&oauth_consumer_key={consumer_key}&oauth_nonce={nonce}&oauth_signature_method=HMAC-SHA1&oauth_timestamp={timestamp}&oauth_version=1.0&oauth_signature={signature}",
            Method = "GET")]
        System.IO.Stream GetRequestToken(string consumer_key, string nonce, string timestamp, string signature);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "get_token?oauth_consumer_key={consumerkey}&oauth_nonce={nonce}&oauth_signature_method=HMAC-SHA1&oauth_timestamp={timestamp}&oauth_version=1.0&oauth_verifier={verifier}&oauth_token={token}&oauth_signature={signature}",
            Method = "GET")]
        System.IO.Stream GetAccessToken(string consumerKey, string nonce, string timestamp, string verifier, string token, string signature);
    }
}