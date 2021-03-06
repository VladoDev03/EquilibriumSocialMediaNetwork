using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Post : BaseEntity
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Reactions = new HashSet<Reaction>();
        }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string ImageDownloadUrl { get; set; }

        public string ImagePublicId { get; set; }

        public bool IsDownloadable { get; set; }

        public DateTime TimePosted { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Reaction> Reactions { get; set; }
    }
}
