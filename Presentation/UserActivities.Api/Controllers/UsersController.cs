using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserActivities.Application.Dtos;
using UserActivities.Application.Services;

namespace UserActivities.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IActivityService _activityService;
        public UsersController(IUserService userService, IActivityService activityService)
        {
            _userService = userService;
            _activityService = activityService;
        }


        [HttpGet]
        [Route("/users/{userId}")]
        public async Task<IActionResult> Get(int userId, [FromQuery] UserActivityFilterDTO Filter)
        {

            var result = await _activityService.GetActivityListByFilter(new ActivityFilterDTO { UserId = userId, ActivityType=Filter.ActivityType, EndDate=Filter.EndDate, StartDate=Filter.StartDate });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserSaveDTO Model)
        {

            var result = await _userService.AddUserAsync(Model);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserUpdateDTO Model)
        {

            var result = await _userService.UpdateUser(Model);

            return Ok(result);
        }
    }
}
