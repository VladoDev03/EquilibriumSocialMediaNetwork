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
            Reactions = new HashSet<ReactionServiceModel>();
        }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string ImageDownloadUrl { get; set; }

        public string ImagePublicId { get; set; }

        public bool IsDownloadable { get; set; }

        public DateTime TimePosted { get; set; }

        public virtual ICollection<CommentServiceModel> Comments { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public virtual ICollection<ReactionServiceModel> Reactions { get; set; }
    }
}
