using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Services.Data.Models.Statistic;
using Microsoft.AspNetCore.Mvc;

namespace KindergartenSystem.Web.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;
        public StatisticsApiController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                StatisticsServiceModel model = await _statisticsService.Statistics();
                return Ok(model);
            }
            catch (Exception)
            {

                return StatusCode(400);
            }
        }
    }
}
