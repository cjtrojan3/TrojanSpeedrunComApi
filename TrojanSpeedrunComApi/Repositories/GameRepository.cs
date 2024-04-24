using RestSharp;
using TrojanSpeedrunComApi.Framework.Extensions;
using TrojanSpeedrunComApi.Interfaces;
using TrojanSpeedrunComApi.Models;
using static TrojanSpeedrunComApi.Framework.Helpers.EnvironmentHelper;

namespace TrojanSpeedrunComApi.Repositories
{
    public class GameRepository : IGameRepository
    {
        //private EnvironmentHelper _environmentHelper { get; set; }
        protected IConfiguration _configuration { get; private set; }

        public GameRepository(IConfiguration configuration)//EnvironmentHelper environmentHelper)
        {
            //_environmentHelper = environmentHelper;
            _configuration = configuration;
        }

        public async Task<Game> GetGame(string id)
        {
            var baseUrl = _configuration.GetSection(AppSettings.SpeedrunComApiBaseUrl.ToString()).Value;//_environmentHelper.GetAppSetting(AppSettings.SpeedrunComApiBaseUrl);
            var client = new RestClient(baseUrl);
            try
            {
                var request = new RestRequest($"games/{id}", Method.Get);

                var response = await client.ExecuteAsync(request);

                var games = response.Content.FromJson<Game>();

                return games;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }
    }
}
