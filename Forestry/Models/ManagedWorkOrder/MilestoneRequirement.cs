// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    

    public partial class MilestoneRequirement
    {
        /// <summary>
        /// Initializes a new instance of the MilestoneRequirement class.
        /// </summary>
        public MilestoneRequirement() { }

        /// <summary>
        /// Initializes a new instance of the MilestoneRequirement class.
        /// </summary>
        public MilestoneRequirement(string url = default(string), string workRequestId = default(string), string district = default(string), string requirementId = default(string), string description = default(string), string status = default(string), string responsibleId = default(string), string lastUpdatedId = default(string), DateTime? lastUpdatedDate = default(DateTime?), DateTime? assignedDate = default(DateTime?), string leadTimeFlag = default(string), string workQueueFlag = default(string), string serviceStdFlag = default(string))
        {
            Url = url;
            WorkRequestId = workRequestId;
            District = district;
            RequirementId = requirementId;
            Description = description;
            Status = status;
            ResponsibleId = responsibleId;
            LastUpdatedId = lastUpdatedId;
            LastUpdatedDate = lastUpdatedDate;
            AssignedDate = assignedDate;
            LeadTimeFlag = leadTimeFlag;
            WorkQueueFlag = workQueueFlag;
            ServiceStdFlag = serviceStdFlag;
        }

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
