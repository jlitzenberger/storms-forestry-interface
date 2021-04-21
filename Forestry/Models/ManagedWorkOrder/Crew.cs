// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    

    public partial class Crew
    {
        /// <summary>
        /// Initializes a new instance of the Crew class.
        /// </summary>
        public Crew() { }

        /// <summary>
        /// Initializes a new instance of the Crew class.
        /// </summary>
        public Crew(string crewId = default(string), string crewClassCode = default(string), string crewHeadquarters = default(string), string entityCode = default(string), string crewDescription = default(string), string activeFlag = default(string), int? employeeQuantity = default(int?), string sectionCode = default(string), double? costPerHour = default(double?), DateTime? timeStampUpdate = default(DateTime?), string shiftCode = default(string), DateTime? shiftStartDate = default(DateTime?), string crewText = default(string), int? resourceId = default(int?), string verifyRequiredFlag = default(string))
        {
            CrewId = crewId;
            CrewClassCode = crewClassCode;
            CrewHeadquarters = crewHeadquarters;
            EntityCode = entityCode;
            CrewDescription = crewDescription;
            ActiveFlag = activeFlag;
            EmployeeQuantity = employeeQuantity;
            SectionCode = sectionCode;
            CostPerHour = costPerHour;
            TimeStampUpdate = timeStampUpdate;
            ShiftCode = shiftCode;
            ShiftStartDate = shiftStartDate;
            CrewText = crewText;
            ResourceId = resourceId;
            VerifyRequiredFlag = verifyRequiredFlag;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "crewId")]
        public string CrewId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "crewClassCode")]
        public string CrewClassCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "crewHeadquarters")]
        public string CrewHeadquarters { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "entityCode")]
        public string EntityCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "crewDescription")]
        public string CrewDescription { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "activeFlag")]
        public string ActiveFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "employeeQuantity")]
        public int? EmployeeQuantity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sectionCode")]
        public string SectionCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "costPerHour")]
        public double? CostPerHour { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timeStampUpdate")]
        public DateTime? TimeStampUpdate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "shiftCode")]
        public string ShiftCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "shiftStartDate")]
        public DateTime? ShiftStartDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "crewText")]
        public string CrewText { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "resourceId")]
        public int? ResourceId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "verifyRequiredFlag")]
        public string VerifyRequiredFlag { get; set; }

    }
}