using BusinessLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapper
{
    public static class EntityMapper
    {
        public static Comment MapToComment(this CommentSummaryDTO comment)
        {
            return new Comment
            {
                Id = comment.CommentId,
                Content = comment.Content,
                PostId = comment.PostId,
                UserId = comment.UserId,
            };
        }

        public static Post MapToPost(this PostDTO post)
        {
            return new Post
            {
                Content = post.Content,
                Title = post.Title,
                Id = post.PostId,
                UserId = post.UserId,
                Comments = post.Comments?.Select(a => a.MapToComment())
            };
        }

        public static Follow MapToFollow(this FollowSummaryDTO follow)
        {
            return new Follow
            {
                FolloweeId = follow.FolloweeId,
                FollowerId = follow.FollowerId,
                Id = follow.FollowId,
            };
        }
    }
}
