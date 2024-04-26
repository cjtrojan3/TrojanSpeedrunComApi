using TrojanSpeedrunComApi.Models;

namespace TrojanSpeedrunComApi.Interfaces
{
    public interface IDeveloperRepository
    {
        Task<Developer> GetDeveloper(string id);
        Task<List<Developer>> GetDevelopers(List<string> developerIds);
    }
}
