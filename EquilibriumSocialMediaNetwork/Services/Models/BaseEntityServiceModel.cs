using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class BaseEntityServiceModel
    {
        public BaseEntityServiceModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
    }
}
