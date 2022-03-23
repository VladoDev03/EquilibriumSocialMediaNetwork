using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.Reaction
{
    public class ReactionViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public Entities.User User { get; set; }
    }
}
