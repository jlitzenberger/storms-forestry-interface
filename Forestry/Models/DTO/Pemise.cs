using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Forestry.Models.DTO
{
    public class Premise
    {
        /// <summary>
        /// Initializes a new instance of the Premise class.
        /// </summary>
        public Premise() { }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "district")]
        public string District { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workRequestId")]
        public long? WorkRequestId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "premiseId")]
        public string PremiseId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sic")]
        public string Sic { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rateClass")]
        public string RateClass { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "revenueClass")]
        public string RevenueClass { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "addressCode")]
        public long? AddressCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hazardFlag")]
        public string HazardFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "keyAvailFlag")]
        public string KeyAvailFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "baseLoadQuantity")]
        public double? BaseLoadQuantity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "heatingFactorQuantity")]
        public double? HeatingFactorQuantity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "serviceId")]
        public string ServiceId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "premiseMore")]
        public PremiseMore PremiseMore { get; set; }

    }
}
