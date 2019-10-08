// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    

    public partial class JobCode
    {
        /// <summary>
        /// Initializes a new instance of the JobCode class.
        /// </summary>
        public JobCode() { }

        /// <summary>
        /// Initializes a new instance of the JobCode class.
        /// </summary>
        public JobCode(string url = default(string), string jobCodeId = default(string), string jobCodeDescription = default(string), DateTime? discontinuedDateTime = default(DateTime?), DateTime? effectiveDateTime = default(DateTime?), int? prior = default(int?), long? toReinitiate = default(long?), double? estTime = default(double?), string jobType = default(string), string facDesignFlag = default(string), string facAsbuildFlag = default(string), string changeEstTimeFlag = default(string), string excMthd = default(string), string initiationInd = default(string), string autoJobCostFlag = default(string), string worksType = default(string), int? serviceStandard = default(int?), string mobileInitFlag = default(string), int? offsetQuantity = default(int?), string apptProfile = default(string), long? capabilityId = default(long?), IList<CuJobCode> cuJobCodes = default(IList<CuJobCode>))
        {
            Url = url;
            JobCodeId = jobCodeId;
            JobCodeDescription = jobCodeDescription;
            DiscontinuedDateTime = discontinuedDateTime;
            EffectiveDateTime = effectiveDateTime;
            Prior = prior;
            ToReinitiate = toReinitiate;
            EstTime = estTime;
            JobType = jobType;
            FacDesignFlag = facDesignFlag;
            FacAsbuildFlag = facAsbuildFlag;
            ChangeEstTimeFlag = changeEstTimeFlag;
            ExcMthd = excMthd;
            InitiationInd = initiationInd;
            AutoJobCostFlag = autoJobCostFlag;
            WorksType = worksType;
            ServiceStandard = serviceStandard;
            MobileInitFlag = mobileInitFlag;
            OffsetQuantity = offsetQuantity;
            ApptProfile = apptProfile;
            CapabilityId = capabilityId;
            CuJobCodes = cuJobCodes;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "jobCodeId")]
        public string JobCodeId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "jobCodeDescription")]
        public string JobCodeDescription { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "discontinuedDateTime")]
        public DateTime? DiscontinuedDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "effectiveDateTime")]
        public DateTime? EffectiveDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "prior")]
        public int? Prior { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "toReinitiate")]
        public long? ToReinitiate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "estTime")]
        public double? EstTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "jobType")]
        public string JobType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "facDesignFlag")]
        public string FacDesignFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "facAsbuildFlag")]
        public string FacAsbuildFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "changeEstTimeFlag")]
        public string ChangeEstTimeFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "excMthd")]
        public string ExcMthd { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "initiationInd")]
        public string InitiationInd { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "autoJobCostFlag")]
        public string AutoJobCostFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "worksType")]
        public string WorksType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "serviceStandard")]
        public int? ServiceStandard { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "mobileInitFlag")]
        public string MobileInitFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "offsetQuantity")]
        public int? OffsetQuantity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "apptProfile")]
        public string ApptProfile { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "capabilityId")]
        public long? CapabilityId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cuJobCodes")]
        public IList<CuJobCode> CuJobCodes { get; set; }

    }
}
