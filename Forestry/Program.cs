using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Forestry.Models;
using Forestry.Models.DTO;
using Forestry.Requestors;
using Forestry.Services;
using Newtonsoft.Json;

namespace Forestry
{
    class Program
    {
        public static IContainer Container;
        
        private static ContainerBuilder ContainerBuilder()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<Services.HttpClientHandler>().As<IHttpClient>();

            builder.RegisterType<WorkRequestRequestor>().As<IResourse<dynamic>>();
            builder.Register(context => WorkRequestRequestorSetting.Get());

            builder.RegisterType<WorkRequestCustomerRequestor>().As<IResourse<List<Forestry.Models.DTO.Customer>>>();
            builder.Register(context => WorkRequestCustomerRequestorSetting.Get());

            builder.RegisterType<WorkRequestPremiseRequestor>().As<IResourse<List<Forestry.Models.DTO.Premise>>>();
            builder.Register(context => WorkRequestPremiseRequestorSetting.Get());

            builder.RegisterType<WorkRequestExtraDetailsRequestor>().As<IResourse<Forestry.Models.DTO.ExtraDetails>>();
            builder.Register(context => WorkRequestExtraDetailsRequestorSetting.Get());

            builder.RegisterType<WorkRequestRemarkRequestor>().As<IResourse<List<Forestry.Models.DTO.Remark>>>();
            builder.Register(context => WorkRequestRemarkRequestorSetting.Get());

            builder.RegisterType<WorkRequestMilestoneRequirementRequestor>().As<IResourse<Forestry.Models.DTO.MilestoneRequirement>>();
            builder.Register(context => WorkRequestMilestoneRequirementRequestorSetting.Get());

            builder.RegisterType<StormsWorkQueueRequestor>().As<IResourse<string>>();
            builder.Register(context => StormsWorkQueueRequestorSetting.Get());
            
            builder.RegisterType<ForestryRequestor>().As<IResourse<ForestryRequest>>();
            builder.Register(context => ForestryRequestorSetting.Get());

            builder.RegisterType<IncidentRequestor>().As<IResourse<Incident>>();
            builder.Register(context => IncidentRequestorSetting.Get());

            builder.RegisterType<WorkRequestTrackingRequestor>().As<IResourse<WorkRequestTracking>>();
            builder.Register(context => WorkRequestTrackingRequestorSetting.Get());

            return builder;
        }

        static void Main(string[] args)
        {
            //build AutoFac container Dependency Injection
            Container = ContainerBuilder().Build();
            
            StormsForestryService service = new StormsForestryService(
                //Container.Resolve<IHttpClient>(),
                Container.Resolve<IResourse<dynamic>>(),
                Container.Resolve<IResourse<List<Forestry.Models.DTO.Customer>>>(),
                Container.Resolve<IResourse<List<Forestry.Models.DTO.Premise>>>(),
                Container.Resolve<IResourse<Forestry.Models.DTO.ExtraDetails>>(),
                Container.Resolve<IResourse<List<Forestry.Models.DTO.Remark>>>(),
                Container.Resolve<IResourse<Forestry.Models.DTO.MilestoneRequirement>>(),
                Container.Resolve<IResourse<string>>(),
                Container.Resolve<IResourse<ForestryRequest>>(),
                Container.Resolve<IResourse<Incident>>(),
                Container.Resolve<IResourse<Forestry.Models.DTO.WorkRequestTracking>>()
            );

            Console.WriteLine("============================================================================");
            Console.WriteLine("==Process Date: " + DateTime.Now);
            Console.WriteLine("==Retrieving WorkRequest(s)  to be sent to Forestry");
            List<Forestry.Models.DTO.WorkPacket> workPackets = service.GetWorkPackets();
            Console.WriteLine("==Retrieved  WorkRequest(s): " + workPackets.Count + " to be sent to Forestry");
            int i = 1;
            foreach (var workPacket in workPackets)
            {
                Console.WriteLine("============================================================================");
                Console.WriteLine("==Processing:" + i + " of " + workPackets.Count);
                Console.WriteLine("============================================================================");
                service.ProcessWorkPacket(workPacket);
                i++;
            }
            Console.WriteLine("==Completed: " + DateTime.Now + " ========================================");
            Console.WriteLine("============================================================================");

            Environment.ExitCode = 0;
        }
    }
}