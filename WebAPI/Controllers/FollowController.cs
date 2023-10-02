using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    public class FollowController : Controller
    {
        private readonly SeminarDBContext _dBContext;

        public FollowController(SeminarDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpGet]
        [Route("[controller]/user/follow")]
        public async Task<IActionResult> CreateFollow(int userId, int userToFollow)
        {
            var followee = await _dBContext.Users
                .FirstOrDefaultAsync(a => a.Id == userToFollow);

            var follower = await _dBContext.Users
                .FirstOrDefaultAsync(a => a.Id == userId);

            if (followee == null || follower == null)
            {
                return BadRequest();
            }

            if (await _dBContext.Follows.AnyAsync(follow => follow.FolloweeId == userToFollow && follow.FollowerId == userId))
            {
                return BadRequest(new
                {
                    Message = $"The {follower.Username} already follows {followee.Username}",
                });
            }

            var followRow = new Follow()
            {
                Followee = followee,
                Follower = follower,
            };

            _dBContext.Follows.Add(followRow);
            await _dBContext.SaveChangesAsync();

            return Ok(new
            {
                Message = $"Successfully followed the chosen user! ({follower.Username} followed {followee.Username})",
                FollowInfo = new
                {
                    Followee = followee.Id,
                    Follower = follower.Id,
                },
            });
        }

        [HttpGet]
        [Route("[controller]/user/follow/ids")]
        public async Task<IActionResult> CreateFollowIds(int userId, int userToFollow)
        {
            if (await _dBContext.Follows.AnyAsync(follow => follow.FolloweeId == userToFollow && follow.FollowerId == userId))
            {
                return BadRequest(new
                {
                    Message = $"The {userId} already follows {userToFollow}",
                });
            }

            var followRow = new Follow()
            {
                FolloweeId = userToFollow,
                FollowerId = userId,
            };

            _dBContext.Follows.Add(followRow);
            await _dBContext.SaveChangesAsync();

            return Ok(new
            {
                Message = $"Successfully followed the chosen user! ({userId} followed {userToFollow})",
                FollowInfo = new
                {
                    FolloweeId = userToFollow,
                    FollowerId = userId,
                },
            });
        }

        [HttpGet]
        [Route("[controller]/user/unfollow")]
        public async Task<IActionResult> DeleteFollow(int userId, int userToUnfollowId)
        {
            var followRow = await _dBContext.Follows
                .FirstOrDefaultAsync(follow => follow.FolloweeId == userToUnfollowId && follow.FollowerId == userId);

            if (followRow == null)
            {
                return BadRequest();
            }

            var followerUsername = followRow.Follower.Username;
            var followeeUsername = followRow.Followee.Username;

            _dBContext.Follows.Remove(followRow);
            await _dBContext.SaveChangesAsync();
            return Ok(new
            {
                Message = $"Successfully unfollowed the chosen user! ({userId} unfollowed {userToUnfollowId})",
                FollowInfo = new
                {
                    Followee = followeeUsername,
                    Follower = followerUsername,
                },
            });
        }
    }
}
