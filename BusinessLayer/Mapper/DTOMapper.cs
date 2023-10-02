using BusinessLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapper
{
    public static class DTOMapper
    {
        public static CommentSummaryDTO MapToCommentDTO(this Comment comment)
        {
            return new CommentSummaryDTO
            {
                CommentId = comment.Id,
                Content = comment.Content,
                PostId = comment.PostId,
                UserId = comment.UserId,
            };
        }

        public static PostDTO MapToPostDTO(this Post post)
        {
            return new PostDTO
            {
                Content = post.Content,
                Title = post.Title,
                PostId = post.Id,
                UserId = post.UserId,
                Comments = post.Comments?.Select(a => a.MapToCommentDTO())
            };
        }

        public static PostSummaryDTO MapToPostSummaryDTO(this Post post)
        {
            return new PostSummaryDTO
            {
                Content = post.Content,
                Title = post.Title,
                PostId = post.Id,
                UserId = post.UserId,
                CommentCount = post.Comments?.Count() ?? 0,
            };
        }

        public static FollowSummaryDTO MapToFollowDTO(this Follow follow)
        {
            return new FollowSummaryDTO
            {
                FolloweeId = follow.FolloweeId,
                FollowerId = follow.FollowerId,
                FollowId = follow.Id,
            };
        }

        public static UserSummaryDTO MapToUserSummaryDTO(this User user)
        {
            return new UserSummaryDTO
            {
                UserId = user.Id,
                Username = user.Username,
                PostSummaries = user.Posts?.Select(post => post.MapToPostSummaryDTO()),
                CommentCount = user.Comments?.Count() ?? 0,
                FollowerCount = user.Followers?.Count() ?? 0,
                FollowCount = user.Follows?.Count() ?? 0,
            };
        }
    }
}
