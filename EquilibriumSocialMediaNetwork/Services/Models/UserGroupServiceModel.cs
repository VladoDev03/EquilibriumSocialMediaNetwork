using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class UserGroupServiceModel : BaseEntityServiceModel
    {
        public int UserId { get; set; }

        public int GroupId { get; set; }

        public virtual GroupServiceModel Group { get; set; }

        public virtual User User { get; set; }
    }
}
