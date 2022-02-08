using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class PostServiceModel : BaseEntityServiceModel
    {
        public PostServiceModel()
        {
            Comments = new HashSet<CommentServiceModel>();
        }

        public string Content { get; set; }

        public virtual ICollection<CommentServiceModel> Comments { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string ReactionId { get; set; }

        public ReactionServiceModel Reaction { get; set; }
    }
}
