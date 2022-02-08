using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class StatusServiceModel : BaseEntityServiceModel
    {
        public string Name { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
