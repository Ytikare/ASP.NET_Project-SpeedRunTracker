using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Services.Interfaces;

namespace SpeedRunTracker.Web.Api.Controllers
{
    [Route("api/users/{value?}")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private IUserService userService;

        public UsersApiController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ModeratorFormModel>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUsernames(string value)
        {
            try
            {
                IEnumerable<ModeratorFormModel> games = await this.userService.GetMatchingUsernamesAsync(value);
                return Ok(games);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
