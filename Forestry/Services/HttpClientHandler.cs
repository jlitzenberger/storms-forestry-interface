﻿using Forestry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Forestry.Services
{
    public class HttpClientHandler : IHttpClient
    {
        private HttpClient _client = new HttpClient();
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestUri)
        {
            return await _client.SendAsync(requestUri);
        }
        public Task<HttpResponseMessage> PostAsync(HttpRequestMessage requestUri)
        {
            throw new NotImplementedException();
        }
    }
}
