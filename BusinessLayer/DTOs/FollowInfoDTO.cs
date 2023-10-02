using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class FollowInfoDTO
    {
        public int FollowerId { get; set; }
        public UserSummaryDTO? User { get; set; }
        public bool WasSuccessful { get; set; }
    }
}
