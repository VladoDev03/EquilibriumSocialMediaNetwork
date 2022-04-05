using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class CommentServiceModel : BaseEntityServiceModel
    {
        public CommentServiceModel()
        {
            Replies = new HashSet<ReplyServiceModel>();
        }

        public string Content { get; set; }

        public DateTime TimeCommented { get; set; }

        public string PostId { get; set; }

        public PostServiceModel Post { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public virtual ICollection<ReplyServiceModel> Replies { get; set; }
    }
}
