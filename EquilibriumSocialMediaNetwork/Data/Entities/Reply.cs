using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Reply : BaseEntity
    {
        public string Content { get; set; }

        public string CommentId { get; set; }

        public Comment Comment { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
