// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    

    public partial class DamageReport
    {
        /// <summary>
        /// Initializes a new instance of the DamageReport class.
        /// </summary>
        public DamageReport() { }

        /// <summary>
        /// Initializes a new instance of the DamageReport class.
        /// </summary>
        public DamageReport(long? workRequest = default(long?), int? witnessSequenceNumber = default(int?), string witnessName = default(string), string witnessAddress = default(string), string witnessCity = default(string), string witnessState = default(string), string witnessZip = default(string), string witnessPhone = default(string))
        {
            WorkRequest = workRequest;
            WitnessSequenceNumber = witnessSequenceNumber;
            WitnessName = witnessName;
            WitnessAddress = witnessAddress;
            WitnessCity = witnessCity;
            WitnessState = witnessState;
            WitnessZip = witnessZip;
            WitnessPhone = witnessPhone;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workRequest")]
        public long? WorkRequest { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "witnessSequenceNumber")]
        public int? WitnessSequenceNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "witnessName")]
        public string WitnessName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "witnessAddress")]
        public string WitnessAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "witnessCity")]
        public string WitnessCity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "witnessState")]
        public string WitnessState { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "witnessZip")]
        public string WitnessZip { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "witnessPhone")]
        public string WitnessPhone { get; set; }

    }
}
