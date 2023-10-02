﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class User : BaseEntity
    {
        [MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }
        public virtual IEnumerable<Post>? Posts { get; set; }

        public virtual IEnumerable<Comment>? Comments { get; set; }

        public virtual IEnumerable<Follow>? Followers { get; set; }

        public virtual IEnumerable<Follow>? Follows { get; set; }
    }
}
