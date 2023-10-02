using BusinessLayer.DTOs;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IUserService : IBaseService
    {
        public Task<bool> DoesUsersExistAsync(params int[] userIds);

        public Task<List<UserSummaryDTO>> GetUsersAsync(
            int[]? userIds = null,
            bool includePosts = true,
            bool includeComments = true,
            bool includeFollowTable = true);

        public Task<UserSummaryDTO?> GetUserSummaryModelAsync(
            int userId,
            bool includePosts = true,
            bool includeComments = true,
            bool includeFollowTable = true);

        public Task<bool> DeleteUserByIdAsync(int userId, bool save = true);
    }
}
