using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Comments
{
    public class CreateCommentBindingModel
    {
        public string Content { get; set; }

        public string PostId { get; set; }
    }
}
