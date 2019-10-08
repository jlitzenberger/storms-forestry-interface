using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Forestry.Models.DTO
{
    public class WorkRequest : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            //base
            if (Id == null || Id <= 0)
            {
                results.Add(new ValidationResult("Work Request ID is null or empty", new List<string>() { "Id" }));
            }
            if (string.IsNullOrEmpty(RequiredDate))
            {
                results.Add(new ValidationResult("Required by date is null or empty", new List<string>() { "RequiredDate" }));
            }
            if (string.IsNullOrEmpty(IoInstallation))
            {
                results.Add(new ValidationResult("IO Installation is null or empty", new List<string>() { "IoInstallation" }));
            }
            if (string.IsNullOrEmpty(CrewHeadquarter))
            {
                results.Add(new ValidationResult("Area is null or empty", new List<string>() { "CrewHeadquarter" }));
            }
            if (string.IsNullOrEmpty(JobType))
            {
                results.Add(new ValidationResult("Job Type is null or empty", new List<string>() { "JobType" }));
            }

            //customer
            if (Customers != null && Customers.Count > 0)
            {
                if (string.IsNullOrEmpty(Customers[0]?.Name))
                {
                    results.Add(new ValidationResult("Customer name is null or empty", new List<string>() {"Customers[0]?.Name"}));
                }
                if (string.IsNullOrEmpty(Customers[0]?.PhoneNumber))
                {
                    results.Add(new ValidationResult("Customer phone is null or empty", new List<string>() { "Customers[0]?.PhoneNumber" }));
                }
                if (!string.IsNullOrEmpty(Customers[0]?.PhoneNumber) && Customers[0]?.PhoneNumber.Length != 10)
                {
                    results.Add(new ValidationResult("Customer phone does not contain enough digits", new List<string>() { "Customers[0]?.PhoneNumber" }));
                }
            }
            else
            {
                //results.Add(new ValidationResult("Customer informaton is missing", new List<string>() { "Customers" }));
                results.Add(new ValidationResult("Customer name is null or empty", new List<string>() { "Customers[0]?.Name" }));
                results.Add(new ValidationResult("Customer phone is null or empty", new List<string>() { "Customers[0]?.PhoneNumber" }));
            }

            //contact
            if (string.IsNullOrEmpty(ContactName))
            {
                results.Add(new ValidationResult("Contact name is null or empty", new List<string>() { "ContactName" }));
            }
            if (string.IsNullOrEmpty(ContactPhone.Trim()))
            {
                results.Add(new ValidationResult("Contact phone is null or empty", new List<string>() { "ContactPhone" }));
            }

            //address
            if (string.IsNullOrEmpty(Address?.FreeFormat) && (string.IsNullOrEmpty(Geo?.XCoordinate) || string.IsNullOrEmpty(Geo?.YCoordinate)))
            {
                results.Add(new ValidationResult("Address or X/Y coordinate information is missing", new List<string>() { "Address" }));

                //if (string.IsNullOrEmpty(Address?.FreeFormat))
                //{
                //    results.Add(new ValidationResult("Address is null or empty", new List<string>() { "Address.FreeFormat" }));
                //}

                //if (!string.IsNullOrEmpty(Geo?.XCoordinate) && !string.IsNullOrEmpty(Geo?.YCoordinate))
                //{
                //    if (string.IsNullOrEmpty(Geo?.XCoordinate))
                //    {
                //        results.Add(new ValidationResult("XCoordinate is null or empty", new List<string>() { "Geo.XCoordinate" }));
                //    }
                //    if (string.IsNullOrEmpty(Geo?.YCoordinate))
                //    {
                //        results.Add(new ValidationResult("YCoordinate is null or empty", new List<string>() { "Geo.YCoordinate" }));
                //    }
                //}
            }
            //else
            //{
            //    results.Add(new ValidationResult("Address information is missing", new List<string>() { "Address" }));
            //}

            return results;
        }
        /// <summary>
        /// Initializes a new instance of the WorkRequest class.
        /// </summary>
        public WorkRequest() { }
        
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "district")]
        public string District { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workCompletedDate")]
        public string WorkCompletedDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workRequestClosedDate")]
        public string WorkRequestClosedDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "jobDescription")]
        public string JobDescription { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "requiredDate")]
        public string RequiredDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "crewHeadquarter")]
        public string CrewHeadquarter { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workType")]
        public string WorkType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "jobCode")]
        public string JobCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "jobType")]
        public string JobType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "reviewDate")]
        public string ReviewDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "suprevisorId")]
        public string SuprevisorId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "project")]
        public string Project { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "projectName")]
        public string ProjectName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ioInstallation")]
        public string IoInstallation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ioRemoval")]
        public string IoRemoval { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ioTransfer")]
        public string IoTransfer { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ioRevenue")]
        public string IoRevenue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "meterNo")]
        public string MeterNo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dateCanceled")]
        public string DateCanceled { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "canceled")]
        public bool? Canceled { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "assignedTo")]
        public string AssignedTo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "priority")]
        public string Priority { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workRequestRelatedTo")]
        public long? WorkRequestRelatedTo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "externalJobNumber")]
        public string ExternalJobNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "externalSystemId")]
        public string ExternalSystemId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hrEstTime")]
        public double? HrEstTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "resolution")]
        public string Resolution { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "contactName")]
        public string ContactName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "contactPhone")]
        public string ContactPhone { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "geo")]
        public Geo Geo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "customers")]
        public List<Customer> Customers { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "extraDetails")]
        public ExtraDetails ExtraDetails { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "premises")]
        public List<Premise> Premises { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "remarks")]
        public List<Remark> Remarks { get; set; }
    }
}
