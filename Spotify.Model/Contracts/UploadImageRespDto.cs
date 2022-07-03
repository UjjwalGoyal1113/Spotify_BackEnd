using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Model.Contracts
{
    public class UploadImageRespDto
    {
        public bool Success { get; set; }
        public string ImageBasePath { get; set; }
        public string ReletivePath { get; set; }
        public string Message { get; set; }
    }
}
