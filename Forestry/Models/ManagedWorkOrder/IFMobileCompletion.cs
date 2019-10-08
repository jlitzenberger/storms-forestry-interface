// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    

    public partial class IFMobileCompletion
    {
        /// <summary>
        /// Initializes a new instance of the IFMobileCompletion class.
        /// </summary>
        public IFMobileCompletion() { }

        /// <summary>
        /// Initializes a new instance of the IFMobileCompletion class.
        /// </summary>
        public IFMobileCompletion(string url = default(string), string district = default(string), long? workRequest = default(long?), DateTime? completionDate = default(DateTime?), string completingCrewId = default(string), string errorFlag = default(string), DateTime? timeStampMobileCompletion = default(DateTime?), long? workPacket = default(long?), string resolutionCode = default(string), long? sequenceCode = default(long?), string jobCode = default(string), string jobType = default(string), long? errorRunSequenceCode = default(long?))
        {
            Url = url;
            District = district;
            WorkRequest = workRequest;
            CompletionDate = completionDate;
            CompletingCrewId = completingCrewId;
            ErrorFlag = errorFlag;
            TimeStampMobileCompletion = timeStampMobileCompletion;
            WorkPacket = workPacket;
            ResolutionCode = resolutionCode;
            SequenceCode = sequenceCode;
            JobCode = jobCode;
            JobType = jobType;
            ErrorRunSequenceCode = errorRunSequenceCode;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "district")]
        public string District { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workRequest")]
        public long? WorkRequest { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "completionDate")]
        public DateTime? CompletionDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "completingCrewId")]
        public string CompletingCrewId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "errorFlag")]
        public string ErrorFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timeStampMobileCompletion")]
        public DateTime? TimeStampMobileCompletion { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workPacket")]
        public long? WorkPacket { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "resolutionCode")]
        public string ResolutionCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sequenceCode")]
        public long? SequenceCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "jobCode")]
        public string JobCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "jobType")]
        public string JobType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "errorRunSequenceCode")]
        public long? ErrorRunSequenceCode { get; set; }

    }
}
