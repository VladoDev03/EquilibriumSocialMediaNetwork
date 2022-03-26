using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.User
{
    public class ProfilePictureViewModel
    {
        public string ImageUrl { get; set; }

        public string ImageDownloadUrl { get; set; }

        public bool IsDownloadable { get; set; }
    }
}
