using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserActivities.Application.Dtos;
using UserActivities.Application.Services;

namespace UserActivities.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly  IActivityService _activityService;
        public ActivitiesController(IActivityService activityService) { 
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ActivityFilterDTO? Filter)
        {
            var result = await _activityService.GetActivityListByFilter(Filter);
            return Ok(result);
        }

        [HttpPost]
        public  async Task<IActionResult> Post(ActivitySaveDTO Model)
        {
            
            var result = await _activityService.AddActivity(Model);
            
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ActivityUpdateDTO Model)
        {

            var result = await _activityService.UpdateActivity(Model);

            return Ok(result);
        }
    }
}
