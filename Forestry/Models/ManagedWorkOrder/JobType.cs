// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    

    public partial class JobType
    {
        /// <summary>
        /// Initializes a new instance of the JobType class.
        /// </summary>
        public JobType() { }

        /// <summary>
        /// Initializes a new instance of the JobType class.
        /// </summary>
        public JobType(string url = default(string), string name = default(string), string description = default(string))
        {
            Url = url;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

    }
}
