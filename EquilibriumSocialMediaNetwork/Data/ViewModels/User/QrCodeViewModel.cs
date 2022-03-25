using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.User
{
    public class QrCodeViewModel
    {
        public QrCodeViewModel(string url, string downloadUrl)
        {
            Url = url;
            DownloadUrl = downloadUrl;
        }

        public string Url { get; set; }

        public string DownloadUrl { get; set; }
    }
}
