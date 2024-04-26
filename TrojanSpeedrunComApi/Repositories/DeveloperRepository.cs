using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;

        public DeveloperRepository(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _memoryCache = memoryCache;
        }

        public async Task<Developer> GetDeveloper(string developerId)
        {
            if (developerId.IsNullOrEmpty())
                return null;

            if (_memoryCache.TryGetValue(developerId, out Developer cachedDeveloper))
                return cachedDeveloper;

            var client = GetSpeedrunDotComClient();
            var request = new RestRequest($"developers/{developerId}", Method.Get);
            var response = await client.ExecuteAsync(request);
            var srcDeveloper = response.Content.FromJson<DeveloperWrapper>().data;
            var developer = Developer.MapFrom(srcDeveloper);

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

            _memoryCache.Set(developer.Id, developer, cacheOptions);

            return developer;
        }

        public async Task<List<Developer>> GetDevelopers(List<string> developerIds)
        {
            var developers = new List<Developer>();
            foreach(var developerId in developerIds)
            {
                // TODO - make calls asyncronously
                developers.Add(await GetDeveloper(developerId));
            }
            return developers;
        }

        private RestClient GetSpeedrunDotComClient()
        {
            var baseUrl = _configuration.GetSection(AppSettings.SpeedrunComApiBaseUrl.ToString()).Value;
            return new RestClient(baseUrl);
        }
    }
}
