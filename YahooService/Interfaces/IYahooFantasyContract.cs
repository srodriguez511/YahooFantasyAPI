using System.ServiceModel;
using System.ServiceModel.Web;
using System.Xml.Linq;
using System;

namespace YahooService
{
    /// <summary>
    /// All fantasy API calls are placed here
    /// </summary>
    [ServiceContract]
    public interface IYahooFantasyContract
    {
        [OperationContract]
        [WebGet(
          UriTemplate = "users;use_login=1?oauth_consumer_key={consumerkey}&oauth_nonce={nonce}&oauth_signature_method=HMAC-SHA1&oauth_timestamp={timestamp}&oauth_version=1.0&oauth_token={token}&oauth_signature={signature}",
          ResponseFormat = WebMessageFormat.Xml,
          BodyStyle = WebMessageBodyStyle.Bare)]
        [XmlSerializerFormat]
        fantasy_content GetUsersCollection(string consumerKey, string nonce, string timestamp, string token, string signature);

        [OperationContract]
        [WebGet(
          UriTemplate = "users;use_login=1/games?oauth_consumer_key={consumerkey}&oauth_nonce={nonce}&oauth_signature_method=HMAC-SHA1&oauth_timestamp={timestamp}&oauth_version=1.0&oauth_token={token}&oauth_signature={signature}",
          ResponseFormat = WebMessageFormat.Xml,
          BodyStyle = WebMessageBodyStyle.Bare)]
        [XmlSerializerFormat]
        fantasy_content GetUserResourceGames(string consumerKey, string nonce, string timestamp, string token, string signature);

        [OperationContract]
        [WebGet(
          UriTemplate = "users;use_login=1/games;game_keys={gameKeys}/leagues?oauth_consumer_key={consumerkey}&oauth_nonce={nonce}&oauth_signature_method=HMAC-SHA1&oauth_timestamp={timestamp}&oauth_version=1.0&oauth_token={token}&oauth_signature={signature}",
          ResponseFormat = WebMessageFormat.Xml,
          BodyStyle = WebMessageBodyStyle.Bare)]
        [XmlSerializerFormat]
        fantasy_content GetUserResourceLeagues(string gameKeys, string consumerKey, string nonce, string timestamp, string token, string signature);

        [OperationContract]
        [WebGet(
          UriTemplate = "users;use_login=1/games;game_keys={gameKeys}/teams?oauth_consumer_key={consumerkey}&oauth_nonce={nonce}&oauth_signature_method=HMAC-SHA1&oauth_timestamp={timestamp}&oauth_version=1.0&oauth_token={token}&oauth_signature={signature}",
          ResponseFormat = WebMessageFormat.Xml,
          BodyStyle = WebMessageBodyStyle.Bare)]
        [XmlSerializerFormat]
        fantasy_content GetUserResourceTeams(string gameKeys, string consumerKey, string nonce, string timestamp, string token, string signature);


        //----league info
        [OperationContract]
        [WebGet(
          UriTemplate = "league/{leaguekey}/{subresource}?oauth_consumer_key={consumerkey}&oauth_nonce={nonce}&oauth_signature_method=HMAC-SHA1&oauth_timestamp={timestamp}&oauth_version=1.0&oauth_token={token}&oauth_signature={signature}",
          ResponseFormat = WebMessageFormat.Xml,
          BodyStyle = WebMessageBodyStyle.Bare)]
        [XmlSerializerFormat]
        fantasy_content GetLeagueResource(string subresource, string leagueKey, string consumerKey, string nonce, string timestamp, string token, string signature);


        
    }
}
