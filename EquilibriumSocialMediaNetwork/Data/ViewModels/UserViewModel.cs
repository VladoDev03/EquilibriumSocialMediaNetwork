using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Posts = new List<PostViewModel>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public List<PostViewModel> Posts { get; set; }
    }
}
