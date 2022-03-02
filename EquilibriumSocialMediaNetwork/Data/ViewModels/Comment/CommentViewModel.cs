﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.Comment
{
    public class CommentViewModel
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public Entities.User User { get; set; }
    }
}
