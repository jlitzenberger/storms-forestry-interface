using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Forestry.Models;
using Newtonsoft.Json;

namespace Forestry.Requestors
{
    public class StormsWorkQueueRequestorSetting : BaseRequestorSettings
    {
        public static StormsWorkQueueRequestorSetting Get()
        {
            return new StormsWorkQueueRequestorSetting()
            {
                Credentials = Properties.Settings.Default.ManagedWorkOrderUriCredentials,
                JsonSerializerSettings = new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    TypeNameHandling = TypeNameHandling.None,
                    NullValueHandling = NullValueHandling.Include,
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                    Converters = { new Newtonsoft.Json.Converters.ExpandoObjectConverter() }
                },
                ApiHeaders = new Dictionary<string, string>
                {
                    {"Content-Application-Name", Properties.Settings.Default.ContentApplicationName},
                    {"Content-User-Id", Properties.Settings.Default.ContentUserId}
                }
            };
        }
    }
    public class StormsWorkQueueRequestor : BaseRequestor, IResourse<string>
    {
        public StormsWorkQueueRequestor(IHttpClient client, StormsWorkQueueRequestorSetting setting)
            : base(client, new BaseRequestorSettings { ApiHeaders = setting.ApiHeaders, Credentials = setting.Credentials, JsonSerializerSettings = setting.JsonSerializerSettings })
        {

        }
        public string Get(Uri uri)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Post(Uri uri, object obj)
        {
            return base.Post(uri, obj);
        }
        public HttpResponseMessage Put(Uri uri, object obj)
        {
            throw new NotImplementedException();
        }
    }
}
