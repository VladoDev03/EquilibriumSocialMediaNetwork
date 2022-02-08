using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ReplyServiceModel : BaseEntityServiceModel
    {
        public string Content { get; set; }

        public string CommentId { get; set; }

        public CommentServiceModel Comment { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
