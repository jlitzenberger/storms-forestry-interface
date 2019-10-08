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
    public class WorkRequestMilestoneRequirementRequestorSetting : BaseRequestorSettings
    {
        public static WorkRequestMilestoneRequirementRequestorSetting Get()
        {
            return new WorkRequestMilestoneRequirementRequestorSetting()
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
    public class WorkRequestMilestoneRequirementRequestor : BaseRequestor, IResourse<Forestry.Models.DTO.MilestoneRequirement>
    {
        public WorkRequestMilestoneRequirementRequestor(IHttpClient client, WorkRequestMilestoneRequirementRequestorSetting setting)
            : base(client, new BaseRequestorSettings { ApiHeaders = setting.ApiHeaders, Credentials = setting.Credentials, JsonSerializerSettings = setting.JsonSerializerSettings })
        {

        }
        public Forestry.Models.DTO.MilestoneRequirement Get(Uri uri)
        {
            return base.Get<Forestry.Models.DTO.MilestoneRequirement>(uri);
        }
        public HttpResponseMessage Post(Uri uri, object obj)
        {
            return base.Post(uri, obj);
        }
        public HttpResponseMessage Put(Uri uri, object obj)
        {
            return base.Put(uri, obj);
        }
    }
}
