using TrojanSpeedrunComApi.Framework.Extensions;
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
            game.Developers = await _developerRepository.GetDevelopers(game.DeveloperIds);
            return game;
        }

        public async Task<List<Game>> SearchGames(string name, int? releasedYear = null)
        {
            var games = await _gameRepository.SearchGames(name, releasedYear);
            var developerIds = games.SelectMany(x => x.DeveloperIds).Distinct().ToList();
            var developers = await _developerRepository.GetDevelopers(developerIds);
            foreach(var game in games)
            {
                if (game.DeveloperIds.Any())
                    game.Developers.AddRange(developers.Where(y => game.DeveloperIds.Contains(y.Id)));
            }

            return games;
        }
    }
}
