using System;
using System.Collections.Generic;
using System.IO;
using OAuth;
using System.Web;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using YahooService;

namespace YahooService
{
    /// <summary>
    /// This is the public user interface into the yahoo service we provide
    /// Login calls use WCF
    /// API calls use WebClient
    /// </summary>
    public class YahooService : IService
    {
        /// <summary>
        /// Instance of our oauth library
        /// </summary>
        private readonly OAuthLib _oauthLib = new OAuthLib();

        /// <summary>
        /// The internal class which handles how we internally request the data.
        /// </summary>
        private readonly InternalLoginContract _ics = new InternalLoginContract();

        /// <summary>
        /// Internal class which handles how we internally request the data
        /// </summary>
        private readonly InternalFantasyContract _ifc = new InternalFantasyContract();

        /// <summary>
        /// Get the request token using the internal contract service
        /// </summary>
        /// <returns></returns>
        public Task<string> GetRequestToken()
        {
            return new Task<string>(() =>
            {
                const string METHOD_NAME = "/get_request_token";
                var nonceString = _oauthLib.Nonce;
                var timestampString = _oauthLib.Timestamp;

                var parameters = new List<UrlParameter>();
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_nonce, nonceString));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_timestamp, timestampString));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_consumer_key, _oauthLib.consumerKey));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_signature_method, _oauthLib.SignatureMethod));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_version, _oauthLib.OauthVersion));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_callback, _oauthLib.Oob));

                try
                {
                    string mySignature = _oauthLib.GetSignature(_oauthLib.BASE_LOGIN_URL + METHOD_NAME, parameters, "GET", String.Empty, String.Empty);
                    var sr = new StreamReader(_ics.GetRequestToken(_oauthLib.consumerKey, nonceString, timestampString, mySignature));
                    var response = sr.ReadToEnd();
                    _oauthLib.RequestToken = new RequestToken(response);
                    return _oauthLib.RequestToken.XoauthRequestAuthUrl;
                }
                catch (Exception e)
                {
                    throw new Exception("Failed to get request token " + e.Message);
                }

            });
        }

        /// <summary>
        /// The final step of the oauth procedure is to obtain the access token 
        /// </summary>
        public Task GetAccessToken(string verifier)
        {
            return new Task(() =>
            {
                const string METHOD_NAME = "/get_token";
                string nonceString = _oauthLib.Nonce;
                string timestampString = _oauthLib.Timestamp;

                var parameters = new List<UrlParameter>();
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_nonce, nonceString));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_timestamp, timestampString));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_consumer_key, _oauthLib.consumerKey));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_signature_method, _oauthLib.SignatureMethod));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_version, _oauthLib.OauthVersion));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_verifier, verifier));

                try
                {
                    var mySignature = _oauthLib.GetSignature(_oauthLib.BASE_LOGIN_URL + METHOD_NAME, parameters, "GET", _oauthLib.RequestToken.OauthToken, _oauthLib.RequestToken.OauthTokenSecret);
                    var sr = new StreamReader(_ics.GetAccessToken(_oauthLib.consumerKey, nonceString, timestampString, verifier, _oauthLib.RequestToken.OauthToken, mySignature));
                    var response = sr.ReadToEnd();
                    if (response != null)
                    {
                        _oauthLib.AccessToken = new AccessToken(response);
                    }
                    else
                    {
                        throw new Exception("Failed to get request token");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Failed to get request token " + e.Message);
                }
            });
        }

        /// <summary>
        /// Users resource collection call
        /// </summary>
        /// <returns></returns>
        public Task<fantasy_content> GetUsersCollection()
        {
            return new Task<fantasy_content>(() =>
            {
                const string METHOD_NAME = "/users;use_login=1";
                var nonceString = _oauthLib.Nonce;
                var timestampString = _oauthLib.Timestamp;

                var parameters = new List<UrlParameter>();
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_nonce, nonceString));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_timestamp, timestampString));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_consumer_key, _oauthLib.consumerKey));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_signature_method, _oauthLib.SignatureMethod));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_version, _oauthLib.OauthVersion));

                try
                {
                    var mySignature = _oauthLib.GetSignature(_oauthLib.BASE_FANTASY_URL + METHOD_NAME, parameters, "GET", _oauthLib.AccessToken.oauth_token, _oauthLib.AccessToken.oauth_token_secret);
                    return _ifc.GetUsersCollection(_oauthLib.consumerKey, nonceString, timestampString, _oauthLib.AccessToken.oauth_token, mySignature);
                }
                catch (Exception)
                {
                    throw;
                }

            });
        }

        /// <summary>
        /// Users resource collection call
        /// </summary>
        /// <returns></returns>
        public Task<fantasy_content> GetUserResourceGames()
        {
            return new Task<fantasy_content>(() =>
            {

                const string METHOD_NAME = "/users;use_login=1/games";
                var nonceString = _oauthLib.Nonce;
                var timestampString = _oauthLib.Timestamp;

                var parameters = new List<UrlParameter>();
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_nonce, nonceString));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_timestamp, timestampString));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_consumer_key, _oauthLib.consumerKey));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_signature_method, _oauthLib.SignatureMethod));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_version, _oauthLib.OauthVersion));

                try
                {
                    var mySignature = _oauthLib.GetSignature(_oauthLib.BASE_FANTASY_URL + METHOD_NAME, parameters, "GET", _oauthLib.AccessToken.oauth_token, _oauthLib.AccessToken.oauth_token_secret);
                    return _ifc.GetUserResourceGames(_oauthLib.consumerKey, nonceString, timestampString, _oauthLib.AccessToken.oauth_token, mySignature);
                }
                catch (Exception)
                {
                    throw;
                }
            });
        }

        /// <summary>
        /// Given a set of games, we can return the league resources associated with them
        /// </summary>
        /// <returns></returns>
        public Task<fantasy_content> GetUserResourceLeagues(List<string> games)
        {
            return new Task<fantasy_content>(() =>
            {
                if (games == null || games.Count == 0)
                {
                    throw new ArgumentException("No games supplied");
                }

                const string BASE_METHOD = "/users;use_login=1/games;game_keys=";
                const string LEAGUES = "/leagues";

                var gamesStr = String.Empty;
                foreach (var game in games)
                {
                    gamesStr += game;
                    gamesStr += ",";
                }
                gamesStr = gamesStr.TrimEnd(',');
                var methodName = BASE_METHOD + gamesStr + LEAGUES;

                var nonceString = _oauthLib.Nonce;
                var timestampString = _oauthLib.Timestamp;

                var parameters = new List<UrlParameter>();
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_nonce, nonceString));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_timestamp, timestampString));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_consumer_key, _oauthLib.consumerKey));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_signature_method, _oauthLib.SignatureMethod));
                parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_version, _oauthLib.OauthVersion));
                try
                {
                    var mySignature = _oauthLib.GetSignature(_oauthLib.BASE_FANTASY_URL + methodName, parameters, "GET", _oauthLib.AccessToken.oauth_token, _oauthLib.AccessToken.oauth_token_secret);
                    return _ifc.GetUserResourceLeagues(gamesStr, _oauthLib.consumerKey, nonceString, timestampString, _oauthLib.AccessToken.oauth_token, mySignature);
                }
                catch (Exception)
                {
                    throw;
                }
            });
        }


        /// <summary>
        /// Given a set of games from the user, we can request all of the teams owned by them
        /// </summary>
        /// <param name="games"></param>
        /// <returns></returns>
        public Task<fantasy_content> GetUserResourcesTeams(List<string> games)
        {
            return new Task<fantasy_content>(() =>
               {
                   if (games == null || games.Count == 0)
                   {
                       return null;
                   }

                   const string BASE_METHOD = "/users;use_login=1/games;game_keys=";
                   const string TEAMS = "/teams";

                   var gamesStr = String.Empty;
                   foreach (var game in games)
                   {
                       gamesStr += game;
                       gamesStr += ",";
                   }
                   gamesStr = gamesStr.TrimEnd(',');
                   var methodName = BASE_METHOD + gamesStr + TEAMS;

                   var nonceString = _oauthLib.Nonce;
                   var timestampString = _oauthLib.Timestamp;

                   var parameters = new List<UrlParameter>();
                   parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_nonce, nonceString));
                   parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_timestamp, timestampString));
                   parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_consumer_key, _oauthLib.consumerKey));
                   parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_signature_method, _oauthLib.SignatureMethod));
                   parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_version, _oauthLib.OauthVersion));
                   try
                   {
                       var mySignature = _oauthLib.GetSignature(_oauthLib.BASE_FANTASY_URL + methodName, parameters, "GET", _oauthLib.AccessToken.oauth_token, _oauthLib.AccessToken.oauth_token_secret);
                       return _ifc.GetUserResourceTeams(gamesStr, _oauthLib.consumerKey, nonceString, timestampString, _oauthLib.AccessToken.oauth_token, mySignature);
                   }
                   catch (Exception)
                   {
                       throw;
                   }
               });
        }


        /// <summary>
        /// League resource information
        /// </summary>
        /// <returns></returns>
        public Task<fantasy_content> GetLeagueResource(string leagueId, string subresource)
        {
            return new Task<fantasy_content>(() =>
               {
                   var methodName = "/league/" + leagueId + "/" + subresource;
                   var nonceString = _oauthLib.Nonce;
                   var timestampString = _oauthLib.Timestamp;

                   var parameters = new List<UrlParameter>();
                   parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_nonce, nonceString));
                   parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_timestamp, timestampString));
                   parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_consumer_key, _oauthLib.consumerKey));
                   parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_signature_method, _oauthLib.SignatureMethod));
                   parameters.Add(new UrlParameter(KnownOAuthParameters.oauth_version, _oauthLib.OauthVersion));

                   try
                   {
                       var mySignature = _oauthLib.GetSignature(_oauthLib.BASE_FANTASY_URL + methodName, parameters, "GET", _oauthLib.AccessToken.oauth_token, _oauthLib.AccessToken.oauth_token_secret);
                       return _ifc.GetLeagueResource(subresource, leagueId, _oauthLib.consumerKey, nonceString, timestampString, _oauthLib.AccessToken.oauth_token, mySignature);
                   }
                   catch (Exception)
                   {
                       throw;
                   }
               });
        }



    }
}
