using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Forestry.Models;
using Forestry.Models.DTO;
using Newtonsoft.Json;

namespace Forestry.Requestors
{
    public class WorkRequestRequestorSetting : BaseRequestorSettings
    {
        public static WorkRequestRequestorSetting Get()
        {
            return new WorkRequestRequestorSetting()
            {
                Credentials = Properties.Settings.Default.ManagedWorkOrderUriCredentials,
                JsonSerializerSettings = new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    TypeNameHandling = TypeNameHandling.None,
                    NullValueHandling = NullValueHandling.Include,
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                    Converters = {new Newtonsoft.Json.Converters.ExpandoObjectConverter()}
                },
                ApiHeaders = new Dictionary<string, string>
                {
                    {"Content-Application-Name", Properties.Settings.Default.ContentApplicationName},
                    {"Content-User-Id", Properties.Settings.Default.ContentUserId}
                }
            };
        }
    }
    public class WorkRequestRequestor : BaseRequestor, IResourse<object>
    {
        public WorkRequestRequestor(IHttpClient client, WorkRequestRequestorSetting setting) 
            : base(client, new BaseRequestorSettings { ApiHeaders = setting.ApiHeaders, Credentials = setting.Credentials, JsonSerializerSettings = setting.JsonSerializerSettings})
        {
            
        }
        public dynamic Get(Uri uri)
        {
            return base.Get<dynamic>(uri);
        }

        public HttpResponseMessage Post(Uri uri, object obj)
        {
            throw new NotImplementedException();
        }
        public HttpResponseMessage Put(Uri uri, object obj)
        {
            throw new NotImplementedException();
        }
    }
}
