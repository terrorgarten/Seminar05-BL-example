using BusinessLayer.DTOs;
using BusinessLayer.Mapper;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly SeminarDBContext _dBContext;

        public UserService(SeminarDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<bool> DoesUsersExistAsync(params int[] userIds)
        {
            userIds = userIds.Distinct()
                .ToArray();

            var users = await _dBContext.Users
                .Where(a => userIds.Contains(a.Id))
                .Select(a => a.Id)
                .ToListAsync();
            
            var count = users.Count == userIds.Length;

            return count && users
                .OrderBy(a => a)
                .SequenceEqual(userIds.OrderBy(a => a));
        }

        public async Task<List<UserSummaryDTO>> GetUsersAsync(
            int[]? userIds = null,
            bool includePosts = true,
            bool includeComments = true,
            bool includeFollowTable = true)
        {
            var query = GetBaseQuery(includePosts, includeComments, includeFollowTable);

            if (userIds != null && userIds.Length > 0)
            {
                query = query.Where(a => userIds.Contains(a.Id));
            }

            var users = await query
                .ToListAsync();

            if (users == null)
            {
                return new();
            }

            return users
                .Select(user => user.MapToUserSummaryDTO())
                .ToList();
        }

        public async Task<UserSummaryDTO?> GetUserSummaryModelAsync(
            int userId,
            bool includePosts = true,
            bool includeComments = true,
            bool includeFollowTable = true)
        {
            var user = await GetBaseQuery(includePosts, includeComments, includeFollowTable)
                .FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null)
            {
                return null;
            }

            return user.MapToUserSummaryDTO();
        }

        public async Task<bool> DeleteUserByIdAsync(int userId, bool save = true)
        {
            var user = await _dBContext.Users
                .SingleOrDefaultAsync(a => a.Id == userId);

            if (user == null)
            {
                return false;
            }

            _dBContext.Users.Remove(user);
            await SaveAsync(save);

            return true;
        }

        private IQueryable<User> GetBaseQuery(bool includePosts, bool includeComments, bool includeFollowTable)
        {
            IQueryable<User> userQuery = _dBContext.Users;

            if (includePosts)
            {
                userQuery = userQuery
                    .Include(user => user.Posts);
            }

            if (includeComments)
            {
                userQuery = userQuery
                    .Include(user => user.Comments);
            }

            if (includeFollowTable)
            {
                userQuery = userQuery
                    .Include(user => user.Follows)
                    .Include(user => user.Followers);
            }

            return userQuery;
        }
    }
}
