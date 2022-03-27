using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ProfilePicture : BaseEntity
    {
        public string ImageUrl { get; set; }

        public string ImageDownloadUrl { get; set; }

        public string ImagePublicId { get; set; }

        public bool IsDownloadable { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
