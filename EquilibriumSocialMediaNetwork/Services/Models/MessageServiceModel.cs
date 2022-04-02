using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class MessageServiceModel : BaseEntityServiceModel
    {
        public MessageServiceModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Content { get; set; }

        public string ConversationId { get; set; }

        public string UserOneId { get; set; }

        public string UserTwoId { get; set; }
    }
}
