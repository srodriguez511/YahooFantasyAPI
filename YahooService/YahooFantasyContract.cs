using System.ServiceModel;
using System.Xml.Linq;

namespace YahooService
{
    /// <summary>
    /// Makes all fantasy api calls
    /// </summary>
    internal class InternalFantasyContract : ClientBase<IYahooFantasyContract>, IYahooFantasyContract
    {
        /// <summary>
        /// Obtains the user information for the currently logged in user of the applications
        /// </summary>
        /// <param name="consumerKey"></param>
        /// <param name="nonce"></param>
        /// <param name="timestamp"></param>
        /// <param name="token"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public fantasy_content GetUsersCollection(string consumerKey, string nonce, string timestamp, string token, string signature)
        {
            return Channel.GetUsersCollection(consumerKey, nonce, timestamp, token, signature);
        }

        /// <summary>
        /// A subresource of the users collection which returns all the yahoo 'games' the logged in user participated in
        /// </summary>
        /// <param name="consumerKey"></param>
        /// <param name="nonce"></param>
        /// <param name="timestamp"></param>
        /// <param name="token"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public fantasy_content GetUserResourceGames(string consumerKey, string nonce, string timestamp, string token, string signature)
        {
            return Channel.GetUserResourceGames(consumerKey, nonce, timestamp, token, signature);
        }

        /// <summary>
        /// A subresource of the users collection which returns the yahoo leages for a parcticular game(s) the user played in
        /// </summary>
        /// <param name="gameKeys"></param>
        /// <param name="consumerKey"></param>
        /// <param name="nonce"></param>
        /// <param name="timestamp"></param>
        /// <param name="token"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public fantasy_content GetUserResourceLeagues(string gameKeys, string consumerKey, string nonce, string timestamp, string token, string signature)
        {
            return Channel.GetUserResourceLeagues(gameKeys, consumerKey, nonce, timestamp, token, signature);
        }

        /// <summary>
        /// A subresource of the users collection which returns the teams for a particular set of games the user is in
        /// </summary>
        /// <param name="gameKeys"></param>
        /// <param name="consumerKey"></param>
        /// <param name="nonce"></param>
        /// <param name="timestamp"></param>
        /// <param name="token"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public fantasy_content GetUserResourceTeams(string gameKeys, string consumerKey, string nonce, string timestamp, string token, string signature)
        {
            return Channel.GetUserResourceTeams(gameKeys, consumerKey, nonce, timestamp, token, signature);
        }

        /// <summary>
        /// The base league call which returns information for a particular league
        /// </summary>
        /// <param name="leagueKey">{a}.{b}.{c} where a=gameid, b=l(lowercase letter NOT #numeric 1), c=leagueid</param>
        /// <param name="consumerKey"></param>
        /// <param name="nonce"></param>
        /// <param name="timestamp"></param>
        /// <param name="token"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public fantasy_content GetLeagueResource(string subresource, string leagueKey, string consumerKey, string nonce, string timestamp, string token, string signature)
        {
            return Channel.GetLeagueResource(subresource, leagueKey, consumerKey, nonce, timestamp, token, signature);
        }
    }
}
