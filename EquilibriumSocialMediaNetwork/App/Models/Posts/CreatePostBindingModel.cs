using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Posts
{
    public class CreatePostBindingModel
    {
        public string Content { get; set; }

        public IFormFile Image { get; set; }

        public string IsDownloadable { get; set; }
    }
}
