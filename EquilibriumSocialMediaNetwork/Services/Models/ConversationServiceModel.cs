using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ConversationServiceModel : BaseEntityServiceModel
    {
        public ConversationServiceModel()
        {
            Id = Guid.NewGuid().ToString();
            Messages = new HashSet<MessageServiceModel>();
        }

        public string UserOneId { get; set; }

        public string UserTwoId { get; set; }

        public IEnumerable<MessageServiceModel> Messages { get; set; }
    }
}
