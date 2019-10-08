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
    public class WorkRequestRemarkRequestorSetting : BaseRequestorSettings
    {
        public static WorkRequestRemarkRequestorSetting Get()
        {
            return new WorkRequestRemarkRequestorSetting()
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
    public class WorkRequestRemarkRequestor : BaseRequestor, IResourse<List<Forestry.Models.DTO.Remark>>
    {
        public WorkRequestRemarkRequestor(IHttpClient client, WorkRequestRemarkRequestorSetting setting)
            : base(client, new BaseRequestorSettings { ApiHeaders = setting.ApiHeaders, Credentials = setting.Credentials, JsonSerializerSettings = setting.JsonSerializerSettings })
        {

        }
        public List<Forestry.Models.DTO.Remark> Get(Uri uri)
        {
            return base.Get<List<Forestry.Models.DTO.Remark>>(uri);
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
