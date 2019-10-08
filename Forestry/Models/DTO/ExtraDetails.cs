using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Forestry.Models.DTO
{
    public class ExtraDetails
    {
        /// <summary>
        /// Initializes a new instance of the ExtraDetails class.
        /// </summary>
        public ExtraDetails() { }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workRequestId")]
        public long? WorkRequestId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "district")]
        public string District { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "complexFlag")]
        public string ComplexFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "subdivisionName")]
        public string SubdivisionName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lotNo")]
        public string LotNo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dogCode")]
        public string DogCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "mapNoId")]
        public string MapNoId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "feederId")]
        public string FeederId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "phaseCode")]
        public string PhaseCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "feeder2Id")]
        public string Feeder2Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "phase2Code")]
        public string Phase2Code { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "serviceSizeCode")]
        public string ServiceSizeCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cssMeterPhs")]
        public string CssMeterPhs { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "serviceVoltageCode")]
        public string ServiceVoltageCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "customerTypeCode")]
        public string CustomerTypeCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "designRequiredDate")]
        public string DesignRequiredDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "designerJobElectric")]
        public string DesignerJobElectric { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "mainOrderNumber")]
        public string MainOrderNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fieldAlert")]
        public string FieldAlert { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "equipmentId")]
        public string EquipmentId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "utilityType")]
        public string UtilityType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "designerJobGas")]
        public string DesignerJobGas { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "customerWantDateTime")]
        public string CustomerWantDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "trsQuarter")]
        public string TrsQuarter { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "trsSection")]
        public string TrsSection { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "trsTown")]
        public string TrsTown { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "trsDirection")]
        public string TrsDirection { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "trsRange")]
        public string TrsRange { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "constructionType")]
        public string ConstructionType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "onOffMain")]
        public string OnOffMain { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "buildingType")]
        public string BuildingType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pre1978Construction")]
        public string Pre1978Construction { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "mainToLotLineFootage")]
        public string MainToLotLineFootage { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pbiAreaNo")]
        public string PbiAreaNo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "publicBuilding")]
        public string PublicBuilding { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "branchService")]
        public string BranchService { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "existingServiceFln")]
        public string ExistingServiceFln { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "trailerParkName")]
        public string TrailerParkName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "systemPressure")]
        public string SystemPressure { get; set; }

    }
}
