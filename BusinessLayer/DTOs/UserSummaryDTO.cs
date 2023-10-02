using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class UserSummaryDTO
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public IEnumerable<PostSummaryDTO>? PostSummaries { get; set; }

        public int CommentCount { get; set; }

        public int FollowerCount { get; set; }

        public int FollowCount { get; set; }
    }
}
