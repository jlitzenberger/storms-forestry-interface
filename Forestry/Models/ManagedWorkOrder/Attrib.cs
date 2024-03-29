// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    

    public partial class Attrib
    {
        /// <summary>
        /// Initializes a new instance of the Attrib class.
        /// </summary>
        public Attrib() { }

        /// <summary>
        /// Initializes a new instance of the Attrib class.
        /// </summary>
        public Attrib(string attributeCode = default(string), string dataTypeIndicator = default(string), int? datafieldLength = default(int?), string fieldNameText = default(string), string attributeIndicator = default(string), string collectionIndicator = default(string), string validationIndicator = default(string), string requiredFlag = default(string), string targetTableText = default(string), string activeFlag = default(string), string targetColumnText = default(string), DateTime? lastChangedTimeStamp = default(DateTime?))
        {
            AttributeCode = attributeCode;
            DataTypeIndicator = dataTypeIndicator;
            DatafieldLength = datafieldLength;
            FieldNameText = fieldNameText;
            AttributeIndicator = attributeIndicator;
            CollectionIndicator = collectionIndicator;
            ValidationIndicator = validationIndicator;
            RequiredFlag = requiredFlag;
            TargetTableText = targetTableText;
            ActiveFlag = activeFlag;
            TargetColumnText = targetColumnText;
            LastChangedTimeStamp = lastChangedTimeStamp;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "attributeCode")]
        public string AttributeCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dataTypeIndicator")]
        public string DataTypeIndicator { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "datafieldLength")]
        public int? DatafieldLength { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fieldNameText")]
        public string FieldNameText { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "attributeIndicator")]
        public string AttributeIndicator { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "collectionIndicator")]
        public string CollectionIndicator { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validationIndicator")]
        public string ValidationIndicator { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "requiredFlag")]
        public string RequiredFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "targetTableText")]
        public string TargetTableText { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "activeFlag")]
        public string ActiveFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "targetColumnText")]
        public string TargetColumnText { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastChangedTimeStamp")]
        public DateTime? LastChangedTimeStamp { get; set; }

    }
}
