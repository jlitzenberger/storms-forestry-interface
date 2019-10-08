using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Forestry.Models.DTO
{
    public class Phones
    {
        /// <summary>
        /// Initializes a new instance of the Phones class.
        /// </summary>
        public Phones() { }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "extension")]
        public string Extension { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "office")]
        public string Office { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cell")]
        public string Cell { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "eMail")]
        public string EMail { get; set; }

    }
}
