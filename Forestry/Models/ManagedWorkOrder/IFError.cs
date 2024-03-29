// Code generated by Microsoft (R) AutoRest Code Generator 0.15.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Forestry.Models.ManagedWorkOrder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    

    public partial class IFError
    {
        /// <summary>
        /// Initializes a new instance of the IFError class.
        /// </summary>
        public IFError() { }

        /// <summary>
        /// Initializes a new instance of the IFError class.
        /// </summary>
        public IFError(long? cDSEQERROR = default(long?), long? cDSQLCODE = default(long?), string nMINTERFACE = default(string), DateTime? tSERROR = default(DateTime?), string txTSQLERRTEXT = default(string), string txTIFERROR = default(string), long? cDSEQERRORRUN = default(long?), string cDDIST = default(string), long? cDWR = default(long?), long? cDWORKPACKET = default(long?), string cDPROJECT = default(string), string cDCREW = default(string), string iDEMPL = default(string), string cDFLEET = default(string), string nMTABLE = default(string), string nMCOLUMN = default(string), string fGDATAERROR = default(string), DateTime? tSERRORLOGGED = default(DateTime?))
        {
            CDSEQERROR = cDSEQERROR;
            CDSQLCODE = cDSQLCODE;
            NMINTERFACE = nMINTERFACE;
            TSERROR = tSERROR;
            TxTSQLERRTEXT = txTSQLERRTEXT;
            TxTIFERROR = txTIFERROR;
            CDSEQERRORRUN = cDSEQERRORRUN;
            CDDIST = cDDIST;
            CDWR = cDWR;
            CDWORKPACKET = cDWORKPACKET;
            CDPROJECT = cDPROJECT;
            CDCREW = cDCREW;
            IDEMPL = iDEMPL;
            CDFLEET = cDFLEET;
            NMTABLE = nMTABLE;
            NMCOLUMN = nMCOLUMN;
            FGDATAERROR = fGDATAERROR;
            TSERRORLOGGED = tSERRORLOGGED;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cD_SEQ_ERROR")]
        public long? CDSEQERROR { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cD_SQLCODE")]
        public long? CDSQLCODE { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nM_INTERFACE")]
        public string NMINTERFACE { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tS_ERROR")]
        public DateTime? TSERROR { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "txT_SQLERRTEXT")]
        public string TxTSQLERRTEXT { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "txT_IFERROR")]
        public string TxTIFERROR { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cD_SEQ_ERROR_RUN")]
        public long? CDSEQERRORRUN { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cD_DIST")]
        public string CDDIST { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cD_WR")]
        public long? CDWR { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cD_WORKPACKET")]
        public long? CDWORKPACKET { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cD_PROJECT")]
        public string CDPROJECT { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cD_CREW")]
        public string CDCREW { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "iD_EMPL")]
        public string IDEMPL { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cD_FLEET")]
        public string CDFLEET { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nM_TABLE")]
        public string NMTABLE { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nM_COLUMN")]
        public string NMCOLUMN { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fG_DATA_ERROR")]
        public string FGDATAERROR { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tS_ERROR_LOGGED")]
        public DateTime? TSERRORLOGGED { get; set; }

    }
}
