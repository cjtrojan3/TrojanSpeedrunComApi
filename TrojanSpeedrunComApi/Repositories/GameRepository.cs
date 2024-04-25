using RestSharp;
using TrojanSpeedrunComApi.Framework.Extensions;
using TrojanSpeedrunComApi.Interfaces;
using TrojanSpeedrunComApi.Models;
using static TrojanSpeedrunComApi.Framework.Helpers.EnvironmentHelper;

namespace TrojanSpeedrunComApi.Repositories
{
    public class GameRepository : IGameRepository
    {
        protected IConfiguration _configuration { get; private set; }

        public GameRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Game> GetGame(string gameId)
        {
            var client = GetSpeedrunDotComClient();
            var request = new RestRequest($"games/{gameId}", Method.Get);
            var response = await client.ExecuteAsync(request);
            var gameWrapper = response.Content.FromJson<GameWrapper>();

            return gameWrapper.data;
        }

        public async Task<List<Game>> SearchGames(string name, int? releasedYear = null)
        {
            var client = GetSpeedrunDotComClient();
            var request = new RestRequest($"games", Method.Get);

            if (name != null)
                request.AddParameter("name", name);
            
            if (releasedYear.HasValue)
                request.AddParameter("released", releasedYear.Value);

            var response = await client.ExecuteAsync(request);

            var gameListWrapper = response.Content.FromJson<GameSearchWrapper>();

            return gameListWrapper.data;
        }

        private RestClient GetSpeedrunDotComClient()
        {
            var baseUrl = _configuration.GetSection(AppSettings.SpeedrunComApiBaseUrl.ToString()).Value;
            return new RestClient(baseUrl);
        }
    }
}
