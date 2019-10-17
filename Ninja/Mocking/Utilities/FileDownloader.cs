using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Ninja.Mocking
{
    public class FileDownloader : IFileDownloader
    {
        public void DownloadFile(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }
}
