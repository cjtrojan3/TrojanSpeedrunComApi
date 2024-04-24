using TrojanSpeedrunComApi.Models;

namespace TrojanSpeedrunComApi.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> GetGame(string id);
        Task<List<Game>> SearchGames(string name = null, int? releasedYear = null);
    }
}
