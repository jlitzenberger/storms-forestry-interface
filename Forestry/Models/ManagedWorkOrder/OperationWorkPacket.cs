// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    

    public partial class OperationWorkPacket
    {
        /// <summary>
        /// Initializes a new instance of the OperationWorkPacket class.
        /// </summary>
        public OperationWorkPacket() { }

        /// <summary>
        /// Initializes a new instance of the OperationWorkPacket class.
        /// </summary>
        public OperationWorkPacket(object value = default(object), string path = default(string), string op = default(string), string fromProperty = default(string))
        {
            Value = value;
            Path = path;
            Op = op;
            FromProperty = fromProperty;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public object Value { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "op")]
        public string Op { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "from")]
        public string FromProperty { get; set; }

    }
}