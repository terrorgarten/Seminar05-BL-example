using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class FollowSummaryDTO
    {
        public int FollowId { get; set; }

        public int FollowerId { get; set; }
        public int FolloweeId { get; set; }
    }
}
