using Forestry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Forestry.Services;
using Newtonsoft.Json;

namespace Forestry.Requestors
{
    public class Resourse<T> : BaseRequestor, IResourse<T> where T : class
    {
        public Resourse(IHttpClient httpClient, BaseRequestorSettings baseRequestorSettings) : base(httpClient, baseRequestorSettings)
        {

        }
        public T Get(Uri uri)
        {
            return null;
        }
        public HttpResponseMessage Post(Uri uri, object obj)
        {
            return null;
        }
        public HttpResponseMessage Put(Uri uri, object obj)
        {
            throw new NotImplementedException();
        }
    }
}
