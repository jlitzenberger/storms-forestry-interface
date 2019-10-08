using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forestry.Models
{
    public class Forestry
    {
        public string Id { get; set; }
        //public string id2 { get; set; }
        public string Status { get; set; }
        public Type Type { get; set; }
        public string WantedDate { get; set; }
        public string Comments { get; set; }
        public Contact Contact { get; set; }
        public Customer Customer { get; set; }
        public FinancialDetails FinancialDetails { get; set; }
        public GeographicDetails GeographicDetails { get; set; }
        public Location Location { get; set; }
        public Origin Origin { get; set; }

    }
    public class CodeModel
    {
        public string Value { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }
    public class Type
    {
        public string Value { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }
    public class PhoneNumber
    {
        public long Number { get; set; }
        public bool IsDefault { get; set; }
        public string AdditionalInformation { get; set; }
    }
    public class Contact
    {
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public string Name { get; set; }
        public string CallHours { get; set; }
    }
    public class Customer
    {
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public string Name { get; set; }
        public string CustomerId { get; set; }
    }
    public class FinancialDetails
    {
        public int ContractNumber { get; set; }
        public int IoNumber { get; set; }
        public int WbsNumber { get; set; }
    }
    public class GeographicDetails
    {
        public string Area { get; set; }
        public string County { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Municipality { get; set; }
        public string XCoordinate { get; set; }
        public string YCoordinate { get; set; }
    }
    public class Address
    {
        public string StreetNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string FormattedAddress { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
    }
    public class Location
    {
        public Address Address { get; set; }
        public string Directions { get; set; }
        public string MarkingInstructions { get; set; }
        public string PoleNumber { get; set; }
        public string TreeLocation { get; set; }
    }
    public class Company
    {
        public string Value { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }
    public class Origin
    {
        public Company Company { get; set; }
        public string ElectricMeterNumber { get; set; }
        public string FeederNumber { get; set; }
        public string OriginOrderTimestamp { get; set; }
        public string OriginSystem { get; set; }
        public string OriginSystemId { get; set; }
        public string PremiseId { get; set; }
        public string Source { get; set; }
        public string Voltage { get; set; }
    }


}
