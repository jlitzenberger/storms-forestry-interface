// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    

    public partial class ExtDesignKey
    {
        /// <summary>
        /// Initializes a new instance of the ExtDesignKey class.
        /// </summary>
        public ExtDesignKey() { }

        /// <summary>
        /// Initializes a new instance of the ExtDesignKey class.
        /// </summary>
        public ExtDesignKey(DateTime? tsExtDsgn = default(DateTime?), string idOper = default(string), int? extDsgnFacAttSeq = default(int?))
        {
            TsExtDsgn = tsExtDsgn;
            IdOper = idOper;
            ExtDsgnFacAttSeq = extDsgnFacAttSeq;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tsExtDsgn")]
        public DateTime? TsExtDsgn { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "idOper")]
        public string IdOper { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "extDsgnFacAttSeq")]
        public int? ExtDsgnFacAttSeq { get; set; }

    }
}
