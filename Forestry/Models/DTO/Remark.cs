using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Forestry.Models.DTO
{
    public class Remark
    {
        /// <summary>
        /// Initializes a new instance of the Remark class.
        /// </summary>
        public Remark() { }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "creationDate")]
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "creatorId")]
        public string CreatorId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "district")]
        public string District { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "remarkText")]
        public string RemarkText { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "seq")]
        public int? Seq { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workRequestId")]
        public long? WorkRequestId { get; set; }

    }
}
