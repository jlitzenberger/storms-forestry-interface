using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Forestry.Models.DTO
{
    public class Geo
    {
        /// <summary>
        /// Initializes a new instance of the Geo class.
        /// </summary>
        public Geo() { }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "area")]
        public string Area { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dist")]
        public string Dist { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "xCoordinate")]
        public string XCoordinate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "yCoordinate")]
        public string YCoordinate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "zone")]
        public string Zone { get; set; }

    }
}
