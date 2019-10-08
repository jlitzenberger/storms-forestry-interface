using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Forestry.Models.DTO
{
    public class MilestoneRequirement
    {
        /// <summary>
        /// Initializes a new instance of the MilestoneRequirement class.
        /// </summary>
        public MilestoneRequirement() { }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workRequestId")]
        public string WorkRequestId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "district")]
        public string District { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "requirementId")]
        public string RequirementId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "responsibleId")]
        public string ResponsibleId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastUpdatedId")]
        public string LastUpdatedId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastUpdatedDate")]
        public DateTime? LastUpdatedDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "assignedDate")]
        public DateTime? AssignedDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "leadTimeFlag")]
        public string LeadTimeFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workQueueFlag")]
        public string WorkQueueFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "serviceStdFlag")]
        public string ServiceStdFlag { get; set; }

    }
}
