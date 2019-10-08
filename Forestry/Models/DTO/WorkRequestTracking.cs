using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Forestry.Models.DTO
{
    public class WorkRequestTracking
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "district")]
        public string District { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workRequestId")]
        public long? WorkRequestId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "operatorId")]
        public string OperatorId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "function")]
        public string Function { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "typeOfChange")]
        public string TypeOfChange { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "changeDate")]
        public DateTime? ChangeDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }

        public WorkRequestTracking()
        {
            
        }
    }
}
