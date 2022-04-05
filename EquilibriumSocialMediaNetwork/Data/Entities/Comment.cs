using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Comment : BaseEntity
    {
        public Comment()
        {
            Replies = new HashSet<Reply>();
        }

        public string Content { get; set; }

        public DateTime TimeCommented { get; set; }

        public string PostId { get; set; }

        public Post Post { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }
    }
}
