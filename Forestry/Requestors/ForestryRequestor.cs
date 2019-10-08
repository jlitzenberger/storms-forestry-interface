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
    public class ForestryRequestorSetting : BaseRequestorSettings
    {
        public static ForestryRequestorSetting Get()
        {
            return new ForestryRequestorSetting()
            {
                Credentials = Properties.Settings.Default.MqApiUriCredentials,
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
                    {"Content-User-Id", Properties.Settings.Default.ContentUserId},
                    {"Messaging-Properties", "registrationVersion=rv1,httpMethod=POST,originSystem=STORMS"},
                    {"Messaging-Queue", "ED.FORESTRY.FORESTRY_JOB.RQ"}
                }
            };
        }
    }
    public class ForestryRequestor : BaseRequestor, IResourse<ForestryRequest>
    {
        public ForestryRequestor(IHttpClient client, ForestryRequestorSetting setting)
            : base(client, new BaseRequestorSettings { ApiHeaders = setting.ApiHeaders, Credentials = setting.Credentials, JsonSerializerSettings = setting.JsonSerializerSettings })
        {

        }
        public ForestryRequest Get(Uri uri)
        {
            return base.Get<ForestryRequest>(uri);
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
