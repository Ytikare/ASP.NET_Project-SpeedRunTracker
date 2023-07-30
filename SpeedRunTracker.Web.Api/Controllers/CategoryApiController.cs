using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Services.Interfaces;

namespace SpeedRunTracker.Web.Api.Controllers
{
    [Route("api/category/{gameId}")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryApiController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SpeedRunSelectCategoryFormModel>))]
        public async Task<IActionResult> GetCategories(int gameId)
        {
            try
            {
                IEnumerable<SpeedRunSelectCategoryFormModel> data = await categoryService.GetCategoriesAsync(gameId);
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
    }
}
