using TrojanSpeedrunComApi.Interfaces;
using TrojanSpeedrunComApi.Models;

namespace TrojanSpeedrunComApi.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IDeveloperRepository _developerRepository;

        public GameService(IGameRepository gameRepository, IDeveloperRepository developerRepository)
        {
            _gameRepository = gameRepository;
            _developerRepository = developerRepository;
        }

        public async Task<Game> GetGame(string gameId)
        {
            var game = await _gameRepository.GetGame(gameId);

            //if (game.developerIds.Any())
            //    game.developers.Add(await _developerRepository.GetDeveloper(game.developerIds.First()));

            return game;
        }

        public async Task<List<Game>> SearchGames(string name, int? releasedYear = null)
        {
            return await _gameRepository.SearchGames(name, releasedYear);
        }
    }
}
