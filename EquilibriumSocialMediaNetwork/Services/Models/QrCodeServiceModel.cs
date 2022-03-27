using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class QrCodeServiceModel : BaseEntityServiceModel
    {
        public string ImageUrl { get; set; }

        public string ImageDownloadUrl { get; set; }

        public string UserId { get; set; }
    }
}
