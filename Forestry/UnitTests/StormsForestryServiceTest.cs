//using Forestry.Models;
//using Forestry.Services;
//using Moq;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Dynamic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Http;
//using Forestry.Requestors;
//using Newtonsoft.Json;
//using WM.STORMS.BusinessLayer.Models;
//using WM.STORMS.DataAccessLayer;
//using Xunit;
//using Xunit.Sdk;
//using Customer = Forestry.Models.DTO.Customer;

//namespace Forestry.UnitTests
//{
//    public class StormsForestryServiceTest
//    {
//        [Fact]
//        public void TestProcessWorkPacket()
//        {
//            //arrange - mock it up
//            dynamic workRequest = new System.Dynamic.ExpandoObject();
//            workRequest.id = 4011646;
//            workRequest.district = "NOEL";
//            workRequest.contactName = "Batman";
//            workRequest.contactPhone = "4141234567";
//            workRequest.requiredDate = "2018-10-30 00:00:00";
//            workRequest.ioInstallation = "5445";
//            workRequest.crewHeadquarter = "RASC";
//            workRequest.jobType = "NSDBCUSTOM";
//            workRequest.address = new Models.DTO.Address
//            {
//                FreeFormat = "3147 N Humboldt Blvd."
//            };
//            workRequest.customersUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.premisesUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.extraDetailsUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.remarksUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";

//            Mock<IResourse<dynamic>> moqWorkRequest = new Mock<IResourse<dynamic>>();
//            moqWorkRequest.Setup(m => m.Get(It.IsAny<Uri>())).Returns((object)workRequest);

//            Mock<IResourse<List<Forestry.Models.DTO.Customer>>> moqCustomer = new Mock<IResourse<List<Forestry.Models.DTO.Customer>>>();
//            moqCustomer.Setup(
//                m => m.Get(It.IsAny<Uri>())
//            ).Returns(
//                new List<Forestry.Models.DTO.Customer>()
//                {
//                    new Forestry.Models.DTO.Customer
//                    {
//                        WorkRequestId = 4011646,
//                        Name =  "Superman",
//                        Phones = new Models.DTO.Phones()
//                        {
//                            Number = "4141234567"
//                        }
//                    }
//                }
//            );

//            Mock<IResourse<List<Forestry.Models.DTO.Premise>>> moqPremise = new Mock<IResourse<List<Forestry.Models.DTO.Premise>>>();
//            moqPremise.Setup(
//                m => m.Get(It.IsAny<Uri>())
//            ).Returns(
//                new List<Forestry.Models.DTO.Premise>()
//            );

//            Mock<IResourse<Forestry.Models.DTO.ExtraDetails>> moqExtraDetail = new Mock<IResourse<Forestry.Models.DTO.ExtraDetails>>();
//            moqExtraDetail.Setup(
//                m => m.Get(It.IsAny<Uri>())
//            ).Returns(
//                new Forestry.Models.DTO.ExtraDetails()
//            );

//            Mock<IResourse<List<Forestry.Models.DTO.Remark>>> moqRemarks = new Mock<IResourse<List<Forestry.Models.DTO.Remark>>>();
//            moqRemarks.Setup(
//                m => m.Get(It.IsAny<Uri>())
//            ).Returns(
//                new List<Forestry.Models.DTO.Remark>
//                {
//                    new Forestry.Models.DTO.Remark
//                    {
//                        WorkRequestId = 4011646,
//                        RemarkText = "Some Text"
//                    },
//                    new Forestry.Models.DTO.Remark
//                    {
//                        WorkRequestId = 4011646,
//                        RemarkText = "Some Other Text"
//                    }
//                }
//            );

//            Mock<IResourse<string>> moqStormsWorkQueue = new Mock<IResourse<string>>();
//            moqStormsWorkQueue.Setup(
//                m => m.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<IFExceptionCond>(x => x.CD_DIST == "NOEL" && x.CD_WR == 4011646 && x.DS_COND == "Failed Forestry data validation")
//                )
//            ).Returns(
//                new HttpResponseMessage()
//                {
//                    StatusCode = System.Net.HttpStatusCode.Created,
//                    Content = new System.Net.Http.StringContent("", Encoding.UTF8, "application/json")
//                }
//            );

//            Mock<IResourse<Forestry.Models.DTO.WorkRequestTracking>> moqWorkRequestTracking = new Mock<IResourse<Forestry.Models.DTO.WorkRequestTracking>>();
//            moqWorkRequestTracking.Setup(
//                m => m.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<Forestry.Models.DTO.WorkRequestTracking>(x => x.WorkRequestId == 4011646 && x.District == "NOEL")
//                )
//            ).Returns(
//                new HttpResponseMessage()
//                {
//                    RequestMessage = new HttpRequestMessage(HttpMethod.Post, It.IsAny<Uri>())
//                    {
//                        Method = HttpMethod.Post,
//                        Content = new System.Net.Http.StringContent("{  \"WorkRequestId\": 4011646 }")
//                    },
//                    StatusCode = System.Net.HttpStatusCode.Created,
//                    Content = new System.Net.Http.StringContent("", Encoding.UTF8, "application/json")
//                }
//            );

//            Mock<IResourse<string>> moqStormsMilestoneRequirement = new Mock<IResourse<string>>();
//            moqStormsMilestoneRequirement.Setup(m => m.Post(
//                It.IsAny<Uri>(),
//                It.Is<MilestoneRequirement>(x => x.WorkRequestId == "4011646" && x.District == "NOEL"))
//            ).Returns(
//                new HttpResponseMessage()
//                {
//                    StatusCode = System.Net.HttpStatusCode.Created,
//                    Content = new System.Net.Http.StringContent("", Encoding.UTF8, "application/json")
//                }
//            );

//            HttpResponseMessage incidentResponse = new HttpResponseMessage()
//            {
//                StatusCode = System.Net.HttpStatusCode.Created
//            };
//            incidentResponse.Headers.Add("X-Id", "INC123");

//            Mock<IResourse<Incident>> moqIncident = new Mock<IResourse<Incident>>();
//            moqIncident.Setup(
//                m => m.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<Incident>(x => x.Notes == "[WR: 4011646 WP: 2322760]\r\nRequired by date is null or empty\r\nIO Installation is null or empty\r\nArea is null or empty\r\nJob Type is null or empty\r\nContact name is null or empty\r\nContact phone is null or empty\r\nCustomer informaton is missing\r\nContact name is null or empty\r\nContact phone is null or empty\r\nAddress information is missing\r\n")
//                )
//            ).Returns(incidentResponse);

//            StormsForestryService service = new StormsForestryService(
//                moqWorkRequest.Object,
//                moqCustomer.Object,
//                moqPremise.Object,
//                moqExtraDetail.Object,
//                moqRemarks.Object,
//                moqStormsMilestoneRequirement.Object,
//                moqStormsWorkQueue.Object,
//                null,
//                moqIncident.Object,
//                moqWorkRequestTracking.Object
//            );

//            //act
//            service.ProcessWorkPacket(
//                new Models.DTO.WorkPacket
//                {
//                    WorkRequestId = 4011646,
//                    WorkPacketId = 2322760
//                }
//            );

//            //assert
//            Assert.NotNull(service);
//            //verify it was called
//            moqWorkRequest.Verify(
//                i => i.Get(It.IsAny<Uri>())
//            );
//            moqStormsWorkQueue.Verify(i => i.Post(
//                It.IsAny<Uri>(),
//                It.Is<IFExceptionCond>(x => x.CD_DIST == "NOEL" && x.CD_WR == 4011646))
//            );
//            moqWorkRequestTracking.Verify(
//                i => i.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<Forestry.Models.DTO.WorkRequestTracking>(x => x.WorkRequestId == 4011646 && x.District == "NOEL")
//                )
//            );
//            moqStormsMilestoneRequirement.Verify(i => i.Post(
//                It.IsAny<Uri>(),
//                It.Is<MilestoneRequirement>(x => x.District == "NOEL"))
//            );
//        }
//        [Fact]
//        public void TestProcessWorkPacket_Invalid()
//        {
//            //arrange - mock it up
//            dynamic workRequest = new System.Dynamic.ExpandoObject();
//            workRequest.id = 4011646;
//            workRequest.district = "NOEL";
//            workRequest.customersUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.premisesUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.extraDetailsUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.remarksUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";

//            Mock<IResourse<dynamic>> moqWorkRequest = new Mock<IResourse<dynamic>>();
//            moqWorkRequest.Setup(m => m.Get(It.IsAny<Uri>())).Returns((object) workRequest);

//            Mock<IResourse<List<Forestry.Models.DTO.Customer>>> moqCustomer = new Mock<IResourse<List<Forestry.Models.DTO.Customer>>>();
//            moqCustomer.Setup(m => m.Get(It.IsAny<Uri>())).Returns(new List<Forestry.Models.DTO.Customer>());

//            Mock<IResourse<List<Forestry.Models.DTO.Premise>>> moqPremise = new Mock<IResourse<List<Forestry.Models.DTO.Premise>>>();
//            moqPremise.Setup(m => m.Get(It.IsAny<Uri>())).Returns(new List<Forestry.Models.DTO.Premise>());

//            Mock<IResourse<Forestry.Models.DTO.ExtraDetails>> moqExtraDetail = new Mock<IResourse<Forestry.Models.DTO.ExtraDetails>>();
//            moqExtraDetail.Setup(m => m.Get(It.IsAny<Uri>())).Returns(new Forestry.Models.DTO.ExtraDetails());

//            Mock<IResourse<List<Forestry.Models.DTO.Remark>>> moqRemarks = new Mock<IResourse<List<Forestry.Models.DTO.Remark>>>();
//            moqRemarks.Setup(
//                m => m.Get(It.IsAny<Uri>())
//            ).Returns(
//                new List<Forestry.Models.DTO.Remark>
//                {
//                    new Forestry.Models.DTO.Remark
//                    {
//                        WorkRequestId = 4011646,
//                        RemarkText = "Some Text"
//                    },
//                    new Forestry.Models.DTO.Remark
//                    {
//                        WorkRequestId = 4011646,
//                        RemarkText = "Some Other Text"
//                    }
//                }
//            );

//            Mock<IResourse<string>> moqStormsWorkQueue = new Mock<IResourse<string>>();
//            moqStormsWorkQueue.Setup(
//                m => m.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<IFExceptionCond>(x => x.CD_DIST == "NOEL" && x.CD_WR == 4011646 && x.DS_COND == "Failed Forestry data validation")
//                )
//            ).Returns(
//                new HttpResponseMessage()
//                {
//                    StatusCode = System.Net.HttpStatusCode.Created,
//                    Content = new System.Net.Http.StringContent("", Encoding.UTF8, "application/json")
//                }
//            );

//            Mock<IResourse<Forestry.Models.DTO.WorkRequestTracking>> moqWorkRequestTracking = new Mock<IResourse<Forestry.Models.DTO.WorkRequestTracking>>();
//            moqWorkRequestTracking.Setup(m => m.Post(
//                It.IsAny<Uri>(),
//                It.Is<Forestry.Models.DTO.WorkRequestTracking>(x => x.WorkRequestId == 4011646 && x.District == "NOEL")
//            )).Returns(
//                new HttpResponseMessage()
//                {
//                    RequestMessage = new HttpRequestMessage(HttpMethod.Post, It.IsAny<Uri>())
//                    {
//                        Method = HttpMethod.Post,
//                        Content = new System.Net.Http.StringContent("{  \"WorkRequestId\": 4011646 }")
//                    },
//                    StatusCode = System.Net.HttpStatusCode.Created,
//                    Content = new System.Net.Http.StringContent("", Encoding.UTF8, "application/json")
//                }
//            );

//            Mock<IResourse<string>> moqStormsMilestoneRequirement = new Mock<IResourse<string>>();
//            moqStormsMilestoneRequirement.Setup(m => m.Post(
//                It.IsAny<Uri>(),
//                It.Is<MilestoneRequirement>(x => x.WorkRequestId == "4011646" && x.District == "NOEL"))
//            ).Returns(
//                new HttpResponseMessage()
//                {
//                    StatusCode = System.Net.HttpStatusCode.Created,
//                    Content = new System.Net.Http.StringContent("", Encoding.UTF8, "application/json")
//                }
//            );

//            HttpResponseMessage incidentResponse = new HttpResponseMessage()
//            {
//                StatusCode = System.Net.HttpStatusCode.Created
//            };
//            incidentResponse.Headers.Add("X-Id", "INC123");

//            Mock<IResourse<Incident>> moqIncident = new Mock<IResourse<Incident>>();
//            moqIncident.Setup(
//                m => m.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<Incident>(x => x.Notes == "[WR: 4011646 WP: 2322760]\r\nRequired by date is null or empty\r\nIO Installation is null or empty\r\nArea is null or empty\r\nJob Type is null or empty\r\nContact name is null or empty\r\nContact phone is null or empty\r\nCustomer informaton is missing\r\nContact name is null or empty\r\nContact phone is null or empty\r\nAddress information is missing\r\n")
//                )
//            ).Returns(incidentResponse);

//            StormsForestryService service = new StormsForestryService(
//                //moqHttpClient.Object,
//                moqWorkRequest.Object,
//                moqCustomer.Object,
//                moqPremise.Object,
//                moqExtraDetail.Object,
//                moqRemarks.Object,
//                moqStormsMilestoneRequirement.Object,
//                moqStormsWorkQueue.Object,
//                null,
//                moqIncident.Object,
//                moqWorkRequestTracking.Object
//            );

//            //act
//            service.ProcessWorkPacket(
//                new Models.DTO.WorkPacket
//                {
//                    WorkRequestId = 4011646,
//                    WorkPacketId = 2322760
//                }
//            );

//            //assert
//            Assert.NotNull(service);
//            //verify it was called
//            moqWorkRequest.Verify(
//                i => i.Get(It.IsAny<Uri>())
//            );
//            moqStormsWorkQueue.Verify(i => i.Post(
//                It.IsAny<Uri>(),
//                It.Is<IFExceptionCond>(x => x.CD_DIST == "NOEL" && x.CD_WR == 4011646))
//            );
//            moqWorkRequestTracking.Verify(
//                i => i.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<Forestry.Models.DTO.WorkRequestTracking>(x => x.WorkRequestId == 4011646 && x.District == "NOEL")
//                )
//            );
//            moqStormsMilestoneRequirement.Verify(i => i.Post(
//                It.IsAny<Uri>(),
//                It.Is<MilestoneRequirement>(x => x.District == "NOEL"))
//            );
//        }

//        [Fact]
//        public void TestGetWorkRequestFromApi()
//        {
//            //arrange - mock it up
//            Mock<IHttpClient> moqHttpClient = new Mock<IHttpClient>();

//            dynamic workRequest = new System.Dynamic.ExpandoObject();
//            workRequest.id = 4011646;
//            workRequest.customersUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.premisesUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.extraDetailsUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.remarksUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";

//            Mock<IResourse<dynamic>> moqWorkRequest = new Mock<IResourse<dynamic>>();
//            moqWorkRequest.Setup(m => m.Get(It.IsAny<Uri>())).Returns((object)workRequest);

//            Mock<IResourse<List<Forestry.Models.DTO.Customer>>> moqCustomer = new Mock<IResourse<List<Forestry.Models.DTO.Customer>>>();
//            moqCustomer.Setup(m => m.Get(It.IsAny<Uri>())).Returns(new List<Forestry.Models.DTO.Customer>());

//            Mock<IResourse<List<Forestry.Models.DTO.Premise>>> moqPremise = new Mock<IResourse<List<Forestry.Models.DTO.Premise>>>();
//            moqPremise.Setup(m => m.Get(It.IsAny<Uri>())).Returns(new List<Forestry.Models.DTO.Premise>());

//            Mock<IResourse<Forestry.Models.DTO.ExtraDetails>> moqExtraDetail = new Mock<IResourse<Forestry.Models.DTO.ExtraDetails>>();
//            moqExtraDetail.Setup(m => m.Get(It.IsAny<Uri>())).Returns(new Forestry.Models.DTO.ExtraDetails());

//            Mock<IResourse<List<Forestry.Models.DTO.Remark>>> moqRemarks = new Mock<IResourse<List<Forestry.Models.DTO.Remark>>>();
//            moqRemarks.Setup(m => m.Get(It.IsAny<Uri>())).Returns(
//                new List<Forestry.Models.DTO.Remark>
//                {
//                    new Forestry.Models.DTO.Remark
//                    {
//                        WorkRequestId = 4011646,
//                        RemarkText = "Some Text"
//                    },
//                    new Forestry.Models.DTO.Remark
//                    {
//                        WorkRequestId = 4011646,
//                        RemarkText = "Some Other Text"
//                    }
//                }
//            );

//            StormsForestryService service = new StormsForestryService(
//                //moqHttpClient.Object,
//                moqWorkRequest.Object,
//                moqCustomer.Object,
//                moqPremise.Object,
//                moqExtraDetail.Object,
//                moqRemarks.Object,
//                null,
//                null,
//                null,
//                null,
//                null
//            );

//            //act
//            Forestry.Models.DTO.WorkRequest serviceresponse = service.GetWorkRequestFromApi(
//                new Models.DTO.WorkPacket
//                {
//                    WorkRequestId = 4011646,
//                    WorkPacketId = 2322760
//                }
//            );

//            //assert - run the unit test with xunit
//            Assert.Equal(4011646, serviceresponse.Id);
//            Assert.Collection(
//                serviceresponse.Remarks,
//                item =>
//                {
//                    Assert.Equal(4011646, item.WorkRequestId);
//                    Assert.Equal("Some Text", item.RemarkText);
//                },
//                item =>
//                {
//                    Assert.Equal(4011646, item.WorkRequestId);
//                    Assert.Equal("Some Other Text", item.RemarkText);
//                }
//            );
//        }
//        [Fact]
//        public void TestProcessForestry()
//        {
//            //arrange - mock it up
//            Mock<IHttpClient> moqHttpClient = new Mock<IHttpClient>();

//            dynamic workRequest = new System.Dynamic.ExpandoObject();
//            workRequest.id = 4011646;
//            workRequest.customersUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.premisesUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.extraDetailsUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.remarksUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";

//            Mock<IResourse<dynamic>> moqWorkRequest = new Mock<IResourse<dynamic>>();
//            moqWorkRequest.Setup(m => m.Get(It.IsAny<Uri>())).Returns((object)workRequest);

//            Mock<IResourse<List<Forestry.Models.DTO.Customer>>> moqCustomer = new Mock<IResourse<List<Forestry.Models.DTO.Customer>>>();
//            moqCustomer.Setup(m => m.Get(It.IsAny<Uri>())).Returns(new List<Forestry.Models.DTO.Customer>());

//            Mock<IResourse<List<Forestry.Models.DTO.Premise>>> moqPremise = new Mock<IResourse<List<Forestry.Models.DTO.Premise>>>();
//            moqPremise.Setup(m => m.Get(It.IsAny<Uri>())).Returns(new List<Forestry.Models.DTO.Premise>());

//            Mock<IResourse<Forestry.Models.DTO.ExtraDetails>> moqExtraDetail = new Mock<IResourse<Forestry.Models.DTO.ExtraDetails>>();
//            moqExtraDetail.Setup(m => m.Get(It.IsAny<Uri>())).Returns(new Forestry.Models.DTO.ExtraDetails());

//            Mock<IResourse<List<Forestry.Models.DTO.Remark>>> moqRemarks = new Mock<IResourse<List<Forestry.Models.DTO.Remark>>>();
//            moqRemarks.Setup(m => m.Get(It.IsAny<Uri>())).Returns(
//                new List<Forestry.Models.DTO.Remark>
//                {
//                    new Forestry.Models.DTO.Remark
//                    {
//                        WorkRequestId = 4011646,
//                        RemarkText = "Some Text"
//                    },
//                    new Forestry.Models.DTO.Remark
//                    {
//                        WorkRequestId = 4011646,
//                        RemarkText = "Some Other Text"
//                    }
//                }
//            );

//            Mock<IResourse<string>> moqStormsMilestoneRequirement = new Mock<IResourse<string>>();
//            moqStormsMilestoneRequirement.Setup(m => m.Post(
//                It.IsAny<Uri>(),
//                It.Is<MilestoneRequirement>(x => x.District == "NOEL"))
//            ).Returns(
//                new HttpResponseMessage()
//                {
//                    StatusCode = System.Net.HttpStatusCode.Created,
//                    Content = new System.Net.Http.StringContent("", Encoding.UTF8, "application/json")
//                }
//            );

//            Mock<IResourse<string>> moqStormsWorkQueue = new Mock<IResourse<string>>();
//            moqStormsWorkQueue.Setup(m => m.Get(It.IsAny<Uri>()));

//            Mock<IResourse<ForestryRequest>> moqForestryRequest = new Mock<IResourse<ForestryRequest>>();
//            moqForestryRequest.Setup(m => m.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<ForestryRequest>(x => x.Method == "POST")
//                )
//            ).Returns(
//                new HttpResponseMessage
//                {
//                    StatusCode = System.Net.HttpStatusCode.Created,
//                    Content = new System.Net.Http.StringContent(
//                        "{ \"id\": 4014022" +
//                        ", \"customersUri\": \"https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4014022/customers\"" +
//                        ", \"premisesUri\": \"https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4014022/customers\"" +
//                        ", \"extraDetailsUri\": \"https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4014022/customers\"" +
//                        ", \"remarksUri\": \"https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4014022/customers\"" +
//                        "}".Trim(), Encoding.UTF8, "application/json")
//                }
//            );



//            Mock<IResourse<Incident>> moqIncident = new Mock<IResourse<Incident>>();
//            moqIncident.Setup(m => m.Post(It.IsAny<Uri>(), It.Is<Incident>(x => x.Id == "123")));




//            Mock<IResourse<Forestry.Models.DTO.WorkRequestTracking>> moqStormsTracking = new Mock<IResourse<Forestry.Models.DTO.WorkRequestTracking>>();
//            moqStormsTracking.Setup(m => m.Post(
//                It.IsAny<Uri>(),
//                It.Is<Forestry.Models.DTO.WorkRequestTracking>(x => x.WorkRequestId == 123)
//            )).Returns(
//                new HttpResponseMessage()
//                {
//                    RequestMessage = new HttpRequestMessage(HttpMethod.Post, It.IsAny<Uri>())
//                    {
//                        Method = HttpMethod.Post,
//                        Content = new System.Net.Http.StringContent("{  \"WorkRequestId\": 123 }")
//                    },
//                    StatusCode = System.Net.HttpStatusCode.Created,
//                    Content = new System.Net.Http.StringContent("", Encoding.UTF8, "application/json")
//                }
//            );

//            StormsForestryService service = new StormsForestryService(
//                //moqHttpClient.Object,
//                moqWorkRequest.Object,
//                moqCustomer.Object,
//                moqPremise.Object,
//                moqExtraDetail.Object,
//                moqRemarks.Object,
//                moqStormsMilestoneRequirement.Object,
//                moqStormsWorkQueue.Object,
//                moqForestryRequest.Object,
//                moqIncident.Object,
//                moqStormsTracking.Object
//            );

//            //act
//            service.ProcessForestry(
//                new Models.DTO.WorkRequest {
//                    Id = 4011646
//                },
//                new Models.DTO.WorkPacket {
//                    WorkRequestId = 4011646,
//                    WorkPacketId = 2322760
//                },
//                new ForestryRequest {
//                    Method = "POST"
//                }
//            );

//            //assert
//            Assert.NotNull(service);
//            //verify it was called
//            moqForestryRequest.Verify(i => i.Post(
//                It.IsAny<Uri>(),
//                It.Is<ForestryRequest>(x => x.Method == "POST"))
//            );
//        }
//        [Fact]
//        public void TestProcessForestryException()
//        {
//            //arrange - mock it up
//            Mock<IHttpClient> moqHttpClient = new Mock<IHttpClient>();

//            dynamic workRequest = new System.Dynamic.ExpandoObject();
//            workRequest.id = 4011646;
//            workRequest.customersUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.premisesUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.extraDetailsUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.remarksUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";

//            Mock<IResourse<dynamic>> moqWorkRequest = new Mock<IResourse<dynamic>>();
//            moqWorkRequest.Setup(m => m.Get(It.IsAny<Uri>())).Returns((object)workRequest);

//            Mock<IResourse<List<Forestry.Models.DTO.Customer>>> moqCustomer = new Mock<IResourse<List<Forestry.Models.DTO.Customer>>>();
//            moqCustomer.Setup(m => m.Get(It.IsAny<Uri>())).Returns(new List<Forestry.Models.DTO.Customer>());

//            Mock<IResourse<List<Forestry.Models.DTO.Premise>>> moqPremise = new Mock<IResourse<List<Forestry.Models.DTO.Premise>>>();
//            moqPremise.Setup(m => m.Get(It.IsAny<Uri>())).Returns(new List<Forestry.Models.DTO.Premise>());

//            Mock<IResourse<Forestry.Models.DTO.ExtraDetails>> moqExtraDetail = new Mock<IResourse<Forestry.Models.DTO.ExtraDetails>>();
//            moqExtraDetail.Setup(m => m.Get(It.IsAny<Uri>())).Returns(new Forestry.Models.DTO.ExtraDetails());

//            Mock<IResourse<List<Forestry.Models.DTO.Remark>>> moqRemarks = new Mock<IResourse<List<Forestry.Models.DTO.Remark>>>();
//            moqRemarks.Setup(m => m.Get(It.IsAny<Uri>())).Returns(
//                new List<Forestry.Models.DTO.Remark>
//                {
//                    new Forestry.Models.DTO.Remark
//                    {
//                        WorkRequestId = 4011646,
//                        RemarkText = "Some Text"
//                    },
//                    new Forestry.Models.DTO.Remark
//                    {
//                        WorkRequestId = 4011646,
//                        RemarkText = "Some Other Text"
//                    }
//                }
//            );

//            Mock<IResourse<string>> moqStormsMilestoneRequirement = new Mock<IResourse<string>>();
//            moqStormsMilestoneRequirement.Setup(m => m.Post(
//                It.IsAny<Uri>(),
//                It.Is<MilestoneRequirement>(x => x.District == "NOEL"))
//            ).Returns(
//                new HttpResponseMessage()
//                {
//                    StatusCode = System.Net.HttpStatusCode.Created,
//                    Content = new System.Net.Http.StringContent("", Encoding.UTF8, "application/json")
//                }
//            );

//            Mock<IResourse<string>> moqStormsWorkQueue = new Mock<IResourse<string>>();
//            moqStormsWorkQueue.Setup(m => m.Get(It.IsAny<Uri>()));

//            //mock throw 500 error
//            Mock<IResourse<ForestryRequest>> moqForestryRequest = new Mock<IResourse<ForestryRequest>>();
//            moqForestryRequest.Setup(m => m.Post(
//                It.IsAny<Uri>(),
//                It.Is<ForestryRequest>(x => x.Method == "POST")
//            )).Throws(
//                new HttpResponseException(System.Net.HttpStatusCode.InternalServerError)
//            );

//            HttpResponseMessage incidentResponse = new HttpResponseMessage()
//            {
//                StatusCode = System.Net.HttpStatusCode.Created
//            };
//            incidentResponse.Headers.Add("X-Id", "");

//            Mock<IResourse<Incident>> moqIncident = new Mock<IResourse<Incident>>();
//            moqIncident.Setup(m => m.Post(
//                It.IsAny<Uri>(),
//                It.Is<Incident>(x => x.Notes == null)
//            )).Returns(incidentResponse);

//            Mock<IResourse<Forestry.Models.DTO.WorkRequestTracking>> moqStormsTracking = new Mock<IResourse<Forestry.Models.DTO.WorkRequestTracking>>();
//            moqStormsTracking.Setup(
//                m => m.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<Forestry.Models.DTO.WorkRequestTracking>(x => x.WorkRequestId == 4011646 && x.District == "NOEL")
//                )
//            ).Returns(
//                new HttpResponseMessage()
//                {
//                    RequestMessage = new HttpRequestMessage(HttpMethod.Post, It.IsAny<Uri>())
//                    {
//                        Method = HttpMethod.Post,
//                        Content = new System.Net.Http.StringContent("{  \"WorkRequestId\": 4011646 }")
//                    },
//                    StatusCode = System.Net.HttpStatusCode.Created,
//                    Content = new System.Net.Http.StringContent("", Encoding.UTF8, "application/json")
//                }
//            );

//            StormsForestryService service = new StormsForestryService(
//                //moqHttpClient.Object,
//                moqWorkRequest.Object,
//                moqCustomer.Object,
//                moqPremise.Object,
//                moqExtraDetail.Object,
//                moqRemarks.Object,
//                moqStormsMilestoneRequirement.Object,
//                moqStormsWorkQueue.Object,
//                moqForestryRequest.Object,
//                moqIncident.Object,
//                moqStormsTracking.Object
//            );

//            //act
//            service.ProcessForestry(
//                new Models.DTO.WorkRequest
//                {
//                    Id = 4011646,
//                    District = "NOEL"
//                },
//                new Models.DTO.WorkPacket
//                {
//                    WorkRequestId = 4011646,
//                    WorkPacketId = 2322760
//                },
//                new ForestryRequest
//                {
//                    Method = "POST"
//                }
//            );

//            //assert
//            Assert.NotNull(service);

//            moqStormsTracking.Verify(
//                i => i.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<Forestry.Models.DTO.WorkRequestTracking>(x => x.WorkRequestId == 4011646 && x.District == "NOEL")
//                )
//            );
//            moqIncident.Verify(
//                i => i.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<Incident>(x => x.Notes == null)
//                )
//            );

//        }
//        [Fact]
//        public void TestAddStormsMilestoneRequirement()
//        {
//            //arrange - mock it up
//            Mock<IHttpClient> moqHttpClient = new Mock<IHttpClient>();

//            dynamic workRequest = new System.Dynamic.ExpandoObject();
//            workRequest.id = 4011646;
//            workRequest.customersUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.premisesUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.extraDetailsUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";
//            workRequest.remarksUri = "https://xxxxx/Energy-Delivery/ManagedWorkOrder/api/v1/work-requests/4011646/customers";

//            Mock<IResourse<dynamic>> moqWorkRequest = new Mock<IResourse<dynamic>>();
//            moqWorkRequest.Setup(m => m.Get(It.IsAny<Uri>())).Returns((object)workRequest);

//            Mock<IResourse<List<Forestry.Models.DTO.Customer>>> moqCustomer = new Mock<IResourse<List<Forestry.Models.DTO.Customer>>>();
//            moqCustomer.Setup(m => m.Get(It.IsAny<Uri>())).Returns(new List<Forestry.Models.DTO.Customer>());

//            Mock<IResourse<List<Forestry.Models.DTO.Premise>>> moqPremise = new Mock<IResourse<List<Forestry.Models.DTO.Premise>>>();
//            moqPremise.Setup(m => m.Get(It.IsAny<Uri>())).Returns(new List<Forestry.Models.DTO.Premise>());

//            Mock<IResourse<Forestry.Models.DTO.ExtraDetails>> moqExtraDetail = new Mock<IResourse<Forestry.Models.DTO.ExtraDetails>>();
//            moqExtraDetail.Setup(m => m.Get(It.IsAny<Uri>())).Returns(new Forestry.Models.DTO.ExtraDetails());

//            Mock<IResourse<List<Forestry.Models.DTO.Remark>>> moqRemarks = new Mock<IResourse<List<Forestry.Models.DTO.Remark>>>();
//            moqRemarks.Setup(m => m.Get(It.IsAny<Uri>())).Returns(
//                new List<Forestry.Models.DTO.Remark>
//                {
//                    new Forestry.Models.DTO.Remark
//                    {
//                        WorkRequestId = 4011646,
//                        RemarkText = "Some Text"
//                    },
//                    new Forestry.Models.DTO.Remark
//                    {
//                        WorkRequestId = 4011646,
//                        RemarkText = "Some Other Text"
//                    }
//                }
//            );

//            Mock<IResourse<string>> moqStormsMilestoneRequirement = new Mock<IResourse<string>>();
//            moqStormsMilestoneRequirement.Setup(m => m.Post(
//                It.IsAny<Uri>(),
//                It.Is<MilestoneRequirement>(x => x.District == "NOEL"))
//            ).Returns(
//                new HttpResponseMessage()
//                {
//                    StatusCode = System.Net.HttpStatusCode.Created,
//                    Content = new System.Net.Http.StringContent("", Encoding.UTF8, "application/json")
//                }
//            );

//            StormsForestryService service = new StormsForestryService(
//                //moqHttpClient.Object,
//                moqWorkRequest.Object,
//                null,
//                null,
//                null,
//                null,
//                moqStormsMilestoneRequirement.Object,
//                null,
//                null,
//                null,
//                null
//            );

//            //act
//            service.AddStormsMilestoneRequirement(
//                new Models.DTO.WorkRequest
//                {
//                    Id = 789,
//                    District = "NOEL"
//                }, 
//                new Models.DTO.WorkPacket
//                {
//                    WorkRequestId = 123,
//                    WorkPacketId = 456
//                }
//            );

//            //assert
//            Assert.NotNull(service);
//            //verify it was called
//            moqStormsMilestoneRequirement.Verify(i => i.Post(
//                It.IsAny<Uri>(),
//                It.Is<MilestoneRequirement>(x => x.District == "NOEL"))
//            );

//        }
//        [Fact]
//        public void TestAddStormsWorkQueue()
//        {
//            //arrange - mock it up
//            //Mock<IHttpClient> moqHttpClient = new Mock<IHttpClient>();

//            Mock<IResourse<string>> moqStormsWorkQueue = new Mock<IResourse<string>>();
//            moqStormsWorkQueue.Setup(m => m.Post(
//                It.IsAny<Uri>(),
//                It.Is<IFExceptionCond>(x => x.CD_DIST == "NOEL" && x.CD_WR == 4011646))
//            ).Returns(
//                new HttpResponseMessage()
//                {
//                    StatusCode = System.Net.HttpStatusCode.Created,
//                    Content = new System.Net.Http.StringContent("", Encoding.UTF8, "application/json")
//                }
//            );

//            StormsForestryService service = new StormsForestryService(
//                //moqHttpClient.Object,
//                null,
//                null,
//                null,
//                null,
//                null,
//                null,
//                moqStormsWorkQueue.Object,
//                null,
//                null,
//                null
//            );

//            //act
//            service.AddStormsWorkQueue(
//                new Models.DTO.WorkRequest
//                {
//                    Id = 4011646,
//                    District = "NOEL"
//                },
//                new Models.DTO.WorkPacket
//                {
//                    WorkRequestId = 4011646,
//                    WorkPacketId = 456
//                },
//                "Some Details"
//            );

//            //assert
//            Assert.NotNull(service);
//            //verify it was called
//            moqStormsWorkQueue.Verify(i => i.Post(
//                It.IsAny<Uri>(),
//                It.Is<IFExceptionCond>(x => x.CD_DIST == "NOEL"))
//            );

//        }
//        [Fact]
//        public void TestAddStormsTracking()
//        {
//            //arrange - mock it up
//            //Mock<IHttpClient> moqHttpClient = new Mock<IHttpClient>();

//            Mock<IResourse<Forestry.Models.DTO.WorkRequestTracking>> moqWorkRequestTracking = new Mock<IResourse<Forestry.Models.DTO.WorkRequestTracking>>();
//            moqWorkRequestTracking.Setup(m => m.Post(
//                It.IsAny<Uri>(),
//                It.Is<Forestry.Models.DTO.WorkRequestTracking>(x => x.WorkRequestId == 123 && x.District == "NOEL")
//            )).Returns(
//                new HttpResponseMessage()
//                {
//                    RequestMessage = new HttpRequestMessage(HttpMethod.Post, It.IsAny<Uri>())
//                    {
//                        Method = HttpMethod.Post,
//                        Content = new System.Net.Http.StringContent("{  \"WorkRequestId\": 123 }")
//                    },
//                    StatusCode = System.Net.HttpStatusCode.Created,
//                    Content = new System.Net.Http.StringContent("", Encoding.UTF8, "application/json")
//                }
//            );

//            StormsForestryService service = new StormsForestryService(
//                //null,
//                null,
//                null,
//                null,
//                null,
//                null,
//                null,
//                null,
//                null,
//                null,
//                moqWorkRequestTracking.Object
//            );

//            //act
//            service.AddStormsTracking(
//                new Models.DTO.WorkRequest
//                {
//                    Id = 4011646,
//                    District = "NOEL"
//                },
//                new Models.DTO.WorkPacket
//                {
//                    WorkRequestId = 4011646,
//                    WorkPacketId = 456
//                },
//                "e12345",
//                "",
//                ""
//            );

//            //assert
//            Assert.NotNull(service);
//            //verify it was called
//            moqWorkRequestTracking.Verify(
//                i => i.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<Forestry.Models.DTO.WorkRequestTracking>(x => x.WorkRequestId == 4011646 && x.District == "NOEL")
//                )
//            );

//        }
//        [Fact]
//        public void TestCreateRemedyTicket_ValidationResults()
//        {
//            //arrange - mock it up
//            //Mock<IHttpClient> moqHttpClient = new Mock<IHttpClient>();

//            HttpResponseMessage incidentResponse = new HttpResponseMessage()
//            {
//                StatusCode = System.Net.HttpStatusCode.Created
//            };
//            incidentResponse.Headers.Add("X-Id", "INC123");

//            Mock<IResourse<Incident>> moqIncident = new Mock<IResourse<Incident>>();
//            moqIncident.Setup(
//                m => m.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<Incident>(x => x.Notes == "[WR: 4011646 WP: 456]\r\n")
//                )
//            ).Returns(incidentResponse);

//            StormsForestryService service = new StormsForestryService(
//                //moqHttpClient.Object,
//                null,
//                null,
//                null,
//                null,
//                null,
//                null,
//                null,
//                null,
//                moqIncident.Object,
//                null
//            );

//            //act
//            service.CreateRemedyTicket(
//                new Models.DTO.WorkRequest
//                {
//                    Id = 4011646,
//                    District = "NOEL"
//                },
//                new Models.DTO.WorkPacket
//                {
//                    WorkRequestId = 4011646,
//                    WorkPacketId = 456
//                },
//                new List<System.ComponentModel.DataAnnotations.ValidationResult>()
//            );

//            //assert
//            Assert.NotNull(service);
//            //verify it was called
//            moqIncident.Verify(
//                i => i.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<Incident>(x => x.Notes == "[WR: 4011646 WP: 456]\r\n")
//                )
//            );
//        }
//        [Fact]
//        public void TestCreateRemedyTicket_Exception()
//        {
//            //arrange - mock it up
//            Mock<IHttpClient> moqHttpClient = new Mock<IHttpClient>();

//            HttpResponseMessage incidentResponse = new HttpResponseMessage()
//            {
//                StatusCode = System.Net.HttpStatusCode.Created
//            };
//            incidentResponse.Headers.Add("X-Id", "INC123");

//            Mock<IResourse<Incident>> moqIncident = new Mock<IResourse<Incident>>();
//            moqIncident.Setup(
//                m => m.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<Incident>(x => x.Notes == null)
//                )
//            ).Returns(incidentResponse);

//            StormsForestryService service = new StormsForestryService(
//                //moqHttpClient.Object,
//                null,
//                null,
//                null,
//                null,
//                null,
//                null,
//                null,
//                null,
//                moqIncident.Object,
//                null
//            );

//            //act
//            service.CreateRemedyTicket(
//                new Models.DTO.WorkRequest
//                {
//                    Id = 4011646,
//                    District = "NOEL"
//                },
//                new Models.DTO.WorkPacket
//                {
//                    WorkRequestId = 4011646,
//                    WorkPacketId = 456
//                },
//                new Exception()
//            );

//            //assert
//            Assert.NotNull(service);
//            //verify it was called
//            moqIncident.Verify(
//                i => i.Post(
//                    It.IsAny<Uri>(),
//                    It.Is<Incident>(x => x.Notes == null)
//                )
//            );

//        }

//    }
//}
