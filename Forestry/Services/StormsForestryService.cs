using Forestry.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;
using Forestry.Requestors;
using WM.STORMS.BusinessLayer.Models;
using WM.STORMS.DataAccessLayer;
using WorkPacket = Forestry.Models.DTO.WorkPacket;
using WorkRequest = Forestry.Models.DTO.WorkRequest;

namespace Forestry.Services
{
    public class twmwr
    {
        public string ExternalId { get; set; }
        public string ExternalJob { get; set; }
    }
    public class StormsForestryService
    {
        private readonly IResourse<dynamic> _workRequestRequestor;
        private readonly IResourse<List<Forestry.Models.DTO.Customer>> _workRequestCustomersRequestor;
        private readonly IResourse<List<Forestry.Models.DTO.Premise>> _workRequestPremisesRequestor;
        private readonly IResourse<Forestry.Models.DTO.ExtraDetails> _workRequestExtraDetailsRequestor;
        private readonly IResourse<List<Forestry.Models.DTO.Remark>> _workRequestRemarksRequestor;
        private readonly IResourse<Forestry.Models.DTO.MilestoneRequirement> _workRequestMilestoneRequirementRequestor;
        private readonly IResourse<string> _stormsWorkQueueRequestor;
        private readonly IResourse<ForestryRequest> _forestryRequestor;
        private readonly IResourse<Incident> _incidentRequestor;
        private readonly IResourse<Forestry.Models.DTO.WorkRequestTracking> _workRequestTrackingRequestor;

        private WM.STORMS.DataAccessLayer.Repositories.UnitOfWork _uowStorms;
        private string _baseManagedWorkApiUri;
 
        protected WM.STORMS.DataAccessLayer.Repositories.UnitOfWork UowStorms
        {
            get
            {
                if (_uowStorms == null)
                {
                    StormsEntities _context = new StormsEntities();
                    _context.Database.Connection.ConnectionString = Properties.Settings.Default.STORMS_EntityFrameworkConnectionString;
                    _uowStorms = new WM.STORMS.DataAccessLayer.Repositories.UnitOfWork(_context);
                }
                return _uowStorms;
            }
            set
            {
                _uowStorms = value;
            }
        }
        protected string BaseManagedWorkApiUri
        {
            get
            {
                if (_baseManagedWorkApiUri == null)
                {
                    _baseManagedWorkApiUri = Properties.Settings.Default.ManagedWorkOrderUriHost + Properties.Settings.Default.ManagedWorkOrderUri;
                }
                return _baseManagedWorkApiUri;
            }
            set
            {
                _baseManagedWorkApiUri = value;
            }
        }

        public StormsForestryService
        (
              IResourse<dynamic> workRequestRequestor
            , IResourse<List<Forestry.Models.DTO.Customer>> workRequestCustomersRequestor
            , IResourse<List<Forestry.Models.DTO.Premise>> workRequestPremisesRequestor
            , IResourse<Forestry.Models.DTO.ExtraDetails> workRequestExtraDetailsRequestor
            , IResourse<List<Forestry.Models.DTO.Remark>> workRequestRemarksRequestor
            , IResourse<Forestry.Models.DTO.MilestoneRequirement> workRequestMilestoneRequirementRequestor
            , IResourse<string> stormsWorkQueueRequestor
            , IResourse<ForestryRequest> forestryRequestor
            , IResourse<Incident> incidentRequestor
            , IResourse<Forestry.Models.DTO.WorkRequestTracking> workRequestTrackingRequestor
        )
        {
            _workRequestRequestor = workRequestRequestor;
            _workRequestCustomersRequestor = workRequestCustomersRequestor;
            _workRequestPremisesRequestor = workRequestPremisesRequestor;
            _workRequestExtraDetailsRequestor = workRequestExtraDetailsRequestor;
            _workRequestRemarksRequestor = workRequestRemarksRequestor;
            _workRequestMilestoneRequirementRequestor = workRequestMilestoneRequirementRequestor;
            _stormsWorkQueueRequestor = stormsWorkQueueRequestor;
            _forestryRequestor = forestryRequestor;
            _incidentRequestor = incidentRequestor;
            _workRequestTrackingRequestor = workRequestTrackingRequestor;
        }
        public void ProcessWorkPacket(Forestry.Models.DTO.WorkPacket workPacket)
        {
            Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][BEGIN--]-processing...");

            Models.DTO.WorkRequest workRequest = null;

            try
            {
                //call managed work API to get all the data
                Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][BEGIN--]-retrieving Managed Work Order data");
                workRequest = GetWorkRequestFromApi(workPacket);

                if (workRequest != null)
                {
                    //validate work request
                    Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][BEGIN--]-validating WorkRequest data");
                    List<ValidationResult> validationResults = ValidateWorkRequest(workRequest);

                    //process validation
                    if (validationResults == null || !validationResults.Any())
                    {
                        Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][SUCCESS]-valid WorkRequest data");
                        ValidationSuccess(workPacket, workRequest);
                    }
                    else
                    {
                        Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][SUCCESS]-invalid WorkRequest data");
                        ValidationInvalid(workPacket, workRequest, validationResults);
                    }
                }
                else
                {
                    Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "]" + " NOT FOUND");
                }

            }
            catch (Exception ex)
            {
                //add to tracking
                AddStormsTracking(workRequest, workPacket, "FOBATCH", "FODATCHK", "Failed to create order in Forestry system");

                //create IT Remedy Ticket
                CreateRemedyTicket(workRequest, workPacket, ex);

                Environment.ExitCode = 1;
            }
        }
        private void ValidationSuccess(WorkPacket workPacket, WorkRequest workRequest)
        {
            //add to tracking
            AddStormsTracking(workRequest, workPacket, "FOBATCH", "FODATCHK", "Forestry data validation Passed");
            
            //convert STORMS into forestry model
            Forestry.Models.ForestryRequest forestry = MapToForestry(workRequest, workPacket);

            //add to tracking
            AddStormsTracking(workRequest, workPacket, "FOBATCH", "FOCREATE", "Forestry order creation request sent");

            //send to Forestry to MQ
            ProcessForestry(workRequest, workPacket, forestry);
        }
        private void ValidationInvalid(WorkPacket workPacket, WorkRequest workRequest, List<ValidationResult> validationResults)
        {
            //add STORMS exception to the Job owner's Work Queue
            AddStormsWorkQueue(workRequest, workPacket, "Failed Forestry data validation");

            //add STORMS tracking Audit Log
            AddStormsTracking(workRequest, workPacket, "FOBATCH", "FODATCHK", "Forestry data validation Failed");

            //add STORMS requirement to say that the data is invalid
            StormsMilestoneRequirement(workRequest, workPacket);

            //create remedy ticket for invalid data
            CreateRemedyTicket(workRequest, workPacket, validationResults);
        }

        public List<Forestry.Models.DTO.WorkPacket> GetWorkPackets()
        {
            //var workPackets = UowStorms.GenericSqlRepo
            //    .RunRawSql<Forestry.Models.DTO.WorkPacket>(
            //        "select cd_wr WorkRequestId, cd_workpacket WorkPacketId " +
            //        "from twmworkpacket a " +
            //        "where a.cd_wr in (4004666) " +
            //        "and cd_crew_class = 'FO'")
            //    .ToList();

            var workPackets = UowStorms.GenericSqlRepo
                .RunRawSql<Forestry.Models.DTO.WorkPacket>(
                    " select cd_wr WorkRequestId, cd_workpacket WorkPacketId " +
                    "  from twmworkpacket a " +
                    " where a.CD_CREW = 'WEFO' " +
                    "   and a.CD_CREW_CLASS = 'FO' " +
                    "   and (A.CD_RESOLUTION is null or A.CD_RESOLUTION <> 'CP') " +
                    "   and not exists( " +
                    "           select * " +
                    "             from TWMWRAUDIT " +
                    "            where TWMWRAUDIT.CD_WR = a.CD_WR " +
                    "              and TWMWRAUDIT.ID_OPER = 'FOBATCH' " +
                    "              and TWMWRAUDIT.NM_FUNCTION = 'FOCREATE' " +
                    "              and TWMWRAUDIT.TP_CHANGE = 'Forestry order creation request sent' " +
                    "        ) " +
                    "   and ( " +
                    "      not exists( " +
                    "           select * " +
                    "             from TWMMILESTONERQMT " +
                    "            where TWMMILESTONERQMT.CD_RQMT = 624 " +
                    "              and a.CD_WR = TWMMILESTONERQMT.CD_WR " +
                    "        ) " +
                    "        or exists( " +
                    "           select * " +
                    "             from TWMMILESTONERQMT " +
                    "             where TWMMILESTONERQMT.CD_RQMT = 624 " +
                    "             and a.CD_WR = TWMMILESTONERQMT.CD_WR " +
                    "             and TWMMILESTONERQMT.ST_RQMT = 'C' " +
                    "        ) " +
                    ")"
                ).ToList();

            return workPackets;
        }
        private twmwr GetWorkRequestOrigin(Forestry.Models.DTO.WorkRequest workRequest)
        {
            var obj = UowStorms.GenericSqlRepo
                .RunRawSql<twmwr>(
                    " select twmwr.no_ext_sys_id externalid, twmwr.no_ext_job externaljob " +
                    " from twmwr " +
                    " where twmwr.cd_wr = " + workRequest.Id.ToString())
                .FirstOrDefault();

            return obj;
        }
        public Forestry.Models.DTO.WorkRequest GetWorkRequestFromApi(Forestry.Models.DTO.WorkPacket workPacket)
        {
            //get the work request resourse          
            dynamic workRequest = _workRequestRequestor.Get(new Uri(BaseManagedWorkApiUri + ResolveCurlyBrackets(Properties.Settings.Default.ManagedWorkOrderApiResourse_WorkRequest, workPacket.WorkRequestId.ToString())));

            //transform dynamic into work request DTO and resolve HATEOAS uri's
            Forestry.Models.DTO.WorkRequest wr = TransformDynamicWorkRequest(workRequest);

            Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][SUCCESS]-retrieved Managed Work Order data");

            return wr;
        }
        private Forestry.Models.DTO.WorkRequest TransformDynamicWorkRequest(dynamic workRequest)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(workRequest);
            Forestry.Models.DTO.WorkRequest wr = Newtonsoft.Json.JsonConvert.DeserializeObject<Forestry.Models.DTO.WorkRequest>(
                json,
                new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    TypeNameHandling = TypeNameHandling.None,
                    NullValueHandling = NullValueHandling.Include,
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                    Converters = { new Newtonsoft.Json.Converters.ExpandoObjectConverter() }
                }
            );

            wr.Customers = _workRequestCustomersRequestor.Get(new Uri(UriHack(workRequest.customersUri.ToString())));
            wr.Premises = _workRequestPremisesRequestor.Get(new Uri(UriHack(workRequest.premisesUri.ToString())));
            wr.ExtraDetails = _workRequestExtraDetailsRequestor.Get(new Uri(UriHack(workRequest.extraDetailsUri.ToString())));
            wr.Remarks = _workRequestRemarksRequestor.Get(new Uri(UriHack(workRequest.remarksUri.ToString())));

            return wr;
        }
        private List<ValidationResult> ValidateWorkRequest(Models.DTO.WorkRequest workRequest)
        {
            var objectToValidate = workRequest;
            var validationContext = new ValidationContext(objectToValidate);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(objectToValidate, validationContext, validationResults, false);

            if (!isValid)
            {
                return validationResults;
            }

            return null;
        }
        public ForestryRequest MapToForestry(Models.DTO.WorkRequest workRequest, Models.DTO.WorkPacket workPacket)
        {
            Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][BEGIN--]-converting WorkRequest into Forestry Job");

            Forestry.Models.ForestryRequest forestry = new Forestry.Models.ForestryRequest();

            forestry.CorellationId = Guid.NewGuid().ToString();
            //REQUIRED
            forestry.Timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            //REQUIRED
            forestry.Origin = new CodeModel();
            forestry.Origin.Value = "STORMS";
            //REQUIRED
            forestry.Method = "POST";

            //REQUIRED
            forestry.Model = new Models.Forestry();
            forestry.Model.Id = ((long)workRequest.Id).ToString();
            DateTime dateValue;
            if (DateTime.TryParse(workRequest.RequiredDate, out dateValue))
            {
                forestry.Model.WantedDate = DateTime.Parse(workRequest.RequiredDate).ToString("yyyy-MM-ddTHH:mm:ssZ");
            }
            forestry.Model.FinancialDetails = new FinancialDetails();
            forestry.Model.FinancialDetails.IoNumber = Convert.ToInt32(workRequest.IoInstallation);

            forestry.Model.GeographicDetails = new GeographicDetails();
            forestry.Model.GeographicDetails.Area = workRequest.CrewHeadquarter;

            forestry.Model.Type = new Models.Type();
            forestry.Model.Type.Value = workRequest.JobType;

            forestry.Model.Contact = new Contact();
            forestry.Model.Contact.Name = workRequest.ContactName;
            forestry.Model.Contact.PhoneNumbers = new List<PhoneNumber>();
            long contactPhoneResult;
            forestry.Model.Contact.PhoneNumbers.Add(new PhoneNumber
            {
                Number = (long.TryParse(workRequest.ContactPhone, out contactPhoneResult) == true) ? contactPhoneResult : 0,
                IsDefault = true,
            });

            if (workRequest.Customers != null && workRequest.Customers.Count > 0)
            {
                forestry.Model.Customer = new Models.Customer();
                forestry.Model.Customer.Name = workRequest.Customers[0].Name;

                if (!string.IsNullOrEmpty(workRequest.Customers[0].Phones.Number))
                {
                    forestry.Model.Customer.PhoneNumbers = new List<PhoneNumber>();
                    long extentionRemoved = 0;
                    if (workRequest.Customers[0].Phones.Number.IndexOf(" ") > 0)
                    {
                        extentionRemoved =
                            Convert.ToInt64(
                                ((string) workRequest.Customers[0].Phones.Number).Substring(
                                    0,
                                    workRequest.Customers[0].Phones.Number.IndexOf(" ")
                                )
                            );
                    }
                    else
                    {
                        extentionRemoved = Convert.ToInt64(workRequest.Customers[0].Phones.Number);
                    }

                    string extention = string.Empty;
                    if (workRequest.Customers[0].Phones.Number.IndexOf(" ") > 0)
                    {
                        extention =
                            ((string) workRequest.Customers[0].Phones.Number).Substring(
                                workRequest.Customers[0].Phones.Number.IndexOf(" "),
                                workRequest.Customers[0].Phones.Number.Length - workRequest.Customers[0].Phones.Number.IndexOf(" ")
                            );
                    }

                    forestry.Model.Customer.PhoneNumbers.Add(new PhoneNumber
                    {
                        Number = extentionRemoved,
                        IsDefault = true,
                        AdditionalInformation = extention
                    });
                }
            }

            forestry.Model.Location = new Location();
            forestry.Model.Location.Address = new Models.Address();
            forestry.Model.Location.Address.StreetNumber = workRequest.Address.StreetNumber != null ? workRequest.Address.StreetNumber : string.Empty;
            forestry.Model.Location.Address.StreetAddress = workRequest.Address.StreetPrefix != null ? workRequest.Address.StreetPrefix : string.Empty;
            forestry.Model.Location.Address.StreetAddress =
                workRequest.Address.StreetName != null
                    ? forestry.Model.Location.Address.StreetAddress + " " + workRequest.Address.StreetName
                    : forestry.Model.Location.Address.StreetAddress;
            forestry.Model.Location.Address.StreetAddress =
                workRequest.Address.StreetType != null
                    ? forestry.Model.Location.Address.StreetAddress + " " + workRequest.Address.StreetType
                    : forestry.Model.Location.Address.StreetAddress;
            forestry.Model.Location.Address.StreetAddress =
                workRequest.Address.StreetSuffix != null
                    ? forestry.Model.Location.Address.StreetAddress + " " + workRequest.Address.StreetSuffix
                    : forestry.Model.Location.Address.StreetAddress;
            forestry.Model.Location.Address.City = workRequest.Address.City;
            forestry.Model.Location.Address.State = workRequest.Address.State;
            forestry.Model.Location.Address.County = workRequest.Address.County;
            forestry.Model.Location.Address.PostalCode = workRequest.Address.Zip;
            forestry.Model.Location.Address.FormattedAddress = workRequest.Address.FreeFormat;

            forestry.Model.GeographicDetails = new GeographicDetails();
            forestry.Model.GeographicDetails.XCoordinate = workRequest?.Geo?.XCoordinate;
            forestry.Model.GeographicDetails.YCoordinate = workRequest?.Geo?.YCoordinate;

            if (workRequest.Geo != null)
            {
                forestry.Model.GeographicDetails.Area = workRequest?.Geo?.Zone;
            }

            forestry.Model.Origin = new Origin();
            //REQUIRED
            forestry.Model.Origin.Company = new Company();
            forestry.Model.Origin.Company.Value = "30";
            //REQUIRED
            forestry.Model.Origin.OriginOrderTimestamp = DateTime.Parse(workRequest.RequiredDate).ToString("yyyy-MM-ddTHH:mm:ssZ");
            //REQUIRED
            //forestry.Model.Origin.OriginSystem = "STORMS";
            forestry.Model.Origin.OriginSystem = GetOrigin(workRequest);

            //REQUIRED
            forestry.Model.Origin.OriginSystemId = ((long)workRequest.Id).ToString();
           
            if (workRequest.Premises != null && workRequest.Premises.Count > 0)
            {
                forestry.Model.Origin.PremiseId = workRequest.Premises[0].PremiseId;
            }
            
            if (workRequest.ExtraDetails != null)
            {
                forestry.Model.Origin.FeederNumber = workRequest.ExtraDetails.FeederId;
                forestry.Model.Origin.Voltage = workRequest.ExtraDetails.ServiceVoltageCode;
            }

            if (workRequest.Remarks != null && workRequest.Remarks.Count > 0)
            {
                foreach (var item in workRequest.Remarks)
                {
                    forestry.Model.Comments += item.Type + " " + item.RemarkText;
                }
            }

            Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][SUCCESS]-converted WorkRequest into Forestry Job");

            return forestry;
        }

        private string GetOrigin(WorkRequest workRequest)
        {
            var origin = GetWorkRequestOrigin(workRequest);

            if (origin != null)
            {
                if (origin.ExternalJob != null)
                {
                    if (origin.ExternalJob.Contains("ELECTRIC"))
                    {
                        return "PCAD";
                    }
                }
                if (origin.ExternalId != null)
                {
                    if (origin.ExternalId.Contains("CSS"))
                    {
                        return "CSS";
                    }
                }
                if (origin.ExternalId != null)
                {
                    if (origin.ExternalId.Contains("FORESTRY"))
                    {
                        return "FORESTRY";
                    }
                }
            }

            return "STORMS";
        }
        public void ProcessForestry(Models.DTO.WorkRequest workRequest, Models.DTO.WorkPacket workPacket, ForestryRequest forestry)
        {
            Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][BEGIN--]-sending Forestry Job to IBM MQ");

            try
            {
                var obj = Newtonsoft.Json.JsonConvert.SerializeObject(forestry);

                HttpResponseMessage htm = _forestryRequestor.Post(
                    new Uri(Properties.Settings.Default.MqApiUriHost + Properties.Settings.Default.MqApiUri),
                    forestry
                );

                Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][SUCCESS]-sent Forestry Job to IBM MQ");
            }
            catch (HttpResponseException ex)
            {
                AddStormsTracking(workRequest, workPacket, "FOBATCH", "FOCREATE", "Failed to create order in Forestry system");

                foreach (var header in ex.Response.Headers)
                {
                    Console.WriteLine(header.Key + ", " + header.Value.ToList()[0]);
                }

                CreateRemedyTicket(workRequest, workPacket, ex);
            }
        }
        public void StormsMilestoneRequirement(Models.DTO.WorkRequest workRequest, Models.DTO.WorkPacket workPacket)
        {
            try
            {
                //check to see if the requirement exists on the work request
                Forestry.Models.DTO.MilestoneRequirement mreq = _workRequestMilestoneRequirementRequestor.Get(
                    new Uri(BaseManagedWorkApiUri + ResolveCurlyBrackets(Properties.Settings.Default.ManagedWorkOrderApiResourse_MilestoneRequirement, workPacket.WorkRequestId.ToString(), "624"))
                );

                if (mreq == null)
                {
                    CreateMilestoneRequirement(workRequest, workPacket);
                }
                else
                {
                    mreq.Status = "R";
                    UpdateMilestoneRequirement(workRequest, workPacket, mreq);
                }
            }
            catch (HttpResponseException ex)
            {
                Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][FAILED-]-failed to log to STORMS milestone requirement");
                Console.WriteLine("Http Status Code:" + ex.Response.StatusCode.ToString());
                Console.WriteLine("*************Http Response Error***************");

                foreach (var header in ex.Response.Headers)
                {
                    Console.WriteLine(header.Key + ", " + header.Value.ToList()[0]);
                }

                Console.WriteLine("*************Http Response Error***************");

                CreateRemedyTicket(workRequest, workPacket, ex);
            }
        }
        public void AddStormsWorkQueue(Models.DTO.WorkRequest workRequest, Models.DTO.WorkPacket workPacket, string details)
        {
            //add to STORMS TWMIFEXCEPTIONCOND table.. then an existing STORMS process will automatically run to add it to STORMS
            try
            {
                Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][BEGIN--]-logging invalid data to STORMS work queue");

                HttpResponseMessage hrm = _stormsWorkQueueRequestor.Post(
                    new Uri(BaseManagedWorkApiUri + ResolveCurlyBrackets(Properties.Settings.Default.ManagedWorkOrderApiResourse_IfExceptionConditions, workRequest.Id.ToString())),
                    new IFExceptionCond()
                    {
                        CD_DIST = workRequest.District,
                        CD_WR = Convert.ToInt64(workRequest.Id),
                        DS_COND = details,
                        ID_OPER = workRequest.AssignedTo,
                        FG_ERROR = "N",
                        TS_IFEXCEPTIONCOND = DateTime.Now,
                        CD_SEQ = 0
                    }
                );

                Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][SUCCESS]-logged invalid data to STORMS work queue");
            }
            catch (HttpResponseException ex)
            {
                Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][FAILED-]-failed to log to STORMS work queue");
                Console.WriteLine("Http Status Code:" + ex.Response.StatusCode.ToString());
                Console.WriteLine("*************Http Response Error***************");

                foreach (var header in ex.Response.Headers)
                {
                    Console.WriteLine(header.Key + ", " + header.Value.ToList()[0]);
                }

                Console.WriteLine("*************Http Response Error***************");
                
                CreateRemedyTicket(workRequest, workPacket, ex);
            }
        }
        public void AddStormsTracking(Models.DTO.WorkRequest workRequest, Models.DTO.WorkPacket workPacket, string operatorId, string function, string typeOfChange)
        {
            try
            {
                Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][BEGIN--]-adding to STORMS tracking audit log");

                string timeStamp = Convert.ToDateTime(DateTime.Now).ToString("dd-MMM-yy HH:mm:ss");

                HttpResponseMessage hrm = _workRequestTrackingRequestor.Post(
                    new Uri(BaseManagedWorkApiUri + ResolveCurlyBrackets(Properties.Settings.Default.ManagedWorkOrderApiResourse_WorkRequestTrackings, workRequest.Id.ToString())),
                    new Forestry.Models.DTO.WorkRequestTracking()
                    {
                        District = workRequest.District.Trim(),
                        Status = workRequest.Status,
                        OperatorId = operatorId,
                        WorkRequestId = Convert.ToInt64(workRequest.Id),
                        ChangeDate = Convert.ToDateTime(timeStamp),
                        Function = function,
                        TypeOfChange = typeOfChange
                    }
                );

                Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][SUCCESS]-added to STORMS tracking audit log");
            }
            catch (HttpResponseException ex)
            {
                Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][FAILED-]-failed to log to STORMS tracking audit log");
                Console.WriteLine("*************Http Response Error***************");
                Console.WriteLine("Http Status Code:" + ex.Response.StatusCode.ToString());

                foreach (var header in ex.Response.Headers)
                {
                    Console.WriteLine(header.Key + ", " + header.Value.ToList()[0]);
                }

                Console.WriteLine("*************Http Response Error***************");

                CreateRemedyTicket(workRequest, workPacket, ex);
            }
        }
        public void CreateRemedyTicket(Forestry.Models.DTO.WorkRequest workRequest, Forestry.Models.DTO.WorkPacket workPacket, List<ValidationResult> errors)
        {
            try
            {
                Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][BEGIN--]-sending invalid data to Remedy");

                string allErrors = string.Empty;
                foreach (var str in errors)
                {
                    allErrors += str + $"\r\n";
                }
                string notes = "[WR: " + workPacket.WorkRequestId + " " + "WP: " + workPacket.WorkPacketId + "]" + "\r\n" + allErrors;

                HttpResponseMessage hrm = _incidentRequestor.Post(
                    new Uri(Properties.Settings.Default.RemedyUriHost + Properties.Settings.Default.RemedyUri),
                    new Incident
                    {
                        AssignedSupportGroup = "CO - Work Management Process",
                        ClientService = "IT - Work Management",
                        Company = "WEC Business Services", //or We Energies
                        Impact = "4-Minor/Localized",
                        Urgency = "4-Low",
                        Notes = notes,
                        Summary = "STORMS to Forestry validation failed."
                    }
                );

                var incident = hrm.Headers.Single(m => m.Key == "X-Id");
                string incidentNumber = incident.Value.ToList()[0];

                Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][SUCCESS]-" + incidentNumber + "" + " created in Remedy");
            }
            catch (HttpResponseException exception)
            {
                Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][FAILED-]-failed to send invalid data to Remedy");
                Console.WriteLine("*************Http Response Error***************");
                Console.WriteLine("Http Status Code:" + exception.Response.StatusCode.ToString());
                
                foreach (var header in exception.Response.Headers)
                {
                    Console.WriteLine(header.Key + ", " + header.Value.ToList()[0]);
                }

                Console.WriteLine("*************Http Response Error***************");
            }
        }
        public void CreateRemedyTicket(Forestry.Models.DTO.WorkRequest workRequest, Forestry.Models.DTO.WorkPacket workPacket, Exception ex)
        {
            try
            {
                Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][BEGIN--]-sending error data to Remedy");

                string stacktrace = ex?.InnerException?.StackTrace;

                HttpResponseMessage hrm = _incidentRequestor.Post(
                    new Uri(Properties.Settings.Default.RemedyUriHost + Properties.Settings.Default.RemedyUri),
                    new Incident
                    {
                        AssignedSupportGroup = "IT - Work Management",
                        ClientService = "IT - Work Management",
                        Company = "WEC Business Services", //or We Energies
                        Impact = "4-Minor/Localized",
                        Urgency = "4-Low",
                        Notes = stacktrace,
                        Summary = "STORMS to Forestry interface error."
                    }
                );

                var incident = hrm.Headers.SingleOrDefault(m => m.Key == "X-Id");
                string incidentNumber = incident.Value.ToList()[0];

                Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][SUCCESS]-" + incidentNumber + "" + " created in Remedy");
            }
            catch (HttpResponseException exception)
            {
                Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][FAILED-]-failed to send error data to Remedy");
                Console.WriteLine("*************Http Response Error***************");
                Console.WriteLine("Http Status Code:" + exception.Response.StatusCode.ToString());

                foreach (var header in exception.Response.Headers)
                {
                    Console.WriteLine(header.Key + ", " + header.Value.ToList()[0]);
                }

                Console.WriteLine("*************Http Response Error***************");
            }
        }
        private void UpdateMilestoneRequirement(WorkRequest workRequest, WorkPacket workPacket, Models.DTO.MilestoneRequirement mreq)
        {
            Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][BEGIN--]-updating invalid data STORMS milestone requirement");
            
            HttpResponseMessage hrm = _workRequestMilestoneRequirementRequestor.Put(
                new Uri(BaseManagedWorkApiUri + ResolveCurlyBrackets(Properties.Settings.Default.ManagedWorkOrderApiResourse_MilestoneRequirement, workRequest.Id.ToString(), "624")),
                mreq
            );

            Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][SUCCESS]-updated invalid data STORMS milestone requirement");
        }
        private void CreateMilestoneRequirement(WorkRequest workRequest, WorkPacket workPacket)
        {
            Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][BEGIN--]-adding invalid data STORMS milestone requirement");

            //add to STORMS TWMIFREQUIREMENT table.. then an existing STORMS process will automatically run to add it to STORMS
            HttpResponseMessage hrm = _workRequestMilestoneRequirementRequestor.Post(
                new Uri(BaseManagedWorkApiUri + ResolveCurlyBrackets(Properties.Settings.Default.ManagedWorkOrderApiResourse_MilestoneRequirements, workRequest.Id.ToString())),
                new MilestoneRequirement()
                {
                    WorkRequestId = workRequest.Id.ToString(),
                    District = workRequest.District,
                    RequirementId = "624",
                    Description = "Forestry Data Invalid",
                    Status = "R"
                }
            );

            Console.WriteLine("[WR:" + workPacket.WorkRequestId + " " + "WP:" + workPacket.WorkPacketId + "][SUCCESS]-added invalid data STORMS milestone requirement");
        }
        private string ResolveCurlyBrackets(string curlyBrackets, params string[] list)
        {
            int i = 0;
            var pattern = @"{.*?}";
            var replaced = Regex.Replace(curlyBrackets, pattern,
                delegate (Match m)
                {
                    string match = list[i].ToString();
                    i++;
                    return match;
                });

            return replaced;
        }
        //TODO: take this out - there is a problem with port numbers on different web server envs using HATEOAS
        private string UriHack(string uri)
        {
            var env = Properties.Settings.Default.Env.ToUpper();

            Uri newUri = new Uri(uri);

            if (env != "DEV")
            {
                UriBuilder builder = new UriBuilder(newUri);
                builder.Port = -1;
                newUri = builder.Uri;
            }

            return newUri.AbsoluteUri;
        }
    }
}
