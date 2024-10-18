using BusinessLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    public class UserSolutionController : Controller
    {
        private readonly IUserService _userService;

        public UserSolutionController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("[controller]/fetch/summary")]
        public async Task<IActionResult> FetchAllSummary()
        {
            return Ok(await _userService.GetUsersAsync());
        }

        [HttpGet]
        [Route("[controller]/fetch/user/summary")]
        public async Task<IActionResult> FetchUserSummary(int userId)
        {
            var user = await _userService.GetUserSummaryModelAsync(userId);

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [HttpDelete]
        [Route("[controller]/delete")]
        public async Task<IActionResult> Delete(int userId)
        {
            var wasDeleted = await _userService.DeleteUserByIdAsync(userId);

            if (!wasDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
