using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.User
{
    public class UploadProfilePictureBindingModel
    {
        public IFormFile ProfilePicture { get; set; }

        public string IsDownloadable { get; set; }
    }
}
