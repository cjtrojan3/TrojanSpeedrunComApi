using TrojanSpeedrunComApi.Interfaces;
using TrojanSpeedrunComApi.Models;

namespace TrojanSpeedrunComApi.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Game> GetGame(string gameId)
        {
            return await _gameRepository.GetGame(gameId);
        }

        public async Task<List<Game>> SearchGames(string name, int? releasedYear = null)
        {
            return await _gameRepository.SearchGames(name, releasedYear);
        }
    }
}
