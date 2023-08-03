using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Models.Web.ApiModels;
using SpeedRunTracker.Services.Interfaces;

namespace SpeedRunTracker.Web.Api.Controllers
{
    [Route("api/speedrun")]
    [ApiController]
    public class SpeedRunApiController : ControllerBase
    {
        private readonly ISpeedRunService speedRunService;

        public SpeedRunApiController(ISpeedRunService speedRunService)
        {
            this.speedRunService = speedRunService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SpeedRunModerationViewModel>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetInverifiedSpeedRuns()
        {
            try
            {
                IEnumerable<SpeedRunModerationViewModel> games = await this.speedRunService.GetOldestFiveUnverifiedSpeedRunsAsync();
                return Ok(games);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
