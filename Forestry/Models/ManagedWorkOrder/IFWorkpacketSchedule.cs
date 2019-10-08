// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    

    public partial class IFWorkpacketSchedule
    {
        /// <summary>
        /// Initializes a new instance of the IFWorkpacketSchedule class.
        /// </summary>
        public IFWorkpacketSchedule() { }

        /// <summary>
        /// Initializes a new instance of the IFWorkpacketSchedule class.
        /// </summary>
        public IFWorkpacketSchedule(DateTime? timeStamp = default(DateTime?), long? errorSequenceCode = default(long?), string crewId = default(string), long? workRequest = default(long?), string district = default(string), string crewClassCode = default(string), DateTime? scheduleDate = default(DateTime?), string errorFlag = default(string), double? remainingHours = default(double?), string rescheduleHoldFlag = default(string), long? workPacket = default(long?), DateTime? workDate = default(DateTime?), long? errorRunSequenceCode = default(long?), string crewMustDoFlag = default(string))
        {
            TimeStamp = timeStamp;
            ErrorSequenceCode = errorSequenceCode;
            CrewId = crewId;
            WorkRequest = workRequest;
            District = district;
            CrewClassCode = crewClassCode;
            ScheduleDate = scheduleDate;
            ErrorFlag = errorFlag;
            RemainingHours = remainingHours;
            RescheduleHoldFlag = rescheduleHoldFlag;
            WorkPacket = workPacket;
            WorkDate = workDate;
            ErrorRunSequenceCode = errorRunSequenceCode;
            CrewMustDoFlag = crewMustDoFlag;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timeStamp")]
        public DateTime? TimeStamp { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "errorSequenceCode")]
        public long? ErrorSequenceCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "crewId")]
        public string CrewId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workRequest")]
        public long? WorkRequest { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "district")]
        public string District { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "crewClassCode")]
        public string CrewClassCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "scheduleDate")]
        public DateTime? ScheduleDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "errorFlag")]
        public string ErrorFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "remainingHours")]
        public double? RemainingHours { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rescheduleHoldFlag")]
        public string RescheduleHoldFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workPacket")]
        public long? WorkPacket { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workDate")]
        public DateTime? WorkDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "errorRunSequenceCode")]
        public long? ErrorRunSequenceCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "crewMustDoFlag")]
        public string CrewMustDoFlag { get; set; }

    }
}
