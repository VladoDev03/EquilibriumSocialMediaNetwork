using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.Post
{
    public class HomeViewModel
    {
        public string LoggedUserId { get; set; }

        public List<PostViewModel> Posts { get; set; }
    }
}
