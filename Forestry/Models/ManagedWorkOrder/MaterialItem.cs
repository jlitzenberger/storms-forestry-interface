// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    

    public partial class MaterialItem
    {
        /// <summary>
        /// Initializes a new instance of the MaterialItem class.
        /// </summary>
        public MaterialItem() { }

        /// <summary>
        /// Initializes a new instance of the MaterialItem class.
        /// </summary>
        public MaterialItem(string materialItemNumber = default(string), double? materialItemAmount = default(double?), double? salvageAmount = default(double?), double? scrapAmount = default(double?), string materialClassCode = default(string), string uomCode = default(string), string materialItemDescription = default(string), int? leadTime = default(int?), string activeFlag = default(string), string prevCapitalizeFlag = default(string), string stockItemFlag = default(string), double? allowanceFlag = default(double?), double? minQuantity = default(double?), string truckStockFlag = default(string), string majorFlag = default(string), string assetFlag = default(string), string stockingCode = default(string), DateTime? lastChangedDateTime = default(DateTime?))
        {
            MaterialItemNumber = materialItemNumber;
            MaterialItemAmount = materialItemAmount;
            SalvageAmount = salvageAmount;
            ScrapAmount = scrapAmount;
            MaterialClassCode = materialClassCode;
            UomCode = uomCode;
            MaterialItemDescription = materialItemDescription;
            LeadTime = leadTime;
            ActiveFlag = activeFlag;
            PrevCapitalizeFlag = prevCapitalizeFlag;
            StockItemFlag = stockItemFlag;
            AllowanceFlag = allowanceFlag;
            MinQuantity = minQuantity;
            TruckStockFlag = truckStockFlag;
            MajorFlag = majorFlag;
            AssetFlag = assetFlag;
            StockingCode = stockingCode;
            LastChangedDateTime = lastChangedDateTime;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "materialItemNumber")]
        public string MaterialItemNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "materialItemAmount")]
        public double? MaterialItemAmount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "salvageAmount")]
        public double? SalvageAmount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "scrapAmount")]
        public double? ScrapAmount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "materialClassCode")]
        public string MaterialClassCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "uomCode")]
        public string UomCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "materialItemDescription")]
        public string MaterialItemDescription { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "leadTime")]
        public int? LeadTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "activeFlag")]
        public string ActiveFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "prevCapitalizeFlag")]
        public string PrevCapitalizeFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "stockItemFlag")]
        public string StockItemFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "allowanceFlag")]
        public double? AllowanceFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "minQuantity")]
        public double? MinQuantity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "truckStockFlag")]
        public string TruckStockFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "majorFlag")]
        public string MajorFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "assetFlag")]
        public string AssetFlag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "stockingCode")]
        public string StockingCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastChangedDateTime")]
        public DateTime? LastChangedDateTime { get; set; }

    }
}