// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    

    public partial class CuJobCode
    {
        /// <summary>
        /// Initializes a new instance of the CuJobCode class.
        /// </summary>
        public CuJobCode() { }

        /// <summary>
        /// Initializes a new instance of the CuJobCode class.
        /// </summary>
        public CuJobCode(string jobCodeId = default(string), string cuName = default(string), string pointNumber = default(string), string pointSpanNumber = default(string), string usage = default(string), string account = default(string), string action = default(string), string onOff = default(string), double? quantityAction = default(double?), string facility = default(string), long? jobCdPacket = default(long?), double? laborHours = default(double?), string crewClass = default(string), string muId = default(string))
        {
            JobCodeId = jobCodeId;
            CuName = cuName;
            PointNumber = pointNumber;
            PointSpanNumber = pointSpanNumber;
            Usage = usage;
            Account = account;
            Action = action;
            OnOff = onOff;
            QuantityAction = quantityAction;
            Facility = facility;
            JobCdPacket = jobCdPacket;
            LaborHours = laborHours;
            CrewClass = crewClass;
            MuId = muId;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "jobCodeId")]
        public string JobCodeId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cuName")]
        public string CuName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pointNumber")]
        public string PointNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pointSpanNumber")]
        public string PointSpanNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "usage")]
        public string Usage { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "account")]
        public string Account { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "onOff")]
        public string OnOff { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "quantityAction")]
        public double? QuantityAction { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "facility")]
        public string Facility { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "jobCdPacket")]
        public long? JobCdPacket { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "laborHours")]
        public double? LaborHours { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "crewClass")]
        public string CrewClass { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "muId")]
        public string MuId { get; set; }

    }
}
