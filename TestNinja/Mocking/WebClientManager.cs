﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    class WebClientManager : IWebClientManager
    {
        public void Download(string url, string path)
        {
            var client = new WebClient();

            client.DownloadFile(url, path);
               
        }
    }
}