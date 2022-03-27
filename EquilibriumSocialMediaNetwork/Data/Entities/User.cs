using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string QrCodeId { get; set; }

        public string ProfilePictureId { get; set; }

        public QrCode QrCode { get; set; }

        public ProfilePicture ProfilePicture { get; set; }
    }
}
