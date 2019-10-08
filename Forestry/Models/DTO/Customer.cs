using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Forestry.Models.DTO
{
    public static class MyExtensions
    {
        public static string NullSafeTrim(this string value)
        {
            if (value != null)
            {
                value = value.Trim();
            }

            return value;
        }
    }
    public class Customer
    {
        /// <summary>
        /// Initializes a new instance of the Customer class.
        /// </summary>
        public Customer() { }
        
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "workRequestId")]
        public long? WorkRequestId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "phones")]
        public Phones Phones { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "customerType")]
        public string CustomerType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ssn")]
        public string Ssn { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "effectiveMoveInDate")]
        public string EffectiveMoveInDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dogCode")]
        public string DogCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "customerId")]
        public string CustomerId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "premiseId")]
        public string PremiseId { get; set; }

        private string _phoneNumber;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber
        {
            get { return _phoneNumber.NullSafeTrim(); }
            set { _phoneNumber = value.NullSafeTrim(); }
        }
    }
}
