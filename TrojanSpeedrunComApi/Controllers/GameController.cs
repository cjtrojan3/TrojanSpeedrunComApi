using Microsoft.AspNetCore.Mvc;
using TrojanSpeedrunComApi.Interfaces;
using TrojanSpeedrunComApi.Models;

namespace TrojanSpeedrunComApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Game))]
        public async Task<IActionResult> GetGame(string id)
        {
            return Ok(await _gameService.GetGame(id));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(List<Game>))]
        public async Task<IActionResult> SearchGames(SearchGames searchGames)
        {
            return Ok(await _gameService.SearchGames(searchGames.Name, searchGames.ReleasedDate));
        }
    }
}
