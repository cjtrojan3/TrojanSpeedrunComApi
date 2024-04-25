using TrojanSpeedrunComApi.Models;

namespace TrojanSpeedrunComApi.Interfaces
{
    public interface IDeveloperRepository
    {
        public Task<Developer> GetDeveloper(string id);
    }
}
