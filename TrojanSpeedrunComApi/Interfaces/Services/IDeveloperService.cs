using TrojanSpeedrunComApi.Models;

namespace TrojanSpeedrunComApi.Interfaces
{
    public interface IDeveloperService
    {
        public Task<Developer> GetDeveloper(string id);
    }
}
