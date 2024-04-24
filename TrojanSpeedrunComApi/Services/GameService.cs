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

        public async Task<Game> GetGame(string id)
        {
            return await _gameRepository.GetGame(id);
        }
    }
}
