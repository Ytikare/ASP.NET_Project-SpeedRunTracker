using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Services.Interfaces;

namespace SpeedRunTracker.Web.Api.Controllers
{
    [Route("api/games/{value?}")]
    [ApiController]
    public class GamesApiController : ControllerBase
    {
        private readonly IGameService gameService;

        public GamesApiController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SpeedRunSelectGameFormModel>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetGames(string value)
        {
            try
            {
                IEnumerable<SpeedRunSelectGameFormModel> games = await this.gameService.GetAllGameTitlesAsync(value);
                return Ok(games);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
