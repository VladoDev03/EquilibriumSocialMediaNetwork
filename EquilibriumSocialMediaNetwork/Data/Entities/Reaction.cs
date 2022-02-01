﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Reaction : BaseEntity
    {
        public string Name { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
