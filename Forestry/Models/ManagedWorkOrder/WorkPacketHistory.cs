// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class WorkPacketHistory
    {
        /// <summary>
        /// Initializes a new instance of the WorkPacketHistory class.
        /// </summary>
        public WorkPacketHistory() { }

        /// <summary>
        /// Initializes a new instance of the WorkPacketHistory class.
        /// </summary>
        public WorkPacketHistory(string uri = default(string), long? workPacketId = default(long?), long? sequence = default(long?), string status = default(string), string reason = default(string), string recordedOperator = default(string), DateTime? dateTimeRecorded = default(DateTime?), DateTime? dateTimeStatusReached = default(DateTime?), DateTime? dateTimeStatusEndEstimate = default(DateTime?))
        {
            Uri = uri;
            WorkPacketId = workPacketId;
            Sequence = sequence;
            Status = status;
            Reason = reason;
            RecordedOperator = recordedOperator;
            DateTimeRecorded = dateTimeRecorded;
            DateTimeStatusReached = dateTimeStatusReached;
            DateTimeStatusEndEstimate = dateTimeStatusEndEstimate;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workPacketId")]
        public long? WorkPacketId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sequence")]
        public long? Sequence { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "recordedOperator")]
        public string RecordedOperator { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dateTimeRecorded")]
        public DateTime? DateTimeRecorded { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dateTimeStatusReached")]
        public DateTime? DateTimeStatusReached { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dateTimeStatusEndEstimate")]
        public DateTime? DateTimeStatusEndEstimate { get; set; }

    }
}
