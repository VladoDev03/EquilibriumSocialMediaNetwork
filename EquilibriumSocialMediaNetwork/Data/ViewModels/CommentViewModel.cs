﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class CommentViewModel
    {
        public string Content { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}