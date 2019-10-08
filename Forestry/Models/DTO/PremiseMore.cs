using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Forestry.Models.DTO
{
    public class PremiseMore
    {
        /// <summary>
        /// Initializes a new instance of the PremiseMore class.
        /// </summary>
        public PremiseMore() { }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workRequestId")]
        public long? WorkRequestId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "district")]
        public string District { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "premiseId")]
        public string PremiseId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "serviceId")]
        public string ServiceId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "numberInHousehold")]
        public string NumberInHousehold { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "buildingSqFootage")]
        public string BuildingSqFootage { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "heatLoad")]
        public string HeatLoad { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "meterSize")]
        public string MeterSize { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "furnaceBoilerEfficiency")]
        public string FurnaceBoilerEfficiency { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "baseLoad")]
        public string BaseLoad { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "insulationPackage")]
        public string InsulationPackage { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "deliveryPressure")]
        public string DeliveryPressure { get; set; }

    }
}
