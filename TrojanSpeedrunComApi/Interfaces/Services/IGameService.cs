using TrojanSpeedrunComApi.Models;

namespace TrojanSpeedrunComApi.Interfaces
{
    public interface IGameService
    {
        Task<Game> GetGame(string id);
        Task<List<Game>> SearchGames(string name, int? releasedYear = null);
    }
}
