using DatsMagic.Models.Responses;
using DatsMagic.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatsMagic.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger, GameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [HttpGet]
        [ProducesResponseType<GameState>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGameState()
        {
            var gameState = await _gameService.GetGameStateAsync();
            return Ok(gameState);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SetLogsAsDataSource([FromBody] bool isDataFromLogs)
        {
            _gameService.IsDataFromLogs = isDataFromLogs;
            return Ok();
        }
    }
}
