using TrojanSpeedrunComApi.Models;

namespace TrojanSpeedrunComApi.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> GetGame(string id);
    }
}
