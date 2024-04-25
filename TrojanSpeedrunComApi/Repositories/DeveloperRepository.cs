using RestSharp;
using TrojanSpeedrunComApi.Framework.Extensions;
using TrojanSpeedrunComApi.Interfaces;
using TrojanSpeedrunComApi.Models;
using static TrojanSpeedrunComApi.Framework.Helpers.EnvironmentHelper;

namespace TrojanSpeedrunComApi.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        protected IConfiguration _configuration { get; private set; }

        public DeveloperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Developer> GetDeveloper(string developerId)
        {
            var client = GetSpeedrunDotComClient();
            var request = new RestRequest($"developers/{developerId}", Method.Get);
            var response = await client.ExecuteAsync(request);
            var developerWrapper = response.Content.FromJson<DeveloperWrapper>();

            return developerWrapper.data;
        }

        private RestClient GetSpeedrunDotComClient()
        {
            var baseUrl = _configuration.GetSection(AppSettings.SpeedrunComApiBaseUrl.ToString()).Value;
            return new RestClient(baseUrl);
        }
    }
}
