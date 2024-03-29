// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    

    public partial class FacilityAttribute
    {
        /// <summary>
        /// Initializes a new instance of the FacilityAttribute class.
        /// </summary>
        public FacilityAttribute() { }

        /// <summary>
        /// Initializes a new instance of the FacilityAttribute class.
        /// </summary>
        public FacilityAttribute(string attributeName = default(string), string facilityName = default(string), string action = default(string), string validation = default(string), string flagActive = default(string), string idSeq = default(string), DateTime? lastChanged = default(DateTime?))
        {
            AttributeName = attributeName;
            FacilityName = facilityName;
            Action = action;
            Validation = validation;
            FlagActive = flagActive;
            IdSeq = idSeq;
            LastChanged = lastChanged;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "attributeName")]
        public string AttributeName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "facilityName")]
        public string FacilityName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validation")]
        public string Validation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "flagActive")]
        public string FlagActive { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "idSeq")]
        public string IdSeq { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastChanged")]
        public DateTime? LastChanged { get; set; }

    }
}
