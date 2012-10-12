using System;
using YahooService;

namespace YahooMVVM.Design
{
    public class DesignDataService : IService
    {
        public System.Threading.Tasks.Task GetAccessToken(string verifier)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<fantasy_content> GetLeagueResource(string leagueId, string subresource)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<string> GetRequestToken()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<fantasy_content> GetUserResourceGames()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<fantasy_content> GetUserResourceLeagues(System.Collections.Generic.List<string> games)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<fantasy_content> GetUserResourcesTeams(System.Collections.Generic.List<string> games)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<fantasy_content> GetUsersCollection()
        {
            throw new NotImplementedException();
        }
    }
}