using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooService
{
    public interface IService
    {
        Task GetAccessToken(string verifier);
        Task<fantasy_content> GetLeagueResource(string leagueId, string subresource);
        Task<string> GetRequestToken();
        Task<fantasy_content> GetUserResourceGames();
        Task<fantasy_content> GetUserResourceLeagues(System.Collections.Generic.List<string> games);
        Task<fantasy_content> GetUserResourcesTeams(System.Collections.Generic.List<string> games);
        Task<fantasy_content> GetUsersCollection();
    }
}
