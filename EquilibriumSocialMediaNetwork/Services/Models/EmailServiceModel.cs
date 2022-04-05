using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class EmailServiceModel : BaseEntityServiceModel
    {
        public string To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
