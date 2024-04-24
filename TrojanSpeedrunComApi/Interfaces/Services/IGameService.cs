using TrojanSpeedrunComApi.Models;

namespace TrojanSpeedrunComApi.Interfaces
{
    public interface IGameService
    {
        Task<Game> GetGame(string id);
    }
}
