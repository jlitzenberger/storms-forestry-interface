// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    

    public partial class FieldOrderAttachmentId
    {
        /// <summary>
        /// Initializes a new instance of the FieldOrderAttachmentId class.
        /// </summary>
        public FieldOrderAttachmentId() { }

        /// <summary>
        /// Initializes a new instance of the FieldOrderAttachmentId class.
        /// </summary>
        public FieldOrderAttachmentId(long? workRequest = default(long?), long? sequenceCode = default(long?), string documentDescription = default(string), string documentName = default(string), DateTime? timeStampUpdate = default(DateTime?), string attachmentId = default(string), string deletedFlag = default(string), string fieldOrderNumber = default(string), long? interfaceSeq = default(long?))
        {
            WorkRequest = workRequest;
            SequenceCode = sequenceCode;
            DocumentDescription = documentDescription;
            DocumentName = documentName;
            TimeStampUpdate = timeStampUpdate;
            AttachmentId = attachmentId;
            DeletedFlag = deletedFlag;
            FieldOrderNumber = fieldOrderNumber;
            InterfaceSeq = interfaceSeq;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workRequest")]
        public long? WorkRequest { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sequenceCode")]
        public long? SequenceCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "documentDescription")]
        public string DocumentDescription { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "documentName")]
        public string DocumentName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timeStampUpdate")]
        public DateTime? TimeStampUpdate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "attachmentId")]
        public string AttachmentId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "deletedFlag")]
        public string DeletedFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fieldOrderNumber")]
        public string FieldOrderNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "interfaceSeq")]
        public long? InterfaceSeq { get; set; }

    }
}