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
        [ProducesResponseType(200, Type = typeof(List<Game>))]
        public async Task<IActionResult> GetGames(string id)
        {
            return Ok(await _gameService.GetGame(id));
        }
    }
}
