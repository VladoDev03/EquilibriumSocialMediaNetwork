﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ReportServiceModel : BaseEntityServiceModel
    {
        public string Reason { get; set; }

        public string PostId { get; set; }

        public Post Post { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
