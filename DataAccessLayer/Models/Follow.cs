using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Follow : BaseEntity
    {
        public int FollowerId { get; set; }

        [ForeignKey(nameof(FollowerId))]
        public virtual User Follower { get; set; }

        public int FolloweeId { get; set; }

        [ForeignKey(nameof(FolloweeId))]
        public virtual User Followee { get; set; }
    }
}
