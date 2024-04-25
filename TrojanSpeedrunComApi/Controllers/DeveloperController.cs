using Microsoft.AspNetCore.Mvc;
using TrojanSpeedrunComApi.Interfaces;
using TrojanSpeedrunComApi.Models;

namespace TrojanSpeedrunComApi.Controllers
{
    [Route("api/[controller]")]
    public class DeveloperController : Controller
    {
        private readonly IDeveloperService _developerService;

        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        [HttpGet]
        [Route(nameof(GetDeveloper))]
        [ProducesResponseType(200, Type = typeof(Developer))]
        public async Task<IActionResult> GetDeveloper(string developerId)
        {
            return Ok(await _developerService.GetDeveloper(developerId));
        }
    }
}
