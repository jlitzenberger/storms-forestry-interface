using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Forestry.Models.DTO
{
    public class Address
    {
        /// <summary>
        /// Initializes a new instance of the Address class.
        /// </summary>
        public Address() { }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "organization")]
        public string Organization { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "building")]
        public string Building { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "floor")]
        public string Floor { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "streetNumber")]
        public string StreetNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "streetPrefix")]
        public string StreetPrefix { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "streetName")]
        public string StreetName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "streetType")]
        public string StreetType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "streetSuffix")]
        public string StreetSuffix { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "unitId")]
        public string UnitId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "unitType")]
        public string UnitType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "county")]
        public string County { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "zip")]
        public string Zip { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "extraInfo")]
        public string ExtraInfo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "freeFormat")]
        public string FreeFormat { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cityCode")]
        public string CityCode { get; set; }

    }
}
